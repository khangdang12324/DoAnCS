﻿using System;
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
	public partial class fThemDeTaiMoi : Form
	{
		public fThemDeTaiMoi()
		{
			InitializeComponent();
		}

		private void fThemDeTaiMoi_Load(object sender, EventArgs e)
		{
			cbTrangThai.SelectedIndex = 0;
		
		}
	}
}