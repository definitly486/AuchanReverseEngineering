using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;

namespace Auchan.Common.Tooltips;

public class TooltipViewModel : ScreenViewModel
{
	public class Parameter
	{
		public Tooltip[] Tooltips { get; }

		public Parameter(Tooltip[] tooltips)
		{
			Tooltips = tooltips;
		}
	}

	private readonly IAdminContext _adminContext;

	private readonly Tooltip[] _tooltips;

	[CompilerGenerated]
	private int _003CCurrentIndex_003Ek__BackingField;

	protected override string ScreenName => $"loyality_tutorial_{CurrentIndex + 1}step";

	private int CurrentIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CCurrentIndex_003Ek__BackingField != value)
			{
				_003CCurrentIndex_003Ek__BackingField = value;
				RaisePropertyChanged("CurrentTooltip");
				RaisePropertyChanged("NextText");
				RaisePropertyChanged("TitleText");
				RaisePropertyChanged("DescriptionText");
				RaisePropertyChanged("TitleIconType");
				RaisePropertyChanged("TitleTargetType");
				RaisePropertyChanged("ScreenName");
				RaisePropertyChanged("TooltipNumberText");
				RaisePropertyChanged("CurrentIndex");
			}
		}
	}

	private Tooltip CurrentTooltip => _tooltips[CurrentIndex];

	public string SkipText => "Пропустить";

	public string NextText
	{
		get
		{
			if (CurrentTooltip.Target == TooltipTargetType.FavoriteCategories)
			{
				return "Здорово!";
			}
			if (CurrentIndex < _tooltips.Length - 1)
			{
				return "Дальше";
			}
			return "Понятно";
		}
	}

	public string TooltipNumberText => $"{CurrentIndex + 1} / {_tooltips.Length}";

	public int TitleMaxLines => 2;

	public int DescriptionMaxLines => 3;

	public string TitleText => CurrentTooltip.Title;

	public string DescriptionText => CurrentTooltip.Description;

	public TooltipTitleIconType TitleIconType => CurrentTooltip.TitleIcon;

	public TooltipTargetType TitleTargetType => CurrentTooltip.Target;

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand NextCommand { get; } = new UICommand();

	public UICommand RedrawCommand { get; } = new UICommand();

	public TooltipViewModel(Parameter parameter, IAdminContext adminContext)
	{
		_tooltips = parameter.Tooltips;
		_adminContext = adminContext;
	}

	protected override async Task Start()
	{
		await base.Start();
		_adminContext.OnTooltipPopupShown();
		NextCommand.Debounce(100).Subscribe(delegate
		{
			ShowNext();
		}).AddTo(base.CloseDisposable);
		ReceiveMethodSelectElementViewModel.ReceiveMethodsSelectUpdated.Subscribe(delegate
		{
			RedrawCommand.Trigger();
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		RedrawCommand.Trigger();
	}

	private void ShowNext()
	{
		if (CurrentIndex + 1 >= _tooltips.Length)
		{
			CloseCommand.Trigger();
		}
		else
		{
			CurrentIndex = MathHelper.Clamp(CurrentIndex + 1, 0, _tooltips.Length - 1);
		}
	}
}
