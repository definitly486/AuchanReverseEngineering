using System;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public sealed class ExpressionFactory : Factory
{
	private readonly Func<Request, Expression> _getServiceExpression;

	public override IReuse Reuse { get; }

	public override Setup Setup { get; }

	public ExpressionFactory(Func<Request, Expression> getServiceExpression, IReuse reuse = null, Setup setup = null)
	{
		_getServiceExpression = getServiceExpression.ThrowIfNull();
		Reuse = reuse;
		Setup = setup ?? Setup.Default;
	}

	public override Expression CreateExpressionOrDefault(Request request)
	{
		return _getServiceExpression(request);
	}
}
