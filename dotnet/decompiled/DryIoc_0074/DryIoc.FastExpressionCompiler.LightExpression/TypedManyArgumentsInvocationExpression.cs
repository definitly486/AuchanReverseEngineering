using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedManyArgumentsInvocationExpression : ManyArgumentsInvocationExpression
{
	public override Type Type { get; }

	internal TypedManyArgumentsInvocationExpression(Expression expression, IReadOnlyList<Expression> arguments, Type type)
		: base(expression, arguments)
	{
		Type = type;
	}
}
