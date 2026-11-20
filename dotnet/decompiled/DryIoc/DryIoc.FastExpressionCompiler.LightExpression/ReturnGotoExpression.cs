using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ReturnGotoExpression : GotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Return;

	internal ReturnGotoExpression(LabelTarget target)
		: base(target)
	{
	}
}
