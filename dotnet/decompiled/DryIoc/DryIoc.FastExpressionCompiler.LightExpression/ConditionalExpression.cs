using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ConditionalExpression : Expression
{
	public readonly Expression Test;

	public readonly Expression IfTrue;

	public override ExpressionType NodeType => ExpressionType.Conditional;

	public override Type Type => typeof(void);

	public virtual Expression IfFalse => Expression.VoidDefault;

	internal ConditionalExpression(Expression test, Expression ifTrue)
	{
		Test = test;
		IfTrue = ifTrue;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Condition(Test.ToExpression(ref exprsConverted), IfTrue.ToExpression(ref exprsConverted), IfFalse.ToExpression(ref exprsConverted), Type);
	}
}
