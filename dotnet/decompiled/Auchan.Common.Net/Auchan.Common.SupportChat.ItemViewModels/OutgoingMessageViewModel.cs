using System;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat.ItemViewModels;

public class OutgoingMessageViewModel : BaseMessageViewModel
{
	public UICommand ResendCommand { get; } = new UICommand();

	public OutgoingMessageViewModel(SupportChatViewModel supportChatViewModel, CacheMessage message, MessageLayoutType layout = MessageLayoutType.Upper)
		: base(message, layout)
	{
		OutgoingMessageViewModel parameter = this;
		ResendCommand.Subscribe(delegate
		{
			supportChatViewModel.OpenResendCommand.Trigger(parameter);
		}).AddTo(base.Disposables);
	}
}
