using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public sealed class ProfileInfo
{
	[JsonProperty("givenName")]
	public string? FirstName { get; set; }

	[JsonProperty("sn")]
	public string? LastName { get; set; }

	[JsonProperty("mail")]
	public string? Email { get; set; }

	[JsonProperty("mobile")]
	public string? Phone { get; set; }

	[JsonProperty("telnum_for_reg")]
	public string? PhoneForPinReceiving { get; set; }

	[JsonProperty("clientAccountID")]
	public string? ClientAccountId { get; set; }

	[JsonIgnore]
	public string ClientAccountIdFormatedForQR => "002" + ClientAccountId;

	[JsonProperty("magentoClientAccountID")]
	public string? MagentoClientAccountId { get; set; }

	[JsonProperty("privacyPolicyFlag")]
	public int PrivacyPolicyFlag => 1;

	[JsonProperty("subscriptionFlag")]
	public int SubscriptionFlag { get; set; }

	[JsonProperty("birthday")]
	public string? Birthday { get; set; }

	[JsonProperty("city")]
	public string? City { get; set; }

	[JsonProperty("status")]
	public string? Status { get; set; }

	[JsonProperty("phone_confirmation")]
	public bool PhoneConfirmed { get; set; }

	public ProfileInfo Clone()
	{
		return new ProfileInfo
		{
			Birthday = Birthday,
			City = City,
			Email = Email,
			ClientAccountId = ClientAccountId,
			FirstName = FirstName,
			LastName = LastName,
			MagentoClientAccountId = MagentoClientAccountId,
			Phone = Phone,
			SubscriptionFlag = SubscriptionFlag
		};
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		ProfileInfo profileInfo = (ProfileInfo)obj;
		return (byte)(1u & (object.Equals(FirstName, profileInfo.FirstName) ? 1u : 0u) & (object.Equals(LastName, profileInfo.LastName) ? 1u : 0u) & (object.Equals(Phone, profileInfo.Phone) ? 1u : 0u) & (object.Equals(Birthday, profileInfo.Birthday) ? 1u : 0u) & (object.Equals(City, profileInfo.City) ? 1u : 0u)) != 0;
	}

	public override int GetHashCode()
	{
		return ClientAccountId?.GetHashCode() ?? 0;
	}
}
