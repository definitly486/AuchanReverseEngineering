using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NotBooleanUnaryExpression : UnaryExpression
{
	public override ExpressionType NodeType => ExpressionType.Not;

	public override Type Type => typeof(bool);

	public NotBooleanUnaryExpression(Expression operand)
		: base(operand)
	{
	}
}
