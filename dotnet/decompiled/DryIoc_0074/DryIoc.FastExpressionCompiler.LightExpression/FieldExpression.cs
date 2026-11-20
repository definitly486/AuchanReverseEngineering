using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class FieldExpression : MemberExpression
{
	public override Type Type => FieldInfo.FieldType;

	public FieldInfo FieldInfo => (FieldInfo)Member;

	internal FieldExpression(FieldInfo field)
		: base(field)
	{
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Field(Expression?.ToExpression(ref exprsConverted), FieldInfo);
	}
}
