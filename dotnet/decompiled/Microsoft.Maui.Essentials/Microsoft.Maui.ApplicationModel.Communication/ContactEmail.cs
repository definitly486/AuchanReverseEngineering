namespace Microsoft.Maui.ApplicationModel.Communication;

public class ContactEmail
{
	public string EmailAddress { get; set; }

	public ContactEmail(string emailAddress)
	{
		EmailAddress = emailAddress;
	}

	public override string ToString()
	{
		return EmailAddress;
	}
}
