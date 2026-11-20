using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public sealed class FactoryPlaceholder : Factory
{
	public static readonly Factory Default = new FactoryPlaceholder();

	private static readonly Setup _setup = Setup.AsResolutionCallSetup;

	public override Setup Setup => _setup;

	public override IReuse Reuse => DryIoc.Reuse.Transient;

	public override Expression CreateExpressionOrDefault(Request request)
	{
		return Throw.For<Expression>(Error.NoImplementationForPlaceholder, request);
	}
}
