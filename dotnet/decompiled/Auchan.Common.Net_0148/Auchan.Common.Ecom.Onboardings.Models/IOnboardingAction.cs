using System.Threading.Tasks;

namespace Auchan.Common.Ecom.Onboardings.Models;

public interface IOnboardingAction
{
	string Text { get; }

	Task ActivateAsync(ShowAt showAt, IOnboardingActionSupport actionSupport);
}
