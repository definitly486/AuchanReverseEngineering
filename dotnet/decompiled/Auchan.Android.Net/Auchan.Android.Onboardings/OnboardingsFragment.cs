using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.Graphics;
using AndroidX.Core.Text;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AndroidX.ViewPager2.Widget;
using Auchan.Android.Authorization;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Onboardings;
using Auchan.Common.Extensions;
using Bumptech.Glide;
using Bumptech.Glide.Load.Resource.Bitmap;
using Me.Relex.CircleIndicatorLib;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.Onboardings;

internal class OnboardingsFragment : BaseDialogFragment<OnboardingsViewModel>
{
	private sealed class Controls(View view)
	{
		public sealed class DefaultLayoutControls(View view)
		{
			public View View => view;

			public ViewPager2 ViewPager { get; } = view.RequireViewById<ViewPager2>(2131297742);

			public View CloseButton { get; } = view.RequireViewById<View>(2131296795);

			public View CloseButtonContainer { get; } = view.RequireViewById<View>(2131296793);

			public CircleIndicator CircleIndicator { get; } = view.RequireViewById<CircleIndicator>(2131296781);
		}

		public View View => view;

		public DefaultLayoutControls DefaultLayout { get; } = new DefaultLayoutControls(view.RequireViewById<View>(2131296909));

		public View ProgressLayout { get; } = view.RequireViewById<View>(2131298079);

		public ErrorLayoutControls Error { get; } = new ErrorLayoutControls(view.RequireViewById<ViewGroup>(2131297111));
	}

	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493069;

