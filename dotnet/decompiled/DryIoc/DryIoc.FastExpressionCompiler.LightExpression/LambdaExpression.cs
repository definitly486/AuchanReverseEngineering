using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class LambdaExpression : Expression, IParameterProvider
{
	public readonly Expression Body;

	public sealed override ExpressionType NodeType => ExpressionType.Lambda;

	public virtual Type ReturnType => Body.Type;

	public virtual IReadOnlyList<ParameterExpression> Parameters => Tools.Empty<ParameterExpression>();

	public virtual int ParameterCount => 0;

	public virtual ParameterExpression GetParameter(int index)
	{
		throw new NotImplementedException("Requested the parameter from the no-parameter lambda");
	}

	protected LambdaExpression(Expression body)
	{
		Body = body;
	}

	public System.Linq.Expressions.LambdaExpression ToLambdaExpression()
	{
		return (System.Linq.Expressions.LambdaExpression)ToExpression();
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Lambda(Type, Body.ToExpression(ref exprsConverted), ParameterExpression.ToParameterExpressions(Parameters, ref exprsConverted));
	}
}
