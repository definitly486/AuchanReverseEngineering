using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Helpers;
using DryIoc;
using Google.Android.Material.Button;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Drive;

internal class AskIsPersonArrivedFragment : BaseBottomSheetDialogFragment<AskIsPersonArrivedViewModel>
{
	private readonly TaskCompletionSource<AgreeState> _tcs = new TaskCompletionSource<AgreeState>();

	private UserCarCell _defaultCarCell;

	private AddNewCarCell _addNewCarCell;

	private MaterialButton _yesButton;

	protected override int LayoutId => 2131493449;

	public override int Theme => 2131951914;

	public AskIsPersonArrivedFragment(Func<AskIsPersonArrivedViewModel.Parameter, AskIsPersonArrivedViewModel> newViewModel)
		: base((Func<Fragment, AskIsPersonArrivedViewModel>)((Fragment fragment) => newViewModel(fragment.RequireNavParam<AskIsPersonArrivedViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OnAnswerCommand.ObserveOn(Auchan.Common.Helpers.MainThread.Scheduler).Subscribe(OnAnswer).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298649);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		TextView textView2 = view.RequireViewById<TextView>(2131296962);
		_yesButton = view.RequireViewById<MaterialButton>(2131296459);
		AppCompatButton appCompatButton = view.RequireViewById<AppCompatButton>(2131296458);
		TextView textView3 = view.RequireViewById<TextView>(2131296634);
		_defaultCarCell = view.RequireViewById<UserCarCell>(2131296906);
		_addNewCarCell = view.RequireViewById<AddNewCarCell>(2131296352);
		textView3.Text = base.ViewModel.DefaultCarSectionTitle;
		_yesButton.Text = base.ViewModel.YesButtonText;
		appCompatButton.Text = base.ViewModel.NoButtonText;
		textView2.Text = base.ViewModel.Message;
		textView.Text = base.ViewModel.Title;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			ShowDefaultCarSection(base.ViewModel.DefaultCar);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DefaultCar")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)_defaultCarCell).OnClick((Action)delegate
		{
			OpenSelectCarScreen().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)_addNewCarCell).OnClick((Action)delegate
		{
			OpenAddCarPopup().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)imageView).OnClick((Action)delegate
		{
			OnAnswer(AgreeState.None);
		}), ((View)_yesButton).OnClick((Action)delegate
		{
			base.ViewModel.Reply(AgreeState.Yes).SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)appCompatButton).OnClick((Action)delegate
		{
			OnAnswer(AgreeState.No);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private async Task OpenSelectCarScreen()
	{
		if (Platform.CurrentActivity is AppCompatActivity)
		{
			Car car = await Show<SelectCarFragment>().Execute();
			if (car != null)
			{
				base.ViewModel.DefaultCar = car;
			}
		}
	}

	public Task<AgreeState> Execute()
	{
		return _tcs.Task;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		_tcs.TrySetResult(AgreeState.None);
	}

	private void OnAnswer(AgreeState result)
	{
		_tcs.TrySetResult(result);
		Dismiss();
	}

	private void ShowDefaultCarSection(Car? car)
	{
		bool flag = car != null;
		_defaultCarCell.Visibility = flag.ToVisibility();
		_yesButton.Enabled = flag;
		_addNewCarCell.Visibility = (!flag).ToVisibility();
		if (car != null)
		{
			_defaultCarCell.CarNumber = car.CarNumber;
			_defaultCarCell.CarDescription = GetCarDescription(car.CarColor, car.CarMark);
			_defaultCarCell.ForceChangeData();
		}
	}

	private string GetCarDescription(string color, string mark)
	{
		return color + " " + mark;
	}

	private async Task OpenAddCarPopup()
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			AddCarPopupFragment addCarPopupFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<AddCarPopupFragment>();
			addCarPopupFragment.Arguments = new CarFormViewModel.Parameter().ToNavBundle();
			addCarPopupFragment.Show(appCompatActivity.SupportFragmentManager, string.Empty);
			Car newCar = await addCarPopupFragment.WaitAddingCar();
			await base.ViewModel.UpdateCars(newCar);
		}
	}
}
