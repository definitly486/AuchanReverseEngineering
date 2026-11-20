using System.Text;

namespace NLog.Targets;

internal static class StringHelpers
{
	internal static bool IsNullOrWhiteSpace(string value)
	{
		return string.IsNullOrWhiteSpace(value);
	}

	public static bool EqualTo(this StringBuilder builder, string other)
	{
		if (builder.Length != other.Length)
		{
			return false;
		}
		int num = 0;
		foreach (char c in other)
		{
			if (builder[num++] != c)
			{
				return false;
			}
		}
		return true;
	}
}
