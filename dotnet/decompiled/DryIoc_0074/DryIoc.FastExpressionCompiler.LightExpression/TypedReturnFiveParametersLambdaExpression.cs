using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnFiveParametersLambdaExpression : FiveParametersLambdaExpression
{
	public override Type ReturnType { get; }

	internal TypedReturnFiveParametersLambdaExpression(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4, Type returnType)
		: base(delegateType, body, p0, p1, p2, p3, p4)
	{
		ReturnType = returnType;
	}
}
