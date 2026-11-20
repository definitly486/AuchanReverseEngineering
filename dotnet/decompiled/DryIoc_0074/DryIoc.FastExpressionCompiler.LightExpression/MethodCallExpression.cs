using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class MethodCallExpression : Expression, IArgumentProvider
{
	public sealed override ExpressionType NodeType => ExpressionType.Call;

	public sealed override Type Type => Method.ReturnType;

	public virtual MethodInfo Method => null;

	public virtual Expression Object => null;

	public virtual IReadOnlyList<Expression> Arguments => Tools.Empty<Expression>();

	public virtual int ArgumentCount => 0;

	public virtual Expression GetArgument(int i)
	{
		throw new NotImplementedException();
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Call(Object?.ToExpression(ref exprsConverted), Method, Expression.ToExpressions(Arguments, ref exprsConverted));
	}
}
