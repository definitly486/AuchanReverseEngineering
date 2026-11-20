using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class IntConstantExpression : ConstantExpression
{
	public readonly int IntValue;

	public override Type Type => typeof(int);

	public override object Value => IntValue;

	internal IntConstantExpression(int value)
	{
		IntValue = value;
	}
}
