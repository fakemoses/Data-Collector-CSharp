using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Data_Collector_CSharp
{
    public partial class CollectDataForm : Form
    {
        private FormHandler handler;
        private bool isStartStopButtonClicked = false;
        private System.Threading.Timer timer;

        /// <summary>
        /// Constructor
        /// </summary>
        public CollectDataForm()
        {
            InitializeComponent();
            logBox.ScrollBars = ScrollBars.Vertical;
            logBox.WordWrap = false;

            handler = new FormHandler();

            IPBox.Text = handler.GetIP();
            portBox.Text = handler.GetPort().ToString();
            requestBox.Text = handler.GetRequestString();

            handler.LogUpdated += UpdateLogBox;
        }

        /// <summary>
        /// Update the log box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateLogBox(object? sender, EventArgs e)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new MethodInvoker(delegate { logBox.Text = handler.log; }));
                logBox.Invoke(new MethodInvoker(delegate { logBox.SelectionStart = logBox.TextLength; }));
                logBox.Invoke(new MethodInvoker(delegate { logBox.ScrollToCaret(); }));
            }
            else
            {
                logBox.Text = handler.log;
                logBox.SelectionStart = logBox.TextLength;
                logBox.ScrollToCaret();
            }

        }

        /// <summary>
        /// Update the IP address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPBox_TextChanged(object sender, EventArgs e)
        {
            if (!isStartStopButtonClicked)
            {
                handler.SetIP(this.IPBox.Text);
            }
        }

        /// <summary>
        /// On port box changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void portBox_TextChanged(object sender, EventArgs e)
        {
            if (!isStartStopButtonClicked)
            {
                handler.SetIP(this.portBox.Text);
            }
        }


        /// <summary>
        /// Start/Stop button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (isStartStopButtonClicked)
            {
                isStartStopButtonClicked = false;
                handler.CloseConnection();
                handler.log += "Program stopped at " + handler.GetCurrentTime() + "\r\n";
                logBox.Text = handler.log;
                ChangeControlBehaviour(isStartStopButtonClicked);
            }
            else
            {
                isStartStopButtonClicked = true;
                timer = new System.Threading.Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));

                handler.StartAndConnect(IPBox.Text, Int32.Parse(portBox.Text));

                ChangeControlBehaviour(isStartStopButtonClicked);

            }


        }

        /// <summary>
        /// Change the control behaviour
        /// </summary>
        /// <param name="c"></param>
        private void ChangeControlBehaviour(bool c)
        {
            if (!c)
                StartStopButton.Text = "Start";
            else
                StartStopButton.Text = "Stop";

            portBox.Enabled = !c;
            IPBox.Enabled = !c;
            requestBox.Enabled = !c;
        }

        /// <summary>
        /// Timer callback for threading
        /// </summary>
        /// <param name="state"></param>
        private void TimerCallback(object state)
        {

            if (isStartStopButtonClicked)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    handler.RetrieveDataAndUpdate();
                });
            }
            else
            {
                // Stop the timer if the thread should not continue running
                timer.Dispose();
            }
        }


        /// <summary>
        /// request box changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void requestBox_TextChanged(object sender, EventArgs e)
        {
            if (!isStartStopButtonClicked)
            {
                handler.SetRequestString(this.requestBox.Text);
            }
        }

        /// <summary>
        /// Save button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            Data.SaveData(handler.log);
        }
    }
}