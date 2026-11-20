using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Java.Lang;

namespace Auchan.Android.Common.UiExtensions;

public static class LayoutInflateExtension
{
	public static void InflateFromLayoutAttribute(this ViewGroup? root, Context context, IAttributeSet attrs)
	{
		View.Inflate(context, GetLayoutIdFromAttributes(context, attrs), root);
	}

	private static int GetLayoutIdFromAttributes(Context context, IAttributeSet attrs)
	{
		string text = attrs.GetAttributeValue(null, "layout") ?? throw new ArgumentException("layout", new Java.Lang.Exception("attribute not found"));
		return (context.Resources ?? throw new NullReferenceException("layout")).GetIdentifier((text[0] == '@' && text.Length > 0) ? text.Substring(1) : text, "layout", context.PackageName);
	}
}
