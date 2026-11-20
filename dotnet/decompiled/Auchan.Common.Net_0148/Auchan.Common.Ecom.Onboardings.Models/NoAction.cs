using System.Threading.Tasks;

namespace Auchan.Common.Ecom.Onboardings.Models;

internal sealed class NoAction : IOnboardingAction
{
	public required string Text { get; init; }

	public Task ActivateAsync(ShowAt showAt, IOnboardingActionSupport actionSupport)
	{
		actionSupport.NextCommand.Trigger();
		return Task.CompletedTask;
	}
}
