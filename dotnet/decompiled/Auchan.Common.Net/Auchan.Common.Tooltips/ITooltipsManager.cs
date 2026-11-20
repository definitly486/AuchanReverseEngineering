using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Tooltips;

public interface ITooltipsManager
{
	Task<Result<Tooltip[], DomainError>> GetTooltips();
}
