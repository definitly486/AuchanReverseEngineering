using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Polly;

public sealed class ResilienceContext
{
	private static class UnknownResult
	{
	}

	[CompilerGenerated]
	private string? _003COperationKey_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsSynchronous_003Ek__BackingField;

	[CompilerGenerated]
	private Type _003CResultType_003Ek__BackingField = typeof(UnknownResult);

	internal string? OperationKey
	{
		[CompilerGenerated]
		set
		{
			_003COperationKey_003Ek__BackingField = value;
		}
	}

	public CancellationToken CancellationToken { get; internal set; }

	private bool IsSynchronous
	{
		[CompilerGenerated]
		set
		{
			_003CIsSynchronous_003Ek__BackingField = value;
		}
	}

	private Type ResultType
	{
		[CompilerGenerated]
		set
		{
			_003CResultType_003Ek__BackingField = value;
		}
	}

	public bool ContinueOnCapturedContext { get; internal set; }

	public ResilienceProperties Properties { get; } = new ResilienceProperties();

	internal ResilienceContext()
	{
	}

	internal bool Reset()
	{
		OperationKey = null;
		IsSynchronous = false;
		ResultType = typeof(UnknownResult);
		ContinueOnCapturedContext = false;
		CancellationToken = default(CancellationToken);
		Properties.Options.Clear();
		return true;
	}
}
