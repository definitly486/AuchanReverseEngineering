using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class TwoArgumentsNewExpression : NewExpression
{
	public readonly Expression Argument0;

	public readonly Expression Argument1;

	public override IReadOnlyList<Expression> Arguments => new Expression[2] { Argument0, Argument1 };

	public override int ArgumentCount => 2;

	public override Expression GetArgument(int i)
	{
		if (i != 0)
		{
			return Argument1;
		}
		return Argument0;
	}

	internal TwoArgumentsNewExpression(ConstructorInfo constructor, Expression a0, Expression a1)
		: base(constructor)
	{
		Argument0 = a0;
		Argument1 = a1;
	}
}
