using System.ComponentModel;
using System.Runtime.Serialization;

namespace Auchan.Common.Logs;

public enum LogLevel
{
	[EnumMember(Value = "info")]
	[Description("Информация")]
	Info,
	[EnumMember(Value = "error")]
	[Description("Ошибка")]
	Error
}
