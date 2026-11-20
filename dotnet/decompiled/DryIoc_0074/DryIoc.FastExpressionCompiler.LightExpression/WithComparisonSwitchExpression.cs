using System;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class WithComparisonSwitchExpression : SwitchExpression
{
	public override MethodInfo Comparison { get; }

	public WithComparisonSwitchExpression(Type type, Expression switchValue, Expression defaultBody, SwitchCase[] cases, MethodInfo comparison)
		: base(type, switchValue, defaultBody, cases)
	{
		Comparison = comparison;
	}
}
