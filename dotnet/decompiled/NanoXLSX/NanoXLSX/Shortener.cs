namespace NanoXLSX;

public class Shortener
{
	private Worksheet currentWorksheet;

	private readonly Workbook workbookReference;

	public Shortener(Workbook reference)
	{
		workbookReference = reference;
		currentWorksheet = reference.CurrentWorksheet;
	}

	internal void SetCurrentWorksheetInternal(Worksheet worksheet)
	{
		currentWorksheet = worksheet;
	}
}
