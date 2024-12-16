namespace Do_an_co_so
{
	partial class fQuanLyNCKH
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
			this.dtgvProjects = new System.Windows.Forms.DataGridView();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.txtQD = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtgvProjects)).BeginInit();
			this.SuspendLayout();
			// 
			// dtgvProjects
			// 
			this.dtgvProjects.AllowUserToAddRows = false;
			this.dtgvProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.dtgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvProjects.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dtgvProjects.Location = new System.Drawing.Point(25, 201);
			this.dtgvProjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dtgvProjects.Name = "dtgvProjects";
			this.dtgvProjects.RowHeadersWidth = 62;
			this.dtgvProjects.RowTemplate.Height = 28;
			this.dtgvProjects.Size = new System.Drawing.Size(1887, 843);
			this.dtgvProjects.TabIndex = 0;
			this.dtgvProjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvProjects_CellClick);
			this.dtgvProjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dtgvProjects.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvProjects_CellValueChanged);
			this.dtgvProjects.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgvProjects_CurrentCellDirtyStateChanged);
			this.dtgvProjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvProjects_KeyDown);
			this.dtgvProjects.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtgvProjects_PreviewKeyDown);
			// 
			// btnXoa
			// 
			this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoa.Location = new System.Drawing.Point(1635, 142);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(121, 48);
			this.btnXoa.TabIndex = 3;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnLuu
			// 
			this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLuu.Location = new System.Drawing.Point(1791, 142);
			this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(121, 48);
			this.btnLuu.TabIndex = 4;
			this.btnLuu.Text = "Lưu";
			this.btnLuu.UseVisualStyleBackColor = true;
			this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
			// 
			// txtQD
			// 
			this.txtQD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtQD.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQD.Location = new System.Drawing.Point(500, 72);
			this.txtQD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtQD.Name = "txtQD";
			this.txtQD.Size = new System.Drawing.Size(691, 41);
			this.txtQD.TabIndex = 6;
			this.txtQD.TextChanged += new System.EventHandler(this.txtQD_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(269, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(207, 36);
			this.label2.TabIndex = 4;
			this.label2.Text = "Quyết định số:";
			// 
			// fQuanLyNCKH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 1055);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtQD);
			this.Controls.Add(this.btnLuu);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.dtgvProjects);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "fQuanLyNCKH";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Xem chi tiết";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fQuanLyNCKH_FormClosing);
			this.Load += new System.EventHandler(this.frmChinh_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fQuanLyNCKH_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.dtgvProjects)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtgvProjects;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.TextBox txtQD;
		private System.Windows.Forms.Label label2;
	}
}