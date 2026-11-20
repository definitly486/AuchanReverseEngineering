using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class FourParametersLambdaExpression : TypedLambdaExpression
{
	public readonly ParameterExpression Parameter0;

	public readonly ParameterExpression Parameter1;

	public readonly ParameterExpression Parameter2;

	public readonly ParameterExpression Parameter3;

	public sealed override IReadOnlyList<ParameterExpression> Parameters => new ParameterExpression[4] { Parameter0, Parameter1, Parameter2, Parameter3 };

	public sealed override int ParameterCount => 4;

	public sealed override ParameterExpression GetParameter(int i)
	{
		return i switch
		{
			2 => Parameter2, 
			1 => Parameter1, 
			0 => Parameter0, 
			_ => Parameter3, 
		};
	}

	internal FourParametersLambdaExpression(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3)
		: base(delegateType, body)
	{
		Parameter0 = p0;
		Parameter1 = p1;
		Parameter2 = p2;
		Parameter3 = p3;
	}
}
