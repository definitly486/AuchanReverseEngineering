using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class TwoParametersExpression<TDelegate> : Expression<TDelegate> where TDelegate : Delegate
{
	public readonly ParameterExpression Parameter0;

	public readonly ParameterExpression Parameter1;

	public sealed override IReadOnlyList<ParameterExpression> Parameters => new ParameterExpression[2] { Parameter0, Parameter1 };

	public sealed override int ParameterCount => 2;

	public sealed override ParameterExpression GetParameter(int i)
	{
		if (i != 0)
		{
			return Parameter1;
		}
		return Parameter0;
	}

	internal TwoParametersExpression(Expression body, ParameterExpression p0, ParameterExpression p1)
		: base(body)
	{
		Parameter0 = p0;
		Parameter1 = p1;
	}
}
