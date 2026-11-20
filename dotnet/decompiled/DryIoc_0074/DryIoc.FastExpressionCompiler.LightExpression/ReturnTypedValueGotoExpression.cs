using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ReturnTypedValueGotoExpression : TypedValueGotoExpression
{
	public override GotoExpressionKind Kind => GotoExpressionKind.Return;

	internal ReturnTypedValueGotoExpression(LabelTarget target, Expression value, Type type)
		: base(target, value, type)
	{
	}
}
