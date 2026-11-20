using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Common;

public static class AlertButtons
{
	public static readonly AlertButton Ok = new AlertButton
	{
		Title = "Ок",
		Type = ActionType.Positive
	};

	public static readonly AlertButton[] OkButtons = new AlertButton[1] { Ok };

	public static readonly AlertButton Close = new AlertButton
	{
		Title = "Закрыть",
		Type = ActionType.Positive
	};

	public static readonly AlertButton[] CloseButtons = new AlertButton[1] { Close };

	public static readonly AlertButton Yes = new AlertButton
	{
		Title = "Да",
		Type = ActionType.Positive
	};

	public static readonly AlertButton No = new AlertButton
	{
		Title = "Нет",
		Type = ActionType.Negative
	};

	public static readonly AlertButton[] YesNo = new AlertButton[2] { Yes, No };

	public static readonly AlertButton Settings = new AlertButton
	{
		Title = "Настройки",
		Type = ActionType.Positive,
		Action = AppInfo.ShowSettingsUI
	};

	public static readonly AlertButton Confirm = new AlertButton
	{
		Title = "Подтвердить",
		Type = ActionType.Positive
	};

	public static readonly AlertButton Decline = new AlertButton
	{
		Title = "Отмена",
		Type = ActionType.Negative
	};

	public static readonly AlertButton[] ConfirmDecline = new AlertButton[2] { Confirm, Decline };
}
