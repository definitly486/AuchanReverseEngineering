using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ManyArgumentsIndexExpression : IndexExpression
{
	public sealed override IReadOnlyList<Expression> Arguments { get; }

	internal ManyArgumentsIndexExpression(Expression @object, IReadOnlyList<Expression> arguments)
		: base(@object)
	{
		Arguments = arguments ?? Tools.Empty<Expression>();
	}
}
