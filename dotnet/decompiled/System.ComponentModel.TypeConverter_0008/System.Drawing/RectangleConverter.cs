using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace System.Drawing;

public class RectangleConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
	{
		if (!(destinationType == typeof(InstanceDescriptor)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		if (value is string text)
		{
			ReadOnlySpan<char> source = text.AsSpan().Trim();
			if (source.Length == 0)
			{
				return null;
			}
			if (culture == null)
			{
				culture = CultureInfo.CurrentCulture;
			}
			string listSeparator = culture.TextInfo.ListSeparator;
			Span<Range> destination = stackalloc Range[5];
			if (source.Split(destination, listSeparator.AsSpan()) != 4)
			{
				throw new ArgumentException(System.SR.Format("TextParseFailedFormat", source.ToString(), $"x{listSeparator} y{listSeparator} width{listSeparator} height"));
			}
			TypeConverter converterTrimUnsafe = TypeDescriptor.GetConverterTrimUnsafe(typeof(int));
			CultureInfo? culture2 = culture;
			Range range = destination[0];
			int length = text.Length;
			int x = (int)converterTrimUnsafe.ConvertFromString(context, culture2, text[range.Start.GetOffset(length)..range.End.GetOffset(length)]);
			CultureInfo? culture3 = culture;
			range = destination[1];
			int length2 = text.Length;
			int y = (int)converterTrimUnsafe.ConvertFromString(context, culture3, text[range.Start.GetOffset(length2)..range.End.GetOffset(length2)]);
			CultureInfo? culture4 = culture;
			range = destination[2];
			length = text.Length;
			int width = (int)converterTrimUnsafe.ConvertFromString(context, culture4, text[range.Start.GetOffset(length)..range.End.GetOffset(length)]);
			CultureInfo? culture5 = culture;
			range = destination[3];
			length2 = text.Length;
			int height = (int)converterTrimUnsafe.ConvertFromString(context, culture5, text[range.Start.GetOffset(length2)..range.End.GetOffset(length2)]);
			return new Rectangle(x, y, width, height);
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		ArgumentNullException.ThrowIfNull(destinationType, "destinationType");
		if (value is Rectangle rectangle)
		{
			if (destinationType == typeof(string))
			{
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				string listSeparator = culture.TextInfo.ListSeparator;
				TypeConverter converterTrimUnsafe = TypeDescriptor.GetConverterTrimUnsafe(typeof(int));
				string value2 = converterTrimUnsafe.ConvertToString(context, culture, rectangle.X);
				string value3 = converterTrimUnsafe.ConvertToString(context, culture, rectangle.Y);
				string value4 = converterTrimUnsafe.ConvertToString(context, culture, rectangle.Width);
				string value5 = converterTrimUnsafe.ConvertToString(context, culture, rectangle.Height);
				return $"{value2}{listSeparator} {value3}{listSeparator} {value4}{listSeparator} {value5}";
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				ConstructorInfo constructor = typeof(Rectangle).GetConstructor(new Type[4]
				{
					typeof(int),
					typeof(int),
					typeof(int),
					typeof(int)
				});
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, new object[4] { rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height });
				}
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
