using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class TwoArgumentsInvocationExpression : NotNullExpressionInvocationExpression
{
	public readonly Expression Argument0;

	public readonly Expression Argument1;

	public sealed override IReadOnlyList<Expression> Arguments => new Expression[2] { Argument0, Argument1 };

	public sealed override int ArgumentCount => 2;

	public sealed override Expression GetArgument(int i)
	{
		if (i != 0)
		{
			return Argument1;
		}
		return Argument0;
	}

	internal TwoArgumentsInvocationExpression(Expression expression, Expression a0, Expression a1)
		: base(expression)
	{
		Argument0 = a0;
		Argument1 = a1;
	}
}
