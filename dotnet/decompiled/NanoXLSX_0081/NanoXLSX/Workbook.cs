using System.Collections.Generic;
using System.Linq;
using NanoXLSX.Exceptions;
using NanoXLSX.LowLevel;

namespace NanoXLSX;

public class Workbook
{
	private string filename;

	private List<Worksheet> worksheets;

	private Worksheet currentWorksheet;

	private Metadata workbookMetadata;

	private string workbookProtectionPassword;

	private bool lockWindowsIfProtected;

	private bool lockStructureIfProtected;

	private int selectedWorksheet;

	private Shortener shortener;

	private List<string> mruColors = new List<string>();

	public Worksheet CurrentWorksheet => currentWorksheet;

	public string Filename => filename;

	public bool LockStructureIfProtected => lockStructureIfProtected;

	public bool LockWindowsIfProtected => lockWindowsIfProtected;

	public Metadata WorkbookMetadata => workbookMetadata;

	public int SelectedWorksheet => selectedWorksheet;

	public bool UseWorkbookProtection { get; }

	public string WorkbookProtectionPassword => workbookProtectionPassword;

	public string WorkbookProtectionPasswordHash { get; }

	public List<Worksheet> Worksheets => worksheets;

	public bool Hidden { get; }

	public Workbook(string filename, string sheetName)
	{
		Init();
		this.filename = filename;
		AddWorksheet(sheetName, sanitizeSheetName: true);
	}

	public IReadOnlyList<string> GetMruColors()
	{
		return mruColors;
	}

	public void AddWorksheet(string name)
	{
		foreach (Worksheet worksheet in worksheets)
		{
			if (worksheet.SheetName == name)
			{
				throw new WorksheetException("The worksheet with the name '" + name + "' already exists.");
			}
		}
		int nextWorksheetId = GetNextWorksheetId();
		Worksheet item = (currentWorksheet = new Worksheet(name, nextWorksheetId, this));
		worksheets.Add(item);
		shortener.SetCurrentWorksheetInternal(currentWorksheet);
	}

	public void AddWorksheet(string name, bool sanitizeSheetName)
	{
		if (sanitizeSheetName)
		{
			string name2 = Worksheet.SanitizeWorksheetName(name, this);
			AddWorksheet(name2);
		}
		else
		{
			AddWorksheet(name);
		}
	}

	internal void ResolveMergedCells()
	{
		foreach (Worksheet worksheet in worksheets)
		{
			worksheet.ResolveMergedCells();
		}
	}

	public void Save()
	{
		new XlsxWriter(this).Save();
	}

	private int GetNextWorksheetId()
	{
		if (worksheets.Count == 0)
		{
			return 1;
		}
		return worksheets.Max((Worksheet w) => w.SheetID) + 1;
	}

	private void Init()
	{
		worksheets = new List<Worksheet>();
		workbookMetadata = new Metadata();
		shortener = new Shortener(this);
	}
}
