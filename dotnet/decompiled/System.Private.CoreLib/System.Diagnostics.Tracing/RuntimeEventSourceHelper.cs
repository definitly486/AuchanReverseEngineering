namespace System.Diagnostics.Tracing;

internal static class RuntimeEventSourceHelper
{
	private static Interop.Sys.ProcessCpuInformation s_cpuInfo;

	internal static double GetCpuUsage()
	{
		return Interop.Sys.GetCpuUtilization(ref s_cpuInfo) / (double)Environment.ProcessorCount;
	}
}
