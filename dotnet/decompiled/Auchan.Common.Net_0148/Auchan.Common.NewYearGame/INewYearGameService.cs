using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.NewYearGame;

public interface INewYearGameService
{
	Task<Result<string, DomainError>> NewYearGameToken();
}
