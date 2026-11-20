namespace NLog.MessageTemplates;

internal readonly struct Literal
{
	public readonly int Print;

	public readonly int Skip;

	public Literal(int print, int skip)
	{
		Print = print;
		Skip = skip;
	}
}
