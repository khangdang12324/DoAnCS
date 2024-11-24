namespace Do_an_co_so
{
	partial class fRemoveMembers
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
			this.clbDSTV = new System.Windows.Forms.CheckedListBox();
			this.btnXacNhan = new System.Windows.Forms.Button();
			this.btnHuy = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// clbDSTV
			// 
			this.clbDSTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clbDSTV.FormattingEnabled = true;
			this.clbDSTV.Location = new System.Drawing.Point(61, 58);
			this.clbDSTV.Name = "clbDSTV";
			this.clbDSTV.Size = new System.Drawing.Size(802, 242);
			this.clbDSTV.TabIndex = 0;
			// 
			// btnXacNhan
			// 
			this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXacNhan.Location = new System.Drawing.Point(227, 337);
			this.btnXacNhan.Name = "btnXacNhan";
			this.btnXacNhan.Size = new System.Drawing.Size(142, 50);
			this.btnXacNhan.TabIndex = 1;
			this.btnXacNhan.Text = "Xác nhận";
			this.btnXacNhan.UseVisualStyleBackColor = true;
			this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
			// 
			// btnHuy
			// 
			this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHuy.Location = new System.Drawing.Point(508, 337);
			this.btnHuy.Name = "btnHuy";
			this.btnHuy.Size = new System.Drawing.Size(142, 50);
			this.btnHuy.TabIndex = 1;
			this.btnHuy.Text = "Hủy";
			this.btnHuy.UseVisualStyleBackColor = true;
			this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
			// 
			// fRemoveMembers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(950, 481);
			this.Controls.Add(this.btnHuy);
			this.Controls.Add(this.btnXacNhan);
			this.Controls.Add(this.clbDSTV);
			this.Name = "fRemoveMembers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "fRemoveMembers";
			this.Load += new System.EventHandler(this.fRemoveMembers_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckedListBox clbDSTV;
		private System.Windows.Forms.Button btnXacNhan;
		private System.Windows.Forms.Button btnHuy;
	}
}