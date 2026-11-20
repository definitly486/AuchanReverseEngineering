using System;
using System.Runtime.CompilerServices;
using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat.ItemViewModels;

public class IncomingMessageViewModel : BaseMessageViewModel
{
	[CompilerGenerated]
	private string _003COperatorImageUrl_003Ek__BackingField;

	[CompilerGenerated]
	private string _003COperatorName_003Ek__BackingField;

	public string OperatorImageUrl
	{
		[CompilerGenerated]
		get
		{
			return _003COperatorImageUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003COperatorImageUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003COperatorImageUrl_003Ek__BackingField = value;
				RaisePropertyChanged("OperatorImageUrl");
			}
		}
	}

	public string OperatorName
	{
		[CompilerGenerated]
		get
		{
			return _003COperatorName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003COperatorName_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003COperatorName_003Ek__BackingField = value;
				RaisePropertyChanged("OperatorName");
			}
		}
	}

	public IncomingMessageViewModel(CacheMessage message, MessageLayoutType layout = MessageLayoutType.Upper)
		: base(message, layout)
	{
		OperatorName = message.SenderName ?? "АШАН-бот";
		OperatorImageUrl = message.OperatorIconUrl ?? "Default";
	}
}
