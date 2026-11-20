using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.NewYearGame;
using Google.Android.Material.BottomNavigation;

namespace Auchan.Android.NewYearGame;

internal class SantaPopupDialogFragment : BaseDialogFragment<SantaPopupDialogViewModel>
{
	private ImageView _closeButton;

	private SkottieAnimationView _animationView;

	private SkottieAnimationView _closeAnimationView;

	protected override int LayoutId => 2131493478;

	public override int Theme => 2131952518;

	public SantaPopupDialogFragment(Func<SantaPopupDialogViewModel.Parameter, SantaPopupDialogViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, SantaPopupDialogViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<SantaPopupDialogViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			OnClose().SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.CloseImmediateCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
		base.ViewModel.GoToGameCommand.SafeSubscribe(GoToGame, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_closeButton = view.RequireViewById<ImageView>(2131296791);
		_animationView = view.RequireViewById<SkottieAnimationView>(2131296443);
		_closeAnimationView = view.RequireViewById<SkottieAnimationView>(2131296790);
		if (base.Activity != null && base.Activity is MainActivity mainActivity)
		{
			BottomNavigationView bottomNavigationView = mainActivity.RequireViewById<BottomNavigationView>(2131296565);
			ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297421);
			ConstraintLayout.LayoutParams layoutParams = _animationView.LayoutParameters as ConstraintLayout.LayoutParams;
			ConstraintLayout.LayoutParams layoutParams2 = _closeAnimationView.LayoutParameters as ConstraintLayout.LayoutParams;
			layoutParams.BottomMargin += bottomNavigationView.Height;
			layoutParams2.BottomMargin += bottomNavigationView.Height;
			ConstraintSet constraintSet = new ConstraintSet();
			constraintSet.Clone(constraintLayout);
			if (base.ViewModel.Position == GameAnimationPosition.Bottom)
			{
				constraintSet.Connect(2131296443, 4, 2131297421, 4);
				constraintSet.Connect(2131296443, 6, 2131297421, 6);
				constraintSet.Connect(2131296443, 7, 2131297421, 7);
				constraintSet.Connect(2131296790, 4, 2131297421, 4);
				constraintSet.Connect(2131296790, 6, 2131297421, 6);
				constraintSet.Connect(2131296790, 7, 2131297421, 7);
			}
			if (base.ViewModel.Position == GameAnimationPosition.LeftCenter)
			{
				constraintSet.Connect(2131296443, 3, 2131297421, 3);
				constraintSet.Connect(2131296443, 4, 2131297421, 4);
				constraintSet.Connect(2131296443, 1, 2131297421, 1);
				constraintSet.Connect(2131296790, 3, 2131297421, 3);
				constraintSet.Connect(2131296790, 4, 2131297421, 4);
				constraintSet.Connect(2131296790, 1, 2131297421, 1);
			}
			if (base.ViewModel.Position == GameAnimationPosition.RightCenter)
			{
				constraintSet.Connect(2131296443, 3, 2131297421, 3);
				constraintSet.Connect(2131296443, 4, 2131297421, 4);
				constraintSet.Connect(2131296443, 2, 2131297421, 2);
				constraintSet.Connect(2131296790, 3, 2131297421, 3);
				constraintSet.Connect(2131296790, 4, 2131297421, 4);
				constraintSet.Connect(2131296790, 2, 2131297421, 2);
			}
			_animationView.LayoutParameters = layoutParams;
			_closeButton.Visibility = base.ViewModel.CloseButtonEnabled.ToVisibility();
			if (base.ViewModel.CloseButtonEnabled)
			{
				_closeButton.FromUrl(base.ViewModel.CloseButtonImageUrl, originalSize: true);
				switch (base.ViewModel.CloseButtonPosition)
				{
				case GameAnimationClosePosition.TopLeft:
					constraintSet.Connect(2131296791, 3, 2131296443, 3);
					constraintSet.Connect(2131296791, 6, 2131296443, 6);
					break;
				case GameAnimationClosePosition.TopRight:
					constraintSet.Connect(2131296791, 3, 2131296443, 3);
					constraintSet.Connect(2131296791, 7, 2131296443, 7);
					break;
				case GameAnimationClosePosition.BottomLeft:
					constraintSet.Connect(2131296791, 4, 2131296443, 4);
					constraintSet.Connect(2131296791, 6, 2131296443, 6);
					break;
				case GameAnimationClosePosition.BottomRight:
					constraintSet.Connect(2131296791, 4, 2131296443, 4);
					constraintSet.Connect(2131296791, 7, 2131296443, 7);
					break;
				}
				if (base.ViewModel.CloseAnimationEnabled)
				{
					_closeAnimationView.LayoutParameters = layoutParams2;
					_closeAnimationView.FromUrl(base.ViewModel.CloseAnimationUrl, base.ViewModel.CloseAnimationUrl + "-lottie_animation");
				}
			}
			constraintSet.ApplyTo(constraintLayout);
			if (base.ViewModel.CloseButtonEnabled)
			{
				ConstraintLayout.LayoutParams layoutParams3 = _closeButton.LayoutParameters as ConstraintLayout.LayoutParams;
				layoutParams3.TopMargin = Converter.DpToPx(base.ViewModel.CloseButtonVerticalOffset);
				layoutParams3.MarginEnd = Converter.DpToPx(base.ViewModel.CloseButtonHorizontalOffset);
				layoutParams3.MarginStart = Converter.DpToPx(base.ViewModel.CloseButtonHorizontalOffset);
				layoutParams3.BottomMargin = Converter.DpToPx(base.ViewModel.CloseButtonVerticalOffset);
				_closeButton.LayoutParameters = layoutParams3;
			}
		}
		_animationView.Visibility = ViewStates.Visible;
		_closeAnimationView.Visibility = ViewStates.Gone;
		_animationView.FromUrl(base.ViewModel.AnimationUrl, base.ViewModel.AnimationUrl + "-lottie_animation");
		_animationView.Play();
		base.ViewModel.BindEvents(_animationView.OnClick(base.ViewModel.OnPlayButton), _closeAnimationView.OnClick(base.ViewModel.OnPlayButton), _closeButton.OnClick(base.ViewModel.OnCloseButton), View.OnClick(base.ViewModel.OnCloseButton)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override Dialog OnCreateDialog(Bundle savedInstanceState)
	{
		Dialog dialog = base.OnCreateDialog(savedInstanceState);
		Window window = dialog.Window;
		window.SetStatusBarColor(Color.Transparent);
		if (OperatingSystem.IsAndroidVersionAtLeast(26))
		{
			window.SetNavigationBarColor(Color.Transparent);
		}
		return dialog;
	}

	private async Task OnClose()
	{
		if (!base.ViewModel.CloseAnimationEnabled || _closeAnimationView.Animation == null)
		{
			Dismiss();
			return;
		}
		_animationView.Visibility = ViewStates.Gone;
		_closeAnimationView.Visibility = ViewStates.Visible;
		_closeButton.Visibility = ViewStates.Gone;
		_closeAnimationView.Play();
		await Task.Delay(_closeAnimationView.Animation.Duration);
		Dismiss();
	}

	private void GoToGame(BrokerToken token)
	{
		Dismiss();
		AndroidX.Fragment.App.Fragment fragment = base.Activity.SupportFragmentManager.Fragments.First();
		base.Activity.SupportFragmentManager.BeginTransaction().Hide(fragment).Add<NewYearGameFragment>(fragment, token.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}
}
