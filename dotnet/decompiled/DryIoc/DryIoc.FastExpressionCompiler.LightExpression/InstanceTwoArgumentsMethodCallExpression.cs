using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstanceTwoArgumentsMethodCallExpression : TwoArgumentsMethodCallExpression
{
	public override Expression Object { get; }

	internal InstanceTwoArgumentsMethodCallExpression(Expression instance, MethodInfo method, Expression argument0, Expression argument1)
		: base(method, argument0, argument1)
	{
		Object = instance;
	}
}
