namespace DryIoc.FastExpressionCompiler.LightExpression;

public class VoidWithFalseBranchConditionalExpression : ConditionalExpression
{
	public override Expression IfFalse { get; }

	internal VoidWithFalseBranchConditionalExpression(Expression test, Expression ifTrue, Expression ifFalse)
		: base(test, ifTrue)
	{
		IfFalse = ifFalse;
	}
}
