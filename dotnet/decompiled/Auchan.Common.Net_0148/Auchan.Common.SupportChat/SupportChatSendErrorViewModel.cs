using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat;

public class SupportChatSendErrorViewModel : ScreenViewModel
{
	public class Parameter
	{
		public CacheMessage Message { get; }

		public Parameter(CacheMessage message)
		{
			Message = message;
		}
	}

	private enum SelectedAction
	{
		Nothing,
		Resend,
		Delete
	}

	private readonly Parameter _parameter;

	private readonly SupportChatMessageManager _messageManager;

	private SelectedAction _selectedAction;

	public string Title => "Сообщение не отправлено";

	public string ResendText => "Повторить отправку";

	public string DeleteText => "Удалить сообщение";

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand ResendCommand { get; } = new UICommand();

	public UICommand DeleteCommand { get; } = new UICommand();

	public SupportChatSendErrorViewModel(Parameter parameter, SupportChatMessageManager messageManager)
	{
		_parameter = parameter;
		_messageManager = messageManager;
		ResendCommand.Subscribe(delegate
		{
			_selectedAction = SelectedAction.Resend;
			CloseCommand.Trigger();
		}).AddTo(base.CloseDisposable);
		DeleteCommand.Subscribe(delegate
		{
			_selectedAction = SelectedAction.Delete;
			CloseCommand.Trigger();
		}).AddTo(base.CloseDisposable);
	}

	public override void Dispose()
	{
		base.Dispose();
		switch (_selectedAction)
		{
		case SelectedAction.Delete:
			Task.Run(() => _messageManager.DeleteMessage(_parameter.Message)).SafeFireAndForget((Action<Exception>)null, false);
			break;
		case SelectedAction.Resend:
			Task.Run(() => _messageManager.ResendMessage(_parameter.Message)).SafeFireAndForget((Action<Exception>)null, false);
			break;
		}
	}
}
