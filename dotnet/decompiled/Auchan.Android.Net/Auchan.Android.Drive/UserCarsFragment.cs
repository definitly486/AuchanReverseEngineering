using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Drive;
using Auchan.Common.Extensions;
using VisibilitySwitch;

namespace Auchan.Android.Drive;

internal class UserCarsFragment : BaseToolbarFragment<UserCarsViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	private OnBackPressedCallback? _backPressCallback;

	protected override int LayoutId => 2131493118;

	public UserCarsFragment(Func<Fragment, UserCarsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(this, OnNavigationButtonClick);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131296904);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = frameLayout.RequireViewById<TextView>(2131298080);
		RecyclerView recyclerView = viewGroup.RequireViewById<RecyclerView>(2131298187);
		constraintLayout.RequireViewById<TextView>(2131298646);
		constraintLayout.RequireViewById<TextView>(2131297563);
		constraintLayout.RequireViewById<AppCompatButton>(2131296325);
		constraintLayout.RequireViewById<Button>(2131298371).Visibility = ViewStates.Gone;
		ObservableRecyclerAdapter<UserCarsItemViewModel, CachingViewHolder> userCarsAdapter = new ObservableRecyclerAdapter<UserCarsItemViewModel, CachingViewHolder>
		{
			CreateViewHolderDelegate = CreateViewHolderDelegate,
			GetItemViewTypeDelegate = GetItemViewTypeDelegate,
			BindViewHolderDelegate = OnBindSubscription
		};
		recyclerView.SetAdapter(userCarsAdapter);
		VisibilitySwitch<VisualState> viewSwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				viewGroup
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout
			}
		};
		base.ToolbarTitle = base.ViewModel.Title;
		textView.Text = base.ViewModel.ProgressTitle;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				userCarsAdapter.DataSource = base.ViewModel.UserCars;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UserCars"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenAddCarCommand.Subscribe(OpenAddCarView).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenEditCarCommand.Subscribe(OpenEditCarView).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private CachingViewHolder CreateViewHolderDelegate(ViewGroup recyclerView, int cellLayoutId)
	{
		return new CachingViewHolder(base.LayoutInflater.Inflate(cellLayoutId, recyclerView, attachToRoot: false));
	}

	private int GetItemViewTypeDelegate(int position)
	{
		UserCarsItemViewModel userCarsItemViewModel = base.ViewModel.UserCars[position];
		return userCarsItemViewModel.ViewType switch
		{
			UserCarsItemViewType.UserCar => 2131493361, 
			UserCarsItemViewType.AddNewUserCar => 2131493206, 
			_ => throw new NotImplementedException($"Cannot resolve any cell layout id for {userCarsItemViewModel.ViewType} type"), 
		};
	}

	private void OnBindSubscription(CachingViewHolder viewHolder, UserCarsItemViewModel item, int position, CompositeDisposable disposable)
	{
		if (item.ViewType == UserCarsItemViewType.UserCar)
		{
			BindDefaultListItem(viewHolder, item, position, disposable);
		}
		else if (item.ViewType == UserCarsItemViewType.AddNewUserCar)
		{
			BindAddNewCarListItem(viewHolder, item, position, disposable);
		}
	}

	private void BindDefaultListItem(CachingViewHolder viewHolder, UserCarsItemViewModel item, int position, CompositeDisposable disposable)
	{
		TextView? textView = viewHolder.FindCachedView<TextView>(2131296628);
		TextView textView2 = viewHolder.FindCachedView<TextView>(2131296627);
		textView.Text = item.CarNumber;
		textView2.Text = item.CarName;
		viewHolder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.EditCarClick(item);
		}).AddTo(disposable);
	}

	private void BindAddNewCarListItem(CachingViewHolder viewHolder, UserCarsItemViewModel item, int position, CompositeDisposable disposable)
	{
		viewHolder.FindCachedView<TextView>(2131296355).Text = base.ViewModel.AddNewCarButtonText;
		viewHolder.ItemView.OnClick(base.ViewModel.AddCarClick).AddTo(disposable);
	}

	private void OpenAddCarView(CarFormViewModel.Parameter parameter)
	{
		AddCarPopupFragment addCarPopupFragment = _fragmentFactory.Instantiate<AddCarPopupFragment>();
		addCarPopupFragment.Arguments = parameter.ToNavBundle();
		addCarPopupFragment.Show(base.ChildFragmentManager, string.Empty);
	}

	private void OpenEditCarView(CarFormViewModel.Parameter parameter)
	{
		EditCarPopupFragment editCarPopupFragment = _fragmentFactory.Instantiate<EditCarPopupFragment>();
		editCarPopupFragment.Arguments = parameter.ToNavBundle();
		editCarPopupFragment.Show(base.ChildFragmentManager, string.Empty);
	}
}
