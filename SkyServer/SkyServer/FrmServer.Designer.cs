namespace SkyServer
{
    partial class FrmServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServer));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.lvClientList = new System.Windows.Forms.ListView();
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(58, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 23);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "6500";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(185, 12);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "监听";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.BtnListen_Click);
            // 
            // lvClientList
            // 
            this.lvClientList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvClientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumber,
            this.chHostName,
            this.chIPAddress});
            this.lvClientList.FullRowSelect = true;
            this.lvClientList.GridLines = true;
            this.lvClientList.Location = new System.Drawing.Point(12, 41);
            this.lvClientList.Name = "lvClientList";
            this.lvClientList.Size = new System.Drawing.Size(339, 422);
            this.lvClientList.TabIndex = 4;
            this.lvClientList.UseCompatibleStateImageBehavior = false;
            this.lvClientList.View = System.Windows.Forms.View.Details;
            this.lvClientList.Click += new System.EventHandler(this.LvClientList_Click);
            // 
            // chNumber
            // 
            this.chNumber.Text = "编号";
            this.chNumber.Width = 45;
            // 
            // chHostName
            // 
            this.chHostName.Text = "主机名";
            this.chHostName.Width = 120;
            // 
            // chIPAddress
            // 
            this.chIPAddress.Text = "IP地址";
            this.chIPAddress.Width = 150;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(357, 41);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(394, 329);
            this.txtMessage.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(276, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(357, 376);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(313, 83);
            this.txtSend.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(676, 423);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 36);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "连接:0";
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lvClientList);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmServer";
            this.Text = "SkyServer V1.0";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListView lvClientList;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chIPAddress;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ColumnHeader chHostName;
        private System.Windows.Forms.Label label2;
    }
}

