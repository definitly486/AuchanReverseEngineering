using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.LoyaltyProgram.Services;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public sealed class MyFavoriteCategoriesPreloaderViewModel : ScreenViewModel
{
	private readonly Lazy<FavoriteCategoriesRepository> _favoriteCategoriesRepository;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public UICommand<MyFavoriteCategoriesViewModel.Parameter> OpenCategoriesCommand { get; } = new UICommand<MyFavoriteCategoriesViewModel.Parameter>();

	public UICommand GoBackCommand { get; } = new UICommand();

	public MyFavoriteCategoriesPreloaderViewModel(Lazy<FavoriteCategoriesRepository> favoriteCategoriesRepository)
	{
		_favoriteCategoriesRepository = favoriteCategoriesRepository;
	}

	protected override async Task Start()
	{
		await base.Start();
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		if ((await _favoriteCategoriesRepository.Value.GetFavoriteCategories()).TryGetValue(out var value))
		{
			OpenCategoriesCommand.Trigger(new MyFavoriteCategoriesViewModel.Parameter(value.Data));
		}
		else
		{
			GoBackCommand.Trigger();
		}
		State = VisualState.Default;
	}
}
