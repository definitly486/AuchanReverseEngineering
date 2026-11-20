using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet.DomainModels;

namespace Auchan.Common.PersonalCabinet.Extensions;

public static class UserContextExtensions
{
	private static readonly IEnumerable<(Gender Gender, DateTime DateOfBirthFrom, DateTime DateOfBirthTo, decimal RetireAge)> _retirementAgeRules = new List<(Gender, DateTime, DateTime, decimal)>
	{
		(Gender.Female, DateTime.MinValue, new DateTime(1963, 12, 31), 55m),
		(Gender.Female, new DateTime(1964, 1, 1), new DateTime(1964, 12, 31), 55.5m),
		(Gender.Female, new DateTime(1965, 1, 1), new DateTime(1965, 12, 31), 56.5m),
		(Gender.Female, new DateTime(1966, 1, 1), new DateTime(1966, 12, 31), 58m),
		(Gender.Female, new DateTime(1967, 1, 1), new DateTime(1967, 12, 31), 59m),
		(Gender.Female, new DateTime(1968, 1, 1), DateTime.MaxValue, 60m),
		(Gender.Male, DateTime.MinValue, new DateTime(1958, 12, 31), 60m),
		(Gender.Male, new DateTime(1959, 1, 1), new DateTime(1959, 12, 31), 60.5m),
		(Gender.Male, new DateTime(1960, 1, 1), new DateTime(1960, 12, 31), 61.5m),
		(Gender.Male, new DateTime(1961, 1, 1), new DateTime(1961, 12, 31), 63m),
		(Gender.Male, new DateTime(1962, 1, 1), new DateTime(1962, 12, 31), 64m),
		(Gender.Male, new DateTime(1963, 1, 1), DateTime.MaxValue, 65m)
	};

	public static bool IsRetiredUser(this ProfileModel profile)
	{
		if (!profile.Birthday.HasValue || profile.Birthday.Value == default(DateTime))
		{
			return false;
		}
		decimal yearsFromDate = DateTime.Now.Date.GetYearsFromDate(profile.Birthday.Value);
		if (profile.Gender != Gender.Male && profile.Gender != Gender.Female)
		{
			return yearsFromDate >= 60m;
		}
		return yearsFromDate >= _retirementAgeRules.First(((Gender Gender, DateTime DateOfBirthFrom, DateTime DateOfBirthTo, decimal RetireAge) rule) => rule.Gender == profile.Gender && profile.Birthday.Value >= rule.DateOfBirthFrom && profile.Birthday.Value <= rule.DateOfBirthTo).RetireAge;
	}

	public static bool IsAudienceOf(this ProfileModel profile, AudienceType audience)
	{
		if (audience == AudienceType.All)
		{
			return true;
		}
		return audience == AudienceType.Employees == profile.IsAuchanEmployee;
	}
}
