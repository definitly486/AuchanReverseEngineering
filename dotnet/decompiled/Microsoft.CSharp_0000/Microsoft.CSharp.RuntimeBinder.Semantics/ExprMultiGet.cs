using System;
using System.Runtime.CompilerServices;

namespace Microsoft.CSharp.RuntimeBinder.Semantics;

internal sealed class ExprMultiGet : ExprWithType
{
	public ExprMulti OptionalMulti
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
