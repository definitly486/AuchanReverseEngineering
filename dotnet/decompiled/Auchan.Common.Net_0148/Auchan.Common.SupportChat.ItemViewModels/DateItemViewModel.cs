using System;

namespace Auchan.Common.SupportChat.ItemViewModels;

public class DateItemViewModel : BaseSupportChatItemViewModel
{
	private DateTime _dateTime;

	public string DateText => GetDateText();

	public DateItemViewModel(DateTime dateTime)
	{
		_dateTime = dateTime.ToLocalTime();
	}

	private string GetDateText()
	{
		if (_dateTime.Date == DateTime.Now.Date)
		{
			return "Сегодня";
		}
		if (_dateTime.Date == DateTime.Now.Date.AddDays(-1.0))
		{
			return "Вчера";
		}
		return _dateTime.Date.ToString("d MMMM");
	}
}
