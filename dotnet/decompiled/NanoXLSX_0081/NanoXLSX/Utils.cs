using System;
using System.Globalization;
using NanoXLSX.Exceptions;

namespace NanoXLSX;

public static class Utils
{
	public static readonly double MIN_OADATE_VALUE = 0.0;

	public static readonly double MAX_OADATE_VALUE = 2958465.999988426;

	public static readonly DateTime FIRST_ALLOWED_EXCEL_DATE = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

	public static readonly DateTime LAST_ALLOWED_EXCEL_DATE = new DateTime(9999, 12, 31, 23, 59, 59, DateTimeKind.Unspecified);

	public static readonly DateTime FIRST_VALID_EXCEL_DATE = new DateTime(1900, 3, 1, 0, 0, 0, DateTimeKind.Unspecified);

	public static readonly CultureInfo INVARIANT_CULTURE = CultureInfo.InvariantCulture;

	private static readonly DateTime ROOT_DATE = new DateTime(1899, 12, 30, 0, 0, 0, DateTimeKind.Unspecified);

	private static readonly double ROOT_MILLIS = (double)new DateTime(1899, 12, 30, 0, 0, 0, DateTimeKind.Unspecified).Ticks / 10000.0;

	public static string GetOADateTimeString(DateTime date)
	{
		return GetOADateTime(date).ToString("G", INVARIANT_CULTURE);
	}

	public static double GetOADateTime(DateTime date, bool skipCheck = false)
	{
		if (!skipCheck && (date < FIRST_ALLOWED_EXCEL_DATE || date > LAST_ALLOWED_EXCEL_DATE))
		{
			throw new NanoXLSX.Exceptions.FormatException("The date is not in a valid range for Excel. Dates before 1900-01-01 or after 9999-12-31 are not allowed.");
		}
		DateTime dateTime = date;
		if (date < FIRST_VALID_EXCEL_DATE)
		{
			dateTime = date.AddDays(-1.0);
		}
		double num = (double)dateTime.Ticks / 10000.0;
		return (double)(dateTime.Second + dateTime.Minute * 60 + dateTime.Hour * 3600) / 86400.0 + Math.Floor((num - ROOT_MILLIS) / 86400000.0);
	}

	public static string GetOATimeString(TimeSpan time)
	{
		return GetOATime(time).ToString("G", INVARIANT_CULTURE);
	}

	public static double GetOATime(TimeSpan time)
	{
		int num = time.Seconds + time.Minutes * 60 + time.Hours * 3600;
		return (double)time.Days + (double)num / 86400.0;
	}

	public static string ToString(int input)
	{
		return input.ToString("G", INVARIANT_CULTURE);
	}

	public static float GetInternalColumnWidth(float columnWidth, float maxDigitWidth = 7f, float textPadding = 5f)
	{
		if (columnWidth < Worksheet.MIN_COLUMN_WIDTH || columnWidth > Worksheet.MAX_COLUMN_WIDTH)
		{
			string[] obj = new string[6]
			{
				"The column width ",
				columnWidth.ToString(),
				" is not valid. The valid range is between ",
				null,
				null,
				null
			};
			float mIN_COLUMN_WIDTH = Worksheet.MIN_COLUMN_WIDTH;
			obj[3] = mIN_COLUMN_WIDTH.ToString();
			obj[4] = " and ";
			mIN_COLUMN_WIDTH = Worksheet.MAX_COLUMN_WIDTH;
			obj[5] = mIN_COLUMN_WIDTH.ToString();
			throw new NanoXLSX.Exceptions.FormatException(string.Concat(obj));
		}
		if (columnWidth <= 0f || maxDigitWidth <= 0f)
		{
			return 0f;
		}
		if (columnWidth <= 1f)
		{
			return (float)Math.Floor(columnWidth * (maxDigitWidth + textPadding) / maxDigitWidth * 256f) / 256f;
		}
		return (float)Math.Floor((columnWidth * maxDigitWidth + textPadding) / maxDigitWidth * 256f) / 256f;
	}

	public static float GetInternalRowHeight(float rowHeight)
	{
		if (rowHeight < Worksheet.MIN_ROW_HEIGHT || rowHeight > Worksheet.MAX_ROW_HEIGHT)
		{
			string[] obj = new string[6]
			{
				"The row height ",
				rowHeight.ToString(),
				" is not valid. The valid range is between ",
				null,
				null,
				null
			};
			float mIN_ROW_HEIGHT = Worksheet.MIN_ROW_HEIGHT;
			obj[3] = mIN_ROW_HEIGHT.ToString();
			obj[4] = " and ";
			mIN_ROW_HEIGHT = Worksheet.MAX_ROW_HEIGHT;
			obj[5] = mIN_ROW_HEIGHT.ToString();
			throw new NanoXLSX.Exceptions.FormatException(string.Concat(obj));
		}
		if (rowHeight == 0f)
		{
			return 0f;
		}
		return (float)Math.Round(rowHeight * 1.3333334f) / 1.3333334f;
	}

	public static float GetInternalPaneSplitWidth(float width, float maxDigitWidth = 7f, float textPadding = 5f)
	{
		float num;
		if (width <= 1f)
		{
			width = 0f;
			num = (float)Math.Floor(width / 12f + 0.5f);
		}
		else
		{
			num = (float)Math.Floor(width * maxDigitWidth + 0.5f) + textPadding;
		}
		return num * 0.75f * 20f + 390f;
	}

	public static float GetInternalPaneSplitHeight(float height)
	{
		if (height < 0f)
		{
			height = 0f;
		}
		return (float)Math.Floor(20f * height + 300f);
	}
}
