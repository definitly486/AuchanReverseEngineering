using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ContinueGotoExpression : GotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Continue;

	internal ContinueGotoExpression(LabelTarget target)
		: base(target)
	{
	}
}
