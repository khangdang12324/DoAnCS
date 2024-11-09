using Do_an_co_so.DAO;
using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;

	namespace Do_an_co_so
	{
		public partial class fDangNhap : Form
		{
			public fDangNhap()
			{
				InitializeComponent();
			}

			private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			{
				fQuenMatKhau quenMatKhau = new fQuenMatKhau();
				quenMatKhau.ShowDialog();
			}

			private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			{
				fDangKy dangKy = new fDangKy();
				dangKy.ShowDialog();
			}

			private void button1_Click(object sender, EventArgs e)
			{
			string userName = txtUserName.Text;
			string passWord = txtPassWord.Text;
			if (Login(userName,passWord))
			{
				fHome frm = new fHome(); // Create an instance of frmChinh
				this.Hide(); // Optional: Hide the current form
				frm.ShowDialog(); // Show frmChinh
				this.Show();
			}
			else
			{
				MessageBox.Show("Sai tên tài khoảng hoặc mật khẩu!");
			}

		}
			bool Login(string userName, string passWord)
		{
			return AccountDAO.Instance.Login(userName, passWord);
		}

			private void textBox_TenTaiKhoan_TextChanged(object sender, EventArgs e)
			{

			}

		private void DangNhap_Load(object sender, EventArgs e)
		{

		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
			{
				e.Cancel = true;
			}
		}

		private void textBox_MatKhau_TextChanged(object sender, EventArgs e)
		{

		}
	}
	}
