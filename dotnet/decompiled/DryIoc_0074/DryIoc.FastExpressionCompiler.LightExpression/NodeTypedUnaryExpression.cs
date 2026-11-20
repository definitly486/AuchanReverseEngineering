using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NodeTypedUnaryExpression : UnaryExpression
{
	public override ExpressionType NodeType { get; }

	public NodeTypedUnaryExpression(ExpressionType nodeType, Expression operand)
		: base(operand)
	{
		NodeType = nodeType;
	}
}
