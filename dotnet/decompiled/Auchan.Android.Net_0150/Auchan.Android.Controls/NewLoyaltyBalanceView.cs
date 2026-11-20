using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.NewLoyaltyCard;

namespace Auchan.Android.Controls;

[Register("auchan.NewLoyaltyBalanceView")]
internal class NewLoyaltyBalanceView : FrameLayout
{
	private TextView _pointsTitle;

	private TextView _pointsDescription;

	private TextView _kopeckDescription;

	private TextView _epointsTitle;

	private TextView _epointsDescription;

	private TextView _ekopecksDescription;

	private TextView _marksTitle;

	private TextView _marksDescription;

	private ConstraintLayout _bottomSection;

	private LinearLayout _messageLayout;

	private TextView _messageView;

	private ImageView _rightChevron;

	private ConstraintLayout _pointsView;

	private ConstraintLayout _epointsView;

	private ConstraintLayout _marksView;

	protected NewLoyaltyBalanceView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public NewLoyaltyBalanceView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public NewLoyaltyBalanceView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public NewLoyaltyBalanceView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public NewLoyaltyBalanceView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		View view = View.Inflate(context, 2131493160, this);
		_pointsView = view.RequireViewById<ConstraintLayout>(2131297957);
		_pointsTitle = _pointsView.RequireViewById<TextView>(2131297952);
		_pointsDescription = _pointsView.RequireViewById<TextView>(2131297931);
		_kopeckDescription = _pointsView.RequireViewById<TextView>(2131297414);
		_epointsView = view.RequireViewById<ConstraintLayout>(2131297107);
		_epointsTitle = _epointsView.RequireViewById<TextView>(2131297106);
		_epointsDescription = _epointsView.RequireViewById<TextView>(2131297102);
		_ekopecksDescription = _epointsView.RequireViewById<TextView>(2131297043);
		_marksView = view.RequireViewById<ConstraintLayout>(2131297521);
		_marksTitle = _marksView.RequireViewById<TextView>(2131297533);
		_marksDescription = _marksView.RequireViewById<TextView>(2131297528);
		_bottomSection = view.RequireViewById<ConstraintLayout>(2131296568);
		_messageLayout = _bottomSection.RequireViewById<LinearLayout>(2131297572);
		_messageView = _messageLayout.RequireViewById<TextView>(2131297571);
		_rightChevron = _messageLayout.RequireViewById<ImageView>(2131298249);
	}

	public void Setup(NewLoyaltyBalanceItemViewModel viewModel, ILifecycleOwner viewLifecycleOwner)
	{
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[12]
		{
			(delegate
			{
				SetControlType(viewModel.BalanceControlType);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BalanceControlType")),
			(delegate
			{
				_pointsTitle.Text = viewModel.PointsName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsName")),
			(delegate
			{
				_pointsDescription.Text = viewModel.Points;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Points")),
			(delegate
			{
				_kopeckDescription.Text = viewModel.Kopecks;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Kopecks")),
			(delegate
			{
				_epointsTitle.Text = viewModel.ExpressPointsName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ExpressPointsName")),
			(delegate
			{
				_epointsDescription.Text = viewModel.ExpressPoints;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ExpressPoints")),
			(delegate
			{
				_ekopecksDescription.Text = viewModel.ExpressKopecks;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ExpressKopecks")),
			(delegate
			{
				_marksTitle.Text = viewModel.MarksName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MarksName")),
			(delegate
			{
				_marksDescription.Text = viewModel.Marks;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Marks")),
			(delegate
			{
				_messageView.Text = viewModel.MessageText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MessageText")),
			(delegate
			{
				_marksView.Visibility = viewModel.IsMarksViewAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsMarksViewAvailable")),
			(delegate
			{
				ChangeBottomViewVisibility(viewModel.IsBalanceEmpty);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsBalanceEmpty"))
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
		viewModel.BindEvents(_pointsView.OnClick(viewModel.NavigateToPurchaseHistory), _epointsView.OnClick(viewModel.NavigateToPurchaseHistory), _marksView.OnClick(viewModel.NavigateToPurchaseHistory), _messageLayout.OnClick(viewModel.NavigateToPointsExpiration)).AutoDisposeOnDestroy(viewLifecycleOwner);
	}

	private void SetControlType(BalanceControlType balanceControlType)
	{
		TextView messageView = _messageView;
		Context context = base.Context;
		messageView.SetCompoundDrawablesWithIntrinsicBounds(ContextCompat.GetDrawable(context, balanceControlType switch
		{
			BalanceControlType.Burning => 2131231177, 
			BalanceControlType.Balance => 2131231050, 
			_ => throw new ArgumentOutOfRangeException("balanceControlType", balanceControlType, null), 
		}), null, null, null);
		_rightChevron.Visibility = (balanceControlType != BalanceControlType.Balance).ToVisibility();
	}

	private void ChangeBottomViewVisibility(bool isBottomViewHidden)
	{
		_bottomSection.Visibility = (!isBottomViewHidden).ToVisibility();
	}
}
