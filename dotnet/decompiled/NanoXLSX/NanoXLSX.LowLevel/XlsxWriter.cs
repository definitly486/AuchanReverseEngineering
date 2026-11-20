using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Xml;
using NanoXLSX.Exceptions;
using NanoXLSX.Styles;

namespace NanoXLSX.LowLevel;

internal class XlsxWriter
{
	private sealed class DynamicRow
	{
		private readonly List<Cell> cellDefinitions;

		public int RowNumber { get; set; }

		public List<Cell> CellDefinitions => cellDefinitions;

		public DynamicRow()
		{
			cellDefinitions = new List<Cell>();
		}
	}

	private static DocumentPath WORKBOOK = new DocumentPath("workbook.xml", "xl/");

	private static DocumentPath STYLES = new DocumentPath("styles.xml", "xl/");

	private static DocumentPath APP_PROPERTIES = new DocumentPath("app.xml", "docProps/");

	private static DocumentPath CORE_PROPERTIES = new DocumentPath("core.xml", "docProps/");

	private static DocumentPath SHARED_STRINGS = new DocumentPath("sharedStrings.xml", "xl/");

	private CultureInfo culture;

	private Workbook workbook;

	private StyleManager styles;

	private SortedMap sharedStrings;

	private int sharedStringsTotalCount;

	public XlsxWriter(Workbook workbook)
	{
		culture = CultureInfo.InvariantCulture;
		this.workbook = workbook;
		sharedStrings = new SortedMap();
		sharedStringsTotalCount = 0;
	}

