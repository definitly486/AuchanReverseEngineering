using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class WithFalseBranchConditionalExpression : VoidWithFalseBranchConditionalExpression
{
	public override Type Type => IfTrue.Type;

	internal WithFalseBranchConditionalExpression(Expression test, Expression ifTrue, Expression ifFalse)
		: base(test, ifTrue, ifFalse)
	{
	}
}
