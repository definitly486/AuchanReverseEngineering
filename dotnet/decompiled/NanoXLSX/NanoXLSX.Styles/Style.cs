using System.Text;
using NanoXLSX.Exceptions;

namespace NanoXLSX.Styles;

public class Style : AbstractStyle
{
	private bool internalStyle;

	[Append(NestedProperty = true)]
	public Border CurrentBorder { get; set; }

	[Append(NestedProperty = true)]
	public CellXf CurrentCellXf { get; set; }

	[Append(NestedProperty = true)]
	public Fill CurrentFill { get; set; }

	[Append(NestedProperty = true)]
	public Font CurrentFont { get; set; }

	[Append(NestedProperty = true)]
	public NumberFormat CurrentNumberFormat { get; set; }

	[Append(Ignore = true)]
	public string Name { get; set; }

	public Style()
	{
		CurrentBorder = new Border();
		CurrentCellXf = new CellXf();
		CurrentFill = new Fill();
		CurrentFont = new Font();
		CurrentNumberFormat = new NumberFormat();
		Name = GetHashCode().ToString();
	}

	public Style(string name, int forcedOrder, bool internalStyle)
	{
		CurrentBorder = new Border();
		CurrentCellXf = new CellXf();
		CurrentFill = new Fill();
		CurrentFont = new Font();
		CurrentNumberFormat = new NumberFormat();
		Name = name;
		base.InternalID = forcedOrder;
		this.internalStyle = internalStyle;
	}

	public Style Append(AbstractStyle styleToAppend)
	{
		if (styleToAppend == null)
		{
			return this;
		}
		if (styleToAppend.GetType() == typeof(Border))
		{
			CurrentBorder.CopyProperties((Border)styleToAppend, new Border());
		}
		else if (styleToAppend.GetType() == typeof(CellXf))
		{
			CurrentCellXf.CopyProperties((CellXf)styleToAppend, new CellXf());
		}
		else if (styleToAppend.GetType() == typeof(Fill))
		{
			CurrentFill.CopyProperties((Fill)styleToAppend, new Fill());
		}
		else if (styleToAppend.GetType() == typeof(Font))
		{
			CurrentFont.CopyProperties((Font)styleToAppend, new Font());
		}
		else if (styleToAppend.GetType() == typeof(NumberFormat))
		{
			CurrentNumberFormat.CopyProperties((NumberFormat)styleToAppend, new NumberFormat());
		}
		else if (styleToAppend.GetType() == typeof(Style))
		{
			CurrentBorder.CopyProperties(((Style)styleToAppend).CurrentBorder, new Border());
			CurrentCellXf.CopyProperties(((Style)styleToAppend).CurrentCellXf, new CellXf());
			CurrentFill.CopyProperties(((Style)styleToAppend).CurrentFill, new Fill());
			CurrentFont.CopyProperties(((Style)styleToAppend).CurrentFont, new Font());
			CurrentNumberFormat.CopyProperties(((Style)styleToAppend).CurrentNumberFormat, new NumberFormat());
		}
		return this;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{\n\"Style\": {\n");
		AbstractStyle.AddPropertyAsJson(stringBuilder, "Name", Name);
		AbstractStyle.AddPropertyAsJson(stringBuilder, "HashCode", GetHashCode());
		stringBuilder.Append(CurrentBorder.ToString()).Append(",\n");
		stringBuilder.Append(CurrentCellXf.ToString()).Append(",\n");
		stringBuilder.Append(CurrentFill.ToString()).Append(",\n");
		stringBuilder.Append(CurrentFont.ToString()).Append(",\n");
		stringBuilder.Append(CurrentNumberFormat.ToString()).Append("\n}\n}");
		return stringBuilder.ToString();
	}

	public override int GetHashCode()
	{
		if (CurrentBorder == null || CurrentCellXf == null || CurrentFill == null || CurrentFont == null || CurrentNumberFormat == null)
		{
			throw new StyleException("The hash of the style could not be created because one or more components are missing as references");
		}
		int num = 241;
		return 1 * (num + CurrentBorder.GetHashCode()) * (num + CurrentCellXf.GetHashCode()) * (num + CurrentFill.GetHashCode()) * (num + CurrentFont.GetHashCode()) * (num + CurrentNumberFormat.GetHashCode());
	}

	public override AbstractStyle Copy()
	{
		if (CurrentBorder == null || CurrentCellXf == null || CurrentFill == null || CurrentFont == null || CurrentNumberFormat == null)
		{
			throw new StyleException("The style could not be copied because one or more components are missing as references");
		}
		return new Style
		{
			CurrentBorder = CurrentBorder.CopyBorder(),
			CurrentCellXf = CurrentCellXf.CopyCellXf(),
			CurrentFill = CurrentFill.CopyFill(),
			CurrentFont = CurrentFont.CopyFont(),
			CurrentNumberFormat = CurrentNumberFormat.CopyNumberFormat()
		};
	}

	public Style CopyStyle()
	{
		return (Style)Copy();
	}
}
