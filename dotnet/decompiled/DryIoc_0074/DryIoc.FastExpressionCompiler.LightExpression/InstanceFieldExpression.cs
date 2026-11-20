using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstanceFieldExpression : FieldExpression
{
	public override Expression Expression { get; }

	internal InstanceFieldExpression(Expression instance, FieldInfo field)
		: base(field)
	{
		Expression = instance;
	}
}
