using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class InvocationExpression : Expression, IArgumentProvider
{
	public sealed override ExpressionType NodeType => ExpressionType.Invoke;

	public override Type Type => ((LambdaExpression)Expression).ReturnType;

	public virtual Expression Expression => null;

	public virtual IReadOnlyList<Expression> Arguments => Tools.Empty<Expression>();

	public virtual int ArgumentCount => 0;

	public virtual Expression GetArgument(int index)
	{
		throw new NotImplementedException();
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Invoke(Expression.ToExpression(ref exprsConverted), Expression.ToExpressions(Arguments, ref exprsConverted));
	}
}
