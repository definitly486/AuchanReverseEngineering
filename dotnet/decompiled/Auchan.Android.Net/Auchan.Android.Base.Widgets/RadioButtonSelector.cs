using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;

namespace Auchan.Android.Base.Widgets;

[Register("auchan.RadioButtonSelector")]
public class RadioButtonSelector : LinearLayoutWidgetBase
{
	private int _selectedIndex = -1;

	private bool _selectionEnabled = true;

	public int SelectedIndex
	{
		get
		{
			return _selectedIndex;
		}
		private set
		{
			if (_selectedIndex != value)
			{
				_selectedIndex = value;
				this.SelectionChanged?.Invoke();
			}
		}
	}

	public event Action? SelectionChanged;

	protected RadioButtonSelector(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public RadioButtonSelector(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public RadioButtonSelector(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public RadioButtonSelector(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public RadioButtonSelector(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
	}

	public void SetButtons(IEnumerable<string> names, ILifecycleOwner viewLifecycleOwner)
	{
		RemoveAllViews();
		foreach (string name in names)
		{
			View btn = LayoutInflater.From(base.Context).Inflate(2131493312, this, attachToRoot: false);
			btn.RequireViewById<TextView>(2131298659).Text = name;
			AddView(btn);
			btn.OnClick((EventHandler)delegate
			{
				SelectButton(btn);
			}).AutoDisposeOnDestroy(viewLifecycleOwner);
		}
	}

	private void SelectButton(View button)
	{
		SelectButton(IndexOfChild(button));
	}

	public void SelectButton(int index)
	{
		if (!_selectionEnabled)
		{
			return;
		}
		_selectionEnabled = false;
		for (int i = 0; i < ChildCount; i++)
		{
			View childAt = GetChildAt(i);
			if (i == index && childAt.Selected)
			{
				childAt.Selected = false;
				SelectedIndex = -1;
				_selectionEnabled = true;
				return;
			}
			childAt.Selected = i == index;
		}
		SelectedIndex = index;
		_selectionEnabled = true;
	}
}
