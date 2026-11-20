using System.Collections.Generic;
using System.Text;
using NanoXLSX.Exceptions;

namespace NanoXLSX.Styles;

public class NumberFormat : AbstractStyle
{
	public enum FormatNumber
	{
		none = 0,
		format_1 = 1,
		format_2 = 2,
		format_3 = 3,
		format_4 = 4,
		format_5 = 5,
		format_6 = 6,
		format_7 = 7,
		format_8 = 8,
		format_9 = 9,
		format_10 = 10,
		format_11 = 11,
		format_12 = 12,
		format_13 = 13,
		format_14 = 14,
		format_15 = 15,
		format_16 = 16,
		format_17 = 17,
		format_18 = 18,
		format_19 = 19,
		format_20 = 20,
		format_21 = 21,
		format_22 = 22,
		format_37 = 37,
		format_38 = 38,
		format_39 = 39,
		format_40 = 40,
		format_45 = 45,
		format_46 = 46,
		format_47 = 47,
		format_48 = 48,
		format_49 = 49,
		custom = 164
	}

	public static readonly int CUSTOMFORMAT_START_NUMBER = 164;

	public static readonly FormatNumber DEFAULT_NUMBER = FormatNumber.none;

	private int customFormatID;

	private string customFormatCode;

	[Append]
	public string CustomFormatCode => customFormatCode;

	[Append]
	public int CustomFormatID
	{
		get
		{
			return customFormatID;
		}
		set
		{
			if (value < CUSTOMFORMAT_START_NUMBER && !StyleRepository.Instance.ImportInProgress)
			{
				string text = value.ToString();
				int cUSTOMFORMAT_START_NUMBER = CUSTOMFORMAT_START_NUMBER;
				throw new StyleException("The number '" + text + "' is not a valid custom format ID. Must be at least " + cUSTOMFORMAT_START_NUMBER);
			}
			customFormatID = value;
		}
	}

	[Append(Ignore = true)]
	public bool IsCustomFormat
	{
		get
		{
			if (Number == FormatNumber.custom)
			{
				return true;
			}
			return false;
		}
	}

	[Append]
	public FormatNumber Number { get; set; }

	public NumberFormat()
	{
		Number = DEFAULT_NUMBER;
		customFormatCode = string.Empty;
		CustomFormatID = CUSTOMFORMAT_START_NUMBER;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\"NumberFormat\": {\n");
		AbstractStyle.AddPropertyAsJson(stringBuilder, "CustomFormatCode", CustomFormatCode);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "CustomFormatID", CustomFormatID);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Number", Number);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "HashCode", GetHashCode(), terminate: true);
		stringBuilder.Append("\n}");
		return stringBuilder.ToString();
	}

	public override AbstractStyle Copy()
	{
		return new NumberFormat
		{
			customFormatCode = customFormatCode,
			CustomFormatID = CustomFormatID,
			Number = Number
		};
	}

	public NumberFormat CopyNumberFormat()
	{
		return (NumberFormat)Copy();
	}

	public override int GetHashCode()
	{
		return ((495605284 * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomFormatCode)) * -1521134295 + CustomFormatID.GetHashCode()) * -1521134295 + Number.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is NumberFormat numberFormat && CustomFormatCode == numberFormat.CustomFormatCode && CustomFormatID == numberFormat.CustomFormatID)
		{
			return Number == numberFormat.Number;
		}
		return false;
	}
}
