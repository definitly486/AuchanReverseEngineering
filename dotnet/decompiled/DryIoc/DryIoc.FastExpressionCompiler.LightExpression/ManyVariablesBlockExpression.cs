using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ManyVariablesBlockExpression : BlockExpression
{
	public sealed override IReadOnlyList<ParameterExpression> Variables { get; }

	public sealed override int ArgumentCount => Expressions.Count;

	public sealed override Expression GetArgument(int index)
	{
		return Expressions[index];
	}

	internal ManyVariablesBlockExpression(IReadOnlyList<ParameterExpression> variables, IReadOnlyList<Expression> expressions)
		: base(expressions)
	{
		Variables = variables;
	}
}
