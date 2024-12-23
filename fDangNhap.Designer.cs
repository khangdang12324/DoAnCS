namespace Do_an_co_so
{
    partial class fDangNhap
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDangNhap));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassWord = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel_QuenMatKhau = new System.Windows.Forms.LinkLabel();
			this.linkLabel_DangKy = new System.Windows.Forms.LinkLabel();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(328, 36);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(141, 114);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(163, 196);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tài khoản ";
			// 
			// txtUserName
			// 
			this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserName.Location = new System.Drawing.Point(281, 188);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(291, 34);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.Text = "admin";
			this.txtUserName.TextChanged += new System.EventHandler(this.textBox_TenTaiKhoan_TextChanged);
			// 
			// txtPassWord
			// 
			this.txtPassWord.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassWord.Location = new System.Drawing.Point(281, 241);
			this.txtPassWord.Name = "txtPassWord";
			this.txtPassWord.Size = new System.Drawing.Size(291, 34);
			this.txtPassWord.TabIndex = 2;
			this.txtPassWord.Text = "1";
			this.txtPassWord.UseSystemPasswordChar = true;
			this.txtPassWord.TextChanged += new System.EventHandler(this.textBox_MatKhau_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(163, 249);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mật khẩu ";
			// 
			// linkLabel_QuenMatKhau
			// 
			this.linkLabel_QuenMatKhau.AutoSize = true;
			this.linkLabel_QuenMatKhau.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel_QuenMatKhau.Location = new System.Drawing.Point(163, 397);
			this.linkLabel_QuenMatKhau.Name = "linkLabel_QuenMatKhau";
			this.linkLabel_QuenMatKhau.Size = new System.Drawing.Size(176, 26);
			this.linkLabel_QuenMatKhau.TabIndex = 3;
			this.linkLabel_QuenMatKhau.TabStop = true;
			this.linkLabel_QuenMatKhau.Text = "Quên Mật Khẩu ?";
			this.linkLabel_QuenMatKhau.Visible = false;
			this.linkLabel_QuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_QuenMatKhau_LinkClicked);
			// 
			// linkLabel_DangKy
			// 
			this.linkLabel_DangKy.AutoSize = true;
			this.linkLabel_DangKy.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel_DangKy.Location = new System.Drawing.Point(476, 397);
			this.linkLabel_DangKy.Name = "linkLabel_DangKy";
			this.linkLabel_DangKy.Size = new System.Drawing.Size(96, 26);
			this.linkLabel_DangKy.TabIndex = 4;
			this.linkLabel_DangKy.TabStop = true;
			this.linkLabel_DangKy.Text = "Đăng Ký";
			this.linkLabel_DangKy.Visible = false;
			this.linkLabel_DangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_DangKy_LinkClicked);
			// 
			// btnLogin
			// 
			this.btnLogin.AutoSize = true;
			this.btnLogin.BackColor = System.Drawing.Color.Blue;
			this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnLogin.Location = new System.Drawing.Point(256, 298);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(129, 36);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Đăng nhập";
			this.btnLogin.UseVisualStyleBackColor = false;
			this.btnLogin.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnExit
			// 
			this.btnExit.AutoSize = true;
			this.btnExit.BackColor = System.Drawing.Color.Blue;
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnExit.Location = new System.Drawing.Point(418, 298);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(129, 36);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "Thoát";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// fDangNhap
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.linkLabel_DangKy);
			this.Controls.Add(this.linkLabel_QuenMatKhau);
			this.Controls.Add(this.txtPassWord);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.MaximizeBox = false;
			this.Name = "fDangNhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DangNhap";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DangNhap_FormClosing);
			this.Load += new System.EventHandler(this.DangNhap_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel_QuenMatKhau;
        private System.Windows.Forms.LinkLabel linkLabel_DangKy;
        private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnExit;
	}
}

