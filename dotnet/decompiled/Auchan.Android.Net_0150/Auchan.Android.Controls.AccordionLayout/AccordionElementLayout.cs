using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Controls.Accordion;

namespace Auchan.Android.Controls.AccordionLayout;

[Register("auchan.AccordionElementLayout")]
internal class AccordionElementLayout : LinearLayout
{
	private bool _isInitialized;

	private Dictionary<AccordionElementState, View> _stateViews = new Dictionary<AccordionElementState, View>();

	public AccordionElementState State { get; private set; }

	public AccordionElementLayout(Context context)
		: base(context)
	{
	}

	public AccordionElementLayout(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public AccordionElementLayout(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public AccordionElementLayout(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected AccordionElementLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private void Initialize()
	{
		foreach (View item in from index in Enumerable.Range(0, ChildCount)
			select GetChildAt(index))
		{
			if (item.Id == -1)
			{
				continue;
			}
			string resourceName = Resources.GetResourceName(item.Id);
			Type typeFromHandle = typeof(AccordionElementState);
			string[] names = Enum.GetNames(typeFromHandle);
			foreach (string text in names)
			{
				EnumMemberAttribute enumMemberAttribute = ((EnumMemberAttribute[])typeFromHandle.GetField(text).GetCustomAttributes(typeof(EnumMemberAttribute), inherit: true)).Single();
				if (resourceName.Contains("_" + enumMemberAttribute.Value, StringComparison.OrdinalIgnoreCase))
				{
					_stateViews[(AccordionElementState)Enum.Parse(typeFromHandle, text)] = item;
					break;
				}
			}
		}
		_isInitialized = true;
	}

	public void SetState(AccordionElementState state)
	{
		if (!_isInitialized)
		{
			Initialize();
		}
		foreach (KeyValuePair<AccordionElementState, View> stateView in _stateViews)
		{
			stateView.Value.Visibility = (state == stateView.Key).ToVisibility();
		}
		State = state;
	}
}
