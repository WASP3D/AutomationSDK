namespace BeeSys.Wasp3D.Utility
{
    partial class frmChatClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.grpSetting = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpCommandSend = new System.Windows.Forms.GroupBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.grpResponse = new System.Windows.Forms.GroupBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grpSetting.SuspendLayout();
            this.grpCommandSend.SuspendLayout();
            this.grpResponse.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(6, 27);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(58, 13);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP Address";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(90, 24);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(219, 20);
            this.txtIPAddress.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(90, 54);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(219, 20);
            this.txtPort.TabIndex = 3;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 57);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port";
            // 
            // grpSetting
            // 
            this.grpSetting.Controls.Add(this.btnConnect);
            this.grpSetting.Controls.Add(this.lblIP);
            this.grpSetting.Controls.Add(this.txtPort);
            this.grpSetting.Controls.Add(this.txtIPAddress);
            this.grpSetting.Controls.Add(this.lblPort);
            this.grpSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetting.Location = new System.Drawing.Point(0, 0);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Size = new System.Drawing.Size(744, 100);
            this.grpSetting.TabIndex = 4;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = "Settings";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(349, 54);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpCommandSend
            // 
            this.grpCommandSend.Controls.Add(this.txtCommand);
            this.grpCommandSend.Controls.Add(this.btnSend);
            this.grpCommandSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCommandSend.Location = new System.Drawing.Point(0, 100);
            this.grpCommandSend.Name = "grpCommandSend";
            this.grpCommandSend.Size = new System.Drawing.Size(744, 150);
            this.grpCommandSend.TabIndex = 5;
            this.grpCommandSend.TabStop = false;
            this.grpCommandSend.Text = "Command";
            // 
            // txtCommand
            // 
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommand.Location = new System.Drawing.Point(3, 16);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommand.Size = new System.Drawing.Size(738, 108);
            this.txtCommand.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSend.Location = new System.Drawing.Point(3, 124);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(738, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // grpResponse
            // 
            this.grpResponse.Controls.Add(this.txtResponse);
            this.grpResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResponse.Location = new System.Drawing.Point(0, 255);
            this.grpResponse.Name = "grpResponse";
            this.grpResponse.Size = new System.Drawing.Size(744, 209);
            this.grpResponse.TabIndex = 6;
            this.grpResponse.TabStop = false;
            this.grpResponse.Text = "Response";
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(3, 16);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(738, 190);
            this.txtResponse.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 250);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(744, 5);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // frmChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 464);
            this.Controls.Add(this.grpResponse);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grpCommandSend);
            this.Controls.Add(this.grpSetting);
            this.Name = "frmChatClient";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Client";
            this.grpSetting.ResumeLayout(false);
            this.grpSetting.PerformLayout();
            this.grpCommandSend.ResumeLayout(false);
            this.grpCommandSend.PerformLayout();
            this.grpResponse.ResumeLayout(false);
            this.grpResponse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.GroupBox grpSetting;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpCommandSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.GroupBox grpResponse;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Splitter splitter1;
    }
}

