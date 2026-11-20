using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using NLog.Internal;

namespace NLog.Targets;

public class DefaultJsonSerializer : IJsonConverter
{
	private readonly ObjectReflectionCache _objectReflectionCache;

	private readonly MruCache<Enum, string> _enumCache = new MruCache<Enum, string>(2000);

	private const int MaxJsonLength = 524288;

	private static readonly IEqualityComparer<object> _referenceEqualsComparer = SingleItemOptimizedHashSet<object>.ReferenceEqualityComparer.Default;

	private static JsonSerializeOptions DefaultSerializerOptions = new JsonSerializeOptions();

	private static JsonSerializeOptions DefaultExceptionSerializerOptions = new JsonSerializeOptions
	{
		SanitizeDictionaryKeys = true
	};

	private static DefaultJsonSerializer? _instance;

	[Obsolete("Instead use ResolveService<IJsonConverter>() in Layout / Target. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static DefaultJsonSerializer Instance => _instance ?? (_instance = new DefaultJsonSerializer(LogManager.LogFactory.ServiceRepository));

	internal DefaultJsonSerializer(IServiceProvider serviceProvider)
	{
		_objectReflectionCache = new ObjectReflectionCache(serviceProvider);
	}

	public string SerializeObject(object value)
	{
		return SerializeObject(value, DefaultSerializerOptions);
	}

	public string SerializeObject(object value, JsonSerializeOptions options)
	{
		if (value == null)
		{
			return "null";
		}
		if (value is string text)
		{
			bool escapeUnicode = options.EscapeUnicode;
			string text2 = text;
			for (int i = 0; i < text2.Length; i++)
			{
				if (RequiresJsonEscape(text2[i], escapeUnicode))
				{
					StringBuilder stringBuilder = new StringBuilder(text.Length + 4);
					stringBuilder.Append('"');
					AppendStringEscape(stringBuilder, text, options);
					stringBuilder.Append('"');
					return stringBuilder.ToString();
				}
			}
			return QuoteValue(text);
		}
		if (value is IConvertible convertible)
		{
			TypeCode typeCode = convertible.GetTypeCode();
			if (typeCode != TypeCode.Object)
			{
				if (!options.EnumAsInteger && IsNumericTypeCode(typeCode, includeDecimals: false) && convertible is Enum value2)
				{
					return QuoteValue(EnumAsString(value2));
				}
				string text3 = XmlHelper.XmlConvertToString(convertible, typeCode);
				if (SkipQuotes(convertible, typeCode))
				{
					return text3;
				}
				return QuoteValue(text3);
			}
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		if (!SerializeObject(value, stringBuilder2, options))
		{
			return string.Empty;
		}
		return stringBuilder2.ToString();
	}

	public bool SerializeObject(object? value, StringBuilder destination)
	{
		return SerializeObject(value, destination, DefaultSerializerOptions);
	}

	public bool SerializeObject(object? value, StringBuilder destination, JsonSerializeOptions options)
	{
		return SerializeObject(value, destination, options, default(SingleItemOptimizedHashSet<object>), 0);
	}

	private bool SerializeObject(object? value, StringBuilder destination, JsonSerializeOptions options, SingleItemOptimizedHashSet<object> objectsInPath, int depth)
	{
		int length = destination.Length;
		try
		{
			if (SerializeSimpleObjectValue(value, destination, options))
			{
				return true;
			}
			return SerializeObjectWithReflection(value, destination, options, ref objectsInPath, depth);
		}
		catch
		{
			destination.Length = length;
			return false;
		}
	}

	private bool SerializeObjectWithReflection(object? value, StringBuilder destination, JsonSerializeOptions options, ref SingleItemOptimizedHashSet<object> objectsInPath, int depth)
	{
		if (destination.Length > 524288)
		{
			return false;
		}
		if (value == null || objectsInPath.Contains(value))
		{
			return false;
		}
		if (value is IDictionary dictionary)
		{
			using (StartCollectionScope(ref objectsInPath, dictionary))
			{
				SerializeDictionaryObject(dictionary, destination, options, objectsInPath, depth);
				return true;
			}
		}
		if (value is IEnumerable value2)
		{
			if (_objectReflectionCache.TryLookupExpandoObject(value, out var objectPropertyList))
			{
				return SerializeObjectPropertyList(value, ref objectPropertyList, destination, options, ref objectsInPath, depth);
			}
			using (StartCollectionScope(ref objectsInPath, value))
			{
				SerializeCollectionObject(value2, destination, options, objectsInPath, depth);
				return true;
			}
		}
		ObjectReflectionCache.ObjectPropertyList objectPropertyList2 = _objectReflectionCache.LookupObjectProperties(value);
		return SerializeObjectPropertyList(value, ref objectPropertyList2, destination, options, ref objectsInPath, depth);
	}

	private bool SerializeSimpleObjectValue(object? value, StringBuilder destination, JsonSerializeOptions options, bool forceToString = false)
	{
		if (value is IConvertible convertible)
		{
			TypeCode typeCode = convertible.GetTypeCode();
			if (typeCode != TypeCode.Object)
			{
				SerializeSimpleTypeCodeValue(convertible, typeCode, destination, options, forceToString);
				return true;
			}
		}
		if (value is IFormattable arg)
		{
			if (value is DateTimeOffset dateTimeOffset)
			{
				QuoteValue(destination, dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss zzz", CultureInfo.InvariantCulture));
				return true;
			}
			destination.Append('"');
			int length = destination.Length;
			destination.AppendFormat(CultureInfo.InvariantCulture, "{0}", arg);
			PerformJsonEscapeWhenNeeded(destination, length, options.EscapeUnicode);
			destination.Append('"');
			return true;
		}
		if (value == null)
		{
			SerializeSimpleTypeCodeValue(null, TypeCode.Empty, destination, options, forceToString);
			return true;
		}
		return false;
	}

	private static SingleItemOptimizedHashSet<object>.SingleItemScopedInsert StartCollectionScope(ref SingleItemOptimizedHashSet<object> objectsInPath, object value)
	{
		return new SingleItemOptimizedHashSet<object>.SingleItemScopedInsert(value, ref objectsInPath, forceHashSet: true, _referenceEqualsComparer);
	}

	private void SerializeDictionaryObject(IDictionary dictionary, StringBuilder destination, JsonSerializeOptions options, SingleItemOptimizedHashSet<object> objectsInPath, int depth)
	{
		bool flag = true;
		int num = ((objectsInPath.Count <= 1) ? depth : (depth + 1));
		if (num > options.MaxRecursionLimit)
		{
			destination.Append("{}");
			return;
		}
		destination.Append('{');
		foreach (DictionaryEntry item in new DictionaryEntryEnumerable(dictionary))
		{
			int length = destination.Length;
			if (length > 524288)
			{
				break;
			}
			if (!flag)
			{
				destination.Append(',');
			}
			object key = item.Key;
			if (!SerializeObjectAsString(key, destination, options))
			{
				destination.Length = length;
				continue;
			}
			if (options.SanitizeDictionaryKeys)
			{
				int num2 = destination.Length - 1;
				int num3 = length + ((!flag) ? 1 : 0) + 1;
				if (!SanitizeDictionaryKey(destination, num3, num2 - num3))
				{
					destination.Length = length;
					continue;
				}
			}
			destination.Append(':');
			object value = item.Value;
			if (!SerializeObject(value, destination, options, objectsInPath, num))
			{
				destination.Length = length;
			}
			else
			{
				flag = false;
			}
		}
		destination.Append('}');
	}

	private static bool SanitizeDictionaryKey(StringBuilder destination, int keyStartIndex, int keyLength)
	{
		if (keyLength == 0)
		{
			return false;
		}
		int num = keyStartIndex + keyLength;
		for (int i = keyStartIndex; i < num; i++)
		{
			char c = destination[i];
			if (c != '_' && !char.IsLetterOrDigit(c))
			{
				destination[i] = '_';
			}
		}
		return true;
	}

	private void SerializeCollectionObject(IEnumerable value, StringBuilder destination, JsonSerializeOptions options, SingleItemOptimizedHashSet<object> objectsInPath, int depth)
	{
		bool flag = true;
		int num = ((objectsInPath.Count <= 1) ? depth : (depth + 1));
		if (num > options.MaxRecursionLimit)
		{
			destination.Append("[]");
			return;
		}
		destination.Append('[');
		foreach (object item in value)
		{
			int length = destination.Length;
			if (length > 524288)
			{
				break;
			}
			if (!flag)
			{
				destination.Append(',');
			}
			if (!SerializeObject(item, destination, options, objectsInPath, num))
			{
				destination.Length = length;
			}
			else
			{
				flag = false;
			}
		}
		destination.Append(']');
	}

	private bool SerializeObjectPropertyList(object value, ref ObjectReflectionCache.ObjectPropertyList objectPropertyList, StringBuilder destination, JsonSerializeOptions options, ref SingleItemOptimizedHashSet<object> objectsInPath, int depth)
	{
		if (objectPropertyList.IsSimpleValue)
		{
			value = objectPropertyList.ObjectValue;
			if (SerializeSimpleObjectValue(value, destination, options))
			{
				return true;
			}
		}
		else if (depth < options.MaxRecursionLimit)
		{
			if (options == DefaultSerializerOptions && value is Exception)
			{
				options = DefaultExceptionSerializerOptions;
			}
			using (new SingleItemOptimizedHashSet<object>.SingleItemScopedInsert(value, ref objectsInPath, forceHashSet: false, _referenceEqualsComparer))
			{
				return SerializeObjectProperties(objectPropertyList, destination, options, objectsInPath, depth);
			}
		}
		return SerializeObjectAsString(value, destination, options);
	}

	private void SerializeSimpleTypeCodeValue(IConvertible? value, TypeCode objTypeCode, StringBuilder destination, JsonSerializeOptions options, bool forceToString = false)
	{
		if (objTypeCode == TypeCode.Empty || value == null)
		{
			destination.Append(forceToString ? "\"\"" : "null");
		}
		else if (objTypeCode == TypeCode.String || objTypeCode == TypeCode.Char)
		{
			destination.Append('"');
			AppendStringEscape(destination, value.ToString(), options);
			destination.Append('"');
		}
		else
		{
			SerializeSimpleTypeCodeValueNoEscape(value, objTypeCode, destination, options, forceToString);
		}
	}

	private void SerializeSimpleTypeCodeValueNoEscape(IConvertible value, TypeCode objTypeCode, StringBuilder destination, JsonSerializeOptions options, bool forceToString)
	{
		if (IsNumericTypeCode(objTypeCode, includeDecimals: false))
		{
			if (!options.EnumAsInteger && value is Enum value2)
			{
				QuoteValue(destination, EnumAsString(value2));
			}
			else
			{
				SerializeNumericValue(value, objTypeCode, destination, forceToString);
			}
			return;
		}
		if (objTypeCode == TypeCode.DateTime)
		{
			destination.Append('"');
			destination.AppendXmlDateTimeUtcRoundTrip(value.ToDateTime(CultureInfo.InvariantCulture));
			destination.Append('"');
			return;
		}
		if (IsNumericTypeCode(objTypeCode, includeDecimals: true) && SkipQuotes(value, objTypeCode))
		{
			SerializeNumericValue(value, objTypeCode, destination, forceToString);
			return;
		}
		string value3 = XmlHelper.XmlConvertToString(value, objTypeCode);
		if (!forceToString && !string.IsNullOrEmpty(value3) && SkipQuotes(value, objTypeCode))
		{
			destination.Append(value3);
		}
		else
		{
			QuoteValue(destination, value3);
		}
	}

	private static void SerializeNumericValue(IConvertible value, TypeCode objTypeCode, StringBuilder destination, bool forceToString)
	{
		if (forceToString)
		{
			destination.Append('"');
		}
		destination.AppendNumericInvariant(value, objTypeCode);
		if (forceToString)
		{
			destination.Append('"');
		}
	}

	private static string QuoteValue(string value)
	{
		return "\"" + value + "\"";
	}

	private static void QuoteValue(StringBuilder destination, string value)
	{
		destination.Append('"');
		destination.Append(value);
		destination.Append('"');
	}

	private string EnumAsString(Enum value)
	{
		if (!_enumCache.TryGetValue(value, out string value2))
		{
			value2 = Convert.ToString(value, CultureInfo.InvariantCulture);
			_enumCache.TryAddValue(value, value2);
		}
		return value2 ?? string.Empty;
	}

	private static bool SkipQuotes(IConvertible value, TypeCode objTypeCode)
	{
		switch (objTypeCode)
		{
		case TypeCode.String:
			return false;
		case TypeCode.Char:
			return false;
		case TypeCode.DateTime:
			return false;
		case TypeCode.Empty:
			return true;
		case TypeCode.Boolean:
			return true;
		case TypeCode.Decimal:
			return true;
		case TypeCode.Double:
		{
			double d = value.ToDouble(CultureInfo.InvariantCulture);
			if (!double.IsNaN(d))
			{
				return !double.IsInfinity(d);
			}
			return false;
		}
		case TypeCode.Single:
		{
			float f = value.ToSingle(CultureInfo.InvariantCulture);
			if (!float.IsNaN(f))
			{
				return !float.IsInfinity(f);
			}
			return false;
		}
		default:
			return IsNumericTypeCode(objTypeCode, includeDecimals: false);
		}
	}

	private static bool IsNumericTypeCode(TypeCode objTypeCode, bool includeDecimals)
	{
		switch (objTypeCode)
		{
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Int64:
		case TypeCode.UInt64:
			return true;
		case TypeCode.Single:
		case TypeCode.Double:
		case TypeCode.Decimal:
			return includeDecimals;
		default:
			return false;
		}
	}

	private static void AppendStringEscape(StringBuilder destination, string text, JsonSerializeOptions options)
	{
		AppendStringEscape(destination, text, options.EscapeUnicode);
	}

	internal static void AppendStringEscape(StringBuilder destination, string text, bool escapeUnicode)
	{
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < text.Length; i++)
		{
			if (RequiresJsonEscape(text[i], escapeUnicode))
			{
				AppendStringEscape(destination, text, escapeUnicode, num);
				return;
			}
			num++;
		}
		destination.Append(text);
	}

	private static void AppendStringEscape(StringBuilder destination, string text, bool escapeUnicode, int startIndex)
	{
		destination.Append(text, 0, startIndex);
		for (int i = startIndex; i < text.Length; i++)
		{
			char c = text[i];
			if (!RequiresJsonEscape(c, escapeUnicode))
			{
				destination.Append(c);
				continue;
			}
			switch (c)
			{
			case '"':
				destination.Append("\\\"");
				break;
			case '\\':
				destination.Append("\\\\");
				break;
			case '\b':
				destination.Append("\\b");
				break;
			case '\r':
				destination.Append("\\r");
				break;
			case '\n':
				destination.Append("\\n");
				break;
			case '\f':
				destination.Append("\\f");
				break;
			case '\t':
				destination.Append("\\t");
				break;
			default:
				destination.AppendFormat(CultureInfo.InvariantCulture, "\\u{0:x4}", (int)c);
				break;
			}
		}
	}

	internal static void PerformJsonEscapeWhenNeeded(StringBuilder builder, int startPos, bool escapeUnicode)
	{
		int length = builder.Length;
		for (int i = startPos; i < length; i++)
		{
			if (RequiresJsonEscape(builder[i], escapeUnicode))
			{
				string text = builder.ToString(startPos, builder.Length - startPos);
				builder.Length = startPos;
				AppendStringEscape(builder, text, escapeUnicode);
				break;
			}
		}
	}

	internal static bool RequiresJsonEscape(char ch, bool escapeUnicode)
	{
		if (ch < ' ')
		{
			return true;
		}
		if (ch > '\u007f')
		{
			return escapeUnicode;
		}
		if (ch != '"')
		{
			return ch == '\\';
		}
		return true;
	}

	private bool SerializeObjectProperties(ObjectReflectionCache.ObjectPropertyList objectPropertyList, StringBuilder destination, JsonSerializeOptions options, SingleItemOptimizedHashSet<object> objectsInPath, int depth)
	{
		destination.Append('{');
		string text = null;
		foreach (ObjectReflectionCache.ObjectPropertyList.PropertyValue item in objectPropertyList)
		{
			int length = destination.Length;
			try
			{
				if (item.HasNameAndValue)
				{
					destination.Append(text);
					QuoteValue(destination, item.Name);
					destination.Append(':');
					TypeCode typeCode = item.TypeCode;
					if (typeCode != TypeCode.Object)
					{
						SerializeSimpleTypeCodeValue((IConvertible)item.Value, typeCode, destination, options);
						goto IL_0097;
					}
					if (SerializeObject(item.Value, destination, options, objectsInPath, depth + 1))
					{
						goto IL_0097;
					}
					destination.Length = length;
				}
				goto end_IL_0027;
				IL_0097:
				if (text == null)
				{
					text = (options.SuppressSpaces ? "," : ", ");
				}
				end_IL_0027:;
			}
			catch
			{
				destination.Length = length;
			}
		}
		destination.Append('}');
		return true;
	}

	private bool SerializeObjectAsString(object value, StringBuilder destination, JsonSerializeOptions options)
	{
		int length = destination.Length;
		try
		{
			if (SerializeSimpleObjectValue(value, destination, options, forceToString: true))
			{
				return true;
			}
			string text = Convert.ToString(value, CultureInfo.InvariantCulture);
			destination.Append('"');
			AppendStringEscape(destination, text, options);
			destination.Append('"');
			return true;
		}
		catch
		{
			destination.Length = length;
			return false;
		}
	}
}
