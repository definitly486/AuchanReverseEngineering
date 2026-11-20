using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class IndexExpression : Expression, IArgumentProvider
{
	public readonly Expression Object;

	public sealed override ExpressionType NodeType => ExpressionType.Index;

	public sealed override Type Type => Indexer?.PropertyType ?? Object.Type.GetElementType();

	public abstract IReadOnlyList<Expression> Arguments { get; }

	public virtual PropertyInfo Indexer => null;

	public virtual int ArgumentCount => Arguments.Count;

	public virtual Expression GetArgument(int index)
	{
		return Arguments[index];
	}

	internal IndexExpression(Expression @object)
	{
		Object = @object;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MakeIndex(Object.ToExpression(ref exprsConverted), Indexer, Expression.ToExpressions(Arguments, ref exprsConverted));
	}
}
