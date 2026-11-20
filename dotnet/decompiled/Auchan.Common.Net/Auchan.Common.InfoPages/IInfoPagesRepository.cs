using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.InfoPages.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.InfoPages;

public interface IInfoPagesRepository
{
	Task<Result<List<InfoPage>, DomainError>> InfoPages();

	Task<Result<InfoPage, DomainError>> InfoPage(string slug);

	Task<Result<FAQ, DomainError>> FAQ(FAQType type = FAQType.Default);

	Task<Result<List<Tutorial>, DomainError>> Tutorials();
}
