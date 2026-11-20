using System;
using System.Threading.Tasks;

namespace Polly.Utils.Pipeline;

internal abstract class PipelineComponent
{
	internal abstract ValueTask<Outcome<TResult>> ExecuteCore<TResult, TState>(Func<ResilienceContext, TState, ValueTask<Outcome<TResult>>> callback, ResilienceContext context, TState state);
}
