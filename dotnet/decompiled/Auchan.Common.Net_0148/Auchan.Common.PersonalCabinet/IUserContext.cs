using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet.DomainModels;

namespace Auchan.Common.PersonalCabinet;

public interface IUserContext : INotifyPropertyChanged
{
	bool Authorized { get; }

	ProfileModel? Profile { get; set; }

	LoyaltyCardEntity? LoyaltyCard { get; set; }

	int LoyaltyTriggersTimesShown { get; set; }

	bool IsFirstTimeLogin { get; set; }

	bool IsJustRegistered { get; set; }

	bool IsSignupWasShown { get; set; }

	int PhoneStatus { get; set; }

	bool IsAuthorizedAcrossRegistration { get; set; }

	List<string>? LoyaltyProgramSegments { get; set; }

	string SessionId { get; }

	string UserGUID { get; }

	event Func<Task> AfterLoggedIn;

	event Func<Task> AfterLoggedOut;

	event Func<Task> BeforeLoggedOut;

	Task LogIn();

	Task LogOut();

	void UpdateProfileWithNotify(ProfileModel? profile, bool needUpdateEmployeeStatus = false);
}
