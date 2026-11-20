using System;
using System.Collections.Generic;

namespace DryIoc;

public abstract class Setup
{
	[Flags]
	public enum Settings : ushort
	{
		Default = 0,
		AsResolutionCall = 2,
		OpenResolutionScope = 4,
		PreventDisposal = 8,
		WeaklyReferenced = 0x10,
		AllowDisposableTransient = 0x20,
		TrackDisposableTransient = 0x40,
		AsResolutionRoot = 0x80,
		UseParentReuse = 0x100,
		PreferInSingleServiceResolve = 0x200,
		AsResolutionCallForExpressionGeneration = 0x400,
		AvoidResolutionScopeTracking = 0x800
	}

	internal sealed class ServiceSetup : Setup
	{
		private object _metadataOrFuncOfMetadata;

		public override FactoryType FactoryType => FactoryType.Service;

		public override object Metadata
		{
			get
			{
				if (!(_metadataOrFuncOfMetadata is Func<object> func))
				{
					return _metadataOrFuncOfMetadata;
				}
				return _metadataOrFuncOfMetadata = func();
			}
		}

		public ServiceSetup()
		{
		}

		public ServiceSetup(Func<Request, bool> condition = null, object metadataOrFuncOfMetadata = null, bool openResolutionScope = false, bool asResolutionCall = false, bool asResolutionRoot = false, bool preventDisposal = false, bool weaklyReferenced = false, bool allowDisposableTransient = false, bool trackDisposableTransient = false, bool useParentReuse = false, int disposalOrder = 0, bool preferOverMultipleResolved = false, bool asResolutionCallForExpressionGeneration = false, bool avoidResolutionScopeTracking = false)
			: base(condition, openResolutionScope, asResolutionCall, asResolutionRoot, preventDisposal, weaklyReferenced, allowDisposableTransient, trackDisposableTransient, useParentReuse, disposalOrder, preferOverMultipleResolved, asResolutionCallForExpressionGeneration, avoidResolutionScopeTracking)
		{
			_metadataOrFuncOfMetadata = metadataOrFuncOfMetadata;
		}
	}

	internal sealed class WrapperSetup : Setup
	{
		public readonly int WrappedServiceTypeArgIndex;

		public readonly bool AlwaysWrapsRequiredServiceType;

		public readonly Func<Type, Type> Unwrap;

		public override FactoryType FactoryType => FactoryType.Wrapper;

		public WrapperSetup(int wrappedServiceTypeArgIndex = -1)
		{
			WrappedServiceTypeArgIndex = wrappedServiceTypeArgIndex;
		}

		public WrapperSetup(int wrappedServiceTypeArgIndex, bool alwaysWrapsRequiredServiceType, Func<Type, Type> unwrap, Func<Request, bool> condition, bool openResolutionScope, bool asResolutionCall, bool preventDisposal, bool weaklyReferenced, bool allowDisposableTransient, bool trackDisposableTransient, bool useParentReuse, int disposalOrder, bool avoidResolutionScopeTracking)
			: base(condition, openResolutionScope, asResolutionCall, asResolutionRoot: false, preventDisposal, weaklyReferenced, allowDisposableTransient, trackDisposableTransient, useParentReuse, disposalOrder, preferOverMultipleResolved: false, asResolutionCallForExpressionGeneration: false, avoidResolutionScopeTracking)
		{
			WrappedServiceTypeArgIndex = wrappedServiceTypeArgIndex;
			AlwaysWrapsRequiredServiceType = alwaysWrapsRequiredServiceType;
			Unwrap = unwrap;
		}

		internal bool ValidateWrapperRegistration(Type serviceType, bool throwIfInvalid)
		{
			if (AlwaysWrapsRequiredServiceType || Unwrap != null || !serviceType.IsGenericType)
			{
				return true;
			}
			int num = serviceType.GetGenericArguments().Length;
			int wrappedServiceTypeArgIndex = WrappedServiceTypeArgIndex;
			if (num > 1 && wrappedServiceTypeArgIndex == -1)
			{
				return Throw.When(throwIfInvalid, Error.GenericWrapperWithMultipleTypeArgsShouldSpecifyArgIndex, serviceType);
			}
			int num2 = ((wrappedServiceTypeArgIndex != -1) ? wrappedServiceTypeArgIndex : 0);
			if (num2 > num - 1)
			{
				return Throw.When(throwIfInvalid, Error.GenericWrapperTypeArgIndexOutOfBounds, serviceType, num2);
			}
			return true;
		}

