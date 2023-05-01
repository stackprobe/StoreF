using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.Utilities;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			Canvas canvas = Canvas.LoadFromFile(@"C:\temp\yande.re_268454.jpg");

			canvas = canvas.GetSubImage(new I4Rect(0, 160, 2560, 1440));
			canvas = canvas.Expand(1920, 1080);

			canvas.Save(SCommon.NextOutputPath() + ".png");

			// ----

			canvas = Canvas.LoadFromFile(@"C:\temp\yande.re_268455.jpg");

			canvas = canvas.GetSubImage(new I4Rect(0, 0, 2560, 1440));
			canvas = canvas.Expand(1920, 1080);

			canvas.Save(SCommon.NextOutputPath() + ".png");
		}
	}
}
