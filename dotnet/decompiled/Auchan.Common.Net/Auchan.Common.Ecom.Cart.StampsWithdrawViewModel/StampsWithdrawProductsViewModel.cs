using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Helpers;

namespace Auchan.Common.Ecom.Cart.StampsWithdrawViewModel;

public class StampsWithdrawProductsViewModel : ScreenViewModel<StampsWithdrawProductsViewModel.Parameter>
{
	public class Parameter : BrokeredParameter<AgreeState>
	{
		public List<StampsWithdrawProductItemViewModel> Products { get; }

		public int StampsCount { get; }

		public string ProductCountString { get; }

		public Parameter(List<StampsWithdrawProductItemViewModel> products, int stamps, string countString)
			: base(default(CancellationToken))
		{
			Products = products;
			StampsCount = stamps;
			ProductCountString = countString;
		}
	}

	private Parameter _parameter;

	private bool _alredyDisplayed;

	public string ScreenTitle => "Поздравляем! У Вас достаточно марок для получения скидки";

	private string StampCountDecliined => $"{_parameter.StampsCount} {GrammarHelper.DeclineNoun(_parameter.StampsCount, new string[3] { "марку", "марки", "марок" })}";

	public LinkedText CollectedStampsLabel => new LinkedText("Вы накопили " + StampCountDecliined, StampCountDecliined, delegate
	{
	});

	public string DetailsLabel => "При применении марок невозможно списать баллы или использовать промокод";

	public string ApplyButtonText => "Применить марки";

	public string DontApplyButtonText => "Не применять марки";

	public ObservableRangeCollection<StampsWithdrawProductItemViewModel> Products { get; } = new ObservableRangeCollection<StampsWithdrawProductItemViewModel>();

	public UICommand CloseCommand { get; } = new UICommand();

	public StampsWithdrawProductsViewModel(BrokerToken brokerToken)
		: base(brokerToken)
	{
		Products.ReplaceRange(base.Argument.Products);
		_parameter = base.Argument;
	}

	public void OnYesTapped()
	{
		CloseCommand.Trigger();
		base.Argument.TaskCompletionSource.TrySetResult(AgreeState.Yes);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		if (_alredyDisplayed)
		{
			base.Argument.TaskCompletionSource.TrySetResult(AgreeState.None);
			CloseCommand.Trigger();
		}
		_alredyDisplayed = true;
	}

	public void OnNoTapped()
	{
		CloseCommand.Trigger();
		base.Argument.TaskCompletionSource.TrySetResult(AgreeState.No);
	}

	public void OnClose()
	{
		base.Argument.TaskCompletionSource.TrySetResult(AgreeState.None);
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(AgreeState.None);
	}
}
