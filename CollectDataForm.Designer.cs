namespace Data_Collector_CSharp
{
    partial class CollectDataForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            logBox = new TextBox();
            label1 = new Label();
            StartStopButton = new Button();
            SaveAsButton = new Button();
            IPBox = new TextBox();
            portBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            requestBox = new TextBox();
            SuspendLayout();
            // 
            // logBox
            // 
            logBox.BorderStyle = BorderStyle.FixedSingle;
            logBox.Location = new Point(12, 126);
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new Size(429, 172);
            logBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 100);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 1;
            label1.Text = "Log:";
            // 
            // StartStopButton
            // 
            StartStopButton.Location = new Point(245, 308);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(94, 29);
            StartStopButton.TabIndex = 2;
            StartStopButton.Text = "Start";
            StartStopButton.UseVisualStyleBackColor = true;
            StartStopButton.Click += StartStopButton_Click;
            // 
            // SaveAsButton
            // 
            SaveAsButton.Location = new Point(345, 308);
            SaveAsButton.Name = "SaveAsButton";
            SaveAsButton.Size = new Size(94, 29);
            SaveAsButton.TabIndex = 3;
            SaveAsButton.Text = "Save As";
            SaveAsButton.UseVisualStyleBackColor = true;
            SaveAsButton.Click += SaveAsButton_Click;
            // 
            // IPBox
            // 
            IPBox.Location = new Point(90, 15);
            IPBox.Name = "IPBox";
            IPBox.Size = new Size(167, 27);
            IPBox.TabIndex = 4;
            IPBox.TextChanged += IPBox_TextChanged;
            // 
            // portBox
            // 
            portBox.Location = new Point(307, 15);
            portBox.Name = "portBox";
            portBox.Size = new Size(98, 27);
            portBox.TabIndex = 5;
            portBox.TextChanged += portBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 19);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 6;
            label2.Text = "IP Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(263, 18);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 7;
            label3.Text = "Port:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 63);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 8;
            label4.Text = "Request Text:";
            // 
            // requestBox
            // 
            requestBox.Location = new Point(112, 60);
            requestBox.Name = "requestBox";
            requestBox.Size = new Size(293, 27);
            requestBox.TabIndex = 9;
            requestBox.TextChanged += requestBox_TextChanged;
            // 
            // CollectDataForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 347);
            Controls.Add(requestBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(portBox);
            Controls.Add(IPBox);
            Controls.Add(SaveAsButton);
            Controls.Add(StartStopButton);
            Controls.Add(label1);
            Controls.Add(logBox);
            Name = "CollectDataForm";
            Text = "UDP Data Collector";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox logBox;
        private Button StartStopButton;
        private Button SaveAsButton;
        private TextBox IPBox;
        private TextBox portBox;
        private Label label4;
        private TextBox requestBox;
    }
}