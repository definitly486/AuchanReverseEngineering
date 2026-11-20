using System;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

internal sealed class InjectedIntoFactoryDummy : Factory
{
	private static readonly Setup _setup = Setup.AsResolutionCallSetup;

	public override Setup Setup => _setup;

	public override IReuse Reuse => DryIoc.Reuse.Transient;

	public override Type ImplementationType { get; }

	public InjectedIntoFactoryDummy(Type instanceType)
	{
		ImplementationType = instanceType;
	}

	public override Expression CreateExpressionOrDefault(Request request)
	{
		return Throw.For<Expression>(Error.InjectedIntoFactoryDummy);
	}
}
