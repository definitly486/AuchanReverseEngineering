using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Extensions;
using VisibilitySwitch;

namespace Auchan.Android.Drive;

internal class SelectCarFragment : BaseDialogFragment<SelectCarViewModel>
{
	private readonly TaskCompletionSource<Car?> _tcs = new TaskCompletionSource<Car>();

	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493094;

	public SelectCarFragment(Func<Fragment, SelectCarViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131296904);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		constraintLayout.RequireViewById<TextView>(2131298646);
		constraintLayout.RequireViewById<TextView>(2131297563);
		AppCompatButton appCompatButton = constraintLayout.RequireViewById<AppCompatButton>(2131296325);
		Button button = constraintLayout.RequireViewById<Button>(2131298371);
		RecyclerView recyclerView = viewGroup.RequireViewById<RecyclerView>(2131298187);
		TextView textView = viewGroup.RequireViewById<TextView>(2131298679);
		AppCompatImageButton appCompatImageButton = viewGroup.RequireViewById<AppCompatImageButton>(2131296490);
		button.Visibility = ViewStates.Gone;
		textView.Text = base.ViewModel.Title;
		ObservableRecyclerAdapter<UserCarsItemViewModel, CachingViewHolder> userCarsAdapter = new ObservableRecyclerAdapter<UserCarsItemViewModel, CachingViewHolder>
		{
			CreateViewHolderDelegate = CreateViewHolderDelegate,
			GetItemViewTypeDelegate = GetItemViewTypeDelegate,
			BindViewHolderDelegate = OnBindCarCell
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
		base.ViewModel.BindEvents(appCompatImageButton.OnClick(Dismiss), appCompatButton.OnClick(Dismiss)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenAddCarCommand.Subscribe(OpenAddCarView).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.UpdatedCarCommand.Subscribe(delegate(Car _)
		{
			SetResult(_);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenEditCarCommand.Subscribe(OpenEditCarView).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private CachingViewHolder CreateViewHolderDelegate(ViewGroup recyclerView, int cellLayoutId)
	{
		return new CachingViewHolder(base.LayoutInflater.Inflate(cellLayoutId, recyclerView, attachToRoot: false));
	}

	public Task<Car?> Execute()
	{
		return _tcs.Task;
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

	private void OnBindCarCell(CachingViewHolder viewHolder, UserCarsItemViewModel item, int position, CompositeDisposable disposable)
	{
		if (item.ViewType == UserCarsItemViewType.AddNewUserCar)
		{
			viewHolder.FindCachedView<TextView>(2131296355).Text = base.ViewModel.AddNewCarButtonText;
			viewHolder.ItemView.OnClick(base.ViewModel.AddCarClick).AddTo(disposable);
			return;
		}
		TextView? textView = viewHolder.FindCachedView<TextView>(2131296628);
		TextView textView2 = viewHolder.FindCachedView<TextView>(2131296627);
		ConstraintLayout constraintLayout = viewHolder.FindCachedView<ConstraintLayout>(2131297037);
		textView.Text = item.CarNumber;
		textView2.Text = item.CarName;
		viewHolder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.SetAsDefault(item).SafeFireAndForget((Action<Exception>)null, false);
		});
		((View)constraintLayout).OnClick((Action)delegate
		{
			base.ViewModel.EditCarClick(item);
		});
	}

	public override void OnDestroy()
	{
		_tcs.TrySetResult(null);
		base.OnDestroy();
	}

	private void SetResult(Car car)
	{
		_tcs.TrySetResult(car);
		Dismiss();
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
