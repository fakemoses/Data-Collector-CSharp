using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Collector_CSharp
{
    /// <summary>
    /// Handles the form and client
    /// </summary>
    class FormHandler
    {
        private readonly Client c;
        public event EventHandler LogUpdated;
        public event EventHandler IPBoxChanged;
        public event EventHandler RequestBoxChanged;

        public string log = "";
        private DateTime currentTime;
        private string formattedTime;

        private string IP;
        private string requestString;
        private int port;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormHandler() 
        {
            this.IP = "192.168.0.20";
            this.port = 8090;
            this.requestString = "Request Data";

            c = new Client(IP, port);
            currentTime = DateTime.Now;
            formattedTime = currentTime.ToString("HH:mm");
        }

        /// <summary>
        /// Get the IP address
        /// </summary>
        /// <returns></returns>
        public string GetIP()
        {
            return IP;
        }

        /// <summary>
        /// Get the port
        /// </summary>
        /// <returns></returns>
        public int GetPort()
        {
            return port;
        }

        /// <summary>
        /// Get the request string
        /// </summary>
        /// <returns></returns>
        public string GetRequestString()
        {
            return requestString;
        }

        /// <summary>
        /// Start the client and connect to the server
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        public void StartAndConnect(string IP, int port)
        {
            this.IP = IP;
            this.port = port;
            c.IP = IP;
            c.Port = port;
            log = "Program initialized at " + formattedTime + "\r\n";
            log += "Connected to " + c.IP + " on port " + c.Port + "\r\n";
            OnLogUpdated(EventArgs.Empty);
        }

        /// <summary>
        /// Close the connection
        /// </summary>
        public void CloseConnection()
        {
            c.CloseClient();
        }

        /// <summary>
        /// Retrieve data from the server and update the log
        /// </summary>
        public void RetrieveDataAndUpdate()
        {
            string res = c.RequestDatafromServer(requestString);
            if (res != null)
            {
                log += res + " \r\n";
                OnLogUpdated(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Set the request string
        /// </summary>
        /// <param name="requestString"></param>
        public void SetRequestString(string requestString)
        {
            this.requestString = requestString;
            OnRequestBoxChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Set the IP address
        /// </summary>
        /// <param name="ip"></param>
        public void SetIP(string ip)
        {
            IP = ip;
            OnIPBoxChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Set the port
        /// </summary>
        /// <param name="port"></param>
        public void SetPort(int port)
        {
            this.port = port;
            OnPortBoxChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Event handler for log updated
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnLogUpdated(EventArgs e)
        {
            LogUpdated?.Invoke(this, e);
        }

        /// <summary>
        /// Event handler for IP box changed
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnIPBoxChanged(EventArgs e)
        {
            LogUpdated?.Invoke(this, e);
        }

        /// <summary>
        /// Event handler for port box changed
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPortBoxChanged(EventArgs e)
        {
            IPBoxChanged?.Invoke(this, e); 
            //?. is the null-conditional operator
            //It checks if the object is null before accessing its members
        }

        /// <summary>
        /// Event handler for request box changed
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRequestBoxChanged(EventArgs e)
        {
            RequestBoxChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Get the current time
        /// </summary>
        /// <returns></returns>
        public string GetCurrentTime()
        {
            return formattedTime;
        }

    }
}
