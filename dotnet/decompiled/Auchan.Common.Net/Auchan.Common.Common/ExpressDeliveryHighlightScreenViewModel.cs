using System;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Extensions;

namespace Auchan.Common.Common;

public class ExpressDeliveryHighlightScreenViewModel : ScreenViewModel<ExpressDeliveryHighlightScreenViewModel.Parameter>
{
	public class Parameter : BrokeredParameter
	{
		public required Action ViewAction { get; init; }
	}

	private readonly StoreRepository _storeRepository;

	public string Title => "Хорошая новость!";

	public string Description => "Вам доступна быстрая доставка";

	public UICommand ViewClickCommand { get; } = new UICommand();

	public UICommand CloseCommand { get; } = new UICommand();

	public ExpressDeliveryHighlightScreenViewModel(BrokerToken brokerToken, StoreRepository storeRepository)
		: base(brokerToken)
	{
		_storeRepository = storeRepository;
		ViewClickCommand.Subscribe(delegate
		{
			CloseCommand.Trigger();
			base.Argument.ViewAction();
		}).AddTo(base.CloseDisposable);
	}

	public void OnShown()
	{
		_storeRepository.TryMarkExpressDeliveryInformerShown();
	}
}
