using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Refit;

internal class FormValueMultimap : IEnumerable<KeyValuePair<string?, string?>>, IEnumerable
{
	private static readonly Dictionary<Type, PropertyInfo[]> PropertyCache = new Dictionary<Type, PropertyInfo[]>();

	private readonly IList<KeyValuePair<string?, string?>> formEntries = new List<KeyValuePair<string, string>>();

	private readonly IHttpContentSerializer contentSerializer;

	public IEnumerable<string?> Keys => this.Select<KeyValuePair<string, string>, string>((KeyValuePair<string, string> it) => it.Key);

	public FormValueMultimap(object source, RefitSettings settings)
	{
		if (settings == null)
		{
			throw new ArgumentNullException("settings");
		}
		contentSerializer = settings.ContentSerializer;
		if (source == null)
		{
			return;
		}
		if (source is IDictionary dictionary)
		{
			{
				foreach (object key in dictionary.Keys)
				{
					object obj = dictionary[key];
					if (obj != null)
					{
						Add(key.ToString(), settings.FormUrlEncodedParameterFormatter.Format(obj, null));
					}
				}
				return;
			}
		}
		Type type = source.GetType();
		lock (PropertyCache)
		{
			if (!PropertyCache.TryGetValue(type, out PropertyInfo[] value))
			{
				value = GetProperties(type);
				PropertyCache[type] = value;
			}
			PropertyInfo[] array = value;
			foreach (PropertyInfo propertyInfo in array)
			{
				object value2 = propertyInfo.GetValue(source, null);
				if (value2 == null)
				{
					continue;
				}
				string fieldNameForProperty = GetFieldNameForProperty(propertyInfo);
				QueryAttribute attrib = propertyInfo.GetCustomAttribute<QueryAttribute>(inherit: true);
				if (!(value2 is IEnumerable enumerable) || value2 is string)
				{
					Add(fieldNameForProperty, settings.FormUrlEncodedParameterFormatter.Format(value2, attrib?.Format));
					continue;
				}
				string text;
				string separator;
				IEnumerable<string> values;
				switch ((attrib != null && attrib.IsCollectionFormatSpecified) ? attrib.CollectionFormat : settings.CollectionFormat)
				{
				case CollectionFormat.Multi:
					foreach (object item in enumerable)
					{
						Add(fieldNameForProperty, settings.FormUrlEncodedParameterFormatter.Format(item, attrib?.Format));
					}
					break;
				case CollectionFormat.Csv:
					text = ",";
					goto IL_0272;
				case CollectionFormat.Ssv:
					text = " ";
					goto IL_0272;
				case CollectionFormat.Tsv:
					text = "\t";
					goto IL_0272;
				case CollectionFormat.Pipes:
					text = "|";
					goto IL_0272;
				default:
					{
						Add(fieldNameForProperty, settings.FormUrlEncodedParameterFormatter.Format(value2, attrib?.Format));
						break;
					}
					IL_0272:
					separator = text;
					values = from object v in enumerable
						select settings.FormUrlEncodedParameterFormatter.Format(v, attrib?.Format);
					Add(fieldNameForProperty, string.Join(separator, values));
					break;
				}
			}
		}
	}

	private void Add(string? key, string? value)
	{
		formEntries.Add(new KeyValuePair<string, string>(key, value));
	}

	private string GetFieldNameForProperty(PropertyInfo propertyInfo)
	{
		string name = (from a in propertyInfo.GetCustomAttributes<AliasAsAttribute>(inherit: true)
			select a.Name).FirstOrDefault() ?? contentSerializer.GetFieldNameForProperty(propertyInfo) ?? propertyInfo.Name;
		return (from attr in propertyInfo.GetCustomAttributes<QueryAttribute>(inherit: true)
			select string.IsNullOrWhiteSpace(attr.Prefix) ? name : (attr.Prefix + attr.Delimiter + name)).FirstOrDefault() ?? name;
	}

	private static PropertyInfo[] GetProperties(Type type)
	{
		return (from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
			where p.CanRead && (p.GetMethod?.IsPublic ?? false)
			select p).ToArray();
	}

	public IEnumerator<KeyValuePair<string?, string?>> GetEnumerator()
	{
		return formEntries.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
