using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom.Address;

public class AskToRemoveAddressPopupViewModel : ScreenViewModel<AskToRemoveAddressPopupViewModel.Parameter>
{
	public class Parameter : BrokeredParameter<bool>
	{
		public required bool ForStore { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private bool _result;

	public string Title
	{
		get
		{
			if (!base.Argument.ForStore)
			{
				return "Удаление адреса";
			}
			return "Удаление магазина";
		}
	}

	public string Message => "Вы точно хотите удалить " + (base.Argument.ForStore ? "адрес магазина?" : "адрес?");

	public string NoText => "Нет, оставить";

	public string YesText => "Да, удалить";

	public UICommand CloseCommand { get; } = new UICommand();

	public AskToRemoveAddressPopupViewModel(BrokerToken parameter)
		: base(parameter)
	{
	}

	public void Yes()
	{
		_result = true;
		CloseCommand.Trigger();
	}

	public void No()
	{
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
