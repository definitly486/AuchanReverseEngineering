using System;
using System.Diagnostics.CodeAnalysis;
using Android.Views;
using Auchan.Android.Base;
using Auchan.Common.Common;
using DryIoc.ImTools;

namespace Auchan.Android.Extensions;

public static class RequireViewExtensions
{
	[return: NotNull]
	public static T RequireCachedView<T>(this CachingViewHolder parent, int id) where T : View
	{
		View view = parent.FindCachedView(id);
		if (view == null)
		{
			throw CreateAndOutputNotFoundException(id, parent.ItemView.Resources?.GetResourceEntryName(id), parent.GetType().Name);
		}
		return (view as T) ?? throw CreateAndOutputCastException(id, parent.ItemView.Resources?.GetResourceEntryName(id), parent.GetType().Name, typeof(T), view.GetType());
	}

	private static NotFoundException CreateAndOutputNotFoundException(int id, string? name, string parentName)
	{
		return new NotFoundException(GetMessage(id, name, parentName)).Do(Console.WriteLine);
	}

	private static InvalidCastException CreateAndOutputCastException(int id, string? name, string parentName, Type expectedType, Type actualType)
	{
		return new InvalidCastException(GetMessage(id, name, parentName) + $", expected type {expectedType}, actual type {actualType}").Do(Console.WriteLine);
	}

	private static string GetMessage(int id, string? name, string parentName)
	{
		return $"View with resource id {id}, name {name ?? "unknown"}, not found in {parentName}";
	}
}
