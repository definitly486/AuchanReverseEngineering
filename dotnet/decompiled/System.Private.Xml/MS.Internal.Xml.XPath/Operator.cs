using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class Operator : AstNode
{
	public enum Op
	{
		INVALID,
		OR,
		AND,
		EQ,
		NE,
		LT,
		LE,
		GT,
		GE,
		PLUS,
		MINUS,
		MUL,
		DIV,
		MOD,
		UNION
	}

	private readonly Op _opType;

	private readonly AstNode _opnd1;

	private readonly AstNode _opnd2;

	public override AstType Type => AstType.Operator;

	public override XPathResultType ReturnType
	{
		get
		{
			if (_opType <= Op.GE)
			{
				return XPathResultType.Boolean;
			}
			if (_opType <= Op.MOD)
			{
				return XPathResultType.Number;
			}
			return XPathResultType.NodeSet;
		}
	}

	public Operator(Op op, AstNode opnd1, AstNode opnd2)
	{
		_opType = op;
		_opnd1 = opnd1;
		_opnd2 = opnd2;
	}
}
