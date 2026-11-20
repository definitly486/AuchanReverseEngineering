using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedConvertUnaryExpression<T> : UnaryExpression
{
	public override ExpressionType NodeType => ExpressionType.Convert;

	public override Type Type => typeof(T);

	public TypedConvertUnaryExpression(Expression operand)
		: base(operand)
	{
	}
}
