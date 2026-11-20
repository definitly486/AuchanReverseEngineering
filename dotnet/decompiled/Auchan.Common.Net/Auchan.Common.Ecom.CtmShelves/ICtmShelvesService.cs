using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.CtmShelves.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.CtmShelves;

public interface ICtmShelvesService
{
	Task<Result<IReadOnlyList<Shelf>, DomainError>> GetShelves(ShelfPlacement placement, CancellationToken cancellationToken = default(CancellationToken));
}
