using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Profile;

public interface IFavoritesApi
{
	[Post("/customers/favorites:add")]
	Task<FavoritesDtos.AddDto> AddProduct([Header("X-Token-CMD")] string cmdToken, [Body] FavoritesDtos.AddRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Delete("/customers/favorites:delete")]
	Task<FavoritesDtos.DeleteDto> DeleteProduct([Header("X-Token-CMD")] string cmdToken, [Body] FavoritesDtos.AddRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/customers/favorites")]
	Task<FavoriteProductsDto> Favorites([Header("X-Token-CMD")] string cmdToken, [Body] FavoritesDtos.FavoritesRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/customers/favorite-fields")]
	Task<FavoritesDtos.FavoriteFieldsDto> FavoriteFields([Header("X-Token-CMD")] string cmdToken, CancellationToken cancellationToken = default(CancellationToken));
}
