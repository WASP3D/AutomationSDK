using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeSys.Wasp3D.Utility
{
    public partial class frmChatClient : Form
    {
        #region Variables
        private Encoding _encoding;
        private Socket _socket = (Socket)null;
        private ManualResetEvent _waitEvnt = (ManualResetEvent)null;
        private Thread _thrd = (Thread)null;
        private int _iCheckThread = 500;
        private bool _iConnected = false;
        #endregion
        public frmChatClient()
        {
            this.InitializeComponent();
            //encoding can be UTF8/ASCII/UNICODE
            this._encoding = Encoding.UTF8;
        }

        /// <summary>
        /// Handle the event to create a socket 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //port number to send command on server.
                //port must be same , as mention in Automation.xml at path C:\Program Files\Beehive Systems Ltd\WASP3D\Common\HostedAssemblies\AutomationAddIn
                int iPort = int.Parse(txtPort.Text);

                //Ip address on which server running
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(this.txtIPAddress.Text), iPort);

                //create and connect with Socket, to send Automation command
                this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this._socket.Connect((EndPoint)remoteEP);
                if (!this._socket.Connected)
                    return;

                this._iConnected = true;
                this.CreateProcessThread();
                MessageBox.Show("Connected");
                this.btnConnect.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                this._iConnected = false;
                this.WriteException(ex);
            }
        }

        /// <summary>
        /// Send the command set in Command Text box to socket connected
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //get the message from command text box and send to socket
                if (this._socket != null)
                {
                    byte[] bytes = this._encoding.GetBytes(this.txtCommand.Text);
                    if (bytes == null)
                        return;
                    this._socket.Send(bytes);
                }
                else
                {
                    MessageBox.Show("Please connect with Playout server.");
                }
            }
            catch (Exception ex)
            {
                this._iConnected = false;
                this.WriteException(ex);
            }
        }

        /// <summary>
        /// Method to show exceptions occurs in application
        /// </summary>
        private void WriteException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


        private void CreateProcessThread()
        {
            try
            {
                this._waitEvnt = new ManualResetEvent(false);
                this._thrd = new Thread(new ThreadStart(this.HandleThread))
                {
                    IsBackground = true,
                    Priority = ThreadPriority.Normal
                };
                this._thrd.Start();
            }
            catch (Exception ex)
            {
                this._iConnected = false;
                this.WriteException(ex);
            }
        }

        private void HandleThread()
        {
            try
            {
                while (this._iConnected)
                {
                    this._waitEvnt.Reset();
                    this._waitEvnt.WaitOne(this._iCheckThread);
                    this.HandleReceived();
                }
            }
            catch (Exception ex)
            {
                this._iConnected = false;
                this.WriteException(ex);
            }
        }

        /// <summary>
        /// Received the message from Socket and show in Response Text Box
        /// </summary>
        private void HandleReceived()
        {
            try
            {
                byte[] numArray = new byte[1024];
                if (this._socket.Receive(numArray, SocketFlags.None) <= 0)
                    return;

                //get the response data from socket data
                string responseData = Encoding.UTF8.GetString(numArray);

                //check for invoke required to handle the cross thread exception
                if (this.txtResponse.InvokeRequired)
                    this.txtResponse.Invoke(new Action(() =>
                    {
                        string response = !string.IsNullOrEmpty(this.txtResponse.Text) ? this.txtResponse.Text + "\r\n" + responseData : responseData;
                        this.txtResponse.Text = response;
                    }));
                else
                {
                    string response = !string.IsNullOrEmpty(this.txtResponse.Text) ? this.txtResponse.Text + "\r\n" + responseData : responseData;
                    this.txtResponse.Text = response;
                }
            }
            catch (Exception ex)
            {
                this._iConnected = false;
                this.WriteException(ex);
            }
        }
    }
}
