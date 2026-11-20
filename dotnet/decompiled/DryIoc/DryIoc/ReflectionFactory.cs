using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public class ReflectionFactory : Factory
{
	internal sealed class WithSingletonReuse : ReflectionFactory
	{
		public override IReuse Reuse => DryIoc.Reuse.Singleton;

		public WithSingletonReuse(Type implementationType)
			: base(implementationType)
		{
		}
	}

	internal sealed class WithTransientReuse : ReflectionFactory
	{
		public override IReuse Reuse => DryIoc.Reuse.Transient;

		public WithTransientReuse(Type implementationType)
			: base(implementationType)
		{
		}
	}

	internal sealed class WithScopedOrSingletonReuse : ReflectionFactory
	{
		public override IReuse Reuse => DryIoc.Reuse.ScopedOrSingleton;

		public WithScopedOrSingletonReuse(Type implementationType)
			: base(implementationType)
		{
		}
	}

	internal sealed class WithScopedReuse : ReflectionFactory
	{
		public override IReuse Reuse => DryIoc.Reuse.Scoped;

		public WithScopedReuse(Type implementationType)
			: base(implementationType)
		{
		}
	}

	internal sealed class WithReuse : ReflectionFactory
	{
		public override IReuse Reuse { get; }

		public WithReuse(Type implementationType, IReuse reuse)
			: base(implementationType)
		{
			Reuse = reuse;
		}
	}

	internal sealed class WithMade : ReflectionFactory
	{
		public override Made Made { get; }

		public WithMade(Type implementationType, Made made)
			: base(implementationType)
		{
			Made = made;
		}
	}

	internal sealed class WithMadeAndReuse : ReflectionFactory
	{
		public override IReuse Reuse { get; }

		public override Made Made { get; }

		public WithMadeAndReuse(Type implementationType, IReuse reuse, Made made)
			: base(implementationType)
		{
			Reuse = reuse;
			Made = made;
		}
	}

	internal class WithAllDetails : ReflectionFactory
	{
		internal object _generatedFactoriesOrFactoryGenerator;

		public override ImHashMap<KV<Type, object>, ReflectionFactory> GeneratedFactories => _generatedFactoriesOrFactoryGenerator as ImHashMap<KV<Type, object>, ReflectionFactory>;

		public override ReflectionFactory GeneratorFactory => _generatedFactoriesOrFactoryGenerator as ReflectionFactory;

		public override IReuse Reuse { get; }

		public override Made Made { get; }

		public override Setup Setup { get; }

		public WithAllDetails(object implementationType, IReuse reuse, Made made, Setup setup, ImHashMap<KV<Type, object>, ReflectionFactory> generatedFactories = null)
		{
			_implementationTypeOrProviderOrPubCtorOrCtors = implementationType;
			Reuse = reuse;
			Made = made;
			Setup = setup;
			_generatedFactoriesOrFactoryGenerator = generatedFactories;
		}

		internal WithAllDetails(Type implementationType, IReuse reuse, Made made, Setup setup, ReflectionFactory factoryGenerator)
		{
			_implementationTypeOrProviderOrPubCtorOrCtors = implementationType;
			Reuse = reuse;
			Made = made;
			Setup = setup;
			_generatedFactoriesOrFactoryGenerator = factoryGenerator;
		}

		public override Factory GetGeneratedFactoryOrDefault(Request request, bool ifErrorReturnDefault = false)
		{
			Type type = ImplementationType;
			Type actualServiceType = request.GetActualServiceType();
			Type[] array = ((type == null || type == actualServiceType.GetGenericDefinitionOrNull()) ? actualServiceType.GetGenericArguments() : (type.IsGenericParameter ? actualServiceType.One() : GetClosedTypeArgsOrNullForOpenGenericType(type, actualServiceType, request, ifErrorReturnDefault)));
			if (array == null)
			{
				return null;
			}
			Made made = Made;
			if (made.FactoryMethodOrSelector != null)
			{
				request = request.WithResolvedFactory(this, ifErrorReturnDefault, ifErrorReturnDefault, copyRequest: true);
				FactoryMethod factoryMethod = (made.FactoryMethodOrSelector as FactoryMethod) ?? ((FactoryMethodSelector)made.FactoryMethodOrSelector)(request);
				if (factoryMethod == null)
				{
					if (!ifErrorReturnDefault)
					{
						return Throw.For<Factory>(Error.GotNullFactoryWhenResolvingService, request);
					}
					return null;
				}
				bool ifErrorReturnDefault2 = type != null && type.IsGenericParameter;
				FactoryMethod closedFactoryMethodOrDefault = GetClosedFactoryMethodOrDefault(factoryMethod, array, request, ifErrorReturnDefault2);
				if (closedFactoryMethodOrDefault == null)
				{
					return null;
				}
				made = Made.Of(closedFactoryMethodOrDefault, made.Parameters, made.PropertiesAndFields);
			}
			ServiceDetails serviceDetails = request.GetServiceDetails();
			if (type != null)
			{
				type = (type.IsGenericParameter ? array[0] : type.TryCloseGenericTypeOrMethod(array, (Type t, Type[] a) => t.MakeGenericType(a), !ifErrorReturnDefault && serviceDetails.IfUnresolved == IfUnresolved.Throw, Error.NoMatchedGenericParamConstraints, request));
				if (type == null)
				{
					return null;
				}
			}
			Type key = type ?? made.FactoryMethodKnownResultType ?? actualServiceType;
			object serviceKey = serviceDetails.ServiceKey;
			serviceKey = (serviceKey as OpenGenericTypeKey)?.ServiceKey ?? serviceKey ?? DefaultKey.Value;
			KV<Type, object> kV = KV.Of(key, serviceKey);
			ImHashMap<KV<Type, object>, ReflectionFactory> generatedFactories = GeneratedFactories;
			if (!generatedFactories.IsEmpty)
			{
				ReflectionFactory valueOrDefault = generatedFactories.GetValueOrDefault(kV);
				if (valueOrDefault != null)
				{
					return valueOrDefault;
				}
			}
			ReflectionFactory closedGenericFactory = new WithAllDetails(type, Reuse, made, Setup, this);
			closedGenericFactory.Flags = base.Flags;
			Ref.Swap(ref _generatedFactoriesOrFactoryGenerator, kV, closedGenericFactory, delegate(object x, KV<Type, object> genFacKey, ReflectionFactory closedGenFac)
			{
				ImHashMapEntry<KV<Type, object>, ReflectionFactory> imHashMapEntry = ImHashMap.Entry(genFacKey, closedGenFac);
				ImHashMap<KV<Type, object>, ReflectionFactory> imHashMap = ((ImHashMap<KV<Type, object>, ReflectionFactory>)x).AddOrGetEntry(imHashMapEntry);
				if (imHashMap is ImHashMapEntry<KV<Type, object>, ReflectionFactory> imHashMapEntry2 && imHashMapEntry2 != imHashMapEntry)
				{
					closedGenericFactory = imHashMapEntry2.Value;
					return x;
				}
				return imHashMap;
			});
			return closedGenericFactory;
		}

		private static Type[] GetClosedTypeArgsOrNullForOpenGenericType(Type openImplType, Type closedServiceType, Request request, bool ifErrorReturnDefault)
		{
			Type[] genericArguments = closedServiceType.GetGenericArguments();
			Type genericTypeDefinition = closedServiceType.GetGenericTypeDefinition();
			Type[] genericArguments2 = openImplType.GetGenericArguments();
			Type[] array = new Type[genericArguments2.Length];
			Type[] implementedTypes = openImplType.GetImplementedTypes();
			bool flag = false;
			int num = 0;
			while (!flag && num < implementedTypes.Length)
			{
				Type type = implementedTypes[num];
				if (type.IsOpenGeneric() && type.GetGenericDefinitionOrNull() == genericTypeDefinition)
				{
					flag = MatchServiceWithImplementedTypeParams(array, genericArguments2, type.GetGenericArguments(), genericArguments);
				}
				num++;
			}
			if (!flag)
			{
				if (!ifErrorReturnDefault && request.IfUnresolved == IfUnresolved.Throw)
				{
					return Throw.For<Type[]>(Error.NoMatchedImplementedTypesWithServiceType, openImplType, implementedTypes, request);
				}
				return null;
			}
			MatchOpenGenericConstraints(genericArguments2, array);
			int num2 = Array.IndexOf(array, null);
			if (num2 != -1)
			{
				if (!ifErrorReturnDefault && request.IfUnresolved == IfUnresolved.Throw)
				{
					return Throw.For<Type[]>(Error.NotFoundOpenGenericImplTypeArgInService, openImplType, genericArguments2[num2], request);
				}
				return null;
			}
			return array;
		}
	}

	internal sealed class WithTypeProvider : WithAllDetails
	{
		public override bool CanAccessImplementationType => false;

		public override Type ImplementationType
		{
			get
			{
				Made made = Made;
				Type type = ((Func<Type>)_implementationTypeOrProviderOrPubCtorOrCtors)();
				Type type2 = ValidateImplementationType(type, made);
				if (IsFactoryGenerator(type2 ?? type, made))
				{
					_generatedFactoriesOrFactoryGenerator = ImHashMap<KV<Type, object>, ReflectionFactory>.Empty;
				}
				return type2;
			}
		}

		public WithTypeProvider(Func<Type> implementationTypeProvider, IReuse reuse, Made made, Setup setup)
			: base(implementationTypeProvider.ThrowIfNull(), reuse, made, setup)
		{
		}
	}

	internal object _implementationTypeOrProviderOrPubCtorOrCtors;

	public override Type ImplementationType
	{
		get
		{
			object implementationTypeOrProviderOrPubCtorOrCtors = _implementationTypeOrProviderOrPubCtorOrCtors;
			if (implementationTypeOrProviderOrPubCtorOrCtors is Type result)
			{
				return result;
			}
			if (implementationTypeOrProviderOrPubCtorOrCtors is ConstructorInfo constructorInfo)
			{
				return constructorInfo.DeclaringType;
			}
			if (implementationTypeOrProviderOrPubCtorOrCtors is ConstructorInfo[] array)
			{
				return array[0].DeclaringType;
			}
			return null;
		}
	}

	public override bool CanAccessImplementationType => true;

	public override Made Made => Made.Default;

	public override int RegistrationOrder => GeneratorFactory?.FactoryID ?? base.FactoryID;

	private static Type ValidateImplementationType(Type type)
	{
		if (type == null)
		{
			Throw.It(Error.RegisteringNullImplementationTypeAndNoFactoryMethod);
		}
		if (type == typeof(object))
		{
			Throw.It(Error.RegisteringObjectTypeAsImplementationIsNotSupported);
		}
		if (type.IsAbstract)
		{
			Throw.It(Error.RegisteringAbstractImplementationTypeAndNoFactoryMethod, type);
		}
		return type;
	}

	private static Type ValidateImplementationType(Type implType, Made made)
	{
		if (made == Made.Default)
		{
			return ValidateImplementationType(implType);
		}
		Type result = implType;
		Type factoryMethodKnownResultType = made.FactoryMethodKnownResultType;
		if (implType == null || implType == typeof(object) || implType.IsAbstract)
		{
			if (made.FactoryMethodOrSelector == null)
			{
				ValidateImplementationType(implType);
			}
			result = null;
			if (factoryMethodKnownResultType != null && factoryMethodKnownResultType != typeof(object) && !factoryMethodKnownResultType.IsAbstract)
			{
				result = factoryMethodKnownResultType;
			}
		}
		else if (factoryMethodKnownResultType != null && factoryMethodKnownResultType != implType && !implType.IsAssignableFrom(factoryMethodKnownResultType) && !factoryMethodKnownResultType.HasConversionOperatorTo(implType))
		{
			Throw.It(Error.RegisteredFactoryMethodResultTypesIsNotAssignableToImplementationType, implType, factoryMethodKnownResultType);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsFactoryGenerator(Type t)
	{
		if (!t.IsGenericTypeDefinition)
		{
			return t.IsGenericParameter;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsFactoryGenerator(Type t, Made m)
	{
		if (!(t == typeof(object)) && ((object)t == null || !t.IsGenericTypeDefinition) && ((object)t == null || !t.IsGenericParameter))
		{
			return m.IsConditionalImplementation;
		}
		return true;
	}

	public static ReflectionFactory Of(Type implementationType)
	{
		ValidateImplementationType(implementationType);
		if (IsFactoryGenerator(implementationType))
		{
			return new WithAllDetails(implementationType, null, Made.Default, Setup.Default, ImHashMap<KV<Type, object>, ReflectionFactory>.Empty);
		}
		return new ReflectionFactory(implementationType);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ReflectionFactory Of(Type implementationType, IReuse reuse)
	{
		ValidateImplementationType(implementationType);
		if (IsFactoryGenerator(implementationType))
		{
			return new WithAllDetails(implementationType, reuse, Made.Default, Setup.Default, ImHashMap<KV<Type, object>, ReflectionFactory>.Empty);
		}
		return OfReuse(implementationType, reuse);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ReflectionFactory OfReuse(Type implementationType, IReuse reuse)
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
							return new WithReuse(implementationType, reuse);
						}
						return new WithScopedOrSingletonReuse(implementationType);
					}
					return new WithTransientReuse(implementationType);
				}
				return new WithScopedReuse(implementationType);
			}
			return new WithSingletonReuse(implementationType);
		}
		return new ReflectionFactory(implementationType);
	}

	public static ReflectionFactory Of(Type implementationType = null, IReuse reuse = null, Made made = null, Setup setup = null)
	{
		if (made == null)
		{
			made = Made.Default;
		}
		if (setup == null)
		{
			setup = Setup.Default;
		}
		Type type = ValidateImplementationType(implementationType, made);
		if (IsFactoryGenerator(type ?? implementationType, made))
		{
			return new WithAllDetails(type, reuse, made, setup, ImHashMap<KV<Type, object>, ReflectionFactory>.Empty);
		}
		if (setup == Setup.Default)
		{
			if (made != Made.Default)
			{
				if (reuse != null)
				{
					return new WithMadeAndReuse(type, reuse, made);
				}
				return new WithMade(type, made);
			}
			return OfReuse(type, reuse);
		}
		return new WithAllDetails(type, reuse, made, setup);
	}

	internal static ReflectionFactory OfTypeAndMadeNoValidation(Type implementationType, Made made, IReuse reuse = null, Setup setup = null)
	{
		if (setup != null && setup != Setup.Default)
		{
			return new WithAllDetails(implementationType, reuse, made, setup ?? Setup.Default);
		}
		if (reuse != null)
		{
			return new WithMadeAndReuse(implementationType, reuse, made);
		}
		return new WithMade(implementationType, made);
	}

	public static ReflectionFactory Of(Func<Type> implementationTypeProvider, IReuse reuse = null, Made made = null, Setup setup = null)
	{
		return new WithTypeProvider(implementationTypeProvider, reuse, made ?? Made.Default, setup ?? Setup.Default);
	}

	protected ReflectionFactory()
	{
	}

	protected ReflectionFactory(Type implementationType)
	{
		_implementationTypeOrProviderOrPubCtorOrCtors = implementationType;
	}

	public override DryIoc.FastExpressionCompiler.LightExpression.Expression CreateExpressionOrDefault(Request request)
	{
		IContainer container = request.Container;
		Rules rules = container.Rules;
		FactoryMethod factoryMethod = null;
		ConstructorInfo constructorInfo = _implementationTypeOrProviderOrPubCtorOrCtors as ConstructorInfo;
		if (constructorInfo == null)
		{
			object obj = Made.FactoryMethodOrSelector ?? rules.FactoryMethodOrSelector;
			if (obj != null)
			{
				factoryMethod = (obj as FactoryMethod) ?? ((FactoryMethodSelector)obj)(request);
				if (factoryMethod == null)
				{
					if (request.IfUnresolved != IfUnresolved.ReturnDefault)
					{
						Throw.It(Error.UnableToSelectCtor, request.ImplementationType, request);
					}
					return null;
				}
			}
		}
		MethodInfo methodInfo = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression = null;
		Delegate obj2 = null;
		bool failedToGet = false;
		MethodBase methodBase;
		if (factoryMethod == null)
		{
			ConstructorInfo obj3 = constructorInfo ?? request.ImplementationType.SingleConstructor();
			constructorInfo = obj3;
			methodBase = obj3;
		}
		else
		{
			obj2 = factoryMethod.FactoryFunc;
			if ((object)obj2 != null)
			{
				if (rules.ThrowIfRuntimeStateRequired)
				{
					Throw.StateIsRequiredToUseItem(obj2.Target);
				}
			}
			else
			{
				expression = factoryMethod.FactoryExpression;
				if (expression == null && factoryMethod.FactoryServiceInfo != null)
				{
					Request request2 = request.Push(factoryMethod.FactoryServiceInfo);
					expression = container.ResolveFactory(request2)?.GetExpressionOrDefault(request2);
					if (expression == null)
					{
						return null;
					}
				}
			}
			MemberInfo constructorOrMethodOrMember = factoryMethod.ConstructorOrMethodOrMember;
			if (factoryMethod.ResolvedParameterExpressions != null)
			{
				constructorInfo = (request.SelectedConstructor = (ConstructorInfo)constructorOrMethodOrMember);
				if (rules.UsedForValidation)
				{
					TryGetMemberAssignments(ref failedToGet, request, container, rules);
					return request.GetActualServiceType().GetDefaultValueExpression();
				}
				DryIoc.FastExpressionCompiler.LightExpression.MemberAssignment[] array = TryGetMemberAssignments(ref failedToGet, request, container, rules);
				DryIoc.FastExpressionCompiler.LightExpression.NewExpression newExpression = DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, factoryMethod.ResolvedParameterExpressions);
				if (!failedToGet)
				{
					if (array != null)
					{
						DryIoc.FastExpressionCompiler.LightExpression.MemberBinding[] bindings = array;
						return DryIoc.FastExpressionCompiler.LightExpression.Expression.MemberInit(newExpression, bindings);
					}
					return newExpression;
				}
				return null;
			}
			methodBase = constructorOrMethodOrMember as MethodBase;
			if (methodBase == null)
			{
				return ConvertExpressionIfNeeded((constructorOrMethodOrMember is PropertyInfo property) ? DryIoc.FastExpressionCompiler.LightExpression.Expression.Property(expression, property) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Field(expression, (FieldInfo)constructorOrMethodOrMember), request, constructorOrMethodOrMember);
			}
			constructorInfo = methodBase as ConstructorInfo;
			methodInfo = methodBase as MethodInfo;
		}
		request.SelectedConstructor = constructorInfo;
		ParameterInfo[] parameters = methodBase.GetParameters();
		if (parameters.Length == 0)
		{
			if (rules.UsedForValidation)
			{
				if (constructorInfo != null)
				{
					TryGetMemberAssignments(ref failedToGet, request, container, rules);
				}
				return request.GetActualServiceType().GetDefaultValueExpression();
			}
			if (methodInfo != null)
			{
				DryIoc.FastExpressionCompiler.LightExpression.MethodCallExpression serviceExpr = (((object)obj2 != null) ? new FuncInvoke0Expression(obj2, methodInfo) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo));
				return ConvertExpressionIfNeeded(serviceExpr, request, methodInfo);
			}
			DryIoc.FastExpressionCompiler.LightExpression.MemberAssignment[] array2 = TryGetMemberAssignments(ref failedToGet, request, container, rules);
			if (!failedToGet)
			{
				if (array2 != null)
				{
					DryIoc.FastExpressionCompiler.LightExpression.NewExpression newExpr = DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo);
					DryIoc.FastExpressionCompiler.LightExpression.MemberBinding[] bindings = array2;
					return DryIoc.FastExpressionCompiler.LightExpression.Expression.MemberInit(newExpr, bindings);
				}
				return DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo);
			}
			return null;
		}
		bool flag = false;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression2 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression3 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression4 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression5 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression6 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression7 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression8 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression[] array3 = ((parameters.Length > 7) ? new DryIoc.FastExpressionCompiler.LightExpression.Expression[parameters.Length] : null);
		ParameterSelector parameters2 = rules._made.Parameters;
		ParameterSelector parameters3 = Made.Parameters;
		Func<ParameterInfo, ParameterServiceInfo> func = null;
		if (parameters2 != null || parameters3 != null)
		{
			func = (rules.OverrideRegistrationMade ? parameters3.OverrideWith(parameters2) : parameters2.OverrideWith(parameters3))(request);
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression[] inputArgExprs = request.InputArgExprs;
		int argsUsedMask = 0;
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			Type parameterType = parameterInfo.ParameterType;
			if (inputArgExprs != null)
			{
				DryIoc.FastExpressionCompiler.LightExpression.Expression expression9 = TryGetExpressionFromInputArgs(parameterType, inputArgExprs, ref argsUsedMask);
				if (expression9 != null)
				{
					if (array3 != null)
					{
						array3[i] = expression9;
						continue;
					}
					switch (i)
					{
					case 0:
						expression2 = expression9;
						break;
					case 1:
						expression3 = expression9;
						break;
					case 2:
						expression4 = expression9;
						break;
					case 3:
						expression5 = expression9;
						break;
					case 4:
						expression6 = expression9;
						break;
					case 5:
						expression7 = expression9;
						break;
					case 6:
						expression8 = expression9;
						break;
					}
					continue;
				}
			}
			flag = flag || parameterType.IsByRef;
			ParameterServiceInfo parameterServiceInfo = ((func == null) ? ParameterServiceInfo.OrNull(parameterInfo) : (func(parameterInfo) ?? ParameterServiceInfo.OrNull(parameterInfo)));
			Request request3 = ((parameterServiceInfo == null) ? request.Push(parameterInfo) : request.Push(parameterServiceInfo));
			ServiceDetails serviceDetails = ((parameterServiceInfo == null) ? ServiceDetails.Default : parameterServiceInfo.Details);
			DryIoc.FastExpressionCompiler.LightExpression.Expression expression10 = TryGetUsedInstanceOrCustomValueExpression(request, request3, serviceDetails);
			if (expression10 != null)
			{
				if (array3 != null)
				{
					array3[i] = expression10;
					continue;
				}
				switch (i)
				{
				case 0:
					expression2 = expression10;
					break;
				case 1:
					expression3 = expression10;
					break;
				case 2:
					expression4 = expression10;
					break;
				case 3:
					expression5 = expression10;
					break;
				case 4:
					expression6 = expression10;
					break;
				case 5:
					expression7 = expression10;
					break;
				case 6:
					expression8 = expression10;
					break;
				}
				continue;
			}
			DryIoc.FastExpressionCompiler.LightExpression.Expression expression11 = container.ResolveFactory(request3)?.GetExpressionOrDefault(request3);
			if (expression11 == null || (serviceDetails.DefaultValue != null && expression11.NodeType == ExpressionType.NewArrayInit && ((DryIoc.FastExpressionCompiler.LightExpression.NewArrayExpression)expression11).ArgumentCount == 0))
			{
				if (serviceDetails.IfUnresolved == IfUnresolved.Throw)
				{
					return null;
				}
				expression11 = ((serviceDetails.DefaultValue != null) ? container.GetConstantExpression(serviceDetails.DefaultValue, request3.ServiceType) : request3.ServiceType.GetDefaultValueExpression());
			}
			if (array3 != null)
			{
				array3[i] = expression11;
				continue;
			}
			switch (i)
			{
			case 0:
				expression2 = expression11;
				break;
			case 1:
				expression3 = expression11;
				break;
			case 2:
				expression4 = expression11;
				break;
			case 3:
				expression5 = expression11;
				break;
			case 4:
				expression6 = expression11;
				break;
			case 5:
				expression7 = expression11;
				break;
			case 6:
				expression8 = expression11;
				break;
			}
		}
		if (rules.UsedForValidation)
		{
			return request.GetActualServiceType().GetDefaultValueExpression();
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression12 = ((expression2 == null) ? ((!(constructorInfo != null)) ? ((DryIoc.FastExpressionCompiler.LightExpression.Expression)DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo, array3)) : ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(flag ? DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, array3) : DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(constructorInfo, array3)))) : ((expression3 == null) ? ((!(constructorInfo != null)) ? ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(((object)obj2 != null) ? new FuncInvoke1Expression(obj2, methodInfo, expression2) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo, expression2))) : ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(flag ? DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, expression2) : DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(constructorInfo, expression2)))) : ((expression4 == null) ? ((!(constructorInfo != null)) ? ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(((object)obj2 != null) ? new FuncInvoke2Expression(obj2, methodInfo, expression2, expression3) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo, expression2, expression3))) : ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(flag ? DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, expression2, expression3) : DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(constructorInfo, expression2, expression3)))) : ((expression5 == null) ? ((!(constructorInfo != null)) ? ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(((object)obj2 != null) ? new FuncInvoke3Expression(obj2, methodInfo, expression2, expression3, expression4) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo, expression2, expression3, expression4))) : ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(flag ? DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, expression2, expression3, expression4) : DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(constructorInfo, expression2, expression3, expression4)))) : ((expression6 == null) ? ((!(constructorInfo != null)) ? ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(((object)obj2 != null) ? new FuncInvoke4Expression(obj2, methodInfo, expression2, expression3, expression4, expression5) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo, expression2, expression3, expression4, expression5))) : ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(flag ? DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, expression2, expression3, expression4, expression5) : DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(constructorInfo, expression2, expression3, expression4, expression5)))) : ((expression7 == null) ? ((!(constructorInfo != null)) ? ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(((object)obj2 != null) ? new FuncInvoke5Expression(obj2, methodInfo, expression2, expression3, expression4, expression5, expression6) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo, expression2, expression3, expression4, expression5, expression6))) : ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(flag ? DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, expression2, expression3, expression4, expression5, expression6) : DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(constructorInfo, expression2, expression3, expression4, expression5, expression6)))) : ((expression8 != null) ? ((!(constructorInfo != null)) ? ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(((object)obj2 != null) ? new FuncInvoke7Expression(obj2, methodInfo, expression2, expression3, expression4, expression5, expression6, expression7, expression8) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo, expression2, expression3, expression4, expression5, expression6, expression7, expression8))) : ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(flag ? DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, expression2, expression3, expression4, expression5, expression6, expression7, expression8) : DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(constructorInfo, expression2, expression3, expression4, expression5, expression6, expression7, expression8)))) : ((!(constructorInfo != null)) ? ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(((object)obj2 != null) ? new FuncInvoke6Expression(obj2, methodInfo, expression2, expression3, expression4, expression5, expression6, expression7) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(expression, methodInfo, expression2, expression3, expression4, expression5, expression6, expression7))) : ((DryIoc.FastExpressionCompiler.LightExpression.Expression)(flag ? DryIoc.FastExpressionCompiler.LightExpression.Expression.New(constructorInfo, expression2, expression3, expression4, expression5, expression6, expression7) : DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(constructorInfo, expression2, expression3, expression4, expression5, expression6, expression7)))))))))));
		if (constructorInfo == null)
		{
			return ConvertExpressionIfNeeded(expression12, request, methodBase);
		}
		DryIoc.FastExpressionCompiler.LightExpression.MemberAssignment[] array4 = TryGetMemberAssignments(ref failedToGet, request, container, rules);
		if (!failedToGet)
		{
			if (array4 != null)
			{
				DryIoc.FastExpressionCompiler.LightExpression.NewExpression newExpr2 = (DryIoc.FastExpressionCompiler.LightExpression.NewExpression)expression12;
				DryIoc.FastExpressionCompiler.LightExpression.MemberBinding[] bindings = array4;
				return DryIoc.FastExpressionCompiler.LightExpression.Expression.MemberInit(newExpr2, bindings);
			}
			return expression12;
		}
		return null;
	}

	private static DryIoc.FastExpressionCompiler.LightExpression.Expression GetFactoryFuncResolutionExpression(Request request, ref Delegate factoryFunc)
	{
		Delegate obj = (Delegate)factoryFunc.Target;
		Type returnType = obj.Method.ReturnType;
		Request request2 = ((returnType == typeof(object)) ? request.Push(ServiceInfo.Of(obj.GetType(), request.GetActualServiceType())) : request.PushServiceType(obj.GetType()));
		factoryFunc = null;
		return Resolver.CreateResolutionExpression(request2, openResolutionScope: false, asResolutionCall: true);
	}

	private DryIoc.FastExpressionCompiler.LightExpression.MemberAssignment[] TryGetMemberAssignments(ref bool failedToGet, Request request, IContainer container, Rules rules)
	{
		if (rules.PropertiesAndFields == null && Made.PropertiesAndFields == null)
		{
			return null;
		}
		IEnumerable<PropertyOrFieldServiceInfo> enumerable = rules.TryGetPropertiesAndFieldsSelector(Made)(request);
		if (enumerable == null)
		{
			return null;
		}
		DryIoc.FastExpressionCompiler.LightExpression.MemberAssignment[] array = null;
		foreach (PropertyOrFieldServiceInfo item in enumerable)
		{
			if (item != null)
			{
				Request request2 = request.Push(item);
				DryIoc.FastExpressionCompiler.LightExpression.Expression expression = TryGetUsedInstanceOrCustomValueExpression(request, request2, item.Details) ?? container.ResolveFactory(request2)?.GetExpressionOrDefault(request2);
				if (expression != null)
				{
					array = array.Append(DryIoc.FastExpressionCompiler.LightExpression.Expression.Bind(item.Member, expression));
				}
				else if (request.IfUnresolved == IfUnresolved.ReturnDefault)
				{
					failedToGet = true;
					return null;
				}
			}
		}
		return array;
	}

	private static DryIoc.FastExpressionCompiler.LightExpression.Expression ConvertExpressionIfNeeded(DryIoc.FastExpressionCompiler.LightExpression.Expression serviceExpr, Request request, MemberInfo ctorOrMember)
	{
		Type actualServiceType = request.GetActualServiceType();
		Type type = serviceExpr.Type;
		if (type == actualServiceType || actualServiceType.IsAssignableFrom(type))
		{
			return serviceExpr;
		}
		if (type == typeof(object))
		{
			return actualServiceType.Cast(serviceExpr);
		}
		MethodInfo conversionOperatorOrNull = type.GetConversionOperatorOrNull(actualServiceType);
		if (conversionOperatorOrNull != null)
		{
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Convert(serviceExpr, actualServiceType, conversionOperatorOrNull);
		}
		if (request.IfUnresolved == IfUnresolved.Throw)
		{
			return Throw.For<DryIoc.FastExpressionCompiler.LightExpression.Expression>(Error.ServiceIsNotAssignableFromFactoryMethod, actualServiceType, ctorOrMember, request);
		}
		return null;
	}

	internal static DryIoc.FastExpressionCompiler.LightExpression.Expression TryGetExpressionFromInputArgs(Type paramType, DryIoc.FastExpressionCompiler.LightExpression.Expression[] inputArgs, ref int argsUsedMask)
	{
		for (int i = 0; i < inputArgs.Length; i++)
		{
			DryIoc.FastExpressionCompiler.LightExpression.Expression expression = inputArgs[i];
			if ((argsUsedMask & (1 << i)) == 0 && paramType.IsAssignableFrom(expression.Type))
			{
				argsUsedMask |= 1 << i;
				return expression;
			}
		}
		return null;
	}

	internal static DryIoc.FastExpressionCompiler.LightExpression.Expression TryGetUsedInstanceOrCustomValueExpression(Request request, Request paramRequest, ServiceDetails paramDetails)
	{
		if (paramDetails.HasCustomValue)
		{
			Type serviceType = paramRequest.ServiceType;
			MethodInfo methodInfo = null;
			object customValue = paramDetails.CustomValue;
			if (customValue != null)
			{
				Type type = customValue.GetType();
				if (!type.IsArray && !type.IsAssignableTo(serviceType) && null == (methodInfo = type.GetConversionOperatorOrNull(serviceType)))
				{
					return Throw.For<DryIoc.FastExpressionCompiler.LightExpression.Expression>(paramRequest.IfUnresolved != IfUnresolved.ReturnDefault, Error.InjectedCustomValueIsOfDifferentType, customValue, serviceType, paramRequest);
				}
			}
			if (!(methodInfo != null))
			{
				return request.Container.GetConstantExpression(customValue, serviceType);
			}
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Convert(request.Container.GetConstantExpression(customValue), serviceType, methodInfo);
		}
		if (paramDetails == ServiceDetails.Default)
		{
			Type serviceType2 = paramRequest.ServiceType;
			if (request.Container.TryGetUsedInstance(RuntimeHelpers.GetHashCode(serviceType2), serviceType2, out var _))
			{
				return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(ResolverContext.GetRootOrSelfExpr(paramRequest), Resolver.ResolveFastMethod, DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantOf(serviceType2), paramRequest.IfUnresolved.ToConstant());
			}
		}
		return null;
	}

	internal override bool ValidateAndNormalizeRegistration(Type serviceType, object serviceKey, bool isStaticallyChecked, Rules rules, bool throwIfInvalid)
	{
		if (!base.ValidateAndNormalizeRegistration(serviceType, serviceKey, isStaticallyChecked, rules, throwIfInvalid))
		{
			return false;
		}
		if (!CanAccessImplementationType)
		{
			return true;
		}
		Type implementationType = ImplementationType;
		object obj = Made.FactoryMethodOrSelector ?? rules.FactoryMethodOrSelector;
		if (obj == null || obj == FactoryMethod.ConstructorWithResolvableArguments)
		{
			ConstructorInfo[] constructors = implementationType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
			switch (constructors.Length)
			{
			case 1:
				_implementationTypeOrProviderOrPubCtorOrCtors = constructors[0];
				break;
			case 0:
				return Throw.When(throwIfInvalid, Error.UnableToSelectSinglePublicConstructorFromNone, implementationType);
			default:
				if (obj == null)
				{
					return Throw.When(throwIfInvalid, Error.UnableToSelectSinglePublicConstructorFromMultiple, implementationType, constructors);
				}
				_implementationTypeOrProviderOrPubCtorOrCtors = constructors;
				break;
			}
		}
		if (isStaticallyChecked || implementationType == null)
		{
			return true;
		}
		if (!implementationType.IsGenericTypeDefinition)
		{
			if (implementationType.IsGenericType && implementationType.ContainsGenericParameters)
			{
				return Throw.When(throwIfInvalid, Error.RegisteringNotAGenericTypedefImplType, implementationType, implementationType.GetGenericDefinitionOrNull());
			}
			if (implementationType != serviceType || serviceType != typeof(object))
			{
				if (!serviceType.IsGenericTypeDefinition)
				{
					if (!serviceType.IsAssignableFrom(implementationType))
					{
						return Throw.When(throwIfInvalid, Error.RegisteringImplementationNotAssignableToServiceType, implementationType, serviceType);
					}
				}
				else if (implementationType.GetImplementedTypes().IndexOf(serviceType, (Type st, Type t) => t == st || t.GetGenericDefinitionOrNull() == st) == -1)
				{
					return Throw.When(throwIfInvalid, Error.RegisteringImplementationNotAssignableToServiceType, implementationType, serviceType);
				}
			}
		}
		else if (implementationType != serviceType)
		{
			if (serviceType.IsGenericTypeDefinition)
			{
				return ValidateImplementationAndServiceTypeParamsMatch(implementationType, serviceType, throwIfInvalid);
			}
			if (!serviceType.IsGenericType)
			{
				return Throw.When(throwIfInvalid, Error.RegisteringOpenGenericImplWithNonGenericService, implementationType, serviceType);
			}
			if (!implementationType.IsImplementingServiceType(serviceType.GetGenericTypeDefinition()))
			{
				return Throw.When(throwIfInvalid, Error.RegisteringImplementationNotAssignableToServiceType, implementationType, serviceType);
			}
		}
		return true;
	}

	private static bool ValidateImplementationAndServiceTypeParamsMatch(Type implType, Type serviceType, bool throwIfInvalid)
	{
		Type[] genericArguments = implType.GetGenericArguments();
		Type[] implementedTypes = implType.GetImplementedTypes();
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		while (!flag2 && num < implementedTypes.Length)
		{
			Type type = implementedTypes[num];
			flag = type.GetGenericDefinitionOrNull() == serviceType;
			flag2 = flag && type.ContainsAllGenericTypeParameters(genericArguments);
			num++;
		}
		if (!flag)
		{
			return Throw.When(throwIfInvalid, Error.RegisteringImplementationNotAssignableToServiceType, implType, serviceType);
		}
		if (!flag2)
		{
			return Throw.When(throwIfInvalid, Error.RegisteringOpenGenericServiceWithMissingTypeArgs, implType, serviceType, implementedTypes.Match(serviceType, (Type st, Type t) => t.GetGenericDefinitionOrNull() == st));
		}
		return true;
	}

	private static void MatchOpenGenericConstraints(Type[] implTypeParams, Type[] implTypeArgs)
	{
		for (int i = 0; i < implTypeParams.Length; i++)
		{
			Type type = implTypeArgs[i];
			if (type == null)
			{
				continue;
			}
			Type[] genericParameterConstraints = implTypeParams[i].GetGenericParameterConstraints();
			if (genericParameterConstraints.IsNullOrEmpty())
			{
				continue;
			}
			bool flag = false;
			int num = 0;
			while (!flag && num < genericParameterConstraints.Length)
			{
				Type type2 = genericParameterConstraints[num];
				if (type2 != type && type2.IsOpenGeneric())
				{
					Type[] serviceArgs = (type.IsGenericType ? type.GetGenericArguments() : (type.IsArray ? type.GetElementType().One() : type.One()));
					Type[] genericArguments = type2.GetGenericArguments();
					flag = MatchServiceWithImplementedTypeParams(implTypeArgs, implTypeParams, genericArguments, serviceArgs);
				}
				num++;
			}
		}
	}

	private static bool MatchServiceWithImplementedTypeParams(Type[] resultImplArgs, Type[] implParams, Type[] serviceParams, Type[] serviceArgs)
	{
		if (serviceArgs.Length != serviceParams.Length)
		{
			return false;
		}
		for (int i = 0; i < serviceParams.Length; i++)
		{
			Type type = serviceArgs[i];
			Type type2 = serviceParams[i];
			if (type2.IsGenericParameter)
			{
				int num = implParams.Length - 1;
				while (num != -1 && (object)implParams[num] != type2)
				{
					num--;
				}
				if (num != -1)
				{
					if (resultImplArgs[num] == null)
					{
						resultImplArgs[num] = type;
					}
					else if (resultImplArgs[num] != type)
					{
						return false;
					}
				}
			}
			else if (type2 != type)
			{
				if (!type2.IsOpenGeneric() || type2.GetGenericDefinitionOrNull() != type.GetGenericDefinitionOrNull())
				{
					return false;
				}
				if (!MatchServiceWithImplementedTypeParams(resultImplArgs, implParams, type2.GetGenericArguments(), type.GetGenericArguments()))
				{
					return false;
				}
			}
		}
		return true;
	}

	private static FactoryMethod GetClosedFactoryMethodOrDefault(FactoryMethod factoryMethod, Type[] serviceTypeArgs, Request request, bool ifErrorReturnDefault = false)
	{
		MemberInfo memberInfo = factoryMethod.ConstructorOrMethodOrMember;
		ServiceInfo serviceInfo = factoryMethod.FactoryServiceInfo;
		Type returnTypeOrDefault = memberInfo.GetReturnTypeOrDefault();
		Type[] serviceParams = (returnTypeOrDefault.IsGenericParameter ? returnTypeOrDefault.One() : returnTypeOrDefault.GetGenericArguments());
		Type type = memberInfo.DeclaringType.ThrowIfNull();
		if (type.IsOpenGeneric())
		{
			Type[] genericArguments = type.GetGenericArguments();
			Type[] array = new Type[genericArguments.Length];
			if (!MatchServiceWithImplementedTypeParams(array, genericArguments, serviceParams, serviceTypeArgs))
			{
				if (!ifErrorReturnDefault && request.IfUnresolved == IfUnresolved.Throw)
				{
					return Throw.For<FactoryMethod>(Error.NoMatchedFactoryMethodDeclaringTypeWithServiceTypeArgs, type, new StringBuilder().Print(serviceTypeArgs, "\"", ", "), request);
				}
				return null;
			}
			if (serviceInfo != null)
			{
				Type type2 = serviceInfo.ServiceType;
				if (type2 != type)
				{
					type2 = type.GetImplementedTypes().FindFirst(type2, (Type fServiceType, Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == fServiceType).ThrowIfNull();
				}
				Type[] genericArguments2 = type2.GetGenericArguments();
				Type[] array2 = new Type[genericArguments2.Length];
				if (MatchServiceWithImplementedTypeParams(array2, genericArguments2, genericArguments, array))
				{
					type2 = type2.GetGenericTypeDefinition().ThrowIfNull();
					Type type3 = type2.TryCloseGenericTypeOrMethod(array2, (Type t, Type[] a) => t.MakeGenericType(a), !ifErrorReturnDefault && request.IfUnresolved == IfUnresolved.Throw, Error.NoMatchedGenericParamConstraints, request);
					if (type3 == null)
					{
						return null;
					}
					serviceInfo = ServiceInfo.Of(type3).WithDetails(serviceInfo.Details);
				}
			}
			MatchOpenGenericConstraints(genericArguments, array);
			Type type4 = type.TryCloseGenericTypeOrMethod(array, (Type t, Type[] a) => t.MakeGenericType(a), !ifErrorReturnDefault && request.IfUnresolved == IfUnresolved.Throw, Error.NoMatchedGenericParamConstraints, request);
			if (type4 == null)
			{
				return null;
			}
			MethodBase methodBase = memberInfo as MethodBase;
			if (methodBase != null)
			{
				MethodInfo[] array3 = type4.GetMethods().Match(memberInfo, methodBase.GetParameters(), (MemberInfo fm, ParameterInfo[] fp, MethodInfo m) => m.Name == fm.Name && m.GetParameters().Length == fp.Length);
				if (array3.Length == 1)
				{
					memberInfo = array3[0];
				}
				else
				{
					PropertyInfo propertyInfo = typeof(MethodBase).GetProperty("MethodHandle").ThrowIfNull(Error.OpenGenericFactoryMethodDeclaringTypeIsNotSupportedOnThisPlatform, type, type4, methodBase.Name);
					memberInfo = MethodBase.GetMethodFromHandle((RuntimeMethodHandle)propertyInfo.GetValue(methodBase, ArrayTools.Empty<object>()), type4.TypeHandle);
				}
			}
			else if (memberInfo is FieldInfo)
			{
				memberInfo = type4.GetField(memberInfo.Name).ThrowIfNull();
			}
			else if (memberInfo is PropertyInfo)
			{
				memberInfo = type4.GetProperty(memberInfo.Name).ThrowIfNull();
			}
		}
		MethodInfo methodInfo = memberInfo as MethodInfo;
		if (methodInfo != null && methodInfo.ContainsGenericParameters)
		{
			Type[] genericArguments3 = methodInfo.GetGenericArguments();
			Type[] array4 = new Type[genericArguments3.Length];
			if (!MatchServiceWithImplementedTypeParams(array4, genericArguments3, serviceParams, serviceTypeArgs))
			{
				if (!ifErrorReturnDefault && request.IfUnresolved == IfUnresolved.Throw)
				{
					return Throw.For<FactoryMethod>(Error.NoMatchedFactoryMethodWithServiceTypeArgs, methodInfo, new StringBuilder().Print(serviceTypeArgs, "\"", ", "), request);
				}
				return null;
			}
			MatchOpenGenericConstraints(genericArguments3, array4);
			memberInfo = methodInfo.TryCloseGenericTypeOrMethod(array4, (MethodInfo m, Type[] a) => m.MakeGenericMethod(a), !ifErrorReturnDefault && request.IfUnresolved == IfUnresolved.Throw, Error.NoMatchedGenericParamConstraints, request);
			if (memberInfo == null)
			{
				return null;
			}
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression factoryExpression = factoryMethod.FactoryExpression;
		if (factoryExpression == null)
		{
			return new FactoryMethod.WithFactoryServiceInfo(memberInfo, serviceInfo);
		}
		return new FactoryMethod.WithFactoryExpression(memberInfo, factoryExpression);
	}
}
