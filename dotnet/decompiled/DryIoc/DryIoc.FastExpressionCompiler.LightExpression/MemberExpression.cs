using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class MemberExpression : Expression
{
	public readonly MemberInfo Member;

	public sealed override ExpressionType NodeType => ExpressionType.MemberAccess;

	public virtual Expression Expression => null;

	protected MemberExpression(MemberInfo member)
	{
		Member = member;
	}
}
