using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NanoXLSX.Exceptions;
using NanoXLSX.Styles;

namespace NanoXLSX;

public class Worksheet
{
	public enum CellDirection
	{
		ColumnToColumn,
		RowToRow,
		Disabled
	}

	public enum SheetProtectionValue
	{
		objects,
		scenarios,
		formatCells,
		formatColumns,
		formatRows,
		insertColumns,
		insertRows,
		insertHyperlinks,
		deleteColumns,
		deleteRows,
		selectLockedCells,
		sort,
		autoFilter,
		pivotTables,
		selectUnlockedCells
	}

	public enum WorksheetPane
	{
		bottomRight,
		topRight,
		bottomLeft,
		topLeft
	}

	public enum SheetViewType
	{
		normal,
		pageBreakPreview,
		pageLayout
	}

	public static readonly int MAX_WORKSHEET_NAME_LENGTH = 31;

	public static readonly float DEFAULT_COLUMN_WIDTH = 10f;

	public static readonly float DEFAULT_ROW_HEIGHT = 15f;

	public static readonly int MAX_COLUMN_NUMBER = 16383;

	public static readonly int MIN_COLUMN_NUMBER = 0;

	public static readonly float MIN_COLUMN_WIDTH = 0f;

	public static readonly float MIN_ROW_HEIGHT = 0f;

	public static readonly float MAX_COLUMN_WIDTH = 255f;

	public static readonly int MAX_ROW_NUMBER = 1048575;

	public static readonly int MIN_ROW_NUMBER = 0;

	public static readonly float MAX_ROW_HEIGHT = 409.5f;

	private Style activeStyle;

	private Range? autoFilterRange;

	private readonly Dictionary<string, Cell> cells;

	private readonly Dictionary<int, Column> columns;

	private string sheetName;

	private int currentRowNumber;

	private int currentColumnNumber;

	private float defaultRowHeight;

	private float defaultColumnWidth;

	private readonly Dictionary<int, float> rowHeights;

	private readonly Dictionary<int, bool> hiddenRows;

	private readonly Dictionary<string, Range> mergedCells;

	private readonly List<SheetProtectionValue> sheetProtectionValues;

	private bool useActiveStyle;

	private bool hidden;

	private Workbook workbookReference;

	private string sheetProtectionPasswordHash;

	private List<Range> selectedCells;

	private bool? freezeSplitPanes;

	private float? paneSplitLeftWidth;

	private float? paneSplitTopHeight;

	private Address? paneSplitTopLeftCell;

	private Address? paneSplitAddress;

	private WorksheetPane? activePane;

	private int sheetID;

	private SheetViewType viewType;

	private Dictionary<SheetViewType, int> zoomFactor;

	public Range? AutoFilterRange => autoFilterRange;

	public Dictionary<string, Cell> Cells => cells;

	public Dictionary<int, Column> Columns => columns;

	public CellDirection CurrentCellDirection { get; set; }

	public float DefaultColumnWidth => defaultColumnWidth;

	public float DefaultRowHeight => defaultRowHeight;

	public Dictionary<int, bool> HiddenRows => hiddenRows;

	public Dictionary<int, float> RowHeights => rowHeights;

	public Dictionary<string, Range> MergedCells => mergedCells;

	public List<Range> SelectedCellRanges => selectedCells;

	public int SheetID
	{
		get
		{
			return sheetID;
		}
		set
		{
			if (value < 1)
			{
				throw new NanoXLSX.Exceptions.FormatException("The ID " + value + " is invalid. Worksheet IDs must be >0");
			}
			sheetID = value;
		}
	}

	public string SheetName => sheetName;

	public string SheetProtectionPasswordHash => sheetProtectionPasswordHash;

	public List<SheetProtectionValue> SheetProtectionValues => sheetProtectionValues;

	public bool UseSheetProtection { get; }

	public bool Hidden => hidden;

	public float? PaneSplitTopHeight => paneSplitTopHeight;

	public float? PaneSplitLeftWidth => paneSplitLeftWidth;

	public bool? FreezeSplitPanes => freezeSplitPanes;

	public Address? PaneSplitTopLeftCell => paneSplitTopLeftCell;

	public Address? PaneSplitAddress => paneSplitAddress;

	public WorksheetPane? ActivePane => activePane;

	public bool ShowGridLines { get; set; }

	public bool ShowRowColumnHeaders { get; set; }

	public bool ShowRuler { get; set; }

	public SheetViewType ViewType => viewType;

	public int ZoomFactor => zoomFactor[viewType];

	public Dictionary<SheetViewType, int> ZoomFactors => zoomFactor;

