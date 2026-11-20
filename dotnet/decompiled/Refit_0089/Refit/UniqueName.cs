using System;

namespace Refit;

internal class UniqueName
{
	public static string ForType<T>()
	{
		return ForType(typeof(T));
	}

	public static string ForType(Type refitInterfaceType)
	{
		string text = refitInterfaceType.FullName;
		int num = text.IndexOf('`');
		if (num < 0)
		{
			num = text.Length;
		}
		int num2 = text.Substring(0, num).LastIndexOf('.');
		if (num2 > 0)
		{
			text = text.Substring(num2 + 1);
		}
		string text2 = string.Empty;
		if (refitInterfaceType.IsGenericType)
		{
			text2 = text.Substring(text.IndexOf("["));
			text = text.Substring(0, text.Length - text2.Length);
		}
		text = text.Replace("+", "");
		string text3 = refitInterfaceType.Namespace?.Replace(".", "");
		return string.Concat("Refit.Implementation.Generated+" + text3 + text + text2, ", ", refitInterfaceType.Assembly.FullName);
	}
}
