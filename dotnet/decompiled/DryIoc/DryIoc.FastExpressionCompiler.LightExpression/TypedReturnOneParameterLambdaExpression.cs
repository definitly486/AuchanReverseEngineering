using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnOneParameterLambdaExpression : OneParameterLambdaExpression
{
	public override Type ReturnType { get; }

	internal TypedReturnOneParameterLambdaExpression(Type delegateType, Expression body, ParameterExpression parameter, Type returnType)
		: base(delegateType, body, parameter)
	{
		ReturnType = returnType;
	}
}