	public Worksheet()
	{
		CurrentCellDirection = CellDirection.ColumnToColumn;
		cells = new Dictionary<string, Cell>();
		currentRowNumber = 0;
		currentColumnNumber = 0;
		defaultColumnWidth = DEFAULT_COLUMN_WIDTH;
		defaultRowHeight = DEFAULT_ROW_HEIGHT;
		rowHeights = new Dictionary<int, float>();
		mergedCells = new Dictionary<string, Range>();
		sheetProtectionValues = new List<SheetProtectionValue>();
		hiddenRows = new Dictionary<int, bool>();
		columns = new Dictionary<int, Column>();
		selectedCells = new List<Range>();
		activeStyle = null;
		workbookReference = null;
		viewType = SheetViewType.normal;
		zoomFactor = new Dictionary<SheetViewType, int>();
		zoomFactor.Add(viewType, 100);
		ShowGridLines = true;
		ShowRowColumnHeaders = true;
		ShowRuler = true;
	}

	public Worksheet(string name)
		: this()
	{
		SetSheetName(name);
	}

	public Worksheet(string name, int id, Workbook reference)
		: this()
	{
		SetSheetName(name);
		SheetID = id;
		workbookReference = reference;
	}

	private void AddNextCell(Cell cell, bool incremental, Style style)
	{
		if (style != null || (activeStyle != null && useActiveStyle))
		{
			if (cell.CellStyle == null && useActiveStyle)
			{
				cell.SetStyle(activeStyle);
			}
			else if (cell.CellStyle == null && style != null)
			{
				cell.SetStyle(style);
			}
			else if (cell.CellStyle != null && useActiveStyle)
			{
				Style style2 = (Style)cell.CellStyle.Copy();
				style2.Append(activeStyle);
				cell.SetStyle(style2);
			}
			else if (cell.CellStyle != null && style != null)
			{
				Style style3 = (Style)cell.CellStyle.Copy();
				style3.Append(style);
				cell.SetStyle(style3);
			}
		}
		string cellAddress = cell.CellAddress;
		if (cells.ContainsKey(cellAddress))
		{
			cells[cellAddress] = cell;
		}
		else
		{
			cells.Add(cellAddress, cell);
		}
		if (incremental)
		{
			if (CurrentCellDirection == CellDirection.ColumnToColumn)
			{
				currentColumnNumber++;
			}
			else if (CurrentCellDirection == CellDirection.RowToRow)
			{
				currentRowNumber++;
			}
		}
		else if (CurrentCellDirection == CellDirection.ColumnToColumn)
		{
			currentColumnNumber = cell.ColumnNumber + 1;
			currentRowNumber = cell.RowNumber;
		}
		else if (CurrentCellDirection == CellDirection.RowToRow)
		{
			currentColumnNumber = cell.ColumnNumber;
			currentRowNumber = cell.RowNumber + 1;
		}
	}

	private Cell CastValue(object value, int column, int row)
	{
		Cell cell;
		if (value != null && value.GetType() == typeof(Cell))
		{
			cell = (Cell)value;
			cell.CellAddress2 = new Address(column, row);
		}
		else
		{
			cell = new Cell(value, Cell.CellType.DEFAULT, column, row);
		}
		return cell;
	}

	public void AddCell(object value, int columnNumber, int rowNumber)
	{
		AddNextCell(CastValue(value, columnNumber, rowNumber), incremental: false, null);
	}

	public void AddCell(object value, int columnNumber, int rowNumber, Style style)
	{
		AddNextCell(CastValue(value, columnNumber, rowNumber), incremental: false, style);
	}

	public int GetFirstColumnNumber()
	{
		return GetBoundaryNumber(row: false, min: true);
	}

	public int GetFirstRowNumber()
	{
		return GetBoundaryNumber(row: true, min: true);
	}

	public int GetLastColumnNumber()
	{
		return GetBoundaryNumber(row: false, min: false);
	}

	public int GetLastRowNumber()
	{
		return GetBoundaryNumber(row: true, min: false);
	}

	public Address? GetLastCellAddress()
	{
		int lastRowNumber = GetLastRowNumber();
		int lastColumnNumber = GetLastColumnNumber();
		if (lastRowNumber < 0 || lastColumnNumber < 0)
		{
			return null;
		}
		return new Address(lastColumnNumber, lastRowNumber);
	}

	public Address? GetFirstCellAddress()
	{
		int firstRowNumber = GetFirstRowNumber();
		int firstColumnNumber = GetFirstColumnNumber();
		if (firstRowNumber < 0 || firstColumnNumber < 0)
		{
			return null;
		}
		return new Address(firstColumnNumber, firstRowNumber);
	}

