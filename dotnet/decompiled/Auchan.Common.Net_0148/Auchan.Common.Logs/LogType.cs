using System.ComponentModel;
using System.Runtime.Serialization;

namespace Auchan.Common.Logs;

public enum LogType
{
	[EnumMember(Value = "userAction")]
	[Description("Действие пользователя")]
	UserAction,
	[EnumMember(Value = "apiRequest")]
	[Description("Запрос на сервер")]
	ApiRequest,
	[EnumMember(Value = "notification")]
	[Description("Уведомление")]
	Notification,
	[EnumMember(Value = "сrash")]
	[Description("Падение приложения")]
	Crash,
	[EnumMember(Value = "debug")]
	[Description("Информация для отладки")]
	Debug
}
