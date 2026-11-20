using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class FiveElementNewArrayInitExpression : NewArrayExpression
{
	public readonly Expression Element0;

	public readonly Expression Element1;

	public readonly Expression Element2;

	public readonly Expression Element3;

	public readonly Expression Element4;

	public override ExpressionType NodeType => ExpressionType.NewArrayInit;

	public override IReadOnlyList<Expression> Expressions => new Expression[5] { Element0, Element1, Element2, Element3, Element4 };

	public override int ArgumentCount => 5;

	public override Expression GetArgument(int i)
	{
		return i switch
		{
			3 => Element3, 
			2 => Element2, 
			1 => Element1, 
			0 => Element0, 
			_ => Element4, 
		};
	}

	internal FiveElementNewArrayInitExpression(Type arrayType, Expression el0, Expression el1, Expression el2, Expression el3, Expression el4)
		: base(arrayType)
	{
		Element0 = el0;
		Element1 = el1;
		Element2 = el2;
		Element3 = el3;
		Element4 = el4;
	}
}