	private int GetBoundaryDataNumber(bool row, bool min, bool ignoreEmpty)
	{
		if (cells.Count == 0)
		{
			return -1;
		}
		if (!ignoreEmpty)
		{
			if (row && min)
			{
				return cells.Min((KeyValuePair<string, Cell> x) => x.Value.RowNumber);
			}
			if (row)
			{
				return cells.Max((KeyValuePair<string, Cell> x) => x.Value.RowNumber);
			}
			if (min)
			{
				return cells.Min((KeyValuePair<string, Cell> x) => x.Value.ColumnNumber);
			}
			return cells.Max((KeyValuePair<string, Cell> x) => x.Value.ColumnNumber);
		}
		List<Cell> list = cells.Values.Where((Cell x) => x.Value != null && x.Value.ToString() != string.Empty).ToList();
		if (list.Count == 0)
		{
			return -1;
		}
		if (row && min)
		{
			return list.Min((Cell x) => x.RowNumber);
		}
		if (row)
		{
			return list.Max((Cell x) => x.RowNumber);
		}
		if (min)
		{
			return list.Min((Cell x) => x.ColumnNumber);
		}
		return list.Max((Cell x) => x.ColumnNumber);
	}

	private int GetBoundaryNumber(bool row, bool min)
	{
		int boundaryDataNumber = GetBoundaryDataNumber(row, min, ignoreEmpty: false);
		if (row)
		{
			int heightBoundary = -1;
			if (rowHeights.Count > 0)
			{
				heightBoundary = (min ? RowHeights.Min((KeyValuePair<int, float> x) => x.Key) : RowHeights.Max((KeyValuePair<int, float> x) => x.Key));
			}
			int hiddenBoundary = -1;
			if (hiddenRows.Count > 0)
			{
				hiddenBoundary = (min ? HiddenRows.Min((KeyValuePair<int, bool> x) => x.Key) : HiddenRows.Max((KeyValuePair<int, bool> x) => x.Key));
			}
			if (!min)
			{
				return GetMaxRow(boundaryDataNumber, heightBoundary, hiddenBoundary);
			}
			return GetMinRow(boundaryDataNumber, heightBoundary, hiddenBoundary);
		}
		int num = -1;
		if (columns.Count > 0)
		{
			num = (min ? Columns.Min((KeyValuePair<int, Column> x) => x.Key) : Columns.Max((KeyValuePair<int, Column> x) => x.Key));
		}
		if (min)
		{
			if (boundaryDataNumber < 0 || boundaryDataNumber >= num)
			{
				return num;
			}
			return boundaryDataNumber;
		}
		if (boundaryDataNumber < 0 || boundaryDataNumber <= num)
		{
			return num;
		}
		return boundaryDataNumber;
	}

	private int GetMaxRow(int cellBoundary, int heightBoundary, int hiddenBoundary)
	{
		int num = -1;
		if (cellBoundary >= 0)
		{
			num = cellBoundary;
		}
		if (heightBoundary >= 0 && heightBoundary > num)
		{
			num = heightBoundary;
		}
		if (hiddenBoundary >= 0 && hiddenBoundary > num)
		{
			num = hiddenBoundary;
		}
		return num;
	}

	private int GetMinRow(int cellBoundary, int heightBoundary, int hiddenBoundary)
	{
		int num = int.MaxValue;
		if (cellBoundary >= 0)
		{
			num = cellBoundary;
		}
		if (heightBoundary >= 0 && heightBoundary < num)
		{
			num = heightBoundary;
		}
		if (hiddenBoundary >= 0 && hiddenBoundary < num)
		{
			num = hiddenBoundary;
		}
		if (num != int.MaxValue)
		{
			return num;
		}
		return -1;
	}

	internal void RecalculateAutoFilter()
	{
		if (!autoFilterRange.HasValue)
		{
			return;
		}
		int column = autoFilterRange.Value.StartAddress.Column;
		int column2 = autoFilterRange.Value.EndAddress.Column;
		int num = 0;
		foreach (KeyValuePair<string, Cell> cell in Cells)
		{
			if (cell.Value.ColumnNumber >= column && cell.Value.ColumnNumber <= column2 && cell.Value.RowNumber > num)
			{
				num = cell.Value.RowNumber;
			}
		}
		for (int i = column; i <= column2; i++)
		{
			if (!columns.ContainsKey(i))
			{
				Column column3 = new Column(i);
				column3.HasAutoFilter = true;
				columns.Add(i, column3);
			}
			else
			{
				columns[i].HasAutoFilter = true;
			}
		}
		autoFilterRange = new Range
		{
			StartAddress = new Address(column, 0),
			EndAddress = new Address(column2, num)
		};
	}

