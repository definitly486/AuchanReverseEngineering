using System;
using System.ComponentModel;
using System.Globalization;
using Android.Graphics;

namespace Microsoft.Maui.Graphics.Converters;

public class RectFTypeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string);
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(string)) && !(destinationType == typeof(global::Android.Graphics.Rect)))
		{
			return destinationType == typeof(global::Android.Graphics.RectF);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (RectF.TryParse(value?.ToString(), out var rectangleF))
		{
			return rectangleF;
		}
		throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(RectF)}");
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(value is RectF rectF))
		{
			throw new NotSupportedException();
		}
		if (destinationType == typeof(global::Android.Graphics.Rect))
		{
			return (global::Android.Graphics.Rect)rectF;
		}
		if (destinationType == typeof(global::Android.Graphics.RectF))
		{
			return (global::Android.Graphics.RectF)rectF;
		}
		return $"{rectF.X.ToString(CultureInfo.InvariantCulture)}, {rectF.Y.ToString(CultureInfo.InvariantCulture)}, {rectF.Width.ToString(CultureInfo.InvariantCulture)}, {rectF.Height.ToString(CultureInfo.InvariantCulture)}";
	}
}
