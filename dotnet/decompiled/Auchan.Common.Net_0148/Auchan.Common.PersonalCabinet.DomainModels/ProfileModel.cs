using System;
using System.Collections.Generic;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Enums;

namespace Auchan.Common.PersonalCabinet.DomainModels;

public class ProfileModel
{
	private string? _firstName;

	private string? _lastName;

	private string? _patronymic;

	private string? _email;

	public string? FirstName
	{
		get
		{
			return _firstName;
		}
		set
		{
			_firstName = CutdownName(value);
		}
	}

	public string? LastName
	{
		get
		{
			return _lastName;
		}
		set
		{
			_lastName = CutdownName(value);
		}
	}

	public string? Patronymic
	{
		get
		{
			return _patronymic;
		}
		set
		{
			_patronymic = CutdownName(value);
		}
	}

	public bool HasEmail => !string.IsNullOrEmpty(Email);

	public string? Email
	{
		get
		{
			return _email;
		}
		set
		{
			_email = value?.Trim();
		}
	}

	public bool MailConfirmation { get; set; }

	public string? Phone { get; set; }

	public bool IsVirtualCard { get; set; }

	public Gender Gender { get; set; }

	public DateTime? Birthday { get; set; }

	public string? Region { get; set; }

	public string? City { get; set; }

	public string? SourceRegistration { get; set; }

	public List<SubscriptionModel> Subscribes { get; set; } = new List<SubscriptionModel>();

	public List<object>? Stores { get; set; }

	public List<object>? Addresses { get; set; }

	public string? UserStatus { get; set; }

	public string? ConfirmPhoneDt { get; set; }

	public string? ClientAccountId { get; set; }

	public int MagentoAccountId { get; set; }

	public bool PhoneConfirmation { get; set; }

	public bool PrivacyPolicyFlag { get; set; }

	public string FullName => FirstName + " " + LastName;

	public string CashbackQrCode => "002" + ClientAccountId;

	public bool LoyaltyFlag { get; set; }

	public bool IsConfirmedSocialStatus { get; set; }

	public bool IsAuchanEmployee { get; set; }

	public AudienceType Audience
	{
		get
		{
			if (!IsAuchanEmployee)
			{
				return AudienceType.Clients;
			}
			return AudienceType.Employees;
		}
	}

	public string? LoyaltyId { get; set; }

	public string? LoymaxLoyaltyId { get; set; }

	public string? CardNumber { get; set; }

	public string? Cvc { get; set; }

	public string? QrCode { get; set; }

	public int PointsAmount { get; set; }

	public int EPointsAmount { get; set; }

	public int MarksAmount { get; set; }

	public LoyaltyCardStatus CardStatus { get; set; }

	public bool EReceiptEnabled { get; set; }

	public static ProfileModel CopyFilled(ProfileModel oldProfileModel, ProfileModel filedProfileModel)
	{
		oldProfileModel.FirstName = filedProfileModel.FirstName;
		oldProfileModel.LastName = filedProfileModel.LastName;
		oldProfileModel.Birthday = filedProfileModel.Birthday;
		oldProfileModel.Email = filedProfileModel.Email;
		oldProfileModel.Gender = filedProfileModel.Gender;
		return oldProfileModel;
	}

	private static string? CutdownName(string? name)
	{
		if (name == null || name.Length <= 25)
		{
			return name;
		}
		return name?.Substring(0, 25);
	}
}
