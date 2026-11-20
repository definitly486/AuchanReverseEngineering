using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

public interface IProductPostService
{
	Task<Result<Unit, DomainError>> ProductPost(long gimaId, Product product, CancellationToken token);

	Task<Result<Unit, DomainError>> ProductPost(long gimaId, ProductOffer product, CancellationToken token);
}
