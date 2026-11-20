using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.Core.Content;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using EBind;
using Google.Android.Material.Badge;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Navigation;

namespace Auchan.Android.Base;

[Register("auchan.Android.Base.BottomNavigationHostFragment")]
internal class BottomNavigationHostFragment : BaseFragment<BottomNavigationViewModel>
{
	private const string CART_CONTAINER_TAG = "CART_CONTAINER_TAG";

	private const string CASHBACK_CONTAINER_TAG = "CASHBACK_CONTAINER_TAG";

	private const string CATALOG_CONTAINER_TAG = "CATALOG_CONTAINER_TAG";

	private const string HOME_CONTAINER_TAG = "HOME_CONTAINER_TAG";

	private const string PROFILE_CONTAINER_TAG = "PROFILE_CONTAINER_TAG";

	private readonly Lazy<CartContainerFragment> _cartContainerFragment;

	private readonly Lazy<LoyaltyContainerFragment> _cashbackContainerFragment;

	private readonly Lazy<CatalogContainerFragment> _catalogContainerFragment;

	private readonly Lazy<HomeContainerFragment> _homeContainerFragment;

	private readonly Lazy<ProfileContainerFragment> _profileContainerFragment;

	private OnBackPressedCallback? _backPressCallback;

	private BottomNavigationView _bottomNavigation;

	private View _bottomInsetTarget;

	private WindowInsetsCompat? _currentInsets;

	private bool _isBottomNavigationVisible = true;

	public View Progress { get; private set; }

	protected override int LayoutId => 2131492992;

	public Fragment CurrentContainerFragment { get; private set; }

	public BottomNavigationHostFragment(Func<Fragment, BottomNavigationViewModel> newViewModel, Lazy<HomeContainerFragment> homeContainerFragment, Lazy<CatalogContainerFragment> catalogContainerFragment, Lazy<CartContainerFragment> cartContainerFragment, Lazy<LoyaltyContainerFragment> cashbackContainerFragment, Lazy<ProfileContainerFragment> profileContainerFragment)
		: base(newViewModel)
	{
		_homeContainerFragment = homeContainerFragment;
		_catalogContainerFragment = catalogContainerFragment;
		_cartContainerFragment = cartContainerFragment;
		_cashbackContainerFragment = cashbackContainerFragment;
		_profileContainerFragment = profileContainerFragment;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (savedInstanceState == null || CurrentContainerFragment == null)
		{
			Fragment fragment = ContainerForTag("HOME_CONTAINER_TAG");
			base.ChildFragmentManager.BeginTransaction().Add(2131297300, fragment, "HOME_CONTAINER_TAG").Commit();
			CurrentContainerFragment = fragment;
		}
		base.ViewModel.ShowSProfileCommand.SafeSubscribe(delegate
		{
			_bottomNavigation.SelectedItemId = 2131297644;
		}, this);
		base.ViewModel.ActivateTabCommand.SafeSubscribe(OnActivateTabCommand, this);
	}

	private bool TryActivateTabByTouch(BottomNavigationViewModel.TabbarItem item, View view, MotionEvent @event)
	{
		BottomNavigationViewModel.TabbarItem tabbarItem = EnumFromId(_bottomNavigation.SelectedItemId);
		return !base.ViewModel.ShouldActivateTab(tabbarItem, item);
	}

