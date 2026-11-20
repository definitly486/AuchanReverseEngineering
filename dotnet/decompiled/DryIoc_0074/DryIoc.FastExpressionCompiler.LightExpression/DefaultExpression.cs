using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class DefaultExpression : Expression
{
	public override ExpressionType NodeType => ExpressionType.Default;

	public override Type Type { get; }

	internal DefaultExpression(Type type)
	{
		Type = type;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (!(Type == typeof(void)))
		{
			return System.Linq.Expressions.Expression.Default(Type);
		}
		return System.Linq.Expressions.Expression.Empty();
	}
}
