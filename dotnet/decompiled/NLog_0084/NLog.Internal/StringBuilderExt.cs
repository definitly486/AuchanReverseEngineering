using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using NLog.MessageTemplates;

namespace NLog.Internal;

internal static class StringBuilderExt
{
	private static readonly char[] charToInt = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

	internal const int Iso8601_MaxDigitCount = 7;

	private static readonly string[] _zeroPaddedDigits = (from i in Enumerable.Range(0, 60)
		select i.ToString("D2")).ToArray();

	public static void AppendFormattedValue(this StringBuilder builder, object? value, string? format, IFormatProvider? formatProvider, IValueFormatter valueFormatter)
	{
		if (value is string value2 && string.IsNullOrEmpty(format))
		{
			builder.Append(value2);
		}
		else if ("@".Equals(format))
		{
			valueFormatter.FormatValue(value, null, CaptureType.Serialize, formatProvider, builder);
		}
		else if (value != null)
		{
			valueFormatter.FormatValue(value, format, CaptureType.Normal, formatProvider, builder);
		}
	}

	public static void AppendInvariant(this StringBuilder builder, int value)
	{
		builder.Append(value);
	}

	public static void AppendInvariant(this StringBuilder builder, uint value)
	{
		builder.Append(value);
	}

	private static int CalculateDigitCount(uint value)
	{
		int num = 0;
		uint num2 = value;
		do
		{
			num2 /= 10;
			num++;
		}
		while (num2 != 0);
		return num;
	}

	private static void ApppendValueWithDigitCount(StringBuilder builder, uint value, int digitCount)
	{
		builder.Append('0', digitCount);
		int num = builder.Length;
		while (digitCount > 0)
		{
			num--;
			builder[num] = charToInt[value % 10];
			value /= 10;
			digitCount--;
		}
	}

	public static void AppendXmlDateTimeUtcRoundTripFixed(this StringBuilder builder, DateTime dateTime)
	{
		int fraction = (int)(dateTime.Ticks % 10000000);
		builder.AppendXmlDateTimeUtcRoundTrip(dateTime, fraction, 7);
	}

	public static void AppendXmlDateTimeUtcRoundTrip(this StringBuilder builder, DateTime dateTime)
	{
		int num = 7;
		int num2 = (int)(dateTime.Ticks % 10000000);
		if (num2 > 0)
		{
			while (num2 % 10 == 0)
			{
				num--;
				num2 /= 10;
			}
		}
		builder.AppendXmlDateTimeUtcRoundTrip(dateTime, num2, num);
	}

	private static void AppendXmlDateTimeUtcRoundTrip(this StringBuilder builder, DateTime dateTime, int fraction, int max_digit_count)
	{
		dateTime = ((dateTime.Kind != DateTimeKind.Unspecified) ? dateTime.ToUniversalTime() : new DateTime(dateTime.Ticks, DateTimeKind.Utc));
		builder.Append4DigitsZeroPadded(dateTime.Year);
		builder.Append('-');
		builder.Append2DigitsZeroPadded(dateTime.Month);
		builder.Append('-');
		builder.Append2DigitsZeroPadded(dateTime.Day);
		builder.Append('T');
		builder.Append2DigitsZeroPadded(dateTime.Hour);
		builder.Append(':');
		builder.Append2DigitsZeroPadded(dateTime.Minute);
		builder.Append(':');
		builder.Append2DigitsZeroPadded(dateTime.Second);
		if (fraction > 0)
		{
			builder.Append('.');
			int num = CalculateDigitCount((uint)fraction);
			if (max_digit_count > num)
			{
				builder.Append('0', max_digit_count - num);
			}
			ApppendValueWithDigitCount(builder, (uint)fraction, num);
		}
		builder.Append('Z');
	}

	public static void ClearBuilder(this StringBuilder builder)
	{
		try
		{
			builder.Clear();
		}
		catch
		{
			if (builder.Length > 1)
			{
				builder.Remove(0, builder.Length - 1);
			}
			builder.Remove(0, builder.Length);
		}
	}

