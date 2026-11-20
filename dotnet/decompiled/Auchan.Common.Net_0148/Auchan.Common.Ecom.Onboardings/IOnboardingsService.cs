using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Onboardings.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Onboardings;

public interface IOnboardingsService
{
	Task<Result<IReadOnlyDictionary<ShowAt, IReadOnlyList<OnboardingModel>>, DomainError>> GetOnboardings(CancellationToken cancellationToken = default(CancellationToken));
}
