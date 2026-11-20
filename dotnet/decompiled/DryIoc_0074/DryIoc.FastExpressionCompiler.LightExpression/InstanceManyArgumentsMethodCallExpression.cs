using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class InstanceManyArgumentsMethodCallExpression : ManyArgumentsMethodCallExpression
{
	public override Expression Object { get; }

	internal InstanceManyArgumentsMethodCallExpression(Expression instance, MethodInfo method, IReadOnlyList<Expression> arguments)
		: base(method, arguments)
	{
		Object = instance;
	}
}
