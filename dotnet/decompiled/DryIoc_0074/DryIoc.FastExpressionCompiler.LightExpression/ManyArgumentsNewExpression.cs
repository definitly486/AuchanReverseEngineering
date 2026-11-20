using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ManyArgumentsNewExpression : NewExpression
{
	private readonly IReadOnlyList<Expression> _arguments;

	public override IReadOnlyList<Expression> Arguments => _arguments;

	public override int ArgumentCount => _arguments.Count;

	public override Expression GetArgument(int i)
	{
		return _arguments[i];
	}

	internal ManyArgumentsNewExpression(ConstructorInfo constructor, IReadOnlyList<Expression> arguments)
		: base(constructor)
	{
		_arguments = arguments;
	}
}
