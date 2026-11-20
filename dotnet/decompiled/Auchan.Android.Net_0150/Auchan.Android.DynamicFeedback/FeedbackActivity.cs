using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.DynamicFeedback;

namespace Auchan.Android.DynamicFeedback;

[Activity(Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask, WindowSoftInputMode = SoftInput.AdjustPan)]
internal class FeedbackActivity : BaseActivity
{
	private ViewGroup.MarginLayoutParams? _originalContainerMargins;

	protected override void OnWindowInsetsChanged(View view, WindowInsetsCompat insets)
	{
		base.OnWindowInsetsChanged(view, insets);
		View view2 = RequireViewById<View>(2131297833);
		if (_originalContainerMargins == null)
		{
			_originalContainerMargins = new ViewGroup.MarginLayoutParams(view2.LayoutParameters);
		}
		Insets sbi = insets.GetInsets(WindowInsetsCompat.Type.SystemBars());
		view2.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.BottomMargin = _originalContainerMargins.BottomMargin + sbi.Bottom;
		});
	}

	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(2131492892);
		TryToSetLightTheme();
		Bundle bundle = Intent?.Extras;
		if (bundle != null)
		{
			ForCase forCase = (ForCase)bundle.GetInt("ForCase");
			switch (forCase)
			{
			case ForCase.PriceChecker:
			{
				DynamicFeedbackViewModel.Parameter parameter2 = new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory, ForCase.PriceChecker);
				GoToFeedback(parameter2);
				break;
			}
			case ForCase.AuthOrRegister:
			{
				DynamicFeedbackViewModel.Parameter parameter = new DynamicFeedbackViewModel.Parameter(FeedbackState.WithoutTopicAndCategory, forCase);
				GoToFeedback(parameter);
				break;
			}
			}
		}
		else
		{
			DynamicFeedbackViewModel.Parameter parameter = new DynamicFeedbackViewModel.Parameter(FeedbackState.WithoutTopicAndCategory);
			GoToFeedback(parameter);
		}
	}

	private void GoToFeedback(DynamicFeedbackViewModel.Parameter parameter)
	{
		SupportFragmentManager.Replace<DynamicFeedbackFragment>(2131297833, parameter.ToNavBundle()).Commit();
	}

	private void TryToSetLightTheme()
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(26))
		{
			int systemUiVisibility = (int)Window.DecorView.SystemUiVisibility;
			systemUiVisibility |= 0x10;
			Window.DecorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
		}
	}
}
