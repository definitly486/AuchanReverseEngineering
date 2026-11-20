using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class MemberMemberBinding : MemberBinding
{
	public readonly IReadOnlyList<MemberBinding> Bindings;

	public override MemberBindingType BindingType => MemberBindingType.MemberBinding;

	internal MemberMemberBinding(MemberInfo member, IReadOnlyList<MemberBinding> bindings)
		: base(member)
	{
		Bindings = bindings;
	}

	private static System.Linq.Expressions.MemberBinding[] ToMemberBindings(IReadOnlyList<MemberBinding> items, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (items.Count == 0)
		{
			return Tools.Empty<System.Linq.Expressions.MemberBinding>();
		}
		System.Linq.Expressions.MemberBinding[] array = new System.Linq.Expressions.MemberBinding[items.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = items[i].ToMemberBinding(ref exprsConverted);
		}
		return array;
	}

	internal override System.Linq.Expressions.MemberBinding ToMemberBinding(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MemberBind(Member, ToMemberBindings(Bindings, ref exprsConverted));
	}
}
