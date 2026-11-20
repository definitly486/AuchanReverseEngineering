using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class FiveParametersLambdaExpression : TypedLambdaExpression
{
	public readonly ParameterExpression Parameter0;

	public readonly ParameterExpression Parameter1;

	public readonly ParameterExpression Parameter2;

	public readonly ParameterExpression Parameter3;

	public readonly ParameterExpression Parameter4;

	public sealed override IReadOnlyList<ParameterExpression> Parameters => new ParameterExpression[5] { Parameter0, Parameter1, Parameter2, Parameter3, Parameter4 };

	public sealed override int ParameterCount => 5;

	public sealed override ParameterExpression GetParameter(int i)
	{
		return i switch
		{
			3 => Parameter3, 
			2 => Parameter2, 
			1 => Parameter1, 
			0 => Parameter0, 
			_ => Parameter4, 
		};
	}

	internal FiveParametersLambdaExpression(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4)
		: base(delegateType, body)
	{
		Parameter0 = p0;
		Parameter1 = p1;
		Parameter2 = p2;
		Parameter3 = p3;
		Parameter4 = p4;
	}
}
