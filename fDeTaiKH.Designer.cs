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
			this.panelMain = new System.Windows.Forms.Panel();
			this.tcDeTaiKH = new System.Windows.Forms.TabControl();
			this.tpDSDT = new System.Windows.Forms.TabPage();
			this.tpDeTaiKHMoi = new System.Windows.Forms.TabPage();
			this.panelMain.SuspendLayout();
			this.tcDeTaiKH.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.tcDeTaiKH);
			this.panelMain.Location = new System.Drawing.Point(4, 1);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1597, 973);
			this.panelMain.TabIndex = 1;
			// 
			// tcDeTaiKH
			// 
			this.tcDeTaiKH.Controls.Add(this.tpDSDT);
			this.tcDeTaiKH.Controls.Add(this.tpDeTaiKHMoi);
			this.tcDeTaiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tcDeTaiKH.Location = new System.Drawing.Point(9, 12);
			this.tcDeTaiKH.Name = "tcDeTaiKH";
			this.tcDeTaiKH.SelectedIndex = 0;
			this.tcDeTaiKH.Size = new System.Drawing.Size(1585, 958);
			this.tcDeTaiKH.TabIndex = 0;
			// 
			// tpDSDT
			// 
			this.tpDSDT.Location = new System.Drawing.Point(4, 34);
			this.tpDSDT.Name = "tpDSDT";
			this.tpDSDT.Padding = new System.Windows.Forms.Padding(3);
			this.tpDSDT.Size = new System.Drawing.Size(1577, 920);
			this.tpDSDT.TabIndex = 0;
			this.tpDSDT.Text = "Dánh sách đề tài";
			this.tpDSDT.UseVisualStyleBackColor = true;
			// 
			// tpDeTaiKHMoi
			// 
			this.tpDeTaiKHMoi.Location = new System.Drawing.Point(4, 34);
			this.tpDeTaiKHMoi.Name = "tpDeTaiKHMoi";
			this.tpDeTaiKHMoi.Padding = new System.Windows.Forms.Padding(3);
			this.tpDeTaiKHMoi.Size = new System.Drawing.Size(1577, 920);
			this.tpDeTaiKHMoi.TabIndex = 1;
			this.tpDeTaiKHMoi.Text = "Thêm đề tài mới";
			this.tpDeTaiKHMoi.UseVisualStyleBackColor = true;
			// 
			// fDeTaiKH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1613, 1007);
			this.Controls.Add(this.panelMain);
			this.Name = "fDeTaiKH";
			this.Text = "fDeTaiKH";
			this.Load += new System.EventHandler(this.fDeTaiKH_Load);
			this.panelMain.ResumeLayout(false);
			this.tcDeTaiKH.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.TabControl tcDeTaiKH;
		private System.Windows.Forms.TabPage tpDSDT;
		private System.Windows.Forms.TabPage tpDeTaiKHMoi;
	}
}