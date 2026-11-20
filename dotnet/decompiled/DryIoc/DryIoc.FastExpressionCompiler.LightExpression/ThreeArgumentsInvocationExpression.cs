using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ThreeArgumentsInvocationExpression : NotNullExpressionInvocationExpression
{
	public readonly Expression Argument0;

	public readonly Expression Argument1;

	public readonly Expression Argument2;

	public sealed override IReadOnlyList<Expression> Arguments => new Expression[3] { Argument0, Argument1, Argument2 };

	public sealed override int ArgumentCount => 3;

	public sealed override Expression GetArgument(int i)
	{
		return i switch
		{
			1 => Argument1, 
			0 => Argument0, 
			_ => Argument2, 
		};
	}

	internal ThreeArgumentsInvocationExpression(Expression expression, Expression a0, Expression a1, Expression a2)
		: base(expression)
	{
		Argument0 = a0;
		Argument1 = a1;
		Argument2 = a2;
	}
}
