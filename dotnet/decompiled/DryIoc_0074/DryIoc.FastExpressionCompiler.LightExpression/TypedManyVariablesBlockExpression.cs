using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedManyVariablesBlockExpression : ManyVariablesBlockExpression
{
	public override Type Type { get; }

	internal TypedManyVariablesBlockExpression(Type type, IReadOnlyList<ParameterExpression> variables, IReadOnlyList<Expression> expressions)
		: base(variables, expressions)
	{
		Type = type;
	}
}
