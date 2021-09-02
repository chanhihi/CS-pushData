namespace pushData
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnData = new System.Windows.Forms.RadioButton();
            this.btnDer = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUartConnect = new System.Windows.Forms.Button();
            this.btnUartDisconnect = new System.Windows.Forms.Button();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.close = new System.Windows.Forms.Button();
            this.textBox_msg = new System.Windows.Forms.TextBox();
            this.OpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.button_cmd = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.textBox_cmd = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_logo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnData);
            this.groupBox5.Controls.Add(this.btnDer);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.Location = new System.Drawing.Point(322, 508);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(230, 89);
            this.groupBox5.TabIndex = 92;
            this.groupBox5.TabStop = false;
            // 
            // btnData
            // 
            this.btnData.AutoSize = true;
            this.btnData.Checked = true;
            this.btnData.Location = new System.Drawing.Point(17, 21);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(94, 17);
            this.btnData.TabIndex = 96;
            this.btnData.TabStop = true;
            this.btnData.Text = "데이터 파일";
            this.btnData.UseVisualStyleBackColor = true;
            // 
            // btnDer
            // 
            this.btnDer.AutoSize = true;
            this.btnDer.Location = new System.Drawing.Point(127, 21);
            this.btnDer.Name = "btnDer";
            this.btnDer.Size = new System.Drawing.Size(64, 17);
            this.btnDer.TabIndex = 95;
            this.btnDer.Text = "인증서";
            this.btnDer.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(115, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "내보내기";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "가져오기";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUartConnect);
            this.groupBox1.Controls.Add(this.btnUartDisconnect);
            this.groupBox1.Controls.Add(this.cbComPort);
            this.groupBox1.Controls.Add(this.close);
            this.groupBox1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(558, 508);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 89);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            // 
            // btnUartConnect
            // 
            this.btnUartConnect.Location = new System.Drawing.Point(25, 53);
            this.btnUartConnect.Name = "btnUartConnect";
            this.btnUartConnect.Size = new System.Drawing.Size(55, 23);
            this.btnUartConnect.TabIndex = 1;
            this.btnUartConnect.Text = "연결";
            this.btnUartConnect.UseVisualStyleBackColor = true;
            this.btnUartConnect.Click += new System.EventHandler(this.btnUartConnect_Click);
            // 
            // btnUartDisconnect
            // 
            this.btnUartDisconnect.Location = new System.Drawing.Point(86, 53);
            this.btnUartDisconnect.Name = "btnUartDisconnect";
            this.btnUartDisconnect.Size = new System.Drawing.Size(55, 23);
            this.btnUartDisconnect.TabIndex = 2;
            this.btnUartDisconnect.Text = "해제";
            this.btnUartDisconnect.UseVisualStyleBackColor = true;
            this.btnUartDisconnect.Click += new System.EventHandler(this.btnUartDisconnect_Click);
            // 
            // cbComPort
            // 
            this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Location = new System.Drawing.Point(25, 21);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(177, 21);
            this.cbComPort.TabIndex = 5;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(147, 53);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(55, 23);
            this.close.TabIndex = 6;
            this.close.Text = "종료";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // textBox_msg
            // 
            this.textBox_msg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_msg.Location = new System.Drawing.Point(12, 12);
            this.textBox_msg.Multiline = true;
            this.textBox_msg.Name = "textBox_msg";
            this.textBox_msg.ReadOnly = true;
            this.textBox_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_msg.Size = new System.Drawing.Size(775, 465);
            this.textBox_msg.TabIndex = 94;
            // 
            // OpenDlg
            // 
            this.OpenDlg.FileName = "OpenDlg";
            // 
            // button_cmd
            // 
            this.button_cmd.Location = new System.Drawing.Point(732, 485);
            this.button_cmd.Name = "button_cmd";
            this.button_cmd.Size = new System.Drawing.Size(55, 23);
            this.button_cmd.TabIndex = 95;
            this.button_cmd.Text = "Enter";
            this.button_cmd.UseVisualStyleBackColor = true;
            this.button_cmd.Click += new System.EventHandler(this.button_cmd_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(671, 485);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(55, 23);
            this.button_clear.TabIndex = 97;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // textBox_cmd
            // 
            this.textBox_cmd.Location = new System.Drawing.Point(12, 485);
            this.textBox_cmd.Name = "textBox_cmd";
            this.textBox_cmd.Size = new System.Drawing.Size(653, 21);
            this.textBox_cmd.TabIndex = 96;
            this.textBox_cmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_cmd_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 603);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(775, 23);
            this.progressBar1.TabIndex = 98;
            // 
            // btn_logo
            // 
            this.btn_logo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_logo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logo.Location = new System.Drawing.Point(12, 514);
            this.btn_logo.Name = "btn_logo";
            this.btn_logo.Size = new System.Drawing.Size(304, 83);
            this.btn_logo.TabIndex = 99;
            this.btn_logo.Text = " ";
            this.btn_logo.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "240_320_Cat.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 632);
            this.Controls.Add(this.btn_logo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_cmd);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.textBox_cmd);
            this.Controls.Add(this.textBox_msg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Name = "Form1";
            this.Text = "데이터 전송";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnUartConnect;
        public System.Windows.Forms.Button btnUartDisconnect;
        public System.Windows.Forms.ComboBox cbComPort;
        public System.Windows.Forms.Button close;
        public System.Windows.Forms.TextBox textBox_msg;
        private System.Windows.Forms.OpenFileDialog OpenDlg;
        private System.Windows.Forms.RadioButton btnData;
        private System.Windows.Forms.RadioButton btnDer;
        private System.Windows.Forms.Button button_cmd;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.TextBox textBox_cmd;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_logo;
        private System.Windows.Forms.ImageList imageList1;
    }
}

