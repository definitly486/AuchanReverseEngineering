namespace Polly;

internal sealed class VoidResult
{
	public static readonly VoidResult Instance = new VoidResult();

	private VoidResult()
	{
	}

	public override string ToString()
	{
		return "void";
	}
}
