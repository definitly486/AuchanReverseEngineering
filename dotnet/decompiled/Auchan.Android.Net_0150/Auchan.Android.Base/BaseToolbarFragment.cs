using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;

namespace Auchan.Android.Base;

internal abstract class BaseToolbarFragment<T> : BaseFragment<T> where T : ScreenViewModel
{
	public string ToolbarTitle
	{
		get
		{
			return ToolbarTitleLabel?.Text ?? Toolbar?.Title ?? string.Empty;
		}
		set
		{
			if (ToolbarTitleLabel != null)
			{
				ToolbarTitleLabel.Text = value;
			}
			else if (Toolbar != null)
			{
				Toolbar.Title = value;
			}
		}
	}

	protected Toolbar? Toolbar { get; private set; }

	protected TextView? ToolbarTitleLabel { get; private set; }

	protected View? NavigationButton { get; private set; }

	protected View? RightButton { get; private set; }

	protected BaseToolbarFragment(Func<Fragment, T> newViewModel)
		: base(newViewModel)
	{
	}

	public override View OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
	{
		View view = inflater.Inflate(LayoutId, container, attachToRoot: false);
		int toolbarId = GetToolbarId();
		int toolbarTitleId = GetToolbarTitleId();
		int navigationButtonId = GetNavigationButtonId();
		int rightButtonId = GetRightButtonId();
		Toolbar = view.FindViewById<Toolbar>(toolbarId);
		ToolbarTitleLabel = view.FindViewById<TextView>(toolbarTitleId);
		NavigationButton = view.FindViewById<View>(navigationButtonId);
		RightButton = view.FindViewById<View>(rightButtonId);
		if (Toolbar != null)
		{
			SetupToolbar(Toolbar);
		}
		return view;
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		Toolbar?.Dispose();
		Toolbar = null;
		ToolbarTitleLabel?.Dispose();
		ToolbarTitleLabel = null;
		NavigationButton?.Dispose();
		NavigationButton = null;
		RightButton?.Dispose();
		RightButton = null;
	}

	protected virtual int GetToolbarId()
	{
		return 2131298669;
	}

	protected virtual int GetToolbarTitleId()
	{
		return 2131298679;
	}

	protected virtual bool HasNavigationButton()
	{
		return false;
	}

	protected virtual bool HasRightButton()
	{
		return false;
	}

	protected virtual int GetNavigationButtonId()
	{
		return 2131296490;
	}

	protected virtual int GetRightButtonId()
	{
		return 2131298249;
	}

	protected virtual void SetupToolbar(Toolbar toolbar)
	{
		toolbar.Elevation = 0f;
		if (NavigationButton != null)
		{
			NavigationButton.Visibility = ((!HasNavigationButton()) ? ViewStates.Gone : ViewStates.Visible);
			NavigationButton?.SetOnClickListener(new ViewOnClickListener((Action<View>)delegate
			{
				OnNavigationButtonClick();
			}));
		}
		if (RightButton != null)
		{
			RightButton.Visibility = ((!HasRightButton()) ? ViewStates.Gone : ViewStates.Visible);
			RightButton?.SetOnClickListener(new ViewOnClickListener((Action<View>)delegate
			{
				OnRightButtonClick();
			}));
		}
	}

	protected virtual void OnNavigationButtonClick()
	{
		GoBackAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task GoBackAsync()
	{
		(await this.GetParentFragmentManagerAsync()).PopBackStack();
	}

	protected virtual void OnRightButtonClick()
	{
	}
}
