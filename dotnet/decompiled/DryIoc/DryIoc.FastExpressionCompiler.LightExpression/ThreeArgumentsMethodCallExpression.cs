using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ThreeArgumentsMethodCallExpression : NotNullMethodCallExpression
{
	public readonly Expression Argument0;

	public readonly Expression Argument1;

	public readonly Expression Argument2;

	public override IReadOnlyList<Expression> Arguments => new Expression[3] { Argument0, Argument1, Argument2 };

	public override int ArgumentCount => 3;

	public override Expression GetArgument(int i)
	{
		return i switch
		{
			1 => Argument1, 
			0 => Argument0, 
			_ => Argument2, 
		};
	}

	internal ThreeArgumentsMethodCallExpression(MethodInfo method, Expression a0, Expression a1, Expression a2)
		: base(method)
	{
		Argument0 = a0;
		Argument1 = a1;
		Argument2 = a2;
	}
}
