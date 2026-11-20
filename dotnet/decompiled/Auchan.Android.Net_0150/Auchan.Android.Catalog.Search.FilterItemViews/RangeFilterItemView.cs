using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Common.UiExtensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Extensions;
using EBind;
using Xamarin.RangeSlider;

namespace Auchan.Android.Catalog.Search.FilterItemViews;

internal sealed class RangeFilterItemView : BaseFilterItemView<RangeFilterItemViewModel>
{
	private TextView _title;

	private EditText _fromText;

	private EditText _toText;

	private RangeSliderControl _rangeSlider;

	protected override int LayoutId => 2131493325;

	public RangeFilterItemView(Context context)
		: base(context)
	{
	}

	public RangeFilterItemView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public RangeFilterItemView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public RangeFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public RangeFilterItemView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void Init(Context context, IAttributeSet? attrs = null)
	{
		base.Init(context, attrs);
		_title = base.View.RequireViewById<TextView>(2131298646);
		_fromText = base.View.RequireViewById<EditText>(2131297224);
		_toText = base.View.RequireViewById<EditText>(2131298664);
		_rangeSlider = base.View.RequireViewById<RangeSliderControl>(2131298136);
	}

	protected override void DoBind()
	{
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				SetSliderMin(base.ViewModel.SelectedMin);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedMin")),
			(delegate
			{
				SetSliderMax(base.ViewModel.SelectedMax);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedMax")),
			(delegate
			{
				UpdateEditTextIfNeeded(_fromText, base.ViewModel.SelectedMinText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedMinText")),
			(delegate
			{
				UpdateEditTextIfNeeded(_toText, base.ViewModel.SelectedMaxText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedMaxText")),
			(delegate
			{
				_title.Text = base.ViewModel.Title;
				_rangeSlider.SetRangeValues(base.ViewModel.Min, base.ViewModel.Max);
				SetSliderMin(base.ViewModel.SelectedMin);
				SetSliderMax(base.ViewModel.SelectedMax);
				SetupDisabledState();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Filter"))
		})).AddTo(base.Disposables);
		_rangeSlider.LowerValueChanged += new DisposableDelegate<EventHandler>(delegate
		{
			base.ViewModel.SelectedMin = (int)_rangeSlider.GetSelectedMinValue();
			base.ViewModel.RaiseFilterChanged();
		}, delegate(EventHandler d)
		{
			_rangeSlider.LowerValueChanged -= d;
		}).AddTo(base.Disposables);
		_rangeSlider.UpperValueChanged += new DisposableDelegate<EventHandler>(delegate
		{
			base.ViewModel.SelectedMax = (int)_rangeSlider.GetSelectedMaxValue();
			base.ViewModel.RaiseFilterChanged();
		}, delegate(EventHandler d)
		{
			_rangeSlider.UpperValueChanged -= d;
		}).AddTo(base.Disposables);
		_fromText.TextChanged += new DisposableDelegate<EventHandler<TextChangedEventArgs>>(delegate
		{
			base.ViewModel.SelectedMinText = _fromText.Text ?? "";
		}, delegate(EventHandler<TextChangedEventArgs> h)
		{
			_fromText.TextChanged -= h;
		}).AddTo(base.Disposables);
		_toText.TextChanged += new DisposableDelegate<EventHandler<TextChangedEventArgs>>(delegate
		{
			base.ViewModel.SelectedMaxText = _toText.Text ?? "";
		}, delegate(EventHandler<TextChangedEventArgs> h)
		{
			_toText.TextChanged -= h;
		}).AddTo(base.Disposables);
		_fromText.FocusChange += new DisposableDelegate<EventHandler<FocusChangeEventArgs>>(delegate(object? sender, FocusChangeEventArgs args)
		{
			if (!args.HasFocus)
			{
				base.ViewModel.ApplyMinTextValue();
				this.HideKeyboard(base.Context);
			}
		}, delegate(EventHandler<FocusChangeEventArgs> d)
		{
			_fromText.FocusChange -= d;
		}).AddTo(base.Disposables);
		_toText.FocusChange += new DisposableDelegate<EventHandler<FocusChangeEventArgs>>(delegate(object? sender, FocusChangeEventArgs args)
		{
			if (!args.HasFocus)
			{
				base.ViewModel.ApplyMaxTextValue();
				this.HideKeyboard(base.Context);
			}
		}, delegate(EventHandler<FocusChangeEventArgs> d)
		{
			_toText.FocusChange -= d;
		}).AddTo(base.Disposables);
	}

	private void UpdateEditTextIfNeeded(EditText editText, string txt)
	{
		if (editText.Text != txt)
		{
			editText.Text = txt;
		}
	}

	private void SetSliderMin(int x)
	{
		float value = x;
		_rangeSlider.SetSelectedMinValue(value);
	}

	private void SetSliderMax(int x)
	{
		float value = x;
		_rangeSlider.SetSelectedMaxValue(value);
	}

	protected override void SetupDisabledState()
	{
		base.SetupDisabledState();
		if (base.IsDisabled)
		{
			_fromText.HideKeyboard(base.Context);
			_toText.HideKeyboard(base.Context);
		}
	}
}
