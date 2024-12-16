using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an_co_so
{
	public partial class fGiaHan : Form
	{
		public int SoNgayGiaHan { get; private set; } = 0; // Giá trị số ngày gia hạn

		public fGiaHan()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent; // Hiển thị ở giữa Form cha
		}
		private void fGiaHan_Load(object sender, EventArgs e)
		{

		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel; // Đóng form không làm gì
			this.Close();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			if (int.TryParse(txtNgayGiaHan.Text.Trim(), out int soNgay) && soNgay > 0)
			{
				SoNgayGiaHan = soNgay;
				this.DialogResult = DialogResult.OK; // Trả về kết quả thành công
				this.Close();
			}
			else
			{
				MessageBox.Show("Vui lòng nhập số tháng gia hạn hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtNgayGiaHan_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
