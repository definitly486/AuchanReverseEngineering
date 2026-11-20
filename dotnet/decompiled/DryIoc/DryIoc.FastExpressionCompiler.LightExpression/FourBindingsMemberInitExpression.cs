using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class FourBindingsMemberInitExpression : MemberInitExpression
{
	public readonly MemberBinding Binding0;

	public readonly MemberBinding Binding1;

	public readonly MemberBinding Binding2;

	public readonly MemberBinding Binding3;

	public override IReadOnlyList<MemberBinding> Bindings => new MemberBinding[4] { Binding0, Binding1, Binding2, Binding3 };

	public override int ArgumentCount => 4;

	public override MemberBinding GetArgument(int i)
	{
		return i switch
		{
			2 => Binding2, 
			1 => Binding1, 
			0 => Binding0, 
			_ => Binding3, 
		};
	}

	internal FourBindingsMemberInitExpression(Expression expression, MemberBinding b0, MemberBinding b1, MemberBinding b2, MemberBinding b3)
		: base(expression)
	{
		Binding0 = b0;
		Binding1 = b1;
		Binding2 = b2;
		Binding3 = b3;
	}
}
