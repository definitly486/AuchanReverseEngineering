namespace Auchan.Common.Profile;

public static class SubscriptionNamesConverter
{
	public static string GetDisplayName(string typeName)
	{
		return typeName switch
		{
			"e-mail" => "E-mail", 
			"mobile_push" => "Push-уведомления", 
			"sms" => "СМС-сообщения", 
			"e-receipt" => "Получать электронные чеки", 
			"email_polls" => "Участвовать в опросах", 
			_ => "Неизвестная подписка", 
		};
	}
}
