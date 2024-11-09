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
			this.dtgvDSDT = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbTenChuNhiem = new System.Windows.Forms.ComboBox();
			this.cbNam = new System.Windows.Forms.ComboBox();
			this.btnXuatExcel = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTimKiemTheoDeTai = new System.Windows.Forms.TextBox();
			this.txtSoDT = new System.Windows.Forms.TextBox();
			this.btnXemChiTiet = new System.Windows.Forms.Button();
			this.rdGV = new System.Windows.Forms.RadioButton();
			this.rdSV = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.dtgvDSDT)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtgvDSDT
			// 
			this.dtgvDSDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvDSDT.Location = new System.Drawing.Point(3, 216);
			this.dtgvDSDT.Name = "dtgvDSDT";
			this.dtgvDSDT.RowHeadersWidth = 51;
			this.dtgvDSDT.RowTemplate.Height = 24;
			this.dtgvDSDT.Size = new System.Drawing.Size(1269, 597);
			this.dtgvDSDT.TabIndex = 0;
			this.dtgvDSDT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDSDT_CellContentClick);
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
			this.panel1.Controls.Add(this.rdSV);
			this.panel1.Controls.Add(this.rdGV);
			this.panel1.Controls.Add(this.cbTenChuNhiem);
			this.panel1.Controls.Add(this.cbNam);
			this.panel1.Controls.Add(this.btnXuatExcel);
			this.panel1.Controls.Add(this.btnLuu);
			this.panel1.ForeColor = System.Drawing.Color.Black;
			this.panel1.Location = new System.Drawing.Point(3, 77);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1269, 66);
			this.panel1.TabIndex = 9;
			// 
			// cbTenChuNhiem
			// 
			this.cbTenChuNhiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbTenChuNhiem.FormattingEnabled = true;
			this.cbTenChuNhiem.Items.AddRange(new object[] {
            "TS. Nguyễn Văn A",
            "TS. Nguyễn Văn B"});
			this.cbTenChuNhiem.Location = new System.Drawing.Point(772, 15);
			this.cbTenChuNhiem.Name = "cbTenChuNhiem";
			this.cbTenChuNhiem.Size = new System.Drawing.Size(244, 33);
			this.cbTenChuNhiem.TabIndex = 37;
			// 
			// cbNam
			// 
			this.cbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbNam.FormattingEnabled = true;
			this.cbNam.Items.AddRange(new object[] {
            "2024",
            "2023"});
			this.cbNam.Location = new System.Drawing.Point(1022, 15);
			this.cbNam.Name = "cbNam";
			this.cbNam.Size = new System.Drawing.Size(244, 33);
			this.cbNam.TabIndex = 37;
			// 
			// btnXuatExcel
			// 
			this.btnXuatExcel.BackColor = System.Drawing.Color.White;
			this.btnXuatExcel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
			this.btnXuatExcel.FlatAppearance.BorderSize = 0;
			this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXuatExcel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXuatExcel.Location = new System.Drawing.Point(250, 2);
			this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnXuatExcel.Name = "btnXuatExcel";
			this.btnXuatExcel.Size = new System.Drawing.Size(241, 56);
			this.btnXuatExcel.TabIndex = 9;
			this.btnXuatExcel.Text = "Xuất excel";
			this.btnXuatExcel.UseVisualStyleBackColor = false;
			// 
			// btnLuu
			// 
			this.btnLuu.BackColor = System.Drawing.Color.White;
			this.btnLuu.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
			this.btnLuu.FlatAppearance.BorderSize = 0;
			this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLuu.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLuu.Location = new System.Drawing.Point(3, 2);
			this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(241, 56);
			this.btnLuu.TabIndex = 9;
			this.btnLuu.Text = "Lưu";
			this.btnLuu.UseVisualStyleBackColor = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 154);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(249, 31);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tìm kiếm tên đề tài:";
			// 
			// txtTimKiemTheoDeTai
			// 
			this.txtTimKiemTheoDeTai.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtTimKiemTheoDeTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtTimKiemTheoDeTai.Location = new System.Drawing.Point(293, 157);
			this.txtTimKiemTheoDeTai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTimKiemTheoDeTai.Name = "txtTimKiemTheoDeTai";
			this.txtTimKiemTheoDeTai.Size = new System.Drawing.Size(494, 30);
			this.txtTimKiemTheoDeTai.TabIndex = 38;
			// 
			// txtSoDT
			// 
			this.txtSoDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSoDT.Location = new System.Drawing.Point(1172, 188);
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
			this.btnXemChiTiet.Location = new System.Drawing.Point(925, 172);
			this.btnXemChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnXemChiTiet.Name = "btnXemChiTiet";
			this.btnXemChiTiet.Size = new System.Drawing.Size(241, 38);
			this.btnXemChiTiet.TabIndex = 38;
			this.btnXemChiTiet.Text = "Xem chi tiết";
			this.btnXemChiTiet.UseVisualStyleBackColor = false;
			this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
			// 
			// rdGV
			// 
			this.rdGV.AutoSize = true;
			this.rdGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdGV.Location = new System.Drawing.Point(506, 15);
			this.rdGV.Name = "rdGV";
			this.rdGV.Size = new System.Drawing.Size(126, 29);
			this.rdGV.TabIndex = 38;
			this.rdGV.TabStop = true;
			this.rdGV.Text = "Giảng viên";
			this.rdGV.UseVisualStyleBackColor = true;
			// 
			// rdSV
			// 
			this.rdSV.AutoSize = true;
			this.rdSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdSV.Location = new System.Drawing.Point(638, 16);
			this.rdSV.Name = "rdSV";
			this.rdSV.Size = new System.Drawing.Size(114, 29);
			this.rdSV.TabIndex = 38;
			this.rdSV.TabStop = true;
			this.rdSV.Text = "Sinh viên";
			this.rdSV.UseVisualStyleBackColor = true;
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
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtgvDSDT;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnXuatExcel;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.ComboBox cbNam;
		private System.Windows.Forms.TextBox txtTimKiemTheoDeTai;
		private System.Windows.Forms.TextBox txtSoDT;
		private System.Windows.Forms.ComboBox cbTenChuNhiem;
		private System.Windows.Forms.Button btnXemChiTiet;
		private System.Windows.Forms.RadioButton rdSV;
		private System.Windows.Forms.RadioButton rdGV;
	}
}