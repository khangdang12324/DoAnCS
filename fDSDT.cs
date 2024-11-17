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
			LoadProjectsData();
			LoadComboBoxData();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void fDSDT_Load(object sender, EventArgs e)
		{

			cbNamBatDau.SelectedIndex = 0;
			
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
			string query = "SELECT DISTINCT nameResearchers FROM dbo.Projects";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);

				// Lọc chỉ lấy các tên duy nhất
				cbTenChuNhiem.DataSource = dataTable.DefaultView.ToTable(true, "nameResearchers");
				cbTenChuNhiem.DisplayMember = "nameResearchers";
				cbTenChuNhiem.ValueMember = "nameResearchers";
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
							UpdateProjectMembers(projectQDSo, dtgvDSDT.CurrentRow.Cells["Thành viên tham gia"].Value.ToString());

							// Làm mới DataGridView nếu cần
							LoadProjectsData();
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

		private void rdAll_CheckedChanged(object sender, EventArgs e)
		{
			ResetFilter();
		}

		private void cbTenChuNhiem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTenChuNhiem.SelectedIndex >= 0)
			{
				string selectedTeacher = cbTenChuNhiem.SelectedValue.ToString();
				ApplyFilter("Người nghiên cứu chính", selectedTeacher);
			}
			else
			{
				ResetFilter(); // Bỏ lọc nếu không chọn gì
			}
		}
	}
}
