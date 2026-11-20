using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedValueConstantExpression : ConstantExpression
{
	public override Type Type { get; }

	public override object Value { get; }

	internal TypedValueConstantExpression(object value, Type type)
	{
		Value = value;
		Type = type;
	}
}
