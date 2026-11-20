using System;
using System.Text.RegularExpressions;

namespace Newtonsoft.Json.Bson.Utilities;

internal static class ConvertUtils
{
	public static bool TryConvertGuid(string s, out Guid g)
	{
		if (s == null)
		{
			throw new ArgumentNullException("s");
		}
		if (new Regex("^[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}$").Match(s).Success)
		{
			g = new Guid(s);
			return true;
		}
		g = Guid.Empty;
		return false;
	}
}
