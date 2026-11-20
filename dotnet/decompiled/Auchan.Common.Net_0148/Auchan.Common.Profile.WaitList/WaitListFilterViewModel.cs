using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Navigation;

namespace Auchan.Common.Profile.WaitList;

public class WaitListFilterViewModel : ScreenViewModel<WaitListFilterViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<bool>
	{
		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private readonly WaitListProducts _waitListProducts;

	public string Title => "Фильтр";

	public string Message => "Наличие товара в магазине";

	public string SwitchText => "Снова в наличии";

	public string ApplyButtonText => "Применить";

	public bool OnlyActive => _waitListProducts.OnlyActive;

	public UICommand CloseCommand { get; } = new UICommand();

	public override NavigationPossibilityType OnNavigateFrom()
	{
		return NavigationPossibilityType.Impossible;
	}

	public WaitListFilterViewModel(BrokerToken token, WaitListProducts waitListProducts)
		: base(token)
	{
		_waitListProducts = waitListProducts;
	}

	public void OnAnswer(bool answer)
	{
		base.Argument.TaskCompletionSource.TrySetResult(answer);
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(OnlyActive);
	}
}
