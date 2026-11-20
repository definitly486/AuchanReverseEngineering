using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ManyParametersExpression<TDelegate> : Expression<TDelegate> where TDelegate : Delegate
{
	private readonly IReadOnlyList<ParameterExpression> _parameters;

	public sealed override IReadOnlyList<ParameterExpression> Parameters => _parameters;

	public sealed override int ParameterCount => _parameters.Count;

	public sealed override ParameterExpression GetParameter(int index)
	{
		return _parameters[index];
	}

	internal ManyParametersExpression(Expression body, IReadOnlyList<ParameterExpression> parameters)
		: base(body)
	{
		_parameters = parameters;
	}
}
