using Do_an_co_so.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an_co_so
{
	public partial class fThemDeTaiMoi : Form
	{
		public fThemDeTaiMoi()
		{
			InitializeComponent();
		}

		private void fThemDeTaiMoi_Load(object sender, EventArgs e)
		{
		
		
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			string qdSo = txtQD.Text.Trim(); // Quyết định số
			string tenDeTai = txtTenDeTai.Text.Trim(); // Tên đề tài
			string tenChuNhiem = txtTenChuNhiem.Text.Trim(); // Tên chủ nhiệm
			string thanhVien = txtTenThanhVien.Text.Trim(); // Tên thành viên
			string phanLoai = rdGiaoVien.Checked ? "Giáo viên" : "Sinh viên"; // Phân loại
			DateTime ngayBatDau = dtpNgayBatDau.Value; // Ngày bắt đầu
			DateTime ngayKetThuc = dtpNgayKetThuc.Value; // Ngày kết thúc
			string kinhPhi = txtKinhPhi.Text.Trim(); // Kinh phí
			if (ngayBatDau > ngayKetThuc)
			{
				MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(thanhVien))
			{
				thanhVien = "Không có"; // Để mặc định nếu không nhập thành viên
			}

			// Kiểm tra dữ liệu nhập vào
			if (string.IsNullOrEmpty(qdSo) || string.IsNullOrEmpty(tenDeTai) || string.IsNullOrEmpty(tenChuNhiem))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
			tenChuNhiem = textInfo.ToTitleCase(tenChuNhiem.ToLower());  // Chuyển chữ cái đầu tên chủ nhiệm thành chữ hoa
			thanhVien = textInfo.ToTitleCase(thanhVien.ToLower()); // Chuyển chữ cái đầu tên thành viên thành chữ hoa


			// Chuỗi kết nối đến cơ sở dữ liệu
			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True";
		
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
				connection.Open();
				// Kiểm tra xem Quyết định số đã tồn tại hay chưa
				string checkQuery = "SELECT COUNT(*) FROM Projects WHERE QDSo = @QDSo";
					using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
					{
						checkCommand.Parameters.AddWithValue("@QDSo", qdSo);

						
						int count = (int)checkCommand.ExecuteScalar(); // Lấy số lượng dòng trả về

						if (count > 0)
						{
							MessageBox.Show("Quyết định số đã tồn tại!");
							return; // Không thực hiện thêm nếu đã tồn tại
						}
					}

				// Nếu không trùng, thực hiện thêm vào cơ sở dữ liệu
				string insertQuery = @"
            INSERT INTO Projects 
            (QDSo, nameProject, nameResearchers, nameMember, type, ngayBatDau, ngayKetThuc, status, kinhPhi) 
            VALUES 
            (@QDSo, @nameProject, @nameResearchers, @nameMember, @type, @ngayBatDau, @ngayKetThuc, N'Đang thực hiện', @kinhPhi)";

				using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
				{
					insertCommand.Parameters.AddWithValue("@QDSo", qdSo);
					insertCommand.Parameters.AddWithValue("@nameProject", tenDeTai);
					insertCommand.Parameters.AddWithValue("@nameResearchers", tenChuNhiem);
					insertCommand.Parameters.AddWithValue("@nameMember", string.IsNullOrEmpty(thanhVien) ? "Không có" : thanhVien);
					insertCommand.Parameters.AddWithValue("@type", phanLoai);
					insertCommand.Parameters.AddWithValue("@ngayBatDau", ngayBatDau);
					insertCommand.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);
					insertCommand.Parameters.AddWithValue("@kinhPhi", kinhPhi);

					insertCommand.ExecuteNonQuery();
				}
			}

				// Cập nhật lại DataGridView
			
				MessageBox.Show("Thêm thành công!");


			
}
		// Trong fThemDeTaiMoi

	
		private void txtTenThanhVien_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtKinhPhi_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
			{	
				e.Handled = true;
			}
		}

		private void txtKinhPhi_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
