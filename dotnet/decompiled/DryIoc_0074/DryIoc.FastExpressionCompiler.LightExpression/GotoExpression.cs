using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class GotoExpression : Expression
{
	public readonly LabelTarget Target;

	public override ExpressionType NodeType => ExpressionType.Goto;

	public override Type Type => typeof(void);

	public virtual GotoExpressionKind Kind => GotoExpressionKind.Goto;

	public virtual Expression Value => null;

	internal GotoExpression(LabelTarget target)
	{
		Target = target;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MakeGoto(Kind, Target.ToSystemLabelTarget(ref exprsConverted), Value?.ToExpression(ref exprsConverted), Type);
	}
}
