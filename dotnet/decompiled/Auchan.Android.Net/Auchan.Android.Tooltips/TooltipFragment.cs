using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Tooltips;
using Google.Android.Material.Button;
using Java.Interop;
using Newtonsoft.Json;

namespace Auchan.Android.Tooltips;

internal class TooltipFragment : BaseDialogFragment<TooltipViewModel>, IDialogInterfaceOnKeyListener, IJavaObject, IDisposable, IJavaPeerable
{
	public const string ViewsKey = "tooltip_fragment_views_key";

	public const string ScrollKey = "tooltip_fragment_scroll_key";

	public const string TargetKey = "tooltip_fragment_target_key";

	private readonly int Offset = Converter.DpToPx(12f);

	private Dictionary<TooltipTargetType, (View view, float insets, float? customRadius, View scrollTarget)> _targets;

	private TooltipDrawerView _drawerView;

	private RecyclerView _recyclerView;

	private ViewGroup _targetView;

	private AppCompatImageView _topHeaderIcon;

	private AppCompatImageView _headerIcon;

	private MaterialButton _nextButton;

	private ViewGroup _headerLayout;

	private AppCompatTextView _description;

	private ViewGroup _cardLayout;

	private TextView _cardTitle;

	private TextView _cardDescription;

	private Button _cardButton;

	private ViewGroup _favCatsLayout;

	private TextView _favCatsTitle;

	private TextView _favCatsDescription;

	private Button _favCatsButton;

	private ImageView _favCatsArrowImage;

	private ImageView _favCatsCellImage;

	protected override int LayoutId => 2131493095;

	public override int Theme => 2131951957;

