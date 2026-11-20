using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Splat;

public class DefaultModeDetector : IModeDetector, IEnableLogger
{
	public bool? InUnitTestRunner()
	{
		string[] assemblyList = new string[9] { "CSUNIT", "NUNIT", "XUNIT", "MBUNIT", "NBEHAVE", "VISUALSTUDIO.QUALITYTOOLS", "VISUALSTUDIO.TESTPLATFORM", "FIXIE", "NCRUNCH" };
		try
		{
			return SearchForAssembly(assemblyList);
		}
		catch (Exception exception)
		{
			this.Log().Debug(exception, "Unable to find unit test runner value");
			return null;
		}
	}

	private static bool SearchForAssembly(IEnumerable<string> assemblyList)
	{
		return (from x in AppDomain.CurrentDomain.GetAssemblies()
			select x.FullName?.ToUpperInvariant() into x
			where x != null
			select (x)).Any((string x) => assemblyList.Any((string name) => x.Contains(name, StringComparison.InvariantCultureIgnoreCase)));
	}
}
