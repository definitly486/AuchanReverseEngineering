using System.Reactive.Disposables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

namespace Auchan.Android.LoyaltyProgram.ViewHolders;

public class DateItemViewHolder : CachingViewHolder
{
	public DateItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public DateItemViewHolder(View itemView)
		: base(itemView)
	{
	}

	public void DoBind(DateItemViewModel model, CompositeDisposable disposable)
	{
		((TextView)base.ItemView).Text = model.Text;
	}
}
