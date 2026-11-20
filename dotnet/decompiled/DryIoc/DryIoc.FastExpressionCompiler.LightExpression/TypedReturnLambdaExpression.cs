using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnLambdaExpression : TypedLambdaExpression
{
	public override Type ReturnType { get; }

	internal TypedReturnLambdaExpression(Type delegateType, Expression body, Type returnType)
		: base(delegateType, body)
	{
		ReturnType = returnType;
	}
}
