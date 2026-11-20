using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Diagnostics;

internal sealed class ProcessInfo
{
	internal readonly List<ThreadInfo> _threadInfoList;

	[CompilerGenerated]
	private int _003CProcessId_003Ek__BackingField;

	internal int BasePriority { get; set; }

	internal string ProcessName { get; set; } = string.Empty;

	internal int ProcessId
	{
		[CompilerGenerated]
		set
		{
			_003CProcessId_003Ek__BackingField = value;
		}
	}

	internal long PoolPagedBytes { get; set; }

	internal long PoolNonPagedBytes { get; }

	internal long VirtualBytes { get; set; }

	internal long VirtualBytesPeak { get; set; }

	internal long WorkingSetPeak { get; set; }

	internal long WorkingSet { get; set; }

	internal long PageFileBytesPeak { get; }

	internal long PageFileBytes { get; set; }

	internal long PrivateBytes { get; set; }

	internal int SessionId { get; set; }

	internal int HandleCount { get; set; }

	internal ProcessInfo()
	{
		_threadInfoList = new List<ThreadInfo>();
	}
}
