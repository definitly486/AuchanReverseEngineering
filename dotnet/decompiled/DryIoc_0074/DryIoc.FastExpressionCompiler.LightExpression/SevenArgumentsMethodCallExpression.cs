using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class SevenArgumentsMethodCallExpression : NotNullMethodCallExpression
{
	public readonly Expression Argument0;

	public readonly Expression Argument1;

	public readonly Expression Argument2;

	public readonly Expression Argument3;

	public readonly Expression Argument4;

	public readonly Expression Argument5;

	public readonly Expression Argument6;

	public override IReadOnlyList<Expression> Arguments => new Expression[7] { Argument0, Argument1, Argument2, Argument3, Argument4, Argument5, Argument6 };

	public override int ArgumentCount => 7;

	public override Expression GetArgument(int i)
	{
		return i switch
		{
			5 => Argument5, 
			4 => Argument4, 
			3 => Argument3, 
			2 => Argument2, 
			1 => Argument1, 
			0 => Argument0, 
			_ => Argument6, 
		};
	}

	internal SevenArgumentsMethodCallExpression(MethodInfo method, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4, Expression a5, Expression a6)
		: base(method)
	{
		Argument0 = a0;
		Argument1 = a1;
		Argument2 = a2;
		Argument3 = a3;
		Argument4 = a4;
		Argument5 = a5;
		Argument6 = a6;
	}
}
