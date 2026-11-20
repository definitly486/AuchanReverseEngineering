using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Products.ViewModels.Filters;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog.FilterItemViews;

internal sealed class RadioFilterItemView : BaseFilterItemView<ProductRadioFilterItemViewModel>
{
	private TextView _title;

	protected override int LayoutId => 2131493297;

	public RadioFilterItemView(Context context)
		: base(context)
	{
	}

	public RadioFilterItemView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public RadioFilterItemView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public RadioFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public RadioFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void Init(Context context, IAttributeSet? attrs = null)
	{
		base.Init(context, attrs);
		_title = base.View.RequireViewById<TextView>(2131298646);
	}

	protected override void DoBind()
	{
		base.View.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.OpenRadioCheckCommand.Trigger(base.ViewModel);
		}).AddTo(base.Disposables));
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_title.Text = base.ViewModel.Filter.Name;
			_blockView.Visibility = base.ViewModel.Filter?.Disabled?.ToVisibility() ?? ViewStates.Gone;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Filter")))).AddTo(base.Disposables);
	}
}
