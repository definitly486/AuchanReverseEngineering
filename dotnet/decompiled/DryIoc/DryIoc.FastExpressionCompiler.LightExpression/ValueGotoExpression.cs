using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ValueGotoExpression : GotoExpression
{
	public override Type Type => Target.Type;

	public override Expression Value { get; }

	internal ValueGotoExpression(LabelTarget target, Expression value)
		: base(target)
	{
		Value = value;
	}
}
