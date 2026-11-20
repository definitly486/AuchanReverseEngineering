using System;
using System.Reflection;
using System.Reflection.Emit;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

internal sealed class FuncInvoke1Expression : OneArgumentMethodCallExpression, IFuncInvokeExpression
{
	public readonly Delegate Func;

	public override Expression Object => Expression.Constant(Func.Target);

	public override bool IsIntrinsic => true;

	internal FuncInvoke1Expression(Delegate f, MethodInfo m, Expression a0)
		: base(m, a0)
	{
		Func = f;
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		if (closure.AddConstantOrIncrementUsageCount(Func.Target))
		{
			return ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument, paramExprs, isNestedLambda, ref rootClosure, config);
		}
		return false;
	}

	public override bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		if (ExpressionCompiler.EmittingVisitor.TryEmitConstantOfNotNullValue(considerClosure: true, null, Func.Target, il, ref closure) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument, paramExprs, il, ref closure, config, parent))
		{
			return ExpressionCompiler.EmittingVisitor.EmitMethodCall(il, Method);
		}
		return false;
	}
}
