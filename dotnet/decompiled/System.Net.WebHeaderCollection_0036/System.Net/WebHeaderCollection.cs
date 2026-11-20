using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace System.Net;

[DefaultMember("Item")]
public class WebHeaderCollection : NameValueCollection, ISerializable
{
	private NameValueCollection _innerCollection;

	[CompilerGenerated]
	private static HeaderInfoTable _003CHeaderInfo_003Ek__BackingField;

	private static HeaderInfoTable HeaderInfo => _003CHeaderInfo_003Ek__BackingField ?? (_003CHeaderInfo_003Ek__BackingField = new HeaderInfoTable());

	private NameValueCollection InnerCollection => _innerCollection ?? (_innerCollection = new NameValueCollection(16, StringComparer.OrdinalIgnoreCase));

	public override int Count
	{
		get
		{
			if (_innerCollection != null)
			{
				return _innerCollection.Count;
			}
			return 0;
		}
	}

	public override KeysCollection Keys => InnerCollection.Keys;

	public override string[] AllKeys => InnerCollection.AllKeys;

	public override void Set(string name, string? value)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name");
		}
		name = HttpValidationHelpers.CheckBadHeaderNameChars(name);
		value = HttpValidationHelpers.CheckBadHeaderValueChars(value);
		InvalidateCachedArrays();
		InnerCollection.Set(name, value);
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException();
	}

	public override void OnDeserialization(object? sender)
	{
	}

	public override string[]? GetValues(string header)
	{
		HeaderInfo headerInfo = HeaderInfo[header];
		string[] values = InnerCollection.GetValues(header);
		if (headerInfo == null || values == null || !headerInfo.AllowMultiValues)
		{
			return values;
		}
		List<string> list = null;
		for (int i = 0; i < values.Length; i++)
		{
			string[] array = headerInfo.Parser(values[i]);
			if (list == null)
			{
				if (array != null)
				{
					list = new List<string>(values);
					list.RemoveRange(i, values.Length - i);
					list.AddRange(array);
				}
			}
			else
			{
				list.AddRange(array);
			}
		}
		if (list != null)
		{
			return list.ToArray();
		}
		return values;
	}

	public override string? Get(string? name)
	{
		if (_innerCollection == null)
		{
			return null;
		}
		return _innerCollection.Get(name);
	}

	public override void Add(string name, string? value)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		name = HttpValidationHelpers.CheckBadHeaderNameChars(name);
		value = HttpValidationHelpers.CheckBadHeaderValueChars(value);
		InvalidateCachedArrays();
		InnerCollection.Add(name, value);
	}

	public override void Remove(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name");
		}
		name = HttpValidationHelpers.CheckBadHeaderNameChars(name);
		if (_innerCollection != null)
		{
			InvalidateCachedArrays();
			_innerCollection.Remove(name);
		}
	}

	public override string ToString()
	{
		if (Count == 0)
		{
			return "\r\n";
		}
		StringBuilder stringBuilder = new StringBuilder(30 * Count);
		foreach (string item in InnerCollection)
		{
			string value = InnerCollection.Get(item);
			stringBuilder.Append(item).Append(": ").Append(value)
				.Append("\r\n");
		}
		stringBuilder.Append("\r\n");
		return stringBuilder.ToString();
	}

	public override IEnumerator GetEnumerator()
	{
		return InnerCollection.Keys.GetEnumerator();
	}
}
