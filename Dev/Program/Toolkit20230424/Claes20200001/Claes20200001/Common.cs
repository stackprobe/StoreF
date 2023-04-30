using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte
{
	public static class Common
	{
		public static bool IsMbcKana(char chr)
		{
			return 0x30a1 <= (int)chr && (int)chr <= 0x30fc; // ? カタカナ(30A1～30FA) || 中点(30FB) || 長音記号(30FC)
		}
	}
}
