namespace Microsoft.CSharp.RuntimeBinder.Semantics;

internal sealed class ExprBinOp : ExprOperator
{
	public Expr OptionalLeftChild { get; set; }

	public Expr OptionalRightChild { get; set; }

	public ExprBinOp(ExpressionKind kind, CType type, Expr left, Expr right)
		: base(kind, type)
	{
		base.Flags = EXPRFLAG.EXF_BINOP;
		OptionalLeftChild = left;
		OptionalRightChild = right;
	}

	public void SetAssignment()
	{
		base.Flags |= EXPRFLAG.EXF_ASSGOP;
	}
}
