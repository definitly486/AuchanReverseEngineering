using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SQLite;

public class TableMapping
{
	public class Column
	{
		private MemberInfo _member;

		public string Name { get; private set; }

		public PropertyInfo PropertyInfo => _member as PropertyInfo;

		public string PropertyName => _member.Name;

		public Type ColumnType { get; private set; }

		public string Collation { get; private set; }

		public bool IsAutoInc { get; private set; }

		public bool IsAutoGuid { get; private set; }

		public bool IsPK { get; private set; }

		public IEnumerable<IndexedAttribute> Indices { get; set; }

		public bool IsNullable { get; private set; }

		public int? MaxStringLength { get; private set; }

		public bool StoreAsText { get; private set; }

		public Column(MemberInfo member, CreateFlags createFlags = CreateFlags.None)
		{
			_member = member;
			Type memberType = GetMemberType(member);
			CustomAttributeData customAttributeData = member.CustomAttributes.FirstOrDefault((CustomAttributeData x) => x.AttributeType == typeof(ColumnAttribute));
			Name = ((customAttributeData == null || customAttributeData.ConstructorArguments.Count <= 0) ? member.Name : customAttributeData.ConstructorArguments[0].Value?.ToString());
			ColumnType = Nullable.GetUnderlyingType(memberType) ?? memberType;
			Collation = Orm.Collation(member);
			IsPK = Orm.IsPK(member) || ((createFlags & CreateFlags.ImplicitPK) == CreateFlags.ImplicitPK && string.Compare(member.Name, "Id", StringComparison.OrdinalIgnoreCase) == 0);
			bool flag = Orm.IsAutoInc(member) || (IsPK && (createFlags & CreateFlags.AutoIncPK) == CreateFlags.AutoIncPK);
			IsAutoGuid = flag && ColumnType == typeof(Guid);
			IsAutoInc = flag && !IsAutoGuid;
			Indices = Orm.GetIndices(member);
			if (!Indices.Any() && !IsPK && (createFlags & CreateFlags.ImplicitIndex) == CreateFlags.ImplicitIndex && Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase))
			{
				Indices = new IndexedAttribute[1]
				{
					new IndexedAttribute()
				};
			}
			IsNullable = !IsPK && !Orm.IsMarkedNotNull(member);
			MaxStringLength = Orm.MaxStringLength(member);
			StoreAsText = memberType.GetTypeInfo().CustomAttributes.Any((CustomAttributeData x) => x.AttributeType == typeof(StoreAsTextAttribute));
		}

		public void SetValue(object obj, object val)
		{
			if (_member is PropertyInfo propertyInfo)
			{
				if (val != null && ColumnType.GetTypeInfo().IsEnum)
				{
					propertyInfo.SetValue(obj, Enum.ToObject(ColumnType, val));
				}
				else
				{
					propertyInfo.SetValue(obj, val);
				}
				return;
			}
			if (_member is FieldInfo fieldInfo)
			{
				if (val != null && ColumnType.GetTypeInfo().IsEnum)
				{
					fieldInfo.SetValue(obj, Enum.ToObject(ColumnType, val));
				}
				else
				{
					fieldInfo.SetValue(obj, val);
				}
				return;
			}
			throw new InvalidProgramException("unreachable condition");
		}

		public object GetValue(object obj)
		{
			if (_member is PropertyInfo propertyInfo)
			{
				return propertyInfo.GetValue(obj);
			}
			if (_member is FieldInfo fieldInfo)
			{
				return fieldInfo.GetValue(obj);
			}
			throw new InvalidProgramException("unreachable condition");
		}

