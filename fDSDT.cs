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
	public partial class fDSDT : Form
	{
		public fDSDT()
		{
			InitializeComponent();
			LoadYearComboBox();
			LoadComboBoxData();
			LoadTrangThaiComboBox();
			LoadProjectsData();

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void fDSDT_Load(object sender, EventArgs e)
		{

			cbNamBatDau.SelectedIndex = 0;
			cbNamKetThuc.SelectedIndex = 0;
		}

		private void btnXemChiTiet_Click(object sender, EventArgs e)
		{
			fQuanLyNCKH f = new fQuanLyNCKH();
			f.DataUpdated += new fQuanLyNCKH.DataUpdatedHandler(fQuanLyNCKH_DataUpdated);
			f.ShowDialog();
		}
		private void fQuanLyNCKH_DataUpdated()
		{
			LoadProjectsData(); // Gọi lại phương thức tải lại dữ liệu
		}
		private void dtgvDSDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
		public void LoadComboBoxData()
		{
			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True";

			string query = @"
WITH SplitNames AS (
    SELECT nameResearchers AS Name
    FROM dbo.Projects
    UNION ALL
    SELECT LTRIM(RTRIM(value)) AS Name
    FROM dbo.Projects
    CROSS APPLY STRING_SPLIT(nameMember, ',')
)
SELECT DISTINCT 
    Name, 
    RIGHT(Name, CHARINDEX(' ', REVERSE(Name) + ' ')-1) COLLATE Vietnamese_CI_AS AS LastNameInitial,
    Name COLLATE Vietnamese_CI_AS
FROM SplitNames
WHERE Name IS NOT NULL AND Name <> ''
ORDER BY LastNameInitial, Name;

";


			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);

				// Thêm mục mặc định
				DataRow newRow = dataTable.NewRow();
				newRow["Name"] = "Chọn chủ nhiệm hoặc thành viên";
				dataTable.Rows.InsertAt(newRow, 0);

				cbTenChuNhiem.DataSource = dataTable;
				cbTenChuNhiem.DisplayMember = "Name";
				cbTenChuNhiem.ValueMember = "Name";
			}
		}


		public void LoadProjectsData()
		{


			string query = @"
    	SELECT 
		QDSo AS [Quyết định số],
		type AS [Loại dự án],
		nameProject AS [Tên đề tài],
		cap AS [Cấp đề tài],
		nameResearchers AS [Người nghiên cứu chính],
		nameMember AS [Thành viên tham gia],
		status AS [Trạng thái],
 FORMAT(ngayBatDau, 'MM-yyyy') AS [Tháng bắt đầu],
    FORMAT(ngayKetThuc, 'MM-yyyy') AS [Tháng kết thúc],
		FORMAT(ngayGiaHan, 'MM-yyyy') AS [Tháng gia hạn],
		FORMAT(ngayNghiemThu, 'MM-yyyy') AS [Tháng nghiệm thu],
		kinhPhi AS [Kinh phí],
		artical AS [Bài báo liên quan],
		prize AS [Giải thưởng]
	FROM Projects;
			  ";


			dtgvDSDT.DataSource = DataProvider.Instance.ExecuteQuery(query);

		}

		private void thêmThànhViênToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void contextMenuStripAddMember_Click(object sender, EventArgs e)
		{

		}
		void UpdateProjectMembers(string projectQDSo, string updateMembers)
		{
			string updateQuery = "UPDATE Projects SET nameMember = @updatedMembers WHERE QDSo = @projectQDSo";
			DataProvider.Instance.ExecuteNonQuery(updateQuery, new object[] { updateMembers, projectQDSo });
		}
		void UpdateNgayNghiemThu(string qdSo)
		{
			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=QuanLyNCKH;Integrated Security=True"; // Đảm bảo thay đổi theo kết nối của bạn

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand cmd = new SqlCommand("USP_UpdateNgayNghiemThu", connection))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					// Thêm tham số vào thủ tục
					cmd.Parameters.Add(new SqlParameter("@QDSo", qdSo));

					// Thực thi thủ tục
					cmd.ExecuteNonQuery();
				}
			}
		}

		private void contextMenuStripAddMember_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Text == "Thêm thành viên")
			{
				if (dtgvDSDT.CurrentRow != null)
				{
					using (var addMemberForm = new fAddMember())
					{
						if (addMemberForm.ShowDialog() == DialogResult.OK)
						{
							string newMember = addMemberForm.NewMemberName;
							string existingMembers = dtgvDSDT.CurrentRow.Cells["Thành viên tham gia"].Value?.ToString();

							// Thêm thành viên mới vào danh sách
							dtgvDSDT.CurrentRow.Cells["Thành viên tham gia"].Value = string.IsNullOrEmpty(existingMembers)
								? newMember
								: existingMembers + ", " + newMember;

							// Lưu lại vào cơ sở dữ liệu
							string projectQDSo = dtgvDSDT.CurrentRow.Cells["Quyết định số"].Value.ToString();
							string updatedMembers = dtgvDSDT.CurrentRow.Cells["Thành viên tham gia"].Value.ToString();

							// Gọi hàm để cập nhật thành viên vào cơ sở dữ liệu
							UpdateProjectMembers(projectQDSo, updatedMembers);

							// Làm mới ComboBox và DataGridView
							LoadComboBoxData();
							LoadProjectsData();  // Đảm bảo dữ liệu trong DataGridView được làm mới
						}
					}
				}
			}
		}
		private void xóaThànhViênToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dtgvDSDT.CurrentRow != null)
			{
				string memberList = dtgvDSDT.CurrentRow.Cells["Thành viên tham gia"].Value?.ToString();
				if (!string.IsNullOrEmpty(memberList))
				{
					List<string> members = memberList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
													 .Select(m => m.Trim())
													 .ToList();

					using (var removeMemberForm = new fRemoveMembers(members))
					{
						if (removeMemberForm.ShowDialog() == DialogResult.OK)
						{
							// Xóa các thành viên được chọn
							List<string> membersToRemove = removeMemberForm.MembersToRemove;
							members = members.Except(membersToRemove).ToList();

							// Cập nhật ô "Thành viên tham gia"
							dtgvDSDT.CurrentRow.Cells["Thành viên tham gia"].Value = string.Join(", ", members);

							// Lưu thay đổi vào cơ sở dữ liệu
							string projectQDSo = dtgvDSDT.CurrentRow.Cells["Quyết định số"].Value.ToString();
							UpdateProjectMembers(projectQDSo, string.Join(", ", members));
						}
					}
				}
				else
				{
					MessageBox.Show("Không có thành viên nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}


		private void rdGV_CheckedChanged(object sender, EventArgs e)
		{
			if (rdGV.Checked)
			{
				pnCap.Visible = true;
				ApplyFilter("Loại dự án", "Giảng viên"); // Áp dụng lọc cho "Giảng viên"
			}
			else
			{
				ResetFilter(); // Bỏ lọc khi không chọn
			}
		}

		private void rdSV_CheckedChanged(object sender, EventArgs e)
		{
			if (rdSV.Checked)
			{
				pnCap.Visible = false;
				ApplyFilter("Loại dự án", "Sinh viên"); // Áp dụng lọc cho "Sinh viên"
			}
			else
			{
				ResetFilter(); // Bỏ lọc khi không chọn
			}
		}

		private void rdCapTruong_CheckedChanged(object sender, EventArgs e)
		{
			if (rdCapTruong.Checked)
				ApplyFilter("Cấp đề tài", "Cấp trường"); // Áp dụng lọc cho "Cấp trường"
			else
				ResetFilter(); // Bỏ lọc khi không chọn
		}

		private void rdCapTrgTrongDiem_CheckedChanged(object sender, EventArgs e)
		{
			if (rdCapTrgTrongDiem.Checked)
				ApplyFilter("Cấp đề tài", "Cấp trường trọng điểm"); // Áp dụng lọc cho "Cấp trường trọng điểm"
			else
				ResetFilter(); // Bỏ lọc khi không chọn
		}

		private void rdCapTinh_CheckedChanged(object sender, EventArgs e)
		{
			if (rdCapTinh.Checked)
				ApplyFilter("Cấp đề tài", "Cấp tỉnh"); // Áp dụng lọc cho "Cấp tỉnh"
			else
				ResetFilter(); // Bỏ lọc khi không chọn
		}

		private void ResetFilter()
		{
			LoadProjectsData(); // Nạp lại dữ liệu gốc
		}

		void ApplyFilter(string columnName, string filterValue)
		{
			if (dtgvDSDT.DataSource is DataView dataView)
			{
				string escapedValue = filterValue.Replace("'", "''");
				dataView.RowFilter = $"[{columnName}] = '{escapedValue}'";
			}
			else if (dtgvDSDT.DataSource is DataTable dataTable)
			{
				DataView dv = new DataView(dataTable);
				string escapedValue = filterValue.Replace("'", "''");
				dv.RowFilter = $"[{columnName}] = '{escapedValue}'";
				dtgvDSDT.DataSource = dv;
			}
		}
		void ApplyFilterForCBB(string column1, string column2, string filterValue)
		{
			if (dtgvDSDT.DataSource is DataTable dataTable)
			{
				DataView dv = new DataView(dataTable);
				string escapedValue = filterValue.Replace("'", "''");
				dv.RowFilter = $"[{column1}] = '{escapedValue}' OR [{column2}] LIKE '%{escapedValue}%'";
				dtgvDSDT.DataSource = dv;
			}
		}


		private void rdAll_CheckedChanged(object sender, EventArgs e)
		{
			ResetFilter();
		}

		private void cbTenChuNhiem_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbTenChuNhiem.SelectedIndexChanged -= cbTenChuNhiem_SelectedIndexChanged;

			// Xử lý logic lọc
			if (cbTenChuNhiem.SelectedValue != null)
			{
				string selectedValue = cbTenChuNhiem.SelectedValue.ToString();
				if (selectedValue == "Chọn chủ nhiệm hoặc thành viên")
				{
					ResetFilter();
				}
				else
				{
					LoadProjectsData();
					ApplyFilterForCBB("Người nghiên cứu chính", "Thành viên tham gia", selectedValue);
				}
			}

			cbTenChuNhiem.SelectedIndexChanged += cbTenChuNhiem_SelectedIndexChanged;
		}

		private void contextMenuStripAddMember_Opening(object sender, CancelEventArgs e)
		{

		}
		#region cbNam
		public void LoadYearComboBox()
		{
			// Lấy danh sách năm từ cơ sở dữ liệu
			string query = @"
        SELECT DISTINCT YEAR(NgayBatDau) AS Nam 
        FROM dbo.Projects
        UNION
        SELECT DISTINCT YEAR(NgayKetThuc) AS Nam
        FROM dbo.Projects
        ORDER BY Nam";

			DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

			// Xóa dữ liệu cũ trong ComboBox
			cbNamBatDau.Items.Clear();
			cbNamKetThuc.Items.Clear();

			cbNamBatDau.Items.Add("Chọn");
			cbNamKetThuc.Items.Add("Chọn");

			// Thêm dữ liệu mới vào ComboBox
			foreach (DataRow row in dataTable.Rows)
			{
				cbNamBatDau.Items.Add(row["Nam"].ToString());
				cbNamKetThuc.Items.Add(row["Nam"].ToString());
			}

			cbNamBatDau.SelectedIndex = 0;
			cbNamKetThuc.SelectedIndex = 0;
		}

		private void cbNamBatDau_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterProjectsByYear();

		}

		private void cbNamKetThuc_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterProjectsByYear();
		}

		private void FilterProjectsByYear()
		{
			if (cbNamBatDau.SelectedIndex > 0 || cbNamKetThuc.SelectedIndex > 0)
			{
				string query = @"
        SELECT 
            QDSo AS [Quyết định số], 
            type AS [Loại dự án], 
            nameProject AS [Tên đề tài], 
            cap AS [Cấp đề tài], 
            nameResearchers AS [Người nghiên cứu chính], 
            nameMember AS [Thành viên tham gia], 
            ngayBatDau AS [Ngày bắt đầu], 
            ngayKetThuc AS [Ngày kết thúc],
            status AS [Trạng thái]
        FROM dbo.Projects
        WHERE 1 = 1"; // Luôn đúng, để nối thêm điều kiện sau

				List<object> parameters = new List<object>();

				if (cbNamBatDau.SelectedIndex > 0)
				{
					int namBatDau = int.Parse(cbNamBatDau.SelectedItem.ToString());
					query += " AND YEAR(ngayBatDau) >= @namBatDau";
					parameters.Add(namBatDau);
				}

				if (cbNamKetThuc.SelectedIndex > 0)
				{
					int namKetThuc = int.Parse(cbNamKetThuc.SelectedItem.ToString());
					query += " AND YEAR(ngayKetThuc) <= @namKetThuc";
					parameters.Add(namKetThuc);
				}

				// Kiểm tra điều kiện hợp lệ
				if (cbNamBatDau.SelectedIndex > 0 && cbNamKetThuc.SelectedIndex > 0)
				{
					int namBatDau = int.Parse(cbNamBatDau.SelectedItem.ToString());
					int namKetThuc = int.Parse(cbNamKetThuc.SelectedItem.ToString());

					if (namBatDau > namKetThuc)
					{
						MessageBox.Show("Năm bắt đầu không được lớn hơn năm kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				// Lấy dữ liệu từ database
				DataTable filteredData = DataProvider.Instance.ExecuteQuery(query, parameters.ToArray());

				// Hiển thị dữ liệu đã lọc
				dtgvDSDT.DataSource = filteredData;
			}
			else
			{
				// Nếu cả hai ComboBox đều chọn "Chọn", tải lại toàn bộ dữ liệu
				LoadProjectsData();
			}


		}




		#endregion
		#region cbb status
		private void LoadTrangThaiComboBox()
		{
			cbTrangThai.Items.Clear();
			cbTrangThai.Items.Add("Tất cả"); // Mục mặc định không lọc
			cbTrangThai.Items.Add("Đã nghiệm thu");
			cbTrangThai.Items.Add("Đã hủy");
			cbTrangThai.Items.Add("Đang thực hiện");

			cbTrangThai.SelectedIndex = 0; // Chọn mặc định "Tất cả"
		}

		private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
		{

			// Kiểm tra lựa chọn
			string selectedStatus = cbTrangThai.SelectedItem.ToString();

			// Nếu chọn "Tất cả", nạp lại toàn bộ dữ liệu
			if (selectedStatus == "Tất cả")
			{
				LoadProjectsData();
				return;
			}

			// Lọc dữ liệu từ cơ sở dữ liệu theo trạng thái
			string query = @"
        SELECT 
            QDSo AS [Quyết định số], 
            type AS [Loại dự án], 
            nameProject AS [Tên đề tài], 
            cap AS [Cấp đề tài], 
            nameResearchers AS [Người nghiên cứu chính], 
            nameMember AS [Thành viên tham gia], 
            ngayBatDau AS [Ngày bắt đầu], 
            ngayKetThuc AS [Ngày kết thúc],
            status AS [Trạng thái]
        FROM dbo.Projects
        WHERE status = @status";

			// Thực thi truy vấn và hiển thị dữ liệu lọc
			DataTable filteredData = DataProvider.Instance.ExecuteQuery(query, new object[] { selectedStatus });
			dtgvDSDT.DataSource = filteredData;
		}


		#endregion
		#region GiaHan
		private void contextMenuStripGiaHan_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void dtgvDSDT_MouseDown(object sender, MouseEventArgs e)
		{
			// Lấy thông tin ô được nhấp
			DataGridView.HitTestInfo hit = dtgvDSDT.HitTest(e.X, e.Y);

			if (e.Button == MouseButtons.Right && hit.Type == DataGridViewHitTestType.Cell)
			{
				// Chọn ô được nhấp
				dtgvDSDT.ClearSelection();
				dtgvDSDT[hit.ColumnIndex, hit.RowIndex].Selected = true;

				// Kiểm tra tên cột để hiển thị menu phù hợp
				string columnName = dtgvDSDT.Columns[hit.ColumnIndex].HeaderText;

				if (columnName == "Thành viên tham gia") // Cột Thêm thành viên
				{
					dtgvDSDT.ContextMenuStrip = contextMenuStripAddMember; // Hiển thị menu thêm thành viên
				}
				else if (columnName == "Tháng kết thúc") // Cột Gia hạn đề tài
				{
					dtgvDSDT.ContextMenuStrip = contextMenuStripGiaHan; // Hiển thị menu gia hạn
				}
				else if (columnName == "Trạng thái") // Cột Gia hạn đề tài
				{
					dtgvDSDT.ContextMenuStrip = contextMenuStripTrangThai; // Hiển thị menu gia hạn
				}
				else
				{
					dtgvDSDT.ContextMenuStrip = null; // Không hiển thị menu
				}
			}
			else
			{
				dtgvDSDT.ContextMenuStrip = null; // Không hiển thị menu nếu không nhấp chuột phải
			}
		}


		private void giaHạnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Lấy ô hiện tại được chọn
			if (dtgvDSDT.SelectedCells.Count > 0)
			{
				DataGridViewCell selectedCell = dtgvDSDT.SelectedCells[0];
				int rowIndex = selectedCell.RowIndex;

				// Lấy giá trị Quyết định số (hoặc bất kỳ khóa chính nào) từ hàng đó
				string qdSo = dtgvDSDT.Rows[rowIndex].Cells["Quyết định số"].Value.ToString();

				// Lấy giá trị hiện tại của cột "Ngày kết thúc"
				DateTime ngayKetThuc = Convert.ToDateTime(selectedCell.Value);

				// Hiển thị Form Gia Hạn
				using (fGiaHan formGiaHan = new fGiaHan())
				{
					if (formGiaHan.ShowDialog() == DialogResult.OK)
					{
						// Cộng thêm số ngày được nhập
						int soNgayGiaHan = formGiaHan.SoNgayGiaHan;
						DateTime ngayGiaHanMoi = ngayKetThuc.AddMonths(soNgayGiaHan);

						// Cập nhật vào cơ sở dữ liệu
						string query = "UPDATE Projects SET ngayGiaHan = @ngayGiaHan WHERE QDSo = @QDSo";
						DataProvider.Instance.ExecuteNonQuery(query, new object[] { ngayGiaHanMoi, qdSo });

						LoadProjectsData();
						// Cập nhật lại DataGridView
						selectedCell.Value = ngayGiaHanMoi;
						MessageBox.Show($"Đề tài đã được gia hạn thêm {soNgayGiaHan} tháng, tháng kết thúc mới là {ngayGiaHanMoi:MM/yyyy}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
		}
		#endregion

		private void txtTimKiemTheoDeTai_TextChanged(object sender, EventArgs e)
		{
			// Kiểm tra nếu DataGridView đã được gắn dữ liệu
			if (dtgvDSDT.DataSource is DataTable dataTable)
			{
				string filter = txtTimKiemTheoDeTai.Text.Trim(); // Lấy giá trị trong ô tìm kiếm
				if (!string.IsNullOrEmpty(filter))
				{
					// Áp dụng bộ lọc (tìm kiếm không phân biệt hoa thường)
					dataTable.DefaultView.RowFilter = $"[Tên đề tài] LIKE '%{filter}%'";
				}
				else
				{
					// Nếu ô tìm kiếm trống, xóa bộ lọc
					dataTable.DefaultView.RowFilter = string.Empty;
				}
			}
		}

		private void contextMenuStripTrangThai_Opening(object sender, CancelEventArgs e)
		{

		}

		private void contextMenuStripGiaHan_Opening(object sender, CancelEventArgs e)
		{

		}

		private void hủyDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Lấy ô hiện tại được chọn
			if (dtgvDSDT.SelectedCells.Count > 0)
			{
				int rowIndex = dtgvDSDT.SelectedCells[0].RowIndex;

				// Lấy thông tin dự án
				string qdSo = dtgvDSDT.Rows[rowIndex].Cells["Quyết định số"].Value.ToString();
				string nameProject = dtgvDSDT.Rows[rowIndex].Cells["Tên đề tài"].Value.ToString();
				string status = dtgvDSDT.Rows[rowIndex].Cells["Trạng thái"].Value.ToString();

				// Kiểm tra trạng thái hiện tại
				if (status != "Đang thực hiện")
				{
					MessageBox.Show("Chỉ có thể hủy các dự án đang thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Hiển thị hộp thoại xác nhận
				DialogResult result = MessageBox.Show(
					$"Bạn có chắc chắn muốn hủy dự án:\n\nQuyết định số: {qdSo}\nTên đề tài: {nameProject}\n\nThao tác này không thể hoàn tác!",
					"Xác nhận hủy dự án",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);

				// Nếu người dùng chọn "Yes", thực hiện cập nhật
				if (result == DialogResult.Yes)
				{
					// Cập nhật trạng thái trong cơ sở dữ liệu
					string query = "UPDATE Projects SET status = N'Đã hủy' WHERE QDSo = @QDSo";
					DataProvider.Instance.ExecuteNonQuery(query, new object[] { qdSo });

					// Làm mới DataGridView
					LoadProjectsData();

					// Thông báo thành công
					MessageBox.Show($"Dự án \"{nameProject}\" đã được hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn dự án cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		private void CompleteProject(string qdSo)
		{
			// Câu lệnh SQL cập nhật trạng thái và ngày nghiệm thu
			string query = "UPDATE Projects SET status = N'Đã hoàn thành', ngayNghiemThu = GETDATE() WHERE QDSo = @QDSo";

			// Thực thi câu lệnh SQL
			DataProvider.Instance.ExecuteNonQuery(query, new object[] { qdSo });
		}

		private void hoànThànhToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dtgvDSDT.SelectedCells.Count > 0)
			{
				int rowIndex = dtgvDSDT.SelectedCells[0].RowIndex;

				// Lấy dữ liệu từ ô được chọn
				string qdSo = dtgvDSDT.Rows[rowIndex].Cells["Quyết định số"].Value?.ToString();
				string nameProject = dtgvDSDT.Rows[rowIndex].Cells["Tên đề tài"].Value?.ToString();
				string status = dtgvDSDT.Rows[rowIndex].Cells["Trạng thái"].Value?.ToString();

				// Kiểm tra trạng thái hiện tại
				if (status != "Đang thực hiện")
				{
					MessageBox.Show("Chỉ có thể hoàn thành các dự án đang thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Xác nhận từ người dùng
				var result = MessageBox.Show(
					$"Bạn có chắc chắn muốn hoàn thành dự án này:\n\nQuyết định số: {qdSo}\nTên đề tài: {nameProject}\nThao tác này không thể hoàn tác!",
					"Xác nhận hoàn thành",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);

				if (result == DialogResult.Yes)
				{
					try
					{
						// Gọi hàm cập nhật trạng thái
						CompleteProject(qdSo);

						// Làm mới dữ liệu hiển thị
						LoadProjectsData();

						// Thông báo thành công
						MessageBox.Show($"Dự án \"{nameProject}\" đã hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						// Hiển thị thông báo lỗi
						MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn dự án cần hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}


		private void tiếpTụcDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Lấy ô hiện tại được chọn
			if (dtgvDSDT.SelectedCells.Count > 0)
			{
				int rowIndex = dtgvDSDT.SelectedCells[0].RowIndex;

				// Lấy thông tin dự án
				string qdSo = dtgvDSDT.Rows[rowIndex].Cells["Quyết định số"].Value.ToString();
				string nameProject = dtgvDSDT.Rows[rowIndex].Cells["Tên đề tài"].Value.ToString();
				string status = dtgvDSDT.Rows[rowIndex].Cells["Trạng thái"].Value.ToString();

		

				// Hiển thị hộp thoại xác nhận
				DialogResult result = MessageBox.Show(
					$"Bạn có chắc chắn muốn cập nhật dự án:\n\nQuyết định số: {qdSo}\nTên đề tài: {nameProject}\n\nThao tác này không thể hoàn tác!",
					"Xác nhận cập nhật dự án",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);

				// Nếu người dùng chọn "Yes", thực hiện cập nhật
				if (result == DialogResult.Yes)
				{
					// Cập nhật trạng thái trong cơ sở dữ liệu
					string query = "UPDATE Projects SET status = N'Đang thực hiện' WHERE QDSo = @QDSo";
					DataProvider.Instance.ExecuteNonQuery(query, new object[] { qdSo });

					// Làm mới DataGridView
					LoadProjectsData();

					// Thông báo thành công
					MessageBox.Show($"Dự án \"{nameProject}\" đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn dự án cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
