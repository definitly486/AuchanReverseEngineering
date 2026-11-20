using System;
using System.Reactive.Subjects;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;

namespace Auchan.Common.LoyaltyProgram.ViewModels.CardBlock;

public class LoyaltyCardReissuePlasticOptionsViewModel : ScreenViewModel
{
	private readonly Subject<LoyaltyCardReattachPlasticCardNavigationParameter> _navigateToReattachPlastic = new Subject<LoyaltyCardReattachPlasticCardNavigationParameter>();

	public string ScreenTitle => "Так-тааак...";

	public string ScreenDialogMessage => "У вас уже есть карта АШАН!\n\nХотите добавить новую карту?";

	public string DismissButtonText => "Отмена";

	public string WantANewCardButtonText => "Добавить новую карту";

	public IObservable<LoyaltyCardReattachPlasticCardNavigationParameter> NavigateToReattachPlasticCommand => _navigateToReattachPlastic.Debounce();

	public void OnWantANewCardSelected()
	{
		_navigateToReattachPlastic.OnNext(new LoyaltyCardReattachPlasticCardNavigationParameter
		{
			ReattachType = LoyaltyCardReattachType.ReattachPlastic
		});
	}
}
