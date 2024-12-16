namespace Do_an_co_so
{
	partial class fGiaHan
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
			this.btnAccept = new System.Windows.Forms.Button();
			this.txtNgayGiaHan = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAccept
			// 
			this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAccept.Location = new System.Drawing.Point(125, 163);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(159, 39);
			this.btnAccept.TabIndex = 0;
			this.btnAccept.Text = "Xác nhận";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// txtNgayGiaHan
			// 
			this.txtNgayGiaHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNgayGiaHan.Location = new System.Drawing.Point(125, 115);
			this.txtNgayGiaHan.Name = "txtNgayGiaHan";
			this.txtNgayGiaHan.Size = new System.Drawing.Size(372, 30);
			this.txtNgayGiaHan.TabIndex = 1;
			this.txtNgayGiaHan.TextChanged += new System.EventHandler(this.txtNgayGiaHan_TextChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(338, 163);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(159, 39);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(205, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(214, 25);
			this.label1.TabIndex = 3;
			this.label1.Text = "Nhập số tháng gia hạn:";
			// 
			// fGiaHan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(674, 314);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtNgayGiaHan);
			this.Controls.Add(this.btnAccept);
			this.Name = "fGiaHan";
			this.Text = "fGiaHan";
			this.Load += new System.EventHandler(this.fGiaHan_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.TextBox txtNgayGiaHan;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
	}
}