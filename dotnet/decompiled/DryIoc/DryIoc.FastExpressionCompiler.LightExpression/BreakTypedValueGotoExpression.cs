using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class BreakTypedValueGotoExpression : TypedValueGotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Break;

	internal BreakTypedValueGotoExpression(LabelTarget target, Expression value, Type type)
		: base(target, value, type)
	{
	}
}
