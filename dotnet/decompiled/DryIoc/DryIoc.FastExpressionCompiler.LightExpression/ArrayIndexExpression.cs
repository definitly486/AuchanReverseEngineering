using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ArrayIndexExpression : BinaryExpression
{
	public override ExpressionType NodeType => ExpressionType.ArrayIndex;

	public override Type Type => Left.Type.GetElementType();

	internal ArrayIndexExpression(Expression left, Expression right)
		: base(left, right)
	{
	}
}
