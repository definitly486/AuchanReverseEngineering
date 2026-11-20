using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ManyArgumentsElementInit : ElementInit
{
	public override IReadOnlyList<Expression> Arguments { get; }

	public override int ArgumentCount => Arguments.Count;

	public override Expression GetArgument(int i)
	{
		return Arguments[i];
	}

	internal ManyArgumentsElementInit(MethodInfo addMethod, IReadOnlyList<Expression> args)
		: base(addMethod)
	{
		Arguments = args;
	}
}
