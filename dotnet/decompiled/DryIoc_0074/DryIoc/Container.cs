using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;
using Example;

namespace DryIoc;

public class Container : IContainer, IRegistrator, IResolverContext, IResolver, IServiceProvider, IDisposable
{
	public struct ResolveManyResult
	{
		public FactoryDelegate FactoryDelegate;

		public object ServiceKey;

		public Type RequiredServiceType;

		public static ResolveManyResult Of(FactoryDelegate factoryDelegate, object serviceKey = null, Type requiredServiceType = null)
		{
			return new ResolveManyResult
			{
				FactoryDelegate = factoryDelegate,
				ServiceKey = serviceKey,
				RequiredServiceType = requiredServiceType
			};
		}
	}

	internal sealed class FactoriesEntry
	{
		public readonly DefaultKey LastDefaultKey;

		public readonly ImHashMap<object, Factory> Factories;

		public static readonly FactoriesEntry Empty = new FactoriesEntry(null, ImHashMap<object, Factory>.Empty);

		public FactoriesEntry(DefaultKey lastDefaultKey, ImHashMap<object, Factory> factories)
		{
			LastDefaultKey = lastDefaultKey;
			Factories = factories;
		}

		public FactoriesEntry With(Factory factory)
		{
			DefaultKey defaultKey = ((LastDefaultKey == null) ? DefaultKey.Value : LastDefaultKey.Next());
			return new FactoriesEntry(defaultKey, Factories.AddOrUpdate(defaultKey, factory));
		}

		public FactoriesEntry WithTwo(Factory oldFactory, Factory newFactory)
		{
			DefaultKey defaultKey = ((LastDefaultKey == null) ? DefaultKey.Value : LastDefaultKey.Next());
			ImHashMap<object, Factory> factories = Factories.AddOrUpdate(defaultKey, oldFactory).AddOrUpdate(defaultKey = defaultKey.Next(), newFactory);
			return new FactoriesEntry(defaultKey, factories);
		}

