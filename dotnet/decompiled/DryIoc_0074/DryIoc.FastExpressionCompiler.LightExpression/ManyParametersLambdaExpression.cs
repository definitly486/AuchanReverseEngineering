using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ManyParametersLambdaExpression : TypedLambdaExpression
{
	private readonly IReadOnlyList<ParameterExpression> _parameters;

	public sealed override IReadOnlyList<ParameterExpression> Parameters => _parameters;

	public sealed override int ParameterCount => _parameters.Count;

	public sealed override ParameterExpression GetParameter(int index)
	{
		return _parameters[index];
	}

	internal ManyParametersLambdaExpression(Type delegateType, Expression body, IReadOnlyList<ParameterExpression> parameters)
		: base(delegateType, body)
	{
		_parameters = parameters;
	}
}
