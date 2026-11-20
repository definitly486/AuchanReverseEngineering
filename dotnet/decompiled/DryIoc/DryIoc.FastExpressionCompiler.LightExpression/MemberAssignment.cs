using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class MemberAssignment : MemberBinding
{
	public readonly Expression Expression;

	public override MemberBindingType BindingType => MemberBindingType.Assignment;

	internal MemberAssignment(MemberInfo member, Expression expression)
		: base(member)
	{
		Expression = expression;
	}

	internal override System.Linq.Expressions.MemberBinding ToMemberBinding(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Bind(Member, Expression.ToExpression(ref exprsConverted));
	}
}
