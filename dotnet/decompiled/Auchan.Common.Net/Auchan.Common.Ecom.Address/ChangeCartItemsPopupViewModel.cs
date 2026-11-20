using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom.Address;

public class ChangeCartItemsPopupViewModel : ScreenViewModel<ChangeCartItemsPopupViewModel.Parameter>
{
	public class Parameter : BrokeredParameter<bool>
	{
		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private bool _result;

	private readonly IEcomTracker _ecomTracker;

	public string ChangeCartTitle => "Подтвердить смену магазина?";

	public string ChangeCartMessage => "Наличие товаров зависит от выбранного магазина. Ваша корзина будет обновлена";

	public string NoText => "Нет";

	public string YesText => "Да";

	public UICommand CloseCommand { get; } = new UICommand();

	public ChangeCartItemsPopupViewModel(BrokerToken token, IEcomTracker ecomTracker)
		: base(token)
	{
		_ecomTracker = ecomTracker;
	}

	protected override Task Start()
	{
		_ecomTracker.TrackPopUpCartUpdate();
		return base.Start();
	}

	public void Yes()
	{
		_result = true;
		_ecomTracker.TrackPopUpCartUpdateButtonChange();
		CloseCommand.Trigger();
	}

	public void No()
	{
		_ecomTracker.TrackPopUpCartUpdateButtonCancel();
		CloseCommand.Trigger();
	}

	public void Close()
	{
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
