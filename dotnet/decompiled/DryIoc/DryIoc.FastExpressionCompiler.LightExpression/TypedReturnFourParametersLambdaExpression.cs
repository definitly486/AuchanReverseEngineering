using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnFourParametersLambdaExpression : FourParametersLambdaExpression
{
	public override Type ReturnType { get; }

	internal TypedReturnFourParametersLambdaExpression(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, Type returnType)
		: base(delegateType, body, p0, p1, p2, p3)
	{
		ReturnType = returnType;
	}
}
