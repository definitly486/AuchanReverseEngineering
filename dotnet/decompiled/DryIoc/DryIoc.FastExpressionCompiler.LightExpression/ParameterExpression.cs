using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class ParameterExpression : Expression
{
	public sealed override ExpressionType NodeType => ExpressionType.Parameter;

	public override Type Type => typeof(object);

	public virtual bool IsByRef => false;

	public string Name { get; }

	internal ParameterExpression(string name)
	{
		Name = name;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Parameter(IsByRef ? Type.MakeByRefType() : Type, Name);
	}

	internal static System.Linq.Expressions.ParameterExpression[] ToParameterExpressions(IReadOnlyList<ParameterExpression> ps, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (ps.Count == 0)
		{
			return Tools.Empty<System.Linq.Expressions.ParameterExpression>();
		}
		if (ps.Count == 1)
		{
			return new System.Linq.Expressions.ParameterExpression[1] { (System.Linq.Expressions.ParameterExpression)ps[0].ToExpression(ref exprsConverted) };
		}
		System.Linq.Expressions.ParameterExpression[] array = new System.Linq.Expressions.ParameterExpression[ps.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (System.Linq.Expressions.ParameterExpression)ps[i].ToExpression(ref exprsConverted);
		}
		return array;
	}
}
