using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

namespace Auchan.Android.Controls;

public class SumDetailsSectionViewControls(View view)
{
	private readonly TextView _sum = view.RequireViewById<TextView>(2131298570);

	private readonly TextView _sumTitle = view.RequireViewById<TextView>(2131298572);

	private readonly ConstraintLayout _addedLine = view.RequireViewById<ConstraintLayout>(2131296364);

	private readonly TextView _addedSectionTitle = view.RequireViewById<TextView>(2131296367);

	private readonly TextView _addedPointsLabel = view.RequireViewById<TextView>(2131296366);

	private readonly View _addedPointsImage = view.RequireViewById<View>(2131296365);

	private readonly TextView _addedExpressPointsLabel = view.RequireViewById<TextView>(2131296363);

	private readonly View _addedExpressPointsImage = view.RequireViewById<View>(2131296362);

	private readonly ConstraintLayout _removedLine = view.RequireViewById<ConstraintLayout>(2131298428);

	private readonly TextView _removedSectionTitle = view.RequireViewById<TextView>(2131298431);

	private readonly TextView _removedPointsLabel = view.RequireViewById<TextView>(2131298430);

	private readonly View _removedPointsImage = view.RequireViewById<View>(2131298429);

	private readonly TextView _removedExpressPointsLabel = view.RequireViewById<TextView>(2131298427);

	private readonly View _removedExpressPointsImage = view.RequireViewById<View>(2131298426);

	private readonly ConstraintLayout _stampsLine = view.RequireViewById<ConstraintLayout>(2131298449);

	private readonly TextView _stampsSectionTitle = view.RequireViewById<TextView>(2131298454);

	private readonly TextView _addedStampsLabel = view.RequireViewById<TextView>(2131296369);

	private readonly View _addedStampsImage = view.RequireViewById<View>(2131298432);

	private readonly TextView _removedStampsLabel = view.RequireViewById<TextView>(2131298433);

	private readonly View _removedStampsImage = view.RequireViewById<View>(2131296368);

	private readonly ViewGroup _delayedPointsLayout = view.RequireViewById<ViewGroup>(2131296918);

	private readonly ImageView _delayedPointsInfoIcon = view.RequireViewById<ImageView>(2131296917);

	private readonly TextView _delayedPointsTitle = view.RequireViewById<TextView>(2131296921);

	private readonly TextView _delayedPointsValue = view.RequireViewById<TextView>(2131296922);

	private readonly TextView _delayedPointsTime = view.RequireViewById<TextView>(2131296920);

	public View View => view;

	public void Setup(PurchaseDetailsViewModel viewModel, ILifecycleOwner viewLifecycleOwner)
	{
		SumDetailsSectionViewModel detailsVm = viewModel.SumDetailsViewModel;
		_delayedPointsTitle.Text = detailsVm.DelayedPointsSectionTitle;
		detailsVm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[30]
		{
			(delegate
			{
				_sumTitle.Text = detailsVm.ResultSumTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ResultSumTitle")),
			(delegate
			{
				_sum.Text = detailsVm.ResultSum;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ResultSum")),
			(delegate
			{
				_addedLine.Visibility = (detailsVm.HasAddedPoints || detailsVm.HasAddedExpressPoints).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "HasAddedPoints", "HasAddedExpressPoints" })),
			(delegate
			{
				_addedSectionTitle.Text = detailsVm.AddedPointsSectionTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddedPointsSectionTitle")),
			(delegate
			{
				_addedPointsLabel.Text = detailsVm.AddedPoints;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddedPoints")),
			(delegate
			{
				_addedPointsLabel.Visibility = detailsVm.HasAddedPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasAddedPoints")),
			(delegate
			{
				_addedPointsImage.Visibility = detailsVm.HasAddedPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasAddedPoints")),
			(delegate
			{
				_addedExpressPointsLabel.Text = detailsVm.AddedExpressPoints;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddedExpressPoints")),
			(delegate
			{
				_addedExpressPointsLabel.Visibility = detailsVm.HasAddedExpressPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasAddedExpressPoints")),
			(delegate
			{
				_addedExpressPointsImage.Visibility = detailsVm.HasAddedExpressPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasAddedExpressPoints")),
			(delegate
			{
				_removedLine.Visibility = (detailsVm.HasSpentPoints || detailsVm.HasSpentExpressPoints).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "HasSpentPoints", "HasSpentExpressPoints" })),
			(delegate
			{
				_removedSectionTitle.Text = detailsVm.SpentPointsSectionTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SpentPointsSectionTitle")),
			(delegate
			{
				_removedPointsLabel.Text = detailsVm.SpentPoints;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SpentPoints")),
			(delegate
			{
				_removedPointsLabel.Visibility = detailsVm.HasSpentPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasSpentPoints")),
			(delegate
			{
				_removedPointsImage.Visibility = detailsVm.HasSpentPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasSpentPoints")),
			(delegate
			{
				_removedExpressPointsLabel.Text = detailsVm.SpentExpressPoints;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SpentExpressPoints")),
			(delegate
			{
				_removedExpressPointsLabel.Visibility = detailsVm.HasSpentExpressPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasSpentExpressPoints")),
			(delegate
			{
				_removedExpressPointsImage.Visibility = detailsVm.HasSpentExpressPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasSpentExpressPoints")),
			(delegate
			{
				_stampsLine.Visibility = (detailsVm.HasSpentStamps || detailsVm.HasAddedStamps).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "HasSpentStamps", "HasAddedStamps" })),
			(delegate
			{
				_stampsSectionTitle.Text = detailsVm.StampsSectionTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsSectionTitle")),
			(delegate
			{
				_addedStampsLabel.Text = detailsVm.AddedStamps;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddedStamps")),
			(delegate
			{
				_addedStampsLabel.Visibility = detailsVm.HasAddedStamps.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasAddedStamps")),
			(delegate
			{
				_addedStampsImage.Visibility = detailsVm.HasAddedStamps.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasAddedStamps")),
			(delegate
			{
				_removedStampsLabel.Text = detailsVm.SpentStamps;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SpentStamps")),
			(delegate
			{
				_removedStampsLabel.Visibility = detailsVm.HasSpentStamps.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasSpentStamps")),
			(delegate
			{
				_removedStampsImage.Visibility = detailsVm.HasSpentStamps.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasSpentStamps")),
			(delegate
			{
				_delayedPointsLayout.Visibility = detailsVm.HasDelayedPoints.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasDelayedPoints")),
			(delegate
			{
				_delayedPointsValue.Text = detailsVm.DelayedPoints;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DelayedPoints")),
			(delegate
			{
				_delayedPointsTime.Visibility = detailsVm.HasDelayedPointsBookDate.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasDelayedPointsBookDate")),
			(delegate
			{
				_delayedPointsTime.Text = detailsVm.DelayedPointsBookDate;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DelayedPointsBookDate"))
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
		_delayedPointsInfoIcon.OnClick(viewModel.OpenDelayedPointsInfoCommand.Trigger).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
