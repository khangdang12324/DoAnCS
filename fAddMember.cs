using Do_an_co_so.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Do_an_co_so
{
	public partial class fAddMember : Form
	{
		public string NewMemberName => txtAddMember.Text.Trim();

		public fAddMember()
		{
			InitializeComponent();
		}

		private void fAddMember_Load(object sender, EventArgs e)
		{

		}

		private void txtQD_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(NewMemberName))
			{
				MessageBox.Show("Tên thành viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Chuẩn hóa tên thành viên
			string normalizedMemberName = NormalizeName(NewMemberName);

			// Gán tên chuẩn hóa vào thuộc tính NewMemberName
			txtAddMember.Text = normalizedMemberName;
			DialogResult = DialogResult.OK;
		}
		private string NormalizeName(string name)
		{
			// Chuyển từng từ sang dạng chữ hoa chữ cái đầu, chữ thường các chữ cái sau
			return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
		}
	}
}
