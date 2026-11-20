using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal class CoalesceBinaryExpression : BinaryExpression
{
	public sealed override ExpressionType NodeType => ExpressionType.Coalesce;

	public override Type Type { get; }

	internal CoalesceBinaryExpression(Expression left, Expression right, Type type)
		: base(left, right)
	{
		Type = type;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Coalesce(Left.ToExpression(ref exprsConverted), Right.ToExpression(ref exprsConverted));
	}
}
