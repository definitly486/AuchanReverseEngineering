using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace CsvHelper;

public class CsvDataReader : IDataReader, IDataRecord, IDisposable
{
	private readonly CsvReader csv;

	private readonly DataTable schemaTable;

	private bool skipNextRead;

	public object this[int i] => csv[i] ?? string.Empty;

	public object this[string name] => csv[name] ?? string.Empty;

	public int Depth => 0;

	public bool IsClosed { get; private set; }

	public int RecordsAffected => 0;

	public int FieldCount => csv?.Parser.Count ?? 0;

	public CsvDataReader(CsvReader csv, DataTable? schemaTable = null)
	{
		this.csv = csv;
		csv.Read();
		if (csv.Configuration.HasHeaderRecord && csv.HeaderRecord == null)
		{
			csv.ReadHeader();
		}
		else
		{
			skipNextRead = true;
		}
		this.schemaTable = schemaTable ?? GetSchemaTable();
	}

	public void Close()
	{
		Dispose();
	}

	public void Dispose()
	{
		csv.Dispose();
		IsClosed = true;
	}

	public bool GetBoolean(int i)
	{
		return csv.GetField<bool>(i);
	}

	public byte GetByte(int i)
	{
		return csv.GetField<byte>(i);
	}

	public long GetBytes(int i, long fieldOffset, byte[]? buffer, int bufferoffset, int length)
	{
		byte[] field = csv.GetField<byte[]>(i);
		if (field == null)
		{
			return 0L;
		}
		if (buffer == null)
		{
			buffer = new byte[field.Length];
		}
		Array.Copy(field, fieldOffset, buffer, bufferoffset, length);
		return field.Length;
	}

	public char GetChar(int i)
	{
		return csv.GetField<char>(i);
	}

	public long GetChars(int i, long fieldoffset, char[]? buffer, int bufferoffset, int length)
	{
		char[] array = csv.GetField(i)?.ToCharArray();
		if (array == null)
		{
			return 0L;
		}
		if (buffer == null)
		{
			buffer = new char[array.Length];
		}
		Array.Copy(array, fieldoffset, buffer, bufferoffset, length);
		return array.Length;
	}

	public IDataReader GetData(int i)
	{
		throw new NotSupportedException();
	}

	public string GetDataTypeName(int i)
	{
		if (i >= schemaTable.Rows.Count)
		{
			throw new IndexOutOfRangeException($"SchemaTable does not contain a definition for field '{i}'.");
		}
		Type obj = schemaTable.Rows[i]["DataType"] as Type;
		if (obj == null)
		{
			throw new InvalidOperationException($"SchemaTable does not contain a 'DataType' of type 'Type' for field '{i}'.");
		}
		return obj.Name;
	}

	public DateTime GetDateTime(int i)
	{
		return csv.GetField<DateTime>(i);
	}

	public decimal GetDecimal(int i)
	{
		return csv.GetField<decimal>(i);
	}

	public double GetDouble(int i)
	{
		return csv.GetField<double>(i);
	}

	public Type GetFieldType(int i)
	{
		return typeof(string);
	}

	public float GetFloat(int i)
	{
		return csv.GetField<float>(i);
	}

	public Guid GetGuid(int i)
	{
		return csv.GetField<Guid>(i);
	}

	public short GetInt16(int i)
	{
		return csv.GetField<short>(i);
	}

	public int GetInt32(int i)
	{
		return csv.GetField<int>(i);
	}

	public long GetInt64(int i)
	{
		return csv.GetField<long>(i);
	}

	public string GetName(int i)
	{
		if (!csv.Configuration.HasHeaderRecord)
		{
			return string.Empty;
		}
		string[]? headerRecord = csv.HeaderRecord;
		return ((headerRecord != null) ? headerRecord[i] : null) ?? string.Empty;
	}

	public int GetOrdinal(string name)
	{
		int fieldIndex = csv.GetFieldIndex(name, 0, isTryGet: true);
		if (fieldIndex >= 0)
		{
			return fieldIndex;
		}
		PrepareHeaderForMatchArgs args = new PrepareHeaderForMatchArgs(name, 0);
		string text = csv.Configuration.PrepareHeaderForMatch(args);
		string[] headerRecord = csv.HeaderRecord;
		for (int i = 0; i < ((headerRecord != null) ? headerRecord.Length : 0); i++)
		{
			args = new PrepareHeaderForMatchArgs(((headerRecord != null) ? headerRecord[i] : null) ?? string.Empty, i);
			string @string = csv.Configuration.PrepareHeaderForMatch(args);
			if (csv.Configuration.CultureInfo.CompareInfo.Compare(text, @string, CompareOptions.IgnoreCase) == 0)
			{
				return i;
			}
		}
		throw new IndexOutOfRangeException($"Field with name '{name}' and prepared name '{text}' was not found.");
	}

