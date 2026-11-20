using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnTwoParametersLambdaExpression : TwoParametersLambdaExpression
{
	public override Type ReturnType { get; }

	internal TypedReturnTwoParametersLambdaExpression(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, Type returnType)
		: base(delegateType, body, p0, p1)
	{
		ReturnType = returnType;
	}
}
