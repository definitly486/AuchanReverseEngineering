namespace CsvHelper;

public readonly struct ShouldSkipRecordArgs
{
	public readonly IReaderRow Row;

	public ShouldSkipRecordArgs(IReaderRow row)
	{
		Row = row;
	}
}
