using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog.Search.FilterItemViews;

public sealed class MulticheckFilterItemView : BaseFilterItemView<MultiCheckFilterItemViewModel>
{
	private TextView _title;

	protected override int LayoutId => 2131493324;

	public MulticheckFilterItemView(Context context)
		: base(context)
	{
	}

	public MulticheckFilterItemView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public MulticheckFilterItemView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public MulticheckFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public MulticheckFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void Init(Context context, IAttributeSet attrs = null)
	{
		base.Init(context, attrs);
		_title = base.View.RequireViewById<TextView>(2131298646);
	}

	protected override void DoBind()
	{
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_title.Text = base.ViewModel.Filter.Name;
			SetupDisabledState();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Filter")))).AddTo(base.Disposables);
		base.View.OnClick((Action)delegate
		{
			base.ViewModel.OpenMulticheckCommand.Trigger(base.ViewModel);
		}).AddTo(base.Disposables);
	}
}
