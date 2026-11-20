using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.UserCards;
using Com.Zerobranch.Layout;
using VisibilitySwitch;

namespace Auchan.Android.Profile.UserCards;

internal class UserCardsFragment : BaseToolbarFragment<UserCardsViewModel>
{
	private FrameLayout _deleteLayout;

	private ConstraintLayout _cardCellView;

	protected override int LayoutId => 2131493116;

	public UserCardsFragment(Func<Fragment, UserCardsViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131296904);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297066);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout3 = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		RecyclerView recyclerView = constraintLayout.RequireViewById<RecyclerView>(2131296674);
		Button button = constraintLayout.RequireViewById<Button>(2131296344);
		TextView textView2 = constraintLayout2.RequireViewById<TextView>(2131296673);
		TextView textView3 = constraintLayout2.RequireViewById<TextView>(2131296671);
		Button button2 = constraintLayout2.RequireViewById<Button>(2131297063);
		TextView errorMessage = constraintLayout3.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout3.RequireViewById<TextView>(2131297563);
		Button button3 = constraintLayout3.RequireViewById<Button>(2131296325);
		Button button4 = constraintLayout3.RequireViewById<Button>(2131298371);
		ObservableRecyclerAdapter<CardItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<CardItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493360,
			DataSource = base.ViewModel.Cards,
			BindViewHolderDelegate = OnBindItem
		};
		recyclerView.SetAdapter(adapter);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				constraintLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout3
			},
			{
				VisualState.Empty,
				constraintLayout2
			}
		};
		textView2.Text = base.ViewModel.EmptyMessage;
		textView3.Text = base.ViewModel.EmptyHint;
		button2.Text = base.ViewModel.AddCardButtonText;
		button.Text = base.ViewModel.AddCardButtonText;
		textView.Text = base.ViewModel.ScreenTitle;
		button3.Text = base.ViewModel.ErrorActionButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorHint")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.AddCardClick), button2.OnClick(base.ViewModel.AddCardClick), ((View)button3).OnClick((Action)delegate
		{
			base.ViewModel.LoadCards().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)button4).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.AddCardCommand.Subscribe(delegate
		{
			OpenAddCard();
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.DeleteCardAskCommand.Subscribe(AskDeleteCard).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	private void OnBindItem(CachingViewHolder viewHolder, CardItemViewModel item, int position, CompositeDisposable disposable)
	{
		_deleteLayout = viewHolder.FindCachedView<FrameLayout>(2131298196);
		_cardCellView = viewHolder.FindCachedView<ConstraintLayout>(2131296734);
		SwipeLayout swipeLayout = viewHolder.FindCachedView<SwipeLayout>(2131298579);
		TextView? textView = viewHolder.FindCachedView<TextView>(2131296639);
		ImageView imageView = viewHolder.FindCachedView<ImageView>(2131296640);
		viewHolder.FindCachedView<TextView>(2131298197).Text = item.DeleteViewTitle;
		textView.Text = item.Pan;
		imageView.SetImageResource(UserCardsConverter.FromSchemeToResourceId(item.Scheme));
		item.BindEvents(((View)_deleteLayout).OnClick((Action)delegate
		{
			base.ViewModel.DeleteCardClick(item);
			swipeLayout.Close();
		})).AddTo(disposable);
	}

	private void OpenAddCard()
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<UserCardsAddFragment>(this, null, 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void AskDeleteCard(CardItemViewModel model)
	{
		AlertDialog.Builder builder = new AlertDialog.Builder(RequireContext());
		builder.SetTitle(base.ViewModel.RemoveCardDialogTitle);
		builder.SetMessage(base.ViewModel.RemoveCardDialogMessage);
		builder.SetPositiveButton(base.ViewModel.RemoveCardDialogAccept, async delegate
		{
			await UserCardsHelper.ShowRemoveLabel(_deleteLayout, _cardCellView);
			base.ViewModel.DeleteCardApprove(model);
		});
		builder.SetNegativeButton(base.ViewModel.RemoveCardDialogCancel, delegate
		{
		});
		builder.Create().ShowCentered();
	}
}
