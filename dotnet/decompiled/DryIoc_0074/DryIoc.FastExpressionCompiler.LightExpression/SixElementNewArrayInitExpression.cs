using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class SixElementNewArrayInitExpression : NewArrayExpression
{
	public readonly Expression Element0;

	public readonly Expression Element1;

	public readonly Expression Element2;

	public readonly Expression Element3;

	public readonly Expression Element4;

	public readonly Expression Element5;

	public override ExpressionType NodeType => ExpressionType.NewArrayInit;

	public override IReadOnlyList<Expression> Expressions => new Expression[6] { Element0, Element1, Element2, Element3, Element4, Element5 };

	public override int ArgumentCount => 6;

	public override Expression GetArgument(int i)
	{
		return i switch
		{
			4 => Element4, 
			3 => Element3, 
			2 => Element2, 
			1 => Element1, 
			0 => Element0, 
			_ => Element5, 
		};
	}

	internal SixElementNewArrayInitExpression(Type arrayType, Expression el0, Expression el1, Expression el2, Expression el3, Expression el4, Expression el5)
		: base(arrayType)
	{
		Element0 = el0;
		Element1 = el1;
		Element2 = el2;
		Element3 = el3;
		Element4 = el4;
		Element5 = el5;
	}
}
