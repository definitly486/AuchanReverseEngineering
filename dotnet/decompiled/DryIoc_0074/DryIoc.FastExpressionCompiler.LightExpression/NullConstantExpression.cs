using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NullConstantExpression<T> : ConstantExpression
{
	public override object Value => null;

	public override Type Type => typeof(T);
}
