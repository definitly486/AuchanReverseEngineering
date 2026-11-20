using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.PersonalCabinet.DTO;
using Auchan.Common.PersonalCabinet.DomainModels;

namespace Auchan.Common.PersonalCabinet;

internal static class PersonalCabinetMapper
{
	public static PhoneStatus ToPhoneStatus(this CheckPhoneDto dto)
	{
		return (PhoneStatus)dto.Result;
	}

	public static ProfileModel ToProfileModel(this ProfileDto? profile)
	{
		return new ProfileModel
		{
			FirstName = profile?.GivenName,
			LastName = profile?.Sn,
			Patronymic = profile?.Patronymic,
			Email = profile?.Mail,
			Phone = profile?.TelNumForReg,
			Gender = (profile?.Sex.ToGender() ?? Gender.Unknown),
			Birthday = ((profile == null || profile.Birthday == null) ? ((DateTime?)null) : new DateTime?(DateTime.Parse(profile?.Birthday))),
			Region = profile?.Region,
			City = profile?.City,
			SourceRegistration = profile?.SourceRegistration,
			Subscribes = (profile?.Subscribes?.Select((SubscriptionDto x) => x.ToSubscriptionModel()).ToList() ?? new List<SubscriptionModel>()),
			Stores = profile?.Stores,
			Addresses = profile?.Addresses,
			UserStatus = profile?.UserStatus,
			ConfirmPhoneDt = profile?.ConfirmPhoneDt,
			ClientAccountId = profile?.ClientAccountId,
			MagentoAccountId = (profile?.MagentoAccountId ?? 0),
			PhoneConfirmation = (profile?.PhoneConfirmation ?? false),
			PrivacyPolicyFlag = (profile?.PrivacyPolicyFlag.FromApiBoolString() ?? false),
			LoyaltyFlag = (profile?.LoyaltyFlag.FromIntBoolString() ?? false),
			LoyaltyId = (profile?.LoyaltyId ?? string.Empty),
			LoymaxLoyaltyId = (profile?.LoymaxLoyaltyId ?? string.Empty),
			EReceiptEnabled = (profile?.EreceiptFlag == true)
		};
	}

	public static ProfileModel ToProfileModel(this ProfileSnackCaseDto? profile)
	{
		return new ProfileModel
		{
			FirstName = profile?.GivenName,
			LastName = profile?.Sn,
			Patronymic = profile?.Patronymic,
			Email = profile?.Mail,
			MailConfirmation = (profile?.MailConfirmation ?? false),
			Phone = profile?.TelNumForReg,
			Gender = (profile?.Sex.ToGender() ?? Gender.Unknown),
			Birthday = ((profile == null || profile.Birthday == null) ? ((DateTime?)null) : new DateTime?(DateTime.Parse(profile?.Birthday))),
			Region = profile?.Region,
			City = profile?.City,
			SourceRegistration = profile?.SourceRegistration,
			Subscribes = (profile?.Subscribes?.Select((SubscriptionSnackCaseDto x) => x.ToSubscriptionModel()).ToList() ?? new List<SubscriptionModel>()),
			Stores = profile?.Stores,
			Addresses = profile?.Addresses,
			UserStatus = profile?.UserStatus,
			ConfirmPhoneDt = profile?.ConfirmPhoneDt,
			ClientAccountId = profile?.ClientAccountId,
			MagentoAccountId = Convert.ToInt32(profile?.MagentoAccountId),
			PhoneConfirmation = (profile?.PhoneConfirmation ?? false),
			PrivacyPolicyFlag = (profile?.PrivacyPolicyFlag.FromApiBoolString() ?? false),
			LoyaltyFlag = (profile?.LoyaltyFlag.FromIntBoolString() ?? false),
			LoyaltyId = (profile?.LoyaltyId ?? string.Empty),
			LoymaxLoyaltyId = (profile?.LoymaxLoyaltyId ?? string.Empty),
			EReceiptEnabled = (profile?.EreceiptFlag == true)
		};
	}

	public static SubscriptionsListModel ToSubscriptionModel(this SubscriptionsListDto dto)
	{
		return new SubscriptionsListModel
		{
			SubscriptionTypes = dto.SubscriptionTypes.Select((SubscriptionTypeDto x) => new SubscriptionTypeModel
			{
				Id = x.Id,
				Title = x.Title
			}).ToList(),
			SubscriptionCommTypes = dto.SubscriptionCommunicationTypes.Select((SubscriptionCommunicationDto x) => new SubscriptionCommunicationModel(x.Id, x.Title)).ToList()
		};
	}

	private static SubscriptionModel ToSubscriptionModel(this SubscriptionDto dto)
	{
		return new SubscriptionModel
		{
			Id = dto.Id,
			StartDate = dto.StartDate,
			EndDate = dto.EndDate,
			CommunicationType = new SubscriptionCommunicationModel(dto.CommunicationType.Id, dto.CommunicationType.Title),
			Type = new SubscriptionTypeModel
			{
				Id = dto.Type.Id,
				Title = dto.Type.Title
			}
		};
	}

