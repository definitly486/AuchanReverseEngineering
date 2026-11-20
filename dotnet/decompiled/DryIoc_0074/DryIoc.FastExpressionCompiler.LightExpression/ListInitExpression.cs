using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ListInitExpression : Expression
{
	public readonly NewExpression NewExpression;

	public readonly IReadOnlyList<ElementInit> Initializers;

	public override ExpressionType NodeType => ExpressionType.ListInit;

	public override Type Type => NewExpression.Type;

	internal ListInitExpression(NewExpression newExpression, IReadOnlyList<ElementInit> initializers)
	{
		NewExpression = newExpression;
		Initializers = initializers;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> convertedExpressions)
	{
		return System.Linq.Expressions.Expression.ListInit((System.Linq.Expressions.NewExpression)NewExpression.ToExpression(ref convertedExpressions), ToElementInits(Initializers, ref convertedExpressions));
	}

	internal static System.Linq.Expressions.ElementInit[] ToElementInits(IReadOnlyList<ElementInit> elemInits, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (elemInits.Count == 0)
		{
			return Tools.Empty<System.Linq.Expressions.ElementInit>();
		}
		System.Linq.Expressions.ElementInit[] array = new System.Linq.Expressions.ElementInit[elemInits.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = System.Linq.Expressions.Expression.ElementInit(elemInits[i].AddMethod, Expression.ToExpressions(elemInits[i].Arguments, ref exprsConverted));
		}
		return array;
	}
}