	public TooltipFragment(Func<TooltipViewModel.Parameter, TooltipViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, TooltipViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<TooltipViewModel.Parameter>())))
	{
	}

	protected override void OnWindowInsetsChanged(WindowInsetsCompat insets)
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(DismissAndResetScroll, this);
		base.ViewModel.RedrawCommand.Delay(TimeSpan.FromSeconds(1L)).SafeSubscribe(delegate
		{
			DrawTooltip(base.ViewModel.TitleTargetType);
			SwitchIcon(base.ViewModel.TitleIconType);
		}, this);
		FragmentActivity fragmentActivity = RequireActivity();
		fragmentActivity.GetRootView()?.CancelPendingInputEvents();
		fragmentActivity.Window?.AddFlags(WindowManagerFlags.NotTouchable);
		_recyclerView = GetScrollView();
		_targetView = GetTargetView();
		_targets = GetTargetViews(_targetView ?? _recyclerView);
		_recyclerView.CancelPendingInputEvents();
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		RequireActivity().Window?.ClearFlags(WindowManagerFlags.NotTouchable);
		_targets.Clear();
		_targets = null;
		_recyclerView = null;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		AppCompatTextView header = view.RequireViewById<AppCompatTextView>(2131297266);
		_description = view.RequireViewById<AppCompatTextView>(2131296958);
		AppCompatTextView progress = view.RequireViewById<AppCompatTextView>(2131298085);
		MaterialButton skipButton = view.RequireViewById<MaterialButton>(2131298376);
		_nextButton = view.RequireViewById<MaterialButton>(2131296846);
		_headerLayout = view.RequireViewById<ViewGroup>(2131297272);
		_headerIcon = view.RequireViewById<AppCompatImageView>(2131297271);
		_topHeaderIcon = view.RequireViewById<AppCompatImageView>(2131298712);
		_drawerView = view.RequireViewById<TooltipDrawerView>(2131298693);
		_cardLayout = view.RequireViewById<ViewGroup>(2131298689);
		_cardTitle = view.RequireViewById<TextView>(2131298690);
		_cardDescription = view.RequireViewById<TextView>(2131298687);
		_cardButton = view.RequireViewById<Button>(2131298686);
		_favCatsLayout = view.RequireViewById<ViewGroup>(2131298698);
		_favCatsTitle = view.RequireViewById<TextView>(2131298699);
		_favCatsDescription = view.RequireViewById<TextView>(2131298697);
		_favCatsButton = view.RequireViewById<Button>(2131298695);
		_favCatsArrowImage = view.RequireViewById<ImageView>(2131298694);
		_favCatsCellImage = view.RequireViewById<ImageView>(2131298696);
		skipButton.Text = base.ViewModel.SkipText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[13]
		{
			(delegate
			{
				header.Text = base.ViewModel.TitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleText")),
			(delegate
			{
				_cardTitle.Text = base.ViewModel.TitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleText")),
			(delegate
			{
				_description.Text = base.ViewModel.DescriptionText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DescriptionText")),
			(delegate
			{
				_cardDescription.Text = base.ViewModel.DescriptionText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DescriptionText")),
			(delegate
			{
				progress.Text = base.ViewModel.TooltipNumberText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TooltipNumberText")),
			(delegate
			{
				_nextButton.Text = base.ViewModel.NextText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NextText")),
			(delegate
			{
				_cardButton.Text = base.ViewModel.NextText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NextText")),
			(delegate
			{
				skipButton.Visibility = (base.ViewModel.TitleTargetType != TooltipTargetType.PriceChecker).ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleTargetType")),
			(delegate
			{
				DrawTooltip(base.ViewModel.TitleTargetType);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleTargetType")),
			(delegate
			{
				SwitchIcon(base.ViewModel.TitleIconType);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleIconType")),
			(delegate
			{
				_favCatsTitle.Text = base.ViewModel.TitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TitleText")),
			(delegate
			{
				_favCatsDescription.Text = base.ViewModel.DescriptionText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DescriptionText")),
			(delegate
			{
				_favCatsButton.Text = base.ViewModel.NextText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NextText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(skipButton.OnClick(base.ViewModel.CloseCommand.Trigger), _nextButton.OnClick(base.ViewModel.NextCommand.Trigger), _cardButton.OnClick(base.ViewModel.NextCommand.Trigger), _favCatsButton.OnClick(base.ViewModel.NextCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		_drawerView = null;
		_headerIcon = null;
		_topHeaderIcon = null;
	}

	public override Dialog OnCreateDialog(Bundle savedInstanceState)
	{
		Dialog dialog = base.OnCreateDialog(savedInstanceState);
		Window window = dialog.Window;
		dialog.SetOnKeyListener(this);
		int systemUiVisibility = 1792;
		window.DecorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
		window.SetStatusBarColor(Color.Transparent);
		if (OperatingSystem.IsAndroidVersionAtLeast(26))
		{
			window.SetNavigationBarColor(Color.Transparent);
		}
		return dialog;
	}

	private Dictionary<TooltipTargetType, (View view, float insets, float? customRadius, View scrollTarget)> GetTargetViews(ViewGroup rootView)
	{
		string? value = base.Arguments?.GetString("tooltip_fragment_views_key", null);
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidOperationException("No views found with key 'tooltip_fragment_views_key'");
		}
		Dictionary<int, (TooltipTargetType, float, float?, int)>? dictionary = JsonConvert.DeserializeObject<Dictionary<int, (TooltipTargetType, float, float?, int)>>(value);
		Dictionary<TooltipTargetType, (View, float, float?, View)> dictionary2 = new Dictionary<TooltipTargetType, (View, float, float?, View)>(dictionary.Count);
		foreach (KeyValuePair<int, (TooltipTargetType, float, float?, int)> item3 in dictionary)
		{
			item3.Deconstruct(out var key, out var value2);
			int id = key;
			(TooltipTargetType, float, float?, int) tuple = value2;
			View item = rootView.RequireViewById<View>(id);
			View item2 = rootView.RequireViewById<View>(tuple.Item4);
			dictionary2.Add(tuple.Item1, (item, tuple.Item2, tuple.Item3, item2));
		}
		return dictionary2;
	}

	private ViewGroup? GetTargetView()
	{
		int? num = base.Arguments?.GetInt("tooltip_fragment_target_key", -1);
		if (num == 0)
		{
			return null;
		}
		if (!num.HasValue || num < 0)
		{
			throw new InvalidOperationException("Failed to find target view");
		}
		return RequireActivity().RequireViewById<ViewGroup>(num.Value);
	}

	private RecyclerView GetScrollView()
	{
		int? num = base.Arguments?.GetInt("tooltip_fragment_scroll_key", -1);
		if (!num.HasValue || num <= 0)
		{
			throw new InvalidOperationException("Failed to find scroll view");
		}
		return RequireActivity().RequireViewById<RecyclerView>(num.Value);
	}

	private void DrawTooltip(TooltipTargetType target)
	{
		View.Post(delegate
		{
			if (_targets != null)
			{
				(View, float, float?, View) tuple = _targets[target];
				int topRelativeTo = tuple.Item4.GetTopRelativeTo(_recyclerView);
				int y = Math.Max(0, topRelativeTo - Offset);
				_recyclerView.ScrollTo(0, y);
				_drawerView.DrawOverView(tuple.Item1, tuple.Item2, tuple.Item3, target == TooltipTargetType.FavoriteCategories);
				bool flag = target == TooltipTargetType.LoyaltyCard;
				bool flag2 = target == TooltipTargetType.FavoriteCategories;
				_cardLayout.Visibility = flag.ToVisibility();
				ViewGroup favCatsLayout = _favCatsLayout;
				ImageView favCatsArrowImage = _favCatsArrowImage;
				ViewStates viewStates = (_favCatsCellImage.Visibility = flag2.ToVisibility());
				ViewStates visibility = (favCatsArrowImage.Visibility = viewStates);
				favCatsLayout.Visibility = visibility;
				_headerLayout.Visibility = (!flag && !flag2).ToVisibility();
				_description.Visibility = (!flag && !flag2).ToVisibility();
				_nextButton.Visibility = (!flag && !flag2).ToVisibility();
				SwitchIcon(base.ViewModel.TitleIconType);
				if (flag && _cardLayout.LayoutParameters is ConstraintLayout.LayoutParams layoutParams)
				{
					int[] array = new int[2];
					tuple.Item1.GetLocationOnScreen(array);
					layoutParams.TopMargin = array[1] + tuple.Item1.Height - Offset;
					_cardLayout.RequestLayout();
				}
			}
		});
		View.PostDelayed(delegate
		{
			if (_targets != null)
			{
				(View, float, float?, View) tuple = _targets[target];
				if (target == TooltipTargetType.LoyaltyCard && _cardLayout.LayoutParameters is ConstraintLayout.LayoutParams layoutParams)
				{
					int[] array = new int[2];
					tuple.Item1.GetLocationOnScreen(array);
					layoutParams.TopMargin = array[1] + tuple.Item1.Height - Offset;
					_cardLayout.RequestLayout();
				}
			}
		}, 100L);
	}

	private void SwitchIcon(TooltipTitleIconType iconType)
	{
		Drawable drawable = iconType switch
		{
			TooltipTitleIconType.Points => ContextCompat.GetDrawable(Context, 2131231416), 
			TooltipTitleIconType.ExpressPoints => ContextCompat.GetDrawable(Context, 2131231313), 
			TooltipTitleIconType.Marks => ContextCompat.GetDrawable(Context, 2131231223), 
			TooltipTitleIconType.StaffBird => ContextCompat.GetDrawable(Context, 2131231394), 
			_ => null, 
		};
		if (drawable == null)
		{
			_topHeaderIcon.Visibility = ViewStates.Gone;
			_headerIcon.Visibility = ViewStates.Gone;
		}
		else if (iconType == TooltipTitleIconType.StaffBird)
		{
			_topHeaderIcon.Visibility = ViewStates.Visible;
			_headerIcon.Visibility = ViewStates.Gone;
			_topHeaderIcon.SetImageDrawable(drawable);
		}
		else
		{
			_topHeaderIcon.Visibility = ViewStates.Gone;
			_headerIcon.Visibility = ViewStates.Visible;
			_headerIcon.SetImageDrawable(drawable);
		}
	}

	private void DismissAndResetScroll(Unit _)
	{
		Dismiss();
		_recyclerView?.ScrollToPosition(0);
	}

	public bool OnKey(IDialogInterface? dialog, Keycode keyCode, KeyEvent? e)
	{
		if (keyCode == Keycode.Back)
		{
			base.ViewModel.CloseCommand.Trigger();
			return true;
		}
		return false;
	}
}