		public FactoriesEntry With(Factory factory, object serviceKey)
		{
			return new FactoriesEntry(LastDefaultKey, Factories.AddOrUpdate(serviceKey, factory));
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct LastFactoryIDWinsComparer : IComparer<KV<object, Factory>>
	{
		public int Compare(KV<object, Factory> first, KV<object, Factory> next)
		{
			return (first?.Value.FactoryID ?? 0) - (next?.Value.FactoryID ?? 0);
		}
	}

	internal sealed class ExprCacheOfTransientWithDepCount
	{
		public Expression Expr;

		public int Count;

		public ExprCacheOfTransientWithDepCount(Expression e, int n)
		{
			Expr = e;
			Count = n;
		}
	}

	internal sealed class ExprCacheOfScopedWithName
	{
		public Expression Expr;

		public object Name;

		public ExprCacheOfScopedWithName(Expression e, object n)
		{
			Expr = e;
			Name = n;
		}
	}

	internal class Registry : ImHashMap<Type, object>
	{
		public sealed class Compiling
		{
			public readonly Expression Expression;

			public Compiling(Expression expression)
			{
				Expression = expression;
			}
		}

		internal sealed class KeyedFactoryCacheEntry
		{
			public readonly KeyedFactoryCacheEntry Rest;

			public readonly object Key;

			public object Factory;

			public KeyedFactoryCacheEntry(KeyedFactoryCacheEntry rest, object key, object factory)
			{
				Rest = rest;
				Key = key;
				Factory = factory;
			}
		}

		internal sealed class AndWrappersAndDecorators : Registry
		{
			private readonly ImHashMap<Type, object> _wrappers;

			private readonly ImHashMap<Type, object> _decorators;

			public override ImHashMap<Type, object> Wrappers => _wrappers;

			public override ImHashMap<Type, object> Decorators => _decorators;

			public AndWrappersAndDecorators(ImHashMap<Type, object> services, ImHashMap<Type, object> wrappers, ImHashMap<Type, object> decorators)
				: base(services)
			{
				_wrappers = wrappers;
				_decorators = decorators;
			}

			public override Registry WithDefaultFactoryCache()
			{
				return new AndCache.CacheAndWrappersAndDecorators(Services, _wrappers, _decorators, new ImHashMap<Type, object>[16], null, null, IsRegistryChangePermitted.Permitted);
			}

			public override Registry WithKeyedFactoryCache()
			{
				return new AndCache.CacheAndWrappersAndDecorators(Services, _wrappers, _decorators, null, new ImHashMap<Type, object>[16], null, IsRegistryChangePermitted.Permitted);
			}

			public override Registry WithFactoryExpressionCache()
			{
				return new AndCache.CacheAndWrappersAndDecorators(Services, _wrappers, _decorators, null, null, new ImMap<object>[16], IsChangePermitted);
			}

			public override Registry WithIsChangePermitted(IsRegistryChangePermitted isChangePermitted)
			{
				return new AndCache.CacheAndWrappersAndDecorators(Services, _wrappers, _decorators, null, null, null, isChangePermitted);
			}

			internal override Registry WithServices(ImHashMap<Type, object> services)
			{
				if (services != Services)
				{
					return new AndWrappersAndDecorators(services, _wrappers, _decorators);
				}
				return this;
			}

			internal override Registry WithWrappers(ImHashMap<Type, object> wrappers)
			{
				if (wrappers != _wrappers)
				{
					return new AndWrappersAndDecorators(Services, wrappers, _decorators);
				}
				return this;
			}

			internal override Registry WithDecorators(ImHashMap<Type, object> decorators)
			{
				if (decorators != _decorators)
				{
					return new AndWrappersAndDecorators(Services, _wrappers, decorators);
				}
				return this;
			}
		}

		internal class AndCache : Registry
		{
			internal sealed class CacheAndWrappersAndDecorators : AndCache
			{
				private readonly ImHashMap<Type, object> _wrappers;

				private readonly ImHashMap<Type, object> _decorators;

				public override ImHashMap<Type, object> Wrappers => _wrappers;

				public override ImHashMap<Type, object> Decorators => _decorators;

				internal CacheAndWrappersAndDecorators(ImHashMap<Type, object> services, ImHashMap<Type, object> wrappers, ImHashMap<Type, object> decorators, ImHashMap<Type, object>[] defaultFactoryCache, ImHashMap<Type, object>[] keyedFactoryCache, ImMap<object>[] factoryExpressionCache, IsRegistryChangePermitted isChangePermitted)
					: base(services, defaultFactoryCache, keyedFactoryCache, factoryExpressionCache, isChangePermitted)
				{
					_wrappers = wrappers;
					_decorators = decorators;
				}

				public override Registry WithoutCache()
				{
					if (_isChangePermitted != IsRegistryChangePermitted.Permitted)
					{
						return new CacheAndWrappersAndDecorators(Services, _wrappers, _decorators, null, null, null, _isChangePermitted);
					}
					return new AndWrappersAndDecorators(Services, _wrappers, _decorators);
				}

				internal override Registry WithServices(ImHashMap<Type, object> services)
				{
					if (services != Services)
					{
						return new CacheAndWrappersAndDecorators(services, _wrappers, _decorators, _defaultFactoryCache?.CopyNonEmpty(), _keyedFactoryCache?.CopyNonEmpty(), _factoryExpressionCache?.CopyNonEmpty(), _isChangePermitted);
					}
					return this;
				}

				internal override Registry WithWrappers(ImHashMap<Type, object> wrappers)
				{
					if (wrappers != _wrappers)
					{
						return new CacheAndWrappersAndDecorators(Services, wrappers, _decorators, _defaultFactoryCache?.CopyNonEmpty(), _keyedFactoryCache?.CopyNonEmpty(), _factoryExpressionCache?.CopyNonEmpty(), _isChangePermitted);
					}
					return this;
				}

				internal override Registry WithDecorators(ImHashMap<Type, object> decorators)
				{
					if (decorators != _decorators)
					{
						return new CacheAndWrappersAndDecorators(Services, _wrappers, decorators, _defaultFactoryCache?.CopyNonEmpty(), _keyedFactoryCache?.CopyNonEmpty(), _factoryExpressionCache?.CopyNonEmpty(), _isChangePermitted);
					}
					return this;
				}

				public override Registry WithIsChangePermitted(IsRegistryChangePermitted isChangePermitted)
				{
					if (isChangePermitted != _isChangePermitted)
					{
						return new CacheAndWrappersAndDecorators(Services, _wrappers, _decorators, _defaultFactoryCache, _keyedFactoryCache, _factoryExpressionCache, isChangePermitted);
					}
					return this;
				}
			}

			protected ImHashMap<Type, object>[] _defaultFactoryCache;

			protected ImHashMap<Type, object>[] _keyedFactoryCache;

			protected ImMap<object>[] _factoryExpressionCache;

			protected IsRegistryChangePermitted _isChangePermitted;

			public sealed override ImHashMap<Type, object>[] DefaultFactoryCache => _defaultFactoryCache;

			public sealed override ImHashMap<Type, object>[] KeyedFactoryCache => _keyedFactoryCache;

			public sealed override ImMap<object>[] FactoryExpressionCache => _factoryExpressionCache;

			internal sealed override IsRegistryChangePermitted IsChangePermitted => _isChangePermitted;

			internal AndCache(ImHashMap<Type, object> services, IsRegistryChangePermitted isChangePermitted)
				: base(services)
			{
				_isChangePermitted = isChangePermitted;
			}

			internal AndCache(ImHashMap<Type, object> services, ImHashMap<Type, object>[] defaultFactoryCache, ImHashMap<Type, object>[] keyedFactoryCache, ImMap<object>[] factoryExpressionCache, IsRegistryChangePermitted isChangePermitted)
				: base(services)
			{
				_defaultFactoryCache = defaultFactoryCache;
				_keyedFactoryCache = keyedFactoryCache;
				_factoryExpressionCache = factoryExpressionCache;
				_isChangePermitted = isChangePermitted;
			}

			public override Registry WithoutCache()
			{
				if (_isChangePermitted != IsRegistryChangePermitted.Permitted)
				{
					return new AndCache(Services, null, null, null, _isChangePermitted);
				}
				return new Registry(Services);
			}

			internal override Registry WithServices(ImHashMap<Type, object> services)
			{
				if (services != Services)
				{
					return new AndCache(services, _defaultFactoryCache?.CopyNonEmpty(), _keyedFactoryCache?.CopyNonEmpty(), _factoryExpressionCache?.CopyNonEmpty(), _isChangePermitted);
				}
				return this;
			}

			internal override Registry WithWrappers(ImHashMap<Type, object> wrappers)
			{
				if (wrappers != ImHashMap<Type, object>.Empty)
				{
					return new CacheAndWrappersAndDecorators(Services, wrappers, Decorators, _defaultFactoryCache?.CopyNonEmpty(), _keyedFactoryCache?.CopyNonEmpty(), _factoryExpressionCache?.CopyNonEmpty(), _isChangePermitted);
				}
				return this;
			}

			internal override Registry WithDecorators(ImHashMap<Type, object> decorators)
			{
				if (decorators != ImHashMap<Type, object>.Empty)
				{
					return new CacheAndWrappersAndDecorators(Services, Wrappers, decorators, _defaultFactoryCache?.CopyNonEmpty(), _keyedFactoryCache?.CopyNonEmpty(), _factoryExpressionCache?.CopyNonEmpty(), _isChangePermitted);
				}
				return this;
			}

			public override Registry WithIsChangePermitted(IsRegistryChangePermitted isChangePermitted)
			{
				if (isChangePermitted != _isChangePermitted)
				{
					return new AndCache(Services, _defaultFactoryCache, _keyedFactoryCache, _factoryExpressionCache, isChangePermitted);
				}
				return this;
			}

			public override Registry WithDefaultFactoryCache()
			{
				if (_defaultFactoryCache != null)
				{
					Interlocked.CompareExchange(ref _defaultFactoryCache, new ImHashMap<Type, object>[16], null);
				}
				return this;
			}

			public override Registry WithKeyedFactoryCache()
			{
				if (_keyedFactoryCache != null)
				{
					Interlocked.CompareExchange(ref _keyedFactoryCache, new ImHashMap<Type, object>[16], null);
				}
				return this;
			}

			public override Registry WithFactoryExpressionCache()
			{
				if (_factoryExpressionCache != null)
				{
					Interlocked.CompareExchange(ref _factoryExpressionCache, new ImMap<object>[16], null);
				}
				return this;
			}

			public void TryCacheDefaultFactory<T>(int serviceTypeHash, Type serviceType, T factory)
			{
				if (_defaultFactoryCache == null)
				{
					Interlocked.CompareExchange(ref _defaultFactoryCache, new ImHashMap<Type, object>[16], null);
				}
				ref ImHashMap<Type, object> reference = ref _defaultFactoryCache[serviceTypeHash & 0xF];
				if (reference == null)
				{
					Interlocked.CompareExchange(ref reference, ImHashMap<Type, object>.Empty, null);
				}
				ImHashMap<Type, object> imHashMap = reference;
				if (Interlocked.CompareExchange(ref reference, imHashMap.AddOrUpdate(serviceTypeHash, serviceType, factory), imHashMap) != imHashMap)
				{
					Ref.Swap(ref reference, serviceTypeHash, serviceType, factory, (ImHashMap<Type, object> x, int h, Type t, T f) => x.AddOrUpdate(h, t, f));
				}
			}

			public void TryCacheKeyedFactory(int serviceTypeHash, Type serviceType, object key, object factory)
			{
				if (_keyedFactoryCache == null)
				{
					Interlocked.CompareExchange(ref _keyedFactoryCache, new ImHashMap<Type, object>[16], null);
				}
				ref ImHashMap<Type, object> reference = ref _keyedFactoryCache[serviceTypeHash & 0xF];
				if (reference == null)
				{
					Interlocked.CompareExchange(ref reference, ImHashMap<Type, object>.Empty, null);
				}
				ImHashMapEntry<Type, object> imHashMapEntry = reference.GetEntryOrDefaultByReferenceEquals(serviceTypeHash, serviceType);
				if (imHashMapEntry == null)
				{
					imHashMapEntry = new ImHashMapEntry<Type, object>(serviceTypeHash, serviceType);
					ImHashMap<Type, object> imHashMap = reference;
					ImHashMap<Type, object> imHashMap2 = imHashMap.AddOrKeepEntry(imHashMapEntry);
					if (Interlocked.CompareExchange(ref reference, imHashMap2, imHashMap) == imHashMap)
					{
						if (imHashMap2 == imHashMap)
						{
							imHashMapEntry = reference.GetEntryOrDefaultByReferenceEquals(serviceTypeHash, serviceType);
						}
					}
					else
					{
						imHashMapEntry = Ref.SwapAndGetNewValue(ref reference, imHashMapEntry, (ImHashMap<Type, object> x, ImHashMapEntry<Type, object> en) => x.AddOrKeepEntry(en)).GetEntryOrDefaultByReferenceEquals(serviceTypeHash, serviceType);
					}
				}
				object value = imHashMapEntry.Value;
				if (Interlocked.CompareExchange(ref imHashMapEntry.Value, SetOrAddKeyedCacheFactory(value, key, factory), value) != value)
				{
					Ref.Swap(ref imHashMapEntry.Value, key, factory, base.SetOrAddKeyedCacheFactory);
				}
			}

			internal void CacheFactoryExpression(int factoryId, Expression expr, IReuse reuse, int dependencyCount, ImMapEntry<object> entry)
			{
				if (entry == null)
				{
					if (_factoryExpressionCache == null)
					{
						Interlocked.CompareExchange(ref _factoryExpressionCache, new ImMap<object>[16], null);
					}
					ref ImMap<object> reference = ref _factoryExpressionCache[factoryId & 0xF];
					if (reference == null)
					{
						Interlocked.CompareExchange(ref reference, ImMap<object>.Empty, null);
					}
					entry = reference.GetEntryOrDefault(factoryId);
					if (entry == null)
					{
						entry = new ImMapEntry<object>(factoryId);
						ImMap<object> imMap = reference;
						ImMap<object> imMap2 = imMap.AddOrKeepEntry(entry);
						if (Interlocked.CompareExchange(ref reference, imMap2, imMap) == imMap)
						{
							if (imMap2 == imMap)
							{
								entry = reference.GetEntryOrDefault(factoryId);
							}
						}
						else
						{
							entry = Ref.SwapAndGetNewValue(ref reference, entry, (ImMap<object> x, ImMapEntry<object> e) => x.AddOrKeepEntry(e)).GetEntryOrDefault(factoryId);
						}
					}
				}
				if (reuse == Reuse.Transient)
				{
					entry.Value = new ExprCacheOfTransientWithDepCount(expr, dependencyCount);
				}
				else if (reuse is CurrentScopeReuse currentScopeReuse)
				{
					entry.Value = ((currentScopeReuse.Name == null) ? ((object)expr) : ((object)new ExprCacheOfScopedWithName(expr, currentScopeReuse.Name)));
				}
				else
				{
					entry.Value = expr;
				}
			}

			internal override void DropFactoryCache(Factory factory, int hash, Type serviceType, object serviceKey = null)
			{
				if (factory == null)
				{
					return;
				}
				if (_defaultFactoryCache != null || _keyedFactoryCache != null)
				{
					if (factory.GeneratedFactories == null)
					{
						ImHashMap<Type, object>[] defaultFactoryCache = _defaultFactoryCache;
						if (defaultFactoryCache != null)
						{
							Ref.Swap(ref defaultFactoryCache[hash & 0xF], hash, serviceType, (ImHashMap<Type, object> x, int h, Type t) => (x ?? ImHashMap<Type, object>.Empty).UpdateToDefault(h, t));
						}
						ImHashMap<Type, object>[] keyedFactoryCache = _keyedFactoryCache;
						if (keyedFactoryCache != null)
						{
							Ref.Swap(ref keyedFactoryCache[hash & 0xF], hash, serviceType, (ImHashMap<Type, object> x, int h, Type t) => (x ?? ImHashMap<Type, object>.Empty).UpdateToDefault(h, t));
						}
					}
					else
					{
						_defaultFactoryCache = null;
						_keyedFactoryCache = null;
					}
				}
				if (_factoryExpressionCache == null)
				{
					return;
				}
				ImMap<object>[] factoryExpressionCache = _factoryExpressionCache;
				if (factoryExpressionCache != null)
				{
					int factoryID = factory.FactoryID;
					Ref.Swap(ref factoryExpressionCache[factoryID & 0xF], factoryID, (ImMap<object> x, int i) => (x ?? ImMap<object>.Empty).UpdateToDefault(i));
				}
			}
		}

		public static readonly ImHashMap<Type, object> Default = ImHashMap<Type, object>.Empty;

		public readonly ImHashMap<Type, object> Services;

		internal const int CACHE_SLOT_COUNT = 16;

		internal const int CACHE_SLOT_COUNT_MASK = 15;

		public virtual ImHashMap<Type, object> Wrappers => WrappersSupport.Wrappers;

		public virtual ImHashMap<Type, object> Decorators => ImHashMap<Type, object>.Empty;

		public virtual ImHashMap<Type, object>[] DefaultFactoryCache => null;

		public virtual ImHashMap<Type, object>[] KeyedFactoryCache => null;

		public virtual ImMap<object>[] FactoryExpressionCache => null;

		internal virtual IsRegistryChangePermitted IsChangePermitted => IsRegistryChangePermitted.Permitted;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ImHashMapEntry<Type, object> GetCachedDefaultFactoryOrDefault(ImHashMap<Type, object> rs, int serviceTypeHash, Type serviceType)
		{
			Registry obj = rs as Registry;
			if (obj == null)
			{
				return null;
			}
			ImHashMap<Type, object>[] defaultFactoryCache = obj.DefaultFactoryCache;
			if (defaultFactoryCache == null)
			{
				return null;
			}
			return defaultFactoryCache[serviceTypeHash & 0xF]?.GetEntryOrDefaultByReferenceEquals(serviceTypeHash, serviceType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool GetCachedKeyedFactoryOrDefault(ImHashMap<Type, object> rs, int serviceTypeHash, Type serviceType, object key, out KeyedFactoryCacheEntry result)
		{
			result = null;
			ImHashMap<Type, object>[] array = (rs as Registry)?.KeyedFactoryCache;
			if (array != null)
			{
				ImHashMapEntry<Type, object> imHashMapEntry = array[serviceTypeHash & 0xF]?.GetEntryOrDefaultByReferenceEquals(serviceTypeHash, serviceType);
				if (imHashMapEntry != null)
				{
					KeyedFactoryCacheEntry keyedFactoryCacheEntry = (KeyedFactoryCacheEntry)imHashMapEntry.Value;
					while (keyedFactoryCacheEntry != null && result == null)
					{
						if (keyedFactoryCacheEntry.Key == key)
						{
							result = keyedFactoryCacheEntry;
						}
						else if (keyedFactoryCacheEntry.Key.Equals(key))
						{
							result = keyedFactoryCacheEntry;
						}
						keyedFactoryCacheEntry = keyedFactoryCacheEntry.Rest;
					}
				}
			}
			return result != null;
		}

		private object SetOrAddKeyedCacheFactory(object x, object k, object f)
		{
			for (KeyedFactoryCacheEntry keyedFactoryCacheEntry = (KeyedFactoryCacheEntry)x; keyedFactoryCacheEntry != null; keyedFactoryCacheEntry = keyedFactoryCacheEntry.Rest)
			{
				if (keyedFactoryCacheEntry.Key.Equals(k))
				{
					keyedFactoryCacheEntry.Factory = f;
					return x;
				}
			}
			return new KeyedFactoryCacheEntry((KeyedFactoryCacheEntry)x, k, f);
		}

		internal Expression GetCachedFactoryExpression(Request request, out ImMapEntry<object> entry)
		{
			int factoryID = request.FactoryID;
			ImMap<object>[] factoryExpressionCache = FactoryExpressionCache;
			entry = ((factoryExpressionCache == null) ? null : factoryExpressionCache[factoryID & 0xF]?.GetEntryOrDefault(factoryID));
			if (entry == null)
			{
				return null;
			}
			IReuse reuse = request.Reuse;
			object value = entry.Value;
			if (value is Expression result)
			{
				if (!(reuse is SingletonReuse) && !(reuse is CurrentScopeReuse { Name: null }))
				{
					return null;
				}
				return result;
			}
			if (value is ExprCacheOfTransientWithDepCount exprCacheOfTransientWithDepCount)
			{
				if (reuse != Reuse.Transient)
				{
					return null;
				}
				return exprCacheOfTransientWithDepCount.Expr;
			}
			if (value is ExprCacheOfScopedWithName exprCacheOfScopedWithName)
			{
				if (reuse.Name == null || !reuse.Name.Equals(exprCacheOfScopedWithName.Name))
				{
					return null;
				}
				return exprCacheOfScopedWithName.Expr;
			}
			return null;
		}

		internal Registry(ImHashMap<Type, object> services)
		{
			Services = services;
		}

		public virtual Registry WithoutCache()
		{
			return this;
		}

		public virtual Registry WithDefaultFactoryCache()
		{
			return new AndCache(Services, new ImHashMap<Type, object>[16], null, null, IsRegistryChangePermitted.Permitted);
		}

		public virtual Registry WithKeyedFactoryCache()
		{
			return new AndCache(Services, null, new ImHashMap<Type, object>[16], null, IsRegistryChangePermitted.Permitted);
		}

		public virtual Registry WithFactoryExpressionCache()
		{
			return new AndCache(Services, null, null, new ImMap<object>[16], IsChangePermitted);
		}

		internal virtual Registry WithServices(ImHashMap<Type, object> services)
		{
			if (services != Services)
			{
				return new Registry(services);
			}
			return this;
		}

		internal virtual Registry WithWrappers(ImHashMap<Type, object> wrappers)
		{
			if (wrappers != Wrappers)
			{
				return new AndWrappersAndDecorators(Services, wrappers, Decorators);
			}
			return this;
		}

		internal virtual Registry WithDecorators(ImHashMap<Type, object> decorators)
		{
			if (decorators != Decorators)
			{
				return new AndWrappersAndDecorators(Services, Wrappers, decorators);
			}
			return this;
		}

		public virtual Registry WithIsChangePermitted(IsRegistryChangePermitted isChangePermitted)
		{
			if (isChangePermitted != IsRegistryChangePermitted.Permitted)
			{
				return new AndCache(Services, null, null, null, isChangePermitted);
			}
			return this;
		}

		public static IEnumerable<ServiceRegistrationInfo> GetServiceRegistrations(ImHashMap<Type, object> registryOrServices)
		{
			ImHashMap<Type, object> map = ((!(registryOrServices is Registry registry)) ? registryOrServices : registry.Services);
			foreach (ImHashMapEntry<Type, object> entry in map.Enumerate())
			{
				if (entry.Value is Factory factory)
				{
					yield return new ServiceRegistrationInfo(factory, entry.Key, null);
				}
				else
				{
					if (entry.Value == null)
					{
						continue;
					}
					ImHashMap<object, Factory> factories = ((FactoriesEntry)entry.Value).Factories;
					foreach (ImHashMapEntry<object, Factory> item in factories.Enumerate())
					{
						yield return new ServiceRegistrationInfo(item.Value, entry.Key, item.Key);
					}
				}
			}
		}

		public IEnumerable<R> GetServiceRegistrations<R>(Func<Type, object, Factory, R> match) where R : class
		{
			foreach (ImHashMapEntry<Type, object> entry in Services.Enumerate())
			{
				if (entry.Value is Factory arg)
				{
					R val;
					if ((val = match(entry.Key, null, arg)) != null)
					{
						yield return val;
					}
					continue;
				}
				ImHashMap<object, Factory> factories = ((FactoriesEntry)entry.Value).Factories;
				foreach (ImHashMapEntry<object, Factory> item in factories.Enumerate())
				{
					R val;
					if ((val = match(entry.Key, item.Key, item.Value)) != null)
					{
						yield return val;
					}
				}
			}
		}

		public static IEnumerable<DecoratorRegistrationInfo> GetDecoratorRegistrations(ImHashMap<Type, object> registryOrServices)
		{
			if (!(registryOrServices is Registry { Decorators: var decorators }) || decorators.IsEmpty)
			{
				yield break;
			}
			foreach (ImHashMapEntry<Type, object> entry in decorators.Enumerate())
			{
				Factory[] array = (Factory[])entry.Value;
				foreach (Factory factory in array)
				{
					yield return new DecoratorRegistrationInfo(factory, entry.Key);
				}
			}
		}

		public static ImHashMap<Type, object> Register(ImHashMap<Type, object> registryOrServices, Factory factory, Type serviceType, IfAlreadyRegistered ifAlreadyRegistered, object serviceKey)
		{
			Registry registry = registryOrServices as Registry;
			if (registry != null && registry.IsChangePermitted != IsRegistryChangePermitted.Permitted)
			{
				if (registry.IsChangePermitted != IsRegistryChangePermitted.Ignored)
				{
					return Throw.For<Registry>(Error.NoMoreRegistrationsAllowed, serviceType, (serviceKey != null) ? ("with key " + serviceKey) : string.Empty, factory);
				}
				return registryOrServices;
			}
			int hashCode = RuntimeHelpers.GetHashCode(serviceType);
			if (factory.FactoryType == FactoryType.Service)
			{
				if (serviceKey != null)
				{
					return WithKeyedService(registry, registryOrServices, factory, hashCode, serviceType, ifAlreadyRegistered, serviceKey);
				}
				return WithDefaultService(registry, registryOrServices, factory, hashCode, serviceType, ifAlreadyRegistered);
			}
			registry = registry ?? new Registry(registryOrServices);
			if (factory.FactoryType != FactoryType.Decorator)
			{
				return registry.WithWrappers(registry.Wrappers.AddOrUpdate(hashCode, serviceType, factory));
			}
			return registry.WithDecorators(registry.Decorators.AddOrUpdate(hashCode, serviceType, factory.One(), (Type _, object older, object newer) => MergeSortedByLatestOrderOrRegistration((Factory[])older, (Factory[])newer)));
		}

		public static Factory[] GetRegisteredFactories(ImHashMap<Type, object> registryOrServices, Type serviceType, object serviceKey, FactoryType factoryType)
		{
			serviceType = serviceType.ThrowIfNull();
			switch (factoryType)
			{
			case FactoryType.Wrapper:
			{
				ImHashMap<Type, object> map2 = ((registryOrServices is Registry registry3) ? registry3.Wrappers : WrappersSupport.Wrappers);
				if (map2.GetValueOrDefault(serviceType) is Factory one2)
				{
					return one2.One();
				}
				Type genericDefinitionOrNull2 = serviceType.GetGenericDefinitionOrNull();
				if (genericDefinitionOrNull2 != null && map2.GetValueOrDefault(genericDefinitionOrNull2) is Factory one3)
				{
					return one3.One();
				}
				if (serviceType.GetArrayElementTypeOrNull() != null && map2.GetValueOrDefault(typeof(IEnumerable<>)) is Factory one4)
				{
					return one4.One();
				}
				return null;
			}
			case FactoryType.Decorator:
			{
				if (!(registryOrServices is Registry { Decorators: var decorators }))
				{
					return null;
				}
				Factory[] array = decorators.GetValueOrDefault(serviceType) as Factory[];
				Type genericDefinitionOrNull = serviceType.GetGenericDefinitionOrNull();
				if (genericDefinitionOrNull != null)
				{
					array = array.Append(decorators.GetValueOrDefault(genericDefinitionOrNull) as Factory[]);
				}
				return array;
			}
			default:
			{
				ImHashMap<Type, object> map = ((!(registryOrServices is Registry registry)) ? registryOrServices : registry.Services);
				object valueOrDefault = map.GetValueOrDefault(serviceType);
				if (valueOrDefault == null)
				{
					return null;
				}
				if (valueOrDefault is Factory one)
				{
					if (serviceKey != null && !DefaultKey.Value.Equals(serviceKey))
					{
						return null;
					}
					return one.One();
				}
				ImHashMap<object, Factory> factories = ((FactoriesEntry)valueOrDefault).Factories;
				if (serviceKey == null)
				{
					return factories.ToArray((ImHashMapEntry<object, Factory> x) => x.Value);
				}
				return factories.GetValueOrDefault(serviceKey)?.One();
			}
			}
		}

		public static bool IsRegistered(ImHashMap<Type, object> registryOrServices, Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
		{
			serviceType = serviceType.ThrowIfNull();
			switch (factoryType)
			{
			case FactoryType.Wrapper:
			{
				ImHashMap<Type, object> map2 = ((registryOrServices is Registry registry2) ? registry2.Wrappers : WrappersSupport.Wrappers);
				if (map2.GetValueOrDefault(serviceType) is Factory arg2 && (condition == null || condition(arg2)))
				{
					return true;
				}
				Type genericDefinitionOrNull = serviceType.GetGenericDefinitionOrNull();
				if (genericDefinitionOrNull != null && map2.GetValueOrDefault(genericDefinitionOrNull) is Factory arg3 && (condition == null || condition(arg3)))
				{
					return true;
				}
				if (serviceType.GetArrayElementTypeOrNull() != null && map2.GetValueOrDefault(typeof(IEnumerable<>)) is Factory arg4 && (condition == null || condition(arg4)))
				{
					return true;
				}
				return false;
			}
			case FactoryType.Decorator:
			{
				if (!(registryOrServices is Registry { Decorators: var decorators }))
				{
					return false;
				}
				if (decorators.GetValueOrDefault(serviceType) is Factory[] array && array.Length != 0 && (condition == null || array.FindFirst(condition) != null))
				{
					return true;
				}
				Type genericDefinitionOrNull2 = serviceType.GetGenericDefinitionOrNull();
				if (genericDefinitionOrNull2 != null && decorators.GetValueOrDefault(genericDefinitionOrNull2) is Factory[] array2 && array2.Length != 0 && (condition == null || array2.FindFirst(condition) != null))
				{
					return true;
				}
				return false;
			}
			default:
			{
				ImHashMap<Type, object> map = ((registryOrServices is Registry registry) ? registry.Services : registryOrServices);
				object valueOrDefault = map.GetValueOrDefault(serviceType);
				if (valueOrDefault == null)
				{
					return false;
				}
				if (valueOrDefault is Factory arg)
				{
					if (serviceKey != null && !DefaultKey.Value.Equals(serviceKey))
					{
						return false;
					}
					if (condition != null)
					{
						return condition(arg);
					}
					return true;
				}
				ImHashMap<object, Factory> factories = ((FactoriesEntry)valueOrDefault).Factories;
				if (serviceKey == null)
				{
					if (condition != null)
					{
						return factories.Enumerate().FirstOrDefault((ImHashMapEntry<object, Factory> f) => condition(f.Value)) != null;
					}
					return true;
				}
				Factory valueOrDefault2 = factories.GetValueOrDefault(serviceKey);
				if (valueOrDefault2 != null)
				{
					if (condition != null)
					{
						return condition(valueOrDefault2);
					}
					return true;
				}
				return false;
			}
			}
		}

		public static bool ClearCache(ImHashMap<Type, object> registryOrServices, int hash, Type serviceType, object serviceKey, FactoryType factoryType)
		{
			Factory[] registeredFactories = GetRegisteredFactories(registryOrServices, serviceType, serviceKey, factoryType);
			if (registeredFactories.IsNullOrEmpty())
			{
				return false;
			}
			if (registryOrServices is Registry registry)
			{
				for (int i = 0; i < registeredFactories.Length; i++)
				{
					registry.DropFactoryCache(registeredFactories[i], hash, serviceType, serviceKey);
				}
			}
			return true;
		}

		private static ImHashMap<Type, object> WithDefaultService(Registry r, ImHashMap<Type, object> registryOrServices, Factory factory, int serviceTypeHash, Type serviceType, IfAlreadyRegistered ifAlreadyRegistered)
		{
			ImHashMap<Type, object> imHashMap = ((r == null) ? registryOrServices : r.Services);
			ImHashMapEntry<Type, object> imHashMapEntry = ImHashMap.Entry(serviceTypeHash, serviceType, (object)factory);
			if (imHashMap.IsEmpty)
			{
				if (r != null)
				{
					return r.WithServices(imHashMapEntry);
				}
				return imHashMapEntry;
			}
			ImHashMap<Type, object> imHashMap2 = imHashMap.AddOrGetEntry(serviceTypeHash, imHashMapEntry);
			if (!(imHashMap2 is Entry entry))
			{
				if (r != null)
				{
					return r.WithServices(imHashMap2);
				}
				return imHashMap2;
			}
			Entry entry2 = entry.UpdateOrKeep(ifAlreadyRegistered, imHashMapEntry, delegate(IfAlreadyRegistered i, ImHashMapEntry<Type, object> o, ImHashMapEntry<Type, object> n)
			{
				Factory factory3 = (Factory)n.Value;
				switch (i)
				{
				case IfAlreadyRegistered.AppendNotKeyed:
					return n.SetValue((o.Value is FactoriesEntry factoriesEntry5) ? factoriesEntry5.With(factory3) : FactoriesEntry.Empty.WithTwo((Factory)o.Value, factory3));
				case IfAlreadyRegistered.Throw:
					return n.SetValue((o.Value is FactoriesEntry { LastDefaultKey: null } factoriesEntry4) ? factoriesEntry4.With(factory3) : Throw.For<object>(Error.UnableToRegisterDuplicateDefault, n.Key, factory3, o));
				case IfAlreadyRegistered.Replace:
					if (o.Value is FactoriesEntry factoriesEntry3)
					{
						if (factoriesEntry3.LastDefaultKey == null)
						{
							return n.SetValue(factoriesEntry3.With(factory3));
						}
						ImHashMap<object, Factory> imHashMap4 = factoriesEntry3.Factories.Fold(ImHashMap<object, Factory>.Empty, (ImHashMapEntry<object, Factory> x, int _, ImHashMap<object, Factory> map) => (x.Key is DefaultKey) ? map : map.AddOrUpdate(x.Key, x.Value));
						if (!imHashMap4.IsEmpty)
						{
							return n.SetValue(new FactoriesEntry(DefaultKey.Value, imHashMap4.AddOrUpdate(DefaultKey.Value, factory3)));
						}
					}
					return n;
				case IfAlreadyRegistered.AppendNewImplementation:
				{
					FactoriesEntry factoriesEntry6 = o.Value as FactoriesEntry;
					if (factoriesEntry6 != null && factoriesEntry6.LastDefaultKey == null)
					{
						return n.SetValue(factoriesEntry6.With(factory3));
					}
					Factory factory4 = o.Value as Factory;
					Type implementationType = factory3.ImplementationType;
					if (implementationType == null || (factory4 != null && factory4.ImplementationType != implementationType))
					{
						return n.SetValue((factoriesEntry6 ?? FactoriesEntry.Empty.With(factory4)).With(factory3));
					}
					if (factoriesEntry6 != null)
					{
						bool flag = true;
						foreach (ImHashMapEntry<object, Factory> item in factoriesEntry6.Factories.Enumerate())
						{
							if (item.Value.ImplementationType == implementationType)
							{
								flag = false;
								break;
							}
						}
						if (!flag)
						{
							return o;
						}
						return n.SetValue((factoriesEntry6 ?? FactoriesEntry.Empty.With(factory4)).With(factory3));
					}
					return n;
				}
				default:
					if (!(o.Value is FactoriesEntry { LastDefaultKey: null } factoriesEntry2))
					{
						return o;
					}
					return n.SetValue(factoriesEntry2.With(factory3));
				}
			});
			if (entry2 == entry)
			{
				return registryOrServices;
			}
			ImHashMap<Type, object> imHashMap3 = imHashMap.ReplaceEntry(serviceTypeHash, entry, entry2);
			if (r == null)
			{
				return imHashMap3;
			}
			r = r.WithServices(imHashMap3);
			object obj = entry.GetEntryOrNull(serviceTypeHash, serviceType)?.Value;
			if (obj is Factory factory2)
			{
				r.DropFactoryCache(factory2, serviceTypeHash, serviceType);
			}
			else if (obj is FactoriesEntry factoriesEntry && factoriesEntry?.LastDefaultKey != null)
			{
				factoriesEntry.Factories.ForEach(new { r, serviceTypeHash, serviceType }, (ImHashMapEntry<object, Factory> x, int _, s) =>
				{
					if (x.Key is DefaultKey)
					{
						s.r.DropFactoryCache(x.Value, s.serviceTypeHash, s.serviceType);
					}
				});
			}
			return r;
		}

		private static ImHashMap<Type, object> WithKeyedService(Registry r, ImHashMap<Type, object> registryOrServices, Factory factory, int serviceTypeHash, Type serviceType, IfAlreadyRegistered ifAlreadyRegistered, object serviceKey)
		{
			ImHashMap<Type, object> map = ((r == null) ? registryOrServices : r.Services);
			object obj = null;
			object valueOrDefault = map.GetValueOrDefault(serviceTypeHash, serviceType);
			if (valueOrDefault != null)
			{
				switch (ifAlreadyRegistered)
				{
				case IfAlreadyRegistered.Keep:
				{
					if (valueOrDefault is Factory factory4)
					{
						obj = FactoriesEntry.Empty.With(factory, serviceKey).With(factory4);
						break;
					}
					FactoriesEntry factoriesEntry2 = (FactoriesEntry)valueOrDefault;
					if (factoriesEntry2.Factories.Contains(serviceKey))
					{
						return registryOrServices;
					}
					obj = new FactoriesEntry(factoriesEntry2.LastDefaultKey, factoriesEntry2.Factories.AddOrUpdate(serviceKey, factory));
					break;
				}
				case IfAlreadyRegistered.Replace:
					obj = ((!(valueOrDefault is Factory factory3)) ? new FactoriesEntry(((FactoriesEntry)valueOrDefault).LastDefaultKey, ((FactoriesEntry)valueOrDefault).Factories.AddOrUpdate(serviceKey, factory)) : FactoriesEntry.Empty.With(factory, serviceKey).With(factory3));
					break;
				default:
				{
					if (valueOrDefault is Factory factory2)
					{
						obj = FactoriesEntry.Empty.With(factory, serviceKey).With(factory2);
						break;
					}
					FactoriesEntry factoriesEntry = (FactoriesEntry)valueOrDefault;
					Factory valueOrDefault2 = factoriesEntry.Factories.GetValueOrDefault(serviceKey);
					if (valueOrDefault2 != null)
					{
						Throw.It(Error.UnableToRegisterDuplicateKey, serviceKey, serviceKey, valueOrDefault2);
					}
					obj = new FactoriesEntry(factoriesEntry.LastDefaultKey, ((FactoriesEntry)valueOrDefault).Factories.AddOrUpdate(serviceKey, factory));
					break;
				}
				}
			}
			if (obj == null)
			{
				obj = FactoriesEntry.Empty.With(factory, serviceKey);
			}
			ImHashMap<Type, object> imHashMap = map.AddOrUpdate(serviceTypeHash, serviceType, obj);
			if (r == null)
			{
				return imHashMap;
			}
			r = r.WithServices(imHashMap);
			if (valueOrDefault != null && ifAlreadyRegistered == IfAlreadyRegistered.Replace && valueOrDefault is FactoriesEntry factoriesEntry3 && factoriesEntry3.Factories.TryFind(serviceKey, out var value))
			{
				r.DropFactoryCache(value, serviceTypeHash, serviceType, serviceKey);
			}
			return r;
		}

		public static ImHashMap<Type, object> Unregister(ImHashMap<Type, object> registryOrServices, FactoryType factoryType, Type serviceType, object serviceKey, Func<Factory, bool> condition)
		{
			Registry registry = registryOrServices as Registry;
			if (registry != null && registry.IsChangePermitted != IsRegistryChangePermitted.Permitted)
			{
				if (registry.IsChangePermitted != IsRegistryChangePermitted.Ignored)
				{
					return Throw.For<Registry>(Error.NoMoreUnregistrationsAllowed, serviceType, (serviceKey != null) ? ("with key " + serviceKey) : string.Empty, factoryType);
				}
				return registryOrServices;
			}
			int hashCode = RuntimeHelpers.GetHashCode(serviceType);
			switch (factoryType)
			{
			case FactoryType.Wrapper:
			{
				ImHashMap<Type, object> map = ((registry != null) ? registry.Wrappers : WrappersSupport.Wrappers);
				if (registry == null)
				{
					registry = new Registry(registryOrServices);
				}
				object removedWrapper = null;
				registry = registry.WithWrappers(map.Update(hashCode, serviceType, null, delegate(Type _, object factory, object _null)
				{
					if (factory != null && condition != null && !condition((Factory)factory))
					{
						return factory;
					}
					removedWrapper = factory;
					return (object)null;
				}));
				if (removedWrapper == null)
				{
					return registryOrServices;
				}
				registry.DropFactoryCache((Factory)removedWrapper, hashCode, serviceType);
				return registry;
			}
			case FactoryType.Decorator:
			{
				if (registry == null)
				{
					return registryOrServices;
				}
				ImHashMap<Type, object> decorators = registry.Decorators;
				Factory[] removedDecorators = null;
				registry = ((condition != null) ? registry.WithDecorators(decorators.Update(hashCode, serviceType, null, delegate(Type _, object factories, object _null)
				{
					removedDecorators = ((Factory[])factories).Match(condition);
					return (removedDecorators != factories) ? factories.To<Factory[]>().Except(removedDecorators).ToArray() : null;
				})) : registry.WithDecorators(decorators.Update(hashCode, serviceType, null, delegate(Type _, object factories, object _null)
				{
					removedDecorators = (Factory[])factories;
					return (object)null;
				})));
				if (removedDecorators.IsNullOrEmpty())
				{
					return registryOrServices;
				}
				for (int num = 0; num < removedDecorators.Length; num++)
				{
					registry.DropFactoryCache(removedDecorators[num], hashCode, serviceType);
				}
				return registry;
			}
			default:
				return UnregisterServiceFactory(registryOrServices, serviceType, serviceKey, condition);
			}
		}

		private static ImHashMap<Type, object> UnregisterServiceFactory(ImHashMap<Type, object> registryOrServices, Type serviceType, object serviceKey = null, Func<Factory, bool> condition = null)
		{
			Registry registry = registryOrServices as Registry;
			ImHashMap<Type, object> map = ((registry == null) ? registryOrServices : registry.Services);
			object removed = null;
			int hashCode = RuntimeHelpers.GetHashCode(serviceType);
			map = ((serviceKey != null || condition != null) ? map.Update(hashCode, serviceType, null, delegate(Type _, object entry, object _null)
			{
				if (entry == null)
				{
					return (object)null;
				}
				if (entry is Factory)
				{
					if ((serviceKey != null && !DefaultKey.Value.Equals(serviceKey)) || (condition != null && !condition((Factory)entry)))
					{
						return entry;
					}
					removed = entry;
					return (object)null;
				}
				FactoriesEntry factoriesEntry = (FactoriesEntry)entry;
				ImHashMap<object, Factory> factories = factoriesEntry.Factories;
				ImHashMap<object, Factory> empty = ImHashMap<object, Factory>.Empty;
				if (serviceKey == null)
				{
					empty = factories.Fold(empty, (ImHashMapEntry<object, Factory> oldFac, int num2, ImHashMap<object, Factory> remainingFacs) => (condition == null || condition(oldFac.Value)) ? remainingFacs : remainingFacs.AddOrUpdate(oldFac.Key, oldFac.Value));
				}
				else
				{
					empty = factories;
					Factory valueOrDefault = factories.GetValueOrDefault(serviceKey);
					if (valueOrDefault != null)
					{
						empty = ((factories.Count() > 1) ? factories.UpdateToDefault(serviceKey.GetHashCode(), serviceKey) : ImHashMap<object, Factory>.Empty);
					}
				}
				if (empty.IsEmpty)
				{
					removed = entry;
					return (object)null;
				}
				removed = (from x in factories.Enumerate().Except(empty.Enumerate())
					select x.Value).ToArray();
				if (empty is ImHashMapEntry<object, Factory> imHashMapEntry && DefaultKey.Value.Equals(imHashMapEntry.Key))
				{
					return imHashMapEntry.Value;
				}
				DefaultKey defaultKey = factoriesEntry.LastDefaultKey;
				if (defaultKey != null && empty.GetValueOrDefault(defaultKey) == null)
				{
					defaultKey = (from key in (from x in empty.Enumerate()
							select x.Key).OfType<DefaultKey>()
						orderby key.RegistrationOrder descending
						select key).FirstOrDefault();
				}
				return new FactoriesEntry(defaultKey, empty);
			}) : map.Update(hashCode, serviceType, null, delegate(Type _, object entry, object _null)
			{
				removed = entry;
				return (object)null;
			}));
			if (removed == null)
			{
				return registryOrServices;
			}
			if (registry == null)
			{
				return map;
			}
			registry = registry.WithServices(map);
			if (removed is Factory factory)
			{
				registry.DropFactoryCache(factory, hashCode, serviceType, serviceKey);
			}
			else if (removed is Factory[] array)
			{
				Factory[] array2 = array;
				foreach (Factory factory2 in array2)
				{
					registry.DropFactoryCache(factory2, hashCode, serviceType, serviceKey);
				}
			}
			else
			{
				foreach (ImHashMapEntry<object, Factory> item in ((FactoriesEntry)removed).Factories.Enumerate())
				{
					registry.DropFactoryCache(item.Value, hashCode, serviceType, serviceKey);
				}
			}
			return registry;
		}

		internal virtual void DropFactoryCache(Factory factory, int hash, Type serviceType, object serviceKey = null)
		{
		}
	}

	private static int _objectTypeHash = RuntimeHelpers.GetHashCode(typeof(object));

	private static readonly MethodInfo _kvOfMethod = typeof(KV).GetMethod("Of");

	private static readonly LastFactoryIDWinsComparer _lastFactoryIDWinsComparer = default(LastFactoryIDWinsComparer);

	private readonly IResolverContext _parent;

	internal readonly Ref<ImHashMap<Type, object>> _registry;

	private readonly IScope _singletonScope;

	private readonly IScope _ownCurrentScope;

	private readonly IScopeContext _scopeContext;

	private StackTrace _disposeStackTrace;

	private int _disposed;

	public IResolverContext Parent => _parent;

	public IResolverContext Root
	{
		get
		{
			if (_parent == null)
			{
				return null;
			}
			IResolverContext parent = _parent;
			while (parent.Parent != null)
			{
				parent = parent.Parent;
			}
			return parent;
		}
	}

	public IScope SingletonScope => _singletonScope;

	public IScopeContext ScopeContext => _scopeContext;

	public IScope CurrentScope
	{
		get
		{
			if (_scopeContext != null)
			{
				return _scopeContext.GetCurrentOrDefault();
			}
			return _ownCurrentScope;
		}
	}

	public IScope CurrentOrSingletonScope => ((_scopeContext == null) ? _ownCurrentScope : _scopeContext.GetCurrentOrDefault()) ?? _singletonScope;

	public Rules Rules { get; private set; }

	public IScope OwnCurrentScope => _ownCurrentScope;

	public bool IsDisposed
	{
		get
		{
			if (_disposed != 1 && !_singletonScope.IsDisposed)
			{
				return _ownCurrentScope?.IsDisposed ?? false;
			}
			return true;
		}
	}

	public object DisposeInfo => _disposeStackTrace;

	public Container()
		: this(Rules.Default, Ref.Of(Registry.Default), NewSingletonScope())
	{
		SetInitialFactoryID();
	}

	public Container(Rules rules = null, IScopeContext scopeContext = null)
		: this(rules ?? Rules.Default, Ref.Of(Registry.Default), NewSingletonScope(), scopeContext)
	{
		SetInitialFactoryID();
	}

	public Container(Func<Rules, Rules> configure, IScopeContext scopeContext = null)
		: this(configure.ThrowIfNull()(Rules.Default) ?? Rules.Default, scopeContext)
	{
	}

	public static IScope NewSingletonScope()
	{
		return Scope.Of("<singletons>");
	}

	public override string ToString()
	{
		string text = ((_scopeContext == null) ? "container" : ("container with ambient " + _scopeContext));
		IScope currentScope = CurrentScope;
		text += ((currentScope == null) ? " without scope" : (" with scope " + currentScope));
		if (Rules != Rules.Default)
		{
			text = text + "\n" + " with " + Rules;
		}
		if (IsDisposed)
		{
			text = text + " is disposed!" + "\n";
			text = ((_disposeStackTrace == null) ? (text + " You may include Dispose stack-trace into the message via:" + "\n" + "container.With(rules => rules.WithCaptureContainerDisposeStackTrace())") : (text + " Dispose stack-trace " + _disposeStackTrace));
		}
		return text;
	}

	private void TryCaptureContainerDisposeStackTrace()
	{
		try
		{
			_disposeStackTrace = new StackTrace();
		}
		catch
		{
		}
	}

	private void DisposeScopeContextCurrentScope()
	{
		IScope currentScope = null;
		_scopeContext.SetCurrent(delegate(IScope s)
		{
			currentScope = s;
			return s?.Parent;
		});
		currentScope?.Dispose();
	}

	public void Dispose()
	{
		if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 1)
		{
			return;
		}
		if (Rules.CaptureContainerDisposeStackTrace)
		{
			TryCaptureContainerDisposeStackTrace();
		}
		if (_parent != null)
		{
			if (_ownCurrentScope != null)
			{
				_ownCurrentScope.Dispose();
			}
			else if (_scopeContext != null)
			{
				DisposeScopeContextCurrentScope();
			}
		}
		else
		{
			_registry.Swap(Registry.Default);
			Rules = Rules.Default;
			_singletonScope.Dispose();
			_scopeContext?.Dispose();
		}
	}

	private void GetLastGeneratedFactoryID(ref int lastFactoryID)
	{
		lastFactoryID = 716;
	}

	private void ResolveGenerated(ref object service, Type serviceType)
	{
		if (serviceType == typeof(IService))
		{
			service = Get_IService_0(this);
		}
	}

	private void ResolveGenerated(ref object service, Type serviceType, object serviceKey, Type requiredServiceType, Request preRequestParent, object[] args)
	{
		if (serviceType == typeof(DependencyB<string>) && serviceKey == null && requiredServiceType == null && object.Equals(preRequestParent, Request.Empty.Push(typeof(IService), 711, typeof(MyService), Reuse.Transient, RequestFlags.IsResolutionCall)))
		{
			service = GetDependency_DependencyB_0(this);
		}
	}

	private void ResolveManyGenerated(ref IEnumerable<ResolveManyResult> services, Type serviceType)
	{
		services = ResolveManyGenerated(serviceType);
	}

	public object ResolveCompileTimeGeneratedOrDefault(Type serviceType)
	{
		object service = null;
		ResolveGenerated(ref service, serviceType);
		return service;
	}

	public object ResolveCompileTimeGeneratedOrDefault(Type serviceType, object serviceKey)
	{
		object service = null;
		ResolveGenerated(ref service, serviceType, serviceKey, null, null, null);
		return service;
	}

	public IEnumerable<ResolveManyResult> ResolveManyCompileTimeGeneratedOrEmpty(Type serviceType)
	{
		IEnumerable<ResolveManyResult> services = ArrayTools.Empty<ResolveManyResult>();
		ResolveManyGenerated(ref services, serviceType);
		return services;
	}

	public IEnumerable<ServiceRegistrationInfo> GetServiceRegistrations()
	{
		return Registry.GetServiceRegistrations(_registry.Value);
	}

	public IEnumerable<DecoratorRegistrationInfo> GetDecoratorRegistrations()
	{
		return Registry.GetDecoratorRegistrations(_registry.Value);
	}

	public Factory[] GetRegisteredFactories(Type serviceType, object serviceKey, FactoryType factoryType)
	{
		return Registry.GetRegisteredFactories(_registry.Value, serviceType.ThrowIfNull(), serviceKey, factoryType);
	}

	public void Register(Factory factory, Type serviceType, object serviceKey, IfAlreadyRegistered? ifAlreadyRegistered, bool isStaticallyChecked)
	{
		ThrowIfRootContainerDisposed();
		if (serviceKey == null)
		{
			serviceKey = Rules.DefaultRegistrationServiceKey;
		}
		factory.ThrowIfNull().ValidateAndNormalizeRegistration(serviceType, serviceKey, isStaticallyChecked, Rules, throwIfInvalid: true);
		if (!ifAlreadyRegistered.HasValue)
		{
			ifAlreadyRegistered = Rules.DefaultIfAlreadyRegistered;
		}
		if (serviceType.IsGenericType && !serviceType.IsGenericTypeDefinition && serviceType.ContainsGenericParameters)
		{
			serviceType = serviceType.GetGenericTypeDefinition();
		}
		ImHashMap<Type, object> value = _registry.Value;
		if (!_registry.TrySwapIfStillCurrent(value, Registry.Register(value, factory, serviceType, ifAlreadyRegistered.Value, serviceKey)))
		{
			RegistrySwap(factory, serviceType, serviceKey, ifAlreadyRegistered);
		}
	}

	private ImHashMap<Type, object> RegistrySwap(Factory factory, Type serviceType, object serviceKey, IfAlreadyRegistered? ifAlreadyRegistered)
	{
		return _registry.Swap((ImHashMap<Type, object> r) => Registry.Register(r, factory, serviceType, ifAlreadyRegistered.Value, serviceKey));
	}

	public bool IsRegistered(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
	{
		return Registry.IsRegistered(_registry.Value, serviceType, serviceKey, factoryType, condition);
	}

	public void Unregister(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
	{
		ThrowIfRootContainerDisposed();
		_registry.Swap((ImHashMap<Type, object> r) => Registry.Unregister(r, factoryType, serviceType, serviceKey, condition));
	}

	object IServiceProvider.GetService(Type serviceType)
	{
		object service = null;
		ResolveGenerated(ref service, serviceType);
		if (service != null)
		{
			return service;
		}
		int hashCode = RuntimeHelpers.GetHashCode(serviceType);
		Registry obj = _registry.Value as Registry;
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			ImHashMap<Type, object>[] defaultFactoryCache = obj.DefaultFactoryCache;
			obj2 = ((defaultFactoryCache == null) ? null : defaultFactoryCache[hashCode & 0xF]?.GetEntryOrDefaultByReferenceEquals(hashCode, serviceType));
		}
		ImHashMapEntry<Type, object> imHashMapEntry = (ImHashMapEntry<Type, object>)obj2;
		if (imHashMapEntry != null)
		{
			if (imHashMapEntry.Value is FactoryDelegate factoryDelegate)
			{
				return factoryDelegate(this);
			}
			if (this.TryGetUsedInstance(hashCode, serviceType, out var instance))
			{
				imHashMapEntry.Value = null;
				return instance;
			}
			Rules rules = Rules;
			while (imHashMapEntry.Value is Expression expression)
			{
				if (rules.UseInterpretation && Interpreter.TryInterpretAndUnwrapContainerException(this, expression, out var result))
				{
					return result;
				}
				if (Interlocked.CompareExchange(ref imHashMapEntry.Value, new Registry.Compiling(expression), expression) == expression)
				{
					return (imHashMapEntry.Value = expression.CompileToFactoryDelegate(rules.UseInterpretation))(this);
				}
			}
			if (imHashMapEntry.Value is Registry.Compiling compiling)
			{
				if (!Interpreter.TryInterpretAndUnwrapContainerException(this, compiling.Expression, out var result2))
				{
					return compiling.Expression.CompileToFactoryDelegate(rules.UseInterpretation)(this);
				}
				return result2;
			}
		}
		IfUnresolved ifUnresolved = ((!Rules.ServiceProviderGetServiceShouldThrowIfUnresolved) ? IfUnresolved.ReturnDefaultIfNotRegistered : IfUnresolved.Throw);
		return ResolveAndCache(hashCode, serviceType, ifUnresolved);
	}

	object IResolver.Resolve(Type serviceType, IfUnresolved ifUnresolved)
	{
		object service = null;
		ResolveGenerated(ref service, serviceType);
		if (service != null)
		{
			return service;
		}
		int hashCode = RuntimeHelpers.GetHashCode(serviceType);
		Registry obj = _registry.Value as Registry;
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			ImHashMap<Type, object>[] defaultFactoryCache = obj.DefaultFactoryCache;
			obj2 = ((defaultFactoryCache == null) ? null : defaultFactoryCache[hashCode & 0xF]?.GetEntryOrDefaultByReferenceEquals(hashCode, serviceType));
		}
		ImHashMapEntry<Type, object> imHashMapEntry = (ImHashMapEntry<Type, object>)obj2;
		if (imHashMapEntry != null)
		{
			if (imHashMapEntry.Value is FactoryDelegate factoryDelegate)
			{
				return factoryDelegate(this);
			}
			if (this.TryGetUsedInstance(hashCode, serviceType, out var instance))
			{
				imHashMapEntry.Value = null;
				return instance;
			}
			Rules rules = Rules;
			while (imHashMapEntry.Value is Expression expression)
			{
				if (rules.UseInterpretation && Interpreter.TryInterpretAndUnwrapContainerException(this, expression, out var result))
				{
					return result;
				}
				if (Interlocked.CompareExchange(ref imHashMapEntry.Value, new Registry.Compiling(expression), expression) == expression)
				{
					return (imHashMapEntry.Value = expression.CompileToFactoryDelegate(rules.UseInterpretation))(this);
				}
			}
			if (imHashMapEntry.Value is Registry.Compiling compiling)
			{
				if (!Interpreter.TryInterpretAndUnwrapContainerException(this, compiling.Expression, out var result2))
				{
					return compiling.Expression.CompileToFactoryDelegate(rules.UseInterpretation)(this);
				}
				return result2;
			}
		}
		return ResolveAndCache(hashCode, serviceType, ifUnresolved);
	}

	private object ResolveAndCache(int serviceTypeHash, Type serviceType, IfUnresolved ifUnresolved)
	{
		ThrowIfRootContainerDisposed();
		if (this.TryGetUsedInstance(serviceTypeHash, serviceType, out var instance))
		{
			return instance;
		}
		Request request = Request.CreateResolutionRoot(this, serviceType, ifUnresolved);
		Factory factory = ((IContainer)this).ResolveFactory(request);
		object serviceKey = request.ServiceKey;
		object obj = CurrentScope?.Name;
		if (serviceKey != null || obj != null)
		{
			return ResolveAndCacheKeyed(serviceTypeHash, serviceType, serviceKey, ifUnresolved, obj, null, Request.Empty, null);
		}
		if (factory == null)
		{
			return null;
		}
		Rules rules = Rules;
		FactoryDelegate factoryDelegate;
		if (!rules.UseInterpretationForTheFirstResolution)
		{
			factoryDelegate = factory.GetDelegateOrDefault(request);
			if (factoryDelegate == null)
			{
				return null;
			}
		}
		else
		{
			Expression expressionOrDefault = factory.GetExpressionOrDefault(request);
			if (expressionOrDefault == null)
			{
				return null;
			}
			if (expressionOrDefault is ConstantExpression { Value: var value })
			{
				if (value is ScopedItemException ex)
				{
					ex.ReThrow();
				}
				if (factory.CanCache)
				{
					TryCacheDefaultFactory<FactoryDelegate>(serviceTypeHash, serviceType, value.ToFactoryDelegate);
				}
				return value;
			}
			if (Interpreter.TryInterpretAndUnwrapContainerException(this, expressionOrDefault, out var result))
			{
				if (factory.CanCache)
				{
					TryCacheDefaultFactory(serviceTypeHash, serviceType, expressionOrDefault);
				}
				return result;
			}
			factoryDelegate = expressionOrDefault.CompileToFactoryDelegate(rules.UseInterpretation);
		}
		if (factory.CanCache)
		{
			TryCacheDefaultFactory(serviceTypeHash, serviceType, factoryDelegate);
		}
		return factoryDelegate(this);
	}

	object IResolver.Resolve(Type serviceType, object serviceKey, IfUnresolved ifUnresolved, Type requiredServiceType, Request preResolveParent, object[] args)
	{
		object obj = CurrentScope?.Name;
		if (serviceKey == null && requiredServiceType == null && obj == null && (preResolveParent == null || preResolveParent.IsEmpty) && args.IsNullOrEmpty())
		{
			return ((IResolver)this).Resolve(serviceType, ifUnresolved);
		}
		return ResolveAndCacheKeyed(RuntimeHelpers.GetHashCode(serviceType), serviceType, serviceKey, ifUnresolved, obj, requiredServiceType, preResolveParent ?? Request.Empty, args);
	}

	private object ResolveAndCacheKeyed(int serviceTypeHash, Type serviceType, object serviceKey, IfUnresolved ifUnresolved, object scopeName, Type requiredServiceType, Request preResolveParent, object[] args)
	{
		object service = null;
		ResolveGenerated(ref service, serviceType, serviceKey, requiredServiceType, preResolveParent, args);
		if (service != null)
		{
			return service;
		}
		if (serviceKey == null && requiredServiceType == null && this.TryGetUsedInstance(serviceTypeHash, serviceType, out var instance))
		{
			return instance;
		}
		object obj = null;
		if (requiredServiceType == null && preResolveParent.IsEmpty && args.IsNullOrEmpty())
		{
			obj = ((scopeName == null) ? serviceKey : ((serviceKey == null) ? scopeName : KV.Of(scopeName, serviceKey)));
			if (Registry.GetCachedKeyedFactoryOrDefault(_registry.Value, serviceTypeHash, serviceType, obj, out var result))
			{
				if (result.Factory is FactoryDelegate factoryDelegate)
				{
					return factoryDelegate(this);
				}
				if (TryInterpretOrCompileCachedExpression(this, result, Rules, out var result2))
				{
					return result2;
				}
			}
		}
		ThrowIfRootContainerDisposed();
		Request request = Request.Create(this, serviceType, serviceKey, ifUnresolved, requiredServiceType, preResolveParent, RequestFlags.Default, args);
		Factory factory = ((IContainer)this).ResolveFactory(request);
		if (factory == null)
		{
			return null;
		}
		if (!factory.CanCache)
		{
			obj = null;
		}
		if (obj != null && serviceKey == null && request.ServiceKey != null)
		{
			obj = ((scopeName == null) ? request.ServiceKey : KV.Of(scopeName, request.ServiceKey));
			if (Registry.GetCachedKeyedFactoryOrDefault(_registry.Value, serviceTypeHash, serviceType, obj, out var result3))
			{
				if (result3.Factory is FactoryDelegate factoryDelegate2)
				{
					return factoryDelegate2(this);
				}
				if (TryInterpretOrCompileCachedExpression(this, result3, Rules, out var result4))
				{
					return result4;
				}
			}
		}
		FactoryDelegate factoryDelegate3;
		if (!Rules.UseInterpretationForTheFirstResolution)
		{
			factoryDelegate3 = factory.GetDelegateOrDefault(request);
			if (factoryDelegate3 == null)
			{
				return null;
			}
		}
		else
		{
			Expression expressionOrDefault = factory.GetExpressionOrDefault(request);
			if (expressionOrDefault == null)
			{
				return null;
			}
			if (expressionOrDefault is ConstantExpression { Value: var value })
			{
				if (obj != null)
				{
					TryCacheKeyedFactory(serviceTypeHash, serviceType, obj, new FactoryDelegate(value.ToFactoryDelegate));
				}
				return value;
			}
			if (obj != null)
			{
				TryCacheKeyedFactory(serviceTypeHash, serviceType, obj, expressionOrDefault);
			}
			if (Interpreter.TryInterpretAndUnwrapContainerException(this, expressionOrDefault, out var result5))
			{
				return result5;
			}
			factoryDelegate3 = expressionOrDefault.CompileToFactoryDelegate(Rules.UseInterpretation);
		}
		if (obj != null)
		{
			TryCacheKeyedFactory(serviceTypeHash, serviceType, obj, factoryDelegate3);
		}
		return factoryDelegate3(this);
	}

	private static bool TryInterpretOrCompileCachedExpression(IResolverContext r, Registry.KeyedFactoryCacheEntry cacheEntry, Rules rules, out object result)
	{
		while (cacheEntry.Factory is Expression expression)
		{
			if (rules.UseInterpretation && Interpreter.TryInterpretAndUnwrapContainerException(r, expression, out result))
			{
				return true;
			}
			if (Interlocked.CompareExchange(ref cacheEntry.Factory, new Registry.Compiling(expression), expression) == expression)
			{
				result = (cacheEntry.Factory = expression.CompileToFactoryDelegate(rules.UseInterpretation))(r);
				return true;
			}
		}
		if (cacheEntry.Factory is Registry.Compiling compiling)
		{
			if (!Interpreter.TryInterpretAndUnwrapContainerException(r, compiling.Expression, out result))
			{
				result = compiling.Expression.CompileToFactoryDelegate(rules.UseInterpretation)(r);
			}
			return true;
		}
		result = null;
		return false;
	}

	IEnumerable<object> IResolver.ResolveMany(Type serviceType, object serviceKey, Type requiredServiceType, Request preResolveParent, object[] args)
	{
		Type requiredItemType = requiredServiceType ?? serviceType;
		IEnumerable<ResolveManyResult> services = Enumerable.Empty<ResolveManyResult>();
		ResolveManyGenerated(ref services, serviceType);
		if (serviceKey != null)
		{
			services = services.Where((ResolveManyResult x) => serviceKey.Equals(x.ServiceKey));
		}
		if (requiredServiceType != null)
		{
			services = services.Where((ResolveManyResult x) => requiredServiceType == x.RequiredServiceType);
		}
		foreach (ResolveManyResult item in services)
		{
			yield return item.FactoryDelegate(this);
		}
		if (preResolveParent == null || preResolveParent.IsEmpty)
		{
			preResolveParent = Request.Empty.Push(typeof(IEnumerable<object>), requiredItemType, serviceKey, IfUnresolved.Throw, WrappersSupport.CollectionWrapperID, FactoryType.Wrapper, null, null, RequestFlags.Default, 0);
		}
		IContainer container = this;
		Type wrappedType = container.GetWrappedType(requiredItemType, null);
		if (wrappedType != null && wrappedType != typeof(void))
		{
			requiredItemType = wrappedType;
		}
		ServiceRegistrationInfo[] array = container.GetServiceRegisteredAndDynamicFactories(requiredItemType).Match(requiredServiceType, (Type _, KV<object, Factory> x) => x.Value != null, (Type t, KV<object, Factory> f) => new ServiceRegistrationInfo(f.Value, t, f.Key));
		ServiceRegistrationInfo[] array2 = null;
		if (requiredItemType.IsClosedGeneric())
		{
			Type genericDefinitionOrNull = requiredItemType.GetGenericDefinitionOrNull();
			array2 = container.GetAllServiceFactories(genericDefinitionOrNull).Match(genericDefinitionOrNull, requiredServiceType, (Type _, Type __, KV<object, Factory> x) => x.Value != null, (Type gt, Type t, KV<object, Factory> x) => new ServiceRegistrationInfo(x.Value, t, new OpenGenericTypeKey(gt, x.Key)));
		}
		ServiceRegistrationInfo[] array3 = null;
		if (requiredItemType.IsGenericType && container.Rules.VariantGenericTypesInResolvedCollection)
		{
			array3 = (from x in container.GetServiceRegistrations()
				where x.ServiceType.IsGenericType && x.ServiceType.GetGenericTypeDefinition() == requiredItemType.GetGenericTypeDefinition() && x.ServiceType != requiredItemType && x.ServiceType.IsAssignableTo(requiredItemType)
				select x).ToArray();
		}
		if (serviceKey != null)
		{
			array = array.Match(serviceKey, (object k, ServiceRegistrationInfo x) => k.Equals(x.OptionalServiceKey));
			if (array2 != null)
			{
				array2 = array2.Match(serviceKey, (object k, ServiceRegistrationInfo x) => k.Equals(((OpenGenericTypeKey)x.OptionalServiceKey).ServiceKey));
			}
			if (array3 != null)
			{
				array3 = array3.Match(serviceKey, (object k, ServiceRegistrationInfo x) => k.Equals(x.OptionalServiceKey));
			}
		}
		ServiceDetails serviceDetails = preResolveParent.GetServiceDetails();
		string metadataKey = serviceDetails.MetadataKey;
		object metadata = serviceDetails.Metadata;
		if (metadataKey != null || metadata != null)
		{
			array = array.Match(metadataKey, metadata, (string mk, object m, ServiceRegistrationInfo x) => x.Factory.Setup.MatchesMetadata(mk, m));
			if (array2 != null)
			{
				array2 = array2.Match(metadataKey, metadata, (string mk, object m, ServiceRegistrationInfo x) => x.Factory.Setup.MatchesMetadata(mk, m));
			}
			if (array3 != null)
			{
				array3 = array3.Match(metadataKey, metadata, (string mk, object m, ServiceRegistrationInfo x) => x.Factory.Setup.MatchesMetadata(mk, m));
			}
		}
		Request request = preResolveParent;
		if (request.FactoryType != FactoryType.Service)
		{
			request = request.FirstOrDefault((Request p) => p.FactoryType == FactoryType.Service) ?? Request.Empty;
		}
		if (!request.IsEmpty && request.GetActualServiceType() == requiredItemType)
		{
			array = array.Match(request.FactoryID, (int id, ServiceRegistrationInfo x) => x.Factory.FactoryID != id);
			if (array2 != null)
			{
				array2 = array2.Match(request.FactoryID, (int id, ServiceRegistrationInfo x) => x.Factory.GeneratedFactories?.ToArray().FindFirst(id, (int i, ImHashMapEntry<KV<Type, object>, ReflectionFactory> f) => f.Value.FactoryID == id) == null);
			}
			if (array3 != null)
			{
				array3 = array3.Match(request.FactoryID, (int id, ServiceRegistrationInfo x) => x.Factory.FactoryID != id);
			}
		}
		ServiceRegistrationInfo[] source = ((array2 == null && array3 == null) ? array : ((array3 == null) ? array.Append(array2) : ((array2 == null) ? array.Append(array3) : array.Append(array2).Append(array3))));
		foreach (ServiceRegistrationInfo item2 in source.OrderBy((ServiceRegistrationInfo x) => x.FactoryRegistrationOrder))
		{
			object obj = container.Resolve(serviceType, item2.OptionalServiceKey, IfUnresolved.ReturnDefaultIfNotRegistered, item2.ServiceType, preResolveParent, args);
			if (obj != null)
			{
				yield return obj;
			}
		}
	}

	private void ThrowIfContainerDisposed()
	{
		if (IsDisposed)
		{
			Throw.It(Error.ContainerIsDisposed, ToString());
		}
	}

	private void ThrowIfRootContainerDisposed()
	{
		if (_singletonScope.IsDisposed)
		{
			Throw.It(Error.ContainerIsDisposed, ToString());
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IResolverContext WithCurrentScope(IScope scope)
	{
		ThrowIfRootContainerDisposed();
		return new Container(Rules, _registry, _singletonScope, _scopeContext, scope, 0, null, this);
	}

	void IResolverContext.InjectPropertiesAndFields(object instance, string[] propertyAndFieldNames)
	{
		Type type = instance.ThrowIfNull().GetType();
		PropertiesAndFieldsSelector propertiesAndFieldsSelector = null;
		if (!propertyAndFieldNames.IsNullOrEmpty())
		{
			PropertyOrFieldServiceInfo[] array = type.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Match(propertyAndFieldNames, (string[] p, MemberInfo m) => (m is PropertyInfo || m is FieldInfo) && p.IndexOf<string>(m.Name) != -1, (string[] p, MemberInfo x) => PropertyOrFieldServiceInfo.Of(x));
			propertiesAndFieldsSelector = ((IEnumerable<PropertyOrFieldServiceInfo>)array).ToFunc<Request, IEnumerable<PropertyOrFieldServiceInfo>>;
		}
		propertiesAndFieldsSelector = propertiesAndFieldsSelector ?? Rules.PropertiesAndFields ?? PropertiesAndFields.Auto;
		Request request = Request.CreateResolutionRoot(this, type).WithResolvedFactory(new InjectedIntoFactoryDummy(type), skipRecursiveDependencyCheck: true, skipCaptiveDependencyCheck: true);
		foreach (PropertyOrFieldServiceInfo item in propertiesAndFieldsSelector(request))
		{
			if (item != null)
			{
				ServiceDetails details = item.Details;
				object obj = ((IResolver)this).Resolve(item.ServiceType, details.ServiceKey, details.IfUnresolved, details.RequiredServiceType, request, (object[])null);
				if (obj != null)
				{
					item.SetValue(instance, obj);
				}
			}
		}
	}

	public void Use(Type serviceType, object instance)
	{
		int hashCode = RuntimeHelpers.GetHashCode(serviceType);
		(CurrentScope ?? SingletonScope).SetUsed(hashCode, serviceType, instance);
		ImHashMapEntry<Type, object> cachedDefaultFactoryOrDefault = Registry.GetCachedDefaultFactoryOrDefault(_registry.Value, hashCode, serviceType);
		if (cachedDefaultFactoryOrDefault != null)
		{
			cachedDefaultFactoryOrDefault.Value = null;
		}
	}

	public IContainer With(Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing, IScope singletonScope)
	{
		return With(_parent, rules, scopeContext, registrySharing, singletonScope, _ownCurrentScope, null);
	}

	public IContainer With(IResolverContext parent, Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing, IScope singletonScope, IScope currentScope)
	{
		return With(_parent, rules, scopeContext, registrySharing, singletonScope, currentScope, null);
	}

	public IContainer With(IResolverContext parent, Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing, IScope singletonScope, IScope currentScope, IsRegistryChangePermitted? isRegistryChangePermitted)
	{
		ThrowIfContainerDisposed();
		ImHashMap<Type, object> value = _registry.Value;
		Registry registry = value as Registry;
		Ref<ImHashMap<Type, object>> obj = registrySharing switch
		{
			RegistrySharing.CloneButKeepCache => Ref.Of(value), 
			RegistrySharing.Share => _registry, 
			_ => (registry != null) ? Ref.Of((ImHashMap<Type, object>)registry.WithoutCache()) : Ref.Of(value), 
		};
		if (isRegistryChangePermitted.HasValue)
		{
			IsRegistryChangePermitted value2 = isRegistryChangePermitted.Value;
			if (obj.Value is Registry registry2)
			{
				if (registry2.IsChangePermitted != value2)
				{
					obj = Ref.Of((ImHashMap<Type, object>)registry2.WithIsChangePermitted(value2));
				}
			}
			else if (value2 != IsRegistryChangePermitted.Permitted)
			{
				obj = Ref.Of((ImHashMap<Type, object>)new Registry.AndCache(value, value2));
			}
		}
		return new Container(rules ?? Rules, obj, singletonScope ?? NewSingletonScope(), scopeContext, currentScope ?? _ownCurrentScope, _disposed, _disposeStackTrace, parent ?? _parent);
	}

	public IContainer WithNoMoreRegistrationAllowed(bool ignoreInsteadOfThrow = false)
	{
		return With(_parent, Rules, _scopeContext, RegistrySharing.Share, _singletonScope, _ownCurrentScope, (!ignoreInsteadOfThrow) ? IsRegistryChangePermitted.Error : IsRegistryChangePermitted.Ignored);
	}

	public bool ClearCache(Type serviceType, FactoryType? factoryType, object serviceKey)
	{
		int hashCode = RuntimeHelpers.GetHashCode(serviceType);
		if (factoryType.HasValue)
		{
			return Registry.ClearCache(_registry.Value, hashCode, serviceType, serviceKey, factoryType.Value);
		}
		ImHashMap<Type, object> value = _registry.Value;
		bool flag = Registry.ClearCache(value, hashCode, serviceType, serviceKey, FactoryType.Service);
		bool flag2 = Registry.ClearCache(value, hashCode, serviceType, serviceKey, FactoryType.Wrapper);
		bool flag3 = Registry.ClearCache(value, hashCode, serviceType, serviceKey, FactoryType.Decorator);
		return flag || flag2 || flag3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal Expression GetCachedFactoryExpression(Request request, out ImMapEntry<object> slot)
	{
		if (_registry.Value is Registry registry)
		{
			return registry.GetCachedFactoryExpression(request, out slot);
		}
		slot = null;
		return null;
	}

	Factory IContainer.ResolveFactory(Request request)
	{
		Factory factory = ((IContainer)this).GetServiceFactoryOrDefault(request);
		if (factory == null)
		{
			factory = GetWrapperFactoryOrDefault(request);
			if (factory != null)
			{
				return factory;
			}
			Rules.UnknownServiceResolver[] unknownServiceResolvers = Rules.UnknownServiceResolvers;
			if (!unknownServiceResolvers.IsNullOrEmpty())
			{
				int num = 0;
				while (factory == null && num < unknownServiceResolvers.Length)
				{
					factory = unknownServiceResolvers[num](request)?.DoNotCache();
					num++;
				}
			}
		}
		if (factory?.GeneratedFactories != null)
		{
			factory = factory.GetGeneratedFactoryOrDefault(request);
		}
		if (factory == null)
		{
			TryThrowUnableToResolve(request);
		}
		return factory;
	}

	internal static void TryThrowUnableToResolve(Request request)
	{
		if (request.IfUnresolved == IfUnresolved.Throw)
		{
			StringBuilder seed = new StringBuilder();
			seed = request.Container.GetAllServiceFactories(request.ServiceType, bothClosedAndOpenGenerics: true).Aggregate(seed, delegate(StringBuilder s, KV<object, Factory> x)
			{
				IReuse reuse = x.Value.Reuse;
				return s.Append((reuse == null || reuse.CanApply(request)) ? "  " : "  without matching scope ").Print(x);
			});
			if (seed.Length != 0)
			{
				Throw.It(Error.UnableToResolveFromRegisteredServices, request, seed);
			}
			else
			{
				Throw.It(Error.UnableToResolveUnknownService, request, request.Rules.DynamicRegistrationProviders.EmptyIfNull().Length, request.Rules.UnknownServiceResolvers.EmptyIfNull().Length);
			}
		}
	}

	Factory IContainer.GetServiceFactoryOrDefault(Request request)
	{
		ServiceDetails serviceDetails = request.GetServiceDetails();
		object serviceKey = serviceDetails.ServiceKey;
		Type requiredServiceType = serviceDetails.RequiredServiceType;
		Type type;
		if (requiredServiceType != null && requiredServiceType.IsOpenGeneric())
		{
			type = requiredServiceType;
		}
		else
		{
			type = request.GetActualServiceType();
			if (serviceKey is OpenGenericTypeKey openGenericTypeKey && type.IsClosedGeneric() && openGenericTypeKey.RequiredServiceType == type.GetGenericTypeDefinition())
			{
				type = openGenericTypeKey.RequiredServiceType;
				serviceKey = openGenericTypeKey.ServiceKey;
			}
		}
		ImHashMap<Type, object> imHashMap = _registry.Value;
		if (imHashMap is Registry registry)
		{
			imHashMap = registry.Services;
		}
		Rules rules = Rules;
		if (rules.FactorySelector != null && serviceKey == null)
		{
			return GetRuleSelectedServiceFactoryOrDefault(rules, imHashMap, request, serviceDetails, type);
		}
		object obj = imHashMap.GetValueOrDefault(type);
		Type type2 = (type.IsClosedGeneric() ? type.GetGenericTypeDefinition() : null);
		if (type2 != null)
		{
			if (obj == null || (serviceKey != null && ((obj is Factory && !serviceKey.Equals(DefaultKey.Value)) || (obj is FactoriesEntry factoriesEntry && factoriesEntry.Factories.GetValueOrDefault(serviceKey) == null))))
			{
				obj = imHashMap.GetValueOrDefault(type2) ?? obj;
			}
			if (obj == null && rules.VariantGenericTypesInResolve)
			{
				foreach (ImHashMapEntry<Type, object> item in imHashMap.Enumerate())
				{
					if (item.Value is Factory factory)
					{
						if ((serviceKey == null || serviceKey == DefaultKey.Value) && type.IsAssignableVariantGenericTypeFrom(item.Key) && request.MatchFactoryConditionAndMetadata(serviceDetails, factory))
						{
							obj = factory;
							break;
						}
						continue;
					}
					foreach (ImHashMapEntry<object, Factory> item2 in ((FactoriesEntry)item.Value).Factories.Enumerate())
					{
						if (item2.Key.Equals(serviceKey) && type.IsAssignableVariantGenericTypeFrom(item.Key) && request.MatchFactoryConditionAndMetadata(serviceDetails, item2.Value))
						{
							obj = item2.Value;
							break;
						}
					}
				}
			}
		}
		if (obj is Factory factory2 && (rules.DynamicRegistrationProviders == null || !rules.HasDynamicRegistrationProvider(DynamicRegistrationFlags.Service, DynamicRegistrationFlags.AsFallback)))
		{
			if ((serviceKey != null && serviceKey != DefaultKey.Value) || !request.MatchFactoryConditionAndMetadata(serviceDetails, factory2))
			{
				return null;
			}
			return factory2;
		}
		KV<object, Factory>[] array = ((obj == null) ? ArrayTools.Empty<KV<object, Factory>>() : ((obj is Factory value) ? new KV<object, Factory>(DefaultKey.Value, value).One() : obj.To<FactoriesEntry>().Factories.ToArray((ImHashMapEntry<object, Factory> x) => KV.Of(x.Key, x.Value)).Match((KV<object, Factory> x) => x.Value != null)));
		if (rules.DynamicRegistrationProviders != null && !type.IsExcludedGeneralPurposeServiceType() && !((IContainer)this).IsWrapper(type, type2))
		{
			array = CombineRegisteredServiceWithDynamicFactories(array, type, type2, serviceKey);
		}
		if (array.Length == 0)
		{
			return null;
		}
		if (serviceKey != null)
		{
			KV<object, Factory>[] array2 = array;
			foreach (KV<object, Factory> kV in array2)
			{
				if (serviceKey.Equals(kV.Key) && kV.Value.CheckCondition(request))
				{
					return kV.Value;
				}
			}
			return null;
		}
		array = array.Match((KV<object, Factory> f) => f.Key is DefaultKey || f.Key is DefaultDynamicKey);
		int num2 = array.Length;
		if (num2 == 0)
		{
			return null;
		}
		array = array.Match(request, serviceDetails, (Request r, ServiceDetails d, KV<object, Factory> x) => r.MatchFactoryConditionAndMetadata(d, x.Value));
		if (array.Length > 1 && rules.ImplicitCheckForReuseMatchingScope)
		{
			KV<object, Factory> kV2 = null;
			KV<object, Factory>[] array3 = array.Match(request, (Request r, KV<object, Factory> x) => r.MatchFactoryReuse(x.Value));
			if (array3.Length == 1)
			{
				kV2 = array3[0];
			}
			else if (array3.Length > 1)
			{
				kV2 = FindFactoryWithTheMinReuseLifespanOrDefault(array);
			}
			if (kV2 != null)
			{
				if (!request.IsResolutionCall)
				{
					kV2.Value.SetAsResolutionCall();
				}
				else
				{
					request.ChangeServiceKey(kV2.Key);
				}
				return kV2.Value;
			}
		}
		if (array.Length > 1)
		{
			array = array.Match(request, (Request r, KV<object, Factory> x) => r.MatchGeneratedFactory(x.Value));
		}
		if (array.Length > 1)
		{
			KV<object, Factory>[] array4 = array.Match((KV<object, Factory> f) => f.Value.Setup.Condition != null);
			if (array4.Length == 1)
			{
				array = array4;
			}
		}
		if (array.Length > 1)
		{
			KV<object, Factory>[] array5 = array.Match((KV<object, Factory> f) => f.Value.Setup.PreferInSingleServiceResolve);
			if (array5.Length == 1)
			{
				array = array5;
			}
		}
		if (array.Length == 1)
		{
			if (num2 > 1 && request.IsResolutionCall)
			{
				request.ChangeServiceKey(array[0].Key);
			}
			return array[0].Value;
		}
		if (array.Length > 1 && request.IfUnresolved == IfUnresolved.Throw)
		{
			Throw.It(Error.ExpectedSingleDefaultFactory, array, request);
		}
		return null;
	}

	private Factory GetRuleSelectedServiceFactoryOrDefault(Rules rules, ImHashMap<Type, object> serviceFactories, Request request, ServiceDetails details, Type serviceType)
	{
		object valueOrDefault = serviceFactories.GetValueOrDefault(serviceType);
		if (valueOrDefault is Factory factory && (rules.DynamicRegistrationProviders == null || !rules.HasDynamicRegistrationProvider(DynamicRegistrationFlags.Service, DynamicRegistrationFlags.AsFallback)))
		{
			if (request.MatchFactoryConditionAndMetadata(details, factory))
			{
				if (!rules.IsSelectLastRegisteredFactory)
				{
					return rules.FactorySelector(request, factory, null);
				}
				return factory;
			}
			return null;
		}
		Type genericDefinitionOrNull = serviceType.GetGenericDefinitionOrNull();
		KV<object, Factory>[] array;
		if (valueOrDefault is Factory value)
		{
			array = new KV<object, Factory>[1]
			{
				new KV<object, Factory>(DefaultKey.Value, value)
			};
		}
		else if (valueOrDefault is FactoriesEntry factoriesEntry)
		{
			array = factoriesEntry.Factories.ToArray((ImHashMapEntry<object, Factory> x) => KV.Of(x.Key, x.Value)).Match((KV<object, Factory> x) => x.Value != null);
		}
		else
		{
			array = ArrayTools.Empty<KV<object, Factory>>();
			if (genericDefinitionOrNull != null)
			{
				object valueOrDefault2 = serviceFactories.GetValueOrDefault(genericDefinitionOrNull);
				if (valueOrDefault2 != null)
				{
					array = ((!(valueOrDefault2 is Factory value2)) ? ((FactoriesEntry)valueOrDefault2).Factories.ToArray((ImHashMapEntry<object, Factory> x) => KV.Of(x.Key, x.Value)).Match((KV<object, Factory> x) => x.Value != null) : new KV<object, Factory>[1]
					{
						new KV<object, Factory>(DefaultKey.Value, value2)
					});
				}
				if (valueOrDefault2 == null && rules.VariantGenericTypesInResolve)
				{
					foreach (ImHashMapEntry<Type, object> item in serviceFactories.Enumerate())
					{
						if (item.Value is Factory factory2)
						{
							if (serviceType.IsAssignableVariantGenericTypeFrom(item.Key) && request.MatchFactoryConditionAndMetadata(details, factory2))
							{
								array = KV.Of((object)DefaultKey.Value, factory2).One();
								break;
							}
							continue;
						}
						foreach (ImHashMapEntry<object, Factory> item2 in ((FactoriesEntry)item.Value).Factories.Enumerate())
						{
							if (serviceType.IsAssignableVariantGenericTypeFrom(item.Key) && request.MatchFactoryConditionAndMetadata(details, item2.Value))
							{
								array = KV.Of(item2.Key, item2.Value).One();
								break;
							}
						}
					}
				}
			}
		}
		if (rules.DynamicRegistrationProviders != null && !serviceType.IsExcludedGeneralPurposeServiceType() && !((IContainer)this).IsWrapper(serviceType, genericDefinitionOrNull))
		{
			array = CombineRegisteredServiceWithDynamicFactories(array, serviceType, genericDefinitionOrNull);
		}
		if (array.Length == 0)
		{
			return null;
		}
		if (array.Length == 1)
		{
			if (!request.MatchFactoryConditionAndMetadata(details, array[0].Value))
			{
				return null;
			}
			return rules.FactorySelector(request, null, array);
		}
		if (array.Length > 1)
		{
			Array.Sort(array, _lastFactoryIDWinsComparer);
		}
		KV<object, Factory>[] array2 = array.Match(request, details, (Request r, ServiceDetails d, KV<object, Factory> x) => r.MatchFactoryConditionAndMetadata(d, x.Value));
		if (array2.Length > 1 && rules.ImplicitCheckForReuseMatchingScope)
		{
			array2 = array2.Match(request, (Request r, KV<object, Factory> x) => r.MatchFactoryReuse(x.Value));
			if (array2.Length == 1 && !request.IsResolutionCall)
			{
				array2[0].Value.SetAsResolutionCall();
			}
		}
		if (array2.Length > 1)
		{
			array2 = array2.Match(request, (Request r, KV<object, Factory> x) => r.MatchGeneratedFactory(x.Value));
		}
		if (array2.Length == 0)
		{
			return null;
		}
		Factory factory3 = ((array2.Length == 1) ? rules.FactorySelector(request, array2[0].Value, null) : rules.FactorySelector(request, null, array2));
		if (factory3 == null)
		{
			return null;
		}
		if (request.IsResolutionCall && array.Length > 1)
		{
			int num;
			for (num = 0; num < array2.Length && array2[num].Value.FactoryID != factory3.FactoryID; num++)
			{
			}
			if (num < array2.Length)
			{
				request.ChangeServiceKey(array2[num].Key);
			}
		}
		return factory3;
	}

	private static KV<object, Factory> FindFactoryWithTheMinReuseLifespanOrDefault(KV<object, Factory>[] factories)
	{
		int num = int.MaxValue;
		bool flag = false;
		KV<object, Factory> kV = null;
		foreach (KV<object, Factory> kV2 in factories)
		{
			IReuse reuse = kV2.Value.Reuse;
			int num2 = ((reuse == null || reuse == Reuse.Transient) ? int.MaxValue : reuse.Lifespan);
			if (num2 == num)
			{
				flag = true;
			}
			else if (num2 < num)
			{
				num = num2;
				kV = kV2;
				flag = false;
			}
		}
		if (flag || kV == null)
		{
			return null;
		}
		return kV;
	}

	KV<object, Factory>[] IContainer.GetAllServiceFactories(Type serviceType, bool bothClosedAndOpenGenerics)
	{
		ImHashMap<Type, object> imHashMap = _registry.Value;
		if (imHashMap is Registry registry)
		{
			imHashMap = registry.Services;
		}
		object valueOrDefault = imHashMap.GetValueOrDefault(serviceType);
		KV<object, Factory>[] array = ((valueOrDefault == null) ? ArrayTools.Empty<KV<object, Factory>>() : ((!(valueOrDefault is Factory value)) ? ((FactoriesEntry)valueOrDefault).Factories.ToArray((ImHashMapEntry<object, Factory> x) => KV.Of(x.Key, x.Value)).Match((KV<object, Factory> x) => x.Value != null) : new KV<object, Factory>[1]
		{
			new KV<object, Factory>(DefaultKey.Value, value)
		}));
		Type type = ((bothClosedAndOpenGenerics && serviceType.IsClosedGeneric()) ? serviceType.GetGenericTypeDefinition() : null);
		if (type != null)
		{
			object valueOrDefault2 = imHashMap.GetValueOrDefault(type);
			if (valueOrDefault2 != null)
			{
				array = ((valueOrDefault2 is Factory value2) ? array.Append(new KV<object, Factory>(DefaultKey.Value, value2)) : array.Append(((FactoriesEntry)valueOrDefault2).Factories.ToArray((ImHashMapEntry<object, Factory> x) => KV.Of(x.Key, x.Value)).Match((KV<object, Factory> x) => x.Value != null)));
			}
		}
		if (Rules.DynamicRegistrationProviders != null && !serviceType.IsExcludedGeneralPurposeServiceType())
		{
			return CombineRegisteredServiceWithDynamicFactories(array, serviceType, type);
		}
		return array;
	}

	internal static Factory[] MergeSortedByLatestOrderOrRegistration(Factory[] source, params Factory[] added)
	{
		if (added == null || added.Length == 0)
		{
			return source;
		}
		if (source == null || source.Length == 0)
		{
			return added;
		}
		int num = source.Length;
		int num2 = added.Length;
		if (num == 1 && num2 == 1)
		{
			Factory factory = source[0];
			Factory factory2 = added[0];
			int order = ((Setup.DecoratorSetup)factory.Setup).Order;
			int order2 = ((Setup.DecoratorSetup)factory2.Setup).Order;
			if (order <= order2 && (order != order2 || factory.RegistrationOrder <= factory2.RegistrationOrder))
			{
				return new Factory[2] { factory2, factory };
			}
			return new Factory[2] { factory, factory2 };
		}
		Factory[] array = new Factory[num + num2];
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (num3 < num && num4 < num2)
			{
				Factory factory3 = source[num3];
				Factory factory4 = added[num4];
				int order3 = ((Setup.DecoratorSetup)factory3.Setup).Order;
				int order4 = ((Setup.DecoratorSetup)factory4.Setup).Order;
				if (order3 > order4 || (order3 == order4 && factory3.RegistrationOrder > factory4.RegistrationOrder))
				{
					array[i] = factory3;
					num3++;
				}
				else
				{
					array[i] = factory4;
					num4++;
				}
			}
			else if (num3 < num)
			{
				array[i] = source[num3++];
			}
			else
			{
				array[i] = added[num4++];
			}
		}
		return array;
	}

	KV<object, Factory>[] IContainer.GetServiceRegisteredAndDynamicFactories(Type serviceType)
	{
		ImHashMap<Type, object> value = _registry.Value;
		ImHashMap<Type, object> map = ((!(value is Registry registry)) ? value : registry.Services);
		object valueOrDefault = map.GetValueOrDefault(serviceType);
		KV<object, Factory>[] array = ((valueOrDefault == null) ? ArrayTools.Empty<KV<object, Factory>>() : ((valueOrDefault is Factory value2) ? new KV<object, Factory>(DefaultKey.Value, value2).One() : valueOrDefault.To<FactoriesEntry>().Factories.ToArray((ImHashMapEntry<object, Factory> x) => KV.Of(x.Key, x.Value)).Match((KV<object, Factory> x) => x.Value != null)));
		if (Rules.DynamicRegistrationProviders != null && !serviceType.IsExcludedGeneralPurposeServiceType())
		{
			return CombineRegisteredServiceWithDynamicFactories(array, serviceType, null);
		}
		return array;
	}

	Expression IContainer.GetDecoratorExpressionOrDefault(Request request)
	{
		IContainer container = request.Container;
		if ((!(_registry.Value is Registry registry) || registry.Decorators.IsEmpty) && (container.Rules.DynamicRegistrationProviders == null || !container.Rules.HasDynamicRegistrationProvider(DynamicRegistrationFlags.Decorator)))
		{
			return null;
		}
		Type arrayElementTypeOrNull = request.ServiceType.GetArrayElementTypeOrNull();
		if (arrayElementTypeOrNull != null)
		{
			request = request.WithChangedType(arrayElementTypeOrNull, (Type _, Type et) => typeof(IEnumerable<>).MakeGenericType(et));
		}
		Type serviceType = request.ServiceType;
		Factory[] array = container.GetDecoratorFactoriesOrDefault(serviceType);
		Factory[] array2 = array;
		Type actualServiceType = request.GetActualServiceType();
		if (actualServiceType != serviceType)
		{
			array = MergeSortedByLatestOrderOrRegistration(array, container.GetDecoratorFactoriesOrDefault(actualServiceType));
		}
		int[] array3 = null;
		if (!array.IsNullOrEmpty())
		{
			array3 = GetAppliedDecoratorIDs(request);
			if (array3.Length != 0)
			{
				array = array.Match(array3, delegate(int[] ids, Factory d)
				{
					int factoryID = d.FactoryID;
					for (int i = 0; i < ids.Length; i++)
					{
						if (factoryID == ids[i])
						{
							return false;
						}
					}
					return true;
				});
			}
		}
		Factory[] source = ArrayTools.Empty<Factory>();
		Type genericDefinitionOrNull = serviceType.GetGenericDefinitionOrNull();
		if (genericDefinitionOrNull != null)
		{
			source = container.GetDecoratorFactoriesOrDefault(genericDefinitionOrNull);
		}
		if (actualServiceType != serviceType)
		{
			Type genericDefinitionOrNull2 = actualServiceType.GetGenericDefinitionOrNull();
			if (genericDefinitionOrNull2 != null && genericDefinitionOrNull2 != genericDefinitionOrNull)
			{
				source = MergeSortedByLatestOrderOrRegistration(source, container.GetDecoratorFactoriesOrDefault(genericDefinitionOrNull2));
			}
		}
		Factory[] decoratorFactoriesOrDefault = container.GetDecoratorFactoriesOrDefault(_objectTypeHash, typeof(object));
		if (!decoratorFactoriesOrDefault.IsNullOrEmpty())
		{
			source = MergeSortedByLatestOrderOrRegistration(source, decoratorFactoriesOrDefault.Match(request, (Request r, Factory d) => d.CheckCondition(r)));
		}
		if (!source.IsNullOrEmpty())
		{
			array3 = array3 ?? GetAppliedDecoratorIDs(request);
			if (!array3.IsNullOrEmpty())
			{
				source = source.Match(array3, delegate(int[] appliedDecIds, Factory d)
				{
					ImHashMap<KV<Type, object>, ReflectionFactory> generatedFactories = d.GeneratedFactories;
					if (generatedFactories == null)
					{
						return appliedDecIds.IndexOf(d.FactoryID) == -1;
					}
					foreach (ImHashMapEntry<KV<Type, object>, ReflectionFactory> item in generatedFactories.Enumerate())
					{
						if (appliedDecIds.IndexOf(item.Value.FactoryID) != -1)
						{
							return false;
						}
					}
					return true;
				});
			}
			if (!source.IsNullOrEmpty())
			{
				source = source.Map(request, (Request r, Factory d) => (d.GeneratedFactories != null) ? d.GetGeneratedFactoryOrDefault(r, ifErrorReturnDefault: true) : d).Match((Factory d) => d != null);
				array = MergeSortedByLatestOrderOrRegistration(array, source);
			}
		}
		if (!array.IsNullOrEmpty())
		{
			array = array.Match(request, (Request r, Factory d) => !r.HasRecursiveParent(d.FactoryID));
		}
		if (array.IsNullOrEmpty())
		{
			return null;
		}
		Factory factory = null;
		if (array.Length == 1)
		{
			factory = array[0];
			if (!factory.CheckCondition(request))
			{
				return null;
			}
		}
		else
		{
			Factory[] array4 = array;
			foreach (Factory factory2 in array4)
			{
				if (factory2.CheckCondition(request))
				{
					factory = factory2;
					break;
				}
			}
		}
		Expression expression = factory?.GetExpressionOrDefault(request);
		if (expression == null)
		{
			return null;
		}
		if (arrayElementTypeOrNull != null)
		{
			expression = Expression.Call(WrappersSupport.ToArrayMethod.MakeGenericMethod(arrayElementTypeOrNull), expression);
		}
		return expression;
	}

	private static int[] GetAppliedDecoratorIDs(Request request)
	{
		int factoryID = request.FactoryID;
		int[] array = ArrayTools.Empty<int>();
		Request directParent = request.DirectParent;
		while (!directParent.IsEmpty && directParent.FactoryType != FactoryType.Service)
		{
			if (directParent.FactoryType == FactoryType.Decorator && directParent.DecoratedFactoryID == factoryID)
			{
				array = array.Append(directParent.FactoryID);
			}
			directParent = directParent.DirectParent;
		}
		return array;
	}

	Factory IContainer.GetWrapperFactoryOrDefault(Type serviceType)
	{
		ImHashMap<Type, object> map = ((_registry.Value is Registry registry) ? registry.Wrappers : WrappersSupport.Wrappers);
		object valueOrDefault = map.GetValueOrDefault(serviceType);
		if (valueOrDefault == null)
		{
			serviceType = serviceType.GetGenericDefinitionOrNull();
			if (serviceType != null)
			{
				valueOrDefault = map.GetValueOrDefault(serviceType);
			}
		}
		return valueOrDefault as Factory;
	}

	bool IContainer.IsWrapper(Type serviceType, Type openGenericServiceType)
	{
		if (serviceType.IsArray)
		{
			return true;
		}
		ImHashMap<Type, object> map = ((_registry.Value is Registry registry) ? registry.Wrappers : WrappersSupport.Wrappers);
		if (map.GetValueOrDefault(serviceType) == null)
		{
			if (openGenericServiceType != null)
			{
				return map.GetValueOrDefault(openGenericServiceType) != null;
			}
			return false;
		}
		return true;
	}

	Factory[] IContainer.GetDecoratorFactoriesOrDefault(Type serviceType)
	{
		Factory[] array = ((_registry.Value is Registry registry) ? ((Factory[])registry.Decorators.GetValueOrDefault(serviceType)) : null);
		if (Rules.DynamicRegistrationProviders != null)
		{
			return CombineRegisteredDecoratorWithDynamicFactories(array, serviceType);
		}
		return array;
	}

	Factory[] IContainer.GetDecoratorFactoriesOrDefault(int serviceTypeHash, Type serviceType)
	{
		Factory[] array = ((_registry.Value is Registry registry) ? ((Factory[])registry.Decorators.GetValueOrDefault(serviceTypeHash, serviceType)) : null);
		if (Rules.DynamicRegistrationProviders != null)
		{
			return CombineRegisteredDecoratorWithDynamicFactories(array, serviceType);
		}
		return array;
	}

	Type IContainer.GetWrappedType(Type serviceType, Type requiredServiceType)
	{
		if (requiredServiceType != null && requiredServiceType.IsOpenGeneric())
		{
			return ((IContainer)this).GetWrappedType(serviceType, (Type)null);
		}
		serviceType = requiredServiceType ?? serviceType;
		Type type = serviceType.GetArrayElementTypeOrNull();
		if (type == null)
		{
			Factory wrapperFactoryOrDefault = ((IContainer)this).GetWrapperFactoryOrDefault(serviceType);
			if (wrapperFactoryOrDefault != null)
			{
				type = ((Setup.WrapperSetup)wrapperFactoryOrDefault.Setup).GetWrappedTypeOrNullIfWrapsRequired(serviceType);
			}
		}
		if (!(type == null))
		{
			return ((IContainer)this).GetWrappedType(type);
		}
		return serviceType;
	}

	public Expression GetConstantExpression(object item, Type itemType = null, bool throwIfStateRequired = false)
	{
		if (!throwIfStateRequired && Rules.ConstantExpressionIsFine)
		{
			if (!(itemType == null))
			{
				return Expression.Constant(item, itemType);
			}
			return Expression.Constant(item);
		}
		if (item == null)
		{
			return Expression.ConstantNull(itemType);
		}
		if (item is Type value)
		{
			return Expression.ConstantOf(value);
		}
		if (item is IConvertibleToExpression convertible)
		{
			return ConvertConstantToExpression(convertible, throwIfStateRequired);
		}
		Type type = item.GetType();
		if (type.GetGenericDefinitionOrNull() == typeof(KV<, >))
		{
			Type[] genericArguments = type.GetGenericArguments();
			return Expression.Call(_kvOfMethod.MakeGenericMethod(genericArguments), GetConstantExpression(type.GetField("Key").GetValue(item), genericArguments[0], throwIfStateRequired), GetConstantExpression(type.GetField("Value").GetValue(item), genericArguments[1], throwIfStateRequired));
		}
		if (type.IsPrimitive() || typeof(Type).IsAssignableFrom(type))
		{
			if (!(itemType == null))
			{
				return Expression.Constant(item, itemType);
			}
			return Expression.Constant(item);
		}
		Type arrayElementTypeOrNull = type.GetArrayElementTypeOrNull();
		if (arrayElementTypeOrNull != null && arrayElementTypeOrNull != typeof(object) && (arrayElementTypeOrNull.IsPrimitive() || typeof(Type).IsAssignableFrom(type)))
		{
			return Expression.NewArrayInit(arrayElementTypeOrNull, throwIfStateRequired ? ((object[])item).Map(this, arrayElementTypeOrNull, (Container c, Type t, object x) => c.GetConstantExpression(x, t, throwIfStateRequired: true)) : ((object[])item).Map(this, arrayElementTypeOrNull, (Container c, Type t, object x) => c.GetConstantExpression(x, t)));
		}
		Expression expression = Rules.ItemToExpressionConverter?.Invoke(item, itemType);
		if (expression != null)
		{
			return expression;
		}
		if (throwIfStateRequired || Rules.ThrowIfRuntimeStateRequired)
		{
			Throw.StateIsRequiredToUseItem(item, itemType);
		}
		if (!(itemType == null))
		{
			return Expression.Constant(item, itemType);
		}
		return Expression.Constant(item);
	}

	private Expression ConvertConstantToExpression(IConvertibleToExpression convertible, bool throwIfStateRequired)
	{
		if (!throwIfStateRequired)
		{
			return convertible.ToExpression((object it) => GetConstantExpression(it));
		}
		return convertible.ToExpression((object it) => GetConstantExpression(it, null, throwIfStateRequired: true));
	}

	Type IContainer.GetWrappedType(Type serviceType)
	{
		Type type = serviceType.GetArrayElementTypeOrNull();
		if (type == null)
		{
			Factory wrapperFactoryOrDefault = ((IContainer)this).GetWrapperFactoryOrDefault(serviceType);
			if (wrapperFactoryOrDefault != null)
			{
				type = ((Setup.WrapperSetup)wrapperFactoryOrDefault.Setup).GetWrappedTypeOrNullIfWrapsRequired(serviceType);
			}
		}
		if (!(type == null))
		{
			return ((IContainer)this).GetWrappedType(type);
		}
		return serviceType;
	}

	private Factory GetWrapperFactoryOrDefault(Request request)
	{
		Type type = request.GetActualServiceType();
		Type arrayElementTypeOrNull = type.GetArrayElementTypeOrNull();
		if (arrayElementTypeOrNull != null)
		{
			type = typeof(IEnumerable<>).MakeGenericType(arrayElementTypeOrNull);
		}
		Factory factory = ((IContainer)this).GetWrapperFactoryOrDefault(type);
		if (factory?.GeneratedFactories != null)
		{
			factory = factory.GetGeneratedFactoryOrDefault(request);
		}
		if (factory == null)
		{
			return null;
		}
		Func<Request, bool> condition = factory.Setup.Condition;
		if (condition != null && !condition(request))
		{
			return null;
		}
		return factory;
	}

	private KV<object, Factory>[] CombineRegisteredServiceWithDynamicFactories(KV<object, Factory>[] factories, Type serviceType, Type openGenericServiceType, object serviceKey = null)
	{
		DynamicRegistrationFlags dynamicRegistrationFlags = DynamicRegistrationFlags.Service;
		DynamicRegistrationFlags dynamicRegistrationFlags2 = ((factories.Length != 0) ? DynamicRegistrationFlags.AsFallback : DynamicRegistrationFlags.NoFlags);
		DefaultDynamicKey defaultDynamicKey = null;
		DynamicRegistrationFlags[] dynamicRegistrationFlags3 = Rules.DynamicRegistrationFlags;
		for (int i = 0; i < dynamicRegistrationFlags3.Length; i++)
		{
			DynamicRegistrationFlags dynamicRegistrationFlags4 = dynamicRegistrationFlags3[i];
			if ((dynamicRegistrationFlags4 & dynamicRegistrationFlags) != dynamicRegistrationFlags || (dynamicRegistrationFlags4 & dynamicRegistrationFlags2) != DynamicRegistrationFlags.NoFlags)
			{
				continue;
			}
			Rules.DynamicRegistrationProvider dynamicRegistrationProvider = Rules.DynamicRegistrationProviders[i];
			DynamicRegistration[] array = dynamicRegistrationProvider(serviceType, serviceKey).ToArrayOrSelf();
			while (true)
			{
				if (array.Length != 0)
				{
					if (factories.Length == 0)
					{
						DynamicRegistration[] array2 = array;
						foreach (DynamicRegistration dynamicRegistration in array2)
						{
							Factory factory = dynamicRegistration.Factory;
							if (factory.FactoryType == FactoryType.Service && factory.ValidateAndNormalizeRegistration(serviceType, serviceKey, isStaticallyChecked: false, Rules, throwIfInvalid: true))
							{
								KV<object, Factory>[] source = factories;
								object obj = dynamicRegistration.ServiceKey;
								if (obj == null)
								{
									obj = defaultDynamicKey?.Next() ?? DefaultDynamicKey.Value;
									defaultDynamicKey = (DefaultDynamicKey)obj;
								}
								factories = source.Append(KV.Of(obj, factory));
							}
						}
					}
					else
					{
						DynamicRegistration[] array3 = array;
						foreach (DynamicRegistration dynamicRegistration2 in array3)
						{
							Factory factory2 = dynamicRegistration2.Factory;
							if (factory2.FactoryType != FactoryType.Service || !factory2.ValidateAndNormalizeRegistration(serviceType, serviceKey, isStaticallyChecked: false, Rules, throwIfInvalid: true))
							{
								continue;
							}
							if (dynamicRegistration2.ServiceKey == null)
							{
								switch (dynamicRegistration2.IfAlreadyRegistered)
								{
								case IfAlreadyRegistered.Throw:
								case IfAlreadyRegistered.Keep:
									if (factories.IndexOf((KV<object, Factory> f) => f.Key is DefaultKey || f.Key is DefaultDynamicKey) != -1)
									{
										continue;
									}
									break;
								case IfAlreadyRegistered.Replace:
									factories = factories.Match((KV<object, Factory> f) => !(f.Key is DefaultKey) && !(f.Key is DefaultDynamicKey));
									break;
								case IfAlreadyRegistered.AppendNewImplementation:
									if (factory2.CanAccessImplementationType && factories.IndexOf(factory2.ImplementationType, (Type it, KV<object, Factory> f) => f.Value.CanAccessImplementationType && f.Value.ImplementationType == it) != -1)
									{
										continue;
									}
									break;
								}
							}
							else
							{
								IfAlreadyRegistered ifAlreadyRegistered = dynamicRegistration2.IfAlreadyRegistered;
								if (ifAlreadyRegistered == IfAlreadyRegistered.Replace)
								{
									factories = factories.Match(dynamicRegistration2.ServiceKey, (object obj3, KV<object, Factory> f) => !f.Key.Equals(obj3));
								}
								else if (factories.IndexOf(dynamicRegistration2.ServiceKey, (object obj3, KV<object, Factory> f) => f.Key.Equals(obj3)) != -1)
								{
									continue;
								}
							}
							KV<object, Factory>[] source2 = factories;
							object obj2 = dynamicRegistration2.ServiceKey;
							if (obj2 == null)
							{
								obj2 = defaultDynamicKey?.Next() ?? DefaultDynamicKey.Value;
								defaultDynamicKey = (DefaultDynamicKey)obj2;
							}
							factories = source2.Append(KV.Of(obj2, factory2));
						}
					}
				}
				if (!(openGenericServiceType != null))
				{
					break;
				}
				array = dynamicRegistrationProvider(openGenericServiceType, serviceKey).ToArrayOrSelf();
				openGenericServiceType = null;
			}
		}
		return factories;
	}

	private KV<object, Factory>[] CombineRegisteredServiceWithDynamicFactories(KV<object, Factory>[] factories, Type serviceType, Type openGenericServiceType)
	{
		DynamicRegistrationFlags dynamicRegistrationFlags = DynamicRegistrationFlags.Service;
		DynamicRegistrationFlags dynamicRegistrationFlags2 = ((factories.Length != 0) ? DynamicRegistrationFlags.AsFallback : DynamicRegistrationFlags.NoFlags);
		DefaultDynamicKey defaultDynamicKey = null;
		DynamicRegistrationFlags[] dynamicRegistrationFlags3 = Rules.DynamicRegistrationFlags;
		for (int i = 0; i < dynamicRegistrationFlags3.Length; i++)
		{
			DynamicRegistrationFlags dynamicRegistrationFlags4 = dynamicRegistrationFlags3[i];
			if ((dynamicRegistrationFlags4 & dynamicRegistrationFlags) != dynamicRegistrationFlags || (dynamicRegistrationFlags4 & dynamicRegistrationFlags2) != DynamicRegistrationFlags.NoFlags)
			{
				continue;
			}
			Rules.DynamicRegistrationProvider dynamicRegistrationProvider = Rules.DynamicRegistrationProviders[i];
			DynamicRegistration[] array = dynamicRegistrationProvider(serviceType, null).ToArrayOrSelf();
			while (true)
			{
				if (array.Length != 0)
				{
					if (factories.Length == 0)
					{
						DynamicRegistration[] array2 = array;
						foreach (DynamicRegistration dynamicRegistration in array2)
						{
							Factory factory = dynamicRegistration.Factory;
							if (factory.FactoryType == FactoryType.Service && factory.ValidateAndNormalizeRegistration(serviceType, null, isStaticallyChecked: false, Rules, throwIfInvalid: true))
							{
								KV<object, Factory>[] source = factories;
								object obj = dynamicRegistration.ServiceKey;
								if (obj == null)
								{
									obj = defaultDynamicKey?.Next() ?? DefaultDynamicKey.Value;
									defaultDynamicKey = (DefaultDynamicKey)obj;
								}
								factories = source.Append(KV.Of(obj, factory));
							}
						}
					}
					else
					{
						DynamicRegistration[] array3 = array;
						foreach (DynamicRegistration dynamicRegistration2 in array3)
						{
							Factory factory2 = dynamicRegistration2.Factory;
							if (factory2.FactoryType != FactoryType.Service || !factory2.ValidateAndNormalizeRegistration(serviceType, null, isStaticallyChecked: false, Rules, throwIfInvalid: true))
							{
								continue;
							}
							if (dynamicRegistration2.ServiceKey == null)
							{
								switch (dynamicRegistration2.IfAlreadyRegistered)
								{
								case IfAlreadyRegistered.Throw:
								case IfAlreadyRegistered.Keep:
									if (factories.IndexOf((KV<object, Factory> f) => f.Key is DefaultKey || f.Key is DefaultDynamicKey) != -1)
									{
										continue;
									}
									break;
								case IfAlreadyRegistered.Replace:
									factories = factories.Match((KV<object, Factory> f) => !(f.Key is DefaultKey) && !(f.Key is DefaultDynamicKey));
									break;
								case IfAlreadyRegistered.AppendNewImplementation:
									if (factory2.CanAccessImplementationType && factories.IndexOf(factory2.ImplementationType, (Type it, KV<object, Factory> f) => f.Value.CanAccessImplementationType && f.Value.ImplementationType == it) != -1)
									{
										continue;
									}
									break;
								}
							}
							else
							{
								IfAlreadyRegistered ifAlreadyRegistered = dynamicRegistration2.IfAlreadyRegistered;
								if (ifAlreadyRegistered == IfAlreadyRegistered.Replace)
								{
									factories = factories.Match(dynamicRegistration2.ServiceKey, (object obj3, KV<object, Factory> f) => !f.Key.Equals(obj3));
								}
								else if (factories.IndexOf(dynamicRegistration2.ServiceKey, (object obj3, KV<object, Factory> f) => f.Key.Equals(obj3)) != -1)
								{
									continue;
								}
							}
							KV<object, Factory>[] source2 = factories;
							object obj2 = dynamicRegistration2.ServiceKey;
							if (obj2 == null)
							{
								obj2 = defaultDynamicKey?.Next() ?? DefaultDynamicKey.Value;
								defaultDynamicKey = (DefaultDynamicKey)obj2;
							}
							factories = source2.Append(KV.Of(obj2, factory2));
						}
					}
				}
				if (!(openGenericServiceType != null))
				{
					break;
				}
				array = dynamicRegistrationProvider(openGenericServiceType, null).ToArrayOrSelf();
				openGenericServiceType = null;
			}
		}
		return factories;
	}

	private Factory[] CombineRegisteredDecoratorWithDynamicFactories(Factory[] factories, Type serviceType)
	{
		DynamicRegistrationFlags dynamicRegistrationFlags = DynamicRegistrationFlags.Decorator;
		if (serviceType == typeof(object))
		{
			dynamicRegistrationFlags |= DynamicRegistrationFlags.DecoratorOfAnyTypeViaObjectServiceType;
		}
		DynamicRegistrationFlags dynamicRegistrationFlags2 = ((factories != null) ? DynamicRegistrationFlags.AsFallback : DynamicRegistrationFlags.NoFlags);
		DynamicRegistrationFlags[] dynamicRegistrationFlags3 = Rules.DynamicRegistrationFlags;
		for (int i = 0; i < dynamicRegistrationFlags3.Length; i++)
		{
			DynamicRegistrationFlags dynamicRegistrationFlags4 = dynamicRegistrationFlags3[i];
			if ((dynamicRegistrationFlags4 & dynamicRegistrationFlags) != dynamicRegistrationFlags || (dynamicRegistrationFlags4 & dynamicRegistrationFlags2) != DynamicRegistrationFlags.NoFlags)
			{
				continue;
			}
			Rules.DynamicRegistrationProvider dynamicRegistrationProvider = Rules.DynamicRegistrationProviders[i];
			DynamicRegistration[] array = dynamicRegistrationProvider(serviceType, null).ToArrayOrSelf();
			if (array.IsNullOrEmpty())
			{
				continue;
			}
			if (factories.IsNullOrEmpty())
			{
				DynamicRegistration[] array2 = array;
				foreach (DynamicRegistration dynamicRegistration in array2)
				{
					Factory factory = dynamicRegistration.Factory;
					if (factory.FactoryType == FactoryType.Decorator && factory.ValidateAndNormalizeRegistration(serviceType, null, isStaticallyChecked: false, Rules, throwIfInvalid: true))
					{
						factories = factories.Append(factory);
					}
				}
				continue;
			}
			DynamicRegistration[] array3 = array;
			foreach (DynamicRegistration dynamicRegistration2 in array3)
			{
				Factory factory2 = dynamicRegistration2.Factory;
				if (factory2.FactoryType != FactoryType.Decorator || !factory2.ValidateAndNormalizeRegistration(serviceType, null, isStaticallyChecked: false, Rules, throwIfInvalid: true))
				{
					continue;
				}
				switch (dynamicRegistration2.IfAlreadyRegistered)
				{
				case IfAlreadyRegistered.Replace:
					factories = ArrayTools.Empty<Factory>();
					break;
				case IfAlreadyRegistered.AppendNewImplementation:
					if (factory2.CanAccessImplementationType && factories.IndexOf(factory2.ImplementationType, (Type it, Factory f) => f.CanAccessImplementationType && f.ImplementationType == it) != -1)
					{
						continue;
					}
					break;
				case IfAlreadyRegistered.Throw:
				case IfAlreadyRegistered.Keep:
					continue;
				}
				factories = factories.Append(factory2);
			}
		}
		return factories;
	}

	internal void TryCacheDefaultFactory<T>(int serviceTypeHash, Type serviceType, T factory)
	{
		ImHashMap<Type, object> value = _registry.Value;
		Registry registry = value as Registry;
		if (!(registry?.Services.IsEmpty ?? value.IsEmpty))
		{
			Registry.AndCache andCache = (Registry.AndCache)((registry as Registry.AndCache)?.WithDefaultFactoryCache() ?? ((Registry.AndCache)_registry.SwapAndGetNewValue(0, (ImHashMap<Type, object> r, int _) => ((r as Registry) ?? new Registry(r)).WithDefaultFactoryCache())));
			andCache.TryCacheDefaultFactory(serviceTypeHash, serviceType, factory);
		}
	}

	internal void TryCacheKeyedFactory(int serviceTypeHash, Type serviceType, object key, object factory)
	{
		ImHashMap<Type, object> value = _registry.Value;
		Registry registry = value as Registry;
		if (!(registry?.Services.IsEmpty ?? value.IsEmpty))
		{
			Registry.AndCache andCache = (Registry.AndCache)((registry as Registry.AndCache)?.WithKeyedFactoryCache() ?? ((Registry.AndCache)_registry.SwapAndGetNewValue(0, (ImHashMap<Type, object> r, int _) => ((r as Registry) ?? new Registry(r)).WithKeyedFactoryCache())));
			andCache.TryCacheKeyedFactory(serviceTypeHash, serviceType, key, factory);
		}
	}

	internal void CacheFactoryExpression(int factoryId, Expression expr, IReuse reuse, int dependencyCount, ImMapEntry<object> entry = null)
	{
		Registry.AndCache andCache = (Registry.AndCache)((_registry.Value as Registry.AndCache)?.WithFactoryExpressionCache() ?? ((Registry.AndCache)_registry.SwapAndGetNewValue(0, (ImHashMap<Type, object> r, int _) => ((r as Registry) ?? new Registry(r)).WithFactoryExpressionCache())));
		andCache.CacheFactoryExpression(factoryId, expr, reuse, dependencyCount, entry);
	}

	private Container(Rules rules, Ref<ImHashMap<Type, object>> registry, IScope singletonScope, IScopeContext scopeContext = null, IScope ownCurrentScope = null, int disposed = 0, StackTrace disposeStackTrace = null, IResolverContext parent = null)
	{
		Rules = rules;
		_registry = registry;
		_singletonScope = singletonScope;
		_scopeContext = scopeContext;
		_ownCurrentScope = ownCurrentScope;
		_disposed = disposed;
		_disposeStackTrace = disposeStackTrace;
		_parent = parent;
	}

	private void SetInitialFactoryID()
	{
		int lastFactoryID = 0;
		GetLastGeneratedFactoryID(ref lastFactoryID);
		if (lastFactoryID > Factory._lastFactoryID)
		{
			Factory._lastFactoryID = lastFactoryID + 1;
		}
	}

	private IEnumerable<ResolveManyResult> ResolveManyGenerated(Type serviceType)
	{
		if (serviceType == typeof(IService))
		{
			yield return ResolveManyResult.Of(Get_IService_0);
		}
	}

	internal static object Get_IService_0(IResolverContext r)
	{
		return new MyService(new DependencyA(), (DependencyB<string>)r.Resolve(typeof(DependencyB<string>), null, IfUnresolved.Throw, null, Request.Empty.Push(typeof(IService), 711, typeof(MyService), Reuse.Transient, RequestFlags.IsResolutionCall | RequestFlags.StopRecursiveDependencyCheck), null), (RuntimeDependencyC)r.Resolve(typeof(RuntimeDependencyC), null, IfUnresolved.Throw, null, Request.Empty.Push(typeof(IService), 711, typeof(MyService), Reuse.Transient, RequestFlags.IsResolutionCall | RequestFlags.StopRecursiveDependencyCheck), null));
	}

	internal static object GetDependency_DependencyB_0(IResolverContext r)
	{
		return new DependencyB<string>();
	}
}
