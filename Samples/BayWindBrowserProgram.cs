﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Sop.Samples
{
	public class Program
	{
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BayWindBrowser());
		}
	}
}
