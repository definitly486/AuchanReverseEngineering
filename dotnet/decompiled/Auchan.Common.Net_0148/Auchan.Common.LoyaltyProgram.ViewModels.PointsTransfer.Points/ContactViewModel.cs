namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public class ContactViewModel
{
	private readonly string _givenName;

	private readonly string _familyName;

	public string FullName => ((_familyName.Length > 0) ? (_familyName + " ") : string.Empty) + ((_givenName.Length > 0) ? _givenName : string.Empty);

	public string Initials => (((_familyName.Length > 0) ? _familyName[0].ToString() : string.Empty) + ((_givenName.Length > 0) ? _givenName[0].ToString() : string.Empty)).ToUpper();

	public string Phone { get; }

	public ContactViewModel(string givenName, string familyName, string phone)
	{
		_givenName = givenName;
		_familyName = familyName;
		Phone = phone;
	}
}
