using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Text;
using AndroidX.Fragment.App;
using Auchan.Android.Authorization;
using Auchan.Android.Base;
using Auchan.Android.Controls.ListSelector;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Controls.ListPicker;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.DynamicFeedback.Responses;
using Auchan.Common.InfoPages;
using Google.Android.Material.BottomNavigation;
using VisibilitySwitch;

namespace Auchan.Android.DynamicFeedback;

internal class DynamicFeedbackFragment : BaseFragment<DynamicFeedbackViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	private ListView _fieldsListView;

	private DynamicFeedbackListViewAdapter _fieldsListAdapter;

	protected override int LayoutId => 2131493023;

	protected override bool NeedToAdjustScreenToKeyboardMoves => true;

	public DynamicFeedbackFragment(Func<DynamicFeedbackViewModel.Parameter, DynamicFeedbackViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, DynamicFeedbackViewModel>)((Fragment fragment) => newViewModel(fragment.RequireNavParam<DynamicFeedbackViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296911);
		_fieldsListView = linearLayout.RequireViewById<ListView>(2131297153);
		ConstraintLayout successView = view.RequireViewById<ConstraintLayout>(2131298564);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = frameLayout.RequireViewById<TextView>(2131298080);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView textView2 = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button showQrButton = constraintLayout.RequireViewById<Button>(2131298371);
		TextView textView3 = linearLayout.RequireViewById<TextView>(2131298679);
		AppCompatImageButton appCompatImageButton = linearLayout.RequireViewById<AppCompatImageButton>(2131296490);
		textView3.Text = base.ViewModel.Title;
		textView.Text = base.ViewModel.ProgressTitle;
		textView2.Text = base.ViewModel.ErrorText;
		base.ViewModel.FieldViewModels.SafeSubscribeToCollectionChanged(delegate
		{
			ReloadFields();
		}, ViewLifecycleOwner);
		VisibilitySwitch<DynamicFeedbackViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<DynamicFeedbackViewModel.VisualState>(DynamicFeedbackViewModel.VisualState.Default)
		{
			{
				DynamicFeedbackViewModel.VisualState.Default,
				linearLayout
			},
			{
				DynamicFeedbackViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				DynamicFeedbackViewModel.VisualState.Error,
				constraintLayout
			},
			{
				DynamicFeedbackViewModel.VisualState.Success,
				successView
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				showQrButton.Visibility = base.ViewModel.IsAuthorized.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuthorized")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				FillSuccessView(successView, base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(appCompatImageButton.OnClick(GoBack), button.OnClick(base.ViewModel.OnRetryClicked), ((View)showQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.ContinueShoppingCommand.SafeSubscribe(delegate
		{
			GoToHome();
		}, ViewLifecycleOwner);
		base.ViewModel.GoToProfileCommand.SafeSubscribe(delegate
		{
			GoToProfile();
		}, ViewLifecycleOwner);
		base.ViewModel.GoBackToPriceCheckerCommand.SafeSubscribe(delegate
		{
			GoBack();
		}, ViewLifecycleOwner);
		base.ViewModel.GoBackToChatCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenListPickerCommand.SafeSubscribe(OpenListSelector, ViewLifecycleOwner);
		base.ViewModel.OpenInfoPageCommand.SafeSubscribe(OpenInfoPage, ViewLifecycleOwner);
		base.ViewModel.OpenAuthCommand.SafeSubscribe(delegate
		{
			GoToAuth();
		}, ViewLifecycleOwner);
	}

	private void GoBack()
	{
		if (base.ViewModel.ForCaseChatbot)
		{
			base.ViewModel.GoBackToChatCommand.Trigger();
		}
		else if (base.ViewModel.ForCasePriceChecker)
		{
			base.Activity.Finish();
		}
		else if (base.ViewModel.WithTopicAndCategory)
		{
			base.ParentFragmentManager.PopBackStack();
		}
		else
		{
			base.Activity.Finish();
		}
	}

	private void FillSuccessView(View successView, DynamicFeedbackViewModel.VisualState state)
	{
		if (state != DynamicFeedbackViewModel.VisualState.Success)
		{
			return;
		}
		TextView textView = successView.RequireViewById<TextView>(2131298646);
		TextView textView2 = successView.RequireViewById<TextView>(2131297563);
		Button button = successView.RequireViewById<Button>(2131296795);
		Button profileButton = successView.RequireViewById<Button>(2131297647);
		textView.Text = base.ViewModel.SuccessFeedbackTitle;
		textView2.TextFormatted = HtmlCompat.FromHtml(base.ViewModel.SuccessFeedbackDescription, 0);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.ContinueSuccessCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		if (base.ViewModel.WithTopicAndCategory)
		{
			button.Text = base.ViewModel.ContinueText;
			profileButton.Text = base.ViewModel.GoToProfileText;
			base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
			{
				profileButton.Visibility = base.ViewModel.ProfileButtonVisibility.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProfileButtonVisibility")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
			base.ViewModel.BindEvents(profileButton.OnClick(base.ViewModel.GoToProfile)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		}
		else
		{
			button.Text = base.ViewModel.ExcellentText;
			profileButton.Visibility = ViewStates.Invisible;
		}
	}

	private void GoToHome()
	{
		BottomNavigationView bottomNavigationView = base.Activity.RequireViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView != null)
		{
			bottomNavigationView.SelectedItemId = 2131297642;
		}
	}

	private void GoToProfile()
	{
		BottomNavigationView bottomNavigationView = base.Activity.RequireViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView != null)
		{
			bottomNavigationView.SelectedItemId = 2131297644;
		}
	}

	private void GoToAuth()
	{
		Intent intent = new Intent(Context, typeof(LoginActivity));
		base.Activity.FinishAffinity();
		StartActivity(intent);
	}

	private void ReloadFields()
	{
		if (base.ViewModel.FieldViewModels.Where((FieldItemViewModel fieldItemViewModel) => fieldItemViewModel.FieldType == FieldType.Header).ToList().Count == 0)
		{
			FieldItemViewModel item = new FieldItemViewModel(FieldType.Header, new FeedbackFieldDto
			{
				Binding = false,
				Display = true,
				Position = -1L
			});
			base.ViewModel.FieldViewModels.Insert(0, item);
		}
		_fieldsListAdapter = new DynamicFeedbackListViewAdapter(Context, base.ViewModel, (from model in base.ViewModel.FieldViewModels
			where model.Display
			orderby model.Position
			select model).ToList(), ViewLifecycleOwner);
		_fieldsListView.Adapter = _fieldsListAdapter;
		_fieldsListAdapter.NotifyDataSetChanged();
	}

	private void OpenListSelector((FieldItemViewModel fieldItemViewModel, ListPickerViewModel.Parameter parameter) tupleForSelection)
	{
		ListPickerFragment listPickerFragment = _fragmentFactory.Instantiate<ListPickerFragment>();
		listPickerFragment.Arguments = tupleForSelection.parameter.ToNavBundle();
		listPickerFragment.ResultAction = delegate(ListPickerViewModel.Result result)
		{
			base.ViewModel.OnListItemInFieldItemSelected(tupleForSelection.fieldItemViewModel, result.SelectedItem);
		};
		listPickerFragment.Show(base.ParentFragmentManager, null);
	}

	private void OpenInfoPage(InfoPageViewModel.Parameter parameter)
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		BottomSheetInfoPageFragmentContainer bottomSheetInfoPageFragmentContainer = supportFragmentManager.FragmentFactory.Instantiate<BottomSheetInfoPageFragmentContainer>();
		bottomSheetInfoPageFragmentContainer.Arguments = parameter.ToNavBundle();
		bottomSheetInfoPageFragmentContainer.Show(supportFragmentManager, null);
	}
}
