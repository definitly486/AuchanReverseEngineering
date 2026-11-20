using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog.Search.FilterItemViews;

public abstract class BaseFilterItemView<TElementViewModel> : BaseCustomView<TElementViewModel> where TElementViewModel : BaseFilterItemViewModel
{
	private View _blockView;

	protected SearchFiltersViewModel? _parentViewModel;

	protected bool IsDisabled
	{
		get
		{
			if (!base.ViewModel.Disabled)
			{
				return _parentViewModel?.IsWaitingForResponse ?? false;
			}
			return true;
		}
	}

	protected BaseFilterItemView(Context context)
		: base(context)
	{
	}

	protected BaseFilterItemView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	protected BaseFilterItemView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	protected BaseFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	protected BaseFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void Init(Context context, IAttributeSet? attrs = null)
	{
		base.Init(context, attrs);
		_blockView = base.View.RequireViewById<View>(2131296541);
	}

	public void Bind(TElementViewModel itemViewModel, SearchFiltersViewModel parentViewModel, ICollection<IDisposable> disposables)
	{
		_parentViewModel = parentViewModel;
		base.Bind(itemViewModel, disposables);
		_parentViewModel.OnPropertyChanges((SearchFiltersViewModel x) => x.IsWaitingForResponse).StartWith(_parentViewModel.IsWaitingForResponse).Subscribe(delegate
		{
			SetupDisabledState();
		})
			.AddTo(disposables);
	}

	protected virtual void SetupDisabledState()
	{
		_blockView.Visibility = IsDisabled.ToVisibility();
	}
}
