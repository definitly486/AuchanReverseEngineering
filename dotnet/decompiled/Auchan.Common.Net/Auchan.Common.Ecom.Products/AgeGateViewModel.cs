using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;

namespace Auchan.Common.Ecom.Products;

public class AgeGateViewModel : ScreenViewModel<AgeGateViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<AgreeState>
	{
		public string Title { get; init; } = "Вам есть 18 лет?";

		public string Message { get; init; } = "Здесь содержится информация, не рекомендуемая для несовершеннолетних";

		public string Yes { get; init; } = "Да, мне есть 18 лет";

		public string No { get; init; } = "Нет";

		public Parameter(CancellationToken cancellationToken = default(CancellationToken))
			: base(cancellationToken)
		{
		}
	}

	public const string DEFAULT_TITLE_TEXT = "Вам есть 18 лет?";

	public const string DEFAULT_MESSAGE_TEXT = "Здесь содержится информация, не рекомендуемая для несовершеннолетних";

	public const string DEFAULT_YES_TEXT = "Да, мне есть 18 лет";

	public const string DEFAULT_NO_TEXT = "Нет";

	private AgreeState _result;

	private readonly IEcomContext _ecomContext;

	public string Title => base.Argument.Title;

	public string Message => base.Argument.Message;

	public string YesButtonText => base.Argument.Yes;

	public string NoButtonText => base.Argument.No;

	public UICommand CloseCommand { get; } = new UICommand();

	public AgeGateViewModel(BrokerToken token, IEcomContext ecomContext)
		: base(token)
	{
		_ecomContext = ecomContext;
		base.Argument.CancellationToken.Register(delegate
		{
			Close();
		}).AddTo(base.CloseDisposable);
	}

	public override NavigationPossibilityType OnNavigateFrom()
	{
		return NavigationPossibilityType.Impossible;
	}

	public void OnYes()
	{
		_result = AgreeState.Yes;
		Close();
	}

	public void OnNo()
	{
		_result = AgreeState.No;
		Close();
	}

	public void Close()
	{
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		_ecomContext.AgeGateAgreement = _result;
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
