using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Ecom.CtmShelves.DTO;
using Auchan.Common.Ecom.CtmShelves.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Ecom.CtmShelves;

internal class CtmShelvesService : ICtmShelvesService
{
	private readonly ICtmShelvesApi _api;

	private readonly IEcomContext _ecomContext;

	private readonly IRequestExecutor _requestExecutor;

	private readonly IDeviceService _deviceService;

	private readonly IResolver _resolver;

	public CtmShelvesService(ICtmShelvesApi api, IEcomContext ecomContext, IRequestExecutor requestExecutor, IDeviceService deviceService, IResolver resolver)
	{
		_api = api;
		_ecomContext = ecomContext;
		_requestExecutor = requestExecutor;
		_deviceService = deviceService;
		_resolver = resolver;
	}

	public async Task<Result<IReadOnlyList<Shelf>, DomainError>> GetShelves(ShelfPlacement placement, CancellationToken cancellationToken)
	{
		return (await _requestExecutor.Execute((CancellationToken ct) => _api.GetShelves(new ShelfRequestDto
		{
			PageUrl = placement.Map(),
			MerchantId = _ecomContext.ActiveStore.Id
		}, ct), cancellationToken)).Map((ShelfResponseDto dto) => dto.Map(_resolver), (ServiceError err) => err.ToBaseDomainError());
	}
}
