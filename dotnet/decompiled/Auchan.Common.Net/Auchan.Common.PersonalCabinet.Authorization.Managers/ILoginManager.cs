using System.Threading.Tasks;

namespace Auchan.Common.PersonalCabinet.Authorization.Managers;

public interface ILoginManager
{
	bool ShouldNavigateToProfile { get; set; }

	Task<bool> LoginAsync(bool displayOnboardings);

	Task<bool> ProceedLoyaltyRolloutCardOptions();

	Task<bool> OpenCardBlocked();
}
