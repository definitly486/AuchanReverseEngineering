using System.ComponentModel;

namespace System.Diagnostics;

[Designer("System.Diagnostics.Design.ProcessThreadDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public class ProcessThread : Component
{
	private readonly bool _isRemoteMachine;

	private readonly int _processId;

	private readonly ThreadInfo _threadInfo;

	internal ProcessThread(bool isRemoteMachine, int processId, ThreadInfo threadInfo)
	{
		_isRemoteMachine = isRemoteMachine;
		_processId = processId;
		_threadInfo = threadInfo;
	}
}
