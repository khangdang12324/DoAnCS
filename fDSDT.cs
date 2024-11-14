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
	public partial class fDSDT : Form
	{
		public fDSDT()
		{
			InitializeComponent();
			LoadProjectsData();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void fDSDT_Load(object sender, EventArgs e)
		{
			
			cbNamBatDau.SelectedIndex = 0;
			cbTenChuNhiem.SelectedIndex = 0;
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

	}
}
