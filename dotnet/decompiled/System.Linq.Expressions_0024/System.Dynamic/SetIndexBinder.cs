using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Dynamic;

[RequiresDynamicCode("Creating a call site may require dynamic code generation.")]
public abstract class SetIndexBinder : DynamicMetaObjectBinder
{
	public sealed override Type ReturnType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicMetaObject FallbackSetIndex(DynamicMetaObject target, DynamicMetaObject[] indexes, DynamicMetaObject value)
	{
		throw new NotSupportedException("Linked away");
	}

	public abstract DynamicMetaObject FallbackSetIndex(DynamicMetaObject target, DynamicMetaObject[] indexes, DynamicMetaObject value, DynamicMetaObject? errorSuggestion);
}
