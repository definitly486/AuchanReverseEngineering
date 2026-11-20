using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public interface IReuse : IConvertibleToExpression
{
	int Lifespan { get; }

	object Name { get; }

	bool CanApply(Request request);

	Expression Apply(Request request, Expression serviceFactoryExpr);
}
