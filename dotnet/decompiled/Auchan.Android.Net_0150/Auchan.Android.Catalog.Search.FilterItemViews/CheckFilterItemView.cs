using System;
using System.Collections.Generic;
using System.Drawing;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog.Search.FilterItemViews;

public sealed class CheckFilterItemView : BaseFilterItemView<CheckFilterItemViewModel>
{
	private const float COMMON_MARGIN = 0f;

	private const float BLOCK_MARGIN = 12f;

	private CheckBox _checkBox;

	private View _container;

	private View _informerIcon;

	protected override int LayoutId => 2131493323;

	public CheckFilterItemView(Context context)
		: base(context)
	{
	}

	public CheckFilterItemView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public CheckFilterItemView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public CheckFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public CheckFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void Init(Context context, IAttributeSet? attrs = null)
	{
		base.Init(context, attrs);
		_checkBox = base.View.RequireViewById<CheckBox>(2131296768);
		_container = base.View.RequireViewById<View>(2131296837);
		_informerIcon = base.View.RequireViewById<View>(2131297369);
	}

	protected override void DoBind()
	{
		if (_container.LayoutParameters is MarginLayoutParams marginLayoutParams && _parentViewModel != null)
		{
			int num = _parentViewModel.Filters.IndexOf(base.ViewModel);
			BaseFilterItemViewModel baseFilterItemViewModel = ((num == 0) ? null : _parentViewModel.Filters[num - 1]);
			BaseFilterItemViewModel obj = ((num == _parentViewModel.Filters.Count - 1) ? null : _parentViewModel.Filters[num + 1]);
			bool flag = !(baseFilterItemViewModel is CheckFilterItemViewModel);
			bool flag2 = !(obj is CheckFilterItemViewModel);
			if (flag || flag2)
			{
				marginLayoutParams.SetMargins(marginLayoutParams.LeftMargin, Converter.DpToPx(flag ? 12f : 0f), marginLayoutParams.RightMargin, Converter.DpToPx(flag2 ? 12f : 0f));
				_container.LayoutParameters = marginLayoutParams;
				RequestLayout();
			}
		}
		_checkBox.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.IsChecked = _checkBox.Checked;
		}).AddTo(base.Disposables));
		_informerIcon.SetOnClickListener(new ViewOnClickListener(ShowHintOnInformerIcon).AddTo(base.Disposables));
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				_checkBox.Checked = base.ViewModel.IsChecked;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsChecked")),
			(delegate
			{
				_informerIcon.Visibility = base.ViewModel.IsHaveInformer.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsHaveInformer")),
			(delegate
			{
				_checkBox.Text = base.ViewModel.Filter.Name;
				SetupDisabledState();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Filter"))
		})).AddTo(base.Disposables);
	}

	private void ShowHintOnInformerIcon()
	{
		if (_parentViewModel != null && !string.IsNullOrEmpty(base.ViewModel.Filter.Informer))
		{
			SearchFiltersViewModel? parentViewModel = _parentViewModel;
			string? informer = base.ViewModel.Filter.Informer;
			View informerIcon = _informerIcon;
			System.Drawing.Size paddingDp = new System.Drawing.Size(20, 0);
			HintPopup.Show(parentViewModel, informer, informerIcon, default(Point), atTop: true, checkAnchorVisibility: false, default(System.Drawing.Size), paddingDp);
		}
	}
}
