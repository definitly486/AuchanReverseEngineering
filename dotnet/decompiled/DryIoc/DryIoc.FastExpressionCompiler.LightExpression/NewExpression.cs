using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class NewExpression : Expression, IArgumentProvider
{
	public readonly ConstructorInfo Constructor;

	public sealed override ExpressionType NodeType => ExpressionType.New;

	public override Type Type => Constructor.DeclaringType;

	public virtual IReadOnlyList<Expression> Arguments => Tools.Empty<Expression>();

	public virtual int ArgumentCount => 0;

	public virtual bool NoByRefArgs => false;

	public virtual Expression GetArgument(int i)
	{
		throw new NotImplementedException();
	}

	internal NewExpression(ConstructorInfo constructor)
	{
		Constructor = constructor;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.New(Constructor, Expression.ToExpressions(Arguments, ref exprsConverted));
	}
}
