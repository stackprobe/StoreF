using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;
using Charlotte.Utilities;
using Charlotte.Drawings;

namespace Charlotte.Tests
{
	class Test0002
	{
		private const string INPUT_ROOT_DIR = @"C:\temp";

		private static string[] IMAGE_EXTS = new string[]
		{
			".bmp",
			".jpg",
			".jpeg",
			".png",
		};

		private static I2Size MONITOR_SIZE = new I2Size(1920, 1080);

		public void Test01()
		{
			foreach (string file in Directory.GetFiles(INPUT_ROOT_DIR))
			{
				string ext = Path.GetExtension(file);

				if (IMAGE_EXTS.Any(v => SCommon.EqualsIgnoreCase(v, ext)))
				{
					ProcMain.WriteLog("< " + file);

					PictureName = Path.GetFileNameWithoutExtension(file);
					Picture = Canvas.LoadFromFile(file);

					ProcMain.WriteLog("W " + Picture.W);
					ProcMain.WriteLog("H " + Picture.H);

					D4Rect[] rects = Common.EnlargeFull(
						new I2Size(Picture.W, Picture.H).ToD2Size(),
						new I4Rect(0, 0, MONITOR_SIZE.W, MONITOR_SIZE.H).ToD4Rect()
						);

					Interior = rects[0].ToI4Rect();
					Exterior = rects[1].ToI4Rect();

					if (Exterior.T == 0 && Exterior.L == 0) // ? アスペクト比が同じ。
					{
						OutputSimple();
					}
					else
					{
						Picture_I = Picture.Expand(Interior.W, Interior.H);
						Picture_E = Picture.Expand(Exterior.W, Exterior.H);

						OutputTopOrLeft();
						OutputBottomOrRight();
						OutputCenter();

						Picture_I = null;
						Picture_E = null;
					}

					PictureName = null;
					Picture = null;
					Interior = default(I4Rect);
					Exterior = default(I4Rect);

					ProcMain.WriteLog("done");
				}
			}
			ProcMain.WriteLog("done!");
		}

		private string PictureName;
		private Canvas Picture;
		private Canvas Picture_I;
		private Canvas Picture_E;
		private I4Rect Interior;
		private I4Rect Exterior;

		private void OutputSimple()
		{
			Canvas canvas = Picture;
			canvas = canvas.Expand(MONITOR_SIZE.W, MONITOR_SIZE.H);
			canvas.Save(Path.Combine(SCommon.GetOutputDir(), PictureName + ".png"));
		}

		private void OutputTopOrLeft()
		{
			string suffix = Exterior.L == 0 ? "T" : "L";

			Picture_E
				.GetSubImage(new I4Rect(0, 0, MONITOR_SIZE.W, MONITOR_SIZE.H))
				.Save(Path.Combine(SCommon.GetOutputDir(), PictureName + suffix + ".png"));
		}

		private void OutputBottomOrRight()
		{
			string suffix = Exterior.L == 0 ? "B" : "R";

			Picture_E
				.GetSubImage(new I4Rect(Exterior.W - MONITOR_SIZE.W, Exterior.H - MONITOR_SIZE.H, MONITOR_SIZE.W, MONITOR_SIZE.H))
				.Save(Path.Combine(SCommon.GetOutputDir(), PictureName + suffix + ".png"));
		}

		private void OutputCenter()
		{
			string suffix = "C";

			Canvas canvas = Picture_E
				.GetSubImage(new I4Rect((Exterior.W - MONITOR_SIZE.W) / 2, (Exterior.H - MONITOR_SIZE.H) / 2, MONITOR_SIZE.W, MONITOR_SIZE.H));

			canvas
				.Save(Path.Combine(SCommon.GetOutputDir(), PictureName + suffix + ".png"));

			// ----

			canvas.FilterAllDot((dot, x, y) => new I4Color(dot.R / 2, dot.G / 2, dot.B / 2, 255));
			canvas.DrawImage(Picture_I, Interior.L, Interior.T, false);
			canvas.Save(Path.Combine(SCommon.GetOutputDir(), PictureName + ".png"));
		}
	}
}
