using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders.Services;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders;

public class IssuingAreaViewModel : ScreenViewModel
{
	public class Parameter
	{
		public long[] OrderIds { get; }

		public string StoreName { get; }

		public string StoreAddress { get; }

		public string PickupPointDescription { get; }

		public string[] PickupPointImages { get; }

		[JsonConstructor]
		public Parameter(long[] orderIds, string storeName, string storeAddress, string pickupPointDescription, string[] pickupPointImages)
		{
			OrderIds = orderIds;
			StoreName = storeName;
			StoreAddress = storeAddress;
			PickupPointDescription = pickupPointDescription;
			PickupPointImages = pickupPointImages;
		}

		public Parameter(IReadOnlyList<OrderItemViewModel> orders)
		{
			OrderItemViewModel orderItemViewModel = orders.First();
			string storeName = orderItemViewModel.StoreName;
			string storeAddress = orderItemViewModel.StoreAddress;
			string pickupPointDescription = orderItemViewModel.PickupPointDescription;
			long[] array = orders.Select((OrderItemViewModel x) => x.OrderId).ToArray();
			IReadOnlyList<string> readOnlyList = orders.First().PickupPointImageUrls;
			if (readOnlyList.Count == 0)
			{
				readOnlyList = new List<string> { string.Empty };
			}
			OrderIds = array;
			StoreName = storeName;
			StoreAddress = storeAddress;
			PickupPointDescription = pickupPointDescription;
			PickupPointImages = readOnlyList.ToArray();
		}
	}

	private readonly Subject<Unit> _onAnswerYes = new Subject<Unit>();

	private readonly Subject<Unit> _onAnswerError = new Subject<Unit>();

	private readonly Parameter _parameter;

	private readonly IOrdersRepository _ordersRepository;

	private readonly IInfoMessageService _infoMessageService;

	public string Title => "Вы в зоне выдачи?";

	public string StoreName { get; }

	public string StoreAddress { get; }

	public string StoreDesc { get; }

	public string[] Images { get; }

	public string YesButtonText => "Да, я уже на месте";

	public IObservable<Unit> OnAnswerYes => _onAnswerYes.Debounce();

	public IObservable<Unit> OnAnswerError => _onAnswerError.Debounce();

	public string CancelButtonText => "Отмена";

	public IssuingAreaViewModel(Parameter parameter, IOrdersRepository ordersRepository, IInfoMessageService infoMessageService)
	{
		_parameter = parameter;
		_ordersRepository = ordersRepository;
		_infoMessageService = infoMessageService;
		StoreName = _parameter.StoreName;
		StoreAddress = _parameter.StoreAddress;
		StoreDesc = _parameter.PickupPointDescription;
		Images = _parameter.PickupPointImages;
	}

	public async Task OnYesButtonClicked()
	{
		bool isAllSuccess = true;
		long[] orderIds = _parameter.OrderIds;
		foreach (long orderId in orderIds)
		{
			if ((await _ordersRepository.UpdateOrderAsync(orderId, 1)).IsFailure)
			{
				isAllSuccess = false;
				break;
			}
		}
		if (isAllSuccess)
		{
			_onAnswerYes.OnNext(Unit.Default);
		}
		if (!isAllSuccess)
		{
			_infoMessageService.ShowSnackbar("Не удалось потвердить для одного или нескольких заказов. Попробуйте еще раз.");
			_onAnswerError.OnNext(Unit.Default);
		}
	}
}
