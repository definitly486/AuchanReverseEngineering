using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnExpression<TDelegate> : Expression<TDelegate> where TDelegate : Delegate
{
	public override Type ReturnType { get; }

	internal TypedReturnExpression(Expression body, Type returnType)
		: base(body)
	{
		ReturnType = returnType;
	}
}
