using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet;

public interface ITokenService
{
	Task<Result<TokenModel, DomainError>> Token20();

	Task<Result<TokenModel, DomainError>> Token80ByPhone(string phone, string pin);

	Task<Result<TokenModel, DomainError>> SavedToken80();

	Task SaveToken(TokenModel tokenModel);

	Task ClearTokens();
}