	private static SubscriptionModel ToSubscriptionModel(this SubscriptionSnackCaseDto dto)
	{
		return new SubscriptionModel
		{
			Id = dto.Id,
			StartDate = dto.StartDate,
			EndDate = dto.EndDate,
			CommunicationType = new SubscriptionCommunicationModel(dto.CommunicationType.Id, dto.CommunicationType.Title),
			Type = new SubscriptionTypeModel
			{
				Id = dto.Type.Id,
				Title = dto.Type.Title
			}
		};
	}

	public static ProfileDto ToProfileDto(this ProfileModel model)
	{
		return new ProfileDto
		{
			GivenName = model.FirstName,
			Sn = model.LastName,
			Patronymic = model.Patronymic,
			Mail = model.Email,
			TelNumForReg = model.Phone,
			Sex = model.Gender.ToGenderString(),
			Birthday = model.Birthday?.ToString("dd.MM.yyyy"),
			Region = model.Region,
			City = model.City,
			Subscribes = model.Subscribes.Select(ToSubscriptionDto).ToList(),
			Stores = model.Stores,
			Addresses = model.Addresses,
			UserStatus = model.UserStatus,
			ConfirmPhoneDt = model.ConfirmPhoneDt,
			ClientAccountId = model.ClientAccountId,
			MagentoAccountId = model.MagentoAccountId,
			PhoneConfirmation = model.PhoneConfirmation,
			PrivacyPolicyFlag = model.PrivacyPolicyFlag.ToApiBoolString(),
			LoyaltyFlag = model.LoyaltyFlag.ToIntBoolString(),
			LoyaltyId = model.LoyaltyId,
			LoymaxLoyaltyId = (model.LoymaxLoyaltyId ?? "0"),
			EreceiptFlag = model.EReceiptEnabled
		};
	}

	public static ProfileSnackCaseDto ToProfileSnackCaseDto(this ProfileModel model)
	{
		return new ProfileSnackCaseDto
		{
			GivenName = model.FirstName,
			Sn = model.LastName,
			Patronymic = model.Patronymic,
			Mail = model.Email,
			TelNumForReg = model.Phone,
			Sex = model.Gender.ToGenderString(),
			Birthday = model.Birthday?.ToString("dd.MM.yyyy"),
			Region = model.Region,
			City = model.City,
			Subscribes = model.Subscribes.Select(ToSubscriptionSnackCaseDto).ToList(),
			Stores = model.Stores,
			Addresses = model.Addresses,
			UserStatus = model.UserStatus,
			ConfirmPhoneDt = model.ConfirmPhoneDt,
			ClientAccountId = model.ClientAccountId,
			MagentoAccountId = model.MagentoAccountId.ToString(),
			PhoneConfirmation = model.PhoneConfirmation,
			PrivacyPolicyFlag = model.PrivacyPolicyFlag.ToApiBoolString(),
			LoyaltyFlag = model.LoyaltyFlag.ToIntBoolString(),
			LoyaltyId = model.LoyaltyId,
			LoymaxLoyaltyId = (string.IsNullOrEmpty(model.LoymaxLoyaltyId) ? null : model.LoymaxLoyaltyId),
			EreceiptFlag = model.EReceiptEnabled
		};
	}

	public static SubscriptionDto ToSubscriptionDto(this SubscriptionModel model)
	{
		return new SubscriptionDto
		{
			Id = model.Id,
			StartDate = model.StartDate,
			EndDate = model.EndDate,
			CommunicationType = new SubscriptionCommunicationDto
			{
				Id = model.CommunicationType.Id,
				Title = model.CommunicationType.Title
			},
			Type = new SubscriptionTypeDto
			{
				Id = model.Type.Id,
				Title = model.Type.Title
			}
		};
	}

	public static SubscriptionSnackCaseDto ToSubscriptionSnackCaseDto(this SubscriptionModel model)
	{
		return new SubscriptionSnackCaseDto
		{
			Id = model.Id,
			StartDate = model.StartDate,
			EndDate = model.EndDate,
			CommunicationType = new SubscriptionCommunicationDto
			{
				Id = model.CommunicationType.Id,
				Title = model.CommunicationType.Title
			},
			Type = new SubscriptionTypeDto
			{
				Id = model.Type.Id,
				Title = model.Type.Title
			}
		};
	}

	public static Gender ToGender(this string? genderString)
	{
		if (!Enum.TryParse<Gender>(genderString, ignoreCase: true, out var result))
		{
			return Gender.Unknown;
		}
		return result;
	}

	public static string? ToGenderString(this Gender gender)
	{
		if (gender != Gender.Unknown)
		{
			return gender.ToString().ToLower();
		}
		return null;
	}

	public static string? ToApiBoolString(this bool flag)
	{
		if (!flag)
		{
			return "0";
		}
		return "1";
	}

	public static bool FromApiBoolString(this string? flag)
	{
		return "1".Equals(flag);
	}

	public static bool FromIntBoolString(this int flag)
	{
		return flag == 1;
	}

	public static int ToIntBoolString(this bool flag)
	{
		return flag ? 1 : 0;
	}
}
