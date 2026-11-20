using System;
using System.Collections.Generic;
using System.Threading;

namespace Polly.Utilities.Wrappers;

internal sealed class ResiliencePipelineSyncPolicy : Policy
{
	private readonly ResiliencePipeline _pipeline;

	public ResiliencePipelineSyncPolicy(ResiliencePipeline strategy)
	{
		_pipeline = strategy;
	}

	protected override void Implementation(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
	{
		IDictionary<string, object> oldProperties;
		ResilienceContext resilienceContext = ResilienceContextFactory.Create(context, continueOnCapturedContext: true, out oldProperties, cancellationToken);
		try
		{
			_pipeline.Execute(delegate(ResilienceContext resilienceContext2, (Action<Context, CancellationToken> action, Context context) state)
			{
				state.action(state.context, resilienceContext2.CancellationToken);
			}, resilienceContext, (action, context));
		}
		finally
		{
			ResilienceContextFactory.Cleanup(resilienceContext, oldProperties);
		}
	}

	protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		IDictionary<string, object> oldProperties;
		ResilienceContext resilienceContext = ResilienceContextFactory.Create(context, continueOnCapturedContext: true, out oldProperties, cancellationToken);
		try
		{
			return _pipeline.Execute((ResilienceContext resilienceContext2, (Func<Context, CancellationToken, TResult> action, Context context) state) => state.action(state.context, resilienceContext2.CancellationToken), resilienceContext, (action, context));
		}
		finally
		{
			ResilienceContextFactory.Cleanup(resilienceContext, oldProperties);
		}
	}
}
internal sealed class ResiliencePipelineSyncPolicy<TResult> : Policy<TResult>
{
	private readonly ResiliencePipeline<TResult> _pipeline;

	public ResiliencePipelineSyncPolicy(ResiliencePipeline<TResult> strategy)
		: base((PolicyBuilder<TResult>?)null)
	{
		_pipeline = strategy;
	}

	protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		IDictionary<string, object> oldProperties;
		ResilienceContext resilienceContext = ResilienceContextFactory.Create(context, continueOnCapturedContext: true, out oldProperties, cancellationToken);
		try
		{
			return _pipeline.Execute((ResilienceContext resilienceContext2, (Func<Context, CancellationToken, TResult> action, Context context) state) => state.action(state.context, resilienceContext2.CancellationToken), resilienceContext, (action, context));
		}
		finally
		{
			ResilienceContextFactory.Cleanup(resilienceContext, oldProperties);
		}
	}
}
