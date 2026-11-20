using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnThreeParametersExpression<TDelegate> : ThreeParametersExpression<TDelegate> where TDelegate : Delegate
{
	public override Type ReturnType { get; }

	internal TypedReturnThreeParametersExpression(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, Type returnType)
		: base(body, p0, p1, p2)
	{
		ReturnType = returnType;
	}
}
