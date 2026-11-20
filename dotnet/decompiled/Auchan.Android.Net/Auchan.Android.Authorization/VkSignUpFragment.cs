using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.InfoPages;
using Auchan.Common.PersonalCabinet.Authorization;

namespace Auchan.Android.Authorization;

internal class VkSignUpFragment : BaseToolbarFragment<VkSignUpViewModel>
{
	private sealed class Controls
	{
		public View CloseButton { get; } = view.RequireViewById<View>(2131296791);

		public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

		public CompoundButton PrivacyDataConsentCheckbox { get; } = view.RequireViewById<CompoundButton>(2131297993);

		public TextView PrivacyDataConsentTextView { get; } = view.RequireViewById<TextView>(2131297994);

		public CompoundButton WantReceiveCheckbox { get; } = view.RequireViewById<CompoundButton>(2131298815);

		public TextView WantReceiveTextView { get; } = view.RequireViewById<TextView>(2131298816);

		public TextView SignUpButton { get; } = view.RequireViewById<TextView>(2131298372);

		public Controls(View view)
		{
		}
	}

	protected override int LayoutId => 2131493122;

	public VkSignUpFragment(Func<BrokerToken, VkSignUpViewModel> newViewModel)
		: base((Func<Fragment, VkSignUpViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		if (RequireParentFragment() is IToolbarContainer toolbarContainer)
		{
			toolbarContainer.Toolbar.Visibility = ViewStates.Gone;
		}
		Controls controls = new Controls(view);
		controls.Title.Text = base.ViewModel.Title;
		controls.PrivacyDataConsentTextView.AddLinkedText(base.ViewModel.PrivacyDataConsentText, new Color(ContextCompat.GetColor(Context, 2131100550)), underlineLinks: false);
		controls.WantReceiveTextView.AddLinkedText(base.ViewModel.WantReceivePromoText, new Color(ContextCompat.GetColor(Context, 2131100550)), underlineLinks: false);
		controls.SignUpButton.Text = base.ViewModel.SignUpButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			controls.SignUpButton.Enabled = base.ViewModel.IsSignUpButtonEnabled;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSignUpButtonEnabled")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.CloseButton.OnClick((Action)delegate
		{
			base.ViewModel.CloseCommand.Trigger();
		}), controls.PrivacyDataConsentCheckbox.OnCheckedChange(delegate(object? o, CompoundButton.CheckedChangeEventArgs e)
		{
			base.ViewModel.PrivacyDataConsentCheck = e.IsChecked;
		}), controls.WantReceiveCheckbox.OnCheckedChange(delegate(object? o, CompoundButton.CheckedChangeEventArgs e)
		{
			base.ViewModel.WantReceivePromoCheck = e.IsChecked;
		}), ((View)controls.SignUpButton).OnClick((Action)delegate
		{
			base.ViewModel.SignUp();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenInfoPageCommand.SafeSubscribe(OpenInfoPage, ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			base.OnNavigationButtonClick();
		}, ViewLifecycleOwner);
	}

	private void OpenInfoPage(InfoPageViewModel.Parameter parameter)
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		BottomSheetInfoPageFragmentContainer bottomSheetInfoPageFragmentContainer = supportFragmentManager.FragmentFactory.Instantiate<BottomSheetInfoPageFragmentContainer>();
		bottomSheetInfoPageFragmentContainer.Arguments = parameter.ToNavBundle();
		bottomSheetInfoPageFragmentContainer.Show(supportFragmentManager, null);
	}
}
