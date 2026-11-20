using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ThreeElementNewArrayInitExpression : NewArrayExpression
{
	public readonly Expression Element0;

	public readonly Expression Element1;

	public readonly Expression Element2;

	public override ExpressionType NodeType => ExpressionType.NewArrayInit;

	public override IReadOnlyList<Expression> Expressions => new Expression[3] { Element0, Element1, Element2 };

	public override int ArgumentCount => 3;

	public override Expression GetArgument(int i)
	{
		return i switch
		{
			1 => Element1, 
			0 => Element0, 
			_ => Element2, 
		};
	}

	internal ThreeElementNewArrayInitExpression(Type arrayType, Expression el0, Expression el1, Expression el2)
		: base(arrayType)
	{
		Element0 = el0;
		Element1 = el1;
		Element2 = el2;
	}
}
