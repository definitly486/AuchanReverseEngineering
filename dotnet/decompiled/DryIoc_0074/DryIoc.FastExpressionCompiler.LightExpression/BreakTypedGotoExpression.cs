using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class BreakTypedGotoExpression : TypedGotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Break;

	internal BreakTypedGotoExpression(LabelTarget target, Type type)
		: base(target, type)
	{
	}
}
