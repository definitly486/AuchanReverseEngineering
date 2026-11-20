using System;
using System.Reactive;
using System.Reactive.Subjects;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class LoyaltyCardDetailsEmployeeViewModel : ScreenViewModel
{
	private readonly Subject<Unit> _navigateToCardBlockOptions = new Subject<Unit>();

	private readonly Subject<InfoPageViewModel.Parameter> _navigateToInfoPage = new Subject<InfoPageViewModel.Parameter>();

	public IObservable<Unit> NavigateToCardBlockOptionsCommand => _navigateToCardBlockOptions.Debounce();

	public IObservable<InfoPageViewModel.Parameter> NavigateToInfoPageCommand => _navigateToInfoPage.Debounce();

	public string ScreenTitle => "Подробнее о карте";

	public string BlockCardButtonText => "Заблокировать карту";

	public string InfoTitle => "Ваша карта АШАН это:";

	public AttributedText InfoText => new AttributedText("- Эксклюзивный кешбэк 10% баллами на все товары без специальных ценников\n\n- Дополнительный кешбэк 10% на все товары с промо кешбэк\n\n- Праздничный кешбэк 10% баллами за неделю до и после дня рождения\n\n- Оплата до 99% покупок баллами по курсу 1\u00a0балл\u00a0=\u00a01\u00a0рубль", "1\u00a0балл\u00a0=\u00a01\u00a0рубль");

	public string LoyaltyRulesText => "Правила программы Лояльности для сотрудников";

	public string PrivilegesClubText => "Клуб привилегий АШАН";

	public void OnBlockCardSelected()
	{
		_navigateToCardBlockOptions.OnNext(Unit.Default);
	}

	public void OnOpenLoyaltyRules()
	{
		_navigateToInfoPage.OnNext(new InfoPageViewModel.Parameter(InfoType.EmployeesLoyaltyPolicy));
	}

	public void OnOpenPrivilegesClub()
	{
		_navigateToInfoPage.OnNext(new InfoPageViewModel.Parameter(InfoType.EmployeesLoyaltyPrivileges));
	}
}
