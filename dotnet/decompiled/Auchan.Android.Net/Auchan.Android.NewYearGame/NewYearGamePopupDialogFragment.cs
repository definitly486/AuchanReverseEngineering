using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.NewYearGame;

namespace Auchan.Android.NewYearGame;

internal class NewYearGamePopupDialogFragment : BaseBottomSheetDialogFragment<GamePopupDialogViewModel>
{
	protected override int LayoutId => 2131493477;

	public override int Theme => 2131951915;

	public NewYearGamePopupDialogFragment(Func<Fragment, GamePopupDialogViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
		base.ViewModel.GoToGameCommand.SafeSubscribe(GoToGame, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Button button = view.RequireViewById<Button>(2131297922);
		TextView textView = view.RequireViewById<TextView>(2131297960);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		CheckBox dontShowAgainCheckbox = view.RequireViewById<CheckBox>(2131297014);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296792);
		dontShowAgainCheckbox.Text = base.ViewModel.DontShowText;
		button.Text = base.ViewModel.ButtonText;
		textView.Text = base.ViewModel.PopupText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			dontShowAgainCheckbox.Checked = base.ViewModel.DontShowAgain;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DontShowAgain")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view.OnClick(base.ViewModel.OnPlayButton), button.OnClick(base.ViewModel.OnPlayButton), imageView.OnClick(base.ViewModel.OnCloseButton), ((View)linearLayout).OnClick((Action)delegate
		{
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void GoToGame(BrokerToken token)
	{
		FragmentManager supportFragmentManager = base.Activity.SupportFragmentManager;
		BottomNavigationHostFragment bottomNavigationHostFragment = supportFragmentManager.FindFragmentById(2131296564) as BottomNavigationHostFragment;
		Fragment fragment = bottomNavigationHostFragment?.CurrentContainerFragment?.ChildFragmentManager?.Fragments?.TakeLast(2)?.FirstOrDefault();
		if (fragment != null)
		{
			FragmentTransaction transaction = supportFragmentManager.BeginTransaction().Hide(bottomNavigationHostFragment);
			Bundle args = token.ToNavBundle();
			int? containerViewId = 2131296564;
			transaction.Add<NewYearGameFragment>(fragment, args, null, containerViewId).AddToBackStack(null).Commit();
			Dismiss();
		}
	}
}
