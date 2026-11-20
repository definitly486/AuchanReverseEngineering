using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedLabelTarget : LabelTarget
{
	public override Type Type { get; }

	public TypedLabelTarget(Type type)
	{
		Type = type;
	}
}
