using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class LabelExpression : Expression
{
	public readonly LabelTarget Target;

	public override ExpressionType NodeType => ExpressionType.Label;

	public override Type Type => Target.Type;

	public virtual Expression DefaultValue => null;

	internal LabelExpression(LabelTarget target)
	{
		Target = target;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (DefaultValue != null)
		{
			return System.Linq.Expressions.Expression.Label(Target.ToSystemLabelTarget(ref exprsConverted), DefaultValue.ToExpression(ref exprsConverted));
		}
		return System.Linq.Expressions.Expression.Label(Target.ToSystemLabelTarget(ref exprsConverted));
	}
}
