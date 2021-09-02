//200708 최적화

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pushData
{
    public partial class Form1 : Form
    {
        public SerialPort Serial = new SerialPort();
        delegate void SetTextCallBack(string opt);

        public string PortNumber;
        public string PRESENT_PORT = "";

        public System.IO.Ports.Parity Parity;
        public System.IO.Ports.StopBits StopBit;

        string DerValue0, DerValue1, DerValue2, DerValue3, DerValue4 = null;
        string[] DV = new string[10000];
        int keyLen;
        int bytelen;

        byte[] byteValue = null;
        byte[] krKey = null;

        public static int mm, ss;

        public string[] cmdTemp = new string[10];
        public static int keyTemp;

        public Form1()
        {
            InitializeComponent();
            ComPortDisplay();
            Serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
        }
        public string[] GetPortName()
        {
            return SerialPort.GetPortNames();
        }

        private void ComPortDisplay()
        {
            if (!Serial.IsOpen)
            {
                cbComPort.Items.Clear();
                string[] ports = GetPortName();

                foreach (string port in ports)
                {
                    cbComPort.Items.Add(port);
                }

                btnUartConnect.Enabled = false;
                btnUartDisconnect.Enabled = false;

                if (ports.Length > 0)
                {
                    btnUartConnect.Enabled = true;

                    try
                    {
                        cbComPort.SelectedIndex = 0;

                        int idx = cbComPort.FindStringExact(Properties.Settings.Default.ComPort);
                        if (idx >= 0)
                            cbComPort.SelectedIndex = idx;
                    }
                    catch { }
                }
            }
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int i_recv_size = Serial.BytesToRead;
            byte[] b_tmp_buf = new byte[i_recv_size];
            string recv_str = "";

            Serial.Read(b_tmp_buf, 0, i_recv_size);
            recv_str += Encoding.GetEncoding(949).GetString(b_tmp_buf);

            Invoke(new SetTextCallBack(display_data), new object[] { recv_str });
            recv_str = null;
        }
        private void display_data(string str)
        {
            textBox_msg.AppendText(str);
//            if (str.Contains("\n"))
  //              textBox_msg.AppendText("\r\n");
            textBox_msg.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenDlg.InitialDirectory = "./";
            if (btnDer.Checked)
            {
                OpenDlg.Filter = "der Files|*.der|All Files|*.*";
            }
            if (btnData.Checked)
            {
                OpenDlg.Filter = "BIN Files(*.bin)|*.bin";
            }
            OpenDlg.FilterIndex = 1;
            OpenDlg.RestoreDirectory = true;

            try
            {
                if (OpenDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var fPath = string.Empty;
                        fPath = OpenDlg.FileName;

                        var fStream = OpenDlg.OpenFile();
                        int bytelength = (int)fStream.Length;


                        var byteKey = string.Empty;
                        var publicKey = string.Empty;

                        byteValue = File.ReadAllBytes(fPath);

                        if (btnDer.Checked)
                        {
                            X509Certificate der = new X509Certificate(byteValue);
                            X509Certificate2 cert = new X509Certificate2(byteValue);
                            //publicKey = Convert.ToBase64String(cert.GetPublicKey());
                            byteKey = Convert.ToBase64String(cert.RawData);
                            int splitLen = 512;
                            keyLen = byteKey.Length / splitLen;

                            textBox_msg.Text += keyLen;
                            textBox_msg.AppendText("\r\n#########################################KEY LEN\r\n");

                            //textBox_msg.Text += Convert.ToBase64String(byteValue);     //rawdata와 같은 값.
                            //textBox_msg.AppendText(Convert.ToString(bytelength));      //읽어온 der 총길이
                            //textBox_msg.AppendText("\r\n###############################################\r\n");
                            textBox_msg.Text += krKey;
                            textBox_msg.AppendText("\r\n#########################################Kr KEY\r\n");

                            textBox_msg.Text += publicKey;
                            textBox_msg.AppendText("\r\n#########################################PUBLIC KEY\r\n");

                            textBox_msg.Text += byteKey;
                            textBox_msg.AppendText("\r\n#########################################BYTE KEY\r\n");


                            if (keyLen > 1)
                            {
                                DerValue0 = byteKey.Substring(0, 512);
                                DerValue1 = byteKey.Substring(512, 512);
                                DerValue2 = byteKey.Substring(1024, 512);
                                DerValue3 = byteKey.Substring(1536, 512);
                                DerValue4 = byteKey.Substring(2048);
                            }
                            else
                            {
                                DerValue0 = byteKey;
                            }

                            textBox_msg.AppendText("\r\nTRIM THE KEY\r\n##########111##########\r\n");
                            textBox_msg.AppendText(DerValue0 + "\r\n##########222##########\r\n");
                            textBox_msg.AppendText(DerValue1 + "\r\n##########333##########\r\n");
                            textBox_msg.AppendText(DerValue2 + "\r\n##########444##########\r\n");
                            textBox_msg.AppendText(DerValue3 + "\r\n##########555##########\r\n");
                            textBox_msg.AppendText(DerValue4);

                            textBox_msg.ScrollToCaret();
                        }
                        else if (btnData.Checked)
                        {
                            int splitLen = 1024;
                            bytelen = byteValue.Length / splitLen;

                            byteKey = Convert.ToBase64String(byteValue);
                            textBox_msg.AppendText("\r\n#########################################" + bytelen + "\r\n" + "\r\n");

                            progressBar1.Maximum = bytelen;

                            for (int i = 0; i < bytelen; i++)
                            {
                                textBox_msg.AppendText("\r\n" + i + "/" + bytelen + "\r\n");
                                DV[i] = byteKey.Substring(i * splitLen, splitLen);
                                progressBar1.Value++;
                            }
                            progressBar1.Value = progressBar1.Maximum;
                            DV[bytelen] = byteKey.Substring(bytelen * splitLen);                            
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (btnDer.Checked) MessageBox.Show("include .der file");
                        if (btnData.Checked) MessageBox.Show("include file");
                    }
                }
            }
            catch { }
            finally { }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Serial.IsOpen)
            {
                if (btnDer.Checked)
                {
                    Send(DerValue0);
                    if (keyLen >= 1)
                    {
                        Send(DerValue1);
                        Send(DerValue2);
                        Send(DerValue3);
                        Send(DerValue4);
                    }
                }
                else if (btnData.Checked)
                {
                    System.Threading.Timer timer = new System.Threading.Timer(timer_callback);

                    timer.Change(0, 1000);

                    progressBar1.Value = 0;
                    progressBar1.Maximum = bytelen;

                    textBox_msg.AppendText("[" + DateTime.Now.ToString() + "]");
                    DateTime startTime = DateTime.Now;

                    for (int i = 0; i <= bytelen; i++)
                    {
                        Send(DV[i]);                        
                        textBox_msg.AppendText("["+ mm + ":" +ss + "]" +"\r\n" + i + "/" + bytelen + "\r\n");
                        if(progressBar1.Value != progressBar1.Maximum)
                        progressBar1.Value++;
                    }

                    /*
                    Parallel.For(0, bytelen, (i) =>
                    {
                        Send(DV[i]);
                        textBox_msg.AppendText("[" + mm + ":" + ss + "]" + "\r\n" + i + "/" + bytelen + "\r\n");
                        progressBar1.Value++;
                    });
                    */
                    
                    DateTime endTime = DateTime.Now;
                    TimeSpan elapsed = endTime - startTime;

                    textBox_msg.AppendText("complete! \r\n");
                    textBox_msg.AppendText("[" + DateTime.Now.ToString() + "]\r\n");
                    textBox_msg.Text += elapsed;

                    timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                    timer.InitializeLifetimeService();
                    timer.Dispose();

                    progressBar1.Value = 0;
                }
            }
            else
                MessageBox.Show("port is not opend");
        }
        private static void timer_callback(object state)
        {
            ss++;
            if (ss > 59)
            {
                ss = 0;
                mm++;
            }
        }
        private void btnUartConnect_Click(object sender, EventArgs e)
        {

            if (!this.Serial.IsOpen)
            {
                this.Serial.PortName = cbComPort.Text;
                this.Serial.BaudRate = 115200;
                this.Serial.DataBits = 8;
                this.Parity = System.IO.Ports.Parity.None;
                this.StopBit = System.IO.Ports.StopBits.None;
                this.Serial.Open();

                btnUartDisconnect.Enabled = true;
                btnUartConnect.Enabled = false;
            }
            else
            {
                MessageBox.Show("Already Open it");
            }
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_msg.Text = null;
        }
        private void button_cmd_Click(object sender, EventArgs e)
        {
            string comport_str = "";
            if (Serial.IsOpen)
            {
                comport_str = textBox_cmd.Text;
                this.textBox_msg.AppendText(comport_str + "\r\n");
                textBox_msg.ScrollToCaret();
                Send(comport_str);
                if (cmdTemp[0] != null)
                {
                    for (int i = 9; i != 0; i--)
                    {
                        cmdTemp[i] = cmdTemp[i - 1];
                    }
                }
                cmdTemp[0] = textBox_cmd.Text;

                keyTemp = 0;
                textBox_cmd.Text = null;
            }
            else
            {
                MessageBox.Show("SERIAL PORT CONNECTION FAIL");
            }
            return;
        }
        private void textBox_cmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (Serial.IsOpen)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Thread tBcmd = new Thread(sendCMD);
                    tBcmd.Start();
                    if (!tBcmd.Join(TimeSpan.FromSeconds(10)))
                    {
                        tBcmd.Abort();
                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    textBox_cmd.Text = cmdTemp[keyTemp];
                    if (keyTemp != 9) keyTemp++;
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (keyTemp != 0) keyTemp--;
                    textBox_cmd.Text = cmdTemp[keyTemp];
                }
            }
            else
            {
                MessageBox.Show("SERIAL PORT CONNECTION FAIL");
            }
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_logo.Image = imageList1.Images[0];
            btn_logo.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }

        private void sendCMD()
        {
            try
            {
                button_cmd_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Timeout" + ex);
            }
        }

        private void btnUartDisconnect_Click(object sender, EventArgs e)
        {
            this.Serial.Close();
            btnUartConnect.Enabled = true;
            btnUartDisconnect.Enabled = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool Send(string txMsg)
        {

            if ((txMsg == "") || (txMsg.Length <= 0))
                return false;

            if (!Serial.IsOpen)
                return false;
            
            try
            {
                Serial.Write(txMsg + "\n");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Send(byte[] txMsg, int len)
        {
            if (len <= 0)
                return false;

            if (!Serial.IsOpen)
                return false;

            try
            {
                Serial.Write(txMsg, 0, len);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

