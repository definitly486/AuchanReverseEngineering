using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstanceFourArgumentsMethodCallExpression : FourArgumentsMethodCallExpression
{
	public override Expression Object { get; }

	internal InstanceFourArgumentsMethodCallExpression(Expression instance, MethodInfo method, Expression argument0, Expression argument1, Expression argument2, Expression argument3)
		: base(method, argument0, argument1, argument2, argument3)
	{
		Object = instance;
	}
}
