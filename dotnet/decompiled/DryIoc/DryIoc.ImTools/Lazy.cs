using System;

namespace DryIoc.ImTools;

public static class Lazy
{
	public static Lazy<T> Of<T>(Func<T> valueFactory)
	{
		return new Lazy<T>(valueFactory);
	}
}
