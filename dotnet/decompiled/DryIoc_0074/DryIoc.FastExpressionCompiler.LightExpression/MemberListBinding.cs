using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class MemberListBinding : MemberBinding
{
	public readonly IReadOnlyList<ElementInit> Initializers;

	public override MemberBindingType BindingType => MemberBindingType.ListBinding;

	internal MemberListBinding(MemberInfo member, IReadOnlyList<ElementInit> initializers)
		: base(member)
	{
		Initializers = initializers;
	}

	internal override System.Linq.Expressions.MemberBinding ToMemberBinding(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.ListBind(Member, ListInitExpression.ToElementInits(Initializers, ref exprsConverted));
	}
}