	public static void CopyToStream(this StringBuilder builder, MemoryStream ms, Encoding encoding, char[] transformBuffer)
	{
		int maxByteCount = encoding.GetMaxByteCount(builder.Length);
		long num = ms.Position;
		ms.SetLength(num + maxByteCount);
		for (int i = 0; i < builder.Length; i += transformBuffer.Length)
		{
			int num2 = Math.Min(builder.Length - i, transformBuffer.Length);
			builder.CopyTo(i, transformBuffer, 0, num2);
			maxByteCount = encoding.GetBytes(transformBuffer, 0, num2, ms.GetBuffer(), (int)num);
			num += maxByteCount;
		}
		ms.Position = num;
		if (num != ms.Length)
		{
			ms.SetLength(num);
		}
	}

	public static void CopyToBuffer(this StringBuilder builder, char[] destination, int destinationIndex)
	{
		builder.CopyTo(0, destination, destinationIndex, builder.Length);
	}

	public static void CopyTo(this StringBuilder builder, StringBuilder destination)
	{
		int length = builder.Length;
		if (length <= 0)
		{
			return;
		}
		destination.EnsureCapacity(length + destination.Length);
		if (length < 8)
		{
			for (int i = 0; i < length; i++)
			{
				destination.Append(builder[i]);
			}
			return;
		}
		if (length < 512)
		{
			destination.Append(builder.ToString());
			return;
		}
		char[] array = new char[256];
		for (int j = 0; j < length; j += array.Length)
		{
			int num = Math.Min(length - j, array.Length);
			builder.CopyTo(j, array, 0, num);
			destination.Append(array, 0, num);
		}
	}

	public static int IndexOf(this StringBuilder builder, char needle, int startPos = 0)
	{
		int length = builder.Length;
		for (int i = startPos; i < length; i++)
		{
			if (builder[i] == needle)
			{
				return i;
			}
		}
		return -1;
	}

	public static int IndexOfAny(this StringBuilder builder, char[] needles, int startPos = 0)
	{
		int length = builder.Length;
		for (int i = startPos; i < length; i++)
		{
			if (CharArrayContains(builder[i], needles))
			{
				return i;
			}
		}
		return -1;
	}

	private static bool CharArrayContains(char searchChar, char[] needles)
	{
		for (int i = 0; i < needles.Length; i++)
		{
			if (needles[i] == searchChar)
			{
				return true;
			}
		}
		return false;
	}

