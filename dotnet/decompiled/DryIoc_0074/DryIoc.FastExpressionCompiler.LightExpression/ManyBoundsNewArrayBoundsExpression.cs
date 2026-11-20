using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ManyBoundsNewArrayBoundsExpression : NewArrayExpression
{
	public override ExpressionType NodeType => ExpressionType.NewArrayBounds;

	public override IReadOnlyList<Expression> Expressions { get; }

	internal ManyBoundsNewArrayBoundsExpression(Type arrayType, IReadOnlyList<Expression> bounds)
		: base(arrayType)
	{
		Expressions = bounds;
	}
}
