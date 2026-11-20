using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public sealed class Rules
{
	public delegate Factory FactorySelectorRule(Request request, Factory singleDefaultFactory, KV<object, Factory>[] orManyDefaultAndKeyedFactories);

	public delegate IEnumerable<DynamicRegistration> DynamicRegistrationProvider(Type serviceType, object serviceKey);

	public delegate Factory UnknownServiceResolver(Request request);

	public delegate Expression ItemToExpressionConverterRule(object item, Type itemType);

	[Flags]
	private enum Settings
	{
		Empty = 0,
		ThrowIfDependencyHasShorterReuseLifespan = 2,
		ThrowOnRegisteringDisposableTransient = 4,
		TrackingDisposableTransients = 8,
		ImplicitCheckForReuseMatchingScope = 0x10,
		VariantGenericTypesInResolvedCollection = 0x20,
		ResolveIEnumerableAsLazyEnumerable = 0x40,
		EagerCachingSingletonForFasterAccess = 0x80,
		ThrowIfRuntimeStateRequired = 0x100,
		CaptureContainerDisposeStackTrace = 0x200,
		UseDynamicRegistrationsAsFallbackOnly = 0x400,
		IgnoringReuseForFuncWithArgs = 0x800,
		OverrideRegistrationMade = 0x1000,
		FuncAndLazyWithoutRegistration = 0x2000,
		AutoConcreteTypeResolution = 0x4000,
		SelectLastRegisteredFactory = 0x8000,
		UsedForExpressionGeneration = 0x10000,
		UseInterpretationForTheFirstResolution = 0x40000,
		UseInterpretation = 0x80000,
		UseDecorateeReuseForDecorators = 0x100000,
		UsedForValidation = 0x200000,
		ServiceProviderGetServiceShouldThrowIfUnresolved = 0x400000,
		ThrowIfScopedOrSingletonHasTransientDependency = 0x800000,
		VariantGenericTypesInResolve = 0x1000000
	}

	public static readonly Rules Default = new Rules();

	public static readonly Rules MicrosoftDependencyInjectionRules = WithMicrosoftDependencyInjectionRules(Default);

	public const int DefaultDependencyCountInLambdaToSplitBigObjectGraph = 1024;

	public static readonly DynamicRegistrationFlags DefaultDynamicRegistrationFlags = DryIoc.DynamicRegistrationFlags.Service;

	internal Made _made;

	private const Settings DEFAULT_SETTINGS = Settings.ThrowIfDependencyHasShorterReuseLifespan | Settings.ThrowOnRegisteringDisposableTransient | Settings.ImplicitCheckForReuseMatchingScope | Settings.VariantGenericTypesInResolvedCollection | Settings.EagerCachingSingletonForFasterAccess | Settings.UseInterpretationForTheFirstResolution;

	private Settings _settings;

	public bool ServiceProviderGetServiceShouldThrowIfUnresolved => (_settings & Settings.ServiceProviderGetServiceShouldThrowIfUnresolved) != 0;

	public int DependencyCountInLambdaToSplitBigObjectGraph { get; private set; }

	public object FactoryMethodOrSelector => _made.FactoryMethodOrSelector;

	public ParameterSelector Parameters => _made.Parameters;

	public PropertiesAndFieldsSelector PropertiesAndFields => _made.PropertiesAndFields;

	public bool OverrideRegistrationMade => (_settings & Settings.OverrideRegistrationMade) != 0;

	public object DefaultRegistrationServiceKey { get; private set; }

	public FactorySelectorRule FactorySelector { get; private set; }

	public bool IsSelectLastRegisteredFactory => (_settings & Settings.SelectLastRegisteredFactory) != 0;

	public DynamicRegistrationProvider[] DynamicRegistrationProviders { get; private set; }

	public DynamicRegistrationFlags[] DynamicRegistrationFlags { get; private set; }

	[Obsolete("Instead use `HasDynamicRegistrationProvider(DynamicRegistrationFlags.AsFallback)`")]
	public bool UseDynamicRegistrationsAsFallbackOnly => (_settings & Settings.UseDynamicRegistrationsAsFallbackOnly) != 0;

	public UnknownServiceResolver[] UnknownServiceResolvers { get; private set; }

	public IReuse DefaultReuse { get; private set; }

	public ItemToExpressionConverterRule ItemToExpressionConverter { get; private set; }

	public bool ThrowIfDependencyHasShorterReuseLifespan => (_settings & Settings.ThrowIfDependencyHasShorterReuseLifespan) != 0;

	public bool ThrowIfScopedOrSingletonHasTransientDependency => (_settings & Settings.ThrowIfScopedOrSingletonHasTransientDependency) != 0;

	public bool ThrowOnRegisteringDisposableTransient => (_settings & Settings.ThrowOnRegisteringDisposableTransient) != 0;

	public bool TrackingDisposableTransients => (_settings & Settings.TrackingDisposableTransients) != 0;

	public bool EagerCachingSingletonForFasterAccess => (_settings & Settings.EagerCachingSingletonForFasterAccess) != 0;

	public Ref<ImHashMap<Request, Expression>> DependencyResolutionCallExprs { get; private set; }

	public bool UsedForExpressionGeneration => (_settings & Settings.UsedForExpressionGeneration) != 0;

	public bool UsedForValidation => (_settings & Settings.UsedForValidation) != 0;

	public bool ImplicitCheckForReuseMatchingScope => (_settings & Settings.ImplicitCheckForReuseMatchingScope) != 0;

	public bool ResolveIEnumerableAsLazyEnumerable => (_settings & Settings.ResolveIEnumerableAsLazyEnumerable) != 0;

	public bool VariantGenericTypesInResolvedCollection => (_settings & Settings.VariantGenericTypesInResolvedCollection) != 0;

	public bool VariantGenericTypesInResolve => (_settings & Settings.VariantGenericTypesInResolve) != 0;

	public IfAlreadyRegistered DefaultIfAlreadyRegistered { get; private set; }

	public bool ThrowIfRuntimeStateRequired => (_settings & Settings.ThrowIfRuntimeStateRequired) != 0;

	public bool ConstantExpressionIsFine => (_settings & (Settings.ThrowIfRuntimeStateRequired | Settings.UsedForExpressionGeneration)) == 0;

	public bool CaptureContainerDisposeStackTrace => (_settings & Settings.CaptureContainerDisposeStackTrace) != 0;

	public bool IgnoringReuseForFuncWithArgs => (_settings & Settings.IgnoringReuseForFuncWithArgs) != 0;

	public bool FuncAndLazyWithoutRegistration => (_settings & Settings.FuncAndLazyWithoutRegistration) != 0;

	public bool UseInterpretationForTheFirstResolution => (_settings & Settings.UseInterpretationForTheFirstResolution) != 0;

	public bool UseInterpretation => (_settings & Settings.UseInterpretation) != 0;

	public bool UseDecorateeReuseForDecorators => (_settings & Settings.UseDecorateeReuseForDecorators) != 0;

	private static Rules WithMicrosoftDependencyInjectionRules(Rules rules)
	{
		Rules rules2 = rules.Clone(cloneMade: true);
		rules2._made.FactoryMethodOrSelector = FactoryMethod.ConstructorWithResolvableArguments;
		rules2._settings = (rules._settings | Settings.TrackingDisposableTransients | Settings.SelectLastRegisteredFactory) & ~Settings.ThrowOnRegisteringDisposableTransient & ~Settings.VariantGenericTypesInResolvedCollection;
		rules2.FactorySelector = SelectLastRegisteredFactory;
		return rules2;
	}

	public bool HasMicrosoftDependencyInjectionRules()
	{
		if (this == MicrosoftDependencyInjectionRules)
		{
			return true;
		}
		object factoryMethodOrSelector = _made.FactoryMethodOrSelector;
		if ((factoryMethodOrSelector == FactoryMethod.ConstructorWithResolvableArguments || factoryMethodOrSelector == FactoryMethod.ConstructorWithResolvableArgumentsIncludingNonPublic || factoryMethodOrSelector == FactoryMethod.ConstructorWithResolvableArgumentsIncludingNonPublicWithoutSameTypeParam) && FactorySelector == new FactorySelectorRule(SelectLastRegisteredFactory) && (_settings & Settings.SelectLastRegisteredFactory) != Settings.Empty && (_settings & Settings.TrackingDisposableTransients) != Settings.Empty && (_settings & Settings.ThrowOnRegisteringDisposableTransient) == 0)
		{
			return (_settings & Settings.VariantGenericTypesInResolvedCollection) == 0;
		}
		return false;
	}

	public Rules WithMicrosoftDependencyInjectionRules()
	{
		return WithMicrosoftDependencyInjectionRules(this);
	}

	public Rules WithServiceProviderGetServiceShouldThrowIfUnresolved()
	{
		return WithSettings(_settings | Settings.ServiceProviderGetServiceShouldThrowIfUnresolved);
	}

	public Rules WithDependencyCountInLambdaToSplitBigObjectGraph(int dependencyCount)
	{
		Rules rules = Clone();
		rules.DependencyCountInLambdaToSplitBigObjectGraph = ((dependencyCount < 1) ? 1 : dependencyCount);
		return rules;
	}

	public Rules WithoutDependencyCountInLambdaToSplitBigObjectGraph()
	{
		return WithDependencyCountInLambdaToSplitBigObjectGraph(int.MaxValue);
	}

	public ParameterSelector TryGetParameterSelector(Made made)
	{
		if (!OverrideRegistrationMade)
		{
			return Parameters.OverrideWith(made.Parameters);
		}
		return made.Parameters.OverrideWith(Parameters);
	}

	public PropertiesAndFieldsSelector TryGetPropertiesAndFieldsSelector(Made made)
	{
		if (!OverrideRegistrationMade)
		{
			return PropertiesAndFields.OverrideWith(made.PropertiesAndFields);
		}
		return made.PropertiesAndFields.OverrideWith(PropertiesAndFields);
	}

	public Rules With(FactoryMethodSelector factoryMethod = null, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null)
	{
		return With(Made.Create(factoryMethod, parameters, propertiesAndFields, isConditionalImplementation: false));
	}

	public Rules With(Made made, bool overrideRegistrationMade = false)
	{
		Rules rules = Clone();
		if (overrideRegistrationMade)
		{
			rules._settings = _settings | Settings.OverrideRegistrationMade;
		}
		rules._made = ((_made == Made.Default) ? made : Made.Create(made.FactoryMethodOrSelector ?? _made.FactoryMethodOrSelector, made.Parameters ?? _made.Parameters, made.PropertiesAndFields ?? _made.PropertiesAndFields, made.IsConditionalImplementation || _made.IsConditionalImplementation));
		return rules;
	}

	public Rules WithDefaultRegistrationServiceKey(object serviceKey)
	{
		if (serviceKey == null)
		{
			return this;
		}
		Rules rules = Clone();
		rules.DefaultRegistrationServiceKey = serviceKey;
		return rules;
	}

	public Rules WithFactorySelector(FactorySelectorRule rule)
	{
		Rules rules = Clone();
		rules.FactorySelector = rule;
		rules._settings = ((rule == new FactorySelectorRule(SelectLastRegisteredFactory)) ? (_settings | Settings.SelectLastRegisteredFactory) : (_settings & ~Settings.SelectLastRegisteredFactory));
		return rules;
	}

	public static FactorySelectorRule SelectLastRegisteredFactory()
	{
		return SelectLastRegisteredFactory;
	}

	private static Factory SelectLastRegisteredFactory(Request request, Factory singleDefaultFactory, KV<object, Factory>[] orManyDefaultAndKeyedFactories)
	{
		object serviceKey = request.ServiceKey;
		if (singleDefaultFactory != null)
		{
			if (serviceKey != null)
			{
				return null;
			}
			return singleDefaultFactory;
		}
		for (int num = orManyDefaultAndKeyedFactories.Length - 1; num >= 0; num--)
		{
			KV<object, Factory> kV = orManyDefaultAndKeyedFactories[num];
			if (kV.Key.Equals(serviceKey))
			{
				return kV.Value;
			}
		}
		return null;
	}

	public static FactorySelectorRule SelectFactoryWithTheMinReuseLifespan()
	{
		return SelectLastRegisteredFactory;
	}

	public static FactorySelectorRule SelectFactoryWithTheMinReuseLifespanOrLastRegistered()
	{
		return (Request request, Factory factory, KV<object, Factory>[] factories) => SelectFactoryWithTheMinReuseLifespan(request, factory, factories) ?? SelectLastRegisteredFactory(request, factory, factories);
	}

	public static FactorySelectorRule SelectKeyedOverDefaultFactory(object serviceKey)
	{
		return delegate(Request r, Factory singleFac, KV<object, Factory>[] keyedFacs)
		{
			object obj = singleFac;
			if (obj == null)
			{
				obj = keyedFacs.FindFirst(serviceKey, (object key, KV<object, Factory> f) => object.Equals(f.Key, key))?.Value;
				if (obj == null)
				{
					KV<object, Factory> kV = keyedFacs.FindFirst((KV<object, Factory> f) => f.Key == null || f.Key.Equals(null));
					if (kV == null)
					{
						return (Factory)null;
					}
					obj = kV.Value;
				}
			}
			return (Factory)obj;
		};
	}

	private static Factory SelectFactoryWithTheMinReuseLifespan(Request request, Factory singleDefaultFactory, KV<object, Factory>[] orManyDefaultAndKeyedFactories)
	{
		if (singleDefaultFactory != null)
		{
			return singleDefaultFactory;
		}
		int num = int.MaxValue;
		bool flag = false;
		Factory factory = null;
		foreach (KV<object, Factory> kV in orManyDefaultAndKeyedFactories)
		{
			IReuse reuse = kV.Value.Reuse;
			int num2 = ((reuse == null || reuse == Reuse.Transient) ? int.MaxValue : reuse.Lifespan);
			if (num2 == num)
			{
				flag = true;
			}
			else if (num2 < num)
			{
				num = num2;
				factory = kV.Value;
				flag = false;
			}
		}
		if (flag || factory == null)
		{
			return null;
		}
		return factory;
	}

	public bool HasDynamicRegistrationProvider(DynamicRegistrationFlags withFlags, DynamicRegistrationFlags withoutFlags = DryIoc.DynamicRegistrationFlags.NoFlags)
	{
		DynamicRegistrationFlags[] dynamicRegistrationFlags = DynamicRegistrationFlags;
		if (dynamicRegistrationFlags == null || dynamicRegistrationFlags.Length == 0)
		{
			return false;
		}
		foreach (DynamicRegistrationFlags dynamicRegistrationFlags2 in dynamicRegistrationFlags)
		{
			if ((dynamicRegistrationFlags2 & withFlags) == withFlags && (dynamicRegistrationFlags2 & withoutFlags) == 0)
			{
				return true;
			}
		}
		return false;
	}

	public Rules WithDynamicRegistration(DynamicRegistrationProvider provider, DynamicRegistrationFlags flags)
	{
		Rules rules = Clone();
		rules.DynamicRegistrationProviders = DynamicRegistrationProviders.Append(provider);
		rules.DynamicRegistrationFlags = DynamicRegistrationFlags.Append(flags);
		return rules;
	}

	public Rules WithDynamicRegistrations(params DynamicRegistrationProvider[] rules)
	{
		return WithDynamicRegistrations(DefaultDynamicRegistrationFlags, rules);
	}

	public Rules WithDynamicRegistrationsAsFallback(params DynamicRegistrationProvider[] rules)
	{
		return WithDynamicRegistrations(DefaultDynamicRegistrationFlags | DryIoc.DynamicRegistrationFlags.AsFallback, rules);
	}

	public Rules WithDynamicRegistrations(DynamicRegistrationFlags flags, params DynamicRegistrationProvider[] rules)
	{
		Rules rules2 = Clone();
		rules2.DynamicRegistrationProviders = DynamicRegistrationProviders.Append(rules);
		rules2.DynamicRegistrationFlags = WithDynamicRegistrationProviderFlags((rules != null) ? rules.Length : 0, flags);
		return rules2;
	}

	private DynamicRegistrationFlags[] WithDynamicRegistrationProviderFlags(int count, DynamicRegistrationFlags flags)
	{
		switch (count)
		{
		case 0:
			return DynamicRegistrationFlags;
		case 1:
			return DynamicRegistrationFlags.Append(flags);
		default:
		{
			DynamicRegistrationFlags[] array = new DynamicRegistrationFlags[count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = flags;
			}
			return DynamicRegistrationFlags.Append(array);
		}
		}
	}

	public Rules WithDynamicRegistrationsAsFallback(DynamicRegistrationFlags flags, params DynamicRegistrationProvider[] rules)
	{
		return WithDynamicRegistrations(flags | DryIoc.DynamicRegistrationFlags.AsFallback, rules);
	}

	public Rules WithUnknownServiceResolvers(params UnknownServiceResolver[] rules)
	{
		Rules rules2 = Clone();
		rules2.UnknownServiceResolvers = UnknownServiceResolvers.Append(rules);
		return rules2;
	}

	public Rules WithoutUnknownServiceResolver(UnknownServiceResolver rule)
	{
		Rules rules = Clone();
		rules.UnknownServiceResolvers = UnknownServiceResolvers.Remove(rule);
		return rules;
	}

	public Rules WithUnknownServiceHandler(Action<Request> handler)
	{
		return WithUnknownServiceResolvers(delegate(Request request)
		{
			handler(request);
			return (Factory)null;
		});
	}

	public static UnknownServiceResolver AutoResolveConcreteTypeRule(Func<Request, bool> condition = null)
	{
		return delegate(Request request)
		{
			Type actualServiceType = request.GetActualServiceType();
			if (!actualServiceType.IsImplementationType() || actualServiceType.IsPrimitive() || (condition != null && !condition(request)))
			{
				return (Factory)null;
			}
			Type genericDefinitionOrNull = actualServiceType.GetGenericDefinitionOrNull();
			if (genericDefinitionOrNull != null && WrappersSupport.Wrappers.GetValueOrDefault(genericDefinitionOrNull) != null)
			{
				return (Factory)null;
			}
			ReflectionFactory reflectionFactory = ReflectionFactory.Of(actualServiceType, null, FactoryMethod.ConstructorWithResolvableArgumentsIncludingNonPublicWithoutSameTypeParam);
			return (reflectionFactory.GetExpressionOrDefault(request.WithIfUnresolved(IfUnresolved.ReturnDefault)) == null) ? null : reflectionFactory;
		};
	}

	private static IEnumerable<Type> GetConcreteServiceType(Type serviceType, object serviceKey)
	{
		if (!serviceType.IsAbstract && !serviceType.IsOpenGeneric() && (!serviceType.IsGenericType || WrappersSupport.Wrappers.GetValueOrDefault(serviceType.GetGenericTypeDefinition()) == null))
		{
			return serviceType.One();
		}
		return null;
	}

	private static IEnumerable<Type> GetConcreteServiceType(Type serviceType, object serviceKey, Func<Type, object, bool> serviceCondition)
	{
		if (!serviceType.IsAbstract && !serviceType.IsOpenGeneric() && serviceCondition(serviceType, serviceKey) && (!serviceType.IsGenericType || WrappersSupport.Wrappers.GetValueOrDefault(serviceType.GetGenericTypeDefinition()) == null))
		{
			return serviceType.One();
		}
		return null;
	}

	private static Factory GetConcreteTypeFactory(Type implType, IReuse reuse = null, IfUnresolved ifConcreteTypeIsUnresolved = IfUnresolved.Throw)
	{
		if (ifConcreteTypeIsUnresolved == IfUnresolved.Throw)
		{
			return ReflectionFactory.Of(implType, reuse, FactoryMethod.ConstructorWithResolvableArgumentsIncludingNonPublicWithoutSameTypeParam);
		}
		ReflectionFactory factory = null;
		factory = ReflectionFactory.Of(implType, reuse, FactoryMethod.ConstructorWithResolvableArgumentsIncludingNonPublicWithoutSameTypeParam, Setup.With(null, (Request req) => factory?.GetExpressionOrDefault(req.WithIfUnresolved(ifConcreteTypeIsUnresolved)) != null));
		return factory;
	}

	public static DynamicRegistrationProvider ConcreteTypeDynamicRegistrations(Func<Type, object, bool> condition = null, IReuse reuse = null)
	{
		return AutoFallbackDynamicRegistrations((condition == null) ? ((Func<Type, object, IEnumerable<Type>>)((Type serviceType, object serviceKey) => GetConcreteServiceType(serviceType, serviceKey))) : ((Func<Type, object, IEnumerable<Type>>)((Type serviceType, object serviceKey) => GetConcreteServiceType(serviceType, serviceKey, condition))), (Type implType) => GetConcreteTypeFactory(implType, reuse, IfUnresolved.ReturnDefault));
	}

	public static DynamicRegistrationProvider ConcreteTypeDynamicRegistrations(IfUnresolved ifConcreteTypeIsUnresolved, Func<Type, object, bool> serviceCondition = null, IReuse reuse = null)
	{
		return AutoFallbackDynamicRegistrations((serviceCondition == null) ? ((Func<Type, object, IEnumerable<Type>>)((Type serviceType, object serviceKey) => GetConcreteServiceType(serviceType, serviceKey))) : ((Func<Type, object, IEnumerable<Type>>)((Type serviceType, object serviceKey) => GetConcreteServiceType(serviceType, serviceKey, serviceCondition))), (Type implType) => GetConcreteTypeFactory(implType, reuse, ifConcreteTypeIsUnresolved));
	}

	public Rules WithConcreteTypeDynamicRegistrations(Func<Type, object, bool> condition = null, IReuse reuse = null)
	{
		return WithDynamicRegistrationsAsFallback(ConcreteTypeDynamicRegistrations(condition, reuse));
	}

	public Rules WithConcreteTypeDynamicRegistrations(IfUnresolved ifConcreteTypeIsUnresolved, Func<Type, object, bool> condition = null, IReuse reuse = null)
	{
		return WithDynamicRegistrationsAsFallback(ConcreteTypeDynamicRegistrations(ifConcreteTypeIsUnresolved, condition, reuse));
	}

	public Rules WithAutoConcreteTypeResolution(Func<Request, bool> condition = null)
	{
		Rules rules = Clone();
		rules._settings = _settings | Settings.AutoConcreteTypeResolution;
		rules.UnknownServiceResolvers = UnknownServiceResolvers.Append(AutoResolveConcreteTypeRule(condition));
		return rules;
	}

	public static DynamicRegistrationProvider AutoFallbackDynamicRegistrations(Func<Type, object, IEnumerable<Type>> getImplementationTypes, Func<Type, Factory> factory = null)
	{
		Ref<ImHashMap<Type, Factory>> factories = Ref.Of(ImHashMap<Type, Factory>.Empty);
		return delegate(Type serviceType, object serviceKey)
		{
			if (!serviceType.IsServiceType())
			{
				return Enumerable.Empty<DynamicRegistration>();
			}
			IEnumerable<Type> source = getImplementationTypes(serviceType, serviceKey);
			return source.Match((Type implType) => implType.IsImplementingServiceType(serviceType), delegate(Type implType)
			{
				int implTypeHash = RuntimeHelpers.GetHashCode(implType);
				Factory implFactory = factories.Value.GetValueOrDefault(implTypeHash, implType);
				if (implFactory == null)
				{
					if (factory == null)
					{
						factories.Swap((ImHashMap<Type, Factory> fs) => ((implFactory = fs.GetValueOrDefault(implTypeHash, implType)) == null) ? fs.AddOrUpdate(implTypeHash, implType, implFactory = ReflectionFactory.Of(implType)) : fs);
					}
					else
					{
						factories.Swap((ImHashMap<Type, Factory> fs) => ((implFactory = fs.GetValueOrDefault(implTypeHash, implType)) == null) ? fs.AddOrUpdate(implTypeHash, implType, implFactory = factory(implType).ThrowIfNull()) : fs);
					}
				}
				object serviceKey2 = ((serviceKey is DefaultDynamicKey) ? null : serviceKey);
				return new DynamicRegistration(implFactory, IfAlreadyRegistered.Keep, serviceKey2);
			});
		};
	}

	[Obsolete("Replaced by AutoFallbackDynamicRegistrations", false)]
	public static UnknownServiceResolver AutoRegisterUnknownServiceRule(IEnumerable<Type> implTypes, Func<IReuse, Request, IReuse> changeDefaultReuse = null, Func<Request, bool> condition = null)
	{
		return delegate(Request request)
		{
			if (condition != null && !condition(request))
			{
				return (Factory)null;
			}
			IScope currentScope = request.Container.CurrentScope;
			IReuse reuse = ((currentScope != null) ? Reuse.ScopedTo(currentScope.Name) : Reuse.Singleton);
			if (changeDefaultReuse != null)
			{
				reuse = changeDefaultReuse(reuse, request);
			}
			Type requestedServiceType = request.GetActualServiceType();
			request.Container.RegisterMany(implTypes, reuse, null, null, null, (Type serviceType) => (!serviceType.IsOpenGeneric() || !requestedServiceType.IsClosedGeneric()) ? (serviceType == requestedServiceType) : (serviceType == requestedServiceType.GetGenericTypeDefinition()));
			return request.Container.GetServiceFactoryOrDefault(request);
		};
	}

	public Rules WithDefaultReuse(IReuse reuse)
	{
		if (reuse == DefaultReuse)
		{
			return this;
		}
		Rules rules = Clone();
		rules.DefaultReuse = reuse ?? Reuse.Transient;
		return rules;
	}

	public Rules WithItemToExpressionConverter(ItemToExpressionConverterRule itemToExpressionOrDefault)
	{
		Rules rules = Clone();
		rules.ItemToExpressionConverter = itemToExpressionOrDefault;
		return rules;
	}

	public Rules WithoutThrowIfDependencyHasShorterReuseLifespan()
	{
		return WithSettings(_settings & ~Settings.ThrowIfDependencyHasShorterReuseLifespan);
	}

	public Rules WithThrowIfScopedOrSingletonHasTransientDependency()
	{
		return WithSettings(_settings | Settings.ThrowIfScopedOrSingletonHasTransientDependency);
	}

	public Rules WithoutThrowIfScopedOrSingletonHasTransientDependency()
	{
		return WithSettings(_settings & ~Settings.ThrowIfScopedOrSingletonHasTransientDependency);
	}

	public Rules WithoutThrowOnRegisteringDisposableTransient()
	{
		return WithSettings(_settings & ~Settings.ThrowOnRegisteringDisposableTransient);
	}

	public Rules WithTrackingDisposableTransients()
	{
		return WithSettings((_settings | Settings.TrackingDisposableTransients) & ~Settings.ThrowOnRegisteringDisposableTransient);
	}

	public Rules WithoutTrackingDisposableTransients()
	{
		return WithSettings(_settings & ~Settings.TrackingDisposableTransients);
	}

	public Rules WithoutEagerCachingSingletonForFasterAccess()
	{
		return WithSettings(_settings & ~Settings.EagerCachingSingletonForFasterAccess);
	}

	private Settings GetSettingsForExpressionGeneration(bool allowRuntimeState = false)
	{
		return (Settings)((int)((_settings & ~Settings.EagerCachingSingletonForFasterAccess & ~Settings.ImplicitCheckForReuseMatchingScope & ~Settings.UseInterpretationForTheFirstResolution & ~Settings.UseInterpretation) | Settings.UsedForExpressionGeneration) | ((!allowRuntimeState) ? 256 : 0));
	}

	public Rules WithExpressionGeneration(bool allowRuntimeState = false)
	{
		Rules rules = Clone();
		rules._settings = GetSettingsForExpressionGeneration(allowRuntimeState);
		rules.DependencyResolutionCallExprs = Ref.Of(ImHashMap<Request, Expression>.Empty);
		return rules;
	}

	public Rules ForExpressionGeneration(bool allowRuntimeState = false)
	{
		return WithSettings(GetSettingsForExpressionGeneration(allowRuntimeState));
	}

	private Settings GetSettingsForValidation()
	{
		return (_settings & ~Settings.EagerCachingSingletonForFasterAccess & ~Settings.ImplicitCheckForReuseMatchingScope) | Settings.UsedForValidation;
	}

	public Rules ForValidate()
	{
		Rules rules = Clone();
		rules._settings = GetSettingsForValidation();
		rules.DependencyCountInLambdaToSplitBigObjectGraph = int.MaxValue;
		rules.DependencyResolutionCallExprs = null;
		return rules;
	}

	public Rules WithoutImplicitCheckForReuseMatchingScope()
	{
		return WithSettings(_settings & ~Settings.ImplicitCheckForReuseMatchingScope);
	}

	public Rules WithResolveIEnumerableAsLazyEnumerable()
	{
		return WithSettings(_settings | Settings.ResolveIEnumerableAsLazyEnumerable);
	}

	public Rules WithVariantGenericTypesInResolvedCollection()
	{
		return WithSettings(_settings | Settings.VariantGenericTypesInResolvedCollection);
	}

	public Rules WithoutVariantGenericTypesInResolvedCollection()
	{
		return WithSettings(_settings & ~Settings.VariantGenericTypesInResolvedCollection);
	}

	public Rules WithVariantGenericTypesInResolve()
	{
		return WithSettings(_settings | Settings.VariantGenericTypesInResolve);
	}

	public Rules WithoutVariantGenericTypesInResolve()
	{
		return WithSettings(_settings & ~Settings.VariantGenericTypesInResolve);
	}

	public Rules WithDefaultIfAlreadyRegistered(IfAlreadyRegistered rule)
	{
		if (rule == DefaultIfAlreadyRegistered)
		{
			return this;
		}
		Rules rules = Clone();
		rules.DefaultIfAlreadyRegistered = rule;
		return rules;
	}

	public Rules WithThrowIfRuntimeStateRequired()
	{
		return WithSettings(_settings | Settings.ThrowIfRuntimeStateRequired);
	}

	public Rules WithCaptureContainerDisposeStackTrace()
	{
		return WithSettings(_settings | Settings.CaptureContainerDisposeStackTrace);
	}

	public Rules WithIgnoringReuseForFuncWithArgs()
	{
		return WithSettings(_settings | Settings.IgnoringReuseForFuncWithArgs);
	}

	public Rules WithFuncAndLazyWithoutRegistration()
	{
		return WithSettings(_settings | Settings.FuncAndLazyWithoutRegistration);
	}

	public Rules WithoutFuncAndLazyWithoutRegistration()
	{
		return WithSettings(_settings & ~Settings.FuncAndLazyWithoutRegistration);
	}

	public Rules WithoutInterpretationForTheFirstResolution()
	{
		return WithSettings(_settings & ~Settings.UseInterpretationForTheFirstResolution & ~Settings.UseInterpretation);
	}

	public Rules WithUseInterpretation()
	{
		return WithSettings(_settings | Settings.UseInterpretation | Settings.UseInterpretationForTheFirstResolution);
	}

	public Rules WithoutUseInterpretation()
	{
		return WithSettings(_settings & ~Settings.UseInterpretation);
	}

	public Rules WithUseDecorateeReuseForDecorators()
	{
		return WithSettings(_settings | Settings.UseDecorateeReuseForDecorators);
	}

	public override string ToString()
	{
		if (this == Default)
		{
			return "Rules.Default";
		}
		string text = "";
		if (_settings != (Settings.ThrowIfDependencyHasShorterReuseLifespan | Settings.ThrowOnRegisteringDisposableTransient | Settings.ImplicitCheckForReuseMatchingScope | Settings.VariantGenericTypesInResolvedCollection | Settings.EagerCachingSingletonForFasterAccess | Settings.UseInterpretationForTheFirstResolution))
		{
			Settings settings = _settings & ~(Settings.ThrowIfDependencyHasShorterReuseLifespan | Settings.ThrowOnRegisteringDisposableTransient | Settings.ImplicitCheckForReuseMatchingScope | Settings.VariantGenericTypesInResolvedCollection | Settings.EagerCachingSingletonForFasterAccess | Settings.UseInterpretationForTheFirstResolution);
			if (settings != Settings.Empty)
			{
				text = "Rules with {" + settings.ToString() + "}";
			}
			Settings settings2 = (Settings.ThrowIfDependencyHasShorterReuseLifespan | Settings.ThrowOnRegisteringDisposableTransient | Settings.ImplicitCheckForReuseMatchingScope | Settings.VariantGenericTypesInResolvedCollection | Settings.EagerCachingSingletonForFasterAccess | Settings.UseInterpretationForTheFirstResolution) & ~_settings;
			if (settings2 != Settings.Empty)
			{
				text = text + ((text != "") ? " and without {" : "Rules without {") + settings2.ToString() + "}";
			}
		}
		if (DependencyCountInLambdaToSplitBigObjectGraph != 1024)
		{
			text = text + " with TotalDependencyCountInLambdaToSplitBigObjectGraph=" + DependencyCountInLambdaToSplitBigObjectGraph;
		}
		if (DefaultReuse != null && DefaultReuse != Reuse.Transient)
		{
			text = text + ((text != "") ? "\n" : "Rules ") + " with DefaultReuse=" + DefaultReuse;
		}
		if (FactorySelector != null)
		{
			text = text + ((text != "") ? "\n" : "Rules ") + " with FactorySelector=";
			text = ((FactorySelector != new FactorySelectorRule(SelectLastRegisteredFactory)) ? (text + "<custom>") : (text + "SelectLastRegisteredFactory"));
		}
		if (_made != Made.Default)
		{
			text = text + ((text != "") ? "\n" : "Rules ") + " with Made=" + _made;
		}
		return text;
	}

	private Rules()
	{
		_made = Made.Default;
		_settings = Settings.ThrowIfDependencyHasShorterReuseLifespan | Settings.ThrowOnRegisteringDisposableTransient | Settings.ImplicitCheckForReuseMatchingScope | Settings.VariantGenericTypesInResolvedCollection | Settings.EagerCachingSingletonForFasterAccess | Settings.UseInterpretationForTheFirstResolution;
		DefaultReuse = Reuse.Transient;
		DefaultIfAlreadyRegistered = IfAlreadyRegistered.AppendNotKeyed;
		DependencyCountInLambdaToSplitBigObjectGraph = 1024;
	}

	private Rules(Settings settings, FactorySelectorRule factorySelector, IReuse defaultReuse, Made made, IfAlreadyRegistered defaultIfAlreadyRegistered, int dependencyCountInLambdaToSplitBigObjectGraph, Ref<ImHashMap<Request, Expression>> dependencyResolutionCallExprs, ItemToExpressionConverterRule itemToExpressionConverter, DynamicRegistrationProvider[] dynamicRegistrationProviders, DynamicRegistrationFlags[] dynamicRegistrationProvidersFlags, UnknownServiceResolver[] unknownServiceResolvers, object defaultRegistrationServiceKey)
	{
		_settings = settings;
		_made = made;
		FactorySelector = factorySelector;
		DefaultReuse = defaultReuse;
		DefaultIfAlreadyRegistered = defaultIfAlreadyRegistered;
		DependencyCountInLambdaToSplitBigObjectGraph = dependencyCountInLambdaToSplitBigObjectGraph;
		DependencyResolutionCallExprs = dependencyResolutionCallExprs;
		ItemToExpressionConverter = itemToExpressionConverter;
		DynamicRegistrationProviders = dynamicRegistrationProviders;
		DynamicRegistrationFlags = dynamicRegistrationProvidersFlags;
		UnknownServiceResolvers = unknownServiceResolvers;
		DefaultRegistrationServiceKey = defaultRegistrationServiceKey;
	}

	private Rules Clone(bool cloneMade = false)
	{
		return new Rules(_settings, FactorySelector, DefaultReuse, cloneMade ? _made.Clone() : _made, DefaultIfAlreadyRegistered, DependencyCountInLambdaToSplitBigObjectGraph, DependencyResolutionCallExprs, ItemToExpressionConverter, DynamicRegistrationProviders, DynamicRegistrationFlags, UnknownServiceResolvers, DefaultRegistrationServiceKey);
	}

	private Rules WithSettings(Settings newSettings)
	{
		Rules rules = Clone();
		rules._settings = newSettings;
		return rules;
	}
}
