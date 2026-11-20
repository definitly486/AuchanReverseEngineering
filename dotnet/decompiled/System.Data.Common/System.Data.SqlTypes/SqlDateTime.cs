using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.Data.SqlTypes;

[Serializable]
[XmlSchemaProvider("GetXsdType")]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public struct SqlDateTime : INullable, IComparable, IXmlSerializable, IEquatable<SqlDateTime>
{
	private bool m_fNotNull;

	private int m_day;

	private int m_time;

	public static readonly int SQLTicksPerSecond = 300;

	public static readonly int SQLTicksPerMinute = SQLTicksPerSecond * 60;

	public static readonly int SQLTicksPerHour = SQLTicksPerMinute * 60;

	private static readonly int s_SQLTicksPerDay = SQLTicksPerHour * 24;

	private static readonly DateTime s_SQLBaseDate = new DateTime(1900, 1, 1);

	private static readonly long s_SQLBaseDateTicks = s_SQLBaseDate.Ticks;

	private static readonly int s_maxTime = s_SQLTicksPerDay - 1;

	private static readonly TimeSpan s_minTimeSpan = new DateTime(1753, 1, 1).Subtract(s_SQLBaseDate);

	private static readonly TimeSpan s_maxTimeSpan = DateTime.MaxValue.Subtract(s_SQLBaseDate);

	private static readonly string[] s_dateTimeFormats = new string[8] { "MMM d yyyy hh:mm:ss:ffftt", "MMM d yyyy hh:mm:ss:fff", "d MMM yyyy hh:mm:ss:ffftt", "d MMM yyyy hh:mm:ss:fff", "hh:mm:ss:ffftt", "hh:mm:ss:fff", "yyMMdd", "yyyyMMdd" };

	public static readonly SqlDateTime MinValue = new SqlDateTime(-53690, 0);

	public static readonly SqlDateTime MaxValue = new SqlDateTime(2958463, s_maxTime);

	public static readonly SqlDateTime Null = new SqlDateTime(_: true);

	public bool IsNull => !m_fNotNull;

	public DateTime Value
	{
		get
		{
			if (m_fNotNull)
			{
				return ToDateTime(this);
			}
			throw new SqlNullValueException();
		}
	}

	public int DayTicks
	{
		get
		{
			if (m_fNotNull)
			{
				return m_day;
			}
			throw new SqlNullValueException();
		}
	}

	public int TimeTicks
	{
		get
		{
			if (m_fNotNull)
			{
				return m_time;
			}
			throw new SqlNullValueException();
		}
	}

	private SqlDateTime(bool _)
	{
		m_fNotNull = false;
		m_day = 0;
		m_time = 0;
	}

	public SqlDateTime(DateTime value)
	{
		this = FromDateTime(value);
	}

	public SqlDateTime(int dayTicks, int timeTicks)
	{
		if (dayTicks < -53690 || dayTicks > 2958463 || timeTicks < 0 || timeTicks > s_maxTime)
		{
			m_fNotNull = false;
			throw new OverflowException("SqlMisc_DateTimeOverflowMessage");
		}
		m_day = dayTicks;
		m_time = timeTicks;
		m_fNotNull = true;
	}

	private static TimeSpan ToTimeSpan(SqlDateTime value)
	{
		long num = (long)((double)value.m_time / 0.3 + 0.5);
		return new TimeSpan(value.m_day * 864000000000L + num * 10000);
	}

	private static DateTime ToDateTime(SqlDateTime value)
	{
		return s_SQLBaseDate.Add(ToTimeSpan(value));
	}

	private static SqlDateTime FromTimeSpan(TimeSpan value)
	{
		if (value < s_minTimeSpan || value > s_maxTimeSpan)
		{
			throw new SqlTypeException("SqlMisc_DateTimeOverflowMessage");
		}
		int num = value.Days;
		long num2 = value.Ticks - num * 864000000000L;
		if (num2 < 0)
		{
			num--;
			num2 += 864000000000L;
		}
		int num3 = (int)((double)num2 / 10000.0 * 0.3 + 0.5);
		if (num3 > s_maxTime)
		{
			num3 = 0;
			num++;
		}
		return new SqlDateTime(num, num3);
	}

	private static SqlDateTime FromDateTime(DateTime value)
	{
		if (value == DateTime.MaxValue)
		{
			return MaxValue;
		}
		return FromTimeSpan(value.Subtract(s_SQLBaseDate));
	}

	public static implicit operator SqlDateTime(DateTime value)
	{
		return new SqlDateTime(value);
	}

	public static explicit operator DateTime(SqlDateTime x)
	{
		return ToDateTime(x);
	}

	public override string ToString()
	{
		if (IsNull)
		{
			return "SqlMisc_NullString";
		}
		return ToDateTime(this).ToString((IFormatProvider?)null);
	}

	public static SqlDateTime Parse(string s)
	{
		if (s == "SqlMisc_NullString")
		{
			return Null;
		}
		DateTime value;
		try
		{
			value = DateTime.Parse(s, CultureInfo.InvariantCulture);
		}
		catch (FormatException)
		{
			DateTimeFormatInfo provider = (DateTimeFormatInfo)CultureInfo.CurrentCulture.GetFormat(typeof(DateTimeFormatInfo));
			value = DateTime.ParseExact(s, s_dateTimeFormats, provider, DateTimeStyles.AllowWhiteSpaces);
		}
		return new SqlDateTime(value);
	}

	public static SqlDateTime operator +(SqlDateTime x, TimeSpan t)
	{
		if (!x.IsNull)
		{
			return FromDateTime(ToDateTime(x) + t);
		}
		return Null;
	}

	public static SqlDateTime operator -(SqlDateTime x, TimeSpan t)
	{
		if (!x.IsNull)
		{
			return FromDateTime(ToDateTime(x) - t);
		}
		return Null;
	}

	public static explicit operator SqlDateTime(SqlString x)
	{
		if (!x.IsNull)
		{
			return Parse(x.Value);
		}
		return Null;
	}

	public static SqlBoolean operator ==(SqlDateTime x, SqlDateTime y)
	{
		if (!x.IsNull && !y.IsNull)
		{
			return new SqlBoolean(x.m_day == y.m_day && x.m_time == y.m_time);
		}
		return SqlBoolean.Null;
	}

	public static SqlBoolean operator !=(SqlDateTime x, SqlDateTime y)
	{
		return !(x == y);
	}

	public static SqlBoolean operator <(SqlDateTime x, SqlDateTime y)
	{
		if (!x.IsNull && !y.IsNull)
		{
			return new SqlBoolean(x.m_day < y.m_day || (x.m_day == y.m_day && x.m_time < y.m_time));
		}
		return SqlBoolean.Null;
	}

	public static SqlBoolean operator >(SqlDateTime x, SqlDateTime y)
	{
		if (!x.IsNull && !y.IsNull)
		{
			return new SqlBoolean(x.m_day > y.m_day || (x.m_day == y.m_day && x.m_time > y.m_time));
		}
		return SqlBoolean.Null;
	}

	public static SqlBoolean operator <=(SqlDateTime x, SqlDateTime y)
	{
		if (!x.IsNull && !y.IsNull)
		{
			return new SqlBoolean(x.m_day < y.m_day || (x.m_day == y.m_day && x.m_time <= y.m_time));
		}
		return SqlBoolean.Null;
	}

	public static SqlBoolean operator >=(SqlDateTime x, SqlDateTime y)
	{
		if (!x.IsNull && !y.IsNull)
		{
			return new SqlBoolean(x.m_day > y.m_day || (x.m_day == y.m_day && x.m_time >= y.m_time));
		}
		return SqlBoolean.Null;
	}

	public static SqlBoolean LessThan(SqlDateTime x, SqlDateTime y)
	{
		return x < y;
	}

	public static SqlBoolean GreaterThan(SqlDateTime x, SqlDateTime y)
	{
		return x > y;
	}

	public int CompareTo(object? value)
	{
		if (value is SqlDateTime value2)
		{
			return CompareTo(value2);
		}
		throw ADP.WrongType(value.GetType(), typeof(SqlDateTime));
	}

	public int CompareTo(SqlDateTime value)
	{
		if (IsNull)
		{
			if (!value.IsNull)
			{
				return -1;
			}
			return 0;
		}
		if (value.IsNull)
		{
			return 1;
		}
		if (this < value)
		{
			return -1;
		}
		if (this > value)
		{
			return 1;
		}
		return 0;
	}

	public override bool Equals([NotNullWhen(true)] object? value)
	{
		if (value is SqlDateTime other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(SqlDateTime other)
	{
		if (!other.IsNull && !IsNull)
		{
			return (this == other).Value;
		}
		if (other.IsNull)
		{
			return IsNull;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (!IsNull)
		{
			return Value.GetHashCode();
		}
		return 0;
	}

	XmlSchema IXmlSerializable.GetSchema()
	{
		return null;
	}

	void IXmlSerializable.ReadXml(XmlReader reader)
	{
		string attribute = reader.GetAttribute("nil", "http://www.w3.org/2001/XMLSchema-instance");
		if (attribute != null && XmlConvert.ToBoolean(attribute))
		{
			reader.ReadElementString();
			m_fNotNull = false;
			return;
		}
		DateTime value = XmlConvert.ToDateTime(reader.ReadElementString(), XmlDateTimeSerializationMode.RoundtripKind);
		if (value.Kind != DateTimeKind.Unspecified)
		{
			throw new SqlTypeException("SqlMisc_TimeZoneSpecifiedMessage");
		}
		SqlDateTime sqlDateTime = FromDateTime(value);
		m_day = sqlDateTime.DayTicks;
		m_time = sqlDateTime.TimeTicks;
		m_fNotNull = true;
	}

	void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		if (IsNull)
		{
			writer.WriteAttributeString("xsi", "nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
		else
		{
			writer.WriteString(XmlConvert.ToString(Value, "yyyy-MM-ddTHH:mm:ss.fff"));
		}
	}

	public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet)
	{
		return new XmlQualifiedName("dateTime", "http://www.w3.org/2001/XMLSchema");
	}
}
