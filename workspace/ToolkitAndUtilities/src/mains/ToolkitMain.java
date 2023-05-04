package mains;

import toolkitAndUtilities.SCommon;

public class ToolkitMain {
	public static void main(String[] args) {
		try {

			// -- choose one --

			test01();

			// --
		}
		catch (Throwable e) {
			e.printStackTrace();
		}
	}

	private static void test01() {
		byte[] data = SCommon.cryptRandom.getBytes(100);
		byte[] gzData = SCommon.compress(data);
		String gzStr = SCommon.Base64.encode(gzData);

		System.out.println(SCommon.Hex.toString(gzData));
		System.out.println(gzStr);
	}
}
