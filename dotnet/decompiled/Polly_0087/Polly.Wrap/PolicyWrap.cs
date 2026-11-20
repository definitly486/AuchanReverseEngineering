using System;
using System.Diagnostics;
using System.Threading;

namespace Polly.Wrap;

public class PolicyWrap : Policy, IPolicyWrap, IsPolicy
{
	private readonly ISyncPolicy _outer;

	private readonly ISyncPolicy _inner;

	public IsPolicy Outer => _outer;

	public IsPolicy Inner => _inner;

	internal override void SetPolicyContext(Context executionContext, out string priorPolicyWrapKey, out string priorPolicyKey)
	{
		priorPolicyWrapKey = executionContext.PolicyWrapKey;
		priorPolicyKey = executionContext.PolicyKey;
		if (executionContext.PolicyWrapKey == null)
		{
			executionContext.PolicyWrapKey = base.PolicyKey;
		}
		base.SetPolicyContext(executionContext, out var _, out var _);
	}

	internal PolicyWrap(Policy outer, ISyncPolicy inner)
		: base(outer.ExceptionPredicates)
	{
		_outer = outer;
		_inner = inner;
	}

	[DebuggerStepThrough]
	protected override void Implementation(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
	{
		PolicyWrapEngine.Implementation(action, context, _outer, _inner, cancellationToken);
	}

	[DebuggerStepThrough]
	protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		return PolicyWrapEngine.Implementation(action, context, _outer, _inner, cancellationToken);
	}
}
public class PolicyWrap<TResult> : Policy<TResult>, IPolicyWrap<TResult>, IPolicyWrap, IsPolicy
{
	private readonly ISyncPolicy _outerNonGeneric;

	private readonly ISyncPolicy _innerNonGeneric;

	private readonly ISyncPolicy<TResult> _outerGeneric;

	private readonly ISyncPolicy<TResult> _innerGeneric;

	public IsPolicy Outer
	{
		get
		{
			IsPolicy outerGeneric = _outerGeneric;
			return outerGeneric ?? _outerNonGeneric;
		}
	}

	public IsPolicy Inner
	{
		get
		{
			IsPolicy innerGeneric = _innerGeneric;
			return innerGeneric ?? _innerNonGeneric;
		}
	}

	internal override void SetPolicyContext(Context executionContext, out string priorPolicyWrapKey, out string priorPolicyKey)
	{
		priorPolicyWrapKey = executionContext.PolicyWrapKey;
		priorPolicyKey = executionContext.PolicyKey;
		if (executionContext.PolicyWrapKey == null)
		{
			executionContext.PolicyWrapKey = base.PolicyKey;
		}
		base.SetPolicyContext(executionContext, out var _, out var _);
	}

	internal PolicyWrap(Policy outer, ISyncPolicy<TResult> inner)
		: base(outer.ExceptionPredicates, ResultPredicates<TResult>.None)
	{
		_outerNonGeneric = outer;
		_innerGeneric = inner;
	}

	internal PolicyWrap(Policy<TResult> outer, ISyncPolicy inner)
		: base(outer.ExceptionPredicates, outer.ResultPredicates)
	{
		_outerGeneric = outer;
		_innerNonGeneric = inner;
	}

	internal PolicyWrap(Policy<TResult> outer, ISyncPolicy<TResult> inner)
		: base(outer.ExceptionPredicates, outer.ResultPredicates)
	{
		_outerGeneric = outer;
		_innerGeneric = inner;
	}

	protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (_outerNonGeneric != null)
		{
			if (_innerNonGeneric != null)
			{
				return PolicyWrapEngine.Implementation(action, context, _outerNonGeneric, _innerNonGeneric, cancellationToken);
			}
			if (_innerGeneric != null)
			{
				return PolicyWrapEngine.Implementation(action, context, _outerNonGeneric, _innerGeneric, cancellationToken);
			}
			throw new InvalidOperationException("A PolicyWrap must define an inner policy.");
		}
		if (_outerGeneric != null)
		{
			if (_innerNonGeneric != null)
			{
				return PolicyWrapEngine.Implementation(action, context, _outerGeneric, _innerNonGeneric, cancellationToken);
			}
			if (_innerGeneric != null)
			{
				return PolicyWrapEngine.Implementation(action, context, _outerGeneric, _innerGeneric, cancellationToken);
			}
			throw new InvalidOperationException("A PolicyWrap must define an inner policy.");
		}
		throw new InvalidOperationException("A PolicyWrap must define an outer policy.");
	}
}
