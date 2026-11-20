using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Managers.Dialogs;

public interface IAgeGateDialog
{
	Task<AgreeState> ShowAgeGateDialogAsync(AgeGateViewModel.Parameter parameter);
}