		private static Type GetMemberType(MemberInfo m)
		{
			return m.MemberType switch
			{
				MemberTypes.Property => ((PropertyInfo)m).PropertyType, 
				MemberTypes.Field => ((FieldInfo)m).FieldType, 
				_ => throw new InvalidProgramException("TableMapping supports properties or fields only."), 
			};
		}
	}

	internal enum MapMethod
	{
		ByName,
		ByPosition
	}

	private readonly Column _autoPk;

	private readonly Column[] _insertColumns;

	private readonly Column[] _insertOrReplaceColumns;

	public Type MappedType { get; private set; }

	public string TableName { get; private set; }

	public bool WithoutRowId { get; private set; }

	public Column[] Columns { get; private set; }

	public Column PK { get; private set; }

	public string GetByPrimaryKeySql { get; private set; }

	public CreateFlags CreateFlags { get; private set; }

	internal MapMethod Method { get; private set; }

	public bool HasAutoIncPK { get; private set; }

	public Column[] InsertColumns => _insertColumns;

	public Column[] InsertOrReplaceColumns => _insertOrReplaceColumns;

	public TableMapping(Type type, CreateFlags createFlags = CreateFlags.None)
	{
		MappedType = type;
		CreateFlags = createFlags;
		TableAttribute tableAttribute = (from x in type.GetTypeInfo().CustomAttributes
			where x.AttributeType == typeof(TableAttribute)
			select (TableAttribute)Orm.InflateAttribute(x)).FirstOrDefault();
		TableName = ((tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name)) ? tableAttribute.Name : MappedType.Name);
		WithoutRowId = tableAttribute?.WithoutRowId ?? false;
		IReadOnlyCollection<MemberInfo> publicMembers = GetPublicMembers(type);
		List<Column> list = new List<Column>(publicMembers.Count);
		foreach (MemberInfo item in publicMembers)
		{
			if (!item.IsDefined(typeof(IgnoreAttribute), inherit: true))
			{
				list.Add(new Column(item, createFlags));
			}
		}
		Columns = list.ToArray();
		Column[] columns = Columns;
		foreach (Column column in columns)
		{
			if (column.IsAutoInc && column.IsPK)
			{
				_autoPk = column;
			}
			if (column.IsPK)
			{
				PK = column;
			}
		}
		HasAutoIncPK = _autoPk != null;
		if (PK != null)
		{
			GetByPrimaryKeySql = $"select * from \"{TableName}\" where \"{PK.Name}\" = ?";
		}
		else
		{
			GetByPrimaryKeySql = $"select * from \"{TableName}\" limit 1";
		}
		_insertColumns = Columns.Where((Column c) => !c.IsAutoInc).ToArray();
		_insertOrReplaceColumns = Columns.ToArray();
	}

	private IReadOnlyCollection<MemberInfo> GetPublicMembers(Type type)
	{
		if (type.Name.StartsWith("ValueTuple`"))
		{
			return GetFieldsFromValueTuple(type);
		}
		List<MemberInfo> list = new List<MemberInfo>();
		HashSet<string> memberNames = new HashSet<string>();
		List<MemberInfo> list2 = new List<MemberInfo>();
		do
		{
			TypeInfo typeInfo = type.GetTypeInfo();
			list2.Clear();
			list2.AddRange(typeInfo.DeclaredProperties.Where((PropertyInfo p) => !memberNames.Contains(p.Name) && p.CanRead && p.CanWrite && p.GetMethod != null && p.SetMethod != null && p.GetMethod.IsPublic && p.SetMethod.IsPublic && !p.GetMethod.IsStatic && !p.SetMethod.IsStatic));
			list.AddRange(list2);
			foreach (MemberInfo item in list2)
			{
				memberNames.Add(item.Name);
			}
			type = typeInfo.BaseType;
		}
		while (type != typeof(object));
		return list;
	}

	private IReadOnlyCollection<MemberInfo> GetFieldsFromValueTuple(Type type)
	{
		Method = MapMethod.ByPosition;
		FieldInfo[] fields = type.GetFields();
		if (fields.Length >= 8)
		{
			throw new NotSupportedException("ValueTuple with more than 7 members not supported due to nesting; see https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-8.rest");
		}
		return (IReadOnlyCollection<MemberInfo>)(object)fields;
	}

	public void SetAutoIncPK(object obj, long id)
	{
		if (_autoPk != null)
		{
			_autoPk.SetValue(obj, Convert.ChangeType(id, _autoPk.ColumnType, null));
		}
	}

	public Column FindColumnWithPropertyName(string propertyName)
	{
		return Columns.FirstOrDefault((Column c) => c.PropertyName == propertyName);
	}

	public Column FindColumn(string columnName)
	{
		if (Method != MapMethod.ByName)
		{
			throw new InvalidOperationException(string.Format("This {0} is not mapped by name, but {1}.", "TableMapping", Method));
		}
		return Columns.FirstOrDefault((Column c) => c.Name.ToLower() == columnName.ToLower());
	}
}
