namespace Do_an_co_so
{
	partial class fDSDT
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
			this.components = new System.ComponentModel.Container();
			this.dtgvDSDT = new System.Windows.Forms.DataGridView();
			this.contextMenuStripAddMember = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.thêmThànhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rdAll = new System.Windows.Forms.RadioButton();
			this.pnCap = new System.Windows.Forms.Panel();
			this.rdCapTruong = new System.Windows.Forms.RadioButton();
			this.rdCapTinh = new System.Windows.Forms.RadioButton();
			this.rdCapTrgTrongDiem = new System.Windows.Forms.RadioButton();
			this.rdGV = new System.Windows.Forms.RadioButton();
			this.rdSV = new System.Windows.Forms.RadioButton();
			this.cbTenChuNhiem = new System.Windows.Forms.ComboBox();
			this.cbNamKetThuc = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbNamBatDau = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTimKiemTheoDeTai = new System.Windows.Forms.TextBox();
			this.txtSoDT = new System.Windows.Forms.TextBox();
			this.btnXemChiTiet = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.cbTrangThai = new System.Windows.Forms.ComboBox();
			this.xóaThànhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dtgvDSDT)).BeginInit();
			this.contextMenuStripAddMember.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnCap.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtgvDSDT
			// 
			this.dtgvDSDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvDSDT.ContextMenuStrip = this.contextMenuStripAddMember;
			this.dtgvDSDT.Location = new System.Drawing.Point(3, 318);
			this.dtgvDSDT.Name = "dtgvDSDT";
			this.dtgvDSDT.RowHeadersWidth = 51;
			this.dtgvDSDT.RowTemplate.Height = 24;
			this.dtgvDSDT.Size = new System.Drawing.Size(1269, 498);
			this.dtgvDSDT.TabIndex = 0;
			this.dtgvDSDT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDSDT_CellContentClick);
			// 
			// contextMenuStripAddMember
			// 
			this.contextMenuStripAddMember.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStripAddMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmThànhViênToolStripMenuItem,
            this.xóaThànhViênToolStripMenuItem});
			this.contextMenuStripAddMember.Name = "contextMenuStripAddMember";
			this.contextMenuStripAddMember.Size = new System.Drawing.Size(211, 80);
			this.contextMenuStripAddMember.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAddMember_Opening);
			this.contextMenuStripAddMember.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripAddMember_ItemClicked);
			this.contextMenuStripAddMember.Click += new System.EventHandler(this.contextMenuStripAddMember_Click);
			// 
			// thêmThànhViênToolStripMenuItem
			// 
			this.thêmThànhViênToolStripMenuItem.Name = "thêmThànhViênToolStripMenuItem";
			this.thêmThànhViênToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
			this.thêmThànhViênToolStripMenuItem.Text = "Thêm thành viên";
			this.thêmThànhViênToolStripMenuItem.Click += new System.EventHandler(this.thêmThànhViênToolStripMenuItem_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.label1);
			this.panel3.ForeColor = System.Drawing.Color.Black;
			this.panel3.Location = new System.Drawing.Point(3, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1269, 66);
			this.panel3.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(399, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(450, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Danh sách các nghiên cứu khoa học";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.cbTrangThai);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.rdAll);
			this.panel1.Controls.Add(this.pnCap);
			this.panel1.Controls.Add(this.rdGV);
			this.panel1.Controls.Add(this.rdSV);
			this.panel1.Controls.Add(this.cbTenChuNhiem);
			this.panel1.Controls.Add(this.cbNamKetThuc);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbNamBatDau);
			this.panel1.ForeColor = System.Drawing.Color.Black;
			this.panel1.Location = new System.Drawing.Point(3, 77);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1269, 176);
			this.panel1.TabIndex = 9;
			// 
			// rdAll
			// 
			this.rdAll.AutoSize = true;
			this.rdAll.Checked = true;
			this.rdAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdAll.Location = new System.Drawing.Point(777, 9);
			this.rdAll.Name = "rdAll";
			this.rdAll.Size = new System.Drawing.Size(88, 29);
			this.rdAll.TabIndex = 40;
			this.rdAll.TabStop = true;
			this.rdAll.Text = "Tất cả";
			this.rdAll.UseVisualStyleBackColor = true;
			this.rdAll.CheckedChanged += new System.EventHandler(this.rdAll_CheckedChanged);
			// 
			// pnCap
			// 
			this.pnCap.Controls.Add(this.rdCapTruong);
			this.pnCap.Controls.Add(this.rdCapTinh);
			this.pnCap.Controls.Add(this.rdCapTrgTrongDiem);
			this.pnCap.Location = new System.Drawing.Point(1013, 41);
			this.pnCap.Name = "pnCap";
			this.pnCap.Size = new System.Drawing.Size(240, 113);
			this.pnCap.TabIndex = 39;
			this.pnCap.Visible = false;
			// 
			// rdCapTruong
			// 
			this.rdCapTruong.AutoSize = true;
			this.rdCapTruong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdCapTruong.Location = new System.Drawing.Point(11, 5);
			this.rdCapTruong.Name = "rdCapTruong";
			this.rdCapTruong.Size = new System.Drawing.Size(130, 29);
			this.rdCapTruong.TabIndex = 38;
			this.rdCapTruong.Text = "Cấp trường";
			this.rdCapTruong.UseVisualStyleBackColor = true;
			this.rdCapTruong.CheckedChanged += new System.EventHandler(this.rdCapTruong_CheckedChanged);
			// 
			// rdCapTinh
			// 
			this.rdCapTinh.AutoSize = true;
			this.rdCapTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdCapTinh.Location = new System.Drawing.Point(11, 75);
			this.rdCapTinh.Name = "rdCapTinh";
			this.rdCapTinh.Size = new System.Drawing.Size(106, 29);
			this.rdCapTinh.TabIndex = 38;
			this.rdCapTinh.Text = "Cấp tỉnh";
			this.rdCapTinh.UseVisualStyleBackColor = true;
			this.rdCapTinh.CheckedChanged += new System.EventHandler(this.rdCapTinh_CheckedChanged);
			// 
			// rdCapTrgTrongDiem
			// 
			this.rdCapTrgTrongDiem.AutoSize = true;
			this.rdCapTrgTrongDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdCapTrgTrongDiem.Location = new System.Drawing.Point(11, 40);
			this.rdCapTrgTrongDiem.Name = "rdCapTrgTrongDiem";
			this.rdCapTrgTrongDiem.Size = new System.Drawing.Size(226, 29);
			this.rdCapTrgTrongDiem.TabIndex = 38;
			this.rdCapTrgTrongDiem.Text = "Cấp trường trọng điểm";
			this.rdCapTrgTrongDiem.UseVisualStyleBackColor = true;
			this.rdCapTrgTrongDiem.CheckedChanged += new System.EventHandler(this.rdCapTrgTrongDiem_CheckedChanged);
			// 
			// rdGV
			// 
			this.rdGV.AutoSize = true;
			this.rdGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdGV.Location = new System.Drawing.Point(1024, 9);
			this.rdGV.Name = "rdGV";
			this.rdGV.Size = new System.Drawing.Size(126, 29);
			this.rdGV.TabIndex = 38;
			this.rdGV.Text = "Giảng viên";
			this.rdGV.UseVisualStyleBackColor = true;
			this.rdGV.CheckedChanged += new System.EventHandler(this.rdGV_CheckedChanged);
			// 
			// rdSV
			// 
			this.rdSV.AutoSize = true;
			this.rdSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdSV.Location = new System.Drawing.Point(887, 10);
			this.rdSV.Name = "rdSV";
			this.rdSV.Size = new System.Drawing.Size(114, 29);
			this.rdSV.TabIndex = 38;
			this.rdSV.Text = "Sinh viên";
			this.rdSV.UseVisualStyleBackColor = true;
			this.rdSV.CheckedChanged += new System.EventHandler(this.rdSV_CheckedChanged);
			// 
			// cbTenChuNhiem
			// 
			this.cbTenChuNhiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbTenChuNhiem.FormattingEnabled = true;
			this.cbTenChuNhiem.Location = new System.Drawing.Point(344, 10);
			this.cbTenChuNhiem.Name = "cbTenChuNhiem";
			this.cbTenChuNhiem.Size = new System.Drawing.Size(410, 33);
			this.cbTenChuNhiem.TabIndex = 37;
			this.cbTenChuNhiem.SelectedIndexChanged += new System.EventHandler(this.cbTenChuNhiem_SelectedIndexChanged);
			// 
			// cbNamKetThuc
			// 
			this.cbNamKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbNamKetThuc.FormattingEnabled = true;
			this.cbNamKetThuc.Items.AddRange(new object[] {
            "2024",
            "2023"});
			this.cbNamKetThuc.Location = new System.Drawing.Point(227, 8);
			this.cbNamKetThuc.Name = "cbNamKetThuc";
			this.cbNamKetThuc.Size = new System.Drawing.Size(86, 33);
			this.cbNamKetThuc.TabIndex = 37;
			this.cbNamKetThuc.SelectedIndexChanged += new System.EventHandler(this.cbNamKetThuc_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(157, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 31);
			this.label4.TabIndex = 1;
			this.label4.Text = "Đến";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(9, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 31);
			this.label3.TabIndex = 1;
			this.label3.Text = "Từ";
			// 
			// cbNamBatDau
			// 
			this.cbNamBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbNamBatDau.FormattingEnabled = true;
			this.cbNamBatDau.Items.AddRange(new object[] {
            "2024",
            "2023"});
			this.cbNamBatDau.Location = new System.Drawing.Point(61, 8);
			this.cbNamBatDau.Name = "cbNamBatDau";
			this.cbNamBatDau.Size = new System.Drawing.Size(86, 33);
			this.cbNamBatDau.TabIndex = 37;
			this.cbNamBatDau.SelectedIndexChanged += new System.EventHandler(this.cbNamBatDau_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(249, 31);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tìm kiếm tên đề tài:";
			// 
			// txtTimKiemTheoDeTai
			// 
			this.txtTimKiemTheoDeTai.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtTimKiemTheoDeTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtTimKiemTheoDeTai.Location = new System.Drawing.Point(289, 259);
			this.txtTimKiemTheoDeTai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTimKiemTheoDeTai.Name = "txtTimKiemTheoDeTai";
			this.txtTimKiemTheoDeTai.Size = new System.Drawing.Size(494, 30);
			this.txtTimKiemTheoDeTai.TabIndex = 38;
			// 
			// txtSoDT
			// 
			this.txtSoDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSoDT.Location = new System.Drawing.Point(1168, 290);
			this.txtSoDT.Name = "txtSoDT";
			this.txtSoDT.ReadOnly = true;
			this.txtSoDT.Size = new System.Drawing.Size(100, 22);
			this.txtSoDT.TabIndex = 39;
			// 
			// btnXemChiTiet
			// 
			this.btnXemChiTiet.BackColor = System.Drawing.Color.White;
			this.btnXemChiTiet.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
			this.btnXemChiTiet.FlatAppearance.BorderSize = 0;
			this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnXemChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXemChiTiet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnXemChiTiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXemChiTiet.Location = new System.Drawing.Point(921, 274);
			this.btnXemChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnXemChiTiet.Name = "btnXemChiTiet";
			this.btnXemChiTiet.Size = new System.Drawing.Size(241, 38);
			this.btnXemChiTiet.TabIndex = 38;
			this.btnXemChiTiet.Text = "Xem chi tiết";
			this.btnXemChiTiet.UseVisualStyleBackColor = false;
			this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(9, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(199, 31);
			this.label5.TabIndex = 41;
			this.label5.Text = "Chọn trạng thái";
			// 
			// cbTrangThai
			// 
			this.cbTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbTrangThai.FormattingEnabled = true;
			this.cbTrangThai.Location = new System.Drawing.Point(227, 61);
			this.cbTrangThai.Name = "cbTrangThai";
			this.cbTrangThai.Size = new System.Drawing.Size(182, 33);
			this.cbTrangThai.TabIndex = 42;
			this.cbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);
			// 
			// xóaThànhViênToolStripMenuItem
			// 
			this.xóaThànhViênToolStripMenuItem.Name = "xóaThànhViênToolStripMenuItem";
			this.xóaThànhViênToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
			this.xóaThànhViênToolStripMenuItem.Text = "Xóa thành viên";
			this.xóaThànhViênToolStripMenuItem.Click += new System.EventHandler(this.xóaThànhViênToolStripMenuItem_Click);
			// 
			// fDSDT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1278, 825);
			this.Controls.Add(this.btnXemChiTiet);
			this.Controls.Add(this.txtSoDT);
			this.Controls.Add(this.txtTimKiemTheoDeTai);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.dtgvDSDT);
			this.Name = "fDSDT";
			this.Text = "fDSDT";
			this.Load += new System.EventHandler(this.fDSDT_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgvDSDT)).EndInit();
			this.contextMenuStripAddMember.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnCap.ResumeLayout(false);
			this.pnCap.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtgvDSDT;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbNamBatDau;
		private System.Windows.Forms.TextBox txtTimKiemTheoDeTai;
		private System.Windows.Forms.TextBox txtSoDT;
		private System.Windows.Forms.ComboBox cbTenChuNhiem;
		private System.Windows.Forms.Button btnXemChiTiet;
		private System.Windows.Forms.RadioButton rdSV;
		private System.Windows.Forms.RadioButton rdGV;
		private System.Windows.Forms.RadioButton rdCapTinh;
		private System.Windows.Forms.RadioButton rdCapTrgTrongDiem;
		private System.Windows.Forms.RadioButton rdCapTruong;
		private System.Windows.Forms.ComboBox cbNamKetThuc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripAddMember;
		private System.Windows.Forms.ToolStripMenuItem thêmThànhViênToolStripMenuItem;
		private System.Windows.Forms.Panel pnCap;
		private System.Windows.Forms.RadioButton rdAll;
		private System.Windows.Forms.ComboBox cbTrangThai;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolStripMenuItem xóaThànhViênToolStripMenuItem;
	}
}