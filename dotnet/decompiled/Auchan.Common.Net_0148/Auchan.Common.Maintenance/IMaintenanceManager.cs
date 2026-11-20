using System.Threading.Tasks;

namespace Auchan.Common.Maintenance;

public interface IMaintenanceManager
{
	Task<bool> CheckMaintenance();

	Task WaitWhileInMaintenanceAsync();
}
