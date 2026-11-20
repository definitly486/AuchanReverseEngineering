using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class BreakGotoExpression : GotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Break;

	internal BreakGotoExpression(LabelTarget target)
		: base(target)
	{
	}
}
