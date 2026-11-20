using System.Collections.Generic;

namespace Auchan.Common.Common;

public interface IExcelService
{
	void CreateExcelDoc(string filepath, List<string> headers, List<List<string>> values);
}
