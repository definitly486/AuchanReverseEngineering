using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class SixArgumentsInvocationExpression : NotNullExpressionInvocationExpression
{
	public readonly Expression Argument0;

	public readonly Expression Argument1;

	public readonly Expression Argument2;

	public readonly Expression Argument3;

	public readonly Expression Argument4;

	public readonly Expression Argument5;

	public sealed override IReadOnlyList<Expression> Arguments => new Expression[6] { Argument0, Argument1, Argument2, Argument3, Argument4, Argument5 };

	public sealed override int ArgumentCount => 6;

	public sealed override Expression GetArgument(int i)
	{
		return i switch
		{
			4 => Argument4, 
			3 => Argument3, 
			2 => Argument2, 
			1 => Argument1, 
			0 => Argument0, 
			_ => Argument5, 
		};
	}

	internal SixArgumentsInvocationExpression(Expression expression, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4, Expression a5)
		: base(expression)
	{
		Argument0 = a0;
		Argument1 = a1;
		Argument2 = a2;
		Argument3 = a3;
		Argument4 = a4;
		Argument5 = a5;
	}
}
