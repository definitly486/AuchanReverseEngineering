using System;
using System.Reflection;
using System.Reflection.Emit;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

internal sealed class FuncInvoke0Expression : NotNullMethodCallExpression, IFuncInvokeExpression
{
	public readonly Delegate Func;

	public override Expression Object => Expression.Constant(Func.Target);

	public override bool IsIntrinsic => true;

	internal FuncInvoke0Expression(Delegate f, MethodInfo m)
		: base(m)
	{
		Func = f;
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		return closure.AddConstantOrIncrementUsageCount(Func.Target);
	}

	public override bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		if (ExpressionCompiler.EmittingVisitor.TryEmitConstantOfNotNullValue(considerClosure: true, null, Func.Target, il, ref closure))
		{
			return ExpressionCompiler.EmittingVisitor.EmitMethodCall(il, Method);
		}
		return false;
	}
}
