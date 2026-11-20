using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class OneParameterLambdaExpression : TypedLambdaExpression
{
	public readonly ParameterExpression Parameter0;

	public sealed override IReadOnlyList<ParameterExpression> Parameters => new ParameterExpression[1] { Parameter0 };

	public sealed override int ParameterCount => 1;

	public sealed override ParameterExpression GetParameter(int index)
	{
		return Parameter0;
	}

	internal OneParameterLambdaExpression(Type delegateType, Expression body, ParameterExpression parameter)
		: base(delegateType, body)
	{
		Parameter0 = parameter;
	}
}
