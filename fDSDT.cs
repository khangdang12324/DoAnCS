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


		void LoadProjectsData()
		{


			string query = @"
        SELECT 
            QDSo AS [Quyết định số], 
            type AS [Loại dự án], 
            nameProject AS [Tên đề tài], 
			cap AS[Cấp đề tài],
            nameResearchers AS [Người nghiên cứu chính], 
            nameMember AS [Thành viên tham gia], 
            ngayBatDau AS [Ngày bắt đầu], 
            ngayKetThuc AS [Ngày kết thúc],
			status AS [Trạng thái]
        FROM dbo.Projects;
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
	}
}
