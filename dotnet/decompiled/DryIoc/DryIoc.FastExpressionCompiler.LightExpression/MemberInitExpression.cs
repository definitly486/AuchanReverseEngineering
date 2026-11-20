using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class MemberInitExpression : Expression, IArgumentProvider<MemberBinding>
{
	public readonly Expression Expression;

	public sealed override ExpressionType NodeType => ExpressionType.MemberInit;

	public override Type Type => Expression.Type;

	public NewExpression NewExpression => Expression as NewExpression;

	public virtual IReadOnlyList<MemberBinding> Bindings => Tools.Empty<MemberBinding>();

	public virtual int ArgumentCount => 0;

	public virtual MemberBinding GetArgument(int i)
	{
		throw new NotImplementedException();
	}

	internal MemberInitExpression(Expression expression)
	{
		Expression = expression;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MemberInit((System.Linq.Expressions.NewExpression)NewExpression.ToExpression(ref exprsConverted), BindingsToExpressions(Bindings, ref exprsConverted));
	}

	internal static System.Linq.Expressions.MemberBinding[] BindingsToExpressions(IReadOnlyList<MemberBinding> ms, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (ms.Count == 0)
		{
			return Tools.Empty<System.Linq.Expressions.MemberBinding>();
		}
		if (ms.Count == 1)
		{
			return new System.Linq.Expressions.MemberBinding[1] { ms[0].ToMemberBinding(ref exprsConverted) };
		}
		System.Linq.Expressions.MemberBinding[] array = new System.Linq.Expressions.MemberBinding[ms.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ms[i].ToMemberBinding(ref exprsConverted);
		}
		return array;
	}
}
