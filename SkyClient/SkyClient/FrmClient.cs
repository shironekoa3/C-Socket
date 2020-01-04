using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyClient
{
    public partial class FrmClient : Form
    {
        public FrmClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Socket socketSend;
        int currAccountIndex = 0;
        private void FrmClient_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\Config.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    if (temp.IndexOf("ip:") != -1)
                    {
                        txtIP.Text = temp.Replace("ip:", "");
                    }
                    else if (temp.IndexOf("port:") != -1)
                    {
                        txtPort.Text = temp.Replace("port:", "");
                    }
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("读取配置失败:" + ex.Message);
            }
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint point = new IPEndPoint(IPAddress.Parse(txtIP.Text), Convert.ToInt32(txtPort.Text));
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketSend.Connect(point);
                SocketSendMessage("[CMD:HOSTNAME]" + Dns.GetHostName());
                this.Text = "SkyClient V1.0 连接成功";
                txtIP.Enabled = false;
                txtPort.Enabled = false;
                btnConnect.Enabled = false;
                Thread thread = new Thread(SocketRecMessageing);
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误:",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (SocketSendMessage(txtSend.Text) > 0)
            {
                txtMessage.Text += "你:" + txtSend.Text + "\r\n";
                txtMessage.SelectionStart = txtMessage.Text.Length;
                txtMessage.ScrollToCaret();
                txtSend.Text = "";
            }
            else
            {
                MessageBox.Show("发送失败!");
            }
        }
        public void SocketRecMessageing()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[2048];
                    int count;
                    try
                    {
                        count = socketSend.Receive(buffer);
                    }
                    catch (Exception)
                    {
                        this.Text = "SkyClient V1.0 连接已关闭";
                        txtIP.Enabled = true;
                        txtPort.Enabled = true;
                        btnConnect.Enabled = true;
                        break;
                    }
                    if (count > 0)
                    {
                        string str = Encoding.UTF8.GetString(buffer, 0, count);
                        if (str == "[CMD:GETHOSTNAME]")
                        {
                            SocketSendMessage("[CMD:HOSTNAME]" + Dns.GetHostName());
                        }
                        else if (str.IndexOf("[CMD:ACCOUNT") != -1)
                        {
                            Clipboard.SetText(str.Replace("[CMD:ACCOUNT", ""));
                            txtMessage.Text += "已复制第" + currAccountIndex.ToString() + "个账号:" + str.Replace("[CMD:ACCOUNT", "") + "\r\n";
                        }
                        else
                        {
                            txtMessage.Text += "对方:" + str + "\r\n";
                            txtMessage.SelectionStart = txtMessage.Text.Length;
                            txtMessage.ScrollToCaret();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                socketSend.Disconnect(false);
                this.Text = "SkyClient V1.0 连接已关闭";
                txtIP.Enabled = true;
                txtPort.Enabled = true;
                btnConnect.Enabled = true;
            }
        }
        public int SocketSendMessage(string msg)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                int receive = socketSend.Send(buffer);
                return receive;
            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}
