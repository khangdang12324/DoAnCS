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
	public partial class fRemoveMembers : Form
	{
		public List<string> Members { get; set; }
		public List<string> MembersToRemove { get; private set; } = new List<string>();
		public fRemoveMembers(List<string> members)
		{
			InitializeComponent();
			Members = members;
			LoadMembers();
		}

		private void fRemoveMembers_Load(object sender, EventArgs e)
		{

		}

		private void LoadMembers()
		{
			foreach (string member in Members)
			{
				clbDSTV.Items.Add(member);
			}
		}

		private void btnXacNhan_Click(object sender, EventArgs e)
		{
			foreach (var item in clbDSTV.CheckedItems)
			{
				MembersToRemove.Add(item.ToString());
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnHuy_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			
		}
	}
}
