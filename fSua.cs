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
	public partial class fQuanLyNCKH : Form
	{
		private bool isSaved = false; // Biến theo dõi nếu dữ liệu đã được lưu	
		private bool isModified = false;
		public fQuanLyNCKH()
		{
			InitializeComponent();
			LoadProjectsData();
			this.KeyPreview = true;
			this.KeyDown -= new KeyEventHandler(fQuanLyNCKH_KeyDown);
			this.KeyDown += new KeyEventHandler(fQuanLyNCKH_KeyDown);
		}
		void LoadProjectsData()
		{


			string query = @"
        SELECT 
            QDSo AS [Quyết định số], 
            type AS [Loại dự án], 
            nameProject AS [Tên đề tài], 
            nameResearchers AS [Người nghiên cứu chính], 
            nameMember AS [Thành viên tham gia], 
            ngayBatDau AS [Ngày bắt đầu], 
            ngayKetThuc AS [Ngày kết thúc], 
            kinhPhi AS [Kinh phí], 
            artical AS [Bài báo liên quan], 
            prize AS [Giải thưởng], 
           status AS [Trạng thái]
        FROM dbo.Projects;
    ";




			dtgvProjects.DataSource = DataProvider.Instance.ExecuteQuery(query);
		}
		private void frmChinh_Load(object sender, EventArgs e)
		{
			this.KeyPreview = true;

		}
	


		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			this.KeyPreview = true; // Để nhận sự kiện phím trên toàn bộ form
			this.KeyDown += new KeyEventHandler(fQuanLyNCKH_KeyDown);
			dtgvProjects.KeyDown += dtgvProjects_KeyDown;

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}


		private void btnThem_Click(object sender, EventArgs e)
		{
			string quyetDinhSo = txtQD.Text; // Lấy giá trị Quyết định số từ txtQD

			if (string.IsNullOrEmpty(quyetDinhSo))
			{
				MessageBox.Show("Quyết định số không được để trống!");
				return;
			}

			// Chuỗi kết nối đến cơ sở dữ liệu
			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					// Kiểm tra xem Quyết định số đã tồn tại hay chưa
					string checkQuery = "SELECT COUNT(*) FROM Projects WHERE QDSo = @QDSo";
					using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
					{
						checkCommand.Parameters.AddWithValue("@QDSo", quyetDinhSo);

						connection.Open();
						int count = (int)checkCommand.ExecuteScalar(); // Lấy số lượng dòng trả về

						if (count > 0)
						{
							MessageBox.Show("Quyết định số đã tồn tại!");
							return; // Không thực hiện thêm nếu đã tồn tại
						}
					}

					// Nếu không trùng, thực hiện thêm vào cơ sở dữ liệu
					string insertQuery = "INSERT INTO Projects (QDSo) VALUES (@QDSo)";
					using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
					{
						insertCommand.Parameters.AddWithValue("@QDSo", quyetDinhSo);
						insertCommand.ExecuteNonQuery();
					}
				}

				// Cập nhật lại DataGridView
				LoadProjectsData();
				MessageBox.Show("Thêm thành công!");

				// Vô hiệu hóa nút thêm
		
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
		}

		private void dtgvProjects_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex >= 0)
				{
					DataGridViewRow row = dtgvProjects.Rows[e.RowIndex];
					txtQD.Text = row.Cells["Quyết định số"].Value.ToString();
					
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

	
		

		private void btnXoa_Click(object sender, EventArgs e)
		{
			string quyetDinhSo = dtgvProjects.CurrentRow.Cells["Quyết định số"].Value.ToString();

			var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa dự án này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (confirmResult == DialogResult.Yes)
			{
				string query = "DELETE FROM dbo.Projects WHERE QDSo = @quyetDinhSo";
				using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True"))

				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@quyetDinhSo", quyetDinhSo);
						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();
						if (rowsAffected > 0)
						{
							MessageBox.Show("Xóa dự án thành công!");
							LoadProjectsData(); // Tải lại dữ liệu
						}
						else
						{
							MessageBox.Show("Không tìm thấy dự án để xóa.");
						}
					}
				}
			}
		}
		public delegate void DataUpdatedHandler(); // Định nghĩa sự kiện

		public event DataUpdatedHandler DataUpdated; // Sự kiện thông báo dữ liệu đã được cập nhật

		private void btnLuu_Click(object sender, EventArgs e)
		{
			SaveChanges();
			isModified = false; // Đặt lại trạng thái thay đổi sau khi lưu
			isSaved = true; // Đánh dấu là đã lưu
			if (DataUpdated != null)
			{
				DataUpdated(); // Gọi sự kiện khi dữ liệu đã được cập nhật
			}
		}

		private void dtgvProjects_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{

			// Kiểm tra nếu hàng hiện tại không null và tồn tại cột có tên đúng
			if (e.RowIndex >= 0 && dtgvProjects.CurrentRow != null)
			{
				string quyetDinhSo = dtgvProjects.CurrentRow.Cells["Quyết định số"].Value.ToString();
				string loaiDuAn = dtgvProjects.CurrentRow.Cells["Loại dự án"].Value.ToString();
				string tenDeTai = dtgvProjects.CurrentRow.Cells["Tên đề tài"].Value.ToString();
				string nguoiNghienCuuChinh = dtgvProjects.CurrentRow.Cells["Người nghiên cứu chính"].Value.ToString();
				string thanhVien = dtgvProjects.CurrentRow.Cells["Thành viên tham gia"].Value.ToString();

				// Kiểm tra nếu giá trị là DBNull trước khi chuyển đổi sang DateTime
				DateTime ngayBatDau = dtgvProjects.CurrentRow.Cells["Ngày bắt đầu"].Value == DBNull.Value
									  ? DateTime.MinValue
									  : Convert.ToDateTime(dtgvProjects.CurrentRow.Cells["Ngày bắt đầu"].Value);

				DateTime ngayKetThuc = dtgvProjects.CurrentRow.Cells["Ngày kết thúc"].Value == DBNull.Value
									   ? DateTime.MinValue
									   : Convert.ToDateTime(dtgvProjects.CurrentRow.Cells["Ngày kết thúc"].Value);

				float kinhPhi = dtgvProjects.CurrentRow.Cells["Kinh phí"].Value == DBNull.Value
								? 0
								: Convert.ToSingle(dtgvProjects.CurrentRow.Cells["Kinh phí"].Value);

				string baiBaoLienQuan = dtgvProjects.CurrentRow.Cells["Bài báo liên quan"].Value.ToString();
				string giaiThuong = dtgvProjects.CurrentRow.Cells["Giải thưởng"].Value.ToString();
				string trangThai = dtgvProjects.CurrentRow.Cells["Trạng thái"].Value.ToString();
		
			}
	
		}


		private void UpdateProject(string quyetDinhSo, string loaiDuAn, string tenDeTai, string nguoiNghienCuuChinh, string thanhVien, DateTime ngayBatDau, DateTime ngayKetThuc, float kinhPhi, string baiBaoLienQuan, string giaiThuong, string trangThai)
		{
			string query = @"UPDATE Projects 
                     SET type = @loaiDuAn,
                         nameProject = @tenDeTai,
                         nameResearchers = @nguoiNghienCuuChinh,
                         nameMember = @thanhVien,
                         ngayBatDau = @ngayBatDau,
                         ngayKetThuc = @ngayKetThuc,
                         kinhPhi = @kinhPhi,
                         artical = @baiBaoLienQuan,
                         prize = @giaiThuong,
                         status = @trangThai
                     WHERE QDSo = @quyetDinhSo";

			using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True"))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					// Thêm các tham số vào câu lệnh SQL
					command.Parameters.AddWithValue("@quyetDinhSo", quyetDinhSo);
					command.Parameters.AddWithValue("@loaiDuAn", loaiDuAn);
					command.Parameters.AddWithValue("@tenDeTai", tenDeTai);
					command.Parameters.AddWithValue("@nguoiNghienCuuChinh", nguoiNghienCuuChinh);
					command.Parameters.AddWithValue("@thanhVien", thanhVien);
					command.Parameters.AddWithValue("@ngayBatDau", ngayBatDau == DateTime.MinValue ? (object)DBNull.Value : ngayBatDau);
					command.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc == DateTime.MinValue ? (object)DBNull.Value : ngayKetThuc);
					command.Parameters.AddWithValue("@kinhPhi", kinhPhi);
					command.Parameters.AddWithValue("@baiBaoLienQuan", baiBaoLienQuan);
					command.Parameters.AddWithValue("@giaiThuong", giaiThuong);
					command.Parameters.AddWithValue("@trangThai", trangThai);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		// Override ProcessCmdKey để xử lý phím tắt và ngăn beep


		private void SaveChanges()
		{

			if (dtgvProjects.CurrentRow != null)
			{
				try
				{
					// Lấy giá trị từ hàng hiện tại trong DataGridView
					string quyetDinhSo = dtgvProjects.CurrentRow.Cells["Quyết định số"].Value.ToString();
					string loaiDuAn = dtgvProjects.CurrentRow.Cells["Loại dự án"].Value.ToString();
					string tenDeTai = dtgvProjects.CurrentRow.Cells["Tên đề tài"].Value.ToString();
					string nguoiNghienCuuChinh = dtgvProjects.CurrentRow.Cells["Người nghiên cứu chính"].Value.ToString();
					string thanhVien = dtgvProjects.CurrentRow.Cells["Thành viên tham gia"].Value.ToString();
					DateTime ngayBatDau = dtgvProjects.CurrentRow.Cells["Ngày bắt đầu"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtgvProjects.CurrentRow.Cells["Ngày bắt đầu"].Value);
					DateTime ngayKetThuc = dtgvProjects.CurrentRow.Cells["Ngày kết thúc"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtgvProjects.CurrentRow.Cells["Ngày kết thúc"].Value);
					float kinhPhi = dtgvProjects.CurrentRow.Cells["Kinh phí"].Value == DBNull.Value ? 0 : Convert.ToSingle(dtgvProjects.CurrentRow.Cells["Kinh phí"].Value);
					string baiBaoLienQuan = dtgvProjects.CurrentRow.Cells["Bài báo liên quan"].Value.ToString();
					string giaiThuong = dtgvProjects.CurrentRow.Cells["Giải thưởng"].Value.ToString();
					string trangThai = dtgvProjects.CurrentRow.Cells["Trạng thái"].Value.ToString();

					// Gọi phương thức cập nhật cơ sở dữ liệu
					UpdateProject(quyetDinhSo, loaiDuAn, tenDeTai, nguoiNghienCuuChinh, thanhVien, ngayBatDau, ngayKetThuc, kinhPhi, baiBaoLienQuan, giaiThuong, trangThai);
					isModified = false;
					// Hiển thị thông báo một lần duy nhất
					MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}


		private void dtgvProjects_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			// Kiểm tra nếu phím Ctrl + S được nhấn
			if (e.Control && e.KeyCode == Keys.S)
			{
				e.IsInputKey = true; // Chặn beep bằng cách đánh dấu là InputKey
			}
		}

		private void dtgvProjects_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Control && e.KeyCode == Keys.S)
			{
				SaveChanges();  // Thực hiện lưu dữ liệu
				e.Handled = true;  // Ngăn việc xử lý thêm phím Ctrl + S
			}
		}

			private void fQuanLyNCKH_KeyDown(object sender, KeyEventArgs e)
			{
				// Kiểm tra nếu Ctrl + S được nhấn
				if (e.Control && e.KeyCode == Keys.S)
				{ 
					if (dtgvProjects.CurrentRow != null)
					{
						try
						{
							// Lấy giá trị từ hàng hiện tại trong DataGridView
							string quyetDinhSo = dtgvProjects.CurrentRow.Cells["Quyết định số"].Value.ToString();
							string loaiDuAn = dtgvProjects.CurrentRow.Cells["Loại dự án"].Value.ToString();
							string tenDeTai = dtgvProjects.CurrentRow.Cells["Tên đề tài"].Value.ToString();
							string nguoiNghienCuuChinh = dtgvProjects.CurrentRow.Cells["Người nghiên cứu chính"].Value.ToString();
							string thanhVien = dtgvProjects.CurrentRow.Cells["Thành viên tham gia"].Value.ToString();
							DateTime ngayBatDau = dtgvProjects.CurrentRow.Cells["Ngày bắt đầu"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtgvProjects.CurrentRow.Cells["Ngày bắt đầu"].Value);
							DateTime ngayKetThuc = dtgvProjects.CurrentRow.Cells["Ngày kết thúc"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtgvProjects.CurrentRow.Cells["Ngày kết thúc"].Value);
							float kinhPhi = dtgvProjects.CurrentRow.Cells["Kinh phí"].Value == DBNull.Value ? 0 : Convert.ToSingle(dtgvProjects.CurrentRow.Cells["Kinh phí"].Value);
							string baiBaoLienQuan = dtgvProjects.CurrentRow.Cells["Bài báo liên quan"].Value.ToString();
							string giaiThuong = dtgvProjects.CurrentRow.Cells["Giải thưởng"].Value.ToString();
							string trangThai = dtgvProjects.CurrentRow.Cells["Trạng thái"].Value.ToString();

							// Gọi phương thức cập nhật cơ sở dữ liệu
							UpdateProject(quyetDinhSo, loaiDuAn, tenDeTai, nguoiNghienCuuChinh, thanhVien, ngayBatDau, ngayKetThuc, kinhPhi, baiBaoLienQuan, giaiThuong, trangThai);
							isModified = false;
							// Hiển thị thông báo một lần duy nhất
							MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						catch (Exception ex)
						{
							MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				e.Handled = true;
				}
			}

		private void txtTenNguoiTH_TextChanged(object sender, EventArgs e)
		{

		}
		
		private void fQuanLyNCKH_FormClosing(object sender, FormClosingEventArgs e)
		{

			if (isModified)
			{
				var result = MessageBox.Show("Bạn có muốn lưu những thay đổi không?", "Xác nhận thoát", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					SaveChanges(); // Gọi lưu khi chọn Yes
				}
				else if (result == DialogResult.Cancel)
				{
					e.Cancel = true; // Hủy đóng form khi chọn Cancel
				}
			}
		}

		private void txtQD_TextChanged(object sender, EventArgs e)
		{
		
		}

		private void dtgvProjects_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{

			if (dtgvProjects.IsCurrentCellDirty)
			{
				// Nếu ô hiện tại đang thay đổi, đánh dấu là đã thay đổi
				isModified = true;
				
			}
		}


	}

}
