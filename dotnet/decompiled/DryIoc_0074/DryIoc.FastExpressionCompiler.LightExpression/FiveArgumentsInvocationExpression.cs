using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class FiveArgumentsInvocationExpression : NotNullExpressionInvocationExpression
{
	public readonly Expression Argument0;

	public readonly Expression Argument1;

	public readonly Expression Argument2;

	public readonly Expression Argument3;

	public readonly Expression Argument4;

	public sealed override IReadOnlyList<Expression> Arguments => new Expression[5] { Argument0, Argument1, Argument2, Argument3, Argument4 };

	public sealed override int ArgumentCount => 5;

	public sealed override Expression GetArgument(int i)
	{
		return i switch
		{
			3 => Argument3, 
			2 => Argument2, 
			1 => Argument1, 
			0 => Argument0, 
			_ => Argument4, 
		};
	}

	internal FiveArgumentsInvocationExpression(Expression expression, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4)
		: base(expression)
	{
		Argument0 = a0;
		Argument1 = a1;
		Argument2 = a2;
		Argument3 = a3;
		Argument4 = a4;
	}
}
