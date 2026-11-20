using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstancePropertyExpression : PropertyExpression
{
	public override Expression Expression { get; }

	internal InstancePropertyExpression(Expression instance, PropertyInfo property)
		: base(property)
	{
		Expression = instance;
	}
}
