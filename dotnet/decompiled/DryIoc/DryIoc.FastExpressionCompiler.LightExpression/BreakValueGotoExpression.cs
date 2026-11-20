using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class BreakValueGotoExpression : ValueGotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Break;

	internal BreakValueGotoExpression(LabelTarget target, Expression value)
		: base(target, value)
	{
	}
}
