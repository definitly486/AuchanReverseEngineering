using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TwoBindingsMemberInitExpression : MemberInitExpression
{
	public readonly MemberBinding Binding0;

	public readonly MemberBinding Binding1;

	public override IReadOnlyList<MemberBinding> Bindings => new MemberBinding[2] { Binding0, Binding1 };

	public override int ArgumentCount => 2;

	public override MemberBinding GetArgument(int i)
	{
		if (i != 0)
		{
			return Binding1;
		}
		return Binding0;
	}

	internal TwoBindingsMemberInitExpression(Expression expression, MemberBinding b0, MemberBinding b1)
		: base(expression)
	{
		Binding0 = b0;
		Binding1 = b1;
	}
}
