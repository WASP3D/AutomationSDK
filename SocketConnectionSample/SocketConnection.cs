using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeSys.Wasp3D.Utility
{
    public class SocketConnection
    {
        private Encoding _encoding;
        private Socket _socket = (Socket)null;

        //Automation command

        //Load Template
        //load "Instance= \Madhur\Test_UDT_Copy.wspx" "mode=Preview" "Zorder=1"

        //play Template
        //Play "Instance= \Madhur\Test_UDT_Copy.wspx" "mode=Preview" "Zorder=1" //template path

        //unload Template
        //unload "Instance= \Madhur\Test_UDT_Copy.wspx" "mode=Preview" "Zorder=1" //template path

        public SocketConnection()
        {
            //encoding can be UTF8/ASCII/UNICODE
            this._encoding = Encoding.UTF8;
        }

            
        public void Connect(string ipAddress, int portNUmber)
        {
            try
            {
                bool bValid = false;
                //port number to send command on server.
                //port must be same , as mention in Automation.xml at path C:\Program Files\Beehive Systems Ltd\WASP3D\Common\HostedAssemblies\AutomationAddIn
                int iPort = portNUmber;

                //Ip address on which server running
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ipAddress), iPort);

                //create and connect with Socket, to send Automation command
                this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this._socket.Connect((EndPoint)remoteEP);
                if (!this._socket.Connected)
                    return;               
            }
            catch (Exception ex)
            {
                this.WriteException(ex);
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                if (this._socket != null)
                {
                    byte[] bytes = this._encoding.GetBytes(message);
                    if (bytes == null)
                        return;
                    this._socket.Send(bytes);
                }
            }
            catch (Exception ex)
            {
                this.WriteException(ex);
            }
        }

        internal void Dispose()
        {
            try
            {
                if(_socket!=null)
                {
                    _socket.Close();
                    _socket = null;
                }
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        private void WriteException(Exception ex)
        {
            //
        }

    }
}
