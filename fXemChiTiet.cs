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
using static System.Net.Mime.MediaTypeNames;

namespace Do_an_co_so
{
	public partial class fXemChiTiet : Form
	{
		private string QDSo;
		public fXemChiTiet(string qdSo, string tenDeTai)
		{
			InitializeComponent();

			// Gán dữ liệu vào các thành phần giao diện
			QDSo = qdSo;
			txtQDSo.Text = qdSo;
			txtTenDeTai.Text = tenDeTai;
		
			// Tải thông tin bài báo
			LoadArticles();
		}
		private void LoadArticles()
		{
			using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True"))
			{
				connection.Open();
				string query = "SELECT * FROM Articles WHERE qdSo = @QDSo";

				using (SqlCommand cmd = new SqlCommand(query, connection))
				{
					cmd.Parameters.AddWithValue("@QDSo", QDSo); // Truyền QD số vào truy vấn
					
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read()) // Nếu có dữ liệu
						{
					
							// Hiển thị dữ liệu lên các TextBox trong form
							txtIDBB.Text= reader["articleID"].ToString();
							txtTenBaiBao.Text = reader["tenBaiBao"].ToString();
							txtTenTapChi.Text = reader["tenTapChi"].ToString();
							txtTenTacGia.Text = reader["tenTacGia"].ToString();
							dtpNgayDang.Text = reader["ngayDang"].ToString();
							txtTenTVBB.Text = reader["tenThanhVienBaiBao"].ToString();

						}
						else
						{
							MessageBox.Show("Không tìm thấy thông tin bài báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
			}
		
	}

		private void LoadArticlesToDataGridView()
		{
			using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True"))
			{
				try
				{
					connection.Open();
					string query = "SELECT ArticleID as [Mã bài báo], tenBaiBao AS [Tên bài báo], tenTapChi as [Tên tạp chí], tenTacGia AS [Tên tác giả]," +
						" tenThanhVienBaiBao as [Tên thành viên bài báo], ngayDang as [Ngày đăng] FROM Articles WHERE qdSo = @QDSo";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@QDSo", QDSo.Trim());

						SqlDataAdapter adapter = new SqlDataAdapter(cmd);
						DataTable dt = new DataTable();
						adapter.Fill(dt);

						dtgvDSBB.DataSource = dt;
					
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void fXemChiTiet_Load(object sender, EventArgs e)
		{
			LoadArticlesToDataGridView();
			AddBinding();
		}

		private void dtgvDSBB_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void btnThemBB_Click(object sender, EventArgs e)
		{
			// Kiểm tra dữ liệu đầu vào
			if (string.IsNullOrWhiteSpace(txtTenBaiBao.Text) ||
				string.IsNullOrWhiteSpace(txtTenTapChi.Text) ||
				string.IsNullOrWhiteSpace(txtTenTacGia.Text))
			{
				MessageBox.Show("Vui lòng điền đầy đủ thông tin bài báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				// Kết nối đến cơ sở dữ liệu
				using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True"))
				{
					connection.Open();

					// Câu lệnh INSERT
					string query = "INSERT INTO Articles (qdSo, tenBaiBao, tenTapChi, tenTacGia, tenThanhVienBaiBao, ngayDang) " +
								   "VALUES (@QDSo, @TenBaiBao, @TenTapChi, @TenTacGia,@tenThanhVienBaiBao, @NgayDang)";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						// Gán giá trị cho các tham số
						cmd.Parameters.AddWithValue("@QDSo", txtQDSo.Text.Trim()); // Quyết định số
						cmd.Parameters.AddWithValue("@TenBaiBao", txtTenBaiBao.Text.Trim());
						cmd.Parameters.AddWithValue("@TenTapChi", txtTenTapChi.Text.Trim());
						cmd.Parameters.AddWithValue("@TenTacGia", txtTenTacGia.Text.Trim());
						cmd.Parameters.AddWithValue("@tenThanhVienBaiBao", txtTenTVBB.Text.Trim());
						cmd.Parameters.AddWithValue("@NgayDang", dtpNgayDang.Value);

						// Thực thi lệnh INSERT
						int result = cmd.ExecuteNonQuery();

						if (result > 0)
						{
							MessageBox.Show("Thêm bài báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

							// Cập nhật danh sách bài báo
							LoadArticlesToDataGridView();
						}
						else
						{
							MessageBox.Show("Không thể thêm bài báo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnMacDinh_Click(object sender, EventArgs e)
		{
			txtIDBB.Clear();
			txtTenBaiBao.Clear();
			txtTenTacGia.Clear();
			txtTenTapChi.Clear();
			txtTenTVBB.Clear();
		}
		public void AddBinding()
		{
			txtIDBB.DataBindings.Clear();
			txtTenBaiBao.DataBindings.Clear();
			txtTenTapChi.DataBindings.Clear();
			txtTenTacGia.DataBindings.Clear();
			dtpNgayDang.DataBindings.Clear();

			txtIDBB.DataBindings.Add("Text", dtgvDSBB.DataSource, "Mã bài báo");
			txtTenBaiBao.DataBindings.Add("Text", dtgvDSBB.DataSource, "Tên bài báo" );
			txtTenTapChi.DataBindings.Add("Text", dtgvDSBB.DataSource, "Tên tạp chí" );
			txtTenTacGia.DataBindings.Add("Text", dtgvDSBB.DataSource, "Tên tác giả");
			txtTenTVBB.DataBindings.Add("Text", dtgvDSBB.DataSource, "Tên thành viên bài báo");
			dtpNgayDang.DataBindings.Add("Value", dtgvDSBB.DataSource, "Ngày đăng");
		}
		public int Update(string maBaiBao, string tenBB, string tenTC, string tenTG, string tenTV, DateTime ngayDang)
		{
			var connString = Utilities.connectionString;
			using (var conn = new SqlConnection(connString)) // Sử dụng `using` để tự động giải phóng tài nguyên
			{
				var cmd = conn.CreateCommand();
				cmd.CommandText = "UPDATE Articles SET tenBaiBao = @TenBaiBao, tenTapChi = @TenTapChi, tenTacGia = @TenTacGia, tenThanhVienBaiBao = @TenThanhVienBaiBao, ngayDang = @NgayDang WHERE articleID = @ArticleID";

				// Thêm tham số với dữ liệu truyền vào từ tham số hàm
				cmd.Parameters.AddWithValue("@TenBaiBao", tenBB);
				cmd.Parameters.AddWithValue("@TenTapChi", tenTC);
				cmd.Parameters.AddWithValue("@TenTacGia", tenTG);
				cmd.Parameters.AddWithValue("@NgayDang", ngayDang);
				cmd.Parameters.AddWithValue("@TenThanhVienBaiBao", tenTV);
				cmd.Parameters.AddWithValue("@ArticleID", maBaiBao);

				conn.Open();

				var sodonganhhuong = cmd.ExecuteNonQuery();
				return sodonganhhuong;
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{


				// Lấy dữ liệu từ hàng được chọn
				string maBaiBao = txtIDBB.Text; // Đảm bảo cột "Mã bài báo" tồn tại
				string tenBB = txtTenBaiBao.Text.Trim();
				string tenTC = txtTenTapChi.Text.Trim();
				string tenTG = txtTenTacGia.Text.Trim();
				string tenTV = txtTenTVBB.Text.Trim();
				DateTime ngayDang = dtpNgayDang.Value;

				// Gọi hàm cập nhật
				int rowsAffected = Update(maBaiBao, tenBB, tenTC, tenTG, tenTV, ngayDang);

				// Kiểm tra số dòng được cập nhật
				if (rowsAffected > 0)
				{
					MessageBox.Show("Cập nhật bài báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadArticlesToDataGridView(); // Cập nhật lại dữ liệu hiển thị
				}
				else
				{
					MessageBox.Show("Không có dòng nào được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}



		private void dtgvDSBB_SelectionChanged(object sender, EventArgs e)
		{

		}

		// Sự kiện chuột phải hiển thị ContextMenuStrip
		private void dtgvDSBB_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				// Lấy vị trí con trỏ chuột
				var hitTestInfo = dtgvDSBB.HitTest(e.X, e.Y);

				// Kiểm tra nếu vị trí chuột thuộc về một ô
				if (hitTestInfo.RowIndex >= 0)
				{
					// Chọn hàng tương ứng
					dtgvDSBB.ClearSelection();
					dtgvDSBB.Rows[hitTestInfo.RowIndex].Selected = true;
		
					// Hiển thị ContextMenuStrip
					contextMenuStripDelete.Show(dtgvDSBB, e.Location);
				}
			}
		}

		// Sự kiện khi chọn "Xóa" từ menu chuột phải
		private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				// Lấy hàng được chọn
				if (dtgvDSBB.SelectedRows.Count > 0)
				{
					var selectedRow = dtgvDSBB.SelectedRows[0];
					string maBaiBao = selectedRow.Cells["Mã bài báo"].Value.ToString(); // Đảm bảo cột này tồn tại

					// Hiển thị xác nhận trước khi xóa
					var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa bài báo này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (confirmResult == DialogResult.Yes)
					{
						// Thực hiện xóa trong cơ sở dữ liệu
						var rowsAffected = DeleteArticle(maBaiBao);

						if (rowsAffected > 0)
						{
							MessageBox.Show("Xóa bài báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

							// Cập nhật lại danh sách
							LoadArticlesToDataGridView();
						}
						else
						{
							MessageBox.Show("Không thể xóa bài báo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
				else
				{
					MessageBox.Show("Vui lòng chọn bài báo để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Hàm xóa bài báo trong cơ sở dữ liệu
		private int DeleteArticle(string maBaiBao)
		{
			using (var conn = new SqlConnection(Utilities.connectionString))
			{
				var cmd = conn.CreateCommand();
				cmd.CommandText = "DELETE FROM Articles WHERE articleID = @ArticleID";
				cmd.Parameters.AddWithValue("@ArticleID", maBaiBao);

				conn.Open();
				return cmd.ExecuteNonQuery();
			}
		}

	}
}
