using System.Reactive.Disposables;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

namespace Auchan.Android.LoyaltyProgram.ViewHolders;

public class PurchaseDelayedPointsItemViewHolder : CachingViewHolder
{
	private TextView _titleText;

	private TextView _timeText;

	private TextView _pointsText;

	public PurchaseDelayedPointsItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PurchaseDelayedPointsItemViewHolder(View itemView)
		: base(itemView)
	{
		_titleText = itemView.RequireViewById<TextView>(2131297637);
		_timeText = itemView.RequireViewById<TextView>(2131298640);
		_pointsText = itemView.RequireViewById<TextView>(2131297939);
	}

	public void DoBind(Context context, DelayedPointsItemViewModel model, CompositeDisposable disposable)
	{
		_titleText.Text = model.DelayedPointsOperationName;
		_pointsText.Text = model.Points;
		_timeText.SetColorSpan(context, model.FormattedDelayedPointsOrder + model.FormattedDelayedPointsTransactionDate, model.FormattedDelayedPointsOrder, 2131100550);
	}
}
