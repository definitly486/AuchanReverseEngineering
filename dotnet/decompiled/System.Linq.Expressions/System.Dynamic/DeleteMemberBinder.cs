using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Dynamic;

[RequiresDynamicCode("Creating a call site may require dynamic code generation.")]
public abstract class DeleteMemberBinder : DynamicMetaObjectBinder
{
	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public bool IgnoreCase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicMetaObject FallbackDeleteMember(DynamicMetaObject target)
	{
		throw new NotSupportedException("Linked away");
	}

	public abstract DynamicMetaObject FallbackDeleteMember(DynamicMetaObject target, DynamicMetaObject? errorSuggestion);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[]? args)
	{
		throw new NotSupportedException("Linked away");
	}
}
