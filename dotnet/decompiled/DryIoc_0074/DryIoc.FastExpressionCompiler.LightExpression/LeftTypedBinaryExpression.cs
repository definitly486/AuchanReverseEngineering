using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal sealed class LeftTypedBinaryExpression : BinaryExpression
{
	public override ExpressionType NodeType { get; }

	public override Type Type => Left.Type;

	internal LeftTypedBinaryExpression(ExpressionType nodeType, Expression left, Expression right)
		: base(left, right)
	{
		NodeType = nodeType;
	}
}
