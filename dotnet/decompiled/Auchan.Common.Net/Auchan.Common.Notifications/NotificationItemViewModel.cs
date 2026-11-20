using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Notifications.DTO;

namespace Auchan.Common.Notifications;

public sealed class NotificationItemViewModel : NotifyPropertyChanged
{
	[CompilerGenerated]
	private bool _003CIsUnread_003Ek__BackingField;

	public string Uuid { get; }

	public string Title { get; }

	public string Text { get; }

	public string DateLabel { get; }

	public string? DeeplinkUrl { get; }

	public string? ImageUrl { get; }

	public bool HasDeeplink => DeeplinkUrl != null;

	public bool HasImage => ImageUrl != null;

	public bool IsUnread
	{
		[CompilerGenerated]
		get
		{
			return _003CIsUnread_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsUnread_003Ek__BackingField != value)
			{
				_003CIsUnread_003Ek__BackingField = value;
				RaisePropertyChanged("IsUnread");
			}
		}
	}

	public NotificationItemViewModel(NotificationDto dto)
	{
		Uuid = dto.Uuid;
		Title = dto.Title;
		Text = dto.Text;
		DateLabel = dto.DateFrom;
		DeeplinkUrl = (string.IsNullOrWhiteSpace(dto.DeeplinkUrl) ? null : dto.DeeplinkUrl);
		ImageUrl = (string.IsNullOrWhiteSpace(dto.Image) ? null : dto.Image);
	}

	public void MarkAsRead()
	{
		if (IsUnread)
		{
			IsUnread = false;
			RaisePropertyChanged("IsUnread");
		}
	}
}
