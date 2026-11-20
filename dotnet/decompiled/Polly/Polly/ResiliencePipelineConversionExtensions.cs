using System;
using Polly.Utilities.Wrappers;

namespace Polly;

public static class ResiliencePipelineConversionExtensions
{
	public static IAsyncPolicy AsAsyncPolicy(this ResiliencePipeline strategy)
	{
		return new ResiliencePipelineAsyncPolicy(strategy ?? throw new ArgumentNullException("strategy"));
	}

	public static IAsyncPolicy<TResult> AsAsyncPolicy<TResult>(this ResiliencePipeline<TResult> strategy)
	{
		return new ResiliencePipelineAsyncPolicy<TResult>(strategy ?? throw new ArgumentNullException("strategy"));
	}

	public static ISyncPolicy AsSyncPolicy(this ResiliencePipeline strategy)
	{
		return new ResiliencePipelineSyncPolicy(strategy ?? throw new ArgumentNullException("strategy"));
	}

	public static ISyncPolicy<TResult> AsSyncPolicy<TResult>(this ResiliencePipeline<TResult> strategy)
	{
		return new ResiliencePipelineSyncPolicy<TResult>(strategy ?? throw new ArgumentNullException("strategy"));
	}
}
