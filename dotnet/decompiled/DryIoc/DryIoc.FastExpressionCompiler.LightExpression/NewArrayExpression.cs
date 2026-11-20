using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class NewArrayExpression : Expression, IArgumentProvider
{
	public sealed override Type Type { get; }

	public abstract IReadOnlyList<Expression> Expressions { get; }

	public virtual int ArgumentCount => Expressions.Count;

	public virtual Expression GetArgument(int i)
	{
		return Expressions[i];
	}

	internal NewArrayExpression(Type arrayType)
	{
		Type = arrayType;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		Type elementType = Type.GetElementType();
		System.Linq.Expressions.Expression[] array = Expression.ToExpressions(Expressions, ref exprsConverted);
		if (NodeType != ExpressionType.NewArrayInit)
		{
			return System.Linq.Expressions.Expression.NewArrayBounds(Type.GetElementType(), array);
		}
		return System.Linq.Expressions.Expression.NewArrayInit(Type.GetElementType(), array);
	}
}
