using System;
using System.ComponentModel;
using System.Globalization;
using Android.Graphics;

namespace Microsoft.Maui.Graphics.Converters;

public class RectTypeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string);
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(string)) && !(destinationType == typeof(RectF)) && !(destinationType == typeof(global::Android.Graphics.Rect)))
		{
			return destinationType == typeof(global::Android.Graphics.RectF);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (Rect.TryParse(value?.ToString(), out var rectangle))
		{
			return rectangle;
		}
		throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Rect)}");
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(value is Rect rect))
		{
			throw new NotSupportedException();
		}
		if (destinationType == typeof(RectF))
		{
			return (RectF)rect;
		}
		if (destinationType == typeof(global::Android.Graphics.Rect))
		{
			return (global::Android.Graphics.Rect)rect;
		}
		if (destinationType == typeof(global::Android.Graphics.RectF))
		{
			return (global::Android.Graphics.RectF)rect;
		}
		return $"{rect.X.ToString(CultureInfo.InvariantCulture)}, {rect.Y.ToString(CultureInfo.InvariantCulture)}, {rect.Width.ToString(CultureInfo.InvariantCulture)}, {rect.Height.ToString(CultureInfo.InvariantCulture)}";
	}
}
