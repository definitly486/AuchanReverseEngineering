using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Profile.Stores.Dto;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores.Services;

public interface IRegionService
{
	Task<Result<List<FullRegionDto>, DomainError>> GetRegionAsync();
}
