using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class OneBoundNewArrayBoundsExpression : NewArrayExpression
{
	public readonly Expression Bound;

	public override ExpressionType NodeType => ExpressionType.NewArrayBounds;

	public override IReadOnlyList<Expression> Expressions => new Expression[1] { Bound };

	public override int ArgumentCount => 1;

	public override Expression GetArgument(int i)
	{
		return Bound;
	}

	internal OneBoundNewArrayBoundsExpression(Type arrayType, Expression bound)
		: base(arrayType)
	{
		Bound = bound;
	}
}
