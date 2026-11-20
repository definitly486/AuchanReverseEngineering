using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TwoElementNewArrayInitExpression : NewArrayExpression
{
	public readonly Expression Element0;

	public readonly Expression Element1;

	public override ExpressionType NodeType => ExpressionType.NewArrayInit;

	public override IReadOnlyList<Expression> Expressions => new Expression[2] { Element0, Element1 };

	public override int ArgumentCount => 2;

	public override Expression GetArgument(int i)
	{
		if (i != 0)
		{
			return Element1;
		}
		return Element0;
	}

	internal TwoElementNewArrayInitExpression(Type arrayType, Expression el0, Expression el1)
		: base(arrayType)
	{
		Element0 = el0;
		Element1 = el1;
	}
}
