namespace Do_an_co_so
{
	partial class fDeTaiKH
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDSDT = new System.Windows.Forms.Button();
			this.btnThongKe = new System.Windows.Forms.Button();
			this.btnThemDTKH = new System.Windows.Forms.Button();
			this.panelMain = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel1.Controls.Add(this.btnDSDT);
			this.panel1.Controls.Add(this.btnThongKe);
			this.panel1.Controls.Add(this.btnThemDTKH);
			this.panel1.Location = new System.Drawing.Point(-1, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(244, 970);
			this.panel1.TabIndex = 0;
			// 
			// btnDSDT
			// 
			this.btnDSDT.BackColor = System.Drawing.Color.White;
			this.btnDSDT.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
			this.btnDSDT.FlatAppearance.BorderSize = 0;
			this.btnDSDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDSDT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDSDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDSDT.Location = new System.Drawing.Point(0, -3);
			this.btnDSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnDSDT.Name = "btnDSDT";
			this.btnDSDT.Size = new System.Drawing.Size(241, 56);
			this.btnDSDT.TabIndex = 8;
			this.btnDSDT.Text = "Danh sách đề tài";
			this.btnDSDT.UseVisualStyleBackColor = false;
			this.btnDSDT.Click += new System.EventHandler(this.btnDSDT_Click);
			// 
			// btnThongKe
			// 
			this.btnThongKe.BackColor = System.Drawing.Color.White;
			this.btnThongKe.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
			this.btnThongKe.FlatAppearance.BorderSize = 0;
			this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThongKe.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThongKe.Location = new System.Drawing.Point(0, 117);
			this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnThongKe.Name = "btnThongKe";
			this.btnThongKe.Size = new System.Drawing.Size(241, 56);
			this.btnThongKe.TabIndex = 7;
			this.btnThongKe.Text = "Thống kê";
			this.btnThongKe.UseVisualStyleBackColor = false;
			this.btnThongKe.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnThemDTKH
			// 
			this.btnThemDTKH.BackColor = System.Drawing.Color.White;
			this.btnThemDTKH.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
			this.btnThemDTKH.FlatAppearance.BorderSize = 0;
			this.btnThemDTKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnThemDTKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThemDTKH.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnThemDTKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThemDTKH.Location = new System.Drawing.Point(0, 57);
			this.btnThemDTKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnThemDTKH.Name = "btnThemDTKH";
			this.btnThemDTKH.Size = new System.Drawing.Size(241, 56);
			this.btnThemDTKH.TabIndex = 5;
			this.btnThemDTKH.Text = "Đề tài khoa học mới";
			this.btnThemDTKH.UseVisualStyleBackColor = false;
			this.btnThemDTKH.Click += new System.EventHandler(this.btnThemDTKH_Click);
			// 
			// panelMain
			// 
			this.panelMain.Location = new System.Drawing.Point(246, 1);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1311, 973);
			this.panelMain.TabIndex = 1;
			// 
			// fDeTaiKH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1597, 1007);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.panel1);
			this.Name = "fDeTaiKH";
			this.Text = "fDeTaiKH";
			this.Load += new System.EventHandler(this.fDeTaiKH_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Button btnThemDTKH;
		private System.Windows.Forms.Button btnDSDT;
		private System.Windows.Forms.Button btnThongKe;
	}
}