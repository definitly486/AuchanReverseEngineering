using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ThrowUnaryExpression : UnaryExpression
{
	public override ExpressionType NodeType => ExpressionType.Throw;

	public override Type Type => typeof(void);

	public ThrowUnaryExpression(Expression operand)
		: base(operand)
	{
	}
}
