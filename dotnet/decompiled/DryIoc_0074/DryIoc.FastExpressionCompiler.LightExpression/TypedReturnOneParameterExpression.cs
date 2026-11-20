using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnOneParameterExpression<TDelegate> : OneParameterExpression<TDelegate> where TDelegate : Delegate
{
	public override Type ReturnType { get; }

	internal TypedReturnOneParameterExpression(Expression body, ParameterExpression p0, Type returnType)
		: base(body, p0)
	{
		ReturnType = returnType;
	}
}
