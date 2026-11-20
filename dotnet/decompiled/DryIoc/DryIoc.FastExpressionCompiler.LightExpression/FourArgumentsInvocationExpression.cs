using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class FourArgumentsInvocationExpression : NotNullExpressionInvocationExpression
{
	public readonly Expression Argument0;

	public readonly Expression Argument1;

	public readonly Expression Argument2;

	public readonly Expression Argument3;

	public sealed override IReadOnlyList<Expression> Arguments => new Expression[4] { Argument0, Argument1, Argument2, Argument3 };

	public sealed override int ArgumentCount => 4;

	public sealed override Expression GetArgument(int i)
	{
		return i switch
		{
			2 => Argument2, 
			1 => Argument1, 
			0 => Argument0, 
			_ => Argument3, 
		};
	}

	internal FourArgumentsInvocationExpression(Expression expression, Expression a0, Expression a1, Expression a2, Expression a3)
		: base(expression)
	{
		Argument0 = a0;
		Argument1 = a1;
		Argument2 = a2;
		Argument3 = a3;
	}
}
