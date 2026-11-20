using Auchan.Common.Ecom.Onboardings.Models;

namespace Auchan.Common.Ecom.Onboardings;

public class OnboardingItemViewModel
{
	public OnboardingModel Model { get; private set; }

	public bool IsTitleVisible => !string.IsNullOrWhiteSpace(Model.Title);

	public bool IsDescriptionVisible => !string.IsNullOrWhiteSpace(Model.Description);

	public bool IsButtonVisible => !string.IsNullOrWhiteSpace(Model.Action.Text);

	public OnboardingItemViewModel(OnboardingModel model)
	{
		Model = model;
	}
}
