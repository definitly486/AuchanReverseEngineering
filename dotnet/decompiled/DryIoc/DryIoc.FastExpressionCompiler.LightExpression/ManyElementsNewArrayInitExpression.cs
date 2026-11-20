using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ManyElementsNewArrayInitExpression : NewArrayExpression
{
	public override ExpressionType NodeType => ExpressionType.NewArrayInit;

	public override IReadOnlyList<Expression> Expressions { get; }

	internal ManyElementsNewArrayInitExpression(Type arrayType, IReadOnlyList<Expression> elements)
		: base(arrayType)
	{
		Expressions = elements;
	}
}
