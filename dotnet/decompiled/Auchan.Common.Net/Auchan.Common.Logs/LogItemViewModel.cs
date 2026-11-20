using Auchan.Common.Extensions;

namespace Auchan.Common.Logs;

public class LogItemViewModel
{
	private Log _item;

	public string Name => _item.Name;

	public string Description => _item.Description;

	public string LogType => _item.LogType.ToString();

	public LogLevel LogLevel => _item.LogLevel;

	public string LogTime => _item.DateTime.UTCToMoscow().ToLongDate();

	public bool IsErrorEntry => _item.LogLevel == LogLevel.Error;

	public bool IsDescriptionVisible => !string.IsNullOrEmpty(_item.Description);

	public LogItemViewModel(Log item)
	{
		_item = item;
	}
}
