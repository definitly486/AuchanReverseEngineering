using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal sealed class CoalesceConversionBinaryExpression : CoalesceBinaryExpression
{
	public override Type Type => Right.Type;

	public override LambdaExpression Conversion { get; }

	internal CoalesceConversionBinaryExpression(Expression left, Expression right, LambdaExpression conversion)
		: base(left, right, right.Type)
	{
		Conversion = conversion;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Coalesce(Left.ToExpression(ref exprsConverted), Right.ToExpression(ref exprsConverted), Conversion.ToLambdaExpression());
	}
}
