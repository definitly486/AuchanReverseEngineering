using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class HasIndexerManyArgumentsIndexExpression : ManyArgumentsIndexExpression
{
	public override PropertyInfo Indexer { get; }

	internal HasIndexerManyArgumentsIndexExpression(Expression @object, PropertyInfo indexer, IReadOnlyList<Expression> arguments)
		: base(@object, arguments)
	{
		Indexer = indexer;
	}
}
