using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Managers.Dialogs;

public static class AgeGateDialogExtensions
{
	public static Task<AgreeState> ShowAgeGateDialogAsync(this IAgeGateDialog @this, CancellationToken cancellationToken = default(CancellationToken))
	{
		return @this.ShowAgeGateDialogAsync(new AgeGateViewModel.Parameter(cancellationToken));
	}
}
