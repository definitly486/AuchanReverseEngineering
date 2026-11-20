using System.Threading.Tasks;
using Auchan.Common.Common;

namespace Auchan.Common.Managers.Dialogs;

public interface IWaitListDialogService
{
	Task<AgreeState> ShowUnsubscribeDialogAsync();
}
