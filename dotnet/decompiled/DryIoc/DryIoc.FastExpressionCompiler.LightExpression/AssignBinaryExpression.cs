using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class AssignBinaryExpression : BinaryExpression
{
	public override ExpressionType NodeType => ExpressionType.Assign;

	public sealed override Type Type => Left.Type;

	internal AssignBinaryExpression(Expression left, Expression right)
		: base(left, right)
	{
	}
}