	public OnboardingsFragment(Func<OnboardingsViewModel.Parameter, OnboardingsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, OnboardingsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<OnboardingsViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
		base.ViewModel.WebCommand.SafeSubscribe(OpenWebFragment, this);
		base.ViewModel.AuthCommand.SafeSubscribe(delegate
		{
			GoToMain();
		}, this);
		foreach (OnboardingItemViewModel onboarding in base.ViewModel.Onboardings)
		{
			if (onboarding.Model.Decoration.TryGetImageUrl(out string imageUrl))
			{
				Glide.With(RequireActivity()).PreloadImage(imageUrl);
			}
		}
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		ObservableRecyclerAdapter<OnboardingItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<OnboardingItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493264,
			BindViewHolderDelegate = BindViewHolderDelegate
		};
		controls.DefaultLayout.ViewPager.OffscreenPageLimit = 2;
		controls.DefaultLayout.ViewPager.Adapter = adapter;
		controls.DefaultLayout.ViewPager.RegisterOnPageChangeCallback(new ViewPager2OnPageChangeCallback(delegate(int p)
		{
			base.ViewModel.CurrentOnboardingIndex = p;
		}));
		VisibilitySwitch<OnboardingsViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<OnboardingsViewModel.VisualState>(OnboardingsViewModel.VisualState.Default)
		{
			{
				OnboardingsViewModel.VisualState.Default,
				controls.DefaultLayout.View
			},
			{
				OnboardingsViewModel.VisualState.InProgress,
				controls.ProgressLayout
			},
			{
				OnboardingsViewModel.VisualState.Error,
				controls.Error.Layout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[8]
		{
			(delegate
			{
				adapter.DataSource = base.ViewModel.Onboardings;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Onboardings")),
			(delegate
			{
				controls.DefaultLayout.CircleIndicator.CreateIndicators(base.ViewModel.OnboardingCount, 0);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OnboardingCount")),
			(delegate
			{
				controls.DefaultLayout.ViewPager.SetCurrentItem(base.ViewModel.CurrentOnboardingIndex, smoothScroll: true);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CurrentOnboardingIndex")),
			(delegate
			{
				controls.Error.Title.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				controls.Error.Message.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				controls.DefaultLayout.CircleIndicator.AnimatePageSelected(base.ViewModel.CurrentOnboardingIndex);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CurrentOnboardingIndex")),
			(delegate
			{
				controls.DefaultLayout.CircleIndicator.Visibility = base.ViewModel.IsIndicatorVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsIndicatorVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.Error.Action.OnClick(base.ViewModel.ReloadCommand.Trigger), controls.Error.ShowQrButton.OnClick(ShowLoyaltyCardQrPreviewFragment), controls.DefaultLayout.CloseButton.OnClick((Action)delegate
		{
			base.ViewModel.FinishCommand.Trigger();
			base.ViewModel.CloseButtonClick();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		Window? obj = Dialog?.Window ?? throw new InvalidOperationException("no window");
		obj.SetStatusBarColor(Color.Transparent);
		WindowCompat.SetDecorFitsSystemWindows(obj, decorFitsSystemWindows: false);
		WindowCompat.GetInsetsController(obj, view).SystemBarsBehavior = 1;
		ViewCompat.SetOnApplyWindowInsetsListener(view, new OnApplyWindowInsetsListener(delegate(WindowInsetsCompat insets)
		{
			AndroidX.Core.Graphics.Insets insets2 = insets.GetInsets(WindowInsetsCompat.Type.StatusBars());
			AndroidX.Core.Graphics.Insets insets3 = insets.GetInsets(WindowInsetsCompat.Type.NavigationBars());
			View closeButtonContainer = controls.DefaultLayout.CloseButtonContainer;
			closeButtonContainer.SetPadding(closeButtonContainer.PaddingLeft, insets2.Top, closeButtonContainer.PaddingRight, closeButtonContainer.PaddingBottom);
			View view2 = controls.View;
			view2.SetPadding(view2.PaddingLeft, view2.PaddingTop, view2.PaddingRight, insets3.Bottom);
		}));
		Dialog?.SetOnKeyListener(new DialogOnKeyListener((IDialogInterface dialogInterface, Keycode key, KeyEvent @event) => key != Keycode.Back || @event.Action != KeyEventActions.Up).AutoDisposeOnDestroy(ViewLifecycleOwner));
	}

	public override void OnResume()
	{
		base.OnResume();
		RequireActivity().SetNavbarVisibility(isVisible: false);
	}

	public override void OnPause()
	{
		base.OnPause();
		RequireActivity().SetNavbarVisibility(isVisible: true);
	}

	private void BindViewHolderDelegate(CachingViewHolder viewHolder, OnboardingItemViewModel item, int position, CompositeDisposable disposables)
	{
		SkottieAnimationView backgroundAnimation = viewHolder.RequireCachedView<SkottieAnimationView>(2131297740);
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131297741);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298646);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131296958);
		TextView textView3 = viewHolder.RequireCachedView<TextView>(2131296971);
		textView.Text = item.Model.Title;
		textView.SetTextColor(item.Model.TitleColor.ToColorStateList());
		textView.Visibility = item.IsTitleVisible.ToVisibility();
		textView2.TextFormatted = HtmlCompat.FromHtml(item.Model.Description, 0);
		textView2.Visibility = item.IsDescriptionVisible.ToVisibility();
		textView3.Text = item.Model.Action.Text;
		textView3.Visibility = item.IsButtonVisible.ToVisibility();
		string imageUrl;
		if (item.Model.Decoration.TryGetAnimationUrl(out string animationUrl))
		{
			backgroundAnimation.Visibility = ViewStates.Visible;
			imageView.Visibility = ViewStates.Gone;
			backgroundAnimation.FromUrl(animationUrl, animationUrl + "-lottie_animation");
			base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
			{
				if (position == base.ViewModel.CurrentOnboardingIndex)
				{
					backgroundAnimation.Progress = 0.0;
					backgroundAnimation.Stop();
					backgroundAnimation.Play();
				}
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CurrentOnboardingIndex")))).AddTo(disposables);
		}
		else if (item.Model.Decoration.TryGetImageUrl(out imageUrl))
		{
			backgroundAnimation.Visibility = ViewStates.Gone;
			imageView.Visibility = ViewStates.Visible;
			imageView.FromUrlAnimated(imageUrl, new FitCenter());
		}
		else
		{
			backgroundAnimation.Visibility = ViewStates.Gone;
			imageView.Visibility = ViewStates.Gone;
		}
		base.ViewModel.BindEvents(((View)textView3).OnClick((Action)delegate
		{
			base.ViewModel.DetailsCommand.Trigger(item);
		})).AddTo(disposables);
	}

	private void OpenWebFragment(WebViewModel.Parameter parameter)
	{
		if (RequireActivity().SupportFragmentManager.Fragments.FirstOrDefault() is BottomNavigationHostFragment bottomNavigationHostFragment && bottomNavigationHostFragment.CurrentContainerFragment?.ChildFragmentManager?.Fragments?.LastOrDefault((Fragment i) => i is BaseFragment) is BaseFragment baseFragment)
		{
			baseFragment.NavigateTo<WebFragment, WebViewModel.Parameter>(parameter);
		}
		else
		{
			base.ParentFragment.ParentFragmentManager.BeginTransaction().Hide(base.ParentFragment).Add<WebFragment>(base.ParentFragment, parameter.ToNavBundle())
				.AddToBackStack(null)
				.Commit();
		}
		Dismiss();
	}

	private void GoToMain()
	{
		base.ParentFragmentManager.FragmentFactory.Instantiate<ToolbarContainerFragment>().Show(base.ParentFragmentManager, "ToolbarContainerFragment");
		View.Visibility = ViewStates.Gone;
	}

	private void ShowLoyaltyCardQrPreviewFragment()
	{
		AppCompatActivity appCompatActivity = (AppCompatActivity)Platform.CurrentActivity;
		_fragmentFactory.Instantiate<LoyaltyCardPdf417PortraitFragment>().Show(appCompatActivity.SupportFragmentManager, string.Empty);
	}
}
