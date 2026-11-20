using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ConvertUnaryExpression : UnaryExpression
{
	public override ExpressionType NodeType => ExpressionType.Convert;

	public override Type Type { get; }

	public ConvertUnaryExpression(Expression operand, Type type)
		: base(operand)
	{
		Type = type;
	}
}
