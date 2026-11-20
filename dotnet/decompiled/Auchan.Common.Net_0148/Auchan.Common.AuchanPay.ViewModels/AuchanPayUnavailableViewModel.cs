using System;
using System.Reactive;
using System.Reactive.Subjects;
using Auchan.Common.Base;
using Auchan.Common.Extensions;

namespace Auchan.Common.AuchanPay.ViewModels;

public class AuchanPayUnavailableViewModel : ScreenViewModel
{
	private readonly Subject<Unit> _closeCommand = new Subject<Unit>();

	public string Title => "Счет Ашан Pay\nбольше не доступен.";

	public string ButtonName => "Понятно";

	public IObservable<Unit> CloseCommand => _closeCommand.Debounce();

	public void Close()
	{
		_closeCommand.OnNext(Unit.Default);
	}
}