		public Type GetWrappedTypeOrNullIfWrapsRequired(Type serviceType)
		{
			if (Unwrap != null)
			{
				return Unwrap(serviceType);
			}
			if (AlwaysWrapsRequiredServiceType || !serviceType.IsGenericType)
			{
				return null;
			}
			Type[] genericArguments = serviceType.GetGenericArguments();
			int wrappedServiceTypeArgIndex = WrappedServiceTypeArgIndex;
			serviceType.ThrowIf(genericArguments.Length > 1 && wrappedServiceTypeArgIndex == -1, Error.GenericWrapperWithMultipleTypeArgsShouldSpecifyArgIndex);
			wrappedServiceTypeArgIndex = ((wrappedServiceTypeArgIndex != -1) ? wrappedServiceTypeArgIndex : 0);
			serviceType.ThrowIf(wrappedServiceTypeArgIndex > genericArguments.Length - 1, Error.GenericWrapperTypeArgIndexOutOfBounds, wrappedServiceTypeArgIndex);
			return genericArguments[wrappedServiceTypeArgIndex];
		}
	}

	internal sealed class DecoratorSetup : Setup
	{
		public readonly int Order;

		public readonly bool UseDecorateeReuse;

		public override FactoryType FactoryType => FactoryType.Decorator;

		public DecoratorSetup()
		{
		}

		public DecoratorSetup(Func<Request, bool> condition, int order, bool useDecorateeReuse, bool openResolutionScope = false, bool asResolutionCall = false, bool preventDisposal = false, bool weaklyReferenced = false, bool allowDisposableTransient = false, bool trackDisposableTransient = false, int disposalOrder = 0, bool avoidResolutionScopeTracking = false)
			: base(condition, openResolutionScope, asResolutionCall, asResolutionRoot: false, preventDisposal, weaklyReferenced, allowDisposableTransient, trackDisposableTransient, useParentReuse: false, disposalOrder, preferOverMultipleResolved: false, asResolutionCallForExpressionGeneration: false, avoidResolutionScopeTracking)
		{
			Order = order;
			UseDecorateeReuse = useDecorateeReuse;
		}
	}

	public static readonly Setup AsResolutionCallSetup = new ServiceSetup
	{
		_settings = Settings.AsResolutionCall
	};

	internal static readonly Setup AsResolutionCallForGeneratedExpressionSetup = new ServiceSetup
	{
		_settings = Settings.AsResolutionCallForExpressionGeneration
	};

	private Settings _settings;

	public static readonly Setup Default = new ServiceSetup();

	public static readonly Setup Wrapper = new WrapperSetup();

	public static readonly Setup Decorator = new DecoratorSetup();

	public abstract FactoryType FactoryType { get; }

	public Func<Request, bool> Condition { get; }

	public int DisposalOrder { get; }

	public virtual object Metadata => null;

	public bool AsResolutionCall => (_settings & Settings.AsResolutionCall) != 0;

	public bool AsResolutionCallForExpressionGeneration => (_settings & Settings.AsResolutionCallForExpressionGeneration) != 0;

	public bool AsResolutionRoot => (_settings & Settings.AsResolutionRoot) != 0;

	public bool OpenResolutionScope => (_settings & Settings.OpenResolutionScope) != 0;

	public bool WeaklyReferenced => (_settings & Settings.WeaklyReferenced) != 0;

	public bool AllowDisposableTransient => (_settings & Settings.AllowDisposableTransient) != 0;

	public bool TrackDisposableTransient => (_settings & Settings.TrackDisposableTransient) != 0;

	public bool UseParentReuse => (_settings & Settings.UseParentReuse) != 0;

	public bool PreventDisposal => (_settings & Settings.PreventDisposal) != 0;

	public bool PreferInSingleServiceResolve => (_settings & Settings.PreferInSingleServiceResolve) != 0;

	public bool AvoidResolutionScopeTracking => (_settings & Settings.AvoidResolutionScopeTracking) != 0;

