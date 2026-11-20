using System.Reactive.Disposables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;

namespace Auchan.Android.LoyaltyProgram.ViewHolders;

public class PointsExpirationItemViewHolder : CachingViewHolder
{
	private ImageView _ballsIcon;

	private TextView _titleLabel;

	private TextView _valueLabel;

	public PointsExpirationItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PointsExpirationItemViewHolder(View itemView)
		: base(itemView)
	{
		_ballsIcon = itemView.RequireViewById<ImageView>(2131297393);
		_titleLabel = itemView.RequireViewById<TextView>(2131298655);
		_valueLabel = itemView.RequireViewById<TextView>(2131298795);
	}

	public void DoBind(PointsExpirationItemViewModel model, CompositeDisposable disposable)
	{
		bool flag = model.PointType == ExpirationPointType.EPoints;
		_ballsIcon.SetBackgroundResource(flag ? 2131230890 : 2131230889);
		_ballsIcon.SetImageResource(flag ? 2131231222 : 2131231218);
		_titleLabel.Text = model.Title;
		_valueLabel.Text = model.PointsFormat;
	}
}
