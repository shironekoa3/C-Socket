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

namespace SkyServer
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Socket socketWatch;
        Dictionary<Socket, string> clientList = new Dictionary<Socket, string>();
        private void FrmServer_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "\\data"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\data");
            }
        }
        private void BtnListen_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint point = new IPEndPoint(IPAddress.Any, Convert.ToInt32(txtPort.Text));
                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketWatch.Bind(point);
                socketWatch.Listen(100);
                Thread thread = new Thread(SocketListening);
                thread.IsBackground = true;
                thread.Start();
                this.Text = "SkyServer V1.0 监听中...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LvClientList_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem temp in this.lvClientList.Items)
            {
                if (temp == this.lvClientList.SelectedItems[0])
                {
                    temp.BackColor = Color.SkyBlue;
                }
                else
                {
                    temp.BackColor = Color.White;
                }
            }
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListView();
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            if(this.lvClientList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请在列表中选择一个目标!");
                return;
            }
            else
            {
                foreach (Socket temp in clientList.Keys)
                {
                    if(temp.RemoteEndPoint.ToString() == this.lvClientList.SelectedItems[0].SubItems[2].Text)
                    {
                        SocketSendMessage(temp, txtSend.Text);
                        txtMessage.Text += "您:" + txtSend.Text + "\r\n";
                        txtSend.Text = "";
                    }
                }
            }
        }
        public void SocketListening()
        {
            try
            {
                while (true)
                {
                    Socket socketsend = socketWatch.Accept();
                    clientList.Add(socketsend, "");
                    RefreshCount();
                    //ListViewItem lvi = new ListViewItem(clientList.Count.ToString());
                    //lvi.SubItems.Add(socketsend.RemoteEndPoint.ToString());
                    //this.lvClientList.Items.Add(lvi);
                    Thread thread = new Thread(SocketReceiveMsging);
                    thread.IsBackground = true;
                    thread.Start(socketsend);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SocketReceiveMsging(Object obj)
        {
            Socket socketSend = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[2048];
                    int count = socketSend.Receive(buffer);
                    if (count > 0)
                    {
                        string str = Encoding.UTF8.GetString(buffer, 0, count);
                        if (str.IndexOf("[CMD:HOSTNAME]") != -1)
                        {
                            clientList[socketSend] = str.Replace("[CMD:HOSTNAME]", "");
                            RefreshListView();
                        }
                        else
                        {
                            txtMessage.Text += "对方:" + str + "\r\n";
                        }
                    }
                }
            }
            catch (Exception)
            {
                clientList.Remove(socketSend);
                RefreshCount();
                if (clientList.Count <= 0)
                {
                    txtMessage.Text = "";
                }
                RefreshListView();
            }
        }
        public int SocketSendMessage(Socket dir, string msg)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                int num = dir.Send(buffer);
                return num;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public void RefreshListView()
        {
            try
            {
                this.lvClientList.Items.Clear();
                int num = 0;
                foreach (Socket temp in clientList.Keys)
                {
                    ListViewItem lvi = new ListViewItem((num + 1).ToString());
                    lvi.SubItems.Add(clientList[temp]);
                    lvi.SubItems.Add(temp.RemoteEndPoint.ToString());
                    this.lvClientList.Items.Add(lvi);
                    num++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("列表刷新错误:" + ex.Message);
            }
        }
        public void RefreshCount()
        {
            label2.Text = "连接:" + clientList.Count.ToString();
        }
       
    }
}
