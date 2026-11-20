using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public abstract class Factory
{
	internal static int _lastFactoryID;

	public int FactoryID { get; internal set; } = GetNextID();

	public virtual IReuse Reuse => null;

	public virtual Setup Setup => Setup.Default;

	public FactoryFlags Flags { get; set; }

	public bool CanCache => (Flags & FactoryFlags.DoNotCache) == 0;

	public FactoryType FactoryType => Setup.FactoryType;

	public virtual Type ImplementationType => null;

	public virtual bool CanAccessImplementationType => true;

	public virtual int RegistrationOrder => FactoryID;

	public virtual Made Made => Made.Default;

	public virtual bool HasRuntimeState => false;

	public bool AsResolutionCall
	{
		get
		{
			if ((Flags & FactoryFlags.AsResolutionCall) == 0)
			{
				return Setup.AsResolutionCall;
			}
			return true;
		}
	}

	public virtual ImHashMap<KV<Type, object>, ReflectionFactory> GeneratedFactories => null;

	public virtual ReflectionFactory GeneratorFactory => null;

	public static int GetNextID()
	{
		return Interlocked.Increment(ref _lastFactoryID);
	}

	public Factory DoNotCache()
	{
		if ((Flags & FactoryFlags.PleaseDontSetDoNotCache) == 0)
		{
			Flags |= FactoryFlags.DoNotCache;
		}
		return this;
	}

	internal void SetAsResolutionCall()
	{
		Flags |= FactoryFlags.AsResolutionCall;
	}

	public bool CheckCondition(Request request)
	{
		return Setup.Condition?.Invoke(request) ?? true;
	}

	public virtual Factory GetGeneratedFactoryOrDefault(Request request, bool ifErrorReturnDefault = false)
	{
		return null;
	}

	public abstract DryIoc.FastExpressionCompiler.LightExpression.Expression CreateExpressionOrDefault(Request request);

	public virtual DryIoc.FastExpressionCompiler.LightExpression.Expression CreateExpressionWithWrappedFactory(Request request, Factory serviceFactory)
	{
		return CreateExpressionOrDefault(request);
	}

	public virtual DryIoc.FastExpressionCompiler.LightExpression.Expression GetExpressionOrDefault(Request request)
	{
		Factory factory = ((request.FactoryID == 0) ? request.Factory : null);
		request = request.WithResolvedFactory(this);
		IContainer container = request.Container;
		if (FactoryType != FactoryType.Decorator)
		{
			DryIoc.FastExpressionCompiler.LightExpression.Expression decoratorExpressionOrDefault = container.GetDecoratorExpressionOrDefault(request);
			if (decoratorExpressionOrDefault != null)
			{
				return decoratorExpressionOrDefault;
			}
		}
		Setup setup = Setup;
		Rules rules = container.Rules;
		bool asResolutionCall = AsResolutionCall;
		if ((request.Flags & RequestFlags.IsGeneratedResolutionDependencyExpression) == 0 && !request.OpensResolutionScope && (setup.OpenResolutionScope || (!request.IsResolutionCall && (asResolutionCall || (setup.AsResolutionCallForExpressionGeneration && rules.UsedForExpressionGeneration)) && request.GetActualServiceType() != typeof(void))))
		{
			return Resolver.CreateResolutionExpression(request, setup.OpenResolutionScope, asResolutionCall);
		}
		IReuse reuse = request.Reuse;
		bool flag = CanCache && FactoryType == FactoryType.Service && !request.IsResolutionRoot && !request.IsDirectlyWrappedInFunc() && !request.IsWrappedInFuncWithArgs() && !(reuse.Name is IScopeName) && !asResolutionCall && !setup.UseParentReuse && setup.Condition == null && !Made.IsConditional;
		ImMapEntry<object> slot = null;
		if (flag)
		{
			DryIoc.FastExpressionCompiler.LightExpression.Expression cachedFactoryExpression = ((Container)container).GetCachedFactoryExpression(request, out slot);
			if (cachedFactoryExpression != null)
			{
				if (reuse == DryIoc.Reuse.Transient && slot.Value is Container.ExprCacheOfTransientWithDepCount { Count: >0 } exprCacheOfTransientWithDepCount && !rules.UsedForValidation && !rules.UsedForExpressionGeneration)
				{
					Request directParent = request.DirectParent;
					while (!directParent.IsEmpty)
					{
						directParent.DependencyCount += exprCacheOfTransientWithDepCount.Count;
						directParent = directParent.DirectParent;
					}
				}
				return cachedFactoryExpression;
			}
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression;
		if (reuse is SingletonReuse && rules.EagerCachingSingletonForFasterAccess)
		{
			int num = ((request.FactoryType == FactoryType.Decorator) ? request.CombineDecoratorWithDecoratedFactoryID() : request.FactoryID);
			ImMapEntry<object> entryOrDefault = ((Scope)container.SingletonScope)._maps[num & 0xF].GetEntryOrDefault(num);
			if (entryOrDefault != null)
			{
				if (entryOrDefault.Value == Scope.NoItem && !request.TracksTransientDisposable && !request.IsWrappedInFunc())
				{
					Scope.WaitForItemIsSet(entryOrDefault);
				}
				if (entryOrDefault.Value != Scope.NoItem)
				{
					object value = entryOrDefault.Value;
					expression = ((value != null) ? DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(value) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(null, request.GetActualServiceType()));
					if (Setup.WeaklyReferenced)
					{
						expression = DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(ThrowInGeneratedCode.WeakRefReuseWrapperGCedMethod, DryIoc.FastExpressionCompiler.LightExpression.Expression.Property(DryIoc.FastExpressionCompiler.LightExpression.Expression.ConvertViaCastClassIntrinsic<WeakReference>(expression), ReflectionTools.WeakReferenceValueProperty));
					}
					else if (Setup.PreventDisposal)
					{
						expression = DryIoc.FastExpressionCompiler.LightExpression.Expression.Field(DryIoc.FastExpressionCompiler.LightExpression.Expression.ConvertViaCastClassIntrinsic<HiddenDisposable>(expression), HiddenDisposable.ValueField);
					}
					return expression;
				}
			}
		}
		expression = ((factory == null) ? CreateExpressionOrDefault(request) : CreateExpressionWithWrappedFactory(request, factory));
		if (expression == null)
		{
			Container.TryThrowUnableToResolve(request);
			return null;
		}
		if (reuse != DryIoc.Reuse.Transient)
		{
			if (!rules.UsedForValidation && request.GetActualServiceType() != typeof(void))
			{
				Type type = expression.Type;
				expression = ApplyReuse(expression, request);
				Type type2 = expression.Type;
				if (expression.NodeType != ExpressionType.Constant && type2 != type && !type.IsAssignableFrom(type2))
				{
					expression = type.Cast(expression);
				}
			}
		}
		else if (!rules.UsedForValidation && !rules.UsedForExpressionGeneration)
		{
			int dependencyCount = request.DependencyCount;
			if (dependencyCount >= rules.DependencyCountInLambdaToSplitBigObjectGraph)
			{
				request.DecreaseTrackedDependencyCountForParents(dependencyCount);
				expression = DryIoc.FastExpressionCompiler.LightExpression.Expression.Invoke(expression.Type, DryIoc.FastExpressionCompiler.LightExpression.Expression.Lambda<Func<object>>(expression, ArrayTools.Empty<DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression>(), typeof(object)), ArrayTools.Empty<DryIoc.FastExpressionCompiler.LightExpression.Expression>());
			}
		}
		if (flag)
		{
			((Container)container).CacheFactoryExpression(request.FactoryID, expression, reuse, (reuse == DryIoc.Reuse.Transient) ? request.DependencyCount : 0, slot);
		}
		return expression;
	}

	protected virtual DryIoc.FastExpressionCompiler.LightExpression.Expression ApplyReuse(DryIoc.FastExpressionCompiler.LightExpression.Expression serviceExpr, Request request)
	{
		IReuse reuse = request.Reuse;
		Setup setup = Setup;
		if (reuse is SingletonReuse && request.Rules.EagerCachingSingletonForFasterAccess && !request.TracksTransientDisposable && !request.IsWrappedInFunc())
		{
			IContainer container = request.Container;
			Scope scope = (Scope)container.SingletonScope;
			if (scope.IsDisposed)
			{
				Throw.ScopeIsDisposed(scope, container);
			}
			int num = ((request.FactoryType == FactoryType.Decorator) ? request.CombineDecoratorWithDecoratedFactoryID() : request.FactoryID);
			object result = Scope.NoItem;
			ImMapEntry<object> imMapEntry = new ImMapEntry<object>(num, Scope.NoItem);
			ref ImMap<object> reference = ref scope._maps[num & 0xF];
			ImMap<object> imMap = reference;
			ImMap<object> imMap2 = imMap.AddOrKeepEntry(imMapEntry);
			if (imMap2 == imMap)
			{
				ImMapEntry<object> surePresentEntry = imMap2.GetSurePresentEntry(num);
				result = ((surePresentEntry.Value != Scope.NoItem) ? surePresentEntry.Value : Scope.WaitForItemIsSet(surePresentEntry));
			}
			else if (Interlocked.CompareExchange(ref reference, imMap2, imMap) != imMap)
			{
				imMap2 = Ref.SwapAndGetNewValue(ref reference, imMapEntry, (ImMap<object> x, ImMapEntry<object> i) => x.AddOrKeepEntry(i));
				ImMapEntry<object> surePresentEntry2 = imMap2.GetSurePresentEntry(num);
				if (surePresentEntry2 != imMapEntry)
				{
					result = ((surePresentEntry2.Value != Scope.NoItem) ? surePresentEntry2.Value : Scope.WaitForItemIsSet(surePresentEntry2));
				}
			}
			if (result == Scope.NoItem)
			{
				if (!Interpreter.TryInterpretSingletonAndUnwrapContainerException(container, serviceExpr, imMapEntry, out result))
				{
					result = serviceExpr.CompileToFactoryDelegate(container.Rules.UseInterpretation)(container);
				}
				if (setup.WeaklyReferenced)
				{
					result = new WeakReference(result);
				}
				else if (setup.PreventDisposal)
				{
					result = new HiddenDisposable(result);
				}
				imMapEntry.Value = result;
				if (result is IDisposable disposable && disposable != scope)
				{
					scope.AddDisposable(disposable, setup.DisposalOrder);
				}
			}
			serviceExpr = ((result == null) ? DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(null, serviceExpr.Type) : DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(result));
			if (request.DependencyCount > 0)
			{
				request.DecreaseTrackedDependencyCountForParents(request.DependencyCount);
			}
		}
		else
		{
			if (setup.WeaklyReferenced)
			{
				serviceExpr = DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(ReflectionTools.WeakReferenceCtor, serviceExpr);
			}
			else if (setup.PreventDisposal)
			{
				serviceExpr = DryIoc.FastExpressionCompiler.LightExpression.Expression.NewNoByRefArgs(HiddenDisposable.Ctor, serviceExpr);
			}
			serviceExpr = reuse.Apply(request, serviceExpr);
		}
		if (setup.WeaklyReferenced)
		{
			serviceExpr = DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(ThrowInGeneratedCode.WeakRefReuseWrapperGCedMethod, DryIoc.FastExpressionCompiler.LightExpression.Expression.Property(DryIoc.FastExpressionCompiler.LightExpression.Expression.ConvertViaCastClassIntrinsic<WeakReference>(serviceExpr), ReflectionTools.WeakReferenceValueProperty));
		}
		else if (setup.PreventDisposal)
		{
			serviceExpr = DryIoc.FastExpressionCompiler.LightExpression.Expression.Field(DryIoc.FastExpressionCompiler.LightExpression.Expression.ConvertViaCastClassIntrinsic<HiddenDisposable>(serviceExpr), HiddenDisposable.ValueField);
		}
		return serviceExpr;
	}

	public virtual FactoryDelegate GetDelegateOrDefault(Request request)
	{
		return GetExpressionOrDefault(request)?.CompileToFactoryDelegate(request.Rules.UseInterpretation);
	}

	internal virtual bool ValidateAndNormalizeRegistration(Type serviceType, object serviceKey, bool isStaticallyChecked, Rules rules, bool throwIfInvalid)
	{
		if (serviceType == null)
		{
			return Throw.When(throwIfInvalid, Error.ServiceTypeIsNull);
		}
		Setup setup = Setup;
		if (setup.FactoryType == FactoryType.Service)
		{
			IReuse reuse = Reuse ?? rules.DefaultReuse;
			if (reuse != DryIoc.Reuse.Transient || setup.AllowDisposableTransient || !rules.ThrowOnRegisteringDisposableTransient || setup.UseParentReuse)
			{
				return true;
			}
			Type c = (CanAccessImplementationType ? ImplementationType : serviceType);
			if (typeof(IDisposable).IsAssignableFrom(c))
			{
				return Throw.When(throwIfInvalid, Error.RegisteredDisposableTransientWontBeDisposedByContainer, serviceType, serviceKey ?? "{no key}", this);
			}
		}
		else
		{
			if (setup.FactoryType == FactoryType.Wrapper)
			{
				return ((Setup.WrapperSetup)setup).ValidateWrapperRegistration(serviceType, throwIfInvalid);
			}
			if (setup.FactoryType == FactoryType.Decorator)
			{
				if (serviceKey != null)
				{
					return Throw.When(throwIfInvalid, Error.DecoratorShouldNotBeRegisteredWithServiceKey, serviceKey);
				}
				IReuse reuse2 = Reuse ?? rules.DefaultReuse;
				if (reuse2 != DryIoc.Reuse.Transient || setup.AllowDisposableTransient || !rules.ThrowOnRegisteringDisposableTransient || ((Setup.DecoratorSetup)setup).UseDecorateeReuse)
				{
					return true;
				}
				Type c2 = (CanAccessImplementationType ? ImplementationType : serviceType);
				if (typeof(IDisposable).IsAssignableFrom(c2))
				{
					return Throw.When(throwIfInvalid, Error.RegisteredDisposableTransientWontBeDisposedByContainer, serviceType, serviceKey ?? "{no key}", this);
				}
			}
		}
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder().Append("{FactoryID=").Append(FactoryID);
		if (ImplementationType != null)
		{
			stringBuilder.Append(", ImplType=").Print(ImplementationType);
		}
		if (Reuse != null)
		{
			stringBuilder.Append(", Reuse=").Print(Reuse);
		}
		if (Setup.FactoryType != Setup.Default.FactoryType)
		{
			stringBuilder.Append(", FactoryType=").Append(Setup.FactoryType);
		}
		if (Setup.Metadata != null)
		{
			stringBuilder.Append(", Metadata=").Print(Setup.Metadata);
		}
		if (Setup.Condition != null)
		{
			stringBuilder.Append(", HasCondition");
		}
		if (Setup.OpenResolutionScope)
		{
			stringBuilder.Append(", OpensResolutionScope");
		}
		else if (AsResolutionCall)
		{
			stringBuilder.Append(", AsResolutionCall");
		}
		return stringBuilder.Append("}").ToString();
	}
}
