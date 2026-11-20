using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Java.Interop;
using Newtonsoft.Json;

namespace Auchan.Android.Common.HighlightScreen;

internal class HighlightScreenFragment : BaseDialogFragment<HighlightScreenViewModel>, IDialogInterfaceOnKeyListener, IJavaObject, IDisposable, IJavaPeerable
{
	public const string ViewsKey = "highlight_fragment_views_key";

	public const string TargetKey = "highlight_fragment_target_key";

	public const string SearchRootKey = "highlight_fragment_search_root_key";

	private readonly Rect _cacheRect = new Rect();

	private List<(View view, float insets, float? customRadius)> _targets;

	private ViewGroup _targetView;

	private HighlightDrawerView _drawerView;

	private RelativeLayout _defaultLayout;

	private View _tooltipLayout;

	private View _arrow;

	private int _tooltipMargin;

	private readonly List<View> _buttons = new List<View>();

	protected override int LayoutId => 2131493030;

	public override int Theme => 2131951957;

	public HighlightScreenFragment(Func<BrokerToken, HighlightScreenViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, HighlightScreenViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		FragmentActivity fragmentActivity = RequireActivity();
		fragmentActivity.GetRootView()?.CancelPendingInputEvents();
		fragmentActivity.Window?.AddFlags(WindowManagerFlags.NotTouchable);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_drawerView = view.RequireViewById<HighlightDrawerView>(2131297025);
		_defaultLayout = view.RequireViewById<RelativeLayout>(2131296909);
		_tooltipLayout = view.RequireViewById<View>(2131298700);
		_arrow = view.RequireViewById<View>(2131296456);
		_tooltipMargin = (_tooltipLayout.LayoutParameters as ViewGroup.MarginLayoutParams)?.MarginStart ?? 0;
		View view2 = _tooltipLayout.RequireViewById<View>(2131296795);
		TextView textView = _tooltipLayout.RequireViewById<TextView>(2131298646);
		TextView textView2 = _tooltipLayout.RequireViewById<TextView>(2131296958);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Description;
		View.PostDelayed(delegate
		{
			UpdateBackground();
		}, 10L);
		ReceiveMethodSelectElementViewModel.ReceiveMethodsSelectUpdated.SafeSubscribe(delegate
		{
			UpdateBackground();
		}, ViewLifecycleOwner);
		base.ViewModel.BindEvents(_tooltipLayout.OnClick((Action)delegate
		{
		}), view2.OnClick(base.ViewModel.CloseCommand.Trigger), _defaultLayout.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void UpdateBackground()
	{
		int leftMargin = int.MaxValue;
		int rightMargin = int.MinValue;
		_targetView = GetTargetView();
		_targets = GetTargetViews(_targetView);
		_buttons.ForEach(delegate(View b)
		{
			_defaultLayout.RemoveView(b);
		});
		_buttons.Clear();
		_drawerView.DrawOverViews(_targets.ToArray());
		int id = 1;
		_targets.ForEach(delegate((View view, float insets, float? customRadius) t)
		{
			if (t.view.GetGlobalVisibleRect(_cacheRect))
			{
				View view = new View(RequireContext())
				{
					Id = id++
				};
				RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(t.view.Width, t.view.Height)
				{
					TopMargin = _cacheRect.Top,
					LeftMargin = _cacheRect.Left
				};
				leftMargin = Math.Min(leftMargin, _cacheRect.Left);
				rightMargin = Math.Max(rightMargin, _cacheRect.Right);
				layoutParams.AddRule(LayoutRules.AlignParentTop);
				layoutParams.AddRule(LayoutRules.AlignParentLeft);
				_defaultLayout.AddView(view, layoutParams);
				_buttons.Add(view);
				view.OnClick((Action)delegate
				{
					base.ViewModel.ViewClickCommand.Trigger(t.view.Id.ToString());
				}).AutoDisposeOnDestroy(ViewLifecycleOwner);
			}
		});
		if (_buttons.Count == 0)
		{
			base.ViewModel.CloseCommand.Trigger();
		}
		else if (_targetView.GetGlobalVisibleRect(_cacheRect))
		{
			int identifier = base.Resources.GetIdentifier("status_bar_height", "dimen", "android");
			int dimensionPixelSize = base.Resources.GetDimensionPixelSize(identifier);
			_cacheRect.Top -= dimensionPixelSize;
			_cacheRect.Bottom -= dimensionPixelSize;
			int num = (rightMargin + leftMargin - _tooltipLayout.Width) / 2;
			int tooltipMargin = _tooltipMargin;
			int tooltipLeft = Math.Max(num, tooltipMargin);
			tooltipLeft = Math.Min(tooltipLeft, _defaultLayout.Width - _tooltipLayout.Width - tooltipMargin);
			int arrowLeft = _tooltipLayout.Width / 2 + num - tooltipLeft - _arrow.Width / 2;
			arrowLeft = Math.Max(0, arrowLeft);
			arrowLeft = Math.Min(_tooltipLayout.Width - _arrow.Width, arrowLeft);
			_tooltipLayout.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
			{
				lp.TopMargin = _cacheRect.Bottom;
				lp.LeftMargin = tooltipLeft;
			});
			_arrow.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
			{
				lp.LeftMargin = arrowLeft;
			});
		}
	}

