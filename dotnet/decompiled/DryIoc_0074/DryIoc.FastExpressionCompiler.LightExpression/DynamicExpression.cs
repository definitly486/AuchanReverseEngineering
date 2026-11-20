using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class DynamicExpression : Expression
{
	public override ExpressionType NodeType => ExpressionType.Dynamic;

	public override Type Type => typeof(object);

	public Type DelegateType { get; }

	public CallSiteBinder Binder { get; }

	public IReadOnlyList<Expression> Arguments { get; }

	public DynamicExpression(Type delegateType, CallSiteBinder binder, IReadOnlyList<Expression> arguments)
	{
		DelegateType = delegateType;
		Binder = binder;
		Arguments = arguments;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MakeDynamic(DelegateType, Binder, Expression.ToExpressions(Arguments, ref exprsConverted));
	}
}
