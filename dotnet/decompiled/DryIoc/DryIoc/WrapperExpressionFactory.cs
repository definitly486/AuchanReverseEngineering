using System;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public class WrapperExpressionFactory : Factory
{
	private class WrapperExpressionFactoryWithSetup : WrapperExpressionFactory
	{
		public override Setup Setup { get; }

		public WrapperExpressionFactoryWithSetup(Func<Request, Factory, Expression> getServiceExpression, Setup setup)
			: base(getServiceExpression)
		{
			Setup = setup;
		}
	}

	private class WrapperExpressionFactoryWithReuseAndSetup : WrapperExpressionFactoryWithSetup
	{
		public override IReuse Reuse { get; }

		public WrapperExpressionFactoryWithReuseAndSetup(Func<Request, Factory, Expression> getServiceExpression, IReuse reuse, Setup setup)
			: base(getServiceExpression, setup)
		{
			Reuse = reuse;
		}
	}

	private readonly Func<Request, Factory, Expression> _getServiceExpression;

	public override Setup Setup => Setup.Wrapper;

	public static WrapperExpressionFactory Of(Func<Request, Factory, Expression> getServiceExpression)
	{
		return new WrapperExpressionFactory(getServiceExpression);
	}

	public static WrapperExpressionFactory Of(Func<Request, Factory, Expression> getServiceExpression, Setup setup)
	{
		if (setup != null && setup != Setup.Wrapper)
		{
			return new WrapperExpressionFactoryWithSetup(getServiceExpression, setup);
		}
		return new WrapperExpressionFactory(getServiceExpression);
	}

	public static WrapperExpressionFactory Of(Func<Request, Factory, Expression> getServiceExpression, IReuse reuse, Setup setup = null)
	{
		if (reuse != null)
		{
			return new WrapperExpressionFactoryWithReuseAndSetup(getServiceExpression, reuse, setup ?? Setup.Wrapper);
		}
		return Of(getServiceExpression, setup);
	}

	private WrapperExpressionFactory(Func<Request, Factory, Expression> getServiceExpression)
	{
		_getServiceExpression = getServiceExpression;
	}

	public override Expression CreateExpressionOrDefault(Request request)
	{
		return _getServiceExpression(request, null);
	}

	public override Expression CreateExpressionWithWrappedFactory(Request request, Factory serviceFactory)
	{
		return _getServiceExpression(request, serviceFactory);
	}
}
