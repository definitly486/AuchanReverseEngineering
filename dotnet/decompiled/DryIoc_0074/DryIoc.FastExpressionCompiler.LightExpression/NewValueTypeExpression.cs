using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NewValueTypeExpression : NewExpression
{
	public override Type Type { get; }

	internal NewValueTypeExpression(Type type)
		: base(null)
	{
		Type = type;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.New(Type);
	}
}
