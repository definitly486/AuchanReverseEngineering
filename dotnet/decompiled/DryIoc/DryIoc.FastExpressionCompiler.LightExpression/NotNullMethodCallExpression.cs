using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class NotNullMethodCallExpression : MethodCallExpression
{
	public override MethodInfo Method { get; }

	internal NotNullMethodCallExpression(MethodInfo method)
	{
		Method = method;
	}
}
