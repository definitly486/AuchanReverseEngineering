using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class SixBindingsMemberInitExpression : MemberInitExpression
{
	public readonly MemberBinding Binding0;

	public readonly MemberBinding Binding1;

	public readonly MemberBinding Binding2;

	public readonly MemberBinding Binding3;

	public readonly MemberBinding Binding4;

	public readonly MemberBinding Binding5;

	public override IReadOnlyList<MemberBinding> Bindings => new MemberBinding[6] { Binding0, Binding1, Binding2, Binding3, Binding4, Binding5 };

	public override int ArgumentCount => 6;

	public override MemberBinding GetArgument(int i)
	{
		return i switch
		{
			4 => Binding4, 
			3 => Binding3, 
			2 => Binding2, 
			1 => Binding1, 
			0 => Binding0, 
			_ => Binding5, 
		};
	}

	internal SixBindingsMemberInitExpression(Expression expression, MemberBinding b0, MemberBinding b1, MemberBinding b2, MemberBinding b3, MemberBinding b4, MemberBinding b5)
		: base(expression)
	{
		Binding0 = b0;
		Binding1 = b1;
		Binding2 = b2;
		Binding3 = b3;
		Binding4 = b4;
		Binding5 = b5;
	}
}
