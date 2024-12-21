using Do_an_co_so.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
			// Kiểm tra xem tên thành viên có hợp lệ không
			if (string.IsNullOrWhiteSpace(txtAddMember.Text))
			{
				MessageBox.Show("Tên thành viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Chuẩn hóa tên thành viên
			string newMemberName = NormalizeName(txtAddMember.Text.Trim());

			// Chuỗi kết nối đến cơ sở dữ liệu
			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Thêm thành viên mới vào bảng Members
					string query = "INSERT INTO Members (Name) VALUES (@Name)";
					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@Name", newMemberName);
						cmd.ExecuteNonQuery();
					}

					MessageBox.Show($"Thành viên \"{newMemberName}\" đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

		
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Có lỗi xảy ra khi thêm thành viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private string NormalizeName(string name)
		{
			// Chuyển từng từ sang dạng chữ hoa chữ cái đầu, chữ thường các chữ cái sau
			return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
		}
	}
}
