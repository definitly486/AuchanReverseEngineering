using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class PropertyExpression : MemberExpression
{
	public override Type Type => PropertyInfo.PropertyType;

	public PropertyInfo PropertyInfo => (PropertyInfo)Member;

	internal PropertyExpression(PropertyInfo property)
		: base(property)
	{
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Property(Expression?.ToExpression(ref exprsConverted), PropertyInfo);
	}
}
