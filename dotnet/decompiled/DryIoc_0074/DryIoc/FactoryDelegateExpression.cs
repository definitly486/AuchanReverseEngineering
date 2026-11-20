using System;
using System.Collections.Generic;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

internal sealed class FactoryDelegateExpression : Expression<FactoryDelegate>
{
	public override Type ReturnType => typeof(object);

	public override int ParameterCount => 1;

	public override IReadOnlyList<ParameterExpression> Parameters => FactoryDelegateCompiler.ResolverContextParamExprs;

	public override ParameterExpression GetParameter(int index)
	{
		return FactoryDelegateCompiler.ResolverContextParamExpr;
	}

	public FactoryDelegateExpression(Expression body)
		: base(body)
	{
	}
}
