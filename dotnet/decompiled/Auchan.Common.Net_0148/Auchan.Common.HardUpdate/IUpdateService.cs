using System.Threading.Tasks;

namespace Auchan.Common.HardUpdate;

public interface IUpdateService
{
	UpdatePackageOwner InstalledFrom { get; }

	bool IsBackgroundOpertionPending => false;

	Task NavigateToStoreAsync();

	Task UpdateInBackgroundAsync()
	{
		return Task.CompletedTask;
	}

	Task<bool> IsCanUpdateInBackgroundAsync()
	{
		return Task.FromResult(result: false);
	}

	sealed async Task<bool> TryToLaunchSystemBackgroundUpdateAsync()
	{
		if (IsBackgroundOpertionPending)
		{
			return true;
		}
		if (await IsCanUpdateInBackgroundAsync())
		{
			await UpdateInBackgroundAsync();
			return true;
		}
		return false;
	}
}
