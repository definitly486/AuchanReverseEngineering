using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SQLite;

public static class Orm
{
	public static Type GetType(object obj)
	{
		if (obj == null)
		{
			return typeof(object);
		}
		if (obj is IReflectableType reflectableType)
		{
			return reflectableType.GetTypeInfo().AsType();
		}
		return obj.GetType();
	}

	public static string SqlDecl(TableMapping.Column p, bool storeDateTimeAsTicks, bool storeTimeSpanAsTicks)
	{
		string text = "\"" + p.Name + "\" " + SqlType(p, storeDateTimeAsTicks, storeTimeSpanAsTicks) + " ";
		if (p.IsPK)
		{
			text += "primary key ";
		}
		if (p.IsAutoInc)
		{
			text += "autoincrement ";
		}
		if (!p.IsNullable)
		{
			text += "not null ";
		}
		if (!string.IsNullOrEmpty(p.Collation))
		{
			text = text + "collate " + p.Collation + " ";
		}
		return text;
	}

	public static string SqlType(TableMapping.Column p, bool storeDateTimeAsTicks, bool storeTimeSpanAsTicks)
	{
		Type columnType = p.ColumnType;
		if (columnType == typeof(bool) || columnType == typeof(byte) || columnType == typeof(ushort) || columnType == typeof(sbyte) || columnType == typeof(short) || columnType == typeof(int) || columnType == typeof(uint) || columnType == typeof(long) || columnType == typeof(ulong))
		{
			return "integer";
		}
		if (columnType == typeof(float) || columnType == typeof(double) || columnType == typeof(decimal))
		{
			return "float";
		}
		if (columnType == typeof(string) || columnType == typeof(StringBuilder) || columnType == typeof(Uri) || columnType == typeof(UriBuilder))
		{
			int? maxStringLength = p.MaxStringLength;
			if (maxStringLength.HasValue)
			{
				return "varchar(" + maxStringLength.Value + ")";
			}
			return "varchar";
		}
		if (columnType == typeof(TimeSpan))
		{
			if (!storeTimeSpanAsTicks)
			{
				return "time";
			}
			return "bigint";
		}
		if (columnType == typeof(DateTime))
		{
			if (!storeDateTimeAsTicks)
			{
				return "datetime";
			}
			return "bigint";
		}
		if (columnType == typeof(DateTimeOffset))
		{
			return "bigint";
		}
		if (columnType.GetTypeInfo().IsEnum)
		{
			if (p.StoreAsText)
			{
				return "varchar";
			}
			return "integer";
		}
		if (columnType == typeof(byte[]))
		{
			return "blob";
		}
		if (columnType == typeof(Guid))
		{
			return "varchar(36)";
		}
		throw new NotSupportedException("Don't know about " + columnType);
	}

	public static bool IsPK(MemberInfo p)
	{
		return p.CustomAttributes.Any((CustomAttributeData x) => x.AttributeType == typeof(PrimaryKeyAttribute));
	}

	public static string Collation(MemberInfo p)
	{
		return p.CustomAttributes.Where((CustomAttributeData x) => typeof(CollationAttribute) == x.AttributeType).Select(delegate(CustomAttributeData x)
		{
			IList<CustomAttributeTypedArgument> constructorArguments = x.ConstructorArguments;
			return (constructorArguments.Count <= 0) ? "" : ((constructorArguments[0].Value as string) ?? "");
		}).FirstOrDefault() ?? "";
	}

	public static bool IsAutoInc(MemberInfo p)
	{
		return p.CustomAttributes.Any((CustomAttributeData x) => x.AttributeType == typeof(AutoIncrementAttribute));
	}

	public static FieldInfo GetField(TypeInfo t, string name)
	{
		FieldInfo declaredField = t.GetDeclaredField(name);
		if (declaredField != null)
		{
			return declaredField;
		}
		return GetField(t.BaseType.GetTypeInfo(), name);
	}

	public static PropertyInfo GetProperty(TypeInfo t, string name)
	{
		PropertyInfo declaredProperty = t.GetDeclaredProperty(name);
		if (declaredProperty != null)
		{
			return declaredProperty;
		}
		return GetProperty(t.BaseType.GetTypeInfo(), name);
	}

	public static object InflateAttribute(CustomAttributeData x)
	{
		TypeInfo typeInfo = x.AttributeType.GetTypeInfo();
		object[] args = x.ConstructorArguments.Select((CustomAttributeTypedArgument a) => a.Value).ToArray();
		object obj = Activator.CreateInstance(x.AttributeType, args);
		foreach (CustomAttributeNamedArgument namedArgument in x.NamedArguments)
		{
			if (namedArgument.IsField)
			{
				GetField(typeInfo, namedArgument.MemberName).SetValue(obj, namedArgument.TypedValue.Value);
			}
			else
			{
				GetProperty(typeInfo, namedArgument.MemberName).SetValue(obj, namedArgument.TypedValue.Value);
			}
		}
		return obj;
	}

	public static IEnumerable<IndexedAttribute> GetIndices(MemberInfo p)
	{
		TypeInfo indexedInfo = typeof(IndexedAttribute).GetTypeInfo();
		return from x in p.CustomAttributes
			where indexedInfo.IsAssignableFrom(x.AttributeType.GetTypeInfo())
			select (IndexedAttribute)InflateAttribute(x);
	}

	public static int? MaxStringLength(MemberInfo p)
	{
		CustomAttributeData customAttributeData = p.CustomAttributes.FirstOrDefault((CustomAttributeData x) => x.AttributeType == typeof(MaxLengthAttribute));
		if (customAttributeData != null)
		{
			return ((MaxLengthAttribute)InflateAttribute(customAttributeData)).Value;
		}
		return null;
	}

	public static bool IsMarkedNotNull(MemberInfo p)
	{
		return p.CustomAttributes.Any((CustomAttributeData x) => x.AttributeType == typeof(NotNullAttribute));
	}
}
