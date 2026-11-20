using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ManyArgumentsMethodCallExpression : NotNullMethodCallExpression
{
	private readonly IReadOnlyList<Expression> _arguments;

	public sealed override IReadOnlyList<Expression> Arguments => _arguments;

	public sealed override int ArgumentCount => _arguments.Count;

	public sealed override Expression GetArgument(int i)
	{
		return _arguments[i];
	}

	internal ManyArgumentsMethodCallExpression(MethodInfo method, IReadOnlyList<Expression> arguments)
		: base(method)
	{
		_arguments = arguments;
	}
}
