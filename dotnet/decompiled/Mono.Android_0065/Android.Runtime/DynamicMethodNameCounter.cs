using System.Globalization;
using System.Threading;

namespace Android.Runtime;

internal class DynamicMethodNameCounter
{
	private static long dynamicMethodNameCounter;

	internal static string GetUniqueName()
	{
		return Interlocked.Increment(ref dynamicMethodNameCounter).ToString(CultureInfo.InvariantCulture);
	}
}
