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

			// ----

			int[,] u1 = new int[2100000000, 0]; // OK
			int[,] u2 = new int[0, 2100000000]; // OK
			int[,] u3 = new int[10000, 10000]; // OK
			//int[,] u4 = new int[100000, 100000]; // メモリ不足
			//int[,] u5 = new int[1000000, 1000000]; // メモリ不足

			Console.WriteLine(u1);
			Console.WriteLine(u2);
			Console.WriteLine(u3);
			//Console.WriteLine(u4);
			//Console.WriteLine(u5);
		}
	}
}
