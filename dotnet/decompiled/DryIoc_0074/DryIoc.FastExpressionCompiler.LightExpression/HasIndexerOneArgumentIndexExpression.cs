using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class HasIndexerOneArgumentIndexExpression : OneArgumentIndexExpression
{
	public override PropertyInfo Indexer { get; }

	internal HasIndexerOneArgumentIndexExpression(Expression @object, PropertyInfo indexer, Expression argument)
		: base(@object, argument)
	{
		Indexer = indexer;
	}
}
