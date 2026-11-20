using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public sealed class Request : IEnumerable<Request>, IEnumerable
{
	internal static readonly RequestFlags InheritedFlags = RequestFlags.IsSingletonOrDependencyOfSingleton | RequestFlags.IsWrappedInFunc;

	public static readonly Request Empty = new Request(null, null, 0, 0, null, RequestFlags.Default, null, null, null);

	internal static readonly Expression EmptyRequestExpr = Expression.Field(typeof(Request).GetField("Empty"));

	public static readonly Request EmptyOpensResolutionScope = new Request(null, null, 0, 0, null, RequestFlags.OpensResolutionScope, null, null, null);

	public Request DirectParent;

	internal RequestStack RequestStack;

	internal object ServiceTypeOrInfo;

	private Type _actualServiceType;

	internal Expression[] InputArgExprs;

	internal object _factoryOrImplType;

	private int _hashCode;

	public RequestFlags Flags;

	public int DependencyDepth;

	public int DependencyCount;

	internal static readonly Lazy<MethodInfo> PushMethodWith4Args = Lazy.Of(() => typeof(Request).Method("Push", typeof(Type), typeof(int), typeof(Type), typeof(IReuse)));

	internal static readonly Lazy<MethodInfo> PushMethodWith5Args = Lazy.Of(() => typeof(Request).Method("Push", typeof(Type), typeof(int), typeof(Type), typeof(IReuse), typeof(RequestFlags)));

	internal static readonly Lazy<MethodInfo> PushMethodWith8Args = Lazy.Of(() => typeof(Request).Method("Push", typeof(Type), typeof(Type), typeof(object), typeof(int), typeof(FactoryType), typeof(Type), typeof(IReuse), typeof(RequestFlags)));

	internal static readonly Lazy<MethodInfo> PushMethodWith10Args = Lazy.Of(() => typeof(Request).Method("Push", typeof(Type), typeof(Type), typeof(object), typeof(IfUnresolved), typeof(int), typeof(FactoryType), typeof(Type), typeof(IReuse), typeof(RequestFlags), typeof(int)));

	internal static readonly Lazy<MethodInfo> PushMethodWith12Args = Lazy.Of(() => typeof(Request).Method("Push", typeof(Type), typeof(Type), typeof(object), typeof(string), typeof(object), typeof(IfUnresolved), typeof(int), typeof(FactoryType), typeof(Type), typeof(IReuse), typeof(RequestFlags), typeof(int)));

	public IContainer Container { get; private set; }

	public IReuse Reuse { get; private set; }

	public ConstructorInfo SelectedConstructor { get; internal set; }

	public int FactoryID { get; private set; }

	public int DecoratedFactoryID { get; private set; }

	public FactoryType FactoryType { get; private set; }

	internal Factory Factory => _factoryOrImplType as Factory;

	public Type ImplementationType
	{
		get
		{
			object obj = _factoryOrImplType as Type;
			if (obj == null)
			{
				Factory obj2 = _factoryOrImplType as Factory;
				if (obj2 == null)
				{
					return null;
				}
				obj = obj2.ImplementationType;
			}
			return (Type)obj;
		}
	}

	public bool IsEmpty => DirectParent == null;

	public bool IsResolutionRoot
	{
		get
		{
			if (DirectParent != null)
			{
				return DirectParent.DirectParent == null;
			}
			return false;
		}
	}

	public bool IsResolutionCall => (Flags & RequestFlags.IsResolutionCall) != 0;

	public bool IsNestedResolutionCall
	{
		get
		{
			if ((Flags & RequestFlags.IsResolutionCall) != RequestFlags.Default)
			{
				return DirectParent?.DirectParent != null;
			}
			return false;
		}
	}

	public bool OpensResolutionScope
	{
		get
		{
			if (DirectParent != null)
			{
				return (DirectParent.Flags & RequestFlags.OpensResolutionScope) != 0;
			}
			return false;
		}
	}

	public bool TracksTransientDisposable => (Flags & RequestFlags.TracksTransientDisposable) != 0;

	public bool IsSingletonOrDependencyOfSingleton => (Flags & RequestFlags.IsSingletonOrDependencyOfSingleton) != 0;

	public IScope CurrentScope => Container.CurrentScope;

	public IScope SingletonScope => Container.SingletonScope;

	public Rules Rules => Container.Rules;

	public Made Made => Factory?.Made;

	public Request Parent
	{
		get
		{
			Request directParent = DirectParent;
			if (directParent != null)
			{
				while (directParent.DirectParent != null && directParent.FactoryType == FactoryType.Wrapper)
				{
					directParent = directParent.DirectParent;
				}
			}
			return directParent;
		}
	}

	public Type ServiceType
	{
		get
		{
			if (!(ServiceTypeOrInfo is ServiceInfo serviceInfo))
			{
				return _actualServiceType;
			}
			return serviceInfo.ServiceType;
		}
	}

	public object ServiceKey
	{
		get
		{
			if (!(ServiceTypeOrInfo is ServiceInfo serviceInfo))
			{
				return null;
			}
			return serviceInfo.Details.ServiceKey;
		}
	}

	public IfUnresolved IfUnresolved
	{
		get
		{
			if (!(ServiceTypeOrInfo is ServiceInfo serviceInfo))
			{
				return IfUnresolved.Throw;
			}
			return serviceInfo.Details.IfUnresolved;
		}
	}

	public Type RequiredServiceType
	{
		get
		{
			if (!(ServiceTypeOrInfo is ServiceInfo serviceInfo))
			{
				return null;
			}
			return serviceInfo.Details.RequiredServiceType;
		}
	}

	public int ReuseLifespan => Reuse?.Lifespan ?? 0;

	internal static Request CreateForValidation(IContainer container, ServiceInfo serviceInfo, RequestStack stack)
	{
		ref Request reference = ref stack.Requests[0];
		if (reference == null)
		{
			reference = new Request(container, Empty, 1, 0, stack, RequestFlags.IsResolutionCall, serviceInfo, serviceInfo.GetActualServiceType(), null);
		}
		else
		{
			reference.SetServiceInfo(container, Empty, 1, 0, stack, RequestFlags.IsResolutionCall, serviceInfo, serviceInfo.GetActualServiceType(), null);
		}
		return reference;
	}

	public static Request Create(IContainer container, ServiceInfo serviceInfo, Request preResolveParent = null, RequestFlags flags = RequestFlags.Default, object[] inputArgs = null)
	{
		Type serviceType = serviceInfo.ServiceType;
		if (serviceType != null && serviceType.IsOpenGeneric())
		{
			Throw.It(Error.ResolvingOpenGenericServiceTypeIsNotPossible, serviceType);
		}
		flags |= RequestFlags.IsResolutionCall;
		preResolveParent = preResolveParent ?? Empty;
		if (preResolveParent.IsEmpty)
		{
			flags |= preResolveParent.Flags;
		}
		else
		{
			object serviceTypeOrInfo = preResolveParent.ServiceTypeOrInfo;
			if (serviceTypeOrInfo is ServiceInfo { Details: not null } serviceInfo2 && serviceInfo2.Details != ServiceDetails.Default)
			{
				serviceInfo = serviceInfo.InheritInfoFromDependencyOwner(serviceInfo2.ServiceType, serviceInfo2.Details, container, preResolveParent.FactoryType);
			}
			flags |= preResolveParent.Flags & InheritedFlags;
		}
		ConstantExpression[] array = inputArgs?.Map((object a) => Expression.Constant(a));
		RequestStack requestStack = RequestStack.Create();
		ref Request reference = ref requestStack.Requests[0];
		if (reference == null)
		{
			Request parent = preResolveParent;
			RequestFlags flags2 = flags;
			ServiceInfo serviceInfo3 = serviceInfo;
			Type actualServiceType = serviceInfo.GetActualServiceType();
			Expression[] inputArgExprs = array;
			reference = new Request(container, parent, 1, 0, requestStack, flags2, serviceInfo3, actualServiceType, inputArgExprs);
		}
		else
		{
			Request obj = reference;
			Request parent2 = preResolveParent;
			RequestFlags flags3 = flags;
			ServiceInfo serviceTypeOrInfo2 = serviceInfo;
			Type actualServiceType2 = serviceInfo.GetActualServiceType();
			Expression[] inputArgExprs = array;
			obj.SetServiceInfo(container, parent2, 1, 0, requestStack, flags3, serviceTypeOrInfo2, actualServiceType2, inputArgExprs);
		}
		return reference;
	}

	public static Request CreateResolutionRoot(IContainer container, Type serviceType, IfUnresolved ifUnresolved = IfUnresolved.Throw)
	{
		if (serviceType != null && serviceType.IsOpenGeneric())
		{
			Throw.It(Error.ResolvingOpenGenericServiceTypeIsNotPossible, serviceType);
		}
		object obj = ((ifUnresolved == IfUnresolved.Throw) ? ((object)serviceType) : ((object)ServiceInfo.Of(serviceType, ifUnresolved)));
		RequestStack requestStack = RequestStack.Create();
		ref Request reference = ref requestStack.Requests[0];
		if (reference == null)
		{
			reference = new Request(container, Empty, 1, 0, requestStack, RequestFlags.IsResolutionCall, obj, serviceType, null);
		}
		else
		{
			reference.SetServiceInfo(container, Empty, 1, 0, requestStack, RequestFlags.IsResolutionCall, obj, serviceType, null);
		}
		return reference;
	}

	public static Request Create(IContainer container, Type serviceType, object serviceKey = null, IfUnresolved ifUnresolved = IfUnresolved.Throw, Type requiredServiceType = null, Request preResolveParent = null, RequestFlags flags = RequestFlags.Default, object[] inputArgs = null)
	{
		return Create(container, ServiceInfo.Of(serviceType, requiredServiceType, ifUnresolved, serviceKey), preResolveParent, flags, inputArgs);
	}

	public int CombineDecoratorWithDecoratedFactoryID()
	{
		return FactoryID | (DecoratedFactoryID << 16);
	}

	public Request WithWrappedServiceFactory(Factory f)
	{
		_factoryOrImplType = f;
		return this;
	}

	internal void DecreaseTrackedDependencyCountForParents(int dependencyCount)
	{
		Request directParent = DirectParent;
		while (!directParent.IsEmpty)
		{
			directParent.DependencyCount -= dependencyCount;
			directParent = directParent.DirectParent;
		}
	}

	public bool IsWrappedInFunc()
	{
		return (Flags & RequestFlags.IsWrappedInFunc) != 0;
	}

	public bool IsDirectlyWrappedInFunc()
	{
		return (Flags & RequestFlags.IsDirectlyWrappedInFunc) != 0;
	}

	public bool IsWrappedInFuncWithArgs()
	{
		return InputArgExprs != null;
	}

	public Expression GetInputArgsExpr()
	{
		if (InputArgExprs != null)
		{
			return Expression.NewArrayInit(typeof(object), InputArgExprs.Map((Expression x) => (!x.Type.IsValueType) ? x : Expression.Convert<object>(x)));
		}
		return Expression.Constant(null, typeof(object[]));
	}

	public Type GetActualServiceType()
	{
		return _actualServiceType;
	}

	public ServiceDetails GetServiceDetails()
	{
		if (!(ServiceTypeOrInfo is ServiceInfo serviceInfo))
		{
			return ServiceDetails.Default;
		}
		return serviceInfo.Details;
	}

	public Type GetKnownImplementationOrServiceType()
	{
		return ImplementationType ?? _actualServiceType;
	}

	private ref Request GetOrPushPooledRequest(RequestStack stack, int indexInStack)
	{
		if (stack == null)
		{
			stack = RequestStack.CreateToAccommodateIndex(indexInStack);
			Request request = null;
			do
			{
				request = ((request == null) ? this : request.DirectParent);
				request.RequestStack = stack;
			}
			while ((request.Flags & RequestFlags.IsResolutionCall) == 0 && !request.DirectParent.IsEmpty);
		}
		return ref stack.GetOrPushRef(indexInStack);
	}

	public Request Push(ServiceInfo info, RequestFlags additionalFlags = RequestFlags.Default)
	{
		if (FactoryID == 0)
		{
			Throw.It(Error.PushingToRequestWithoutFactory, info, this);
		}
		if (ServiceTypeOrInfo is ServiceInfo { Details: not null } serviceInfo && serviceInfo.Details != ServiceDetails.Default)
		{
			info = info.InheritInfoFromDependencyOwner(serviceInfo.ServiceType, serviceInfo.Details, Container, FactoryType);
		}
		RequestFlags flags = (Flags & InheritedFlags) | additionalFlags;
		int dependencyDepth = DependencyDepth;
		ref Request orPushPooledRequest = ref GetOrPushPooledRequest(RequestStack, dependencyDepth);
		if (orPushPooledRequest == null)
		{
			orPushPooledRequest = new Request(Container, this, dependencyDepth + 1, 0, RequestStack, flags, info, info.GetActualServiceType(), InputArgExprs);
		}
		else
		{
			orPushPooledRequest.SetServiceInfo(Container, this, dependencyDepth + 1, 0, RequestStack, flags, info, info.GetActualServiceType(), InputArgExprs);
		}
		return orPushPooledRequest;
	}

	public Request Push(ParameterInfo parameter, RequestFlags additionalFlags = RequestFlags.Default)
	{
		if (FactoryID == 0)
		{
			Throw.It(Error.PushingToRequestWithoutFactory, ParameterServiceInfo.Of(parameter), this);
		}
		object obj = parameter;
		Type type = parameter.ParameterType;
		if (ServiceTypeOrInfo is ServiceInfo { Details: not null } serviceInfo && serviceInfo.Details != ServiceDetails.Default)
		{
			obj = type.InheritInfoFromDependencyOwner(serviceInfo.ServiceType, serviceInfo.Details, Container, FactoryType);
			if (obj is ServiceInfo info)
			{
				type = info.GetActualServiceType();
			}
		}
		RequestFlags flags = (Flags & InheritedFlags) | additionalFlags;
		int dependencyDepth = DependencyDepth;
		ref Request orPushPooledRequest = ref GetOrPushPooledRequest(RequestStack, dependencyDepth);
		if (orPushPooledRequest == null)
		{
			orPushPooledRequest = new Request(Container, this, dependencyDepth + 1, 0, RequestStack, flags, obj, type, InputArgExprs);
		}
		else
		{
			orPushPooledRequest.SetServiceInfo(Container, this, dependencyDepth + 1, 0, RequestStack, flags, obj, type, InputArgExprs);
		}
		return orPushPooledRequest;
	}

	public Request PushServiceType(Type serviceType, RequestFlags additionalFlags = RequestFlags.Default)
	{
		object obj;
		if (ServiceTypeOrInfo is ServiceInfo { Details: not null } serviceInfo && serviceInfo.Details != ServiceDetails.Default)
		{
			obj = serviceType.InheritInfoFromDependencyOwner(serviceInfo.ServiceType, serviceInfo.Details, Container, FactoryType);
			if (obj is ServiceInfo info)
			{
				serviceType = info.GetActualServiceType();
			}
		}
		else
		{
			obj = ServiceInfo.Of(serviceType);
		}
		RequestFlags flags = (Flags & InheritedFlags) | additionalFlags;
		int dependencyDepth = DependencyDepth;
		ref Request orPushPooledRequest = ref GetOrPushPooledRequest(RequestStack, dependencyDepth);
		if (orPushPooledRequest == null)
		{
			orPushPooledRequest = new Request(Container, this, dependencyDepth + 1, 0, RequestStack, flags, obj, serviceType, InputArgExprs);
		}
		else
		{
			orPushPooledRequest.SetServiceInfo(Container, this, dependencyDepth + 1, 0, RequestStack, flags, obj, serviceType, InputArgExprs);
		}
		return orPushPooledRequest;
	}

	public Request Push(Type serviceType, object serviceKey = null, IfUnresolved ifUnresolved = IfUnresolved.Throw, Type requiredServiceType = null, RequestFlags flags = RequestFlags.Default)
	{
		return Push(ServiceInfo.Of(serviceType.ThrowIfNull().ThrowIf(serviceType.IsOpenGeneric(), Error.ResolvingOpenGenericServiceTypeIsNotPossible), requiredServiceType, ifUnresolved, serviceKey), flags);
	}

	public Request Push(Type serviceType, int factoryID, Type implementationType, IReuse reuse)
	{
		return Push(serviceType, null, null, null, null, IfUnresolved.Throw, factoryID, FactoryType.Service, implementationType, reuse, RequestFlags.Default, 0);
	}

	public Request Push(Type serviceType, int factoryID, Type implementationType, IReuse reuse, RequestFlags flags)
	{
		return Push(serviceType, null, null, null, null, IfUnresolved.Throw, factoryID, FactoryType.Service, implementationType, reuse, flags, 0);
	}

	public Request Push(Type serviceType, Type requiredServiceType, object serviceKey, int factoryID, FactoryType factoryType, Type implementationType, IReuse reuse, RequestFlags flags)
	{
		return Push(serviceType, requiredServiceType, serviceKey, null, null, IfUnresolved.Throw, factoryID, factoryType, implementationType, reuse, flags, 0);
	}

	public Request Push(Type serviceType, Type requiredServiceType, object serviceKey, IfUnresolved ifUnresolved, int factoryID, FactoryType factoryType, Type implementationType, IReuse reuse, RequestFlags flags, int decoratedFactoryID)
	{
		return Push(serviceType, requiredServiceType, serviceKey, null, null, ifUnresolved, factoryID, factoryType, implementationType, reuse, flags, decoratedFactoryID);
	}

	public Request Push(Type serviceType, Type requiredServiceType, object serviceKey, string metadataKey, object metadata, IfUnresolved ifUnresolved, int factoryID, FactoryType factoryType, Type implementationType, IReuse reuse, RequestFlags flags, int decoratedFactoryID)
	{
		ServiceInfo serviceInfo = ServiceInfo.Of(serviceType, requiredServiceType, ifUnresolved, serviceKey, metadataKey, metadata);
		return new Request(Container, this, DependencyDepth + 1, 0, null, flags, serviceInfo, serviceInfo.GetActualServiceType(), InputArgExprs, implementationType, factoryID, factoryType, reuse, decoratedFactoryID);
	}

	public Request WithChangedType<S>(S state, Func<Type, S, Type> getInfo)
	{
		Type serviceType = ServiceType;
		Type type = getInfo(serviceType, state);
		if (type == serviceType)
		{
			return this;
		}
		object obj = ((ServiceTypeOrInfo is ParameterInfo parameter) ? ParameterServiceInfo.Of(parameter, type, ServiceDetails.Default) : ((ServiceTypeOrInfo is ServiceInfo source) ? ((object)source.WithType(type)) : ((object)type)));
		Type actualServiceType = ((obj is Type type2) ? type2 : ((ServiceInfo)obj).GetActualServiceType());
		return new Request(Container, DirectParent, DependencyDepth, DependencyCount, RequestStack, Flags, obj, actualServiceType, InputArgExprs, _factoryOrImplType, FactoryID, FactoryType, Reuse, DecoratedFactoryID);
	}

	public Request WithIfUnresolved(IfUnresolved ifUnresolved)
	{
		ServiceInfo serviceInfo = null;
		object serviceTypeOrInfo = ServiceTypeOrInfo;
		if (serviceTypeOrInfo is ServiceInfo serviceInfo2)
		{
			if (serviceInfo2.Details.IfUnresolved == ifUnresolved || (serviceInfo = serviceInfo2.WithIfUnresolved(ifUnresolved)) == serviceInfo2)
			{
				return this;
			}
		}
		else
		{
			if (ifUnresolved == IfUnresolved.Throw)
			{
				return this;
			}
			serviceInfo = ((serviceTypeOrInfo is ParameterInfo parameter) ? ParameterServiceInfo.Of(parameter, _actualServiceType, ServiceDetails.Of(ifUnresolved)) : ServiceInfo.Of(_actualServiceType, ifUnresolved));
		}
		return new Request(Container, DirectParent, DependencyDepth, DependencyCount, RequestStack, Flags, serviceInfo, serviceInfo.GetActualServiceType(), InputArgExprs, _factoryOrImplType, FactoryID, FactoryType, Reuse, DecoratedFactoryID);
	}

	public Request WithFlags(RequestFlags newFlags)
	{
		return new Request(Container, DirectParent, DependencyDepth, DependencyCount, RequestStack, newFlags, ServiceTypeOrInfo, _actualServiceType, InputArgExprs, _factoryOrImplType, FactoryID, FactoryType, Reuse, DecoratedFactoryID);
	}

	public void ChangeServiceKey(object serviceKey)
	{
		if (ServiceTypeOrInfo is ServiceInfo { Details: var details } serviceInfo)
		{
			ServiceTypeOrInfo = serviceInfo.Create(serviceInfo.ServiceType, ServiceDetails.Of(details.RequiredServiceType, serviceKey, details.IfUnresolved, details.DefaultValue, details.MetadataKey, details.Metadata));
		}
		else if (ServiceTypeOrInfo is ParameterInfo parameter)
		{
			ServiceTypeOrInfo = ParameterServiceInfo.Of(parameter, _actualServiceType, ServiceDetails.Of(null, serviceKey));
		}
		else
		{
			ServiceTypeOrInfo = ServiceInfo.Of(_actualServiceType, serviceKey);
		}
	}

	public Request WithInputArgs(Expression[] inputArgs)
	{
		return new Request(Container, DirectParent, DependencyDepth, DependencyCount, RequestStack, Flags, ServiceTypeOrInfo, _actualServiceType, inputArgs.Append(InputArgExprs), _factoryOrImplType, FactoryID, FactoryType, Reuse, DecoratedFactoryID);
	}

	public Request WithResolvedFactory(Factory factory, bool skipRecursiveDependencyCheck = false, bool skipCaptiveDependencyCheck = false, bool copyRequest = false)
	{
		int factoryID = factory.FactoryID;
		int decoratedFactoryID = 0;
		if (Factory != null && FactoryID != 0)
		{
			if (FactoryID == factoryID)
			{
				return this;
			}
			if (FactoryType != FactoryType.Decorator && factory.FactoryType == FactoryType.Decorator)
			{
				decoratedFactoryID = FactoryID;
			}
		}
		RequestFlags requestFlags = Flags & ~RequestFlags.TracksTransientDisposable;
		if (skipRecursiveDependencyCheck)
		{
			requestFlags |= RequestFlags.StopRecursiveDependencyCheck;
		}
		Setup setup = factory.Setup;
		IReuse reuse = null;
		reuse = ((InputArgExprs != null && Rules.IgnoringReuseForFuncWithArgs) ? DryIoc.Reuse.Transient : ((factory.Reuse != null) ? factory.Reuse : (setup.UseParentReuse ? (DirectParent.IsEmpty ? Rules.DefaultReuse : null) : ((factory.FactoryType == FactoryType.Decorator && (setup.To<Setup.DecoratorSetup>().UseDecorateeReuse || Rules.UseDecorateeReuseForDecorators)) ? Reuse : ((factory.FactoryType != FactoryType.Wrapper) ? Rules.DefaultReuse : DryIoc.Reuse.Transient)))));
		IReuse reuse2 = null;
		if (!DirectParent.IsEmpty)
		{
			bool flag = !skipRecursiveDependencyCheck && factory.FactoryType == FactoryType.Service;
			int num = reuse?.Lifespan ?? 0;
			bool flag2 = !skipCaptiveDependencyCheck && !IsDirectlyWrappedInFunc() && !factory.Setup.OpenResolutionScope && ((Rules.ThrowIfDependencyHasShorterReuseLifespan && num > 0) || (Rules.ThrowIfScopedOrSingletonHasTransientDependency && num == 0));
			bool flag3 = flag2 && ((reuse as CurrentScopeReuse)?.ScopedOrSingleton ?? false);
			int num2 = ((Factory == null) ? 1 : 0);
			Request directParent = DirectParent;
			while (!directParent.IsEmpty)
			{
				if (flag)
				{
					if ((directParent.Flags & RequestFlags.StopRecursiveDependencyCheck) != RequestFlags.Default)
					{
						flag = false;
					}
					else if (directParent.FactoryID == factoryID)
					{
						Throw.It(Error.RecursiveDependencyDetected, Print(factoryID));
					}
				}
				if (flag2)
				{
					if (directParent.OpensResolutionScope || (flag3 && directParent.Reuse is SingletonReuse) || (directParent.FactoryType == FactoryType.Wrapper && directParent._actualServiceType.IsFunc()))
					{
						flag2 = false;
					}
					else if (directParent.FactoryType != FactoryType.Wrapper && directParent.ReuseLifespan > num)
					{
						Throw.It(Error.DependencyHasShorterReuseLifespan, PrintCurrent(), reuse, directParent);
					}
				}
				if (reuse2 == null)
				{
					if (directParent.FactoryType != FactoryType.Wrapper)
					{
						if (directParent.Reuse != DryIoc.Reuse.Transient)
						{
							reuse2 = directParent.Reuse;
						}
					}
					else if (directParent._actualServiceType.IsFunc())
					{
						reuse2 = Rules.DefaultReuse;
					}
				}
				directParent.DependencyCount += num2;
				directParent = directParent.DirectParent;
			}
			if (reuse == null)
			{
				reuse = reuse2 ?? Rules.DefaultReuse;
			}
		}
		if (reuse == DryIoc.Reuse.Singleton)
		{
			requestFlags |= RequestFlags.IsSingletonOrDependencyOfSingleton;
		}
		else if (reuse == DryIoc.Reuse.Transient && !setup.PreventDisposal && (setup.TrackDisposableTransient || (!setup.AllowDisposableTransient && Rules.TrackingDisposableTransients)) && typeof(IDisposable).IsAssignableFrom(factory.ImplementationType ?? _actualServiceType))
		{
			if (reuse2 != null)
			{
				reuse = reuse2;
				requestFlags |= RequestFlags.TracksTransientDisposable;
			}
			else if (!IsWrappedInFunc())
			{
				reuse = DryIoc.Reuse.ScopedOrSingleton;
				requestFlags |= RequestFlags.TracksTransientDisposable;
			}
		}
		if (copyRequest)
		{
			IsolateRequestChain();
			return new Request(Container, DirectParent, DependencyDepth, DependencyCount, null, requestFlags, ServiceTypeOrInfo, _actualServiceType, InputArgExprs, factory, factoryID, factory.FactoryType, reuse, decoratedFactoryID);
		}
		Flags = requestFlags;
		SetResolvedFactory(factory, factoryID, factory.FactoryType, reuse, decoratedFactoryID);
		return this;
	}

	public bool HasRecursiveParent(int factoryID)
	{
		Request directParent = DirectParent;
		while (!directParent.IsEmpty && (directParent.Flags & RequestFlags.StopRecursiveDependencyCheck) == 0)
		{
			if (directParent.FactoryID == factoryID)
			{
				return true;
			}
			directParent = directParent.DirectParent;
		}
		return false;
	}

	public bool HasRecursiveParentUntilResolutionRoot(int factoryID)
	{
		Request directParent = DirectParent;
		while (!directParent.IsEmpty)
		{
			if (directParent.FactoryID == factoryID)
			{
				return true;
			}
			directParent = directParent.DirectParent;
		}
		return false;
	}

	public TResult Is<TResult>(Func<TResult> root = null, Func<ParameterInfo, TResult> parameter = null, Func<PropertyInfo, TResult> property = null, Func<FieldInfo, TResult> field = null)
	{
		object serviceTypeOrInfo = ServiceTypeOrInfo;
		if (serviceTypeOrInfo is ParameterServiceInfo parameterServiceInfo)
		{
			if (parameter != null)
			{
				return parameter(parameterServiceInfo.Parameter);
			}
		}
		else if (serviceTypeOrInfo is PropertyOrFieldServiceInfo propertyOrFieldServiceInfo)
		{
			if (propertyOrFieldServiceInfo.Member is PropertyInfo arg)
			{
				if (property != null)
				{
					return property(arg);
				}
			}
			else if (field != null)
			{
				return field((FieldInfo)propertyOrFieldServiceInfo.Member);
			}
		}
		else if (root != null)
		{
			return root();
		}
		return default(TResult);
	}

	public IEnumerator<Request> GetEnumerator()
	{
		Request r = this;
		while (!r.IsEmpty)
		{
			yield return r;
			r = r.DirectParent;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public StringBuilder PrintCurrent(StringBuilder s = null)
	{
		s = s ?? new StringBuilder();
		if (IsEmpty)
		{
			return s.Append("<empty request>");
		}
		bool flag = false;
		if (flag = IsNestedResolutionCall)
		{
			s.Append("resolution call dependency ");
		}
		else if (flag = IsResolutionRoot)
		{
			s.Append("resolution root ");
		}
		if (FactoryID != 0)
		{
			if (Reuse != DryIoc.Reuse.Transient)
			{
				s.Append((Reuse is SingletonReuse) ? "Singleton" : "Scoped").Append(' ');
			}
			if (FactoryType != FactoryType.Service)
			{
				s.Append(FactoryType.ToString().ToLower()).Append(' ');
			}
			Type implementationType = ImplementationType;
			if (implementationType != null && implementationType != ServiceType)
			{
				s.Print(implementationType).Append(": ");
			}
		}
		if (ServiceTypeOrInfo is ParameterInfo parameter)
		{
			s.Append(ParameterServiceInfo.Of(parameter));
		}
		else if (ServiceTypeOrInfo is Type type)
		{
			s.Print(type);
		}
		else
		{
			s.Append(ServiceTypeOrInfo);
		}
		Factory factory = Factory;
		if (factory != null && !(factory is ReflectionFactory))
		{
			s.Append(' ').Append(factory.GetType().Name).Append(' ');
		}
		if (FactoryID != 0)
		{
			s.Append(" FactoryId=").Append(FactoryID);
		}
		if (DecoratedFactoryID != 0)
		{
			s.Append(" decorating FactoryId=").Append(DecoratedFactoryID);
		}
		if (!InputArgExprs.IsNullOrEmpty())
		{
			StringBuilder stringBuilder = s;
			object[] inputArgExprs = InputArgExprs;
			stringBuilder.AppendFormat(" with passed arguments [{0}]", inputArgExprs);
		}
		RequestFlags requestFlags = Flags;
		if (flag)
		{
			requestFlags &= ~RequestFlags.IsResolutionCall;
		}
		if (requestFlags != RequestFlags.Default)
		{
			s.Append(" (").Append(Flags).Append(')');
		}
		return s;
	}

	public StringBuilder Print(int recursiveFactoryID = 0)
	{
		if (IsEmpty)
		{
			return new StringBuilder("<empty request>");
		}
		StringBuilder stringBuilder = PrintCurrent(new StringBuilder());
		stringBuilder = ((recursiveFactoryID == 0) ? stringBuilder : stringBuilder.Append(" <--recursive"));
		foreach (Request item in DirectParent)
		{
			stringBuilder = item.PrintCurrent(stringBuilder.AppendLine().Append("  in "));
			if (item.FactoryID == recursiveFactoryID)
			{
				stringBuilder = stringBuilder.Append(" <--recursive");
			}
		}
		if (Container != null)
		{
			stringBuilder.AppendLine().Append("  from ").Append(Container);
		}
		return stringBuilder;
	}

	public override string ToString()
	{
		return Print().ToString();
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as Request);
	}

	public bool Equals(Request other)
	{
		if (other != null && EqualsWithoutParent(other))
		{
			if (DirectParent != null || other.DirectParent != null)
			{
				if (DirectParent != null)
				{
					return DirectParent.EqualsWithoutParent(other.DirectParent);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public bool EqualsWithoutParent(Request other)
	{
		if (other.ServiceType == ServiceType && other.FactoryType == FactoryType && other.ImplementationType == ImplementationType && other.GetServiceDetails().Equals(GetServiceDetails()) && other.Reuse?.GetType() == Reuse?.GetType() && other.Reuse?.Lifespan == Reuse?.Lifespan)
		{
			return object.Equals(other.Reuse?.Name, Reuse?.Name);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	private Request(IContainer container, Request parent, int dependencyDepth, int dependencyCount, RequestStack stack, RequestFlags flags, object serviceInfo, Type actualServiceType, Expression[] inputArgExprs)
	{
		DirectParent = parent;
		RequestStack = stack;
		ServiceTypeOrInfo = serviceInfo;
		_actualServiceType = actualServiceType;
		InputArgExprs = inputArgExprs;
		Container = container;
		DependencyCount = dependencyCount;
		DependencyDepth = dependencyDepth;
		Flags = flags;
	}

	private Request(IContainer container, Request parent, int dependencyDepth, int dependencyCount, RequestStack stack, RequestFlags flags, object serviceInfo, Type actualServiceType, Expression[] inputArgExprs, object factoryOrImplType, int factoryID, FactoryType factoryType, IReuse reuse, int decoratedFactoryID)
		: this(container, parent, dependencyDepth, dependencyCount, stack, flags, serviceInfo, actualServiceType, inputArgExprs)
	{
		SetResolvedFactory(factoryOrImplType, factoryID, factoryType, reuse, decoratedFactoryID);
	}

	internal Request IsolateRequestChain()
	{
		Request request = null;
		do
		{
			request = ((request == null) ? this : request.DirectParent);
			if (request.RequestStack != null)
			{
				request.RequestStack.Requests[request.DependencyDepth - 1] = null;
				request.RequestStack = null;
			}
		}
		while ((request.Flags & RequestFlags.IsResolutionCall) == 0 && !request.DirectParent.IsEmpty);
		return this;
	}

	private void SetServiceInfo(IContainer container, Request parent, int dependencyDepth, int dependencyCount, RequestStack stack, RequestFlags flags, object serviceTypeOrInfo, Type actualServiceType, Expression[] inputArgExprs)
	{
		DirectParent = parent;
		RequestStack = stack;
		ServiceTypeOrInfo = serviceTypeOrInfo;
		_actualServiceType = actualServiceType;
		InputArgExprs = inputArgExprs;
		Container = container;
		DependencyDepth = dependencyDepth;
		DependencyCount = dependencyCount;
		Flags = flags;
		_factoryOrImplType = null;
		SelectedConstructor = null;
		Reuse = null;
		FactoryID = 0;
		DecoratedFactoryID = 0;
		_hashCode = parent?._hashCode ?? 0;
		FactoryType = FactoryType.Service;
	}

	private void SetResolvedFactory(object factoryOrImplType, int factoryID, FactoryType factoryType, IReuse reuse, int decoratedFactoryID)
	{
		_factoryOrImplType = factoryOrImplType;
		SelectedConstructor = null;
		FactoryID = factoryID;
		FactoryType = factoryType;
		Reuse = reuse;
		DecoratedFactoryID = decoratedFactoryID;
		_hashCode = ((DirectParent == null) ? FactoryID : Hasher.Combine(DirectParent._hashCode, FactoryID));
	}
}
