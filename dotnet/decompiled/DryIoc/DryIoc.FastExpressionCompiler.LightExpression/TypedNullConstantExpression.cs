using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedNullConstantExpression : ConstantExpression
{
	public override Type Type { get; }

	public override object Value => null;

	internal TypedNullConstantExpression(Type type)
	{
		Type = type;
	}
}
