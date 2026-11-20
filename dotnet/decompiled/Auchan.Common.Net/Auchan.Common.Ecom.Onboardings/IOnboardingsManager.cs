using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Onboardings.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Onboardings;

public interface IOnboardingsManager
{
	Task<Result<IReadOnlyList<OnboardingModel>, DomainError>> GetOnboardings(ShowAt position);

	void OnboardingShown(int id, ShowAt position);

	void PrefetchOnboardings();

	Task<bool> ShouldShowOnboardings(ShowAt position);
}
