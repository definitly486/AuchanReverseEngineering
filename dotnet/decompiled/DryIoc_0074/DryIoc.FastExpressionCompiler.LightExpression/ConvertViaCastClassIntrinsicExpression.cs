using System;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ConvertViaCastClassIntrinsicExpression<T> : UnaryExpression where T : class
{
	public sealed override ExpressionType NodeType => ExpressionType.Convert;

	public override Type Type => typeof(T);

	public override bool IsIntrinsic => true;

	public ConvertViaCastClassIntrinsicExpression(Expression operand)
		: base(operand)
	{
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		return ExpressionCompiler.TryCollectBoundConstants(ref closure, Operand, paramExprs, isNestedLambda, ref rootClosure, config);
	}

	public override bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		if (!ExpressionCompiler.EmittingVisitor.TryEmit(Operand, paramExprs, il, ref closure, config, parent, byRefIndex))
		{
			return false;
		}
		return true;
	}
}
public sealed class ConvertViaCastClassIntrinsicExpression : ConvertViaCastClassIntrinsicExpression<object>
{
	public override Type Type { get; }

	public ConvertViaCastClassIntrinsicExpression(Expression operand, Type type)
		: base(operand)
	{
		Type = type;
	}
}
