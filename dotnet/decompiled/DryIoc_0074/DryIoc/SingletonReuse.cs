using System;
using System.Linq.Expressions;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public sealed class SingletonReuse : IReuse, IConvertibleToExpression
{
	public const int DefaultLifespan = 1000;

	private static readonly Lazy<DryIoc.FastExpressionCompiler.LightExpression.Expression> _singletonReuseExpr = Lazy.Of((Func<DryIoc.FastExpressionCompiler.LightExpression.Expression>)(() => DryIoc.FastExpressionCompiler.LightExpression.Expression.Field(typeof(Reuse).GetField("Singleton"))));

	public int Lifespan => 1000;

	public object Name => null;

	public bool CanApply(Request request)
	{
		return true;
	}

	public DryIoc.FastExpressionCompiler.LightExpression.Expression Apply(Request request, DryIoc.FastExpressionCompiler.LightExpression.Expression serviceFactoryExpr)
	{
		if (serviceFactoryExpr.NodeType == ExpressionType.Convert)
		{
			serviceFactoryExpr = ((DryIoc.FastExpressionCompiler.LightExpression.UnaryExpression)serviceFactoryExpr).Operand;
		}
		int disposalOrder = request.Factory.Setup.DisposalOrder;
		Type type = serviceFactoryExpr.Type;
		if (request.TracksTransientDisposable)
		{
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(ResolverContext.SingletonScopeExpr, Scope.TrackDisposableOpenGenericMethod.MakeGenericMethod(type), serviceFactoryExpr, DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantInt(disposalOrder));
		}
		int value = ((request.FactoryType == FactoryType.Decorator) ? request.CombineDecoratorWithDecoratedFactoryID() : request.FactoryID);
		if (type.IsValueType)
		{
			serviceFactoryExpr = DryIoc.FastExpressionCompiler.LightExpression.Expression.Convert<object>(serviceFactoryExpr);
		}
		FactoryDelegateExpression arg = new FactoryDelegateExpression(serviceFactoryExpr);
		if (request.DependencyCount > 0)
		{
			request.DecreaseTrackedDependencyCountForParents(request.DependencyCount);
		}
		if (disposalOrder == 0)
		{
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(ResolverContext.SingletonScopeExpr, Scope.GetOrAddViaFactoryDelegateMethod, DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantInt(value), arg, FactoryDelegateCompiler.ResolverContextParamExpr);
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(ResolverContext.SingletonScopeExpr, Scope.GetOrAddViaFactoryDelegateWithDisposalOrderMethod, DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantInt(value), arg, FactoryDelegateCompiler.ResolverContextParamExpr, DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantInt(disposalOrder));
	}

	public DryIoc.FastExpressionCompiler.LightExpression.Expression ToExpression(Func<object, DryIoc.FastExpressionCompiler.LightExpression.Expression> fallbackConverter)
	{
		return _singletonReuseExpr.Value;
	}

	public override string ToString()
	{
		return "Singleton {Lifespan=" + Lifespan + "}";
	}
}
