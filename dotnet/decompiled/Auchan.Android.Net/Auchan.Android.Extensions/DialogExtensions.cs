using System;
using Android.App;
using Android.Views;

namespace Auchan.Android.Extensions;

internal static class DialogExtensions
{
	public static T RequireViewById<T>(this Dialog @this, int id) where T : View
	{
		return @this.FindViewById<T>(id) ?? throw new ArgumentException("id", $"view with {id} isn't found");
	}
}
