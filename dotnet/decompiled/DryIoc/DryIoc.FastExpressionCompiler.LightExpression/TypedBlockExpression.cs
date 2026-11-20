using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedBlockExpression : BlockExpression
{
	public override Type Type { get; }

	internal TypedBlockExpression(Type type, IReadOnlyList<Expression> expressions)
		: base(expressions)
	{
		Type = type;
	}
}
