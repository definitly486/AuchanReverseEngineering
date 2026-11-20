using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public sealed class CurrentScopeReuse : IReuse, IConvertibleToExpression
{
	internal class GetScopedOrSingletonViaFactoryDelegateExpression : DryIoc.FastExpressionCompiler.LightExpression.MethodCallExpression
	{
		public readonly int FactoryId;

		public readonly DryIoc.FastExpressionCompiler.LightExpression.Expression ServiceFactoryExpr;

		public override DryIoc.FastExpressionCompiler.LightExpression.Expression Object => ResolverContext.CurrentOrSingletonScopeExpr;

		public override MethodInfo Method => Scope.GetOrAddViaFactoryDelegateMethod;

		public DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression FactoryIdExpr => DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantInt(FactoryId);

		public override int ArgumentCount => 3;

		public override IReadOnlyList<DryIoc.FastExpressionCompiler.LightExpression.Expression> Arguments => new DryIoc.FastExpressionCompiler.LightExpression.Expression[3]
		{
			FactoryIdExpr,
			ServiceFactoryExpr,
			FactoryDelegateCompiler.ResolverContextParamExpr
		};

		public override bool IsIntrinsic => true;

		public override DryIoc.FastExpressionCompiler.LightExpression.Expression GetArgument(int i)
		{
			return i switch
			{
				1 => ServiceFactoryExpr, 
				0 => FactoryIdExpr, 
				_ => FactoryDelegateCompiler.ResolverContextParamExpr, 
			};
		}

		internal GetScopedOrSingletonViaFactoryDelegateExpression(int factoryId, DryIoc.FastExpressionCompiler.LightExpression.Expression createValueExpr)
		{
			FactoryId = factoryId;
			ServiceFactoryExpr = createValueExpr;
		}

		public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
		{
			if (ExpressionCompiler.TryCollectBoundConstants(ref closure, FactoryDelegateCompiler.ResolverContextParamExpr, paramExprs, isNestedLambda, ref rootClosure, config))
			{
				return ExpressionCompiler.TryCollectBoundConstants(ref closure, ServiceFactoryExpr, paramExprs, isNestedLambda, ref rootClosure, config);
			}
			return false;
		}

		public override bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
		{
			ExpressionCompiler.EmittingVisitor.TryEmit(Object, paramExprs, il, ref closure, config, parent);
			ExpressionCompiler.EmittingVisitor.EmitLoadConstantInt(il, FactoryId);
			if (!ExpressionCompiler.EmittingVisitor.TryEmit(ServiceFactoryExpr, paramExprs, il, ref closure, config, parent))
			{
				return false;
			}
			ExpressionCompiler.EmittingVisitor.TryEmitNonByRefNonValueTypeParameter(FactoryDelegateCompiler.ResolverContextParamExpr, paramExprs, il, ref closure);
			return ExpressionCompiler.EmittingVisitor.EmitVirtualMethodCall(il, Scope.GetOrAddViaFactoryDelegateMethod);
		}
	}

	internal class GetScopedOrSingletonViaFactoryDelegateWithDisposalOrderExpression : GetScopedOrSingletonViaFactoryDelegateExpression
	{
		public readonly int DisposalOrder;

		public override MethodInfo Method => Scope.GetOrAddViaFactoryDelegateWithDisposalOrderMethod;

		public DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression DisposalOrderExpr => DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantInt(DisposalOrder);

		public override int ArgumentCount => 4;

		public override IReadOnlyList<DryIoc.FastExpressionCompiler.LightExpression.Expression> Arguments => new DryIoc.FastExpressionCompiler.LightExpression.Expression[4]
		{
			base.FactoryIdExpr,
			ServiceFactoryExpr,
			FactoryDelegateCompiler.ResolverContextParamExpr,
			DisposalOrderExpr
		};

		public override bool IsIntrinsic => false;

		public override DryIoc.FastExpressionCompiler.LightExpression.Expression GetArgument(int i)
		{
			return i switch
			{
				2 => FactoryDelegateCompiler.ResolverContextParamExpr, 
				1 => ServiceFactoryExpr, 
				0 => base.FactoryIdExpr, 
				_ => DisposalOrderExpr, 
			};
		}

		internal GetScopedOrSingletonViaFactoryDelegateWithDisposalOrderExpression(int factoryId, DryIoc.FastExpressionCompiler.LightExpression.Expression createValueExpr, int disposalOrder)
			: base(factoryId, createValueExpr)
		{
			DisposalOrder = disposalOrder;
		}
	}

	internal sealed class GetScopedViaFactoryDelegateExpression : GetScopedOrSingletonViaFactoryDelegateExpression
	{
		public readonly bool ThrowIfNoScope;

		public override DryIoc.FastExpressionCompiler.LightExpression.Expression Object
		{
			get
			{
				if (!ThrowIfNoScope)
				{
					return ResolverContext.CurrentScopeExpr;
				}
				return ResolverContext.GetCurrentScopeOrThrowExpr;
			}
		}

		public DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression ThrowIfNoScopeExpr => DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(ThrowIfNoScope);

		internal GetScopedViaFactoryDelegateExpression(bool throwIfNoScope, int factoryId, DryIoc.FastExpressionCompiler.LightExpression.Expression createValueExpr)
			: base(factoryId, createValueExpr)
		{
			ThrowIfNoScope = throwIfNoScope;
		}
	}

	internal sealed class GetScopedViaFactoryDelegateWithDisposalOrderExpression : GetScopedOrSingletonViaFactoryDelegateWithDisposalOrderExpression
	{
		public readonly bool ThrowIfNoScope;

		public override DryIoc.FastExpressionCompiler.LightExpression.Expression Object
		{
			get
			{
				if (!ThrowIfNoScope)
				{
					return ResolverContext.CurrentScopeExpr;
				}
				return ResolverContext.GetCurrentScopeOrThrowExpr;
			}
		}

		public DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression ThrowIfNoScopeExpr => DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(ThrowIfNoScope);

		internal GetScopedViaFactoryDelegateWithDisposalOrderExpression(bool throwIfNoScope, int factoryId, DryIoc.FastExpressionCompiler.LightExpression.Expression serviceFactoryExpr, int disposalOrder)
			: base(factoryId, serviceFactoryExpr, disposalOrder)
		{
			ThrowIfNoScope = throwIfNoScope;
		}
	}

	public const int DefaultLifespan = 100;

	public readonly bool ScopedOrSingleton;

	internal static readonly MethodInfo GetScopedViaFactoryDelegateWithDisposalOrderMethod = typeof(CurrentScopeReuse).GetMethod("GetScopedViaFactoryDelegateWithDisposalOrder");

	internal static readonly MethodInfo GetNameScopedViaFactoryDelegateMethod = typeof(CurrentScopeReuse).GetMethod("GetNameScopedViaFactoryDelegate");

	internal static readonly MethodInfo TrackScopedOrSingletonMethod = typeof(CurrentScopeReuse).GetMethod("TrackScopedOrSingleton");

	internal static readonly MethodInfo TrackScopedMethod = typeof(CurrentScopeReuse).GetMethod("TrackScoped");

	internal static readonly MethodInfo TrackNameScopedMethod = typeof(CurrentScopeReuse).GetMethod("TrackNameScoped");

	public int Lifespan { get; }

	public object Name { get; }

	public bool CanApply(Request request)
	{
		if (!ScopedOrSingleton)
		{
			return request.Container.GetNamedScope(Name, throwIfNotFound: false) != null;
		}
		return true;
	}

	public DryIoc.FastExpressionCompiler.LightExpression.Expression Apply(Request request, DryIoc.FastExpressionCompiler.LightExpression.Expression serviceFactoryExpr)
	{
		if (serviceFactoryExpr.NodeType == ExpressionType.Convert)
		{
			serviceFactoryExpr = ((DryIoc.FastExpressionCompiler.LightExpression.UnaryExpression)serviceFactoryExpr).Operand;
		}
		if (serviceFactoryExpr.Type.IsValueType)
		{
			serviceFactoryExpr = DryIoc.FastExpressionCompiler.LightExpression.Expression.Convert<object>(serviceFactoryExpr);
		}
		if (request.TracksTransientDisposable)
		{
			if (ScopedOrSingleton)
			{
				return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(TrackScopedOrSingletonMethod, FactoryDelegateCompiler.ResolverContextParamExpr, serviceFactoryExpr);
			}
			DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression = DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(request.IfUnresolved == IfUnresolved.Throw);
			if (Name == null)
			{
				return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(TrackScopedMethod, FactoryDelegateCompiler.ResolverContextParamExpr, constantExpression, serviceFactoryExpr);
			}
			DryIoc.FastExpressionCompiler.LightExpression.Expression constantExpression2 = request.Container.GetConstantExpression(Name, typeof(object));
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(TrackNameScopedMethod, FactoryDelegateCompiler.ResolverContextParamExpr, constantExpression2, constantExpression, serviceFactoryExpr);
		}
		int num = ((request.FactoryType == FactoryType.Decorator) ? request.CombineDecoratorWithDecoratedFactoryID() : request.FactoryID);
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression2;
		if (serviceFactoryExpr is DryIoc.FastExpressionCompiler.LightExpression.InvocationExpression { Expression: DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression expression } && expression.Type == typeof(FactoryDelegate))
		{
			expression2 = expression;
		}
		else
		{
			if (request.DependencyCount > 0)
			{
				request.DecreaseTrackedDependencyCountForParents(request.DependencyCount);
			}
			expression2 = new FactoryDelegateExpression(serviceFactoryExpr);
		}
		int disposalOrder = request.Factory.Setup.DisposalOrder;
		if (ScopedOrSingleton)
		{
			if (disposalOrder != 0)
			{
				return new GetScopedOrSingletonViaFactoryDelegateWithDisposalOrderExpression(num, expression2, disposalOrder);
			}
			return new GetScopedOrSingletonViaFactoryDelegateExpression(num, expression2);
		}
		bool flag = request.IfUnresolved == IfUnresolved.Throw;
		if (Name == null)
		{
			if (disposalOrder != 0)
			{
				return new GetScopedViaFactoryDelegateWithDisposalOrderExpression(flag, num, expression2, disposalOrder);
			}
			return new GetScopedViaFactoryDelegateExpression(flag, num, expression2);
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(GetNameScopedViaFactoryDelegateMethod, FactoryDelegateCompiler.ResolverContextParamExpr, request.Container.GetConstantExpression(Name, typeof(object)), DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(flag), DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantInt(num), expression2, DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantInt(disposalOrder));
	}

	public DryIoc.FastExpressionCompiler.LightExpression.Expression ToExpression(Func<object, DryIoc.FastExpressionCompiler.LightExpression.Expression> fallbackConverter)
	{
		if (Name != null || ScopedOrSingleton)
		{
			if (!ScopedOrSingleton)
			{
				return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(typeof(Reuse).Method("ScopedTo", typeof(object)), fallbackConverter(Name));
			}
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Field(null, typeof(Reuse).GetField("ScopedOrSingleton"));
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.Field(null, typeof(Reuse).GetField("Scoped"));
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(ScopedOrSingleton ? "ScopedOrSingleton {" : "Scoped {");
		if (Name != null)
		{
			stringBuilder.Append("Name=").Print(Name).Append(", ");
		}
		if (Lifespan != 100)
		{
			stringBuilder.Append("NON DEFAULT LIFESPAN=").Append(Lifespan);
		}
		else
		{
			stringBuilder.Append("Lifespan=").Append(Lifespan);
		}
		return stringBuilder.Append("}").ToString();
	}

	public CurrentScopeReuse(object name, bool scopedOrSingleton, int lifespan)
	{
		Name = name;
		ScopedOrSingleton = scopedOrSingleton;
		Lifespan = lifespan;
	}

	public CurrentScopeReuse(object name = null, bool scopedOrSingleton = false)
		: this(name, scopedOrSingleton, 100)
	{
	}

	public static object GetScopedOrSingletonViaFactoryDelegateWithDisposalOrder(IResolverContext r, int id, FactoryDelegate createValue, int disposalOrder = 0)
	{
		if (disposalOrder != 0)
		{
			return r.CurrentOrSingletonScope.GetOrAddViaFactoryDelegateWithDisposalOrder(id, createValue, r, disposalOrder);
		}
		return r.CurrentOrSingletonScope.GetOrAddViaFactoryDelegate(id, createValue, r);
	}

	public static object GetScopedViaFactoryDelegate(IResolverContext r, bool throwIfNoScope, int id, FactoryDelegate createValue)
	{
		return r.GetCurrentScope(throwIfNoScope)?.GetOrAddViaFactoryDelegate(id, createValue, r);
	}

	public static object GetScopedViaFactoryDelegateWithDisposalOrder(IResolverContext r, bool throwIfNoScope, int id, FactoryDelegate createValue, int disposalOrder)
	{
		return r.GetCurrentScope(throwIfNoScope)?.GetOrAddViaFactoryDelegateWithDisposalOrder(id, createValue, r, disposalOrder);
	}

	public static object GetNameScopedViaFactoryDelegate(IResolverContext r, object scopeName, bool throwIfNoScope, int id, FactoryDelegate createValue, int disposalOrder)
	{
		return r.GetNamedScope(scopeName, throwIfNoScope)?.GetOrAddViaFactoryDelegateWithDisposalOrder(id, createValue, r, disposalOrder);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static object TrackScopedOrSingleton(IResolverContext r, object item)
	{
		if (!(item is IDisposable disposable))
		{
			return item;
		}
		return r.CurrentOrSingletonScope.TrackDisposable(disposable);
	}

	public static object TrackScoped(IResolverContext r, bool throwIfNoScope, object item)
	{
		if (!(item is IDisposable disposable))
		{
			return item;
		}
		return r.GetCurrentScope(throwIfNoScope)?.TrackDisposable(disposable);
	}

	public static object TrackNameScoped(IResolverContext r, object scopeName, bool throwIfNoScope, object item)
	{
		if (!(item is IDisposable disposable))
		{
			return item;
		}
		return r.GetNamedScope(scopeName, throwIfNoScope)?.TrackDisposable(disposable);
	}
}
