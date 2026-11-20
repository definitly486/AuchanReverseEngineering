using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public class SuccessAdditionalOrderPopupViewModel : ScreenViewModel<SuccessAdditionalOrderPopupViewModel.Parameter>
{
	public class Parameter : BrokeredParameter<ModelResult>
	{
		public required IListOrderModel Model { get; init; }

		public required decimal OrderAdditionPrice { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public enum ModelResult
	{
		Unknown,
		GotoHome,
		GotoOrder
	}

	private ModelResult _result;

	public string Title => "Новые товары успешно добавлены!";

	public string Subtitle => "Отслеживать статус заказа можно в личном кабинете. Мы отправили детали на ваш адрес электронной почты.";

	public string InfoText => $"Пожалуйста, убедитесь, что на вашей карте есть необходимая сумма в размере {base.Argument.OrderAdditionPrice:C2}, т.к. средства будут списаны автоматически";

	public string HomeButtonText => "На главную";

	public string OrderDetailsButtonText => "Перейти к заказу";

	public IListOrderModel Order => base.Argument.Model;

	public UICommand CloseCommand { get; } = new UICommand();

	public SuccessAdditionalOrderPopupViewModel(BrokerToken brokerToken)
		: base(brokerToken)
	{
	}

	public void NavigateToHome()
	{
		_result = ModelResult.GotoHome;
		CloseCommand.Trigger();
	}

	public void NavigateToOrderDetails()
	{
		_result = ModelResult.GotoOrder;
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
