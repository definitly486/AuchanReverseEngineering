using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class OpAssignBinaryExpression : AssignBinaryExpression
{
	public sealed override ExpressionType NodeType { get; }

	internal OpAssignBinaryExpression(ExpressionType nodeType, Expression left, Expression right)
		: base(left, right)
	{
		NodeType = nodeType;
	}
}
