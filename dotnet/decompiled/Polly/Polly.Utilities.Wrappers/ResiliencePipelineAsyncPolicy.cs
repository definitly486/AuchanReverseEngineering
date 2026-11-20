using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Utilities.Wrappers;

internal sealed class ResiliencePipelineAsyncPolicy : AsyncPolicy
{
	private readonly ResiliencePipeline _pipeline;

	public ResiliencePipelineAsyncPolicy(ResiliencePipeline strategy)
	{
		_pipeline = strategy;
	}

	protected override async Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		IDictionary<string, object> oldProperties;
		ResilienceContext resilienceContext = ResilienceContextFactory.Create(context, continueOnCapturedContext, out oldProperties, cancellationToken);
		try
		{
			await _pipeline.ExecuteAsync(async delegate(ResilienceContext resilienceContext2, (Func<Context, CancellationToken, Task> action, Context context) state)
			{
				await state.action(state.context, resilienceContext2.CancellationToken).ConfigureAwait(resilienceContext2.ContinueOnCapturedContext);
			}, resilienceContext, (action, context)).ConfigureAwait(continueOnCapturedContext);
		}
		finally
		{
			ResilienceContextFactory.Cleanup(resilienceContext, oldProperties);
		}
	}

	protected override async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		IDictionary<string, object> oldProperties;
		ResilienceContext resilienceContext = ResilienceContextFactory.Create(context, continueOnCapturedContext, out oldProperties, cancellationToken);
		try
		{
			return await _pipeline.ExecuteAsync<TResult, (Func<Context, CancellationToken, Task<TResult>>, Context)>(async (ResilienceContext resilienceContext2, (Func<Context, CancellationToken, Task<TResult>> action, Context context) state) => await state.action(state.context, resilienceContext2.CancellationToken).ConfigureAwait(resilienceContext2.ContinueOnCapturedContext), resilienceContext, (action, context)).ConfigureAwait(continueOnCapturedContext);
		}
		finally
		{
			ResilienceContextFactory.Cleanup(resilienceContext, oldProperties);
		}
	}
}
internal sealed class ResiliencePipelineAsyncPolicy<TResult> : AsyncPolicy<TResult>
{
	private readonly ResiliencePipeline<TResult> _pipeline;

	public ResiliencePipelineAsyncPolicy(ResiliencePipeline<TResult> strategy)
		: base((PolicyBuilder<TResult>?)null)
	{
		_pipeline = strategy;
	}

	protected override async Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		IDictionary<string, object> oldProperties;
		ResilienceContext resilienceContext = ResilienceContextFactory.Create(context, continueOnCapturedContext, out oldProperties, cancellationToken);
		try
		{
			return await _pipeline.ExecuteAsync<TResult, (Func<Context, CancellationToken, Task<TResult>>, Context)>(async (ResilienceContext resilienceContext2, (Func<Context, CancellationToken, Task<TResult>> action, Context context) state) => await state.action(state.context, resilienceContext2.CancellationToken).ConfigureAwait(resilienceContext2.ContinueOnCapturedContext), resilienceContext, (action, context)).ConfigureAwait(continueOnCapturedContext);
		}
		finally
		{
			ResilienceContextFactory.Cleanup(resilienceContext, oldProperties);
		}
	}
}