	private string CreateAppPropertiesDocument()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<Properties xmlns=\"http://schemas.openxmlformats.org/officeDocument/2006/extended-properties\" xmlns:vt=\"http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes\">");
		stringBuilder.Append(CreateAppString());
		stringBuilder.Append("</Properties>");
		return stringBuilder.ToString();
	}

	private string CreateCorePropertiesDocument()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<cp:coreProperties xmlns:cp=\"http://schemas.openxmlformats.org/package/2006/metadata/core-properties\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:dcterms=\"http://purl.org/dc/terms/\" xmlns:dcmitype=\"http://purl.org/dc/dcmitype/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
		stringBuilder.Append(CreateCorePropertiesString());
		stringBuilder.Append("</cp:coreProperties>");
		return stringBuilder.ToString();
	}

	private string CreateSharedStringsDocument()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<sst xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" count=\"");
		stringBuilder.Append(sharedStringsTotalCount.ToString("G", culture));
		stringBuilder.Append("\" uniqueCount=\"");
		stringBuilder.Append(sharedStrings.Count.ToString("G", culture));
		stringBuilder.Append("\">");
		foreach (string key in sharedStrings.Keys)
		{
			AppendSharedString(stringBuilder, EscapeXmlChars(key));
		}
		stringBuilder.Append("</sst>");
		return stringBuilder.ToString();
	}

	private void AppendSharedString(StringBuilder sb, string value)
	{
		int length = value.Length;
		sb.Append("<si>");
		if (length == 0)
		{
			sb.Append("<t></t>");
		}
		else
		{
			if (char.IsWhiteSpace(value, 0) || char.IsWhiteSpace(value, length - 1))
			{
				sb.Append("<t xml:space=\"preserve\">");
			}
			else
			{
				sb.Append("<t>");
			}
			sb.Append(NormalizeNewLines(value)).Append("</t>");
		}
		sb.Append("</si>");
	}

	private string NormalizeNewLines(string value)
	{
		if (value == null || (!Enumerable.Contains(value, '\n') && !Enumerable.Contains(value, '\r')))
		{
			return value;
		}
		return value.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
	}

	private string CreateStyleSheetDocument()
	{
		string value = CreateStyleBorderString();
		string value2 = CreateStyleFillString();
		string value3 = CreateStyleFontString();
		string text = CreateStyleNumberFormatString();
		string value4 = CreateStyleXfsString();
		string value5 = CreateMruColorsString();
		int fontStyleNumber = styles.GetFontStyleNumber();
		int fillStyleNumber = styles.GetFillStyleNumber();
		int styleNumber = styles.GetStyleNumber();
		int borderStyleNumber = styles.GetBorderStyleNumber();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<styleSheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" mc:Ignorable=\"x14ac\" xmlns:x14ac=\"http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac\">");
		int numberFormatStyleNumber = styles.GetNumberFormatStyleNumber();
		if (numberFormatStyleNumber > 0)
		{
			stringBuilder.Append("<numFmts count=\"").Append(numberFormatStyleNumber.ToString("G", culture)).Append("\">");
			stringBuilder.Append(text + "</numFmts>");
		}
		stringBuilder.Append("<fonts x14ac:knownFonts=\"1\" count=\"").Append(fontStyleNumber.ToString("G", culture)).Append("\">");
		stringBuilder.Append(value3).Append("</fonts>");
		stringBuilder.Append("<fills count=\"").Append(fillStyleNumber.ToString("G", culture)).Append("\">");
		stringBuilder.Append(value2).Append("</fills>");
		stringBuilder.Append("<borders count=\"").Append(borderStyleNumber.ToString("G", culture)).Append("\">");
		stringBuilder.Append(value).Append("</borders>");
		stringBuilder.Append("<cellXfs count=\"").Append(styleNumber.ToString("G", culture)).Append("\">");
		stringBuilder.Append(value4).Append("</cellXfs>");
		if (workbook.WorkbookMetadata != null && !string.IsNullOrEmpty(value5))
		{
			stringBuilder.Append("<colors>");
			stringBuilder.Append(value5);
			stringBuilder.Append("</colors>");
		}
		stringBuilder.Append("</styleSheet>");
		return stringBuilder.ToString();
	}

	private string CreateWorkbookDocument()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<workbook xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">");
		if (workbook.SelectedWorksheet > 0 || workbook.Hidden || workbook.Worksheets.Any((Worksheet x) => HasPaneSplitting(x)))
		{
			stringBuilder.Append("<bookViews><workbookView ");
			if (workbook.Hidden)
			{
				stringBuilder.Append("visibility=\"hidden\"");
			}
			else
			{
				stringBuilder.Append("activeTab=\"").Append(workbook.SelectedWorksheet.ToString("G", culture)).Append("\"");
			}
			stringBuilder.Append("/></bookViews>");
		}
		CreateWorkbookProtectionString(stringBuilder);
		stringBuilder.Append("<sheets>");
		if (workbook.Worksheets.Count > 0)
		{
			foreach (Worksheet worksheet in workbook.Worksheets)
			{
				stringBuilder.Append("<sheet r:id=\"rId").Append(worksheet.SheetID.ToString()).Append("\" sheetId=\"")
					.Append(worksheet.SheetID.ToString())
					.Append("\" name=\"")
					.Append(EscapeXmlAttributeChars(worksheet.SheetName))
					.Append("\"");
				if (worksheet.Hidden)
				{
					stringBuilder.Append(" state=\"hidden\"");
				}
				stringBuilder.Append("/>");
			}
		}
		else
		{
			stringBuilder.Append("<sheet r:id=\"rId1\" sheetId=\"1\" name=\"sheet1\"/>");
		}
		stringBuilder.Append("</sheets>");
		stringBuilder.Append("</workbook>");
		return stringBuilder.ToString();
	}

	private void CreateWorkbookProtectionString(StringBuilder sb)
	{
		if (workbook.UseWorkbookProtection)
		{
			sb.Append("<workbookProtection");
			if (workbook.LockWindowsIfProtected)
			{
				sb.Append(" lockWindows=\"1\"");
			}
			if (workbook.LockStructureIfProtected)
			{
				sb.Append(" lockStructure=\"1\"");
			}
			if (!string.IsNullOrEmpty(workbook.WorkbookProtectionPassword))
			{
				sb.Append(" workbookPassword=\"");
				sb.Append(workbook.WorkbookProtectionPasswordHash);
				sb.Append("\"");
			}
			sb.Append("/>");
		}
	}

	private string CreateWorksheetPart(Worksheet worksheet)
	{
		worksheet.RecalculateAutoFilter();
		worksheet.RecalculateColumns();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" mc:Ignorable=\"x14ac\" xmlns:x14ac=\"http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac\">");
		if (worksheet.GetLastCellAddress().HasValue && worksheet.GetFirstCellAddress().HasValue)
		{
			stringBuilder.Append("<dimension ref=\"").Append(new Range(worksheet.GetFirstCellAddress().Value, worksheet.GetLastCellAddress().Value)).Append("\"/>");
		}
		if (worksheet.SelectedCellRanges.Count > 0 || worksheet.PaneSplitTopHeight.HasValue || worksheet.PaneSplitLeftWidth.HasValue || worksheet.PaneSplitAddress.HasValue || worksheet.Hidden || worksheet.ZoomFactor != 100 || worksheet.ZoomFactors.Count > 1 || !worksheet.ShowGridLines || !worksheet.ShowRuler || !worksheet.ShowRowColumnHeaders || worksheet.ViewType != Worksheet.SheetViewType.normal)
		{
			CreateSheetViewString(worksheet, stringBuilder);
		}
		stringBuilder.Append("<sheetFormatPr");
		if (!HasPaneSplitting(worksheet))
		{
			stringBuilder.Append(" defaultColWidth=\"").Append(worksheet.DefaultColumnWidth.ToString("G", culture)).Append("\"");
		}
		stringBuilder.Append(" defaultRowHeight=\"").Append(worksheet.DefaultRowHeight.ToString("G", culture)).Append("\" baseColWidth=\"")
			.Append(worksheet.DefaultColumnWidth.ToString("G", culture))
			.Append("\" x14ac:dyDescent=\"0.25\"/>");
		string value = CreateColsString(worksheet);
		if (!string.IsNullOrEmpty(value))
		{
			stringBuilder.Append("<cols>");
			stringBuilder.Append(value);
			stringBuilder.Append("</cols>");
		}
		stringBuilder.Append("<sheetData>");
		CreateRowsString(worksheet, stringBuilder);
		stringBuilder.Append("</sheetData>");
		stringBuilder.Append(CreateMergedCellsString(worksheet));
		stringBuilder.Append(CreateSheetProtectionString(worksheet));
		if (worksheet.AutoFilterRange.HasValue)
		{
			stringBuilder.Append("<autoFilter ref=\"").Append(worksheet.AutoFilterRange.Value.ToString()).Append("\"/>");
		}
		stringBuilder.Append("</worksheet>");
		return stringBuilder.ToString();
	}

	private bool HasPaneSplitting(Worksheet worksheet)
	{
		if (!worksheet.PaneSplitLeftWidth.HasValue && !worksheet.PaneSplitTopHeight.HasValue && !worksheet.PaneSplitAddress.HasValue)
		{
			return false;
		}
		return true;
	}

	private void CreateRowsString(Worksheet worksheet, StringBuilder sb)
	{
		foreach (DynamicRow sortedSheetDatum in GetSortedSheetData(worksheet))
		{
			string value = CreateRowString(sortedSheetDatum, worksheet);
			sb.Append(value);
		}
	}

	private void CreateSheetViewString(Worksheet worksheet, StringBuilder sb)
	{
		sb.Append("<sheetViews><sheetView workbookViewId=\"0\"");
		if (workbook.SelectedWorksheet == worksheet.SheetID - 1 && !worksheet.Hidden)
		{
			sb.Append(" tabSelected=\"1\"");
		}
		if (worksheet.ViewType != Worksheet.SheetViewType.normal)
		{
			if (worksheet.ViewType == Worksheet.SheetViewType.pageLayout)
			{
				if (worksheet.ShowRuler)
				{
					sb.Append(" showRuler=\"1\"");
				}
				else
				{
					sb.Append(" showRuler=\"0\"");
				}
				sb.Append(" view=\"pageLayout\"");
			}
			else if (worksheet.ViewType == Worksheet.SheetViewType.pageBreakPreview)
			{
				sb.Append(" view=\"pageBreakPreview\"");
			}
		}
		if (!worksheet.ShowGridLines)
		{
			sb.Append(" showGridLines=\"0\"");
		}
		if (!worksheet.ShowRowColumnHeaders)
		{
			sb.Append("  showRowColHeaders=\"0\"");
		}
		sb.Append(" zoomScale=\"").Append(worksheet.ZoomFactor.ToString("G", culture)).Append("\"");
		foreach (KeyValuePair<Worksheet.SheetViewType, int> zoomFactor in worksheet.ZoomFactors)
		{
			if (zoomFactor.Key != worksheet.ViewType)
			{
				if (zoomFactor.Key == Worksheet.SheetViewType.normal)
				{
					sb.Append(" zoomScaleNormal=\"").Append(zoomFactor.Value.ToString("G", culture)).Append("\"");
				}
				else if (zoomFactor.Key == Worksheet.SheetViewType.pageBreakPreview)
				{
					sb.Append(" zoomScaleSheetLayoutView=\"").Append(zoomFactor.Value.ToString("G", culture)).Append("\"");
				}
				else if (zoomFactor.Key == Worksheet.SheetViewType.pageLayout)
				{
					sb.Append(" zoomScalePageLayoutView=\"").Append(zoomFactor.Value.ToString("G", culture)).Append("\"");
				}
			}
		}
		sb.Append(">");
		CreatePaneString(worksheet, sb);
		if (worksheet.SelectedCellRanges.Count > 0)
		{
			sb.Append("<selection sqref=\"");
			for (int i = 0; i < worksheet.SelectedCellRanges.Count; i++)
			{
				sb.Append(worksheet.SelectedCellRanges[i].ToString());
				if (i < worksheet.SelectedCellRanges.Count - 1)
				{
					sb.Append(" ");
				}
			}
			sb.Append("\" activeCell=\"");
			sb.Append(worksheet.SelectedCellRanges[0].StartAddress.ToString());
			sb.Append("\"/>");
		}
		sb.Append("</sheetView></sheetViews>");
	}

	private void CreatePaneString(Worksheet worksheet, StringBuilder sb)
	{
		if (!HasPaneSplitting(worksheet))
		{
			return;
		}
		sb.Append("<pane");
		bool flag = false;
		bool flag2 = false;
		if (worksheet.PaneSplitAddress.HasValue)
		{
			bool flag3 = worksheet.FreezeSplitPanes.HasValue && worksheet.FreezeSplitPanes.Value;
			int column = worksheet.PaneSplitAddress.Value.Column;
			int row = worksheet.PaneSplitAddress.Value.Row;
			if (column > 0)
			{
				if (flag3)
				{
					sb.Append(" xSplit=\"").Append(Utils.ToString(column)).Append("\"");
				}
				else
				{
					sb.Append(" xSplit=\"").Append(CalculatePaneWidth(worksheet, column).ToString("G", culture)).Append("\"");
				}
				flag = true;
			}
			if (row > 0)
			{
				if (flag3)
				{
					sb.Append(" ySplit=\"").Append(Utils.ToString(row)).Append("\"");
				}
				else
				{
					sb.Append(" ySplit=\"").Append(CalculatePaneHeight(worksheet, row).ToString("G", culture)).Append("\"");
				}
				flag2 = true;
			}
			if (flag3 && flag && flag2)
			{
				sb.Append(" state=\"frozenSplit\"");
			}
			else if (flag3)
			{
				sb.Append(" state=\"frozen\"");
			}
		}
		else
		{
			if (worksheet.PaneSplitLeftWidth.HasValue)
			{
				sb.Append(" xSplit=\"").Append(Utils.GetInternalPaneSplitWidth(worksheet.PaneSplitLeftWidth.Value).ToString("G", culture)).Append("\"");
				flag = true;
			}
			if (worksheet.PaneSplitTopHeight.HasValue)
			{
				sb.Append(" ySplit=\"").Append(Utils.GetInternalPaneSplitHeight(worksheet.PaneSplitTopHeight.Value).ToString("G", culture)).Append("\"");
				flag2 = true;
			}
		}
		if ((flag || flag2) && worksheet.ActivePane.HasValue)
		{
			switch (worksheet.ActivePane.Value)
			{
			case Worksheet.WorksheetPane.bottomLeft:
				sb.Append(" activePane=\"bottomLeft\"");
				break;
			case Worksheet.WorksheetPane.bottomRight:
				sb.Append(" activePane=\"bottomRight\"");
				break;
			case Worksheet.WorksheetPane.topLeft:
				sb.Append(" activePane=\"topLeft\"");
				break;
			case Worksheet.WorksheetPane.topRight:
				sb.Append(" activePane=\"topRight\"");
				break;
			}
		}
		string address = worksheet.PaneSplitTopLeftCell.Value.GetAddress();
		sb.Append(" topLeftCell=\"").Append(address).Append("\" ");
		sb.Append("/>");
		if (flag && !flag2)
		{
			sb.Append("<selection pane=\"topRight\" activeCell=\"" + address + "\"  sqref=\"" + address + "\" />");
		}
		else if (flag2 && !flag)
		{
			sb.Append("<selection pane=\"bottomLeft\" activeCell=\"" + address + "\"  sqref=\"" + address + "\" />");
		}
		else if (flag2 && flag)
		{
			sb.Append("<selection activeCell=\"" + address + "\"  sqref=\"" + address + "\" />");
		}
	}

	private float CalculatePaneHeight(Worksheet worksheet, int numberOfRows)
	{
		float num = 0f;
		for (int i = 0; i < numberOfRows; i++)
		{
			num = ((!worksheet.RowHeights.ContainsKey(i)) ? (num + Utils.GetInternalRowHeight(Worksheet.DEFAULT_ROW_HEIGHT)) : (num + Utils.GetInternalRowHeight(worksheet.RowHeights[i])));
		}
		return Utils.GetInternalPaneSplitHeight(num);
	}

	private float CalculatePaneWidth(Worksheet worksheet, int numberOfColumns)
	{
		float num = 0f;
		for (int i = 0; i < numberOfColumns; i++)
		{
			num = ((!worksheet.Columns.ContainsKey(i)) ? (num + Utils.GetInternalColumnWidth(Worksheet.DEFAULT_COLUMN_WIDTH)) : (num + Utils.GetInternalColumnWidth(worksheet.Columns[i].Width)));
		}
		return Utils.GetInternalPaneSplitWidth(num) + (float)(numberOfColumns - 1) * 0f;
	}

	public void Save()
	{
		try
		{
			FileStream stream = new FileStream(workbook.Filename, FileMode.Create);
			SaveAsStream(stream);
		}
		catch (Exception ex)
		{
			throw new NanoXLSX.Exceptions.IOException("An error occurred while saving. See inner exception for details: " + ex.Message, ex);
		}
	}

	public void SaveAsStream(Stream stream, bool leaveOpen = false)
	{
		workbook.ResolveMergedCells();
		styles = StyleManager.GetManagedStyles(workbook);
		List<Uri> list = new List<Uri>();
		try
		{
			using Package package = Package.Open(stream, FileMode.Create);
			Uri partUri = new Uri(WORKBOOK.GetFullPath(), UriKind.Relative);
			Uri uri = new Uri(STYLES.GetFullPath(), UriKind.Relative);
			Uri uri2 = new Uri(APP_PROPERTIES.GetFullPath(), UriKind.Relative);
			Uri uri3 = new Uri(CORE_PROPERTIES.GetFullPath(), UriKind.Relative);
			Uri uri4 = new Uri(SHARED_STRINGS.GetFullPath(), UriKind.Relative);
			PackagePart packagePart = package.CreatePart(partUri, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml", CompressionOption.Normal);
			package.CreateRelationship(packagePart.Uri, TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument", "rId1");
			package.CreateRelationship(uri3, TargetMode.Internal, "http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties", "rId2");
			package.CreateRelationship(uri2, TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties", "rId3");
			AppendXmlToPackagePart(CreateWorkbookDocument(), packagePart);
			int num = ((workbook.Worksheets.Count <= 0) ? 2 : (workbook.Worksheets.Count + 1));
			packagePart.CreateRelationship(uri, TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles", "rId" + num);
			packagePart.CreateRelationship(uri4, TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/sharedStrings", "rId" + (num + 1));
			if (workbook.Worksheets.Count > 0)
			{
				foreach (Worksheet worksheet in workbook.Worksheets)
				{
					DocumentPath documentPath = new DocumentPath("sheet" + worksheet.SheetID + ".xml", "xl/worksheets");
					list.Add(new Uri(documentPath.GetFullPath(), UriKind.Relative));
					packagePart.CreateRelationship(list[list.Count - 1], TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet", "rId" + worksheet.SheetID);
				}
			}
			else
			{
				DocumentPath documentPath = new DocumentPath("sheet1.xml", "xl/worksheets");
				list.Add(new Uri(documentPath.GetFullPath(), UriKind.Relative));
				packagePart.CreateRelationship(list[list.Count - 1], TargetMode.Internal, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet", "rId1");
			}
			packagePart = package.CreatePart(uri, "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml", CompressionOption.Normal);
			AppendXmlToPackagePart(CreateStyleSheetDocument(), packagePart);
			int num2 = 0;
			if (workbook.Worksheets.Count > 0)
			{
				foreach (Worksheet worksheet2 in workbook.Worksheets)
				{
					packagePart = package.CreatePart(list[num2], "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml", CompressionOption.Normal);
					num2++;
					AppendXmlToPackagePart(CreateWorksheetPart(worksheet2), packagePart);
				}
			}
			else
			{
				packagePart = package.CreatePart(list[num2], "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml", CompressionOption.Normal);
				num2++;
				AppendXmlToPackagePart(CreateWorksheetPart(new Worksheet("sheet1")), packagePart);
			}
			packagePart = package.CreatePart(uri4, "application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml", CompressionOption.Normal);
			AppendXmlToPackagePart(CreateSharedStringsDocument(), packagePart);
			if (workbook.WorkbookMetadata != null)
			{
				packagePart = package.CreatePart(uri2, "application/vnd.openxmlformats-officedocument.extended-properties+xml", CompressionOption.Normal);
				AppendXmlToPackagePart(CreateAppPropertiesDocument(), packagePart);
				packagePart = package.CreatePart(uri3, "application/vnd.openxmlformats-package.core-properties+xml", CompressionOption.Normal);
				AppendXmlToPackagePart(CreateCorePropertiesDocument(), packagePart);
			}
			package.Flush();
			package.Close();
			if (!leaveOpen)
			{
				stream.Close();
			}
		}
		catch (Exception ex)
		{
			throw new NanoXLSX.Exceptions.IOException("An error occurred while saving. See inner exception for details: " + ex.Message, ex);
		}
	}

	private void AppendXmlTag(StringBuilder sb, string value, string tagName, string nameSpace)
	{
		if (!string.IsNullOrEmpty(value))
		{
			bool num = string.IsNullOrEmpty(nameSpace);
			sb.Append('<');
			if (!num)
			{
				sb.Append(nameSpace);
				sb.Append(':');
			}
			sb.Append(tagName).Append(">");
			sb.Append(EscapeXmlChars(value));
			sb.Append("</");
			if (!num)
			{
				sb.Append(nameSpace);
				sb.Append(':');
			}
			sb.Append(tagName);
			sb.Append('>');
		}
	}

	private void AppendXmlToPackagePart(string doc, PackagePart pp)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using XmlWriter xmlWriter = XmlWriter.Create(memoryStream);
		xmlWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"");
		xmlWriter.WriteRaw(doc);
		xmlWriter.Flush();
		memoryStream.Position = 0L;
		memoryStream.CopyTo(pp.GetStream());
		memoryStream.Flush();
	}

	private string CreateAppString()
	{
		Metadata workbookMetadata = workbook.WorkbookMetadata;
		StringBuilder stringBuilder = new StringBuilder();
		AppendXmlTag(stringBuilder, "0", "TotalTime", null);
		AppendXmlTag(stringBuilder, workbookMetadata.Application, "Application", null);
		AppendXmlTag(stringBuilder, "0", "DocSecurity", null);
		AppendXmlTag(stringBuilder, "false", "ScaleCrop", null);
		AppendXmlTag(stringBuilder, workbookMetadata.Manager, "Manager", null);
		AppendXmlTag(stringBuilder, workbookMetadata.Company, "Company", null);
		AppendXmlTag(stringBuilder, "false", "LinksUpToDate", null);
		AppendXmlTag(stringBuilder, "false", "SharedDoc", null);
		AppendXmlTag(stringBuilder, workbookMetadata.HyperlinkBase, "HyperlinkBase", null);
		AppendXmlTag(stringBuilder, "false", "HyperlinksChanged", null);
		AppendXmlTag(stringBuilder, workbookMetadata.ApplicationVersion, "AppVersion", null);
		return stringBuilder.ToString();
	}

	private string CreateColsString(Worksheet worksheet)
	{
		if (worksheet.Columns.Count > 0)
		{
			string value = "";
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, Column> column in worksheet.Columns)
			{
				if (!(Math.Abs(column.Value.Width - worksheet.DefaultColumnWidth) < 0.0001f) || column.Value.IsHidden || column.Value.DefaultColumnStyle != null)
				{
					if (worksheet.Columns.ContainsKey(column.Key) && worksheet.Columns[column.Key].IsHidden)
					{
						value = " hidden=\"1\"";
					}
					string value2 = (column.Key + 1).ToString("G", culture);
					float internalColumnWidth = Utils.GetInternalColumnWidth(column.Value.Width);
					stringBuilder.Append("<col customWidth=\"1\" width=\"").Append(internalColumnWidth.ToString("G", culture)).Append("\" max=\"")
						.Append(value2)
						.Append("\" min=\"")
						.Append(value2)
						.Append("\"");
					if (column.Value.DefaultColumnStyle != null)
					{
						stringBuilder.Append(" style=\"").Append(column.Value.DefaultColumnStyle.InternalID.Value.ToString("G", culture)).Append("\"");
					}
					stringBuilder.Append(value).Append("/>");
				}
			}
			string text = stringBuilder.ToString();
			if (text.Length > 0)
			{
				return text;
			}
			return string.Empty;
		}
		return string.Empty;
	}

	private string CreateCorePropertiesString()
	{
		Metadata workbookMetadata = workbook.WorkbookMetadata;
		StringBuilder stringBuilder = new StringBuilder();
		AppendXmlTag(stringBuilder, workbookMetadata.Title, "title", "dc");
		AppendXmlTag(stringBuilder, workbookMetadata.Subject, "subject", "dc");
		AppendXmlTag(stringBuilder, workbookMetadata.Creator, "creator", "dc");
		AppendXmlTag(stringBuilder, workbookMetadata.Creator, "lastModifiedBy", "cp");
		AppendXmlTag(stringBuilder, workbookMetadata.Keywords, "keywords", "cp");
		AppendXmlTag(stringBuilder, workbookMetadata.Description, "description", "dc");
		string value = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ssZ", culture);
		stringBuilder.Append("<dcterms:created xsi:type=\"dcterms:W3CDTF\">").Append(value).Append("</dcterms:created>");
		stringBuilder.Append("<dcterms:modified xsi:type=\"dcterms:W3CDTF\">").Append(value).Append("</dcterms:modified>");
		AppendXmlTag(stringBuilder, workbookMetadata.Category, "category", "cp");
		AppendXmlTag(stringBuilder, workbookMetadata.ContentStatus, "contentStatus", "cp");
		return stringBuilder.ToString();
	}

	private string CreateMergedCellsString(Worksheet sheet)
	{
		if (sheet.MergedCells.Count < 1)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<mergeCells count=\"").Append(sheet.MergedCells.Count.ToString("G", culture)).Append("\">");
		foreach (KeyValuePair<string, Range> mergedCell in sheet.MergedCells)
		{
			stringBuilder.Append("<mergeCell ref=\"").Append(mergedCell.Value.ToString()).Append("\"/>");
		}
		stringBuilder.Append("</mergeCells>");
		return stringBuilder.ToString();
	}

	private string CreateRowString(DynamicRow dynamicRow, Worksheet worksheet)
	{
		int rowNumber = dynamicRow.RowNumber;
		string value = "";
		string value2 = "";
		if (worksheet.RowHeights.ContainsKey(rowNumber) && Math.Abs(worksheet.RowHeights[rowNumber] - worksheet.DefaultRowHeight) > 0.0001f)
		{
			value = " x14ac:dyDescent=\"0.25\" customHeight=\"1\" ht=\"" + Utils.GetInternalRowHeight(worksheet.RowHeights[rowNumber]).ToString("G", culture) + "\"";
		}
		if (worksheet.HiddenRows.ContainsKey(rowNumber) && worksheet.HiddenRows[rowNumber])
		{
			value2 = " hidden=\"1\"";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<row r=\"").Append((rowNumber + 1).ToString()).Append("\"")
			.Append(value)
			.Append(value2)
			.Append(">");
		string text = "";
		int num = 0;
		foreach (Cell cellDefinition in dynamicRow.CellDefinitions)
		{
			string value3 = " ";
			string value4 = ((cellDefinition.CellStyle == null) ? "" : (" s=\"" + cellDefinition.CellStyle.InternalID.Value.ToString("G", culture) + "\" "));
			if (cellDefinition.DataType == Cell.CellType.BOOL)
			{
				string text2 = "b";
				value3 = " t=\"" + text2 + "\" ";
				text = ((!(bool)cellDefinition.Value) ? "0" : "1");
			}
			else if (cellDefinition.DataType == Cell.CellType.NUMBER)
			{
				string text2 = "n";
				value3 = " t=\"" + text2 + "\" ";
				Type type = cellDefinition.Value.GetType();
				if (type == typeof(byte))
				{
					text = ((byte)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(sbyte))
				{
					text = ((sbyte)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(decimal))
				{
					text = ((decimal)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(double))
				{
					text = ((double)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(float))
				{
					text = ((float)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(int))
				{
					text = ((int)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(uint))
				{
					text = ((uint)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(long))
				{
					text = ((long)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(ulong))
				{
					text = ((ulong)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(short))
				{
					text = ((short)cellDefinition.Value).ToString("G", culture);
				}
				else if (type == typeof(ushort))
				{
					text = ((ushort)cellDefinition.Value).ToString("G", culture);
				}
			}
			else if (cellDefinition.DataType == Cell.CellType.DATE)
			{
				text = Utils.GetOADateTimeString((DateTime)cellDefinition.Value);
			}
			else if (cellDefinition.DataType == Cell.CellType.TIME)
			{
				text = Utils.GetOATimeString((TimeSpan)cellDefinition.Value);
			}
			else
			{
				string text2;
				if (cellDefinition.Value == null)
				{
					text2 = null;
					text = null;
				}
				else if (cellDefinition.DataType == Cell.CellType.FORMULA)
				{
					text2 = "str";
					text = cellDefinition.Value.ToString();
				}
				else
				{
					text2 = "s";
					text = sharedStrings.Add(cellDefinition.Value.ToString(), sharedStrings.Count.ToString("G", culture));
					sharedStringsTotalCount++;
				}
				value3 = " t=\"" + text2 + "\" ";
			}
			if (cellDefinition.DataType != Cell.CellType.EMPTY)
			{
				stringBuilder.Append("<c r=\"").Append(cellDefinition.CellAddress).Append("\"")
					.Append(value3)
					.Append(value4)
					.Append(">");
				if (cellDefinition.DataType == Cell.CellType.FORMULA)
				{
					stringBuilder.Append("<f>").Append(EscapeXmlChars(cellDefinition.Value.ToString())).Append("</f>");
				}
				else
				{
					stringBuilder.Append("<v>").Append(EscapeXmlChars(text)).Append("</v>");
				}
				stringBuilder.Append("</c>");
			}
			else if (text == null || cellDefinition.DataType == Cell.CellType.EMPTY)
			{
				stringBuilder.Append("<c r=\"").Append(cellDefinition.CellAddress).Append("\"")
					.Append(value4)
					.Append("/>");
			}
			num++;
		}
		stringBuilder.Append("</row>");
		return stringBuilder.ToString();
	}

	private string CreateSheetProtectionString(Worksheet sheet)
	{
		if (!sheet.UseSheetProtection)
		{
			return string.Empty;
		}
		Dictionary<Worksheet.SheetProtectionValue, int> dictionary = new Dictionary<Worksheet.SheetProtectionValue, int>();
		if (sheet.SheetProtectionValues.Count == 0)
		{
			dictionary.Add(Worksheet.SheetProtectionValue.selectLockedCells, 1);
			dictionary.Add(Worksheet.SheetProtectionValue.selectUnlockedCells, 1);
		}
		if (!sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.objects))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.objects, 1);
		}
		if (!sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.scenarios))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.scenarios, 1);
		}
		if (!sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.selectLockedCells) && !dictionary.ContainsKey(Worksheet.SheetProtectionValue.selectLockedCells))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.selectLockedCells, 1);
		}
		if ((!sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.selectUnlockedCells) || !sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.selectLockedCells)) && !dictionary.ContainsKey(Worksheet.SheetProtectionValue.selectUnlockedCells))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.selectUnlockedCells, 1);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.formatCells))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.formatCells, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.formatColumns))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.formatColumns, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.formatRows))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.formatRows, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.insertColumns))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.insertColumns, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.insertRows))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.insertRows, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.insertHyperlinks))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.insertHyperlinks, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.deleteColumns))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.deleteColumns, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.deleteRows))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.deleteRows, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.sort))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.sort, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.autoFilter))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.autoFilter, 0);
		}
		if (sheet.SheetProtectionValues.Contains(Worksheet.SheetProtectionValue.pivotTables))
		{
			dictionary.Add(Worksheet.SheetProtectionValue.pivotTables, 0);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<sheetProtection");
		foreach (KeyValuePair<Worksheet.SheetProtectionValue, int> item in dictionary)
		{
			string name = Enum.GetName(typeof(Worksheet.SheetProtectionValue), item.Key);
			stringBuilder.Append(" ").Append(name).Append("=\"")
				.Append(item.Value.ToString("G", culture))
				.Append("\"");
		}
		if (!string.IsNullOrEmpty(sheet.SheetProtectionPasswordHash))
		{
			stringBuilder.Append(" password=\"").Append(sheet.SheetProtectionPasswordHash).Append("\"");
		}
		stringBuilder.Append(" sheet=\"1\"/>");
		return stringBuilder.ToString();
	}

	private string CreateStyleBorderString()
	{
		Border[] borders = styles.GetBorders();
		StringBuilder stringBuilder = new StringBuilder();
		Border[] array = borders;
		foreach (Border border in array)
		{
			if (border.DiagonalDown && !border.DiagonalUp)
			{
				stringBuilder.Append("<border diagonalDown=\"1\">");
			}
			else if (!border.DiagonalDown && border.DiagonalUp)
			{
				stringBuilder.Append("<border diagonalUp=\"1\">");
			}
			else if (border.DiagonalDown && border.DiagonalUp)
			{
				stringBuilder.Append("<border diagonalDown=\"1\" diagonalUp=\"1\">");
			}
			else
			{
				stringBuilder.Append("<border>");
			}
			if (border.LeftStyle != Border.StyleValue.none)
			{
				stringBuilder.Append("<left style=\"" + Border.GetStyleName(border.LeftStyle) + "\">");
				if (!string.IsNullOrEmpty(border.LeftColor))
				{
					stringBuilder.Append("<color rgb=\"").Append(border.LeftColor).Append("\"/>");
				}
				else
				{
					stringBuilder.Append("<color auto=\"1\"/>");
				}
				stringBuilder.Append("</left>");
			}
			else
			{
				stringBuilder.Append("<left/>");
			}
			if (border.RightStyle != Border.StyleValue.none)
			{
				stringBuilder.Append("<right style=\"").Append(Border.GetStyleName(border.RightStyle)).Append("\">");
				if (!string.IsNullOrEmpty(border.RightColor))
				{
					stringBuilder.Append("<color rgb=\"").Append(border.RightColor).Append("\"/>");
				}
				else
				{
					stringBuilder.Append("<color auto=\"1\"/>");
				}
				stringBuilder.Append("</right>");
			}
			else
			{
				stringBuilder.Append("<right/>");
			}
			if (border.TopStyle != Border.StyleValue.none)
			{
				stringBuilder.Append("<top style=\"").Append(Border.GetStyleName(border.TopStyle)).Append("\">");
				if (!string.IsNullOrEmpty(border.TopColor))
				{
					stringBuilder.Append("<color rgb=\"").Append(border.TopColor).Append("\"/>");
				}
				else
				{
					stringBuilder.Append("<color auto=\"1\"/>");
				}
				stringBuilder.Append("</top>");
			}
			else
			{
				stringBuilder.Append("<top/>");
			}
			if (border.BottomStyle != Border.StyleValue.none)
			{
				stringBuilder.Append("<bottom style=\"").Append(Border.GetStyleName(border.BottomStyle)).Append("\">");
				if (!string.IsNullOrEmpty(border.BottomColor))
				{
					stringBuilder.Append("<color rgb=\"").Append(border.BottomColor).Append("\"/>");
				}
				else
				{
					stringBuilder.Append("<color auto=\"1\"/>");
				}
				stringBuilder.Append("</bottom>");
			}
			else
			{
				stringBuilder.Append("<bottom/>");
			}
			if (border.DiagonalStyle != Border.StyleValue.none)
			{
				stringBuilder.Append("<diagonal style=\"").Append(Border.GetStyleName(border.DiagonalStyle)).Append("\">");
				if (!string.IsNullOrEmpty(border.DiagonalColor))
				{
					stringBuilder.Append("<color rgb=\"").Append(border.DiagonalColor).Append("\"/>");
				}
				else
				{
					stringBuilder.Append("<color auto=\"1\"/>");
				}
				stringBuilder.Append("</diagonal>");
			}
			else
			{
				stringBuilder.Append("<diagonal/>");
			}
			stringBuilder.Append("</border>");
		}
		return stringBuilder.ToString();
	}

	private string CreateStyleFontString()
	{
		Font[] fonts = styles.GetFonts();
		StringBuilder stringBuilder = new StringBuilder();
		Font[] array = fonts;
		foreach (Font font in array)
		{
			stringBuilder.Append("<font>");
			if (font.Bold)
			{
				stringBuilder.Append("<b/>");
			}
			if (font.Italic)
			{
				stringBuilder.Append("<i/>");
			}
			if (font.Strike)
			{
				stringBuilder.Append("<strike/>");
			}
			if (font.Underline != Font.UnderlineValue.none)
			{
				if (font.Underline == Font.UnderlineValue.u_double)
				{
					stringBuilder.Append("<u val=\"double\"/>");
				}
				else if (font.Underline == Font.UnderlineValue.singleAccounting)
				{
					stringBuilder.Append("<u val=\"singleAccounting\"/>");
				}
				else if (font.Underline == Font.UnderlineValue.doubleAccounting)
				{
					stringBuilder.Append("<u val=\"doubleAccounting\"/>");
				}
				else
				{
					stringBuilder.Append("<u/>");
				}
			}
			if (font.VerticalAlign == Font.VerticalAlignValue.subscript)
			{
				stringBuilder.Append("<vertAlign val=\"subscript\"/>");
			}
			else if (font.VerticalAlign == Font.VerticalAlignValue.superscript)
			{
				stringBuilder.Append("<vertAlign val=\"superscript\"/>");
			}
			stringBuilder.Append("<sz val=\"").Append(font.Size.ToString("G", culture)).Append("\"/>");
			if (string.IsNullOrEmpty(font.ColorValue))
			{
				stringBuilder.Append("<color theme=\"").Append(font.ColorTheme.ToString("G", culture)).Append("\"/>");
			}
			else
			{
				stringBuilder.Append("<color rgb=\"").Append(font.ColorValue).Append("\"/>");
			}
			stringBuilder.Append("<name val=\"").Append(font.Name).Append("\"/>");
			stringBuilder.Append("<family val=\"").Append(font.Family).Append("\"/>");
			if (font.Scheme != Font.SchemeValue.none)
			{
				if (font.Scheme == Font.SchemeValue.major)
				{
					stringBuilder.Append("<scheme val=\"major\"/>");
				}
				else if (font.Scheme == Font.SchemeValue.minor)
				{
					stringBuilder.Append("<scheme val=\"minor\"/>");
				}
			}
			if (!string.IsNullOrEmpty(font.Charset))
			{
				stringBuilder.Append("<charset val=\"").Append(font.Charset).Append("\"/>");
			}
			stringBuilder.Append("</font>");
		}
		return stringBuilder.ToString();
	}

	private string CreateStyleFillString()
	{
		Fill[] fills = styles.GetFills();
		StringBuilder stringBuilder = new StringBuilder();
		Fill[] array = fills;
		foreach (Fill fill in array)
		{
			stringBuilder.Append("<fill>");
			stringBuilder.Append("<patternFill patternType=\"").Append(Fill.GetPatternName(fill.PatternFill)).Append("\"");
			if (fill.PatternFill == Fill.PatternValue.solid)
			{
				stringBuilder.Append(">");
				stringBuilder.Append("<fgColor rgb=\"").Append(fill.ForegroundColor).Append("\"/>");
				stringBuilder.Append("<bgColor indexed=\"").Append(fill.IndexedColor.ToString("G", culture)).Append("\"/>");
				stringBuilder.Append("</patternFill>");
			}
			else if (fill.PatternFill == Fill.PatternValue.mediumGray || fill.PatternFill == Fill.PatternValue.lightGray || fill.PatternFill == Fill.PatternValue.gray0625 || fill.PatternFill == Fill.PatternValue.darkGray)
			{
				stringBuilder.Append(">");
				stringBuilder.Append("<fgColor rgb=\"").Append(fill.ForegroundColor).Append("\"/>");
				if (!string.IsNullOrEmpty(fill.BackgroundColor))
				{
					stringBuilder.Append("<bgColor rgb=\"").Append(fill.BackgroundColor).Append("\"/>");
				}
				stringBuilder.Append("</patternFill>");
			}
			else
			{
				stringBuilder.Append("/>");
			}
			stringBuilder.Append("</fill>");
		}
		return stringBuilder.ToString();
	}

	private string CreateStyleNumberFormatString()
	{
		NumberFormat[] numberFormats = styles.GetNumberFormats();
		StringBuilder stringBuilder = new StringBuilder();
		NumberFormat[] array = numberFormats;
		foreach (NumberFormat numberFormat in array)
		{
			if (numberFormat.IsCustomFormat)
			{
				if (string.IsNullOrEmpty(numberFormat.CustomFormatCode))
				{
					throw new NanoXLSX.Exceptions.FormatException("The number format style component with the ID " + Utils.ToString(numberFormat.CustomFormatID) + " cannot be null or empty");
				}
				stringBuilder.Append("<numFmt formatCode=\"").Append(EscapeXmlAttributeChars(numberFormat.CustomFormatCode)).Append("\" numFmtId=\"")
					.Append(numberFormat.CustomFormatID.ToString("G", culture))
					.Append("\"/>");
			}
		}
		return stringBuilder.ToString();
	}

	private string CreateStyleXfsString()
	{
		Style[] array = styles.GetStyles();
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		Style[] array2 = array;
		foreach (Style style in array2)
		{
			int num = style.CurrentCellXf.CalculateInternalRotation();
			string text = string.Empty;
			string text2 = string.Empty;
			if (style.CurrentCellXf.HorizontalAlign != CellXf.HorizontalAlignValue.none || style.CurrentCellXf.VerticalAlign != CellXf.VerticalAlignValue.none || style.CurrentCellXf.Alignment != CellXf.TextBreakValue.none || num != 0)
			{
				stringBuilder2.Clear();
				stringBuilder2.Append("<alignment");
				if (style.CurrentCellXf.HorizontalAlign != CellXf.HorizontalAlignValue.none)
				{
					stringBuilder2.Append(" horizontal=\"");
					if (style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.center)
					{
						stringBuilder2.Append("center");
					}
					else if (style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.right)
					{
						stringBuilder2.Append("right");
					}
					else if (style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.centerContinuous)
					{
						stringBuilder2.Append("centerContinuous");
					}
					else if (style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.distributed)
					{
						stringBuilder2.Append("distributed");
					}
					else if (style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.fill)
					{
						stringBuilder2.Append("fill");
					}
					else if (style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.general)
					{
						stringBuilder2.Append("general");
					}
					else if (style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.justify)
					{
						stringBuilder2.Append("justify");
					}
					else
					{
						stringBuilder2.Append("left");
					}
					stringBuilder2.Append("\"");
				}
				if (style.CurrentCellXf.VerticalAlign != CellXf.VerticalAlignValue.none)
				{
					stringBuilder2.Append(" vertical=\"");
					if (style.CurrentCellXf.VerticalAlign == CellXf.VerticalAlignValue.center)
					{
						stringBuilder2.Append("center");
					}
					else if (style.CurrentCellXf.VerticalAlign == CellXf.VerticalAlignValue.distributed)
					{
						stringBuilder2.Append("distributed");
					}
					else if (style.CurrentCellXf.VerticalAlign == CellXf.VerticalAlignValue.justify)
					{
						stringBuilder2.Append("justify");
					}
					else if (style.CurrentCellXf.VerticalAlign == CellXf.VerticalAlignValue.top)
					{
						stringBuilder2.Append("top");
					}
					else
					{
						stringBuilder2.Append("bottom");
					}
					stringBuilder2.Append("\"");
				}
				if (style.CurrentCellXf.Indent > 0 && (style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.left || style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.right || style.CurrentCellXf.HorizontalAlign == CellXf.HorizontalAlignValue.distributed))
				{
					stringBuilder2.Append(" indent=\"");
					stringBuilder2.Append(style.CurrentCellXf.Indent.ToString("G", culture));
					stringBuilder2.Append("\"");
				}
				if (style.CurrentCellXf.Alignment != CellXf.TextBreakValue.none)
				{
					if (style.CurrentCellXf.Alignment == CellXf.TextBreakValue.shrinkToFit)
					{
						stringBuilder2.Append(" shrinkToFit=\"1");
					}
					else
					{
						stringBuilder2.Append(" wrapText=\"1");
					}
					stringBuilder2.Append("\"");
				}
				if (num != 0)
				{
					stringBuilder2.Append(" textRotation=\"");
					stringBuilder2.Append(num.ToString("G", culture));
					stringBuilder2.Append("\"");
				}
				stringBuilder2.Append("/>");
				text = stringBuilder2.ToString();
			}
			if (style.CurrentCellXf.Hidden || style.CurrentCellXf.Locked)
			{
				text2 = ((style.CurrentCellXf.Hidden && style.CurrentCellXf.Locked) ? "<protection locked=\"1\" hidden=\"1\"/>" : ((!style.CurrentCellXf.Hidden || style.CurrentCellXf.Locked) ? "<protection hidden=\"0\" locked=\"1\"/>" : "<protection hidden=\"1\" locked=\"0\"/>"));
			}
			stringBuilder.Append("<xf numFmtId=\"");
			if (style.CurrentNumberFormat.IsCustomFormat)
			{
				stringBuilder.Append(style.CurrentNumberFormat.CustomFormatID.ToString("G", culture));
			}
			else
			{
				stringBuilder.Append(((int)style.CurrentNumberFormat.Number).ToString("G", culture));
			}
			stringBuilder.Append("\" borderId=\"").Append(style.CurrentBorder.InternalID.Value.ToString("G", culture));
			stringBuilder.Append("\" fillId=\"").Append(style.CurrentFill.InternalID.Value.ToString("G", culture));
			stringBuilder.Append("\" fontId=\"").Append(style.CurrentFont.InternalID.Value.ToString("G", culture));
			if (!style.CurrentFont.IsDefaultFont)
			{
				stringBuilder.Append("\" applyFont=\"1");
			}
			if (style.CurrentFill.PatternFill != Fill.PatternValue.none)
			{
				stringBuilder.Append("\" applyFill=\"1");
			}
			if (!style.CurrentBorder.IsEmpty())
			{
				stringBuilder.Append("\" applyBorder=\"1");
			}
			if (text != string.Empty || style.CurrentCellXf.ForceApplyAlignment)
			{
				stringBuilder.Append("\" applyAlignment=\"1");
			}
			if (text2 != string.Empty)
			{
				stringBuilder.Append("\" applyProtection=\"1");
			}
			if (style.CurrentNumberFormat.Number != NumberFormat.FormatNumber.none)
			{
				stringBuilder.Append("\" applyNumberFormat=\"1\"");
			}
			else
			{
				stringBuilder.Append("\"");
			}
			if (text != string.Empty || text2 != string.Empty)
			{
				stringBuilder.Append(">");
				stringBuilder.Append(text);
				stringBuilder.Append(text2);
				stringBuilder.Append("</xf>");
			}
			else
			{
				stringBuilder.Append("/>");
			}
		}
		return stringBuilder.ToString();
	}

	private string CreateMruColorsString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<string> list = new List<string>();
		foreach (string mruColor in workbook.GetMruColors())
		{
			if (!(mruColor == Fill.DEFAULT_COLOR) && !list.Contains(mruColor))
			{
				list.Add(mruColor);
			}
		}
		if (list.Count > 0)
		{
			stringBuilder.Append("<mruColors>");
			foreach (string item in list)
			{
				stringBuilder.Append("<color rgb=\"").Append(item).Append("\"/>");
			}
			stringBuilder.Append("</mruColors>");
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	private List<DynamicRow> GetSortedSheetData(Worksheet sheet)
	{
		List<Cell> list = new List<Cell>();
		foreach (KeyValuePair<string, Cell> cell in sheet.Cells)
		{
			list.Add(cell.Value);
		}
		list.Sort();
		DynamicRow dynamicRow = new DynamicRow();
		Dictionary<int, DynamicRow> dictionary = new Dictionary<int, DynamicRow>();
		if (list.Count > 0)
		{
			int num = (dynamicRow.RowNumber = list[0].RowNumber);
			foreach (Cell item in list)
			{
				if (item.RowNumber != num)
				{
					dictionary.Add(num, dynamicRow);
					dynamicRow = new DynamicRow();
					dynamicRow.RowNumber = item.RowNumber;
					num = item.RowNumber;
				}
				dynamicRow.CellDefinitions.Add(item);
			}
			if (dynamicRow.CellDefinitions.Count > 0)
			{
				dictionary.Add(num, dynamicRow);
			}
		}
		foreach (KeyValuePair<int, float> rowHeight in sheet.RowHeights)
		{
			if (!dictionary.ContainsKey(rowHeight.Key))
			{
				dynamicRow = new DynamicRow();
				dynamicRow.RowNumber = rowHeight.Key;
				dictionary.Add(rowHeight.Key, dynamicRow);
			}
		}
		foreach (KeyValuePair<int, bool> hiddenRow in sheet.HiddenRows)
		{
			if (!dictionary.ContainsKey(hiddenRow.Key))
			{
				dynamicRow = new DynamicRow();
				dynamicRow.RowNumber = hiddenRow.Key;
				dictionary.Add(hiddenRow.Key, dynamicRow);
			}
		}
		List<DynamicRow> list2 = dictionary.Values.ToList();
		list2.Sort((DynamicRow r1, DynamicRow r2) => r1.RowNumber.CompareTo(r2.RowNumber));
		return list2;
	}

	public static string EscapeXmlChars(string input)
	{
		if (input == null)
		{
			return "";
		}
		int length = input.Length;
		List<int> list = new List<int>(length);
		List<byte> list2 = new List<byte>(length);
		for (int i = 0; i < length; i++)
		{
			if (input[i] < '\t' || (input[i] > '\n' && input[i] < '\r') || (input[i] > '\r' && input[i] < ' ') || (input[i] > '\ud7ff' && input[i] < '\ue000') || input[i] > '\ufffd')
			{
				list.Add(i);
				list2.Add(0);
			}
			else if (input[i] == '<')
			{
				list.Add(i);
				list2.Add(1);
			}
			else if (input[i] == '>')
			{
				list.Add(i);
				list2.Add(2);
			}
			else if (input[i] == '&')
			{
				list.Add(i);
				list2.Add(3);
			}
		}
		if (list.Count == 0)
		{
			return input;
		}
		StringBuilder stringBuilder = new StringBuilder(length);
		int num = 0;
		length = list.Count;
		for (int i = 0; i < length; i++)
		{
			stringBuilder.Append(input.Substring(num, list[i] - num));
			if (list2[i] == 0)
			{
				stringBuilder.Append(' ');
			}
			else if (list2[i] == 1)
			{
				stringBuilder.Append("&lt;");
			}
			else if (list2[i] == 2)
			{
				stringBuilder.Append("&gt;");
			}
			else if (list2[i] == 3)
			{
				stringBuilder.Append("&amp;");
			}
			num = list[i] + 1;
		}
		stringBuilder.Append(input.Substring(num));
		return stringBuilder.ToString();
	}

	public static string EscapeXmlAttributeChars(string input)
	{
		input = EscapeXmlChars(input);
		input = input.Replace("\"", "&quot;");
		return input;
	}
}
