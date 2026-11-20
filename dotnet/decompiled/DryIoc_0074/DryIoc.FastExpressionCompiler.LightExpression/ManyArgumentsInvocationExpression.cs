using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ManyArgumentsInvocationExpression : NotNullExpressionInvocationExpression
{
	public sealed override IReadOnlyList<Expression> Arguments { get; }

	public sealed override int ArgumentCount => Arguments.Count;

	public sealed override Expression GetArgument(int index)
	{
		return Arguments[index];
	}

	internal ManyArgumentsInvocationExpression(Expression expression, IReadOnlyList<Expression> arguments)
		: base(expression)
	{
		Arguments = arguments;
	}
}
