using System;
using System.Collections.Generic;

namespace NanoXLSX.Styles;

internal class StyleManager
{
	private List<AbstractStyle> borders;

	private List<AbstractStyle> cellXfs;

	private List<AbstractStyle> fills;

	private List<AbstractStyle> fonts;

	private List<AbstractStyle> numberFormats;

	private List<AbstractStyle> styles;

	public StyleManager()
	{
		borders = new List<AbstractStyle>();
		cellXfs = new List<AbstractStyle>();
		fills = new List<AbstractStyle>();
		fonts = new List<AbstractStyle>();
		numberFormats = new List<AbstractStyle>();
		styles = new List<AbstractStyle>();
	}

	private static AbstractStyle GetComponentByHash(ref List<AbstractStyle> list, int hash)
	{
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i].GetHashCode() == hash)
			{
				return list[i];
			}
		}
		return null;
	}

	public Border[] GetBorders()
	{
		return Array.ConvertAll(borders.ToArray(), (AbstractStyle x) => (Border)x);
	}

	public int GetBorderStyleNumber()
	{
		return borders.Count;
	}

	public Fill[] GetFills()
	{
		return Array.ConvertAll(fills.ToArray(), (AbstractStyle x) => (Fill)x);
	}

	public int GetFillStyleNumber()
	{
		return fills.Count;
	}

	public Font[] GetFonts()
	{
		return Array.ConvertAll(fonts.ToArray(), (AbstractStyle x) => (Font)x);
	}

	public int GetFontStyleNumber()
	{
		return fonts.Count;
	}

	public NumberFormat[] GetNumberFormats()
	{
		return Array.ConvertAll(numberFormats.ToArray(), (AbstractStyle x) => (NumberFormat)x);
	}

	public int GetNumberFormatStyleNumber()
	{
		return numberFormats.Count;
	}

	public Style[] GetStyles()
	{
		return Array.ConvertAll(styles.ToArray(), (AbstractStyle x) => (Style)x);
	}

	public int GetStyleNumber()
	{
		return styles.Count;
	}

	public Style AddStyle(Style style)
	{
		int hash = AddStyleComponent(style);
		return (Style)GetComponentByHash(ref styles, hash);
	}

	private int AddStyleComponent(AbstractStyle style, int? id)
	{
		style.InternalID = id;
		return AddStyleComponent(style);
	}

	private int AddStyleComponent(AbstractStyle style)
	{
		int hashCode = style.GetHashCode();
		if (style.GetType() == typeof(Border))
		{
			if (GetComponentByHash(ref borders, hashCode) == null)
			{
				borders.Add(style);
			}
			Reorganize(ref borders);
		}
		else if (style.GetType() == typeof(CellXf))
		{
			if (GetComponentByHash(ref cellXfs, hashCode) == null)
			{
				cellXfs.Add(style);
			}
			Reorganize(ref cellXfs);
		}
		else if (style.GetType() == typeof(Fill))
		{
			if (GetComponentByHash(ref fills, hashCode) == null)
			{
				fills.Add(style);
			}
			Reorganize(ref fills);
		}
		else if (style.GetType() == typeof(Font))
		{
			if (GetComponentByHash(ref fonts, hashCode) == null)
			{
				fonts.Add(style);
			}
			Reorganize(ref fonts);
		}
		else if (style.GetType() == typeof(NumberFormat))
		{
			if (GetComponentByHash(ref numberFormats, hashCode) == null)
			{
				numberFormats.Add(style);
			}
			Reorganize(ref numberFormats);
		}
		else if (style.GetType() == typeof(Style))
		{
			Style style2 = (Style)style;
			if (GetComponentByHash(ref styles, hashCode) == null)
			{
				int? id = (style2.InternalID.HasValue ? new int?(style2.InternalID.Value) : (style2.InternalID = int.MaxValue));
				int hash = AddStyleComponent(style2.CurrentBorder, id);
				style2.CurrentBorder = (Border)GetComponentByHash(ref borders, hash);
				hash = AddStyleComponent(style2.CurrentCellXf, id);
				style2.CurrentCellXf = (CellXf)GetComponentByHash(ref cellXfs, hash);
				hash = AddStyleComponent(style2.CurrentFill, id);
				style2.CurrentFill = (Fill)GetComponentByHash(ref fills, hash);
				hash = AddStyleComponent(style2.CurrentFont, id);
				style2.CurrentFont = (Font)GetComponentByHash(ref fonts, hash);
				hash = AddStyleComponent(style2.CurrentNumberFormat, id);
				style2.CurrentNumberFormat = (NumberFormat)GetComponentByHash(ref numberFormats, hash);
				styles.Add(style2);
			}
			Reorganize(ref styles);
			hashCode = style2.GetHashCode();
		}
		return hashCode;
	}

	internal static StyleManager GetManagedStyles(Workbook workbook)
	{
		StyleManager styleManager = new StyleManager();
		styleManager.AddStyle(new Style("default", 0, internalStyle: true));
		Style style = new Style("default_border_style", 1, internalStyle: true);
		style.CurrentBorder = BasicStyles.DottedFill_0_125.CurrentBorder;
		style.CurrentFill = BasicStyles.DottedFill_0_125.CurrentFill;
		styleManager.AddStyle(style);
		for (int i = 0; i < workbook.Worksheets.Count; i++)
		{
			foreach (KeyValuePair<string, Cell> cell in workbook.Worksheets[i].Cells)
			{
				if (cell.Value.CellStyle != null)
				{
					Style style2 = styleManager.AddStyle(cell.Value.CellStyle);
					workbook.Worksheets[i].Cells[cell.Key].SetStyle(style2, unmanaged: true);
				}
			}
			foreach (KeyValuePair<int, Column> column in workbook.Worksheets[i].Columns)
			{
				if (column.Value.DefaultColumnStyle != null)
				{
					Style defaultColumnStyle = styleManager.AddStyle(column.Value.DefaultColumnStyle);
					workbook.Worksheets[i].Columns[column.Key].SetDefaultColumnStyle(defaultColumnStyle, unmanaged: true);
				}
			}
		}
		return styleManager;
	}

	private static void Reorganize(ref List<AbstractStyle> list)
	{
		int count = list.Count;
		list.Sort();
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			list[i].InternalID = num;
			num++;
		}
	}
}
