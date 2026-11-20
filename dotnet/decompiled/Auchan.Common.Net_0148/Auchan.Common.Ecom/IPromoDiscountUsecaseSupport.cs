using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom;

public interface IPromoDiscountUsecaseSupport
{
	UICommand<LinkedText> ShowPromoTooltipCommand { get; }

	UICommand GotoTooltipLinkCommand { get; }
}
