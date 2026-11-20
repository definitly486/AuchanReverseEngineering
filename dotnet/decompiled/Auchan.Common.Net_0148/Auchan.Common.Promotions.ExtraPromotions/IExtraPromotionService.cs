using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;

namespace Auchan.Common.Promotions.ExtraPromotions;

public interface IExtraPromotionService
{
	Task OpenPromotionDirectly(ScreenViewModel vm);

	Task<ExtraPromotion?> GetPromotionsFor(ScreenViewModel vm);
}
