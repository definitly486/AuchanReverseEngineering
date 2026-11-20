namespace Splat.ModeDetection;

public sealed class Mode : IModeDetector
{
	public static readonly Mode Run = new Mode(inUnitTestRunner: false);

	public static readonly Mode Test = new Mode(inUnitTestRunner: true);

	private readonly bool _inUnitTestRunner;

	private Mode(bool inUnitTestRunner)
	{
		_inUnitTestRunner = inUnitTestRunner;
	}

	public bool? InUnitTestRunner()
	{
		return _inUnitTestRunner;
	}
}
