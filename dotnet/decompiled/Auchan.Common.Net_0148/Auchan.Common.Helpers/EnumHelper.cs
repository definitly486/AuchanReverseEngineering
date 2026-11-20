using System;
using System.Collections.Generic;
using System.Linq;

namespace Auchan.Common.Helpers;

public static class EnumHelper
{
	public static List<T> GetEnumList<T>() where T : Enum
	{
		return Enum.GetValues(typeof(T)).Cast<T>().ToList();
	}
}
