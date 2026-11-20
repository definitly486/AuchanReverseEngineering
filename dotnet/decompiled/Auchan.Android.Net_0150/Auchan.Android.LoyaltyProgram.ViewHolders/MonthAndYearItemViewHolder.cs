using System.Reactive.Disposables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;

namespace Auchan.Android.LoyaltyProgram.ViewHolders;

public class MonthAndYearItemViewHolder : CachingViewHolder
{
	private TextView _titleLabel;

	public MonthAndYearItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public MonthAndYearItemViewHolder(View itemView)
		: base(itemView)
	{
		_titleLabel = itemView.RequireViewById<TextView>(2131298655);
	}

	public void DoBind(MonthAndYearItemViewModel model, CompositeDisposable disposable)
	{
		_titleLabel.Text = model.Text;
	}
}
