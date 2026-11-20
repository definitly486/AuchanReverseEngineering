using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom.Onboardings.Models;

public interface IOnboardingActionSupport
{
	UICommand<WebViewModel.Parameter> WebCommand { get; }

	UICommand NextCommand { get; }
}
