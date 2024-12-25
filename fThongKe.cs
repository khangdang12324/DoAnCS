using Do_an_co_so.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an_co_so
{
	public partial class fThongKe : Form
	{
		public fThongKe()
		{
			InitializeComponent();
		}

		private void label5_Click(object sender, EventArgs e)
		{

		}
		private void LoadDataChuNhiem()
		{
			string query = @"SELECT qdSo AS [Quyết định số], nameProject as [Tên đề tài],FORMAT(ngayBatDau, 'yyyy') AS [Năm bắt đầu],
    FORMAT(ngayKetThuc, 'yyyy') AS [Năm kết thúc],nameResearchers as [Tên chủ nhiệm],
prize as [Giải thưởng] FROM dbo.Projects";

			dtgvCN.DataSource = DataProvider.Instance.ExecuteQuery(query);

		}
		private void fThongKe_Load(object sender, EventArgs e)
		{
			LoadDataChuNhiem();
			AddBinding();
		}

		private void txtTenChuNhiem_TextChanged(object sender, EventArgs e)
		{
			// Lấy giá trị từ txtTenChuNhiem
			string tenChuNhiem = txtTenChuNhiem.Text.Trim();

			// Kiểm tra nếu tên chủ nhiệm không trống
			if (!string.IsNullOrEmpty(tenChuNhiem))
			{
				// Kết nối đến cơ sở dữ liệu (Sử dụng ADO.NET hoặc Entity Framework)
				string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True";
				string query = "SELECT qdSo AS [Quyết định số], nameProject as [Tên đề tài],FORMAT(ngayBatDau, 'yyyy') AS [Năm bắt đầu],\r\n    FORMAT(ngayKetThuc, 'yyyy') AS [Năm kết thúc],nameResearchers as [Tên chủ nhiệm],prize as [Giải thưởng] FROM dbo.Projects WHERE nameResearchers LIKE @tenChuNhiem";

				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					SqlDataAdapter da = new SqlDataAdapter(query, conn);
					da.SelectCommand.Parameters.AddWithValue("@tenChuNhiem", "%" + tenChuNhiem + "%");

					DataTable dt = new DataTable();
					da.Fill(dt);

					// Cập nhật DataGridView với dữ liệu tìm được
					dtgvCN.DataSource = dt;
				}
			}
			else
			{
				LoadDataChuNhiem();
			}

		}
		public void AddBinding()
		{
		
		}
		private void btnThem_Click(object sender, EventArgs e)
		{
			
		}


		private void dtgvCN_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			// Kiểm tra xem người dùng có nhấn vào ô hợp lệ không (không phải header)
			
		}

		private void dtpNgayDang_ValueChanged(object sender, EventArgs e)
		{
			FilterDataByDate();
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			FilterDataByDate();
		}

		private void FilterDataByDate()
		{
			// Lấy năm bắt đầu và năm kết thúc từ DateTimePicker
			int startYear = dtpNgayBatDau.Value.Year;
			int endYear = dtpNgayKetThuc.Value.Year;

			// Kết nối đến cơ sở dữ liệu
			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True";
			string query = @"
        SELECT qdSo AS [Quyết định số], 
               nameProject AS [Tên đề tài], 
               FORMAT(ngayBatDau, 'yyyy') AS [Năm bắt đầu],
               FORMAT(ngayKetThuc, 'yyyy') AS [Năm kết thúc],
               nameResearchers AS [Tên chủ nhiệm],
         
               prize AS [Giải thưởng]
        FROM dbo.Projects
        WHERE YEAR(ngayBatDau) >= @startYear AND YEAR(ngayKetThuc) <= @endYear";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@startYear", startYear);
				cmd.Parameters.AddWithValue("@endYear", endYear);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				// Gán kết quả vào DataGridView
				dtgvCN.DataSource = dt;
			}
		}

		private void dtgvCN_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			try
			{
				// Đếm số hàng không rỗng trong DataGridView
				int soDuAn = 0;
				foreach (DataGridViewRow row in dtgvCN.Rows)
				{
					if (!row.IsNewRow) // Loại bỏ hàng trống mặc định
					{
						soDuAn++;
					}
				}

				// Hiển thị tổng số dự án vào TextBox
				txtTongSo.Text = soDuAn.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dtgvCN_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}

}



