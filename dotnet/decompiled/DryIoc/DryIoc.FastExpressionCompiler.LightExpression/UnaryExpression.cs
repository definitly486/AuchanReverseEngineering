using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class UnaryExpression : Expression
{
	public readonly Expression Operand;

	public override Type Type => Operand.Type;

	public virtual MethodInfo Method => null;

	public UnaryExpression(Expression operand)
	{
		Operand = operand;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return NodeType switch
		{
			ExpressionType.ArrayLength => System.Linq.Expressions.Expression.ArrayLength(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.Convert => System.Linq.Expressions.Expression.Convert(Operand.ToExpression(ref exprsConverted), Type, Method), 
			ExpressionType.ConvertChecked => System.Linq.Expressions.Expression.ConvertChecked(Operand.ToExpression(ref exprsConverted), Type, Method), 
			ExpressionType.Decrement => System.Linq.Expressions.Expression.Decrement(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.Increment => System.Linq.Expressions.Expression.Increment(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.IsFalse => System.Linq.Expressions.Expression.IsFalse(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.IsTrue => System.Linq.Expressions.Expression.IsTrue(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.Negate => System.Linq.Expressions.Expression.Negate(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.NegateChecked => System.Linq.Expressions.Expression.NegateChecked(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.OnesComplement => System.Linq.Expressions.Expression.OnesComplement(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.PostDecrementAssign => System.Linq.Expressions.Expression.PostDecrementAssign(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.PostIncrementAssign => System.Linq.Expressions.Expression.PostIncrementAssign(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.PreDecrementAssign => System.Linq.Expressions.Expression.PreDecrementAssign(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.PreIncrementAssign => System.Linq.Expressions.Expression.PreIncrementAssign(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.Quote => System.Linq.Expressions.Expression.Quote(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.UnaryPlus => System.Linq.Expressions.Expression.UnaryPlus(Operand.ToExpression(ref exprsConverted)), 
			ExpressionType.Unbox => System.Linq.Expressions.Expression.Unbox(Operand.ToExpression(ref exprsConverted), Type), 
			ExpressionType.Throw => System.Linq.Expressions.Expression.Throw(Operand.ToExpression(ref exprsConverted), Type), 
			ExpressionType.TypeAs => System.Linq.Expressions.Expression.TypeAs(Operand.ToExpression(ref exprsConverted), Type), 
			ExpressionType.Not => System.Linq.Expressions.Expression.Not(Operand.ToExpression(ref exprsConverted)), 
			_ => throw new NotSupportedException("Cannot convert Expression to Expression of type " + NodeType), 
		};
	}
}
