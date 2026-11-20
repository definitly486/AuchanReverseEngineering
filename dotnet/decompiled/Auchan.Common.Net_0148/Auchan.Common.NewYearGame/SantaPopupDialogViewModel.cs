using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;

namespace Auchan.Common.NewYearGame;

public class SantaPopupDialogViewModel : ScreenViewModel
{
	public class Parameter
	{
		public GameAnimation Animation { get; }

		public NewYearGamePlayPosition Position { get; }

		public Parameter(GameAnimation animation, NewYearGamePlayPosition position)
		{
			Animation = animation;
			Position = position;
		}
	}

	private bool _initiatedClose;

	private readonly Subject<Unit> _onCloseButton = new Subject<Unit>();

	private readonly Subject<Unit> _onCloseImmediate = new Subject<Unit>();

	private readonly Subject<Unit> _onPlayButton = new Subject<Unit>();

	private readonly IAdminContext _adminContext;

	private readonly Parameter _parameter;

	private readonly IDataBroker _dataBroker;

	public string AnimationUrl => _parameter.Animation.AnimationUrl;

	public GameAnimationPosition Position => _parameter.Animation.Position;

	public bool CloseButtonEnabled => _parameter.Animation.CloseButtonEnabled;

	public string CloseButtonImageUrl => _parameter.Animation.CloseButtonImageUrl;

	public GameAnimationClosePosition CloseButtonPosition => _parameter.Animation.ClosePosition;

	public int CloseButtonHorizontalOffset => _parameter.Animation.CloseButtonHorizontalOffset;

	public int CloseButtonVerticalOffset => _parameter.Animation.CloseButtonVerticalOffset;

	public bool CloseAnimationEnabled => !string.IsNullOrWhiteSpace(_parameter.Animation.CloseAnimationUrl);

	public string CloseAnimationUrl => _parameter.Animation.CloseAnimationUrl;

	public IObservable<Unit> CloseImmediateCommand => _onCloseImmediate.Debounce();

	public IObservable<Unit> CloseCommand => _onCloseButton.Debounce();

	public UICommand<BrokerToken> GoToGameCommand { get; } = new UICommand<BrokerToken>();

	public SantaPopupDialogViewModel(IAdminContext adminContext, Parameter parameter, IDataBroker dataBroker)
	{
		_adminContext = adminContext;
		_parameter = parameter;
		_dataBroker = dataBroker;
	}

	protected override async Task Start()
	{
		await base.Start();
		_adminContext.OnGameAnimationPopupShown();
		_initiatedClose = false;
	}

	public void OnPlayButton()
	{
		if (_initiatedClose)
		{
			_onCloseImmediate.OnNext(Unit.Default);
			return;
		}
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
		if (_initiatedClose)
		{
			_onCloseImmediate.OnNext(Unit.Default);
			return;
		}
		_initiatedClose = true;
		_onCloseButton.OnNext(Unit.Default);
	}
}
