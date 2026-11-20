using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class TypedUnaryExpression : UnaryExpression
{
	public override ExpressionType NodeType { get; }

	public sealed override Type Type { get; }

	public TypedUnaryExpression(ExpressionType nodeType, Expression operand, Type type)
		: base(operand)
	{
		NodeType = nodeType;
		Type = type;
	}
}
public sealed class TypedUnaryExpression<T> : UnaryExpression
{
	public override ExpressionType NodeType { get; }

	public override Type Type => typeof(T);

	public TypedUnaryExpression(ExpressionType nodeType, Expression operand)
		: base(operand)
	{
		NodeType = nodeType;
	}
}
