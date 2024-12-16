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
	public partial class fDeTaiKH : Form
	{	
		private Form currentFormChild;
		public fDeTaiKH()
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

			//btnDSDT.BackColor = Color.White;
			//btnThemDTKH.BackColor = Color.White;
		
			////----------------------------------------
			//btnDSDT.ForeColor = Color.Black;
			//btnThemDTKH.ForeColor = Color.Black;
		}
		private void fDeTaiKH_Load(object sender, EventArgs e)
		{
			OpenChildForm(new fDSDT());
			ResetButtonColors();
			//btnDSDT.BackColor = Color.Black;
			//btnDSDT.ForeColor = Color.White;

		}
		private void button2_Click(object sender, EventArgs e)
		{
	
		}

		private void btnDSDT_Click(object sender, EventArgs e)
		{
			OpenChildForm(new fDSDT());
			ResetButtonColors();
			//btnDSDT.BackColor = Color.Black;
			//btnDSDT.ForeColor = Color.White;
		}

		private void btnThemDTKH_Click(object sender, EventArgs e)
		{
			OpenChildForm(new fThemDeTaiMoi());
			ResetButtonColors();
			//btnThemDTKH.BackColor = Color.Black;
			//btnThemDTKH.ForeColor = Color.White;
		}

		private void thốngKêTheoDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
