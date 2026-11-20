using Android.Runtime;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;

namespace Auchan.Android.LoyaltyProgram.ViewHolders;

public class PurchasePointsExpirationItemViewHolder : CachingViewHolder
{
	private readonly ImageView _ballsIcon;

	private readonly TextView _titleLabel;

	private readonly TextView _valueLabel;

	private readonly TextView _timeLabel;

	public PurchasePointsExpirationItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PurchasePointsExpirationItemViewHolder(View itemView)
		: base(itemView)
	{
		_ballsIcon = itemView.RequireViewById<ImageView>(2131297393);
		_titleLabel = itemView.RequireViewById<TextView>(2131298655);
		_valueLabel = itemView.RequireViewById<TextView>(2131298795);
		_timeLabel = itemView.RequireViewById<TextView>(2131298640);
	}

	public void DoBind(PointsExpirationItemViewModel model)
	{
		bool flag = model.PointType == ExpirationPointType.EPoints;
		_ballsIcon.SetBackgroundResource(flag ? 2131230890 : 2131230889);
		_ballsIcon.SetImageResource(flag ? 2131231222 : 2131231218);
		_titleLabel.Text = model.Title;
		_valueLabel.Text = model.PointsFormat;
		_timeLabel.Text = model.GetFormattedTime;
	}
}
