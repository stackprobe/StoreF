package tests.toolkitAndUtilities;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

import toolkitAndUtilities.SCommon;

public class UnitTestMain {
	public static void main(String[] args) {
		try {

			// -- choose one --

			//test0001_01(); // SCommon.getIndex
			//test0002_01(); // SCommon.getRange
			//test0003_01(); // SCommon.Base64
			//test0004_01(); // RandomUnit
			test0004_02(); // RandomUnit

			// --
		}
		catch (Throwable e) {
			e.printStackTrace();
		}
	}

	private static void test0001_01() {
		for (int a = 0; a < 10; a++) {
			for (int b = 0; b <= 1; b++) {
				for (int c = 0; c < 10; c++) {
					String str = "A".repeat(a) + "B".repeat(b) + "C".repeat(c);
					char target = 'B';
					int expect = b == 1 ? a : -1;

					test0001_01_a(str, target, expect);
				}
			}
		}
		System.out.println("OK!");
	}

	private static void test0001_01_a(String str, char target, int expect) {
		int ret = SCommon.getIndex(SCommon.toList(str.toCharArray()), target, (a, b) -> (int)a - (int)b);

		System.out.println(SCommon.joining(", ", "TEST-0001-01", str, target, expect, ret));

		boolean expectTrue =
				ret == expect;
		if (!expectTrue) {
			throw null;
		}

		System.out.println("OK");
	}

	private static void test0002_01() {
		for (int a = 0; a < 10; a++) {
			for (int b = 0; b < 10; b++) {
				for (int c = 0; c < 10; c++) {
					String str = "A".repeat(a) + "B".repeat(b) + "C".repeat(c);
					char target = 'B';
					int expectRange_L = a - 1;
					int expectRange_R = a + b;

					test0002_01_a(str, target, expectRange_L, expectRange_R);
				}
			}
		}
		System.out.println("OK!");
	}

	private static void test0002_01_a(String str, char target, int expectRange_L, int expectRange_R) {
		int[] range = SCommon.getRange(SCommon.toList(str.toCharArray()), target, (a, b) -> (int)a - (int)b);

		System.out.println(SCommon.joining(", ", "TEST-0002-01", str, target, expectRange_L, expectRange_R, range[0], range[1]));

		boolean expectTrue =
				range[0] == expectRange_L &&
				range[1] == expectRange_R;
		if (!expectTrue) {
			throw null;
		}

		System.out.println("OK");
	}

	private static void test0003_01() {
		for (int testcnt = 0; testcnt < 10000; testcnt++) {
			byte[] data = SCommon.cryptRandom.getBytes(SCommon.cryptRandom.getInt(1000));
			String str = SCommon.Base64.encode(data);

			if (str == null) {
				throw null;
			}
			if (!Pattern.matches("^[A-Za-z0-9+/]*=*$", str)) {
				throw null;
			}

			byte[] retData = SCommon.Base64.decode(str);

			if (retData == null) {
				throw null;
			}
			if (SCommon.compare(data, retData) != 0) { // ? not same
				throw null;
			}
		}
		System.out.println("OK! (TEST-0003-01)");
	}

	private static void test0004_01() {
		for (int c = 0; c < 100; c++) {
			System.out.println(String.format("%.20f", SCommon.cryptRandom.getRate()));
		}
	}

	private static void test0004_02() {
		test0004_02_a(3.0, 7.0);
		test0004_02_a(-3.0, 7.0);
		test0004_02_a(-3.0, 3.0);
		test0004_02_a(-7.0, 3.0);
		test0004_02_a(-7.0, -3.0);
	}

	private static void test0004_02_a(double minval, double maxval) {
		List<Double> values = new ArrayList<Double>();

		for (int c = 0; c < 100; c++) {
			values.add(SCommon.cryptRandom.getRealRange(minval, maxval));
		}
		values.sort((a, b) -> SCommon.compare(a, b));

		SCommon.writeAllLines(
				new File("C:/temp/(" + minval + ")-(" + maxval + ").txt"),
				values.stream().map(value -> "" + value).collect(Collectors.toList()),
				SCommon.CHARSET_ASCII
				);
	}
}