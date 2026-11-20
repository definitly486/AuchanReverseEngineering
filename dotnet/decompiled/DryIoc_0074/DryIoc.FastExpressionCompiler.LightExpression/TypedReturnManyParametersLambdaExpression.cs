using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnManyParametersLambdaExpression : ManyParametersLambdaExpression
{
	public override Type ReturnType { get; }

	internal TypedReturnManyParametersLambdaExpression(Type delegateType, Expression body, IReadOnlyList<ParameterExpression> parameters, Type returnType)
		: base(delegateType, body, parameters)
	{
		ReturnType = returnType;
	}
}
