using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;

namespace Auchan.Common.SupportChat;

public sealed class SupportChatSendFileViewModel : ScreenViewModel<SupportChatSendFileViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<AgreeState>
	{
		public string Error { get; }

		public Parameter(string error)
			: base(default(CancellationToken))
		{
			Error = error;
		}
	}

	private AgreeState _result;

	public string Title => "Файл не отправлен";

	public string ResendText => "Отправить другой файл";

	public string DeleteText => "Отправить позже";

	public string ErrorText => base.Argument.Error;

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand ResendCommand { get; } = new UICommand();

	public SupportChatSendFileViewModel(BrokerToken brokerToken)
		: base(brokerToken)
	{
	}

	protected override async Task Start()
	{
		await base.Start();
		((IObservable<Unit>)ResendCommand).PerformDebouncingTask((Func<Task>)delegate
		{
			CloseCommand.Trigger();
			_result = AgreeState.Yes;
			return Task.CompletedTask;
		}, (IScheduler?)null).Subscribe().AddTo(base.CloseDisposable);
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
