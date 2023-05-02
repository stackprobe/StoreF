using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Charlotte.Tests
{
	public class Test0002
	{
		public void Test01()
		{
			int[,] t1 = new int[100, 100]; // OK
			int[,] t2 = new int[0, 100]; // OK
			int[,] t3 = new int[100, 0]; // OK
			int[,] t4 = new int[0, 0]; // OK

			Console.WriteLine(t1);
			Console.WriteLine(t2);
			Console.WriteLine(t3);
			Console.WriteLine(t4);

			// ----

			Bitmap bmp1 = new Bitmap(100, 100); // OK
			//Bitmap bmp2 = new Bitmap(0, 100); // 例外
			//Bitmap bmp3 = new Bitmap(100, 0); // 例外
			//Bitmap bmp4 = new Bitmap(0, 0); // 例外

			Console.WriteLine(bmp1);
			//Console.WriteLine(bmp2);
			//Console.WriteLine(bmp3);
			//Console.WriteLine(bmp4);
		}
	}
}
