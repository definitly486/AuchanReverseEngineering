namespace Microsoft.CSharp.RuntimeBinder.Semantics;

internal sealed class ExprUnaryOp : ExprOperator
{
	public Expr Child { get; set; }

	public ExprUnaryOp(ExpressionKind kind, CType type, Expr operand)
		: base(kind, type)
	{
		Child = operand;
	}
}
