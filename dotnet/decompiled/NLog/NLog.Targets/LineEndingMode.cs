using System;
using System.ComponentModel;
using System.Globalization;
using NLog.Internal;

namespace NLog.Targets;

[TypeConverter(typeof(LineEndingModeConverter))]
public sealed class LineEndingMode : IEquatable<LineEndingMode>
{
	public class LineEndingModeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (!(sourceType == typeof(string)))
			{
				return base.CanConvertFrom(context, sourceType);
			}
			return true;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (!(value is string name))
			{
				return base.ConvertFrom(context, culture, value);
			}
			return FromString(name);
		}
	}

	public static readonly LineEndingMode Default = new LineEndingMode("Default", "\n");

	public static readonly LineEndingMode CRLF = new LineEndingMode("CRLF", "\r\n");

	public static readonly LineEndingMode CR = new LineEndingMode("CR", "\r");

	public static readonly LineEndingMode LF = new LineEndingMode("LF", "\n");

	public static readonly LineEndingMode Null = new LineEndingMode("Null", "\0");

	public static readonly LineEndingMode None = new LineEndingMode("None", string.Empty);

	private readonly string _name;

	private readonly string _newLineCharacters;

	public string Name => _name;

	public string NewLineCharacters => _newLineCharacters;

	private LineEndingMode()
	{
		_name = string.Empty;
		_newLineCharacters = string.Empty;
	}

	private LineEndingMode(string name, string newLineCharacters)
	{
		_name = name;
		_newLineCharacters = newLineCharacters;
	}

	public static LineEndingMode FromString(string name)
	{
		Guard.ThrowIfNull(name, "name");
		if (name.Equals(CRLF.Name, StringComparison.OrdinalIgnoreCase))
		{
			return CRLF;
		}
		if (name.Equals(LF.Name, StringComparison.OrdinalIgnoreCase))
		{
			return LF;
		}
		if (name.Equals(CR.Name, StringComparison.OrdinalIgnoreCase))
		{
			return CR;
		}
		if (name.Equals(Default.Name, StringComparison.OrdinalIgnoreCase))
		{
			return Default;
		}
		if (name.Equals(Null.Name, StringComparison.OrdinalIgnoreCase))
		{
			return Null;
		}
		if (name.Equals(None.Name, StringComparison.OrdinalIgnoreCase))
		{
			return None;
		}
		throw new ArgumentOutOfRangeException("name", name, "LineEndingMode is out of range");
	}

	public static bool operator ==(LineEndingMode mode1, LineEndingMode mode2)
	{
		if ((object)mode1 == null)
		{
			return (object)mode2 == null;
		}
		if ((object)mode2 == null)
		{
			return false;
		}
		return mode1.NewLineCharacters == mode2.NewLineCharacters;
	}

	public static bool operator !=(LineEndingMode mode1, LineEndingMode mode2)
	{
		if ((object)mode1 == null)
		{
			return (object)mode2 != null;
		}
		if ((object)mode2 == null)
		{
			return true;
		}
		return mode1.NewLineCharacters != mode2.NewLineCharacters;
	}

	public override string ToString()
	{
		return Name;
	}

	public override int GetHashCode()
	{
		return _newLineCharacters?.GetHashCode() ?? 0;
	}

	public override bool Equals(object obj)
	{
		if (obj is LineEndingMode other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(LineEndingMode other)
	{
		if ((object)this != other)
		{
			return string.Equals(_newLineCharacters, other?._newLineCharacters, StringComparison.Ordinal);
		}
		return true;
	}
}
