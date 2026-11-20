using System;
using System.Collections.Generic;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public class InstanceFactory : Factory
{
	internal sealed class WithAllDetails : InstanceFactory
	{
		public override Setup Setup { get; }

		public override Type ImplementationType
		{
			get
			{
				object instance = Instance;
				object obj = (instance as WeakReference)?.Target.GetType();
				if (obj == null)
				{
					if (instance == null)
					{
						return null;
					}
					obj = instance.GetType();
				}
				return (Type)obj;
			}
		}

		public WithAllDetails(object instance, Setup setup)
			: base((instance != null && setup.WeaklyReferenced) ? new WeakReference(instance) : instance)
		{
			Setup = setup.WithAsResolutionCallForGeneratedExpression();
		}
	}

	public readonly object Instance;

	public override Type ImplementationType => Instance?.GetType();

	public override IReuse Reuse => DryIoc.Reuse.Singleton;

	public override Setup Setup => Setup.AsResolutionCallForGeneratedExpressionSetup;

	public override bool HasRuntimeState => true;

	public static InstanceFactory Of(object instance)
	{
		return new InstanceFactory(instance);
	}

	public static InstanceFactory Of(object instance, Setup setup)
	{
		if (setup != null && setup != Setup.Default)
		{
			return new WithAllDetails(instance, setup ?? Setup.Default);
		}
		return new InstanceFactory(instance);
	}

	public InstanceFactory(object instance)
	{
		Instance = instance;
	}

	internal override bool ValidateAndNormalizeRegistration(Type serviceType, object serviceKey, bool isStaticallyChecked, Rules rules, bool throwIfInvalid)
	{
		if (isStaticallyChecked)
		{
			return true;
		}
		if (serviceType == null)
		{
			return Throw.When(throwIfInvalid, Error.ServiceTypeIsNull);
		}
		Type implementationType = ImplementationType;
		if (implementationType != null && !serviceType.IsAssignableFrom(implementationType))
		{
			return Throw.When(throwIfInvalid, Error.RegisteringInstanceNotAssignableToServiceType, implementationType, serviceType);
		}
		return true;
	}

	public override Expression CreateExpressionOrDefault(Request request)
	{
		if (Setup.WeaklyReferenced)
		{
			return Expression.Call(typeof(ThrowInGeneratedCode).GetMethod("WeakRefReuseWrapperGCed"), Expression.Property(Expression.ConstantOf((WeakReference)Instance), typeof(WeakReference).GetProperty("Target")));
		}
		Expression constantExpression = request.Container.GetConstantExpression(Instance);
		Type actualServiceType = request.GetActualServiceType();
		Type implementationType = ImplementationType;
		if (!(implementationType == null) && !actualServiceType.IsAssignableFrom(implementationType))
		{
			return actualServiceType.Cast(constantExpression);
		}
		return constantExpression;
	}

	public override Expression GetExpressionOrDefault(Request request)
	{
		if ((request.Flags & RequestFlags.IsGeneratedResolutionDependencyExpression) == 0 && !request.IsResolutionCall && (base.AsResolutionCall || (Setup.AsResolutionCallForExpressionGeneration && request.Rules.UsedForExpressionGeneration)))
		{
			return Resolver.CreateResolutionExpression(request.WithResolvedFactory(this), Setup.OpenResolutionScope, base.AsResolutionCall);
		}
		Type serviceType = request.ServiceType;
		if (serviceType.IsArray)
		{
			serviceType = typeof(IEnumerable<>).MakeGenericType(serviceType.GetElementType());
		}
		Container container = (Container)request.Container;
		if (container._registry.Value is Container.Registry registry && !registry.Decorators.IsEmpty)
		{
			Expression decoratorExpressionOrDefault = ((IContainer)container).GetDecoratorExpressionOrDefault(request.WithResolvedFactory(this));
			if (decoratorExpressionOrDefault != null)
			{
				return decoratorExpressionOrDefault;
			}
		}
		return CreateExpressionOrDefault(request);
	}

	public override FactoryDelegate GetDelegateOrDefault(Request request)
	{
		request = request.WithResolvedFactory(this);
		if (request.Container.GetDecoratorExpressionOrDefault(request) != null)
		{
			return base.GetDelegateOrDefault(request);
		}
		if (!Setup.WeaklyReferenced)
		{
			return Instance.ToFactoryDelegate;
		}
		return UnpackWeakRefFactory;
	}

	private object UnpackWeakRefFactory(IResolverContext _)
	{
		return (Instance as WeakReference)?.Target.WeakRefReuseWrapperGCed();
	}
}
