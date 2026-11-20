using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedWithFalseBranchConditionalExpression : VoidWithFalseBranchConditionalExpression
{
	public override Type Type { get; }

	internal TypedWithFalseBranchConditionalExpression(Expression test, Expression ifTrue, Expression ifFalse, Type type)
		: base(test, ifTrue, ifFalse)
	{
		Type = type;
	}
}
