using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using SQLitePCL;

namespace SQLite;

public class SQLiteCommand
{
	private class Binding
	{
		public string Name { get; set; }

		public object Value { get; set; }

		public int Index { get; set; }
	}

	private SQLiteConnection _conn;

	private List<Binding> _bindings;

	private static IntPtr NegativePointer = new IntPtr(-1);

	public string CommandText { get; set; }

	public SQLiteCommand(SQLiteConnection conn)
	{
		_conn = conn;
		_bindings = new List<Binding>();
		CommandText = "";
	}

	public int ExecuteNonQuery()
	{
		if (_conn.Trace)
		{
			_conn.Tracer?.Invoke("Executing: " + this);
		}
		SQLite3.Result result = SQLite3.Result.OK;
		sqlite3_stmt stmt = Prepare();
		result = SQLite3.Step(stmt);
		Finalize(stmt);
		switch (result)
		{
		case SQLite3.Result.Done:
			return SQLite3.Changes(_conn.Handle);
		case SQLite3.Result.Error:
		{
			string errmsg = SQLite3.GetErrmsg(_conn.Handle);
			throw SQLiteException.New(result, errmsg);
		}
		case SQLite3.Result.Constraint:
			if (SQLite3.ExtendedErrCode(_conn.Handle) == SQLite3.ExtendedResult.ConstraintNotNull)
			{
				throw NotNullConstraintViolationException.New(result, SQLite3.GetErrmsg(_conn.Handle));
			}
			break;
		}
		throw SQLiteException.New(result, SQLite3.GetErrmsg(_conn.Handle));
	}

	public IEnumerable<T> ExecuteDeferredQuery<T>()
	{
		return ExecuteDeferredQuery<T>(_conn.GetMapping(typeof(T)));
	}

	public List<T> ExecuteQuery<T>()
	{
		return ExecuteDeferredQuery<T>(_conn.GetMapping(typeof(T))).ToList();
	}

	public List<T> ExecuteQuery<T>(TableMapping map)
	{
		return ExecuteDeferredQuery<T>(map).ToList();
	}

	protected virtual void OnInstanceCreated(object obj)
	{
	}

