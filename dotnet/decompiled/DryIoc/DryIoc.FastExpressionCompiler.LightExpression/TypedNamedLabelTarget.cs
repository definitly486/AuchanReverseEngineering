using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedNamedLabelTarget : NamedLabelTarget
{
	public override Type Type { get; }

	public TypedNamedLabelTarget(Type type, string name)
		: base(name)
	{
		Type = type;
	}
}
