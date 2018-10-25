/*
 * Created by SharpDevelop.
 * User: Jayan Nair
 * Date: 7/9/2004
 * Time: 2:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;


namespace DefaultNamespace
{
    /// <summary>
    /// Description of SocketClient.	
    /// </summary>
    /// 
    public class SocketClient : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxConnectStatus;
        private System.Windows.Forms.Button buttonClose;

        byte[] m_dataBuffer = new byte[10];
        IAsyncResult m_result;
        public AsyncCallback m_pfnCallBack;
        private System.Windows.Forms.Button btnClear;
        private System.ComponentModel.IContainer components;
        private Button button6;
        private Button buttonSendRaw;
        private ComboBox comboBoxCmdTest;
        private TextBox textBoxHeader2;
        private TextBox textBoxHeader1;
        private ComboBox comboBoxGT06;
        private Button button1;
        private Button button2;
        private TextBox textBoxTQ;
        private Button buttonUdp;
        private TextBox listBoxLog;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button7;
        public Socket m_clientSocket;

        public SocketClient()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

        }

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new SocketClient());
        }

        #region Windows Forms Designer generated code
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxConnectStatus = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.buttonSendRaw = new System.Windows.Forms.Button();
            this.comboBoxCmdTest = new System.Windows.Forms.ComboBox();
            this.textBoxHeader2 = new System.Windows.Forms.TextBox();
            this.textBoxHeader1 = new System.Windows.Forms.TextBox();
            this.comboBoxGT06 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxTQ = new System.Windows.Forms.TextBox();
            this.buttonUdp = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(647, 391);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(77, 25);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // textBoxConnectStatus
            // 
            this.textBoxConnectStatus.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnectStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConnectStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxConnectStatus.Location = new System.Drawing.Point(641, 13);
            this.textBoxConnectStatus.Name = "textBoxConnectStatus";
            this.textBoxConnectStatus.ReadOnly = true;
            this.textBoxConnectStatus.Size = new System.Drawing.Size(83, 14);
            this.textBoxConnectStatus.TabIndex = 10;
            this.textBoxConnectStatus.Text = "Not Connected";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(134, 33);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(58, 21);
            this.textBoxPort.TabIndex = 6;
            this.textBoxPort.Text = "8500";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonConnect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.ForeColor = System.Drawing.Color.Yellow;
            this.buttonConnect.Location = new System.Drawing.Point(323, 9);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(86, 51);
            this.buttonConnect.TabIndex = 7;
            this.buttonConnect.Text = "Connect To Server";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnectClick);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(508, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Connection Status";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(134, 9);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(183, 21);
            this.textBoxIP.TabIndex = 3;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.Color.Red;
            this.buttonDisconnect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.ForeColor = System.Drawing.Color.Yellow;
            this.buttonDisconnect.Location = new System.Drawing.Point(415, 9);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(87, 51);
            this.buttonDisconnect.TabIndex = 15;
            this.buttonDisconnect.Text = "Disconnet From Server";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnectClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server IP Address";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Port";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(307, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Message From Server";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(564, 391);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 25);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // buttonSendRaw
            // 
            this.buttonSendRaw.Location = new System.Drawing.Point(730, 92);
            this.buttonSendRaw.Name = "buttonSendRaw";
            this.buttonSendRaw.Size = new System.Drawing.Size(61, 25);
            this.buttonSendRaw.TabIndex = 53;
            this.buttonSendRaw.Text = "TBIT发送";
            this.buttonSendRaw.Click += new System.EventHandler(this.buttonSendRaw_Click);
            // 
            // comboBoxCmdTest
            // 
            this.comboBoxCmdTest.FormattingEnabled = true;
            this.comboBoxCmdTest.Items.AddRange(new object[] {
            "T0",
            "T1,13428701985,18603030944,123456,1,12121221212",
            "T2,DOMAIN,0",
            "T3,1,E,20.862142,N,52.051920,0.00,177.46,0,460:00:09242:00059",
            "T5,1,E,113.232332,N,23.23565,12.59,333.10,32,460:00:09242:00059",
            "T6,1,E,113.232332,N,23.23565,12.59,333.10,32,460:00:09242:00059",
            "T7,1,E,113.232332,N,23.23565,12.59,333.10,32,460:00:09242:00059",
            "T9,1,E,113.232332,N,23.23565,0.00,177.46,0,460:00:09242:00059,896",
            "T10,1,E,113.232332,N,23.23565,0.00,177.46,0,460:00:09242:00059,896",
            "T12,1",
            "T13,1",
            "T14,DOMAIN=211.154.135.237:8500",
            "T14,SOFTVERSION=123456",
            "T15,1",
            "T18,0,13",
            "T19,13428701985,詹华你好！",
            "T20,1"});
            this.comboBoxCmdTest.Location = new System.Drawing.Point(262, 92);
            this.comboBoxCmdTest.Name = "comboBoxCmdTest";
            this.comboBoxCmdTest.Size = new System.Drawing.Size(462, 20);
            this.comboBoxCmdTest.TabIndex = 54;
            this.comboBoxCmdTest.Text = "T10,1,E,113.232332,N,23.23565,0.00,177.46,0,260:06:01211:18655,896";
            // 
            // textBoxHeader2
            // 
            this.textBoxHeader2.Location = new System.Drawing.Point(157, 92);
            this.textBoxHeader2.Name = "textBoxHeader2";
            this.textBoxHeader2.Size = new System.Drawing.Size(99, 21);
            this.textBoxHeader2.TabIndex = 55;
            this.textBoxHeader2.Text = ",1,A1,801111111,";
            // 
            // textBoxHeader1
            // 
            this.textBoxHeader1.Location = new System.Drawing.Point(7, 92);
            this.textBoxHeader1.Name = "textBoxHeader1";
            this.textBoxHeader1.Size = new System.Drawing.Size(144, 21);
            this.textBoxHeader1.TabIndex = 56;
            // 
            // comboBoxGT06
            // 
            this.comboBoxGT06.FormattingEnabled = true;
            this.comboBoxGT06.Items.AddRange(new object[] {
            "78780D01012345678901234500018CDD0D0A",
            "787808134606042B0FF17C0D0A",
            "78781F120A0B1D0F0F1AC602409FDB099D2D68191C76014E0379180075AA0098EF2A0D0A"});
            this.comboBoxGT06.Location = new System.Drawing.Point(7, 119);
            this.comboBoxGT06.Name = "comboBoxGT06";
            this.comboBoxGT06.Size = new System.Drawing.Size(717, 20);
            this.comboBoxGT06.TabIndex = 58;
            this.comboBoxGT06.Text = "78780D01012345678901234500018CDD0D0A";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(730, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 25);
            this.button1.TabIndex = 59;
            this.button1.Text = "GT06发送";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(730, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 25);
            this.button2.TabIndex = 61;
            this.button2.Text = "天琴发送";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxTQ
            // 
            this.textBoxTQ.Location = new System.Drawing.Point(7, 145);
            this.textBoxTQ.Name = "textBoxTQ";
            this.textBoxTQ.Size = new System.Drawing.Size(717, 21);
            this.textBoxTQ.TabIndex = 62;
            // 
            // buttonUdp
            // 
            this.buttonUdp.Location = new System.Drawing.Point(797, 119);
            this.buttonUdp.Name = "buttonUdp";
            this.buttonUdp.Size = new System.Drawing.Size(43, 25);
            this.buttonUdp.TabIndex = 63;
            this.buttonUdp.Text = "UDP";
            this.buttonUdp.Click += new System.EventHandler(this.buttonUdp_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Location = new System.Drawing.Point(7, 223);
            this.listBoxLog.Multiline = true;
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(833, 162);
            this.listBoxLog.TabIndex = 64;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 25);
            this.button3.TabIndex = 65;
            this.button3.Text = "正常定位";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 192);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 25);
            this.button4.TabIndex = 66;
            this.button4.Text = "缺电报警";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(141, 192);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 25);
            this.button5.TabIndex = 67;
            this.button5.Text = "SOS报警";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(208, 192);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(61, 25);
            this.button7.TabIndex = 68;
            this.button7.Text = "小区定位";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // SocketClient
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(845, 428);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonUdp);
            this.Controls.Add(this.textBoxTQ);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxGT06);
            this.Controls.Add(this.textBoxHeader1);
            this.Controls.Add(this.textBoxHeader2);
            this.Controls.Add(this.comboBoxCmdTest);
            this.Controls.Add(this.buttonSendRaw);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxConnectStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIP);
            this.Name = "SocketClient";
            this.Text = "Socket Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        void ButtonCloseClick(object sender, System.EventArgs e)
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
            }
            Close();
        }

        void ButtonConnectClick(object sender, System.EventArgs e)
        {
            // See if we have text on the IP and Port text fields
            if (textBoxIP.Text == "" || textBoxPort.Text == "")
            {
                MessageBox.Show("IP Address and Port Number are required to connect to the Server\n");
                return;
            }
            try
            {
                UpdateControls(false);
                // Create the socket instance
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Cet the remote IP address
                // Find host by name
                IPHostEntry iphostentry = Dns.GetHostByName(textBoxIP.Text);

                // Grab the first IP addresses
                String IPStr = "";
                foreach (IPAddress ipaddress in iphostentry.AddressList)
                {
                    IPStr = ipaddress.ToString();
                }
                IPAddress ip = IPAddress.Parse(IPStr);
                int iPortNo = int.Parse(textBoxPort.Text);
                // Create the end point 
                IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
                // Connect to the remote host

                m_clientSocket.Connect(ipEnd);
                if (m_clientSocket.Connected)
                {

                    UpdateControls(true);
                    //Wait for data asynchronously 
                    WaitForData();
                }
            }
            catch (SocketException se)
            {
                string str;
                str = "\nConnection failed, is the server running?\n" + se.Message;
                MessageBox.Show(str);
                UpdateControls(false);
            }
        }
        public void WaitForData()
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_clientSocket;
                // Start listening to the data asynchronously
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        m_pfnCallBack,
                                                        theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }
        public class SocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1024];
        }
        /*
		public  void OnDataReceived(IAsyncResult asyn)
		{
			try
			{
				SocketPacket theSockId = (SocketPacket)asyn.AsyncState ;
				int iRx  = theSockId.thisSocket.EndReceive (asyn);

                string strMsg = Pub.Bytes2HexString(theSockId.dataBuffer, iRx);
                MessageBox.Show(strMsg);
                Console.WriteLine(strMsg);
				char[] chars = new char[iRx +  1];
                StringBuilder sb = new StringBuilder();
				//System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                System.Text.Decoder d = System.Text.Encoding.Default.GetDecoder();

				int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                //richTextRxMessage.Text = richTextRxMessage.Text + chars;
                sb.Append(chars);
                local_Log("接收:" + sb.ToString());
				WaitForData();
			}
			catch (ObjectDisposedException )
			{
				System.Diagnostics.Debugger.Log(0,"1","\nOnDataReceived: Socket has been closed\n");
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}
		}*/
        private bool isBin = false;
        //纯文本应答
        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                int iRx = theSockId.thisSocket.EndReceive(asyn);

                if (isBin)
                {
                    string strMsg = Pub.Bytes2HexString(theSockId.dataBuffer, iRx);
                    local_Log("接收:" + strMsg);
                }
                else
                {
                    char[] chars = new char[iRx + 1];
                    StringBuilder sb = new StringBuilder();
                    //System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                    System.Text.Decoder d = System.Text.Encoding.Default.GetDecoder();

                    int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                    sb.Append(chars);
                    string[] sArray1 = sb.ToString().Split(new char[3] { 'E', 'N', 'D' });
                    foreach (string i in sArray1)
                    {
                        local_Log("接收:" + i);
                    }
                }
                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        //定位线程错误
        void local_Log(String msg)
        {
            try
            {
                this.BeginInvoke(new OnLog(Log), new object[] { msg });
            }
            catch { }
        }
        private delegate void OnLog(String msg);
        private void Log(String msg)
        {
            listBoxLog.Text += msg + "\r\n";
        }
        private void UpdateControls(bool connected)
        {
            buttonConnect.Enabled = !connected;
            buttonDisconnect.Enabled = connected;
            string connectStatus = connected ? "Connected" : "Not Connected";
            textBoxConnectStatus.Text = connectStatus;
        }
        void ButtonDisconnectClick(object sender, System.EventArgs e)
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
                UpdateControls(false);
            }
        }
        //----------------------------------------------------	
        // This is a helper function used (for convenience) to 
        // get the IP address of the local machine
        //----------------------------------------------------
        String GetIP()
        {
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            listBoxLog.Text = "";
        }

        private void buttonSendRaw_Click(object sender, EventArgs e)
        {
            textBoxHeader1.Text = DateTime.Now.ToString();
            String strMsg = "[" + textBoxHeader1.Text + textBoxHeader2.Text + comboBoxCmdTest.Text + "]";
            Log("发送:" + strMsg);

            byte[] byData = System.Text.Encoding.UTF8.GetBytes(strMsg.ToCharArray());
            m_clientSocket.Send(byData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isBin = true;
            string str_gt06 = comboBoxGT06.Text.Replace(" ","");
            byte[] msg_gt06 = Pub.HexString2Bytes(str_gt06);
            MessageBox.Show(str_gt06 + ":" + str_gt06.Length + "," + msg_gt06.Length);

            m_clientSocket.Send(msg_gt06);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] byData = System.Text.Encoding.UTF8.GetBytes(textBoxTQ.Text.ToCharArray());
            m_clientSocket.Send(byData);
        }
        private UdpClient gps_client = null;
        private void buttonUdp_Click(object sender, EventArgs e)
        {
            // Create the socket instance
            m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Cet the remote IP address
            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostByName(textBoxIP.Text);

            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
            }
            IPAddress remotehost = IPAddress.Parse(IPStr);
            int remoteport = int.Parse(textBoxPort.Text);
            IPEndPoint remoteEP = new IPEndPoint(remotehost, remoteport);
            //gps_server = new UdpClient(remoteEP);
            IPEndPoint send = new IPEndPoint(IPAddress.Any, 0);
            if (gps_client == null)
            {
                gps_client = new UdpClient(send);
            }

            AsyncCallback GetRecvBuffer = new AsyncCallback(ReceiveCallback);
            gps_client.BeginReceive(GetRecvBuffer, null);

            string str_gt06 = comboBoxGT06.Text;
            byte[] msg_gt06 = Pub.HexString2Bytes(str_gt06);
            //gps_client.Send(msg_gt06, msg_gt06.Length, remoteEP);
            gps_client.BeginSend(msg_gt06, msg_gt06.Length, remoteEP, null, null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            lock (this)
            {
                IPEndPoint ipRemote = null;
                byte[] recvbytes = gps_client.EndReceive(ar, ref ipRemote);
                string strMsg = Pub.Bytes2HexString(recvbytes);
                MessageBox.Show(strMsg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxHeader1.Text = DateTime.Now.ToString();
            String strMsg = "[" + textBoxHeader1.Text + textBoxHeader2.Text + "T3,1,E,20.862142,N,52.051920,0.00,177.46,0,460:00:09242:00059" + "]";
            Log("发送:" + strMsg);

            byte[] byData = System.Text.Encoding.UTF8.GetBytes(strMsg.ToCharArray());
            m_clientSocket.Send(byData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxHeader1.Text = DateTime.Now.ToString();
            String strMsg = "[" + textBoxHeader1.Text + textBoxHeader2.Text + "T7,1,E,113.232332,N,23.23565,12.59,333.10,32,460:00:09242:00059" + "]";
            Log("发送:" + strMsg);

            byte[] byData = System.Text.Encoding.UTF8.GetBytes(strMsg.ToCharArray());
            m_clientSocket.Send(byData);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxHeader1.Text = DateTime.Now.ToString();
            String strMsg = "[" + textBoxHeader1.Text + textBoxHeader2.Text + "T6,1,E,113.232332,N,23.23565,12.59,333.10,32,460:00:09242:00059" + "]";
            Log("发送:" + strMsg);

            byte[] byData = System.Text.Encoding.UTF8.GetBytes(strMsg.ToCharArray());
            m_clientSocket.Send(byData);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxHeader1.Text = DateTime.Now.ToString();
            String strMsg = "[" + textBoxHeader1.Text + textBoxHeader2.Text + "T3,2,E,20.862142,N,52.051920,0.00,177.46,0,460:00:09242:00059" + "]";
            Log("发送:" + strMsg);

            byte[] byData = System.Text.Encoding.UTF8.GetBytes(strMsg.ToCharArray());
            m_clientSocket.Send(byData);
        }
    }
}
