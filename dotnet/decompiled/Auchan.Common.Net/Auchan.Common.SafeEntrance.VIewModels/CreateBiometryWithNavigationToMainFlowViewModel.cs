using System;
using System.Reactive;
using System.Reactive.Subjects;
using Auchan.Common.Extensions;
using Auchan.Common.SafeEntrance.Managers;
using Auchan.Common.SafeEntrance.ViewModels;

namespace Auchan.Common.SafeEntrance.VIewModels;

public class CreateBiometryWithNavigationToMainFlowViewModel : CreateBiometryViewModel
{
	private readonly Subject<Unit> _navigateToMain = new Subject<Unit>();

	public IObservable<Unit> NavigateToMainCommand => _navigateToMain.Debounce();

	public CreateBiometryWithNavigationToMainFlowViewModel(ISafeEntranceManager safeEntranceManager)
		: base(safeEntranceManager)
	{
	}

	protected override void Close()
	{
		_navigateToMain.OnNext(Unit.Default);
	}
}