	public void OnTrimMemory(TrimMemory level)
	{
		switch (level)
		{
		case TrimMemory.RunningLow:
		case TrimMemory.RunningCritical:
		{
			FragmentTransaction fragmentTransaction2 = base.ChildFragmentManager.BeginTransaction();
			foreach (Fragment item in base.ChildFragmentManager.Fragments.Where((Fragment f) => f.View != null && f.IsHidden && !IsTabbarFragment(f)))
			{
				fragmentTransaction2.Detach(item);
			}
			fragmentTransaction2.CommitAllowingStateLoss();
			break;
		}
		case TrimMemory.Moderate:
		case TrimMemory.Complete:
		{
			FragmentTransaction fragmentTransaction = base.ChildFragmentManager.BeginTransaction();
			foreach (Fragment item2 in base.ChildFragmentManager.Fragments.Where((Fragment f) => (f.View == null || f.IsHidden) && !IsTabbarFragment(f)))
			{
				fragmentTransaction.Remove(item2);
			}
			fragmentTransaction.CommitNowAllowingStateLoss();
			break;
		}
		}
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ViewCompat.SetOnApplyWindowInsetsListener(view, new OnApplyWindowInsetsListener(OnWindowInsetsChanged));
		_bottomNavigation = view.RequireViewById<BottomNavigationView>(2131296565);
		DisableTooltipsOn(_bottomNavigation);
		_bottomInsetTarget = View.RequireViewById<View>(2131296562);
		View progress = view.RequireViewById<View>(2131298077);
		Progress = progress;
		progress.RequireViewById<TextView>(2131298080).Text = "Проверяем наличие товаров...";
		IMenuItem cartItem = _bottomNavigation.Menu.FindItem(2131297640);
		BadgeDrawable basketBadge = RecreateBadge(2131297640);
		BadgeDrawable loyaltyBadge = RecreateBadge(2131297643);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				cartItem.SetTitle(base.ViewModel.BasketSum);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BasketSum")),
			(delegate
			{
				UpdateProfileBadge(base.ViewModel.CommonCounter);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CommonCounter")),
			(delegate
			{
				UpdateNavigationBarSelection(base.ViewModel.CartNavigationState, progress);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CartNavigationState")),
			(delegate
			{
				CreateBadge(loyaltyBadge, 2131297643, base.ViewModel.OffersItemCount);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OffersItemCount")),
			(delegate
			{
				CreateBadge(basketBadge, 2131297640, base.ViewModel.BasketItemCount);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BasketItemCount"))
		})).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(ViewLifecycleOwner, delegate
		{
			_bottomNavigation.SelectedItemId = 2131297642;
		});
		_backPressCallback.Enabled = _bottomNavigation.SelectedItemId != 2131297642;
		SetOnTouchListener(BottomNavigationViewModel.TabbarItem.Home);
		SetOnTouchListener(BottomNavigationViewModel.TabbarItem.Catalog);
		SetOnTouchListener(BottomNavigationViewModel.TabbarItem.Cart);
		SetOnTouchListener(BottomNavigationViewModel.TabbarItem.Loyalty);
		SetOnTouchListener(BottomNavigationViewModel.TabbarItem.Profile);
		_bottomNavigation.OnItemSelected(delegate(object? s, NavigationBarView.ItemSelectedEventArgs e)
		{
			BottomNavigationView bottomNavigationView = (BottomNavigationView)s;
			BottomNavigationViewModel.TabbarItem tabbarItem = EnumFromId(bottomNavigationView.SelectedItemId);
			BottomNavigationViewModel.TabbarItem to = EnumFromId(e.Item.ItemId);
			base.ViewModel.OnClicked(tabbarItem, to);
			if (e.Item.ItemId == bottomNavigationView.SelectedItemId)
			{
				if (base.ChildFragmentManager.FindFragmentByTag(ContainerTagFromItemId(bottomNavigationView.SelectedItemId)) is IFragmentContainer fragmentContainer)
				{
					fragmentContainer.PostRepeatedOpenEvent();
				}
			}
			else
			{
				_backPressCallback.Enabled = e.Item.ItemId != 2131297642;
				SwitchFragmentContainers(bottomNavigationView.SelectedItemId, e.Item.ItemId);
				e.Handled = true;
			}
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	public void SetBottomNavigationVisible(bool visible)
	{
		if (_isBottomNavigationVisible != visible)
		{
			_isBottomNavigationVisible = visible;
			_bottomInsetTarget.Visibility = (!visible).ToVisibility();
			_bottomNavigation.Visibility = visible.ToVisibility();
		}
	}

	private void OnWindowInsetsChanged(WindowInsetsCompat insets)
	{
		if (!insets.Equals(_currentInsets))
		{
			_currentInsets = insets;
			AndroidX.Core.Graphics.Insets sbi = insets.GetInsets(WindowInsetsCompat.Type.SystemBars());
			_bottomInsetTarget.UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
			{
				lp.Height = sbi.Bottom;
			});
		}
	}

	private void UpdateNavigationBarSelection(VisualState cartNavigationState, View progress)
	{
		switch (cartNavigationState)
		{
		case VisualState.InProgress:
			progress.Visibility = ViewStates.Visible;
			break;
		case VisualState.Error:
			progress.Visibility = ViewStates.Gone;
			break;
		}
		_bottomNavigation.Menu.FindItem((cartNavigationState == VisualState.InProgress) ? 2131297640 : IdFromFragment(CurrentContainerFragment))?.SetChecked(@checked: true);
	}

	private int IdFromFragment(Fragment currentContainerFragment)
	{
		if (!(currentContainerFragment is HomeContainerFragment))
		{
			if (!(currentContainerFragment is CatalogContainerFragment))
			{
				if (!(currentContainerFragment is CartContainerFragment))
				{
					if (!(currentContainerFragment is LoyaltyContainerFragment))
					{
						if (currentContainerFragment is ProfileContainerFragment)
						{
							return 2131297644;
						}
						throw new NotSupportedException();
					}
					return 2131297643;
				}
				return 2131297640;
			}
			return 2131297641;
		}
		return 2131297642;
	}

	private void DisableTooltipsOn(BottomNavigationView navigationView)
	{
		IMenu menu = navigationView.Menu;
		for (int i = 0; i < menu.Size(); i++)
		{
			int itemId = menu.GetItem(i).ItemId;
			View v = navigationView.RequireViewById<View>(itemId);
			v.LongClick += new DisposableDelegate<EventHandler<View.LongClickEventArgs>>(delegate(object? o, View.LongClickEventArgs e)
			{
				e.Handled = true;
			}, delegate(EventHandler<View.LongClickEventArgs> h)
			{
				v.LongClick -= h;
			}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		}
	}

	private void SetOnTouchListener(BottomNavigationViewModel.TabbarItem item)
	{
		int id = IdFromEnum(item);
		_bottomNavigation.SetItemOnTouchListener(id, new ViewOnTouchListener((View v, MotionEvent e) => TryActivateTabByTouch(item, v, e)));
		Disposable.Create(delegate
		{
			_bottomNavigation.SetItemOnTouchListener(id, null);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public static BottomNavigationViewModel.TabbarItem EnumFromId(int itemId)
	{
		return itemId switch
		{
			2131297642 => BottomNavigationViewModel.TabbarItem.Home, 
			2131297641 => BottomNavigationViewModel.TabbarItem.Catalog, 
			2131297640 => BottomNavigationViewModel.TabbarItem.Cart, 
			2131297643 => BottomNavigationViewModel.TabbarItem.Loyalty, 
			2131297644 => BottomNavigationViewModel.TabbarItem.Profile, 
			_ => throw new NotSupportedException(), 
		};
	}

	private static int IdFromEnum(BottomNavigationViewModel.TabbarItem item)
	{
		return item switch
		{
			BottomNavigationViewModel.TabbarItem.Home => 2131297642, 
			BottomNavigationViewModel.TabbarItem.Catalog => 2131297641, 
			BottomNavigationViewModel.TabbarItem.Cart => 2131297640, 
			BottomNavigationViewModel.TabbarItem.Loyalty => 2131297643, 
			BottomNavigationViewModel.TabbarItem.Profile => 2131297644, 
			_ => throw new NotSupportedException(), 
		};
	}

	private static string ContainerTagFromItemId(int itemId)
	{
		return itemId switch
		{
			2131297642 => "HOME_CONTAINER_TAG", 
			2131297641 => "CATALOG_CONTAINER_TAG", 
			2131297640 => "CART_CONTAINER_TAG", 
			2131297643 => "CASHBACK_CONTAINER_TAG", 
			2131297644 => "PROFILE_CONTAINER_TAG", 
			_ => throw new NotSupportedException(), 
		};
	}

	private Fragment ContainerForTag(string containerTag)
	{
		return containerTag switch
		{
			"HOME_CONTAINER_TAG" => _homeContainerFragment.Value, 
			"CATALOG_CONTAINER_TAG" => _catalogContainerFragment.Value, 
			"CART_CONTAINER_TAG" => _cartContainerFragment.Value, 
			"CASHBACK_CONTAINER_TAG" => _cashbackContainerFragment.Value, 
			"PROFILE_CONTAINER_TAG" => _profileContainerFragment.Value, 
			_ => throw new NotSupportedException(), 
		};
	}

	private static bool IsTabbarFragment(Fragment fragment)
	{
		return fragment.Tag switch
		{
			"HOME_CONTAINER_TAG" => true, 
			"CATALOG_CONTAINER_TAG" => true, 
			"CART_CONTAINER_TAG" => true, 
			"CASHBACK_CONTAINER_TAG" => true, 
			"PROFILE_CONTAINER_TAG" => true, 
			_ => false, 
		};
	}

	private void SwitchFragmentContainers(int currentItemId, int nextItemId)
	{
		Fragment fragment = base.ChildFragmentManager.FindFragmentByTag(ContainerTagFromItemId(currentItemId));
		FragmentTransaction fragmentTransaction = base.ChildFragmentManager.BeginTransaction();
		if (fragment != null)
		{
			fragmentTransaction.Hide(fragment);
			if (fragment is CartContainerFragment fragment2)
			{
				fragmentTransaction.Remove(fragment2);
			}
		}
		string text = ContainerTagFromItemId(nextItemId);
		Fragment fragment3 = base.ChildFragmentManager.FindFragmentByTag(text);
		if (fragment3 == null)
		{
			fragment3 = ContainerForTag(text);
			fragmentTransaction.Add(2131297300, fragment3, text);
		}
		else
		{
			if (fragment3.View == null)
			{
				fragmentTransaction.Attach(fragment3);
			}
			if (fragment3.IsHidden)
			{
				fragmentTransaction.Show(fragment3);
			}
		}
		fragmentTransaction.CommitAllowingStateLoss();
		CurrentContainerFragment = fragment3;
	}

	public ContainerFragment? GetContainer()
	{
		return base.ChildFragmentManager.FindFragmentByTag(ContainerTagFromItemId(_bottomNavigation.SelectedItemId)) as ContainerFragment;
	}

	private BadgeDrawable RecreateBadge(int menuItemId)
	{
		BadgeDrawable orCreateBadge = _bottomNavigation.GetOrCreateBadge(menuItemId);
		orCreateBadge.BackgroundColor = ContextCompat.GetColor(Context, 2131099742);
		orCreateBadge.BadgeTextColor = Color.White;
		return orCreateBadge;
	}

	private void UpdateProfileBadge(int count)
	{
		if (count != 0)
		{
			RecreateBadge(2131297644).Number = count;
		}
		else
		{
			_bottomNavigation.RemoveBadge(2131297644);
		}
	}

	private void CreateBadge(BadgeDrawable badge, int itemResId, int count)
	{
		badge.Dispose();
		badge = RecreateBadge(itemResId);
		badge.SetVisible(count != 0);
		badge.Number = count;
	}

	private void OnActivateTabCommand(BottomNavigationViewModel.TabbarItem item)
	{
		_bottomNavigation.SelectedItemId = IdFromEnum(item);
	}
}
