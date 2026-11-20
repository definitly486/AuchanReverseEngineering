using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnTwoParametersExpression<TDelegate> : TwoParametersExpression<TDelegate> where TDelegate : Delegate
{
	public override Type ReturnType { get; }

	internal TypedReturnTwoParametersExpression(Expression body, ParameterExpression p0, ParameterExpression p1, Type returnType)
		: base(body, p0, p1)
	{
		ReturnType = returnType;
	}
}
