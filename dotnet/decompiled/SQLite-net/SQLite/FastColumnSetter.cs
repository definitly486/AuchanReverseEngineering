using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using SQLitePCL;

namespace SQLite;

internal class FastColumnSetter
{
	internal static Action<object, sqlite3_stmt, int> GetFastSetter<T>(SQLiteConnection conn, TableMapping.Column column)
	{
		Action<object, sqlite3_stmt, int> result = null;
		Type type = column.PropertyInfo.PropertyType;
		TypeInfo typeInfo = type.GetTypeInfo();
		if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			type = typeInfo.GenericTypeArguments[0];
			typeInfo = type.GetTypeInfo();
		}
		if (type == typeof(string))
		{
			result = CreateTypedSetterDelegate<T, string>(column, (sqlite3_stmt stmt, int index) => SQLite3.ColumnString(stmt, index));
		}
		else if (type == typeof(int))
		{
			result = CreateNullableTypedSetterDelegate<T, int>(column, (sqlite3_stmt stmt, int index) => SQLite3.ColumnInt(stmt, index));
		}
		else if (type == typeof(bool))
		{
			result = CreateNullableTypedSetterDelegate<T, bool>(column, (sqlite3_stmt stmt, int index) => SQLite3.ColumnInt(stmt, index) == 1);
		}
		else if (type == typeof(double))
		{
			result = CreateNullableTypedSetterDelegate<T, double>(column, (sqlite3_stmt stmt, int index) => SQLite3.ColumnDouble(stmt, index));
		}
		else if (type == typeof(float))
		{
			result = CreateNullableTypedSetterDelegate<T, float>(column, (sqlite3_stmt stmt, int index) => (float)SQLite3.ColumnDouble(stmt, index));
		}
		else if (type == typeof(TimeSpan))
		{
			result = ((!conn.StoreTimeSpanAsTicks) ? CreateNullableTypedSetterDelegate<T, TimeSpan>(column, delegate(sqlite3_stmt stmt, int index)
			{
				string text = SQLite3.ColumnString(stmt, index);
				TimeSpan result2;
				return (!TimeSpan.TryParseExact(text, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out result2)) ? TimeSpan.Parse(text) : result2;
			}) : CreateNullableTypedSetterDelegate<T, TimeSpan>(column, (sqlite3_stmt stmt, int index) => new TimeSpan(SQLite3.ColumnInt64(stmt, index))));
		}
		else if (type == typeof(DateTime))
		{
			result = ((!conn.StoreDateTimeAsTicks) ? CreateNullableTypedSetterDelegate<T, DateTime>(column, delegate(sqlite3_stmt stmt, int index)
			{
				string s = SQLite3.ColumnString(stmt, index);
				DateTime result2;
				return (!DateTime.TryParseExact(s, conn.DateTimeStringFormat, CultureInfo.InvariantCulture, conn.DateTimeStyle, out result2)) ? DateTime.Parse(s) : result2;
			}) : CreateNullableTypedSetterDelegate<T, DateTime>(column, (sqlite3_stmt stmt, int index) => new DateTime(SQLite3.ColumnInt64(stmt, index))));
		}
		else if (type == typeof(DateTimeOffset))
		{
			result = CreateNullableTypedSetterDelegate<T, DateTimeOffset>(column, (sqlite3_stmt stmt, int index) => new DateTimeOffset(SQLite3.ColumnInt64(stmt, index), TimeSpan.Zero));
		}
		else if (!typeInfo.IsEnum)
		{
			if (type == typeof(long))
			{
				result = CreateNullableTypedSetterDelegate<T, long>(column, (sqlite3_stmt stmt, int index) => SQLite3.ColumnInt64(stmt, index));
			}
			else if (type == typeof(ulong))
			{
				result = CreateNullableTypedSetterDelegate<T, ulong>(column, (sqlite3_stmt stmt, int index) => (ulong)SQLite3.ColumnInt64(stmt, index));
			}
			else if (type == typeof(uint))
			{
				result = CreateNullableTypedSetterDelegate<T, uint>(column, (sqlite3_stmt stmt, int index) => (uint)SQLite3.ColumnInt64(stmt, index));
			}
			else if (type == typeof(decimal))
			{
				result = CreateNullableTypedSetterDelegate<T, decimal>(column, (sqlite3_stmt stmt, int index) => (decimal)SQLite3.ColumnDouble(stmt, index));
			}
			else if (type == typeof(byte))
			{
				result = CreateNullableTypedSetterDelegate<T, byte>(column, (sqlite3_stmt stmt, int index) => (byte)SQLite3.ColumnInt(stmt, index));
			}
			else if (type == typeof(ushort))
			{
				result = CreateNullableTypedSetterDelegate<T, ushort>(column, (sqlite3_stmt stmt, int index) => (ushort)SQLite3.ColumnInt(stmt, index));
			}
			else if (type == typeof(short))
			{
				result = CreateNullableTypedSetterDelegate<T, short>(column, (sqlite3_stmt stmt, int index) => (short)SQLite3.ColumnInt(stmt, index));
			}
			else if (type == typeof(sbyte))
			{
				result = CreateNullableTypedSetterDelegate<T, sbyte>(column, (sqlite3_stmt stmt, int index) => (sbyte)SQLite3.ColumnInt(stmt, index));
			}
			else if (type == typeof(byte[]))
			{
				result = CreateTypedSetterDelegate<T, byte[]>(column, (sqlite3_stmt stmt, int index) => SQLite3.ColumnByteArray(stmt, index));
			}
			else if (type == typeof(Guid))
			{
				result = CreateNullableTypedSetterDelegate<T, Guid>(column, (sqlite3_stmt stmt, int index) => new Guid(SQLite3.ColumnString(stmt, index)));
			}
			else if (type == typeof(Uri))
			{
				result = CreateTypedSetterDelegate<T, Uri>(column, (sqlite3_stmt stmt, int index) => new Uri(SQLite3.ColumnString(stmt, index)));
			}
			else if (type == typeof(StringBuilder))
			{
				result = CreateTypedSetterDelegate<T, StringBuilder>(column, (sqlite3_stmt stmt, int index) => new StringBuilder(SQLite3.ColumnString(stmt, index)));
			}
			else if (type == typeof(UriBuilder))
			{
				result = CreateTypedSetterDelegate<T, UriBuilder>(column, (sqlite3_stmt stmt, int index) => new UriBuilder(SQLite3.ColumnString(stmt, index)));
			}
		}
		return result;
	}

	private static Action<object, sqlite3_stmt, int> CreateNullableTypedSetterDelegate<ObjectType, ColumnMemberType>(TableMapping.Column column, Func<sqlite3_stmt, int, ColumnMemberType> getColumnValue) where ColumnMemberType : struct
	{
		TypeInfo typeInfo = column.PropertyInfo.PropertyType.GetTypeInfo();
		bool flag = false;
		if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			flag = true;
		}
		if (flag)
		{
			Action<ObjectType, ColumnMemberType?> setProperty = (Action<ObjectType, ColumnMemberType?>)Delegate.CreateDelegate(typeof(Action<ObjectType, ColumnMemberType?>), null, column.PropertyInfo.GetSetMethod());
			return delegate(object o, sqlite3_stmt stmt, int i)
			{
				if (SQLite3.ColumnType(stmt, i) != SQLite3.ColType.Null)
				{
					setProperty((ObjectType)o, getColumnValue(stmt, i));
				}
			};
		}
		return CreateTypedSetterDelegate<ObjectType, ColumnMemberType>(column, getColumnValue);
	}

	private static Action<object, sqlite3_stmt, int> CreateTypedSetterDelegate<ObjectType, ColumnMemberType>(TableMapping.Column column, Func<sqlite3_stmt, int, ColumnMemberType> getColumnValue)
	{
		Action<ObjectType, ColumnMemberType> setProperty = (Action<ObjectType, ColumnMemberType>)Delegate.CreateDelegate(typeof(Action<ObjectType, ColumnMemberType>), null, column.PropertyInfo.GetSetMethod());
		return delegate(object o, sqlite3_stmt stmt, int i)
		{
			if (SQLite3.ColumnType(stmt, i) != SQLite3.ColType.Null)
			{
				setProperty((ObjectType)o, getColumnValue(stmt, i));
			}
		};
	}
}
