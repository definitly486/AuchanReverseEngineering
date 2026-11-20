using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ReturnValueGotoExpression : ValueGotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Return;

	internal ReturnValueGotoExpression(LabelTarget target, Expression value)
		: base(target, value)
	{
	}
}
