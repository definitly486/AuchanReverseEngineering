namespace CsvHelper;

public readonly struct ValidateArgs
{
	public readonly string Field;

	public readonly IReaderRow Row;

	public ValidateArgs(string field, IReaderRow row)
	{
		Field = field;
		Row = row;
	}
}
