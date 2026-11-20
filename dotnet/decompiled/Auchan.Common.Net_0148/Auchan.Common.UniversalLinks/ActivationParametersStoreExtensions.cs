using System;

namespace Auchan.Common.UniversalLinks;

public static class ActivationParametersStoreExtensions
{
	public static T? PopFor<T>(this IActivationParametersStore @this, Type type) where T : class
	{
		return @this.PopFor(type) as T;
	}
}
