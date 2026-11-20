using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ThreeBindingsMemberInitExpression : MemberInitExpression
{
	public readonly MemberBinding Binding0;

	public readonly MemberBinding Binding1;

	public readonly MemberBinding Binding2;

	public override IReadOnlyList<MemberBinding> Bindings => new MemberBinding[3] { Binding0, Binding1, Binding2 };

	public override int ArgumentCount => 3;

	public override MemberBinding GetArgument(int i)
	{
		return i switch
		{
			1 => Binding1, 
			0 => Binding0, 
			_ => Binding2, 
		};
	}

	internal ThreeBindingsMemberInitExpression(Expression expression, MemberBinding b0, MemberBinding b1, MemberBinding b2)
		: base(expression)
	{
		Binding0 = b0;
		Binding1 = b1;
		Binding2 = b2;
	}
}
