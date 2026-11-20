using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.SafeEntrance;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Profile;

namespace Auchan.Android.Profile.SafeEntrance;

internal class SafeEntranceFragment : BaseToolbarFragment<SafeEntranceViewModel>
{
	private SwitchCompat _safeEntranceSwitch;

	private SwitchCompat _biometrySwitch;

	protected override int LayoutId => 2131493082;

	public SafeEntranceFragment(Func<Fragment, SafeEntranceViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateToCreateBiometryCommand.SafeSubscribe(delegate
		{
			NavigateTo<CreatePinCodeFragment>();
		}, this);
		base.ViewModel.OnPropertyChanges((SafeEntranceViewModel x) => x.IsPinCodeCreated).StartWith(base.ViewModel.IsPinCodeCreated).ObserveOn(MainThread.Scheduler)
			.Subscribe(delegate
			{
				SetPinChecked();
			})
			.AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.OnPropertyChanges((SafeEntranceViewModel x) => x.IsBiometryCreated).StartWith(base.ViewModel.IsBiometryCreated).ObserveOn(MainThread.Scheduler)
			.Subscribe(delegate
			{
				SetBiometryChecked();
			})
			.AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView safeEntranceTitle = view.RequireViewById<TextView>(2131298272);
		TextView biometryTitle = view.RequireViewById<TextView>(2131298268);
		_safeEntranceSwitch = view.RequireViewById<SwitchCompat>(2131297907);
		_biometrySwitch = view.RequireViewById<SwitchCompat>(2131296536);
		LinearLayout safeEntranceChangePinContainer = view.RequireViewById<LinearLayout>(2131298270);
		LinearLayout biometryContainer = view.RequireViewById<LinearLayout>(2131298267);
		NavigationCellView changePinNavigationCell = view.RequireViewById<NavigationCellView>(2131298269);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				base.ToolbarTitle = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				safeEntranceTitle.Text = base.ViewModel.SafeEntranceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SafeEntranceText")),
			(delegate
			{
				biometryTitle.Text = base.ViewModel.BiometrySafeEntrance;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BiometrySafeEntrance")),
			(delegate
			{
				changePinNavigationCell.Text = base.ViewModel.ChangePinCodeText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ChangePinCodeText")),
			(delegate
			{
				safeEntranceChangePinContainer.Visibility = base.ViewModel.IsPinCodeCreated.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPinCodeCreated")),
			(delegate
			{
				biometryContainer.Visibility = base.ViewModel.IsBiometryEnabledOnDevice.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsBiometryEnabledOnDevice"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(changePinNavigationCell.OnClick(base.ViewModel.OnNavigateToUpdatePinCodeClick)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnResume()
	{
		base.OnResume();
		_safeEntranceSwitch.Checked = base.ViewModel.IsPinCodeCreated;
		_safeEntranceSwitch.RxValueChanged().ObserveOn(MainThread.Scheduler).Subscribe(delegate(EventPattern<CompoundButton.CheckedChangeEventArgs> e)
		{
			bool isChecked = e.EventArgs.IsChecked;
			base.ViewModel.ToggleSafeEntrance(isChecked);
		})
			.AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnPause);
		_biometrySwitch.Checked = base.ViewModel.IsBiometryCreated;
		_biometrySwitch.RxValueChanged().ObserveOn(MainThread.Scheduler).Subscribe(delegate(EventPattern<CompoundButton.CheckedChangeEventArgs> e)
		{
			bool isChecked = e.EventArgs.IsChecked;
			base.ViewModel.ToggleEnterWithBiometry(isChecked).SafeFireAndForget((Action<Exception>)null, false);
		})
			.AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnPause);
	}

	private void SetPinChecked()
	{
		bool isPinCodeCreated = base.ViewModel.IsPinCodeCreated;
		_safeEntranceSwitch.Checked = isPinCodeCreated;
	}

	private void SetBiometryChecked()
	{
		bool isBiometryCreated = base.ViewModel.IsBiometryCreated;
		_biometrySwitch.Checked = isBiometryCreated;
	}
}
