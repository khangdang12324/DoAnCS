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
	public partial class fAddMember : Form
	{
		public string NewMemberName => txtAddMember.Text.Trim();

		public fAddMember()
		{
			InitializeComponent();
		}

		private void fAddMember_Load(object sender, EventArgs e)
		{

		}

		private void txtQD_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