	public bool MatchesMetadata(string metadataKey, object metadata)
	{
		if (metadataKey == null)
		{
			return object.Equals(metadata, Metadata);
		}
		if (Metadata is IDictionary<string, object> dictionary && dictionary.TryGetValue(metadataKey, out var value))
		{
			return object.Equals(value, metadata);
		}
		return false;
	}

	public object GetMetadataValueMatchedByMetadataType(Type metadataType)
	{
		object metadata = Metadata;
		if (metadataType != typeof(object) && metadata is IDictionary<string, object> dictionary && metadataType != typeof(IDictionary<string, object>))
		{
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				metadata = item.Value;
				if (metadataType.IsTypeOf(metadata))
				{
					return metadata;
				}
			}
			return null;
		}
		return metadata;
	}

	internal Setup WithAsResolutionCallForGeneratedExpression()
	{
		if (AsResolutionCallForExpressionGeneration)
		{
			return this;
		}
		if (this == Default)
		{
			return AsResolutionCallForGeneratedExpressionSetup;
		}
		Setup setup = (Setup)MemberwiseClone();
		setup._settings |= Settings.AsResolutionCallForExpressionGeneration;
		return setup;
	}

	private Setup()
	{
	}

	private Setup(Func<Request, bool> condition, bool openResolutionScope, bool asResolutionCall, bool asResolutionRoot, bool preventDisposal, bool weaklyReferenced, bool allowDisposableTransient, bool trackDisposableTransient, bool useParentReuse, int disposalOrder, bool preferOverMultipleResolved = false, bool asResolutionCallForExpressionGeneration = false, bool avoidResolutionScopeTracking = false)
	{
		Condition = condition;
		DisposalOrder = disposalOrder;
		if (asResolutionCall)
		{
			_settings |= Settings.AsResolutionCall;
		}
		if (openResolutionScope)
		{
			_settings |= Settings.OpenResolutionScope;
			_settings |= Settings.AsResolutionCall;
			if (avoidResolutionScopeTracking)
			{
				_settings |= Settings.AvoidResolutionScopeTracking;
			}
		}
		if (preventDisposal)
		{
			_settings |= Settings.PreventDisposal;
		}
		if (weaklyReferenced)
		{
			_settings |= Settings.WeaklyReferenced;
		}
		if (allowDisposableTransient)
		{
			_settings |= Settings.AllowDisposableTransient;
		}
		if (trackDisposableTransient)
		{
			_settings |= Settings.TrackDisposableTransient;
			_settings |= Settings.AllowDisposableTransient;
		}
		if (asResolutionRoot)
		{
			_settings |= Settings.AsResolutionRoot;
		}
		if (useParentReuse)
		{
			_settings |= Settings.UseParentReuse;
		}
		if (preferOverMultipleResolved)
		{
			_settings |= Settings.PreferInSingleServiceResolve;
		}
		if (asResolutionCallForExpressionGeneration)
		{
			_settings |= Settings.AsResolutionCallForExpressionGeneration;
		}
	}

	public static Setup With(object metadataOrFuncOfMetadata = null, Func<Request, bool> condition = null, bool openResolutionScope = false, bool asResolutionCall = false, bool asResolutionRoot = false, bool preventDisposal = false, bool weaklyReferenced = false, bool allowDisposableTransient = false, bool trackDisposableTransient = false, bool useParentReuse = false, int disposalOrder = 0, bool preferInSingleServiceResolve = false, bool avoidResolutionScopeTracking = false)
	{
		if (metadataOrFuncOfMetadata == null && condition == null && !openResolutionScope && !asResolutionRoot && !preventDisposal && !weaklyReferenced && !allowDisposableTransient && !trackDisposableTransient && !useParentReuse && disposalOrder == 0 && !preferInSingleServiceResolve && !avoidResolutionScopeTracking)
		{
			if (asResolutionCall)
			{
				return AsResolutionCallSetup;
			}
			return Default;
		}
		return new ServiceSetup(condition, metadataOrFuncOfMetadata, openResolutionScope, asResolutionCall, asResolutionRoot, preventDisposal, weaklyReferenced, allowDisposableTransient, trackDisposableTransient, useParentReuse, disposalOrder, preferInSingleServiceResolve, asResolutionCallForExpressionGeneration: false, avoidResolutionScopeTracking);
	}

	public static Setup WrapperWith(int wrappedServiceTypeArgIndex = -1, bool alwaysWrapsRequiredServiceType = false, Func<Type, Type> unwrap = null, bool openResolutionScope = false, bool asResolutionCall = false, bool preventDisposal = false, bool weaklyReferenced = false, bool allowDisposableTransient = false, bool trackDisposableTransient = false, bool useParentReuse = false, Func<Request, bool> condition = null, int disposalOrder = 0, bool avoidResolutionScopeTracking = false)
	{
		if (wrappedServiceTypeArgIndex != -1 || alwaysWrapsRequiredServiceType || unwrap != null || openResolutionScope || asResolutionCall || preventDisposal || weaklyReferenced || allowDisposableTransient || trackDisposableTransient || condition != null || disposalOrder != 0 || avoidResolutionScopeTracking)
		{
			return new WrapperSetup(wrappedServiceTypeArgIndex, alwaysWrapsRequiredServiceType, unwrap, condition, openResolutionScope, asResolutionCall, preventDisposal, weaklyReferenced, allowDisposableTransient, trackDisposableTransient, useParentReuse, disposalOrder, avoidResolutionScopeTracking);
		}
		return Wrapper;
	}

	public static Setup DecoratorWith(Func<Request, bool> condition = null, int order = 0, bool useDecorateeReuse = false, bool openResolutionScope = false, bool asResolutionCall = false, bool preventDisposal = false, bool weaklyReferenced = false, bool allowDisposableTransient = false, bool trackDisposableTransient = false, int disposalOrder = 0, bool avoidResolutionScopeTracking = false)
	{
		if (condition != null || order != 0 || useDecorateeReuse || openResolutionScope || asResolutionCall || preventDisposal || weaklyReferenced || allowDisposableTransient || trackDisposableTransient || disposalOrder != 0 || avoidResolutionScopeTracking)
		{
			return new DecoratorSetup(condition, order, useDecorateeReuse, openResolutionScope, asResolutionCall, preventDisposal, weaklyReferenced, allowDisposableTransient, trackDisposableTransient, disposalOrder, avoidResolutionScopeTracking);
		}
		return Decorator;
	}

	public static Func<Request, bool> GetDecorateeCondition(Type decorateeType, object decorateeServiceKey = null, Func<Request, bool> condition = null)
	{
		if (decorateeType == null && decorateeServiceKey == null)
		{
			return condition;
		}
		Func<Request, bool> decorateeCondition;
		if (decorateeServiceKey == null)
		{
			decorateeCondition = (Request r) => r.GetKnownImplementationOrServiceType().IsAssignableTo(decorateeType);
		}
		else if (decorateeType == null)
		{
			decorateeCondition = (Request r) => decorateeServiceKey.Equals(r.ServiceKey);
		}
		else
		{
			decorateeCondition = (Request r) => decorateeServiceKey.Equals(r.ServiceKey) && r.GetKnownImplementationOrServiceType().IsAssignableTo(decorateeType);
		}
		if (condition != null)
		{
			return (Request r) => decorateeCondition(r) && condition(r);
		}
		return decorateeCondition;
	}

	public static Setup DecoratorOf(Type decorateeType = null, int order = 0, bool useDecorateeReuse = false, bool openResolutionScope = false, bool asResolutionCall = false, bool preventDisposal = false, bool weaklyReferenced = false, bool allowDisposableTransient = false, bool trackDisposableTransient = false, int disposalOrder = 0, object decorateeServiceKey = null)
	{
		return DecoratorWith(GetDecorateeCondition(decorateeType, decorateeServiceKey), order, useDecorateeReuse, openResolutionScope, asResolutionCall, preventDisposal, weaklyReferenced, allowDisposableTransient, trackDisposableTransient, disposalOrder);
	}

	public static Setup DecoratorOf<TDecoratee>(int order = 0, bool useDecorateeReuse = false, bool openResolutionScope = false, bool asResolutionCall = false, bool preventDisposal = false, bool weaklyReferenced = false, bool allowDisposableTransient = false, bool trackDisposableTransient = false, int disposalOrder = 0, object decorateeServiceKey = null)
	{
		return DecoratorOf(typeof(TDecoratee), order, useDecorateeReuse, openResolutionScope, asResolutionCall, preventDisposal, weaklyReferenced, allowDisposableTransient, trackDisposableTransient, disposalOrder, decorateeServiceKey);
	}
}
