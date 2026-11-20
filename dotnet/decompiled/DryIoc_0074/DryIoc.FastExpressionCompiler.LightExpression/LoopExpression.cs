using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class LoopExpression : Expression
{
	public readonly Expression Body;

	public readonly LabelTarget BreakLabel;

	public readonly LabelTarget ContinueLabel;

	public override ExpressionType NodeType => ExpressionType.Loop;

	public override Type Type => typeof(void);

	internal LoopExpression(Expression body, LabelTarget breakLabel, LabelTarget continueLabel)
	{
		Body = body;
		BreakLabel = breakLabel;
		ContinueLabel = continueLabel;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (BreakLabel != null)
		{
			if (ContinueLabel != null)
			{
				return System.Linq.Expressions.Expression.Loop(Body.ToExpression(ref exprsConverted), BreakLabel.ToSystemLabelTarget(ref exprsConverted), ContinueLabel.ToSystemLabelTarget(ref exprsConverted));
			}
			return System.Linq.Expressions.Expression.Loop(Body.ToExpression(ref exprsConverted), BreakLabel.ToSystemLabelTarget(ref exprsConverted));
		}
		return System.Linq.Expressions.Expression.Loop(Body.ToExpression(ref exprsConverted));
	}
}
