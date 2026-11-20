using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ReturnTypedGotoExpression : TypedGotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Return;

	internal ReturnTypedGotoExpression(LabelTarget target, Type type)
		: base(target, type)
	{
	}
}
