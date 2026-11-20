using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedParameterExpression : ParameterExpression
{
	public override Type Type { get; }

	internal TypedParameterExpression(Type type, string name)
		: base(name)
	{
		Type = type;
	}
}
public sealed class TypedParameterExpression<T> : ParameterExpression
{
	public override Type Type => typeof(T);

	internal TypedParameterExpression(string name)
		: base(name)
	{
	}
}
