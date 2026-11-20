namespace CsvHelper;

public struct ReadingExceptionOccurredArgs
{
	public readonly CsvHelperException Exception;

	public object? Record { get; set; }

	public ReadingExceptionOccurredArgs(CsvHelperException exception)
	{
		Record = null;
		Exception = exception;
	}
}
