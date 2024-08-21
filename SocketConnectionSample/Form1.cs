using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeSys.Wasp3D.Utility
{
    public partial class Form1 : Form
    {
        SocketConnection _socketConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string templatepath = "aa.wsp";
                //string s = $"load \"Instace ={templatepath}\"";
                //MessageBox.Show(s);
                //send command
                if (_socketConnection!=null)
                {

                    string templatePath = "\\Madhur\\Test_UDT_Copy.wspx";

                    string commandToSend = $"load \"Instance= {templatePath}\"";
                    _socketConnection.SendMessage(commandToSend);



                    commandToSend = $"play \"Instance= {templatePath}\"";
                    _socketConnection.SendMessage(commandToSend);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try 
            {
                if (_socketConnection == null)
                {
                    _socketConnection = new SocketConnection();
                }

                //connect
                _socketConnection.Connect("192.168.1.188", 10005);
            }
            catch { }
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            try
            {
                //send command
                if (_socketConnection != null)
                {
                    _socketConnection.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
