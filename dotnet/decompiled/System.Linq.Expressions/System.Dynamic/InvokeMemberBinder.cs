using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Dynamic;

[RequiresDynamicCode("Creating a call site may require dynamic code generation.")]
public abstract class InvokeMemberBinder : DynamicMetaObjectBinder
{
	public sealed override Type ReturnType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

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
	public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicMetaObject FallbackInvokeMember(DynamicMetaObject target, DynamicMetaObject[] args)
	{
		throw new NotSupportedException("Linked away");
	}

	public abstract DynamicMetaObject FallbackInvokeMember(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject? errorSuggestion);

	public abstract DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject? errorSuggestion);
}
