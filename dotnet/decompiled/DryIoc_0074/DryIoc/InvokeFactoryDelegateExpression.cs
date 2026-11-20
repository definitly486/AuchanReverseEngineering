using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

internal class InvokeFactoryDelegateExpression : InvocationExpression
{
	public readonly FactoryDelegate FactoryDelegate;

	public sealed override Type Type { get; }

	public sealed override Expression Expression => Expression.ConstantOf(FactoryDelegate);

	public sealed override int ArgumentCount => 1;

	public override IReadOnlyList<Expression> Arguments => FactoryDelegateCompiler.ResolverContextParamExprs;

	public sealed override bool IsIntrinsic => true;

	public override Expression GetArgument(int index)
	{
		return FactoryDelegateCompiler.ResolverContextParamExpr;
	}

	public InvokeFactoryDelegateExpression(Type type, FactoryDelegate f)
	{
		Type = type;
		FactoryDelegate = f;
	}

	public sealed override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		if (closure.AddConstantOrIncrementUsageCount(FactoryDelegate))
		{
			return ExpressionCompiler.TryCollectBoundConstants(ref closure, FactoryDelegateCompiler.ResolverContextParamExpr, paramExprs, isNestedLambda, ref rootClosure, config);
		}
		return false;
	}

	internal static bool EmitConvertObjectTo(ILGenerator il, Type t)
	{
		if (t != typeof(object) && t.IsValueType)
		{
			il.Emit(OpCodes.Unbox_Any, t);
		}
		return true;
	}

	public override bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		if (ExpressionCompiler.EmittingVisitor.TryEmitConstantOfNotNullValue(considerClosure: true, null, FactoryDelegate, il, ref closure) && ExpressionCompiler.EmittingVisitor.TryEmitNonByRefNonValueTypeParameter(FactoryDelegateCompiler.ResolverContextParamExpr, paramExprs, il, ref closure) && ExpressionCompiler.EmittingVisitor.EmitMethodCall(il, FactoryDelegateCompiler.InvokeMethod))
		{
			return EmitConvertObjectTo(il, Type);
		}
		return false;
	}
}
