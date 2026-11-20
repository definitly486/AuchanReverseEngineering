using System;
using System.Reflection;
using System.Reflection.Emit;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

internal sealed class FuncInvoke4Expression : FourArgumentsMethodCallExpression, IFuncInvokeExpression
{
	public readonly Delegate Func;

	public override Expression Object => Expression.Constant(Func.Target);

	public override bool IsIntrinsic => true;

	internal FuncInvoke4Expression(Delegate f, MethodInfo m, Expression a0, Expression a1, Expression a2, Expression a3)
		: base(m, a0, a1, a2, a3)
	{
		Func = f;
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		if (closure.AddConstantOrIncrementUsageCount(Func.Target) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument0, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument1, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument2, paramExprs, isNestedLambda, ref rootClosure, config))
		{
			return ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument3, paramExprs, isNestedLambda, ref rootClosure, config);
		}
		return false;
	}

	public override bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		if (ExpressionCompiler.EmittingVisitor.TryEmitConstantOfNotNullValue(considerClosure: true, null, Func.Target, il, ref closure) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument0, paramExprs, il, ref closure, config, parent) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument1, paramExprs, il, ref closure, config, parent) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument2, paramExprs, il, ref closure, config, parent) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument3, paramExprs, il, ref closure, config, parent))
		{
			return ExpressionCompiler.EmittingVisitor.EmitMethodCall(il, Method);
		}
		return false;
	}
}
