using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class MemberBinding
{
	public readonly MemberInfo Member;

	public abstract MemberBindingType BindingType { get; }

	internal MemberBinding(MemberInfo member)
	{
		Member = member;
	}

	internal abstract System.Linq.Expressions.MemberBinding ToMemberBinding(ref LiveCountArray<LightAndSysExpr> exprsConverted);
}
