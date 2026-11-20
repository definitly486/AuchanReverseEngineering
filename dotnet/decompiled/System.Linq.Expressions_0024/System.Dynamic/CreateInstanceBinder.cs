using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Dynamic;

[RequiresDynamicCode("Creating a call site may require dynamic code generation.")]
public abstract class CreateInstanceBinder : DynamicMetaObjectBinder
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicMetaObject FallbackCreateInstance(DynamicMetaObject target, DynamicMetaObject[] args)
	{
		throw new NotSupportedException("Linked away");
	}

	public abstract DynamicMetaObject FallbackCreateInstance(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject? errorSuggestion);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args)
	{
		throw new NotSupportedException("Linked away");
	}
}
