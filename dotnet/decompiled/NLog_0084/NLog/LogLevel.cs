using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using NLog.Attributes;
using NLog.Internal;

namespace NLog;

[TypeConverter(typeof(LogLevelTypeConverter))]
public sealed class LogLevel : IComparable<LogLevel>, IComparable, IEquatable<LogLevel>, IFormattable
{
	public static readonly LogLevel Trace = new LogLevel("Trace", 0);

	public static readonly LogLevel Debug = new LogLevel("Debug", 1);

	public static readonly LogLevel Info = new LogLevel("Info", 2);

	public static readonly LogLevel Warn = new LogLevel("Warn", 3);

	public static readonly LogLevel Error = new LogLevel("Error", 4);

	public static readonly LogLevel Fatal = new LogLevel("Fatal", 5);

	public static readonly LogLevel Off = new LogLevel("Off", 6);

	private static readonly IList<LogLevel> allLevels = new List<LogLevel> { Trace, Debug, Info, Warn, Error, Fatal, Off }.AsReadOnly();

	private static readonly IList<LogLevel> allLoggingLevels = new List<LogLevel> { Trace, Debug, Info, Warn, Error, Fatal }.AsReadOnly();

	private readonly int _ordinal;

	private readonly string _name;

	public static IEnumerable<LogLevel> AllLevels => allLevels;

	public static IEnumerable<LogLevel> AllLoggingLevels => allLoggingLevels;

	internal static LogLevel MaxLevel => Fatal;

	internal static LogLevel MinLevel => Trace;

	public string Name => _name;

	public int Ordinal => _ordinal;

	private LogLevel(string name, int ordinal)
	{
		_name = name;
		_ordinal = ordinal;
	}

	public static bool operator ==(LogLevel? level1, LogLevel? level2)
	{
		if ((object)level1 == level2)
		{
			return true;
		}
		return (level1 ?? Off).Equals(level2);
	}

	public static bool operator !=(LogLevel? level1, LogLevel? level2)
	{
		if ((object)level1 == level2)
		{
			return false;
		}
		return !(level1 ?? Off).Equals(level2);
	}

	public static bool operator >(LogLevel? level1, LogLevel? level2)
	{
		if ((object)level1 == level2)
		{
			return false;
		}
		return (level1 ?? Off).CompareTo(level2) > 0;
	}

	public static bool operator >=(LogLevel? level1, LogLevel? level2)
	{
		if ((object)level1 == level2)
		{
			return true;
		}
		return (level1 ?? Off).CompareTo(level2) >= 0;
	}

	public static bool operator <(LogLevel? level1, LogLevel? level2)
	{
		if ((object)level1 == level2)
		{
			return false;
		}
		return (level1 ?? Off).CompareTo(level2) < 0;
	}

	public static bool operator <=(LogLevel? level1, LogLevel? level2)
	{
		if ((object)level1 == level2)
		{
			return true;
		}
		return (level1 ?? Off).CompareTo(level2) <= 0;
	}

	public static LogLevel FromOrdinal(int ordinal)
	{
		return ordinal switch
		{
			0 => Trace, 
			1 => Debug, 
			2 => Info, 
			3 => Warn, 
			4 => Error, 
			5 => Fatal, 
			6 => Off, 
			_ => throw new ArgumentException("Unknown loglevel: " + ordinal + ".", "ordinal"), 
		};
	}

	public static LogLevel FromString(string levelName)
	{
		Guard.ThrowIfNull(levelName, "levelName");
		if (levelName.Equals("Trace", StringComparison.OrdinalIgnoreCase))
		{
			return Trace;
		}
		if (levelName.Equals("Debug", StringComparison.OrdinalIgnoreCase))
		{
			return Debug;
		}
		if (levelName.Equals("Info", StringComparison.OrdinalIgnoreCase))
		{
			return Info;
		}
		if (levelName.Equals("Warn", StringComparison.OrdinalIgnoreCase))
		{
			return Warn;
		}
		if (levelName.Equals("Error", StringComparison.OrdinalIgnoreCase))
		{
			return Error;
		}
		if (levelName.Equals("Fatal", StringComparison.OrdinalIgnoreCase))
		{
			return Fatal;
		}
		if (levelName.Equals("Off", StringComparison.OrdinalIgnoreCase))
		{
			return Off;
		}
		if (levelName.Equals("None", StringComparison.OrdinalIgnoreCase))
		{
			return Off;
		}
		if (levelName.Equals("Information", StringComparison.OrdinalIgnoreCase))
		{
			return Info;
		}
		if (levelName.Equals("Warning", StringComparison.OrdinalIgnoreCase))
		{
			return Warn;
		}
		throw new ArgumentException("Unknown log level: " + levelName, "levelName");
	}

	public override string ToString()
	{
		return _name;
	}

	string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
	{
		if (format == null || !"D".Equals(format, StringComparison.OrdinalIgnoreCase))
		{
			return _name;
		}
		return _ordinal.ToString(CultureInfo.InvariantCulture);
	}

	public override int GetHashCode()
	{
		return _ordinal;
	}

	public override bool Equals(object? obj)
	{
		return Equals(obj as LogLevel);
	}

	public bool Equals(LogLevel? other)
	{
		return _ordinal == other?._ordinal;
	}

	public int CompareTo(object? obj)
	{
		return CompareTo(obj as LogLevel);
	}

	public int CompareTo(LogLevel? other)
	{
		return _ordinal - (other ?? Off)._ordinal;
	}
}
