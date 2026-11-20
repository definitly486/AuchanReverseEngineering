using System;
using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ElementInit : IArgumentProvider
{
	public readonly MethodInfo AddMethod;

	public virtual IReadOnlyList<Expression> Arguments => Tools.Empty<Expression>();

	public virtual int ArgumentCount => 0;

	public virtual Expression GetArgument(int i)
	{
		throw new NotImplementedException();
	}

	internal ElementInit(MethodInfo addMethod)
	{
		AddMethod = addMethod;
	}
}
