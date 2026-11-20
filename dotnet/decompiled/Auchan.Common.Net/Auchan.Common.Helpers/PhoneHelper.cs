namespace Auchan.Common.Helpers;

public static class PhoneHelper
{
	private static int _russianPhoneLength = 11;

	public static string FormatPhone(string phone)
	{
		if (string.IsNullOrEmpty(phone) || phone.Length != _russianPhoneLength)
		{
			return phone;
		}
		if (!long.TryParse(phone, out var result))
		{
			return phone;
		}
		return result.ToString("+# (###) ###-##-##");
	}

	public static string GetPhoneDigits(string phone)
	{
		phone = phone.Replace("(", "").Replace(")", "").Replace("-", "")
			.Replace(" ", "");
		if (phone.Length > 1)
		{
			if (phone.StartsWith("8") || phone.StartsWith("7"))
			{
				phone = phone.Remove(0, 1);
			}
			else if (phone.StartsWith("+7"))
			{
				phone = phone.Remove(0, 2);
			}
		}
		phone = ((phone.Length > 10) ? phone.Remove(10) : phone);
		return phone;
	}

	public static string TryFix(string phone)
	{
		if (phone.Length == _russianPhoneLength - 1)
		{
			phone = phone.Insert(0, "7");
		}
		if (phone.Length == _russianPhoneLength && !phone.StartsWith("+"))
		{
			phone = phone.Insert(0, "+");
		}
		return phone;
	}
}
