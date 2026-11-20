using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class BlockExpression : Expression, IArgumentProvider
{
	public readonly IReadOnlyList<Expression> Expressions;

	public override ExpressionType NodeType => ExpressionType.Block;

	public override Type Type => Result.Type;

	public virtual IReadOnlyList<ParameterExpression> Variables => Tools.Empty<ParameterExpression>();

	public Expression Result => Expressions[Expressions.Count - 1];

	public virtual int ArgumentCount => 0;

	public virtual Expression GetArgument(int index)
	{
		throw new NotImplementedException();
	}

	internal BlockExpression(IReadOnlyList<Expression> expressions)
	{
		Expressions = expressions;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Block(Type, ParameterExpression.ToParameterExpressions(Variables, ref exprsConverted), Expression.ToExpressions(Expressions, ref exprsConverted));
	}
}
