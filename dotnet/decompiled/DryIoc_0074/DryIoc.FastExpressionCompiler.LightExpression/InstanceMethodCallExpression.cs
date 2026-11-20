using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstanceMethodCallExpression : NotNullMethodCallExpression
{
	public override Expression Object { get; }

	internal InstanceMethodCallExpression(Expression instance, MethodInfo method)
		: base(method)
	{
		Object = instance;
	}
}
