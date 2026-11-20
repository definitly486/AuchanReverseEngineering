using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal sealed class LogicalBinaryExpression : BinaryExpression
{
	public override ExpressionType NodeType { get; }

	public override Type Type => typeof(bool);

	internal LogicalBinaryExpression(ExpressionType nodeType, Expression left, Expression right)
		: base(left, right)
	{
		NodeType = nodeType;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (NodeType == ExpressionType.Equal || NodeType == ExpressionType.NotEqual)
		{
			System.Linq.Expressions.Expression expression = Left.ToExpression(ref exprsConverted);
			System.Linq.Expressions.Expression expression2 = Right.ToExpression(ref exprsConverted);
			if (expression.Type.GetTypeInfo().IsPrimitive)
			{
				expression = TryConvertSysExprToInt(expression);
				expression2 = TryConvertSysExprToInt(expression2);
			}
			return System.Linq.Expressions.Expression.MakeBinary(NodeType, expression, expression2);
		}
		return base.CreateSysExpression(ref exprsConverted);
	}

	private static System.Linq.Expressions.Expression TryConvertSysExprToInt(System.Linq.Expressions.Expression e)
	{
		Type type = e.Type;
		if (type == typeof(byte) || type == typeof(sbyte) || type == typeof(short) || type == typeof(ushort))
		{
			return System.Linq.Expressions.Expression.Convert(e, typeof(int));
		}
		return e;
	}
}
