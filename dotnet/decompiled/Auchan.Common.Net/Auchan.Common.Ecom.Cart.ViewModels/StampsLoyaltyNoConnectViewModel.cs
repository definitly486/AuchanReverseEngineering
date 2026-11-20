using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public class StampsLoyaltyNoConnectViewModel : ScreenViewModel<StampsLoyaltyNoConnectViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<bool>
	{
		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public string TitleText => "Списать марки в данный момент\nневозможно";

	public string DescriptionText => "Сервис скоро будет восстановлен";

	public string ContinueText => "Продолжить без списания";

	public UICommand CloseCommand { get; } = new UICommand();

	public StampsLoyaltyNoConnectViewModel(BrokerToken parameter)
		: base(parameter)
	{
	}

	public void ContinueWithoutWithdrawalTapped()
	{
		base.Argument.TaskCompletionSource.TrySetResult(result: true);
		CloseCommand.Trigger();
	}

	public void OnClose()
	{
		base.Argument.TaskCompletionSource.TrySetResult(result: false);
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(result: false);
	}
}
