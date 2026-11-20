using System;
using System.Collections.Generic;
using System.Text;
using NanoXLSX.Exceptions;
using NanoXLSX.Styles;

namespace NanoXLSX;

public class Cell : IComparable<Cell>
{
	public enum CellType
	{
		STRING,
		NUMBER,
		DATE,
		TIME,
		BOOL,
		FORMULA,
		EMPTY,
		DEFAULT
	}

	public enum AddressType
	{
		Default,
		FixedRow,
		FixedColumn,
		FixedRowAndColumn
	}

	private Style cellStyle;

	private int columnNumber;

	private int rowNumber;

	private object value;

	public string CellAddress => ResolveCellAddress(ColumnNumber, RowNumber, CellAddressType);

	public Address CellAddress2
	{
		get
		{
			return new Address(ColumnNumber, RowNumber, CellAddressType);
		}
		set
		{
			ColumnNumber = value.Column;
			RowNumber = value.Row;
			CellAddressType = value.Type;
		}
	}

	public Style CellStyle => cellStyle;

	public int ColumnNumber
	{
		get
		{
			return columnNumber;
		}
		set
		{
			ValidateColumnNumber(value);
			columnNumber = value;
		}
	}

	public CellType DataType { get; set; }

	public int RowNumber
	{
		get
		{
			return rowNumber;
		}
		set
		{
			ValidateRowNumber(value);
			rowNumber = value;
		}
	}

	public AddressType CellAddressType { get; set; }

	public object Value => value;

	public Cell()
	{
		DataType = CellType.DEFAULT;
	}

	public Cell(object value, CellType type)
	{
		if (type == CellType.EMPTY)
		{
			this.value = null;
		}
		else
		{
			this.value = value;
		}
		DataType = type;
		if (type == CellType.DEFAULT)
		{
			ResolveCellType();
		}
	}

	public Cell(object value, CellType type, int column, int row)
		: this(value, type)
	{
		ColumnNumber = column;
		RowNumber = row;
		CellAddressType = AddressType.Default;
		if (type == CellType.DEFAULT)
		{
			ResolveCellType();
		}
	}

	public int CompareTo(Cell other)
	{
		if (other == null)
		{
			return -1;
		}
		if (RowNumber == other.RowNumber)
		{
			return ColumnNumber.CompareTo(other.ColumnNumber);
		}
		return RowNumber.CompareTo(other.RowNumber);
	}

	public override bool Equals(object obj)
	{
		if (obj == null || obj.GetType() != typeof(Cell))
		{
			return false;
		}
		Cell cell = (Cell)obj;
		if (!CellAddress2.Equals(cell.CellAddress2))
		{
			return false;
		}
		if (cellStyle != null && cell.CellStyle != null && !CellStyle.Equals(cell.CellStyle))
		{
			return false;
		}
		if (DataType != cell.DataType)
		{
			return false;
		}
		if (Value != null && cell.Value != null && !Value.Equals(cell.Value))
		{
			return false;
		}
		return true;
	}

	public void ResolveCellType()
	{
		if (value == null)
		{
			DataType = CellType.EMPTY;
			value = null;
		}
		else if (DataType != CellType.FORMULA)
		{
			Type type = value.GetType();
			if (type == typeof(bool))
			{
				DataType = CellType.BOOL;
			}
			else if (type == typeof(byte) || type == typeof(sbyte))
			{
				DataType = CellType.NUMBER;
			}
			else if (type == typeof(decimal))
			{
				DataType = CellType.NUMBER;
			}
			else if (type == typeof(double))
			{
				DataType = CellType.NUMBER;
			}
			else if (type == typeof(float))
			{
				DataType = CellType.NUMBER;
			}
			else if (type == typeof(int) || type == typeof(uint))
			{
				DataType = CellType.NUMBER;
			}
			else if (type == typeof(long) || type == typeof(ulong))
			{
				DataType = CellType.NUMBER;
			}
			else if (type == typeof(short) || type == typeof(ushort))
			{
				DataType = CellType.NUMBER;
			}
			else if (type == typeof(DateTime))
			{
				DataType = CellType.DATE;
				SetStyle(BasicStyles.DateFormat);
			}
			else if (type == typeof(TimeSpan))
			{
				DataType = CellType.TIME;
				SetStyle(BasicStyles.TimeFormat);
			}
			else
			{
				DataType = CellType.STRING;
			}
		}
	}

