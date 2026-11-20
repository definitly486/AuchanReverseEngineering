using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ThreeParametersExpression<TDelegate> : Expression<TDelegate> where TDelegate : Delegate
{
	public readonly ParameterExpression Parameter0;

	public readonly ParameterExpression Parameter1;

	public readonly ParameterExpression Parameter2;

	public sealed override IReadOnlyList<ParameterExpression> Parameters => new ParameterExpression[3] { Parameter0, Parameter1, Parameter2 };

	public sealed override int ParameterCount => 3;

	public sealed override ParameterExpression GetParameter(int i)
	{
		return i switch
		{
			1 => Parameter1, 
			0 => Parameter0, 
			_ => Parameter2, 
		};
	}

	internal ThreeParametersExpression(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2)
		: base(body)
	{
		Parameter0 = p0;
		Parameter1 = p1;
		Parameter2 = p2;
	}
}
