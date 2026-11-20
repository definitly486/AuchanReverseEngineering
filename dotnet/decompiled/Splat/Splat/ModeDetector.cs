namespace Splat;

public static class ModeDetector
{
	private static bool? _cachedInUnitTestRunnerResult;

	private static IModeDetector Current { get; set; }

	static ModeDetector()
	{
		Current = new DefaultModeDetector();
	}

	public static void OverrideModeDetector(IModeDetector modeDetector)
	{
		Current = modeDetector;
		_cachedInUnitTestRunnerResult = null;
	}

	public static bool InUnitTestRunner()
	{
		if (_cachedInUnitTestRunnerResult.HasValue)
		{
			return _cachedInUnitTestRunnerResult.Value;
		}
		if (Current != null)
		{
			_cachedInUnitTestRunnerResult = Current.InUnitTestRunner();
			if (_cachedInUnitTestRunnerResult.HasValue)
			{
				return _cachedInUnitTestRunnerResult.Value;
			}
		}
		return false;
	}
}
