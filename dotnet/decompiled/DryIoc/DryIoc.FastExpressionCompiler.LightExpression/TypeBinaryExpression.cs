using System;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypeBinaryExpression : Expression
{
	public readonly Expression Expression;

	public override ExpressionType NodeType { get; }

	public override Type Type => typeof(bool);

	public Type TypeOperand { get; }

	internal TypeBinaryExpression(ExpressionType nodeType, Expression expression, Type typeOperand)
	{
		NodeType = nodeType;
		Expression = expression;
		TypeOperand = typeOperand;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return NodeType switch
		{
			ExpressionType.TypeIs => System.Linq.Expressions.Expression.TypeIs(Expression.ToExpression(ref exprsConverted), TypeOperand), 
			ExpressionType.TypeEqual => System.Linq.Expressions.Expression.TypeEqual(Expression.ToExpression(ref exprsConverted), TypeOperand), 
			_ => throw new NotSupportedException(), 
		};
	}
}
