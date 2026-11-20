namespace Microsoft.Maui.ApplicationModel.Communication;

public class ContactPhone
{
	public string PhoneNumber { get; set; }

	public ContactPhone(string phoneNumber)
	{
		PhoneNumber = phoneNumber;
	}

	public override string ToString()
	{
		return PhoneNumber;
	}
}
