using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class OneParameterExpression<TDelegate> : Expression<TDelegate> where TDelegate : Delegate
{
	public readonly ParameterExpression Parameter0;

	public sealed override IReadOnlyList<ParameterExpression> Parameters => new ParameterExpression[1] { Parameter0 };

	public sealed override int ParameterCount => 1;

	public sealed override ParameterExpression GetParameter(int index)
	{
		return Parameter0;
	}

	internal OneParameterExpression(Expression body, ParameterExpression p0)
		: base(body)
	{
		Parameter0 = p0;
	}
}
