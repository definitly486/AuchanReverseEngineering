using System.Threading.Tasks;

namespace Auchan.Common.Profile;

public interface IUserAccountDeletionService
{
	Task<DeletionResult> DeleteAccount();
}