	public override Dialog OnCreateDialog(Bundle savedInstanceState)
	{
		Dialog dialog = base.OnCreateDialog(savedInstanceState);
		Window window = dialog.Window;
		dialog.SetOnKeyListener(this);
		WindowCompat.SetDecorFitsSystemWindows(window, decorFitsSystemWindows: false);
		window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
		window.ClearFlags(WindowManagerFlags.TranslucentNavigation | WindowManagerFlags.TranslucentStatus);
		window.SetStatusBarColor(Color.Argb(153, 0, 0, 0));
		window.SetNavigationBarColor(Color.Argb(153, 0, 0, 0));
		WindowInsetsControllerCompat? insetsController = WindowCompat.GetInsetsController(window, window.DecorView);
		insetsController.AppearanceLightStatusBars = false;
		insetsController.AppearanceLightNavigationBars = false;
		return dialog;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		RequireActivity().Window?.ClearFlags(WindowManagerFlags.NotTouchable);
		_targetView = null;
		_targets = null;
		_drawerView = null;
	}

	public bool OnKey(IDialogInterface dialog, Keycode keyCode, KeyEvent e)
	{
		if (keyCode == Keycode.Back)
		{
			base.ViewModel.CloseCommand.Trigger();
			return true;
		}
		return false;
	}

	private List<(View view, float insets, float? customRadius)> GetTargetViews(ViewGroup rootView)
	{
		string? value = base.Arguments?.GetString("highlight_fragment_views_key", null);
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidOperationException("No views found with key 'highlight_fragment_views_key'");
		}
		Dictionary<int, (float, float?)>? dictionary = JsonConvert.DeserializeObject<Dictionary<int, (float, float?)>>(value);
		List<(View, float, float?)> list = new List<(View, float, float?)>(dictionary.Count);
		foreach (KeyValuePair<int, (float, float?)> item in dictionary)
		{
			item.Deconstruct(out var key, out var value2);
			int id = key;
			(float, float?) tuple = value2;
			View view = rootView.FindViewById(id);
			if (view != null)
			{
				list.Add((view, tuple.Item1, tuple.Item2));
			}
		}
		return list;
	}

	private ViewGroup GetTargetView()
	{
		Bundle arguments = base.Arguments;
		int? num = arguments?.GetInt("highlight_fragment_target_key", -1);
		if (num == 0)
		{
			return null;
		}
		if (!num.HasValue || num < 0)
		{
			throw new InvalidOperationException("Failed to find target view");
		}
		FragmentActivity fragmentActivity = RequireActivity();
		int num2 = arguments?.GetInt("highlight_fragment_search_root_key", 0) ?? 0;
		if (num2 > 0)
		{
			return fragmentActivity.RequireViewById<ViewGroup>(num2).FindViewById<ViewGroup>(num.Value) ?? throw new InvalidOperationException($"Failed to find target view '{num.Value}' in search root '{num2}'");
		}
		return fragmentActivity.RequireViewById<ViewGroup>(num.Value);
	}
}