	public Style SetStyle(Style style, bool unmanaged = false)
	{
		if (style == null)
		{
			throw new StyleException("No style to assign was defined");
		}
		cellStyle = (unmanaged ? style : StyleRepository.Instance.AddStyle(style));
		return cellStyle;
	}

	public static IEnumerable<Address> GetCellRange(Address startAddress, Address endAddress)
	{
		int column;
		int column2;
		if (startAddress.Column < endAddress.Column)
		{
			column = startAddress.Column;
			column2 = endAddress.Column;
		}
		else
		{
			column = endAddress.Column;
			column2 = startAddress.Column;
		}
		int row;
		int row2;
		if (startAddress.Row < endAddress.Row)
		{
			row = startAddress.Row;
			row2 = endAddress.Row;
		}
		else
		{
			row = endAddress.Row;
			row2 = startAddress.Row;
		}
		List<Address> list = new List<Address>();
		for (int i = column; i <= column2; i++)
		{
			for (int j = row; j <= row2; j++)
			{
				list.Add(new Address(i, j));
			}
		}
		return list;
	}

	public static string ResolveCellAddress(int column, int row, AddressType type = AddressType.Default)
	{
		ValidateColumnNumber(column);
		ValidateRowNumber(row);
		return type switch
		{
			AddressType.FixedRowAndColumn => "$" + ResolveColumnAddress(column) + "$" + (row + 1), 
			AddressType.FixedColumn => "$" + ResolveColumnAddress(column) + (row + 1), 
			AddressType.FixedRow => ResolveColumnAddress(column) + "$" + (row + 1), 
			_ => ResolveColumnAddress(column) + (row + 1), 
		};
	}

	public static string ResolveColumnAddress(int columnNumber)
	{
		ValidateColumnNumber(columnNumber);
		StringBuilder stringBuilder = new StringBuilder();
		for (columnNumber++; columnNumber > 0; columnNumber /= 26)
		{
			columnNumber--;
			stringBuilder.Insert(0, (char)(65 + columnNumber % 26));
		}
		return stringBuilder.ToString();
	}

	public static void ValidateColumnNumber(int column)
	{
		if (column > Worksheet.MAX_COLUMN_NUMBER || column < Worksheet.MIN_COLUMN_NUMBER)
		{
			string[] obj = new string[9]
			{
				"The column number (",
				column.ToString(),
				") is out of range. Range is from ",
				null,
				null,
				null,
				null,
				null,
				null
			};
			int mIN_COLUMN_NUMBER = Worksheet.MIN_COLUMN_NUMBER;
			obj[3] = mIN_COLUMN_NUMBER.ToString();
			obj[4] = " to ";
			mIN_COLUMN_NUMBER = Worksheet.MAX_COLUMN_NUMBER;
			obj[5] = mIN_COLUMN_NUMBER.ToString();
			obj[6] = " (";
			obj[7] = (Worksheet.MAX_COLUMN_NUMBER + 1).ToString();
			obj[8] = " columns).";
			throw new RangeException(string.Concat(obj));
		}
	}

	public static void ValidateRowNumber(int row)
	{
		if (row > Worksheet.MAX_ROW_NUMBER || row < Worksheet.MIN_ROW_NUMBER)
		{
			string[] obj = new string[9]
			{
				"The row number (",
				row.ToString(),
				") is out of range. Range is from ",
				null,
				null,
				null,
				null,
				null,
				null
			};
			int mIN_ROW_NUMBER = Worksheet.MIN_ROW_NUMBER;
			obj[3] = mIN_ROW_NUMBER.ToString();
			obj[4] = " to ";
			mIN_ROW_NUMBER = Worksheet.MAX_ROW_NUMBER;
			obj[5] = mIN_ROW_NUMBER.ToString();
			obj[6] = " (";
			obj[7] = (Worksheet.MAX_ROW_NUMBER + 1).ToString();
			obj[8] = " rows).";
			throw new RangeException(string.Concat(obj));
		}
	}
}
