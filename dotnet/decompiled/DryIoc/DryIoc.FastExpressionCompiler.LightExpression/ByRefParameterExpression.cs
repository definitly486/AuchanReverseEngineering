using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal sealed class ByRefParameterExpression : ParameterExpression
{
	public override bool IsByRef => true;

	public override Type Type { get; }

	internal ByRefParameterExpression(Type type, string name)
		: base(name)
	{
		Type = type;
	}
}
