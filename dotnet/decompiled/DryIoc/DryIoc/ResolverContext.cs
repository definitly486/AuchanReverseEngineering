using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public static class ResolverContext
{
	internal sealed class ResolverContextPropertyParamExpression : PropertyExpression
	{
		public override Expression Expression => FactoryDelegateCompiler.ResolverContextParamExpr;

		internal ResolverContextPropertyParamExpression(PropertyInfo property)
			: base(property)
		{
		}
	}

	internal sealed class ResolverContextArgMethodCallExpression : MethodCallExpression
	{
		public override MethodInfo Method { get; }

		public override int ArgumentCount => 1;

		public override IReadOnlyList<Expression> Arguments => FactoryDelegateCompiler.ResolverContextParamExprs;

		public override bool IsIntrinsic => true;

		public override Expression GetArgument(int i)
		{
			return FactoryDelegateCompiler.ResolverContextParamExpr;
		}

		public ResolverContextArgMethodCallExpression(MethodInfo method)
		{
			Method = method;
		}

		public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
		{
			return ExpressionCompiler.TryCollectBoundConstants(ref closure, FactoryDelegateCompiler.ResolverContextParamExpr, paramExprs, isNestedLambda, ref rootClosure, config);
		}

		public override bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
		{
			if (ExpressionCompiler.EmittingVisitor.TryEmitNonByRefNonValueTypeParameter(FactoryDelegateCompiler.ResolverContextParamExpr, paramExprs, il, ref closure))
			{
				return ExpressionCompiler.EmittingVisitor.EmitMethodCall(il, Method);
			}
			return false;
		}
	}

	internal static readonly MethodInfo OpenScopeMethod = typeof(ResolverContext).GetMethod("OpenScope", new Type[3]
	{
		typeof(IResolverContext),
		typeof(object),
		typeof(bool)
	});

	public static readonly Expression RootOrSelfExpr = new ResolverContextArgMethodCallExpression(typeof(ResolverContext).GetMethod("RootOrSelf"));

	public static readonly PropertyExpression SingletonScopeExpr = new ResolverContextPropertyParamExpression(typeof(IResolverContext).GetProperty("SingletonScope"));

	public static readonly PropertyExpression CurrentScopeExpr = new ResolverContextPropertyParamExpression(typeof(IResolverContext).GetProperty("CurrentScope"));

	public static readonly PropertyExpression CurrentOrSingletonScopeExpr = new ResolverContextPropertyParamExpression(typeof(IResolverContext).GetProperty("CurrentOrSingletonScope"));

	public static readonly MethodCallExpression GetCurrentScopeOrThrowExpr = new ResolverContextArgMethodCallExpression(typeof(ResolverContext).GetMethod("GetCurrentScopeOrThrow"));

	public static IResolverContext RootOrSelf(this IResolverContext r)
	{
		return r.Root ?? r;
	}

	public static Expression GetRootOrSelfExpr(Request request)
	{
		if (request.Reuse is CurrentScopeReuse || !request.DirectParent.IsSingletonOrDependencyOfSingleton || !request.Rules.ThrowIfDependencyHasShorterReuseLifespan || request.OpensResolutionScopeUpToResolutionCall())
		{
			return FactoryDelegateCompiler.ResolverContextParamExpr;
		}
		return RootOrSelfExpr;
	}

	private static bool OpensResolutionScopeUpToResolutionCall(this Request r)
	{
		for (Request directParent = r.DirectParent; directParent != null; directParent = directParent.DirectParent)
		{
			if ((directParent.Flags & RequestFlags.OpensResolutionScope) != RequestFlags.Default)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsScoped(this IResolverContext r)
	{
		return r.Parent != null;
	}

	public static IScope GetCurrentScopeOrThrow(this IResolverContext r)
	{
		return r.CurrentScope ?? Throw.For<IScope>(Error.NoCurrentScope, r);
	}

	public static IScope GetCurrentScope(this IResolverContext r, bool throwIfNotFound)
	{
		IScope scope = r.CurrentScope;
		if (scope == null)
		{
			if (!throwIfNotFound)
			{
				return null;
			}
			scope = Throw.For<IScope>(Error.NoCurrentScope, r);
		}
		return scope;
	}

	public static IScope GetNamedScope(this IResolverContext r, object name, bool throwIfNotFound)
	{
		IScope currentScope = r.CurrentScope;
		if (currentScope == null)
		{
			if (!throwIfNotFound)
			{
				return null;
			}
			return Throw.For<IScope>(Error.NoCurrentScope, r);
		}
		IScope scope = currentScope;
		if (name != null)
		{
			if (name is IScopeName scopeName)
			{
				while (scope != null && !scopeName.Match(scope.Name))
				{
					scope = scope.Parent;
				}
			}
			else
			{
				while (scope != null && name != scope.Name && !name.Equals(scope.Name))
				{
					scope = scope.Parent;
				}
			}
		}
		if (scope == null)
		{
			if (!throwIfNotFound)
			{
				return null;
			}
			return Throw.For<Scope>(Error.NoMatchedScopeFound, name, currentScope);
		}
		if (scope.IsDisposed)
		{
			if (throwIfNotFound)
			{
				Throw.ScopeIsDisposed(scope, r);
			}
			return null;
		}
		return scope;
	}

	public static IResolverContext OpenScope(this IResolverContext r, object name, bool trackInParent = false)
	{
		if (r.ScopeContext == null)
		{
			IScope ownCurrentScope = r.OwnCurrentScope;
			IScope scope = Scope.Of(ownCurrentScope, name);
			if (trackInParent)
			{
				(ownCurrentScope ?? r.SingletonScope).TrackDisposable(scope);
			}
			return r.WithCurrentScope(scope);
		}
		IScope scope2 = ((name == null) ? r.ScopeContext.SetCurrent((IScope parent) => Scope.Of(parent)) : r.ScopeContext.SetCurrent((IScope parent) => Scope.Of(parent, name)));
		if (trackInParent)
		{
			(scope2.Parent ?? r.SingletonScope).TrackDisposable(scope2);
		}
		return r.WithCurrentScope(null);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IResolverContext OpenScope(this IResolverContext r)
	{
		if (r.ScopeContext != null)
		{
			return r.OpenScope(null);
		}
		return r.WithCurrentScope(Scope.Of(r.OwnCurrentScope));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsUsed(this IResolverContext r, Type serviceType)
	{
		int hashCode = RuntimeHelpers.GetHashCode(serviceType);
		IScope currentScope = r.CurrentScope;
		if (currentScope == null || !currentScope.TryGetUsed(hashCode, serviceType, out var instance))
		{
			return r.SingletonScope.TryGetUsed(hashCode, serviceType, out instance);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsUsed<TService>(this IResolverContext r)
	{
		return r.IsUsed(typeof(TService));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetUsedInstance(this IResolverContext r, int serviceTypeHash, Type serviceType, out object instance)
	{
		IScope currentScope = r.CurrentScope;
		if ((currentScope != null && currentScope.TryGetUsed(serviceTypeHash, serviceType, out var instance2)) || r.SingletonScope.TryGetUsed(serviceTypeHash, serviceType, out instance2))
		{
			instance = ((instance2 is FactoryDelegate factoryDelegate) ? factoryDelegate(r) : instance2);
			return true;
		}
		instance = null;
		return false;
	}

	public static T TrackDisposable<T>(this IResolverContext r, T instance, int disposalOrder = 0) where T : IDisposable
	{
		return r.CurrentOrSingletonScope.TrackDisposable(instance, disposalOrder);
	}
}
