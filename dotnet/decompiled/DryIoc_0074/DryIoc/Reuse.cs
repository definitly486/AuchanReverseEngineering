using System;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public static class Reuse
{
	private sealed class TransientReuse : IReuse, IConvertibleToExpression
	{
		private readonly Lazy<Expression> _transientReuseExpr = Lazy.Of((Func<Expression>)(() => Expression.Field(null, typeof(Reuse).GetField("Transient"))));

		public int Lifespan => 0;

		public object Name => null;

		public Expression Apply(Request _, Expression serviceFactoryExpr)
		{
			return serviceFactoryExpr;
		}

		public bool CanApply(Request request)
		{
			return true;
		}

		public Expression ToExpression(Func<object, Expression> fallbackConverter)
		{
			return _transientReuseExpr.Value;
		}

		public override string ToString()
		{
			return "TransientReuse";
		}
	}

	public static readonly IReuse Transient = new TransientReuse();

	public static readonly IReuse Singleton = new SingletonReuse();

	public static readonly IReuse Scoped = new CurrentScopeReuse();

	public static readonly IReuse ScopedOrSingleton = new CurrentScopeReuse(null, scopedOrSingleton: true);

	[Obsolete("The same as Reuse.Scoped, please prefer to use Reuse.Scoped or the Reuse.ScopedTo to specify a bound service.")]
	public static readonly IReuse InResolutionScope = Scoped;

	public static readonly IReuse InCurrentScope = Scoped;

	public static readonly IReuse InThread = Scoped;

	public static string WebRequestScopeName = "~WebRequestScopeName";

	public static readonly IReuse InWebRequest = ScopedTo(WebRequestScopeName);

	public static IReuse ScopedTo(object name)
	{
		return new CurrentScopeReuse(name);
	}

	public static IReuse ScopedTo(object name, bool scopedOrSingleton, int lifespan)
	{
		return new CurrentScopeReuse(name, scopedOrSingleton, lifespan);
	}

	public static IReuse ScopedTo(params object[] names)
	{
		if (!names.IsNullOrEmpty())
		{
			if (names.Length != 1)
			{
				return new CurrentScopeReuse(CompositeScopeName.Of(names));
			}
			return ScopedTo(names[0]);
		}
		return Scoped;
	}

	[Obsolete("Use ScopedToService to prevent ambiguity with the ScopeTo(object name) where name is the Type")]
	public static IReuse ScopedTo(Type serviceType = null, object serviceKey = null)
	{
		if (!(serviceType == null) || serviceKey != null)
		{
			return new CurrentScopeReuse(ResolutionScopeName.Of(serviceType, serviceKey));
		}
		return Scoped;
	}

	public static IReuse ScopedToService(Type serviceType = null, object serviceKey = null)
	{
		if (!(serviceType == null) || serviceKey != null)
		{
			return new CurrentScopeReuse(ResolutionScopeName.Of(serviceType, serviceKey));
		}
		return Scoped;
	}

	public static IReuse ScopedTo<TService>(object serviceKey = null)
	{
		return ScopedToService(typeof(TService), serviceKey);
	}

	public static IReuse ScopedToService<TService>(object serviceKey = null)
	{
		return ScopedToService(typeof(TService), serviceKey);
	}

	public static IReuse InCurrentNamedScope(object name = null)
	{
		return ScopedTo(name);
	}

	[Obsolete("Please use `ScopedToService` instead")]
	public static IReuse InResolutionScopeOf(Type assignableFromServiceType = null, object serviceKey = null)
	{
		return ScopedToService(assignableFromServiceType, serviceKey);
	}

	[Obsolete("Please use `ScopedToService` instead.")]
	public static IReuse InResolutionScopeOf<TAssignableFromServiceType>(object serviceKey = null)
	{
		return ScopedToService<TAssignableFromServiceType>(serviceKey);
	}
}
