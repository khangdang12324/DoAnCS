using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Do_an_co_so
{
	public partial class fHome : Form
	{
		private Form currentFormChild;
		public fHome()
		{
			InitializeComponent();
		}
		private void OpenChildForm(Form childForm)
		{
			if (currentFormChild != null)
			{
				currentFormChild.Close();
			}
			currentFormChild = childForm;
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			panelMain.Controls.Add(childForm);
			panelMain.Tag = childForm;
			childForm.BringToFront();
			childForm.Show();
		}
		private void ResetButtonColors()
		{

			btnDeTaiKH.BackColor = Color.White;

			btnDeTaiKH.ForeColor = Color.Black;

			btnChuNhiem.BackColor = Color.White;

			btnChuNhiem.ForeColor = Color.Black;

		}


		private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void panelTop_Paint(object sender, PaintEventArgs e)
		{

		}

		private void thôngTinCáNhânToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			fAccountProfile f = new fAccountProfile();
			f.ShowDialog();
		}

		private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnDeTaiKH_Click(object sender, EventArgs e)
		{
			OpenChildForm(new fDeTaiKH());
			ResetButtonColors();
			btnDeTaiKH.BackColor = Color.Black;
			btnDeTaiKH.ForeColor = Color.White;
		}

		private void fHome_Load(object sender, EventArgs e)
		{

			OpenChildForm(new fDeTaiKH ());
			btnDeTaiKH.BackColor = Color.Black;
			btnDeTaiKH.ForeColor = Color.White;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenChildForm(new fChuNhiem());
			ResetButtonColors();
			btnChuNhiem.BackColor = Color.Black;
			btnChuNhiem.ForeColor = Color.White;
		}

	}
}
