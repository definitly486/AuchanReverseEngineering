using System.Reactive;
using System.Threading.Tasks;

namespace Auchan.Common.AuchanPay.Services;

public interface IAuchanPayDialogManager
{
	Task<Unit> OpenAuchanPayUnavailablePopup();
}
