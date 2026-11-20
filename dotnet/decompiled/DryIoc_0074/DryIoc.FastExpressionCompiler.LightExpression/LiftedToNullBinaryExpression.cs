using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal sealed class LiftedToNullBinaryExpression : BinaryExpression
{
	public override ExpressionType NodeType { get; }

	public override Type Type => typeof(bool?);

	internal LiftedToNullBinaryExpression(ExpressionType nodeType, Expression left, Expression right)
		: base(left, right)
	{
		NodeType = nodeType;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MakeBinary(NodeType, Left.ToExpression(ref exprsConverted), Right.ToExpression(ref exprsConverted), liftToNull: true, null);
	}
}
