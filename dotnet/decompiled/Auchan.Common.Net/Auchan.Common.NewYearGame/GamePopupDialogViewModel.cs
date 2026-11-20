using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;

namespace Auchan.Common.NewYearGame;

public class GamePopupDialogViewModel : ScreenViewModel
{
	private readonly Subject<Unit> _onCloseButton = new Subject<Unit>();

	private readonly IAdminContext _adminContext;

	private readonly IDataBroker _dataBroker;

	public string PopupText => _adminContext.AppConfig?.GameConfig?.PopupText ?? string.Empty;

	public string ButtonText => _adminContext.AppConfig?.GameConfig?.ButtonText ?? "Играть";

	public string DontShowText => "Больше не показывать";

	public bool DontShowAgain
	{
		get
		{
			return _adminContext.GamePopupDontShowFlag;
		}
		set
		{
			if (DontShowAgain != value)
			{
				_adminContext.GamePopupDontShowFlag = value;
				RaisePropertyChanged("DontShowAgain");
			}
		}
	}

	public IObservable<Unit> CloseCommand => _onCloseButton.Debounce();

	public UICommand<BrokerToken> GoToGameCommand { get; } = new UICommand<BrokerToken>();

	public GamePopupDialogViewModel(IAdminContext adminContext, IDataBroker dataBroker)
	{
		_adminContext = adminContext;
		_dataBroker = dataBroker;
		_adminContext.OnGamePopupShown();
	}

	protected override async Task Start()
	{
		await base.Start();
		DontShowAgain = false;
	}

	public void OnPlayButton()
	{
		int? num = _adminContext.AppConfig?.GameConfig?.Id;
		if (num.HasValue)
		{
			int valueOrDefault = num.GetValueOrDefault();
			GoToGameCommand.Trigger(_dataBroker.Push(new NewYearGameViewModel.Parameter(valueOrDefault)));
		}
		else
		{
			_onCloseButton.OnNext(Unit.Default);
		}
	}

	public void OnCloseButton()
	{
		_onCloseButton.OnNext(Unit.Default);
	}
}
