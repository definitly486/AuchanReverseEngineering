using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Profile;

namespace Auchan.Android.Catalog.Common;

public sealed class FavoritesButtonView : ImageView
{
	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public FavoritesButtonView(Context context, IAttributeSet? _)
		: base(context)
	{
		SetBackgroundResource(2131231165);
	}

	public void Bind(FavoritesButtonViewModel vm, ICollection<IDisposable> disposables)
	{
		_disposables.Clear();
		vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			SetFavoriteState(vm.ProductInFavorites);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInFavorites")))).AddTo(_disposables);
		((View)this).OnClick((Action)delegate
		{
			vm.OnHeartClicked();
		}).AddTo(_disposables);
		disposables.AddCollection(_disposables);
	}

	private void SetFavoriteState(bool isInFavorites)
	{
		SetBackgroundResource(isInFavorites ? 2131231168 : 2131231165);
	}
}
