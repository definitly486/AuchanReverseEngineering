using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Text.Method;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Text;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

public class SnackView : LinearLayout
{
	private string _text;

	private string _description;

	private TextView _textView;

	private TextView _descriptionView;

	private ImageView _closeButton;

	private ImageView _iconView;

	public TextView TextView => _textView;

	public TextView DescriptionView => _descriptionView;

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			_textView.Text = value;
		}
	}

	public string Description
	{
		get
		{
			return _description;
		}
		set
		{
			_description = value;
			_descriptionView.Text = value;
			if (string.IsNullOrWhiteSpace(value))
			{
				_descriptionView.Visibility = ViewStates.Gone;
				return;
			}
			_descriptionView.Visibility = ViewStates.Visible;
			_descriptionView.Text = value;
		}
	}

	public bool CloseButtonActive
	{
		get
		{
			return _closeButton.Visibility == ViewStates.Visible;
		}
		set
		{
			_closeButton.Visibility = value.ToVisibility();
		}
	}

	public event EventHandler CloseClicked
	{
		add
		{
			_closeButton.Click += value;
		}
		remove
		{
			_closeButton.Click -= value;
		}
	}

	protected SnackView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public SnackView(Context context)
		: base(context)
	{
	}

	public SnackView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Init(context, attrs);
	}

	public SnackView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Init(base.Context, attrs);
	}

	public SnackView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Init(context, attrs);
	}

	private void Init(Context context, IAttributeSet attrs)
	{
		View view = View.Inflate(context, 2131493524, this);
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.SnackView, 0, 0);
		_text = typedArray.GetString(5) ?? string.Empty;
		_description = typedArray.GetString(2) ?? string.Empty;
		int resourceId = typedArray.GetResourceId(4, 2131231403);
		int resourceId2 = typedArray.GetResourceId(0, 2131231403);
		Color color = typedArray.GetColor(6, 2131099704);
		Color color2 = typedArray.GetColor(3, 2131099704);
		bool boolean = typedArray.GetBoolean(1, defValue: false);
		typedArray.Recycle();
		_textView = view.RequireViewById<TextView>(2131298401);
		_textView.SetTextColor(color);
		_textView.Text = _text;
		_descriptionView = view.RequireViewById<TextView>(2131298398);
		_descriptionView.SetTextColor(color2);
		Description = _description;
		_iconView = view.RequireViewById<ImageView>(2131298399);
		_iconView.SetImageResource(resourceId);
		ShowIcon();
		_closeButton = view.RequireViewById<ImageView>(2131298397);
		view.SetBackgroundResource(resourceId2);
		CloseButtonActive = boolean;
	}

	public void ShowIcon()
	{
		_iconView.Visibility = ViewStates.Visible;
	}

	public void SetFormattedText(string text)
	{
		_textView.TextFormatted = HtmlCompat.FromHtml(text, 0);
		_textView.MovementMethod = LinkMovementMethod.Instance;
	}

	public void AddLinkedText(LinkedText text, Color? highlightColor = null, bool underlineLinks = true)
	{
		_textView.AddLinkedText(text, highlightColor, underlineLinks);
	}
}
