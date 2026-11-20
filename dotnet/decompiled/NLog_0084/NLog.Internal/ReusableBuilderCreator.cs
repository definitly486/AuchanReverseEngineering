using System;
using System.Text;

namespace NLog.Internal;

internal sealed class ReusableBuilderCreator : ReusableObjectCreator<StringBuilder>
{
	private const int MaxBuilderCapacity = 40960;

	public ReusableBuilderCreator()
		: base((Func<StringBuilder>)(() => new StringBuilder(512)), (Action<StringBuilder>)delegate(StringBuilder sb)
		{
			ResetCapacity(sb);
		})
	{
	}

	private static void ResetCapacity(StringBuilder stringBuilder)
	{
		if (stringBuilder.Length > 40960 && stringBuilder.Capacity > 409600)
		{
			stringBuilder.Remove(0, stringBuilder.Length - 1);
			stringBuilder.Capacity = 40960;
		}
		stringBuilder.ClearBuilder();
	}
}
