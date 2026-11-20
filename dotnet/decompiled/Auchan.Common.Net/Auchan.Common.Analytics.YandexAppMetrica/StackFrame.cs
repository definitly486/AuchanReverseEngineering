namespace Auchan.Common.Analytics.YandexAppMetrica;

public sealed record StackFrame
{
	public string ClassName { get; }

	public string MethodName { get; }

	public string FileName { get; }

	public int LineNumber { get; }

	public string Symbol
	{
		get
		{
			if (!string.IsNullOrEmpty(MethodName))
			{
				return ClassName + "." + MethodName;
			}
			return ClassName;
		}
	}

	public StackFrame(string className, string methodName, string fileName, int lineNumber)
	{
		ClassName = className;
		MethodName = methodName;
		FileName = fileName;
		LineNumber = lineNumber;
	}
}