	internal void RecalculateColumns()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, Column> column in columns)
		{
			if (!column.Value.HasAutoFilter && !column.Value.IsHidden && Math.Abs(column.Value.Width - DEFAULT_COLUMN_WIDTH) <= 0.0001f && column.Value.DefaultColumnStyle == null)
			{
				list.Add(column.Key);
			}
		}
		foreach (int item in list)
		{
			columns.Remove(item);
		}
	}

	internal void ResolveMergedCells()
	{
		Style mergeCellStyle = BasicStyles.MergeCellStyle;
		foreach (KeyValuePair<string, Range> mergedCell in MergedCells)
		{
			int num = 0;
			foreach (Address item in Cell.GetCellRange(mergedCell.Value.StartAddress, mergedCell.Value.EndAddress) as List<Address>)
			{
				Cell cell;
				if (!Cells.ContainsKey(item.GetAddress()))
				{
					cell = new Cell();
					cell.DataType = Cell.CellType.EMPTY;
					cell.RowNumber = item.Row;
					cell.ColumnNumber = item.Column;
					AddCell(cell, cell.ColumnNumber, cell.RowNumber);
				}
				else
				{
					cell = Cells[item.GetAddress()];
				}
				if (num != 0)
				{
					cell.DataType = Cell.CellType.EMPTY;
					if (cell.CellStyle == null)
					{
						cell.SetStyle(mergeCellStyle);
					}
					else
					{
						Style cellStyle = cell.CellStyle;
						cellStyle.CurrentCellXf.ForceApplyAlignment = mergeCellStyle.CurrentCellXf.ForceApplyAlignment;
						cell.SetStyle(cellStyle);
					}
				}
				num++;
			}
		}
	}

	public void SetSheetName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			int mAX_WORKSHEET_NAME_LENGTH = MAX_WORKSHEET_NAME_LENGTH;
			throw new NanoXLSX.Exceptions.FormatException("the worksheet name must be between 1 and " + mAX_WORKSHEET_NAME_LENGTH + " characters");
		}
		if (name.Length > MAX_WORKSHEET_NAME_LENGTH)
		{
			int mAX_WORKSHEET_NAME_LENGTH = MAX_WORKSHEET_NAME_LENGTH;
			throw new NanoXLSX.Exceptions.FormatException("the worksheet name must be between 1 and " + mAX_WORKSHEET_NAME_LENGTH + " characters");
		}
		if (new Regex("[\\[\\]\\*\\?/\\\\]").Match(name).Captures.Count > 0)
		{
			throw new NanoXLSX.Exceptions.FormatException("the worksheet name must not contain the characters [  ]  * ? / \\ ");
		}
		sheetName = name;
	}

	public static string SanitizeWorksheetName(string input, Workbook workbook)
	{
		if (string.IsNullOrEmpty(input))
		{
			input = "Sheet1";
		}
		int num = ((input.Length <= MAX_WORKSHEET_NAME_LENGTH) ? input.Length : MAX_WORKSHEET_NAME_LENGTH);
		StringBuilder stringBuilder = new StringBuilder(MAX_WORKSHEET_NAME_LENGTH);
		for (int i = 0; i < num; i++)
		{
			char c = input[i];
			if (c == '[' || c == ']' || c == '*' || c == '?' || c == '\\' || c == '/')
			{
				stringBuilder.Append('_');
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return GetUnusedWorksheetName(stringBuilder.ToString(), workbook);
	}

	private static string GetUnusedWorksheetName(string name, Workbook workbook)
	{
		if (workbook == null)
		{
			throw new WorksheetException("The workbook reference is null");
		}
		if (!WorksheetExists(name, workbook))
		{
			return name;
		}
		Match match = new Regex("^(.*?)(\\d{1,31})$").Match(name);
		string text = name;
		int result = 1;
		if (match.Groups.Count > 1)
		{
			text = match.Groups[1].Value;
			int.TryParse(match.Groups[2].Value, out result);
		}
		string text3;
		while (true)
		{
			string text2 = Utils.ToString(result);
			if (text2.Length + text.Length > MAX_WORKSHEET_NAME_LENGTH)
			{
				int length = text.Length - (text2.Length + text.Length - MAX_WORKSHEET_NAME_LENGTH);
				text = text.Substring(0, length);
			}
			text3 = text + text2;
			if (!WorksheetExists(text3, workbook))
			{
				break;
			}
			result++;
		}
		return text3;
	}

	private static bool WorksheetExists(string name, Workbook workbook)
	{
		int count = workbook.Worksheets.Count;
		for (int i = 0; i < count; i++)
		{
			if (workbook.Worksheets[i].SheetName == name)
			{
				return true;
			}
		}
		return false;
	}
}
