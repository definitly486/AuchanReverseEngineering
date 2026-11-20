using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class OneElementNewArrayInitExpression : NewArrayExpression
{
	public readonly Expression Element;

	public override ExpressionType NodeType => ExpressionType.NewArrayInit;

	public override IReadOnlyList<Expression> Expressions => new Expression[1] { Element };

	public override int ArgumentCount => 1;

	public override Expression GetArgument(int i)
	{
		return Element;
	}

	internal OneElementNewArrayInitExpression(Type arrayType, Expression element)
		: base(arrayType)
	{
		Element = element;
	}
}
