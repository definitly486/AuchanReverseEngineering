using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class OneBindingMemberInitExpression : MemberInitExpression
{
	public readonly MemberBinding Binding;

	public override IReadOnlyList<MemberBinding> Bindings => new MemberBinding[1] { Binding };

	public override int ArgumentCount => 1;

	public override MemberBinding GetArgument(int i)
	{
		return Binding;
	}

	internal OneBindingMemberInitExpression(Expression expression, MemberBinding b1)
		: base(expression)
	{
		Binding = b1;
	}
}
