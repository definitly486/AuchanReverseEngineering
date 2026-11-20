using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ValueConstantExpression : ConstantExpression
{
	public override Type Type => Value.GetType();

	public override object Value { get; }

	internal ValueConstantExpression(object value)
	{
		Value = value;
	}
}
public sealed class ValueConstantExpression<T> : ConstantExpression
{
	public override Type Type => typeof(T);

	public override object Value { get; }

	internal ValueConstantExpression(object value)
	{
		Value = value;
	}
}
