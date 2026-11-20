using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Text;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Extensions;

namespace Auchan.Android.Controls;

[Register("auchan.CollapsableTextView")]
internal class CollapsableTextView : BaseCustomView
{
	private const string DOTS_AND_SPACE = "...  ";

	private string _fullText = string.Empty;

	private int _charactersCountCollapsed = 1;

	private TextView _textView;

	private TextView _moreView;

	protected override int LayoutId => 2131493145;

	public bool IsCollapsable { get; private set; } = true;

	public bool IsCollapsed { get; private set; } = true;

	public CollapsableTextView(Context context)
		: base(context)
	{
	}

	public CollapsableTextView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public CollapsableTextView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public CollapsableTextView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public CollapsableTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void Init(Context context, IAttributeSet? attrs = null)
	{
		base.Init(context, attrs);
		_textView = base.View.RequireViewById<TextView>(2131298621);
		_moreView = base.View.RequireViewById<TextView>(2131297599);
		_textView.Click += delegate
		{
			SwitchText();
		};
	}

	public void Setup(string fullText, string moreText, int maxLinesCollapsed, int widthPX)
	{
		if (string.IsNullOrWhiteSpace(fullText))
		{
			IsCollapsed = false;
			IsCollapsable = false;
			_fullText = string.Empty;
			_moreView.Visibility = ViewStates.Gone;
			UpdateText();
			return;
		}
		_moreView.Text = moreText;
		string text = moreText + "...  ";
		int num = (int)Math.Ceiling(_moreView.Paint.MeasureText(text));
		_fullText = fullText;
		string[] array = _fullText.Split(" ");
		int num2 = 0;
		int num3 = 0;
		string text2 = fullText;
		_charactersCountCollapsed = 0;
		string[] array2 = array;
		foreach (string text3 in array2)
		{
			float num4 = _textView.Paint.MeasureText(text2, 0, num3 + text3.Length);
			int num5 = ((num2 == 2) ? (widthPX - num) : widthPX);
			if (num4 > (float)num5)
			{
				_charactersCountCollapsed += num3;
				num2++;
				if (num2 >= maxLinesCollapsed)
				{
					break;
				}
				text2 = _fullText.SubstringSafe(_charactersCountCollapsed);
				num3 = text3.Length + 1;
			}
			else
			{
				num3 += text3.Length + 1;
			}
		}
		IsCollapsed = num2 >= maxLinesCollapsed;
		IsCollapsable = IsCollapsed;
		_moreView.Visibility = IsCollapsed.ToVisibility();
		UpdateText();
	}

	public void Collapse()
	{
		if (IsCollapsable && !IsCollapsed)
		{
			IsCollapsed = true;
			UpdateText();
			_moreView.Visibility = ViewStates.Visible;
		}
	}

	private void SwitchText()
	{
		if (IsCollapsable)
		{
			IsCollapsed = !IsCollapsed;
			UpdateText();
			_moreView.Visibility = IsCollapsed.ToVisibility();
		}
	}

	private void UpdateText()
	{
		_textView.TextFormatted = HtmlCompat.FromHtml(IsCollapsed ? (_fullText.SubstringSafe(0, _charactersCountCollapsed.Clamp(0, _fullText.Length)).Trim() + "...  ") : _fullText, 0);
	}
}
