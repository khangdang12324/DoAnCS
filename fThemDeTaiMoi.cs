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
															 // Lấy danh sách tất cả thành viên từ các ComboBox trong flowLayoutPanel
			List<string> danhSachThanhVien = new List<string>();

			foreach (Control control in flowLayoutPanelThanhVien.Controls)
			{
				if (control is ComboBox comboBox && comboBox.SelectedItem != null)
				{
					danhSachThanhVien.Add(comboBox.SelectedItem.ToString());
				}
			}

			// Nối các thành viên thành một chuỗi, ngăn cách bởi dấu phẩy
			string thanhVien = danhSachThanhVien.Count > 0 ? string.Join(", ", danhSachThanhVien) : "Không có";

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

		private void btnThemTV_Click(object sender, EventArgs e)
		{
			fAddMember fAddMember = new fAddMember();
			fAddMember.Show();
		}

		private void cbSLTV_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Kiểm tra nếu người dùng chọn số lượng thành viên
			if (int.TryParse(cbSLTV.SelectedItem?.ToString(), out int soLuongThanhVien))
			{
				using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True"))
				{
					connection.Open();
					string query = "SELECT DISTINCT Name FROM dbo.Members ORDER BY Name"; // Truy vấn SQL lấy dữ liệu
					SqlCommand cmd = new SqlCommand(query, connection);
					SqlDataReader reader = cmd.ExecuteReader();

					// Lưu danh sách tên thành viên từ cơ sở dữ liệu
					List<string> danhSachTenThanhVien = new List<string>();
					while (reader.Read())
					{
						danhSachTenThanhVien.Add(reader["Name"].ToString());
					}
					reader.Close();

					// Xóa các ComboBox cũ trong FlowLayoutPanel
					flowLayoutPanelThanhVien.Controls.Clear();

					// Tạo đúng số lượng ComboBox dựa trên lựa chọn
					for (int i = 0; i < soLuongThanhVien; i++)
					{
						ComboBox cbb = new ComboBox
						{
							Width = 250, // Đặt độ rộng tùy ý
							Font = new Font("Microsoft Sans Serif", 12) // Cỡ chữ lớn hơn
						};

						// Gán danh sách thành viên vào ComboBox
						cbb.Items.AddRange(danhSachTenThanhVien.ToArray());
						if (cbb.Items.Count > 0)
						{
							cbb.SelectedIndex = 0; // Chọn mục đầu tiên
						}

						// Thêm ComboBox vào FlowLayoutPanel
						flowLayoutPanelThanhVien.Controls.Add(cbb);
					}
				}
			}
			else
			{
				// Nếu không chọn hoặc chọn không hợp lệ, xóa tất cả ComboBox
				flowLayoutPanelThanhVien.Controls.Clear();
			}
		}

		private void RefreshComboBoxInFlowLayoutPanel()
		{
			// Lấy danh sách tên thành viên từ cơ sở dữ liệu
			List<string> memberList = new List<string>();

			using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True"))
			{
				connection.Open();
				string query = "SELECT DISTINCT Name FROM Members ORDER BY Name";
				using (SqlCommand cmd = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							memberList.Add(reader["Name"].ToString());
						}
					}
				}
			}

			// Làm mới danh sách thành viên trong mỗi ComboBox
			foreach (Control control in flowLayoutPanelThanhVien.Controls)
			{
				if (control is ComboBox cbb)
				{
					cbb.Items.Clear();
					cbb.Items.AddRange(memberList.ToArray());
					if (cbb.Items.Count > 0)
					{
						cbb.SelectedIndex = 0; // Chọn mục đầu tiên
					}
				}
			}
		}


		private void btnThemTVMoi_Click(object sender, EventArgs e)
		{
			// Hiển thị form thêm thành viên
			using (fAddMember fAddMember = new fAddMember())
			{
				if (fAddMember.ShowDialog() == DialogResult.Cancel)
				{
					RefreshComboBoxInFlowLayoutPanel();
				}
			}
		}


		private void flowLayoutPanelThanhVien_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnThemBaiBao_Click(object sender, EventArgs e)
		{
			/*// Mở form thêm bài báo
			fThemBaiBao formBaiBao = new fThemBaiBao();
			formBaiBao.qdSo = txtQD.Text.Trim(); // Gán QĐ số từ form hiện tại
			if (formBaiBao.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("Đã thêm bài báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				// Nếu cần, tải lại danh sách bài báo liên quan đến đề tài này
				LoadDanhSachBaiBao();
			}*/
		}

		private void txtQD_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
