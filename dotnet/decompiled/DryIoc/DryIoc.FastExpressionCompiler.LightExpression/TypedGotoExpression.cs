using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class TypedGotoExpression : GotoExpression
{
	public override Type Type { get; }

	internal TypedGotoExpression(LabelTarget target, Type type)
		: base(target)
	{
		Type = type;
	}
}
