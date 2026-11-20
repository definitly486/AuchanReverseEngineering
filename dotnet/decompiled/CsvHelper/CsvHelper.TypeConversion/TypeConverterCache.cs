using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using CsvHelper.Configuration.Attributes;

namespace CsvHelper.TypeConversion;

public class TypeConverterCache
{
	private readonly Dictionary<Type, ITypeConverter> typeConverters = new Dictionary<Type, ITypeConverter>();

	private readonly List<ITypeConverterFactory> defaultTypeConverterFactories = new List<ITypeConverterFactory>();

	private readonly List<ITypeConverterFactory> typeConverterFactories = new List<ITypeConverterFactory>();

	private readonly Dictionary<Type, ITypeConverterFactory> typeConverterFactoryCache = new Dictionary<Type, ITypeConverterFactory>();

	public TypeConverterCache()
	{
		CreateDefaultConverters();
	}

	public bool Contains(Type type)
	{
		return typeConverters.ContainsKey(type);
	}

	public void AddConverterFactory(ITypeConverterFactory typeConverterFactory)
	{
		if (typeConverterFactory == null)
		{
			throw new ArgumentNullException("typeConverterFactory");
		}
		typeConverterFactories.Add(typeConverterFactory);
	}

	public void AddConverter(Type type, ITypeConverter typeConverter)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (typeConverter == null)
		{
			throw new ArgumentNullException("typeConverter");
		}
		typeConverters[type] = typeConverter;
	}

	public void AddConverter<T>(TypeConverter<T> typeConverter)
	{
		this.AddConverter<T>((ITypeConverter)typeConverter);
	}

	public void AddConverter<T>(ITypeConverter typeConverter)
	{
		if (typeConverter == null)
		{
			throw new ArgumentNullException("typeConverter");
		}
		typeConverters[typeof(T)] = typeConverter;
	}

	public void AddConverter(ITypeConverter typeConverter)
	{
		foreach (Type key in typeConverters.Keys)
		{
			typeConverters[key] = typeConverter;
		}
	}

	public void RemoveConverter(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		typeConverters.Remove(type);
	}

	public void RemoveConverter<T>()
	{
		RemoveConverter(typeof(T));
	}

	public void RemoveConverterFactory(ITypeConverterFactory typeConverterFactory)
	{
		typeConverterFactories.Remove(typeConverterFactory);
		foreach (KeyValuePair<Type, ITypeConverterFactory> item in typeConverterFactoryCache.Where<KeyValuePair<Type, ITypeConverterFactory>>((KeyValuePair<Type, ITypeConverterFactory> pair) => pair.Value == typeConverterFactory))
		{
			typeConverterFactoryCache.Remove(item.Key);
		}
	}

	public ITypeConverter GetConverter(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (typeConverters.TryGetValue(type, out ITypeConverter value))
		{
			return value;
		}
		if (!typeConverterFactoryCache.TryGetValue(type, out ITypeConverterFactory value2))
		{
			value2 = typeConverterFactories.Concat(defaultTypeConverterFactories).FirstOrDefault((ITypeConverterFactory f) => f.CanCreate(type));
			if (value2 != null)
			{
				typeConverterFactoryCache[type] = value2;
			}
		}
		if (value2 != null)
		{
			if (value2.Create(type, this, out value))
			{
				AddConverter(type, value);
			}
			return value;
		}
		return new DefaultTypeConverter();
	}

	public ITypeConverter GetConverter(MemberInfo member)
	{
		TypeConverterAttribute customAttribute = member.GetCustomAttribute<TypeConverterAttribute>();
		if (customAttribute != null)
		{
			return customAttribute.TypeConverter;
		}
		return GetConverter(member.MemberType());
	}

	public ITypeConverter GetConverter<T>()
	{
		return GetConverter(typeof(T));
	}

	private void CreateDefaultConverters()
	{
		AddConverter(typeof(BigInteger), new BigIntegerConverter());
		AddConverter(typeof(bool), new BooleanConverter());
		AddConverter(typeof(byte), new ByteConverter());
		AddConverter(typeof(byte[]), new ByteArrayConverter());
		AddConverter(typeof(char), new CharConverter());
		AddConverter(typeof(DateTime), new DateTimeConverter());
		AddConverter(typeof(DateTimeOffset), new DateTimeOffsetConverter());
		AddConverter(typeof(decimal), new DecimalConverter());
		AddConverter(typeof(double), new DoubleConverter());
		AddConverter(typeof(float), new SingleConverter());
		AddConverter(typeof(Guid), new GuidConverter());
		AddConverter(typeof(short), new Int16Converter());
		AddConverter(typeof(int), new Int32Converter());
		AddConverter(typeof(long), new Int64Converter());
		AddConverter(typeof(sbyte), new SByteConverter());
		AddConverter(typeof(string), new StringConverter());
		AddConverter(typeof(TimeSpan), new TimeSpanConverter());
		AddConverter(new NotSupportedTypeConverter<Type>());
		AddConverter(typeof(ushort), new UInt16Converter());
		AddConverter(typeof(uint), new UInt32Converter());
		AddConverter(typeof(ulong), new UInt64Converter());
		AddConverter(typeof(Uri), new UriConverter());
		AddConverter(typeof(DateOnly), new DateOnlyConverter());
		AddConverter(typeof(TimeOnly), new TimeOnlyConverter());
		defaultTypeConverterFactories.Add(new EnumConverterFactory());
		defaultTypeConverterFactories.Add(new NullableConverterFactory());
		defaultTypeConverterFactories.Add(new CollectionConverterFactory());
	}
}
