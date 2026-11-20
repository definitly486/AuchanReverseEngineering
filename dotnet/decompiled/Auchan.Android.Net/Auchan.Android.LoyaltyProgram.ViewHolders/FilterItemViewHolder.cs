using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Base;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

namespace Auchan.Android.LoyaltyProgram.ViewHolders;

public class FilterItemViewHolder : CachingViewHolder
{
	private TextView _nameLabel;

	public FilterItemViewModel Model { get; private set; }

	public FilterItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public FilterItemViewHolder(View itemView)
		: base(itemView)
	{
		_nameLabel = itemView.RequireViewById<TextView>(2131297637);
	}

	public void DoBind(FilterItemViewModel model, CompositeDisposable disposable)
	{
		Model = model;
		_nameLabel.Text = Model.OperationTypeName;
		model.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				base.ItemView.SetBackgroundResource(Model.IsSelected ? 2131230922 : 2131230920);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected")),
			(delegate
			{
				_nameLabel.SetTextColor(new Color(ContextCompat.GetColor(base.ItemView.Context, Model.IsSelected ? 2131099697 : 2131099872)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSelected"))
		})).AddTo(disposable);
	}
}
