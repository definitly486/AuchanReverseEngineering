namespace System.Linq.Expressions;

public class SymbolDocumentInfo
{
	public string FileName { get; }

	internal SymbolDocumentInfo(string fileName)
	{
		ArgumentNullException.ThrowIfNull(fileName, "fileName");
		FileName = fileName;
	}
}