	public DataTable GetSchemaTable()
	{
		if (schemaTable != null)
		{
			return schemaTable;
		}
		DataTable dataTable = new DataTable("SchemaTable");
		dataTable.Columns.Add("AllowDBNull", typeof(bool));
		dataTable.Columns.Add("AutoIncrementSeed", typeof(long));
		dataTable.Columns.Add("AutoIncrementStep", typeof(long));
		dataTable.Columns.Add("BaseCatalogName");
		dataTable.Columns.Add("BaseColumnName");
		dataTable.Columns.Add("BaseColumnNamespace");
		dataTable.Columns.Add("BaseSchemaName");
		dataTable.Columns.Add("BaseTableName");
		dataTable.Columns.Add("BaseTableNamespace");
		dataTable.Columns.Add("ColumnName");
		dataTable.Columns.Add("ColumnMapping", typeof(MappingType));
		dataTable.Columns.Add("ColumnOrdinal", typeof(int));
		dataTable.Columns.Add("ColumnSize", typeof(int));
		dataTable.Columns.Add("DataType", typeof(Type));
		dataTable.Columns.Add("DefaultValue", typeof(object));
		dataTable.Columns.Add("Expression");
		dataTable.Columns.Add("IsAutoIncrement", typeof(bool));
		dataTable.Columns.Add("IsKey", typeof(bool));
		dataTable.Columns.Add("IsLong", typeof(bool));
		dataTable.Columns.Add("IsReadOnly", typeof(bool));
		dataTable.Columns.Add("IsRowVersion", typeof(bool));
		dataTable.Columns.Add("IsUnique", typeof(bool));
		dataTable.Columns.Add("NumericPrecision", typeof(short));
		dataTable.Columns.Add("NumericScale", typeof(short));
		dataTable.Columns.Add("ProviderType", typeof(int));
		for (int i = 0; i < csv.ColumnCount; i++)
		{
			object obj;
			if (!csv.Configuration.HasHeaderRecord)
			{
				obj = i;
			}
			else
			{
				string[]? headerRecord = csv.HeaderRecord;
				obj = ((headerRecord != null) ? headerRecord[i] : null);
			}
			object value = obj;
			DataRow dataRow = dataTable.NewRow();
			dataRow["AllowDBNull"] = true;
			dataRow["AutoIncrementSeed"] = DBNull.Value;
			dataRow["AutoIncrementStep"] = DBNull.Value;
			dataRow["BaseCatalogName"] = null;
			dataRow["BaseColumnName"] = value;
			dataRow["BaseColumnNamespace"] = null;
			dataRow["BaseSchemaName"] = null;
			dataRow["BaseTableName"] = null;
			dataRow["BaseTableNamespace"] = null;
			dataRow["ColumnName"] = value;
			dataRow["ColumnMapping"] = MappingType.Element;
			dataRow["ColumnOrdinal"] = i;
			dataRow["ColumnSize"] = int.MaxValue;
			dataRow["DataType"] = typeof(string);
			dataRow["DefaultValue"] = null;
			dataRow["Expression"] = null;
			dataRow["IsAutoIncrement"] = false;
			dataRow["IsKey"] = false;
			dataRow["IsLong"] = false;
			dataRow["IsReadOnly"] = true;
			dataRow["IsRowVersion"] = false;
			dataRow["IsUnique"] = false;
			dataRow["NumericPrecision"] = DBNull.Value;
			dataRow["NumericScale"] = DBNull.Value;
			dataRow["ProviderType"] = DbType.String;
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
	}

	public string GetString(int i)
	{
		return csv.GetField(i) ?? string.Empty;
	}

	public object GetValue(int i)
	{
		object obj;
		if (!IsDBNull(i))
		{
			obj = csv.GetField(i);
			if (obj == null)
			{
				return string.Empty;
			}
		}
		else
		{
			obj = DBNull.Value;
		}
		return obj;
	}

	public int GetValues(object[] values)
	{
		for (int i = 0; i < values.Length; i++)
		{
			values[i] = (IsDBNull(i) ? ((IConvertible)DBNull.Value) : ((IConvertible)(csv.GetField(i) ?? string.Empty)));
		}
		return csv.Parser.Count;
	}

	public bool IsDBNull(int i)
	{
		string field = csv.GetField(i);
		List<string> nullValues = csv.Context.TypeConverterOptionsCache.GetOptions<string>().NullValues;
		if (field != null)
		{
			return nullValues.Contains(field);
		}
		return true;
	}

	public bool NextResult()
	{
		return false;
	}

	public bool Read()
	{
		if (skipNextRead)
		{
			skipNextRead = false;
			return true;
		}
		return csv.Read();
	}
}
