using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class OneArgumentMethodCallExpression : NotNullMethodCallExpression
{
	public readonly Expression Argument;

	public override IReadOnlyList<Expression> Arguments => new Expression[1] { Argument };

	public override int ArgumentCount => 1;

	public override Expression GetArgument(int i)
	{
		return Argument;
	}

	internal OneArgumentMethodCallExpression(MethodInfo method, Expression argument)
		: base(method)
	{
		Argument = argument;
	}
}
