namespace Do_an_co_so
{
	partial class fThongKe
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
			this.txtTenChuNhiem = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
			this.dtgvCN = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTongSo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtgvCN)).BeginInit();
			this.SuspendLayout();
			// 
			// txtTenChuNhiem
			// 
			this.txtTenChuNhiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtTenChuNhiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtTenChuNhiem.Location = new System.Drawing.Point(241, 29);
			this.txtTenChuNhiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTenChuNhiem.Name = "txtTenChuNhiem";
			this.txtTenChuNhiem.Size = new System.Drawing.Size(494, 30);
			this.txtTenChuNhiem.TabIndex = 13;
			this.txtTenChuNhiem.TextChanged += new System.EventHandler(this.txtTenChuNhiem_TextChanged);
			// 
			// label13
			// 
			this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label13.Location = new System.Drawing.Point(7, 141);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(85, 25);
			this.label13.TabIndex = 50;
			this.label13.Text = "Từ năm:";
			// 
			// dtpNgayBatDau
			// 
			this.dtpNgayBatDau.CustomFormat = "yyyy";
			this.dtpNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpNgayBatDau.Location = new System.Drawing.Point(275, 136);
			this.dtpNgayBatDau.Name = "dtpNgayBatDau";
			this.dtpNgayBatDau.Size = new System.Drawing.Size(108, 30);
			this.dtpNgayBatDau.TabIndex = 49;
			this.dtpNgayBatDau.ValueChanged += new System.EventHandler(this.dtpNgayDang_ValueChanged);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label1.Location = new System.Drawing.Point(406, 141);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 25);
			this.label1.TabIndex = 52;
			this.label1.Text = "Đến năm:";
			// 
			// dtpNgayKetThuc
			// 
			this.dtpNgayKetThuc.CustomFormat = "yyyy";
			this.dtpNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpNgayKetThuc.Location = new System.Drawing.Point(680, 136);
			this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
			this.dtpNgayKetThuc.Size = new System.Drawing.Size(108, 30);
			this.dtpNgayKetThuc.TabIndex = 51;
			this.dtpNgayKetThuc.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// dtgvCN
			// 
			this.dtgvCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvCN.Location = new System.Drawing.Point(12, 228);
			this.dtgvCN.Name = "dtgvCN";
			this.dtgvCN.RowHeadersWidth = 51;
			this.dtgvCN.RowTemplate.Height = 24;
			this.dtgvCN.Size = new System.Drawing.Size(1857, 572);
			this.dtgvCN.TabIndex = 55;
			this.dtgvCN.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCN_CellContentClick);
			this.dtgvCN.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgvCN_CellMouseDown);
			this.dtgvCN.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dtgvCN_RowStateChanged);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label4.Location = new System.Drawing.Point(7, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(192, 25);
			this.label4.TabIndex = 57;
			this.label4.Text = "Tìm kiếm chủ nhiệm:";
			// 
			// txtTongSo
			// 
			this.txtTongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTongSo.Location = new System.Drawing.Point(217, 813);
			this.txtTongSo.Name = "txtTongSo";
			this.txtTongSo.ReadOnly = true;
			this.txtTongSo.Size = new System.Drawing.Size(100, 30);
			this.txtTongSo.TabIndex = 60;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(17, 810);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(194, 31);
			this.label6.TabIndex = 59;
			this.label6.Text = "Tổng số dự án:";
			// 
			// fThongKe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 855);
			this.Controls.Add(this.txtTongSo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dtgvCN);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtpNgayKetThuc);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.dtpNgayBatDau);
			this.Controls.Add(this.txtTenChuNhiem);
			this.Name = "fThongKe";
			this.Text = "Thống kê";
			this.Load += new System.EventHandler(this.fThongKe_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgvCN)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtTenChuNhiem;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
		private System.Windows.Forms.DataGridView dtgvCN;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTongSo;
		private System.Windows.Forms.Label label6;
	}
}