using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet;

public interface IPersonalCabinetService
{
	Task<Result<int, DomainError>> CheckPhone(string token20, string phone, string deviceid, bool needHash);

	Task<Result<ProfileModel, DomainError>> GetProfile(string token80);

	Task<Result<SubscriptionsListModel, DomainError>> GetSubscriptionTypes(string token80);

	Task<Result<ProfileModel, DomainError>> UpdateProfile(ProfileModel profileModel, string token80);

	Task<Result<Unit, DomainError>> BeginVerifyPhone(string token80, string phone, bool needHash);

	Task<Result<Unit, DomainError>> VerifyPhone(string token80, string phone, string pin);

	Task<Result<Unit, DomainError>> Logout(string token80, bool forAll, string osType = "", string mobileType = "", string resolution = "");
}
