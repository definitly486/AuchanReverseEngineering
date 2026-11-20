using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.UserCards;

public interface IUserCardsService
{
	Task<Result<List<CardModel>, DomainError>> GetCards();

	Task<Result<string, DomainError>> AddCardUrl(string callbackUrl);

	Task<Result<List<CardModel>, DomainError>> RemoveCard(int id);
}
