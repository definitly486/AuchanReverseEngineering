using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace CsvHelper.TypeConversion;

public class CollectionConverterFactory : ITypeConverterFactory
{
	private int dictionaryTypeHashCode = typeof(IDictionary).GetHashCode();

	private List<int> enumerableTypeHashCodes = new List<int>
	{
		typeof(IList).GetHashCode(),
		typeof(ICollection).GetHashCode(),
		typeof(IEnumerable).GetHashCode()
	};

	public bool CanCreate(Type type)
	{
		if (type is IList || type is IDictionary || type is ICollection || type is IEnumerable)
		{
			return true;
		}
		if (type.IsArray)
		{
			return true;
		}
		if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<, >))
		{
			return true;
		}
		if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<, >))
		{
			return true;
		}
		if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
		{
			return true;
		}
		if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Collection<>))
		{
			return true;
		}
		if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
		{
			return true;
		}
		if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>))
		{
			return true;
		}
		if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
		{
			return true;
		}
		if (typeof(IEnumerable).IsAssignableFrom(type))
		{
			return true;
		}
		return false;
	}

	public bool Create(Type type, TypeConverterCache cache, out ITypeConverter typeConverter)
	{
		int hashCode = type.GetHashCode();
		if (hashCode == dictionaryTypeHashCode)
		{
			typeConverter = new IDictionaryConverter();
			return true;
		}
		if (enumerableTypeHashCodes.Contains(hashCode))
		{
			typeConverter = new IEnumerableConverter();
			return true;
		}
		if (type.IsArray)
		{
			typeConverter = new ArrayConverter();
			return true;
		}
		if (type.GetTypeInfo().IsGenericType)
		{
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (genericTypeDefinition == typeof(Dictionary<, >))
			{
				typeConverter = new IDictionaryGenericConverter();
				return true;
			}
			if (genericTypeDefinition == typeof(IDictionary<, >))
			{
				typeConverter = new IDictionaryGenericConverter();
				return true;
			}
			if (genericTypeDefinition == typeof(List<>))
			{
				typeConverter = new CollectionGenericConverter();
				return true;
			}
			if (genericTypeDefinition == typeof(Collection<>))
			{
				typeConverter = new CollectionGenericConverter();
				return true;
			}
			if (genericTypeDefinition == typeof(IList<>))
			{
				typeConverter = new IEnumerableGenericConverter();
				return true;
			}
			if (genericTypeDefinition == typeof(ICollection<>))
			{
				typeConverter = new IEnumerableGenericConverter();
				return true;
			}
			if (genericTypeDefinition == typeof(IEnumerable<>))
			{
				typeConverter = new IEnumerableGenericConverter();
				return true;
			}
		}
		if (typeof(IEnumerable).IsAssignableFrom(type))
		{
			typeConverter = new EnumerableConverter();
			return true;
		}
		throw new InvalidOperationException("Cannot create collection converter for type '" + type.FullName + "'.");
	}
}
