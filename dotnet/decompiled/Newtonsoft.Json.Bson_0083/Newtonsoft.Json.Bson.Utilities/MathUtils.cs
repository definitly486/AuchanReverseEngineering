namespace Newtonsoft.Json.Bson.Utilities;

internal static class MathUtils
{
	public static int IntLength(ulong i)
	{
		if (i < 10000000000L)
		{
			if (i < 10)
			{
				return 1;
			}
			if (i < 100)
			{
				return 2;
			}
			if (i < 1000)
			{
				return 3;
			}
			if (i < 10000)
			{
				return 4;
			}
			if (i < 100000)
			{
				return 5;
			}
			if (i < 1000000)
			{
				return 6;
			}
			if (i < 10000000)
			{
				return 7;
			}
			if (i < 100000000)
			{
				return 8;
			}
			if (i < 1000000000)
			{
				return 9;
			}
			return 10;
		}
		if (i < 100000000000L)
		{
			return 11;
		}
		if (i < 1000000000000L)
		{
			return 12;
		}
		if (i < 10000000000000L)
		{
			return 13;
		}
		if (i < 100000000000000L)
		{
			return 14;
		}
		if (i < 1000000000000000L)
		{
			return 15;
		}
		if (i < 10000000000000000L)
		{
			return 16;
		}
		if (i < 100000000000000000L)
		{
			return 17;
		}
		if (i < 1000000000000000000L)
		{
			return 18;
		}
		if (i < 10000000000000000000uL)
		{
			return 19;
		}
		return 20;
	}
}
