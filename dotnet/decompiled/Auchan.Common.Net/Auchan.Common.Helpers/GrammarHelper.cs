namespace Auchan.Common.Helpers;

public static class GrammarHelper
{
	public static string DeclineNoun(int qty, string[] words)
	{
		int[] array = new int[6] { 2, 0, 1, 1, 1, 2 };
		int num;
		if (qty % 100 > 4 && qty % 100 < 20)
		{
			num = 2;
		}
		else
		{
			int num2 = qty % 10;
			num = ((num2 < 5) ? array[num2] : array[5]);
		}
		return words[num];
	}

	public static string DeclineNoun(decimal qty, string[] words)
	{
		int num = decimal.ToInt32(qty);
		if (!(qty != (decimal)num))
		{
			return DeclineNoun(num, words);
		}
		return words[1];
	}

	public static string DeclineNoun(int qty, string oneEnd = "", string twofourEnd = "а", string defaultEnd = "ов")
	{
		int num = qty % 100 / 10;
		int num2 = qty % 10;
		if (num == 1)
		{
			return defaultEnd;
		}
		switch (num2)
		{
		case 1:
			return oneEnd;
		case 2:
		case 3:
		case 4:
			return twofourEnd;
		default:
			return defaultEnd;
		}
	}
}
