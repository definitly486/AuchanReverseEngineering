using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnFourParametersExpression<TDelegate> : FourParametersExpression<TDelegate> where TDelegate : Delegate
{
	public override Type ReturnType { get; }

	internal TypedReturnFourParametersExpression(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, Type returnType)
		: base(body, p0, p1, p2, p3)
	{
		ReturnType = returnType;
	}
}
