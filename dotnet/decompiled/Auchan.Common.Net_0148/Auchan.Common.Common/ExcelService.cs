using System.Collections.Generic;
using NanoXLSX;
using NanoXLSX.Styles;

namespace Auchan.Common.Common;

public class ExcelService : IExcelService
{
	public void CreateExcelDoc(string filepath, List<string> headers, List<List<string>> values)
	{
		Style style = BasicStyles.Font("Calibri");
		Workbook workbook = new Workbook(filepath, "Log");
		Worksheet currentWorksheet = workbook.CurrentWorksheet;
		for (int i = 0; i < headers.Count; i++)
		{
			currentWorksheet.AddCell(headers[i], i, 0, style);
		}
		for (int j = 0; j < values.Count; j++)
		{
			List<string> list = values[j];
			for (int k = 0; k < list.Count; k++)
			{
				currentWorksheet.AddCell(list[k], k, j + 1, style);
			}
		}
		workbook.Save();
	}
}
