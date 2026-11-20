using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnThreeParametersLambdaExpression : ThreeParametersLambdaExpression
{
	public override Type ReturnType { get; }

	internal TypedReturnThreeParametersLambdaExpression(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, Type returnType)
		: base(delegateType, body, p0, p1, p2)
	{
		ReturnType = returnType;
	}
}
