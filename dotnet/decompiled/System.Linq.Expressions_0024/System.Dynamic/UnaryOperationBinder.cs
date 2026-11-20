using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace System.Dynamic;

[RequiresDynamicCode("Creating a call site may require dynamic code generation.")]
public abstract class UnaryOperationBinder : DynamicMetaObjectBinder
{
	public sealed override Type ReturnType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public ExpressionType Operation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicMetaObject FallbackUnaryOperation(DynamicMetaObject target)
	{
		throw new NotSupportedException("Linked away");
	}

	public abstract DynamicMetaObject FallbackUnaryOperation(DynamicMetaObject target, DynamicMetaObject? errorSuggestion);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sealed override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[]? args)
	{
		throw new NotSupportedException("Linked away");
	}
}
