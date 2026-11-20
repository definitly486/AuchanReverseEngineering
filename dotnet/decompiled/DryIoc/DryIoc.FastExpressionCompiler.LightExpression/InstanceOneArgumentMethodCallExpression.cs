using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstanceOneArgumentMethodCallExpression : OneArgumentMethodCallExpression
{
	public override Expression Object { get; }

	internal InstanceOneArgumentMethodCallExpression(Expression instance, MethodInfo method, Expression argument)
		: base(method, argument)
	{
		Object = instance;
	}
}
