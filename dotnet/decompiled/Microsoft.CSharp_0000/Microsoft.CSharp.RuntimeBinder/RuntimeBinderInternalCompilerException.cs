using System;

namespace Microsoft.CSharp.RuntimeBinder;

[Serializable]
public class RuntimeBinderInternalCompilerException : Exception
{
	public RuntimeBinderInternalCompilerException(string? message)
		: base(message)
	{
	}
}
