using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ContinueTypedGotoExpression : TypedGotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Continue;

	internal ContinueTypedGotoExpression(LabelTarget target, Type type)
		: base(target, type)
	{
	}
}
