namespace Auchan.Common.PersonalCabinet.DomainModels;

public class UserPhoneCredentionals
{
	public string Phone { get; }

	public string Pin { get; }

	public string? PhoneToken80 { get; }

	public UserPhoneCredentionals(string phone, string pin, string? phoneToken80 = null)
	{
		Phone = phone;
		Pin = pin;
		PhoneToken80 = phoneToken80;
	}
}
