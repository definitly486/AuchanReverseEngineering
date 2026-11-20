using System;

namespace NanoXLSX;

public struct Address : IEquatable<Address>, IComparable<Address>
{
	public int Column;

	public int Row;

	public Cell.AddressType Type;

	public Address(int column, int row)
		: this(column, row, Cell.AddressType.Default)
	{
	}

	public Address(int column, int row, Cell.AddressType type)
	{
		Cell.ValidateColumnNumber(column);
		Cell.ValidateRowNumber(row);
		Column = column;
		Row = row;
		Type = type;
	}

	public string GetAddress()
	{
		return Cell.ResolveCellAddress(Column, Row, Type);
	}

	public override string ToString()
	{
		return GetAddress();
	}

	public bool Equals(Address other)
	{
		if (Row == other.Row && Column == other.Column && Type == other.Type)
		{
			return true;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Address))
		{
			return false;
		}
		return Equals((Address)obj);
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}

	public static bool operator ==(Address address1, Address address2)
	{
		return address1.Equals(address2);
	}

	public static bool operator !=(Address address1, Address address2)
	{
		return !address1.Equals(address2);
	}

	public int CompareTo(Address other)
	{
		long num = (long)Column * (long)Worksheet.MAX_ROW_NUMBER + Row;
		long value = (long)other.Column * (long)Worksheet.MAX_ROW_NUMBER + other.Row;
		return num.CompareTo(value);
	}
}
