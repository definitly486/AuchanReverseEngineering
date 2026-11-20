using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class OneArgumentIndexExpression : IndexExpression
{
	public readonly Expression Argument;

	public sealed override IReadOnlyList<Expression> Arguments => new Expression[1] { Argument };

	public override int ArgumentCount => 1;

	public override Expression GetArgument(int index)
	{
		return Argument;
	}

	internal OneArgumentIndexExpression(Expression @object, Expression argument)
		: base(@object)
	{
		Argument = argument;
	}
}
