using System.Linq;
using Auchan.Common.LoyaltyProgramLoymax.Dtos;

namespace Auchan.Common.Home;

public class FavoriteCategoriesItemViewModel(FavoriteCategoriesData favoriteCategory)
{
	public bool Accepted => favoriteCategory.Accepted;

	public bool CountVisible => favoriteCategory.MaxCount > 3;

	public string Title => favoriteCategory.Title;

	public string Subtitle => favoriteCategory.Subtitle;

	public string[] Images => favoriteCategory.Categories.Select((FavoriteCategory x) => x.MobileImageUrl).ToArray();

	public string Count => $"+{favoriteCategory.MaxCount - 3}";

	public FavoriteCategoriesData Data => favoriteCategory;
}
