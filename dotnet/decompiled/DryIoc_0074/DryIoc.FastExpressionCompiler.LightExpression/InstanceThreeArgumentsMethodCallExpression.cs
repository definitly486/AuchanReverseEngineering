using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstanceThreeArgumentsMethodCallExpression : ThreeArgumentsMethodCallExpression
{
	public override Expression Object { get; }

	internal InstanceThreeArgumentsMethodCallExpression(Expression instance, MethodInfo method, Expression a0, Expression a1, Expression a2)
		: base(method, a0, a1, a2)
	{
		Object = instance;
	}
}
