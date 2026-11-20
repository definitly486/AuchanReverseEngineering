using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Onboardings.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Onboardings;

public interface IOnboardingsRepository
{
	Task<Result<IReadOnlyList<OnboardingModel>, DomainError>> GetOnboardings(ShowAt showAt);

	void PrefetchOnboardings();
}
