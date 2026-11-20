using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class TypedLambdaExpression : LambdaExpression
{
	public sealed override Type Type { get; }

	internal TypedLambdaExpression(Type delegateType, Expression body)
		: base(body)
	{
		Type = delegateType;
	}
}