	public static bool EqualTo(this StringBuilder builder, StringBuilder other)
	{
		int length = builder.Length;
		if (length != other.Length)
		{
			return false;
		}
		for (int i = 0; i < length; i++)
		{
			if (builder[i] != other[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool EqualTo(this StringBuilder builder, string other)
	{
		if (builder.Length != other.Length)
		{
			return false;
		}
		int num = 0;
		foreach (char c in other)
		{
			if (builder[num++] != c)
			{
				return false;
			}
		}
		return true;
	}

	internal static void Append2DigitsZeroPadded(this StringBuilder builder, int number)
	{
		if (number < 0 || number >= _zeroPaddedDigits.Length)
		{
			builder.Append((char)(number / 10 + 48));
			builder.Append((char)(number % 10 + 48));
		}
		else
		{
			builder.Append(_zeroPaddedDigits[number]);
		}
	}

	internal static void Append4DigitsZeroPadded(this StringBuilder builder, int number)
	{
		if (number > 999 && number < 10000)
		{
			builder.Append(number);
			return;
		}
		builder.Append((char)(number / 1000 % 10 + 48));
		builder.Append((char)(number / 100 % 10 + 48));
		builder.Append((char)(number / 10 % 10 + 48));
		builder.Append((char)(number % 10 + 48));
	}

	internal static void AppendNumericInvariant(this StringBuilder sb, IConvertible value, TypeCode objTypeCode)
	{
		switch (objTypeCode)
		{
		case TypeCode.Byte:
			sb.AppendInvariant(value.ToByte(CultureInfo.InvariantCulture));
			break;
		case TypeCode.SByte:
			sb.AppendInvariant(value.ToSByte(CultureInfo.InvariantCulture));
			break;
		case TypeCode.Int16:
			sb.AppendInvariant(value.ToInt16(CultureInfo.InvariantCulture));
			break;
		case TypeCode.Int32:
			sb.AppendInvariant(value.ToInt32(CultureInfo.InvariantCulture));
			break;
		case TypeCode.Int64:
		{
			long value2 = value.ToInt64(CultureInfo.InvariantCulture);
			sb.Append(value2);
			break;
		}
		case TypeCode.UInt16:
			sb.AppendInvariant(value.ToUInt16(CultureInfo.InvariantCulture));
			break;
		case TypeCode.UInt32:
			sb.AppendInvariant(value.ToUInt32(CultureInfo.InvariantCulture));
			break;
		case TypeCode.UInt64:
		{
			ulong value3 = value.ToUInt64(CultureInfo.InvariantCulture);
			sb.Append(value3);
			break;
		}
		case TypeCode.Single:
		{
			float num2 = value.ToSingle(CultureInfo.InvariantCulture);
			if (!float.IsNaN(num2) && !float.IsInfinity(num2) && value is IFormattable formattable3)
			{
				AppendDecimalInvariant(sb, formattable3, "{0:R}");
			}
			else
			{
				AppendFloatInvariant(sb, num2);
			}
			break;
		}
		case TypeCode.Double:
		{
			double num = value.ToDouble(CultureInfo.InvariantCulture);
			if (!double.IsNaN(num) && !double.IsInfinity(num) && value is IFormattable formattable2)
			{
				AppendDecimalInvariant(sb, formattable2, "{0:R}");
			}
			else
			{
				AppendDoubleInvariant(sb, num);
			}
			break;
		}
		case TypeCode.Decimal:
			if (value is IFormattable formattable)
			{
				AppendDecimalInvariant(sb, formattable, "{0}");
			}
			else
			{
				AppendDecimalInvariant(sb, value.ToDecimal(CultureInfo.InvariantCulture));
			}
			break;
		default:
			sb.Append(XmlHelper.XmlConvertToString(value, objTypeCode));
			break;
		}
	}

	private static void AppendDecimalInvariant(StringBuilder sb, IFormattable formattable, string format)
	{
		int length = sb.Length;
		sb.AppendFormat(CultureInfo.InvariantCulture, format, formattable);
		for (int num = sb.Length - 1; num > length; num--)
		{
			if (!char.IsDigit(sb[num]))
			{
				return;
			}
		}
		sb.Append('.');
		sb.Append('0');
	}

	private static void AppendDecimalInvariant(StringBuilder sb, decimal decimalValue)
	{
		if (Math.Truncate(decimalValue) == decimalValue && decimalValue > -2147483648m && decimalValue < 2147483647m)
		{
			sb.AppendInvariant(Convert.ToInt32(decimalValue));
			sb.Append(".0");
		}
		else
		{
			sb.Append(XmlHelper.XmlConvertToString(decimalValue));
		}
	}

	private static void AppendDoubleInvariant(StringBuilder sb, double doubleValue)
	{
		if (double.IsNaN(doubleValue) || double.IsInfinity(doubleValue))
		{
			sb.Append(XmlHelper.XmlConvertToString(doubleValue));
		}
		else if (Math.Truncate(doubleValue) == doubleValue && doubleValue > -2147483648.0 && doubleValue < 2147483647.0)
		{
			sb.AppendInvariant(Convert.ToInt32(doubleValue));
			sb.Append(".0");
		}
		else
		{
			sb.Append(XmlHelper.XmlConvertToString(doubleValue));
		}
	}

	private static void AppendFloatInvariant(StringBuilder sb, float floatValue)
	{
		if (float.IsNaN(floatValue) || float.IsInfinity(floatValue))
		{
			sb.Append(XmlHelper.XmlConvertToString(floatValue));
		}
		else if (Math.Truncate(floatValue) == (double)floatValue && floatValue > -2.1474836E+09f && floatValue < 2.1474836E+09f)
		{
			sb.AppendInvariant(Convert.ToInt32(floatValue));
			sb.Append(".0");
		}
		else
		{
			sb.Append(XmlHelper.XmlConvertToString(floatValue));
		}
	}

	public static void TrimRight(this StringBuilder sb, int startPos = 0)
	{
		int num = sb.Length - 1;
		while (num >= startPos && char.IsWhiteSpace(sb[num]))
		{
			num--;
		}
		if (num < sb.Length - 1)
		{
			sb.Length = num + 1;
		}
	}
}
