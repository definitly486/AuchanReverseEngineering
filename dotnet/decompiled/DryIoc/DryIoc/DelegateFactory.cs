using System;
using System.Runtime.CompilerServices;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public class DelegateFactory : Factory
{
	internal sealed class WithSingletonReuse : DelegateFactory
	{
		public override IReuse Reuse => DryIoc.Reuse.Singleton;

		public WithSingletonReuse(FactoryDelegate factoryDelegate)
			: base(factoryDelegate)
		{
		}
	}

	internal sealed class WithScopedReuse : DelegateFactory
	{
		public override IReuse Reuse => DryIoc.Reuse.Scoped;

		public WithScopedReuse(FactoryDelegate factoryDelegate)
			: base(factoryDelegate)
		{
		}
	}

	internal sealed class WithTransientReuse : DelegateFactory
	{
		public override IReuse Reuse => DryIoc.Reuse.Transient;

		public WithTransientReuse(FactoryDelegate factoryDelegate)
			: base(factoryDelegate)
		{
		}
	}

	internal sealed class WithScopedOrSingletonReuse : DelegateFactory
	{
		public override IReuse Reuse => DryIoc.Reuse.ScopedOrSingleton;

		public WithScopedOrSingletonReuse(FactoryDelegate factoryDelegate)
			: base(factoryDelegate)
		{
		}
	}

	internal sealed class WithReuse : DelegateFactory
	{
		public override IReuse Reuse { get; }

		public WithReuse(FactoryDelegate factoryDelegate, IReuse reuse)
			: base(factoryDelegate)
		{
			Reuse = reuse;
		}
	}

	internal sealed class WithAllDetails : DelegateFactory
	{
		public override IReuse Reuse { get; }

		public override Setup Setup { get; }

		public WithAllDetails(FactoryDelegate factoryDelegate, IReuse reuse, Setup setup)
			: base(factoryDelegate)
		{
			Reuse = reuse;
			Setup = setup.WithAsResolutionCallForGeneratedExpression();
		}
	}

	private readonly FactoryDelegate _factoryDelegate;

	public override bool HasRuntimeState => true;

	public override Setup Setup => Setup.AsResolutionCallForGeneratedExpressionSetup;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static DelegateFactory Of(FactoryDelegate factoryDelegate)
	{
		return new DelegateFactory(factoryDelegate);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static DelegateFactory Of(FactoryDelegate factoryDelegate, IReuse reuse)
	{
		if (reuse != null)
		{
			if (reuse != DryIoc.Reuse.Singleton)
			{
				if (reuse != DryIoc.Reuse.Scoped)
				{
					if (reuse != DryIoc.Reuse.Transient)
					{
						if (reuse != DryIoc.Reuse.ScopedOrSingleton)
						{
							return new WithReuse(factoryDelegate, reuse);
						}
						return new WithScopedOrSingletonReuse(factoryDelegate);
					}
					return new WithTransientReuse(factoryDelegate);
				}
				return new WithScopedReuse(factoryDelegate);
			}
			return new WithSingletonReuse(factoryDelegate);
		}
		return new DelegateFactory(factoryDelegate);
	}

	public static DelegateFactory Of(FactoryDelegate factoryDelegate, Setup setup)
	{
		if (setup != null && setup != Setup.Default)
		{
			return new WithAllDetails(factoryDelegate, null, setup ?? Setup.Default);
		}
		return new DelegateFactory(factoryDelegate);
	}

	public static DelegateFactory Of(FactoryDelegate factoryDelegate, IReuse reuse, Setup setup)
	{
		if (setup != null && setup != Setup.Default)
		{
			return new WithAllDetails(factoryDelegate, reuse, setup ?? Setup.Default);
		}
		return Of(factoryDelegate, reuse);
	}

	public DelegateFactory(FactoryDelegate factoryDelegate)
	{
		_factoryDelegate = factoryDelegate.ThrowIfNull();
	}

	public override Expression CreateExpressionOrDefault(Request request)
	{
		IContainer container = request.Container;
		if (container.Rules.ThrowIfRuntimeStateRequired)
		{
			Throw.StateIsRequiredToUseItem(_factoryDelegate);
		}
		Type actualServiceType = request.GetActualServiceType();
		if (!(request.Reuse is SingletonReuse))
		{
			return new InvokeFactoryDelegateExpression(actualServiceType, _factoryDelegate);
		}
		return new InvokeFactoryDelegateOfRootOrSelfExpression(actualServiceType, _factoryDelegate);
	}

	public override FactoryDelegate GetDelegateOrDefault(Request request)
	{
		request = request.WithResolvedFactory(this);
		if (request.Reuse != DryIoc.Reuse.Transient || (base.FactoryType == FactoryType.Service && request.Container.GetDecoratorExpressionOrDefault(request) != null))
		{
			return base.GetDelegateOrDefault(request);
		}
		return _factoryDelegate;
	}
}
