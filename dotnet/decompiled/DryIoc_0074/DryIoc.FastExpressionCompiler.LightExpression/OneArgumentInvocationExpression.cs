using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class OneArgumentInvocationExpression : NotNullExpressionInvocationExpression
{
	public readonly Expression Argument;

	public sealed override IReadOnlyList<Expression> Arguments => new Expression[1] { Argument };

	public sealed override int ArgumentCount => 1;

	public sealed override Expression GetArgument(int index)
	{
		return Argument;
	}

	internal OneArgumentInvocationExpression(Expression expression, Expression argument)
		: base(expression)
	{
		Argument = argument;
	}
}
