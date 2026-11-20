using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ManyBindingsMemberInitExpression : MemberInitExpression
{
	public override IReadOnlyList<MemberBinding> Bindings { get; }

	public override int ArgumentCount => Bindings.Count;

	public override MemberBinding GetArgument(int i)
	{
		return Bindings[i];
	}

	internal ManyBindingsMemberInitExpression(Expression expression, IReadOnlyList<MemberBinding> bindings)
		: base(expression)
	{
		Bindings = bindings;
	}
}
