using NanoXLSX.Exceptions;
using NanoXLSX.Styles;

namespace NanoXLSX;

public class Column
{
	private int number;

	private string columnAddress;

	private float width;

	private Style defaultColumnStyle;

	public bool HasAutoFilter { get; set; }

	public bool IsHidden { get; }

	public int Number
	{
		set
		{
			columnAddress = Cell.ResolveColumnAddress(value);
			number = value;
		}
	}

	public float Width
	{
		get
		{
			return width;
		}
		set
		{
			if (value < Worksheet.MIN_COLUMN_WIDTH || value > Worksheet.MAX_COLUMN_WIDTH)
			{
				string[] obj = new string[5] { "The passed column width is out of range (", null, null, null, null };
				float mIN_COLUMN_WIDTH = Worksheet.MIN_COLUMN_WIDTH;
				obj[1] = mIN_COLUMN_WIDTH.ToString();
				obj[2] = " to ";
				mIN_COLUMN_WIDTH = Worksheet.MAX_COLUMN_WIDTH;
				obj[3] = mIN_COLUMN_WIDTH.ToString();
				obj[4] = ")";
				throw new RangeException(string.Concat(obj));
			}
			width = value;
		}
	}

	public Style DefaultColumnStyle => defaultColumnStyle;

	public Style SetDefaultColumnStyle(Style defaultColumnStyle, bool unmanaged = false)
	{
		if (defaultColumnStyle == null)
		{
			this.defaultColumnStyle = null;
			return null;
		}
		if (unmanaged)
		{
			this.defaultColumnStyle = defaultColumnStyle;
		}
		else
		{
			this.defaultColumnStyle = StyleRepository.Instance.AddStyle(defaultColumnStyle);
		}
		return this.defaultColumnStyle;
	}

	private Column()
	{
		Width = Worksheet.DEFAULT_COLUMN_WIDTH;
		defaultColumnStyle = null;
	}

	public Column(int columnCoordinate)
		: this()
	{
		Number = columnCoordinate;
	}
}
