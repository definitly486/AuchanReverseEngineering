using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstanceSixArgumentsMethodCallExpression : SixArgumentsMethodCallExpression
{
	public override Expression Object { get; }

	internal InstanceSixArgumentsMethodCallExpression(Expression instance, MethodInfo method, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4, Expression a5)
		: base(method, a0, a1, a2, a3, a4, a5)
	{
		Object = instance;
	}
}
