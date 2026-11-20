using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnSixParametersLambdaExpression : SixParametersLambdaExpression
{
	public override Type ReturnType { get; }

	internal TypedReturnSixParametersLambdaExpression(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4, ParameterExpression p5, Type returnType)
		: base(delegateType, body, p0, p1, p2, p3, p4, p5)
	{
		ReturnType = returnType;
	}
}
