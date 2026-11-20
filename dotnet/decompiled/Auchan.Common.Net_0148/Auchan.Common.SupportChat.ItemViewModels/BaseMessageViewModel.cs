using System;
using System.Runtime.CompilerServices;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat.ItemViewModels;

public abstract class BaseMessageViewModel : BaseCachedSupportChatItemViewModel
{
	[CompilerGenerated]
	private CacheMessage _003CMessage_003Ek__BackingField;

	[CompilerGenerated]
	private MessageLayoutType _003CLayout_003Ek__BackingField;

	public CacheMessage Message
	{
		[CompilerGenerated]
		get
		{
			return _003CMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CMessage_003Ek__BackingField, value))
			{
				_003CMessage_003Ek__BackingField = value;
				RaisePropertyChanged("Status");
				RaisePropertyChanged("MessageText");
				RaisePropertyChanged("IsRating");
				RaisePropertyChanged("MessageTime");
				RaisePropertyChanged("MessageId");
				RaisePropertyChanged("AttachmentUrl");
				RaisePropertyChanged("IsImage");
				RaisePropertyChanged("Message");
			}
		}
	}

	public MessageLayoutType Layout
	{
		[CompilerGenerated]
		get
		{
			return _003CLayout_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CLayout_003Ek__BackingField != value)
			{
				_003CLayout_003Ek__BackingField = value;
				RaisePropertyChanged("Layout");
			}
		}
	}

	public MessageStatusType Status => Message.Status;

	public string MessageText => Message.Text;

	public bool IsRating
	{
		get
		{
			if (!(MessageText == "1") && !(MessageText == "2") && !(MessageText == "3") && !(MessageText == "4"))
			{
				return MessageText == "5";
			}
			return true;
		}
	}

	public string MessageTime => Message.SendTime.ToString("HH:mm");

	public Guid MessageId => Message.Id;

	public string? AttachmentUrl => Message.UploadFileResult?.DownloadLink;

	public bool IsImage => Message.DataContentType == WSDataContentType.Image;

	public static string LoadingImageText => "Загружается изображение: ";

	public static string CantDisplayImageText => "Не могу отобразить изображение: ";

	public event Action? ImageLoadedEvent;

	public BaseMessageViewModel(CacheMessage message, MessageLayoutType layout)
	{
		Message = message;
		Layout = layout;
	}

	public virtual void OnImageDownloaded()
	{
		this.ImageLoadedEvent?.Invoke();
	}

	public virtual void OnMessageUpdated()
	{
		RaisePropertyChanged("Status");
	}
}