	public IEnumerable<T> ExecuteDeferredQuery<T>(TableMapping map)
	{
		if (_conn.Trace)
		{
			_conn.Tracer?.Invoke("Executing Query: " + this);
		}
		sqlite3_stmt stmt = Prepare();
		try
		{
			TableMapping.Column[] cols = new TableMapping.Column[SQLite3.ColumnCount(stmt)];
			Action<object, sqlite3_stmt, int>[] fastColumnSetters = new Action<object, sqlite3_stmt, int>[SQLite3.ColumnCount(stmt)];
			if (map.Method == TableMapping.MapMethod.ByPosition)
			{
				Array.Copy(map.Columns, cols, Math.Min(cols.Length, map.Columns.Length));
			}
			else if (map.Method == TableMapping.MapMethod.ByName)
			{
				MethodInfo methodInfo = null;
				if (typeof(T) != map.MappedType)
				{
					methodInfo = typeof(FastColumnSetter).GetMethod("GetFastSetter", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(map.MappedType);
				}
				for (int i = 0; i < cols.Length; i++)
				{
					string columnName = SQLite3.ColumnName16(stmt, i);
					cols[i] = map.FindColumn(columnName);
					if (cols[i] != null)
					{
						if (methodInfo != null)
						{
							fastColumnSetters[i] = (Action<object, sqlite3_stmt, int>)methodInfo.Invoke(null, new object[2]
							{
								_conn,
								cols[i]
							});
						}
						else
						{
							fastColumnSetters[i] = FastColumnSetter.GetFastSetter<T>(_conn, cols[i]);
						}
					}
				}
			}
			while (SQLite3.Step(stmt) == SQLite3.Result.Row)
			{
				object obj = Activator.CreateInstance(map.MappedType);
				for (int j = 0; j < cols.Length; j++)
				{
					if (cols[j] != null)
					{
						if (fastColumnSetters[j] != null)
						{
							fastColumnSetters[j](obj, stmt, j);
							continue;
						}
						SQLite3.ColType type = SQLite3.ColumnType(stmt, j);
						object val = ReadCol(stmt, j, type, cols[j].ColumnType);
						cols[j].SetValue(obj, val);
					}
				}
				OnInstanceCreated(obj);
				yield return (T)obj;
			}
		}
		finally
		{
			SQLite3.Finalize(stmt);
		}
	}

	public T ExecuteScalar<T>()
	{
		if (_conn.Trace)
		{
			_conn.Tracer?.Invoke("Executing Query: " + this);
		}
		T result = default(T);
		sqlite3_stmt stmt = Prepare();
		try
		{
			SQLite3.Result result2 = SQLite3.Step(stmt);
			switch (result2)
			{
			case SQLite3.Result.Row:
			{
				SQLite3.ColType type = SQLite3.ColumnType(stmt, 0);
				object obj = ReadCol(stmt, 0, type, typeof(T));
				if (obj != null)
				{
					result = (T)obj;
					return result;
				}
				break;
			}
			case SQLite3.Result.Done:
				break;
			default:
				throw SQLiteException.New(result2, SQLite3.GetErrmsg(_conn.Handle));
			}
		}
		finally
		{
			Finalize(stmt);
		}
		return result;
	}

	public IEnumerable<T> ExecuteQueryScalars<T>()
	{
		if (_conn.Trace)
		{
			_conn.Tracer?.Invoke("Executing Query: " + this);
		}
		sqlite3_stmt stmt = Prepare();
		try
		{
			if (SQLite3.ColumnCount(stmt) < 1)
			{
				throw new InvalidOperationException("QueryScalars should return at least one column");
			}
			while (SQLite3.Step(stmt) == SQLite3.Result.Row)
			{
				SQLite3.ColType type = SQLite3.ColumnType(stmt, 0);
				object obj = ReadCol(stmt, 0, type, typeof(T));
				if (obj == null)
				{
					yield return default(T);
				}
				else
				{
					yield return (T)obj;
				}
			}
		}
		finally
		{
			Finalize(stmt);
		}
	}

	public void Bind(string name, object val)
	{
		_bindings.Add(new Binding
		{
			Name = name,
			Value = val
		});
	}

	public void Bind(object val)
	{
		Bind(null, val);
	}

	public override string ToString()
	{
		string[] array = new string[1 + _bindings.Count];
		array[0] = CommandText;
		int num = 1;
		foreach (Binding binding in _bindings)
		{
			array[num] = $"  {num - 1}: {binding.Value}";
			num++;
		}
		return string.Join("\n", array);
	}

	private sqlite3_stmt Prepare()
	{
		sqlite3_stmt sqlite3_stmt = SQLite3.Prepare2(_conn.Handle, CommandText);
		BindAll(sqlite3_stmt);
		return sqlite3_stmt;
	}

	private void Finalize(sqlite3_stmt stmt)
	{
		SQLite3.Finalize(stmt);
	}

	private void BindAll(sqlite3_stmt stmt)
	{
		int num = 1;
		foreach (Binding binding in _bindings)
		{
			if (binding.Name != null)
			{
				binding.Index = SQLite3.BindParameterIndex(stmt, binding.Name);
			}
			else
			{
				binding.Index = num++;
			}
			BindParameter(stmt, binding.Index, binding.Value, _conn.StoreDateTimeAsTicks, _conn.DateTimeStringFormat, _conn.StoreTimeSpanAsTicks);
		}
	}

	internal static void BindParameter(sqlite3_stmt stmt, int index, object value, bool storeDateTimeAsTicks, string dateTimeStringFormat, bool storeTimeSpanAsTicks)
	{
		if (value == null)
		{
			SQLite3.BindNull(stmt, index);
			return;
		}
		if (value is int)
		{
			SQLite3.BindInt(stmt, index, (int)value);
			return;
		}
		if (value is string)
		{
			SQLite3.BindText(stmt, index, (string)value, -1, NegativePointer);
			return;
		}
		if (value is byte || value is ushort || value is sbyte || value is short)
		{
			SQLite3.BindInt(stmt, index, Convert.ToInt32(value));
			return;
		}
		if (value is bool)
		{
			SQLite3.BindInt(stmt, index, ((bool)value) ? 1 : 0);
			return;
		}
		if (value is uint || value is long || value is ulong)
		{
			SQLite3.BindInt64(stmt, index, Convert.ToInt64(value));
			return;
		}
		if (value is float || value is double || value is decimal)
		{
			SQLite3.BindDouble(stmt, index, Convert.ToDouble(value));
			return;
		}
		if (value is TimeSpan)
		{
			if (storeTimeSpanAsTicks)
			{
				SQLite3.BindInt64(stmt, index, ((TimeSpan)value).Ticks);
			}
			else
			{
				SQLite3.BindText(stmt, index, ((TimeSpan)value/*cast due to .constrained prefix*/).ToString(), -1, NegativePointer);
			}
			return;
		}
		if (value is DateTime)
		{
			if (storeDateTimeAsTicks)
			{
				SQLite3.BindInt64(stmt, index, ((DateTime)value).Ticks);
			}
			else
			{
				SQLite3.BindText(stmt, index, ((DateTime)value).ToString(dateTimeStringFormat, CultureInfo.InvariantCulture), -1, NegativePointer);
			}
			return;
		}
		if (value is DateTimeOffset)
		{
			SQLite3.BindInt64(stmt, index, ((DateTimeOffset)value).UtcTicks);
			return;
		}
		if (value is byte[])
		{
			SQLite3.BindBlob(stmt, index, (byte[])value, ((byte[])value).Length, NegativePointer);
			return;
		}
		if (value is Guid)
		{
			SQLite3.BindText(stmt, index, ((Guid)value/*cast due to .constrained prefix*/).ToString(), 72, NegativePointer);
			return;
		}
		if (value is Uri)
		{
			SQLite3.BindText(stmt, index, ((Uri)value).ToString(), -1, NegativePointer);
			return;
		}
		if (value is StringBuilder)
		{
			SQLite3.BindText(stmt, index, ((StringBuilder)value).ToString(), -1, NegativePointer);
			return;
		}
		if (value is UriBuilder)
		{
			SQLite3.BindText(stmt, index, ((UriBuilder)value).ToString(), -1, NegativePointer);
			return;
		}
		EnumCacheInfo info = EnumCache.GetInfo(value.GetType());
		if (info.IsEnum)
		{
			int num = Convert.ToInt32(value);
			if (info.StoreAsText)
			{
				SQLite3.BindText(stmt, index, info.EnumValues[num], -1, NegativePointer);
			}
			else
			{
				SQLite3.BindInt(stmt, index, num);
			}
			return;
		}
		throw new NotSupportedException("Cannot store type: " + Orm.GetType(value));
	}

	private object ReadCol(sqlite3_stmt stmt, int index, SQLite3.ColType type, Type clrType)
	{
		if (type == SQLite3.ColType.Null)
		{
			return null;
		}
		TypeInfo typeInfo = clrType.GetTypeInfo();
		if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			clrType = typeInfo.GenericTypeArguments[0];
			typeInfo = clrType.GetTypeInfo();
		}
		if (clrType == typeof(string))
		{
			return SQLite3.ColumnString(stmt, index);
		}
		if (clrType == typeof(int))
		{
			return SQLite3.ColumnInt(stmt, index);
		}
		if (clrType == typeof(bool))
		{
			return SQLite3.ColumnInt(stmt, index) == 1;
		}
		if (clrType == typeof(double))
		{
			return SQLite3.ColumnDouble(stmt, index);
		}
		if (clrType == typeof(float))
		{
			return (float)SQLite3.ColumnDouble(stmt, index);
		}
		if (clrType == typeof(TimeSpan))
		{
			if (_conn.StoreTimeSpanAsTicks)
			{
				return new TimeSpan(SQLite3.ColumnInt64(stmt, index));
			}
			string text = SQLite3.ColumnString(stmt, index);
			if (!TimeSpan.TryParseExact(text, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out var result))
			{
				result = TimeSpan.Parse(text);
			}
			return result;
		}
		if (clrType == typeof(DateTime))
		{
			if (_conn.StoreDateTimeAsTicks)
			{
				return new DateTime(SQLite3.ColumnInt64(stmt, index));
			}
			string s = SQLite3.ColumnString(stmt, index);
			if (!DateTime.TryParseExact(s, _conn.DateTimeStringFormat, CultureInfo.InvariantCulture, _conn.DateTimeStyle, out var result2))
			{
				result2 = DateTime.Parse(s);
			}
			return result2;
		}
		if (clrType == typeof(DateTimeOffset))
		{
			return new DateTimeOffset(SQLite3.ColumnInt64(stmt, index), TimeSpan.Zero);
		}
		if (typeInfo.IsEnum)
		{
			if (type == SQLite3.ColType.Text)
			{
				string text2 = SQLite3.ColumnString(stmt, index);
				return Enum.Parse(clrType, text2.ToString(), ignoreCase: true);
			}
			return SQLite3.ColumnInt(stmt, index);
		}
		if (clrType == typeof(long))
		{
			return SQLite3.ColumnInt64(stmt, index);
		}
		if (clrType == typeof(ulong))
		{
			return (ulong)SQLite3.ColumnInt64(stmt, index);
		}
		if (clrType == typeof(uint))
		{
			return (uint)SQLite3.ColumnInt64(stmt, index);
		}
		if (clrType == typeof(decimal))
		{
			return (decimal)SQLite3.ColumnDouble(stmt, index);
		}
		if (clrType == typeof(byte))
		{
			return (byte)SQLite3.ColumnInt(stmt, index);
		}
		if (clrType == typeof(ushort))
		{
			return (ushort)SQLite3.ColumnInt(stmt, index);
		}
		if (clrType == typeof(short))
		{
			return (short)SQLite3.ColumnInt(stmt, index);
		}
		if (clrType == typeof(sbyte))
		{
			return (sbyte)SQLite3.ColumnInt(stmt, index);
		}
		if (clrType == typeof(byte[]))
		{
			return SQLite3.ColumnByteArray(stmt, index);
		}
		if (clrType == typeof(Guid))
		{
			return new Guid(SQLite3.ColumnString(stmt, index));
		}
		if (clrType == typeof(Uri))
		{
			return new Uri(SQLite3.ColumnString(stmt, index));
		}
		if (clrType == typeof(StringBuilder))
		{
			return new StringBuilder(SQLite3.ColumnString(stmt, index));
		}
		if (clrType == typeof(UriBuilder))
		{
			return new UriBuilder(SQLite3.ColumnString(stmt, index));
		}
		throw new NotSupportedException("Don't know how to read " + clrType);
	}
}
