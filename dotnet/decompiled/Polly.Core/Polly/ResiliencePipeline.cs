using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Polly.Utils;
using Polly.Utils.Pipeline;

namespace Polly;

public sealed class ResiliencePipeline
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CExecuteAsync_003Ed__0<TState> : IAsyncStateMachine where TState : notnull
	{
		public int _003C_003E1__state;

		public AsyncValueTaskMethodBuilder _003C_003Et__builder;

		public Func<ResilienceContext, TState, ValueTask> callback;

		public ResilienceContext context;

		public ResiliencePipeline _003C_003E4__this;

		public TState state;

		private ConfiguredValueTaskAwaitable<Outcome<VoidResult>>.ConfiguredValueTaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			ResiliencePipeline resiliencePipeline = _003C_003E4__this;
			try
			{
				ConfiguredValueTaskAwaitable<Outcome<VoidResult>>.ConfiguredValueTaskAwaiter awaiter;
				if (num != 0)
				{
					Guard.NotNull(callback, "callback");
					Guard.NotNull(context, "context");
					resiliencePipeline.InitializeAsyncContext(context);
					awaiter = resiliencePipeline.Component.ExecuteCore<VoidResult, (Func<ResilienceContext, TState, ValueTask>, TState)>([DebuggerDisableUserUnhandledExceptions] async (ResilienceContext context, (Func<ResilienceContext, TState, ValueTask> callback, TState state) state) =>
					{
						try
						{
							await state.callback(context, state.state).ConfigureAwait(context.ContinueOnCapturedContext);
							return Outcome.Void;
						}
						catch (Exception exception2)
						{
							return Outcome.FromException(exception2);
						}
					}, context, (callback, state)).ConfigureAwait(context.ContinueOnCapturedContext).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(ConfiguredValueTaskAwaitable<Outcome<VoidResult>>.ConfiguredValueTaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				awaiter.GetResult().GetResultOrRethrow();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_003C_003Et__builder.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CExecuteAsync_003Ed__7<TResult, TState> : IAsyncStateMachine where TResult : notnull where TState : notnull
	{
		public int _003C_003E1__state;

		public AsyncValueTaskMethodBuilder<TResult> _003C_003Et__builder;

		public Func<ResilienceContext, TState, ValueTask<TResult>> callback;

		public ResilienceContext context;

		public ResiliencePipeline _003C_003E4__this;

		public TState state;

		private ConfiguredValueTaskAwaitable<Outcome<TResult>>.ConfiguredValueTaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			ResiliencePipeline resiliencePipeline = _003C_003E4__this;
			TResult resultOrRethrow;
			try
			{
				ConfiguredValueTaskAwaitable<Outcome<TResult>>.ConfiguredValueTaskAwaiter awaiter;
				if (num != 0)
				{
					Guard.NotNull(callback, "callback");
					Guard.NotNull(context, "context");
					resiliencePipeline.InitializeAsyncContext<TResult>(context);
					awaiter = resiliencePipeline.Component.ExecuteCore<TResult, (Func<ResilienceContext, TState, ValueTask<TResult>>, TState)>([DebuggerDisableUserUnhandledExceptions] async (ResilienceContext context, (Func<ResilienceContext, TState, ValueTask<TResult>> callback, TState state) state) =>
					{
						try
						{
							return Outcome.FromResult(await state.callback(context, state.state).ConfigureAwait(context.ContinueOnCapturedContext));
						}
						catch (Exception exception2)
						{
							return Outcome.FromException<TResult>(exception2);
						}
					}, context, (callback, state)).ConfigureAwait(context.ContinueOnCapturedContext).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(ConfiguredValueTaskAwaitable<Outcome<TResult>>.ConfiguredValueTaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				resultOrRethrow = awaiter.GetResult().GetResultOrRethrow();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(resultOrRethrow);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_003C_003Et__builder.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	internal PipelineComponent Component
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__0<>))]
	public ValueTask ExecuteAsync<TState>(Func<ResilienceContext, TState, ValueTask> callback, ResilienceContext context, TState state)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeAsyncContext(ResilienceContext context)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__7<, >))]
	public ValueTask<TResult> ExecuteAsync<TResult, TState>(Func<ResilienceContext, TState, ValueTask<TResult>> callback, ResilienceContext context, TState state)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeAsyncContext<TResult>(ResilienceContext context)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Execute<TState>(Action<ResilienceContext, TState> callback, ResilienceContext context, TState state)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TResult Execute<TResult, TState>(Func<ResilienceContext, TState, TResult> callback, ResilienceContext context, TState state)
	{
		throw new NotSupportedException("Linked away");
	}
}
public sealed class ResiliencePipeline<T>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public ValueTask<TResult> ExecuteAsync<TResult, TState>(Func<ResilienceContext, TState, ValueTask<TResult>> callback, ResilienceContext context, TState state) where TResult : T
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TResult Execute<TResult, TState>(Func<ResilienceContext, TState, TResult> callback, ResilienceContext context, TState state) where TResult : T
	{
		throw new NotSupportedException("Linked away");
	}
}
