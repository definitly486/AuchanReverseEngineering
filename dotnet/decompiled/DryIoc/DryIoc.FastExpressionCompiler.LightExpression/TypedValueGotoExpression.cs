using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class TypedValueGotoExpression : ValueGotoExpression
{
	public override Type Type { get; }

	internal TypedValueGotoExpression(LabelTarget target, Expression value, Type type)
		: base(target, value)
	{
		Type = type;
	}
}
