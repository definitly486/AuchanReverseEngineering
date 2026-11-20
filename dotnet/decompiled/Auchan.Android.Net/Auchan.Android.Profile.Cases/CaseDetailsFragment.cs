using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Cases;
using VisibilitySwitch;

namespace Auchan.Android.Profile.Cases;

internal sealed class CaseDetailsFragment : BaseToolbarFragment<CaseDetailsViewModel>
{
	protected override int LayoutId => 2131492997;

	public CaseDetailsFragment(Func<CaseDetailsViewModel.Parameter, CaseDetailsViewModel> newViewModel)
		: base((Func<Fragment, CaseDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<CaseDetailsViewModel.Parameter>())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	protected override bool HasRightButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		NestedScrollView nestedScrollView = view.RequireViewById<NestedScrollView>(2131296904);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297066);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297111);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView emptyTitle = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView textView = constraintLayout.RequireViewById<TextView>(2131297563);
		ImageView imageView = constraintLayout.RequireViewById<ImageView>(2131297308);
		textView.Visibility = ViewStates.Gone;
		imageView.SetImageResource(2131231424);
		TextView textView2 = constraintLayout2.RequireViewById<TextView>(2131298646);
		TextView textView3 = constraintLayout2.RequireViewById<TextView>(2131297563);
		AppCompatButton appCompatButton = constraintLayout2.RequireViewById<AppCompatButton>(2131296325);
		View view2 = constraintLayout2.RequireViewById<View>(2131298371);
		ImageView imageView2 = constraintLayout2.RequireViewById<ImageView>(2131297308);
		view2.Visibility = ViewStates.Gone;
		imageView2.SetImageResource(2131231423);
		textView2.Text = base.ViewModel.ErrorTitleText;
		textView3.Text = base.ViewModel.ErrorMessageText;
		appCompatButton.Text = base.ViewModel.ErrorButtonText;
		frameLayout.RequireViewById<TextView>(2131298080).Text = base.ViewModel.ProgressTitle;
		TextView textView4 = nestedScrollView.RequireViewById<TextView>(2131298717);
		TextView statusChip = nestedScrollView.RequireViewById<TextView>(2131298482);
		TextView topicsText = nestedScrollView.RequireViewById<TextView>(2131298718);
		TextView createdOnText = nestedScrollView.RequireViewById<TextView>(2131296872);
		statusChip.BackgroundTintMode = PorterDuff.Mode.SrcIn;
		View descriptionSection = nestedScrollView.RequireViewById<View>(2131296963);
		TextView textView5 = nestedScrollView.RequireViewById<TextView>(2131296965);
		TextView descriptionText = nestedScrollView.RequireViewById<TextView>(2131296964);
		View answerSection = nestedScrollView.RequireViewById<View>(2131296445);
		TextView textView6 = nestedScrollView.RequireViewById<TextView>(2131296447);
		TextView answerDateText = nestedScrollView.RequireViewById<TextView>(2131296444);
		TextView answerText = nestedScrollView.RequireViewById<TextView>(2131296446);
		View ratingSection = nestedScrollView.RequireViewById<View>(2131298151);
		TextView textView7 = nestedScrollView.RequireViewById<TextView>(2131298153);
		TextView ratingStars = nestedScrollView.RequireViewById<TextView>(2131298152);
		View closedSection = nestedScrollView.RequireViewById<View>(2131296796);
		TextView closedText = nestedScrollView.RequireViewById<TextView>(2131296797);
		textView4.Text = base.ViewModel.TopicTitleText;
		textView5.Text = base.ViewModel.DescriptionTitleText;
		textView6.Text = base.ViewModel.AnswerTitleText;
		textView7.Text = base.ViewModel.RatingTitleText;
		VisibilitySwitch<CaseDetailsViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<CaseDetailsViewModel.VisualState>(CaseDetailsViewModel.VisualState.Default)
		{
			{
				CaseDetailsViewModel.VisualState.Default,
				nestedScrollView
			},
			{
				CaseDetailsViewModel.VisualState.Empty,
				constraintLayout
			},
			{
				CaseDetailsViewModel.VisualState.Error,
				constraintLayout2
			},
			{
				CaseDetailsViewModel.VisualState.InProgress,
				frameLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[22]
		{
			(delegate
			{
				base.ToolbarTitle = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				emptyTitle.Text = base.ViewModel.EmptyTitleText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyTitleText")),
			(delegate
			{
				statusChip.Text = base.ViewModel.StatusText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StatusText")),
			(delegate
			{
				statusChip.Visibility = base.ViewModel.HasStatus.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasStatus")),
			(delegate
			{
				statusChip.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), base.ViewModel.Status.GetTextArgb())));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Status")),
			(delegate
			{
				statusChip.BackgroundTintList = ContextCompat.GetColorStateList(RequireContext(), base.ViewModel.Status.GetBackgroundArgb());
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Status")),
			(delegate
			{
				topicsText.Text = base.ViewModel.TopicsText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TopicsText")),
			(delegate
			{
				topicsText.Visibility = base.ViewModel.HasTopics.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasTopics")),
			(delegate
			{
				createdOnText.Text = base.ViewModel.CreatedOnText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CreatedOnText")),
			(delegate
			{
				createdOnText.Visibility = base.ViewModel.HasCreatedOn.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasCreatedOn")),
			(delegate
			{
				descriptionSection.Visibility = base.ViewModel.HasDescription.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasDescription")),
			(delegate
			{
				descriptionText.Text = base.ViewModel.DescriptionText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DescriptionText")),
			(delegate
			{
				answerSection.Visibility = base.ViewModel.HasAnswer.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasAnswer")),
			(delegate
			{
				answerDateText.Text = base.ViewModel.AnswerDateText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AnswerDateText")),
			(delegate
			{
				answerDateText.Visibility = (!string.IsNullOrWhiteSpace(base.ViewModel.AnswerDateText)).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AnswerDateText")),
			(delegate
			{
				answerText.Text = base.ViewModel.AnswerText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AnswerText")),
			(delegate
			{
				answerText.Visibility = (!string.IsNullOrWhiteSpace(base.ViewModel.AnswerText)).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AnswerText")),
			(delegate
			{
				ratingSection.Visibility = base.ViewModel.HasRating.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasRating")),
			(delegate
			{
				SetRatingStars(ratingStars, base.ViewModel.Rating);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Rating")),
			(delegate
			{
				closedSection.Visibility = base.ViewModel.HasClosedText.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasClosedText")),
			(delegate
			{
				closedText.Text = base.ViewModel.ClosedText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ClosedText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(appCompatButton.OnClick(base.ViewModel.Retry)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.InfoCommand.SafeSubscribe(delegate
		{
			Show<CasesInfoFragment>();
		}, ViewLifecycleOwner);
	}

	protected override void OnRightButtonClick()
	{
		base.ViewModel.InfoCommand.Trigger();
	}

	protected override void OnNavigationButtonClick()
	{
		base.ParentFragmentManager.PopBackStack();
	}

	private void SetRatingStars(TextView ratingStars, int filledStars)
	{
		SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(base.ViewModel.RatingStarsText);
		Color color = new Color(ContextCompat.GetColor(RequireContext(), 2131100629));
		Color color2 = new Color(ContextCompat.GetColor(RequireContext(), 2131099848));
		if (filledStars < 5)
		{
			spannableStringBuilder.SetSpan(new ForegroundColorSpan(color2), filledStars, 5, SpanTypes.ExclusiveExclusive);
		}
		if (filledStars > 0)
		{
			spannableStringBuilder.SetSpan(new ForegroundColorSpan(color), 0, filledStars, SpanTypes.ExclusiveExclusive);
		}
		ratingStars.SetText(spannableStringBuilder, TextView.BufferType.Spannable);
	}
}
