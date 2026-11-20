using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels.Filters;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog.FilterItemViews;

internal abstract class BaseFilterItemView<TElementViewModel> : BaseCustomView<TElementViewModel> where TElementViewModel : BaseProductFilterItemViewModel
{
	protected View _blockView;

	protected IProductFilterObserver? _parentViewModel;

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

	public void Bind(TElementViewModel itemViewModel, IProductFilterObserver parentViewModel, ICollection<IDisposable> disposables)
	{
		_parentViewModel = parentViewModel;
		base.Bind(itemViewModel, disposables);
		_parentViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			SetupDisabledState();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWaitingForResponse")))).AddTo(disposables);
	}

	protected virtual void SetupDisabledState()
	{
		_blockView.Visibility = IsDisabled.ToVisibility();
	}
}
