using System;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Widget;
using AndroidX.GridLayout.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

public class EnterPinView : GridLayout
{
	private const int columnCount = 3;

	private const int rowCount = 4;

	private const int lastRowIndex = 3;

	private const int noResId = -1;

	public EventHandler<int> NumberButtonPressed;

	public EventHandler BiometryButtonPressed;

	public EventHandler RemoveButtonPressed;

	private View _leftButton;

	public bool BiometryButtonVisibility
	{
		get
		{
			return _leftButton.Visibility == ViewStates.Visible;
		}
		set
		{
			_leftButton.Visibility = value.ToVisibility();
		}
	}

	public EnterPinView(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public EnterPinView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public EnterPinView(Context context, IAttributeSet attrs, int defStyle)
		: base(context, attrs, defStyle)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet attrs = null)
	{
		AlignmentMode = 0;
		ColumnCount = 3;
		RowCount = 4;
		UseDefaultMargins = false;
		FillNumberButtons();
		(int, int) iconsResources = GetIconsResources(context, attrs);
		int item = iconsResources.Item1;
		int item2 = iconsResources.Item2;
		_leftButton = GetLeftButton(item);
		View rightButton = GetRightButton(item2);
		AddView(_leftButton);
		AddView(CreateTextButtonView(3, 1, 0));
		AddView(rightButton);
	}

	private (int, int) GetIconsResources(Context context, IAttributeSet attrs)
	{
		if (attrs == null)
		{
			return (-1, 2131231142);
		}
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.EnterPinView, 0, 0);
		try
		{
			int resourceId = typedArray.GetResourceId(0, -1);
			int resourceId2 = typedArray.GetResourceId(1, 2131231142);
			return (resourceId, resourceId2);
		}
		finally
		{
			typedArray.Recycle();
		}
	}

	private void FillNumberButtons()
	{
		int num = 1;
		for (int i = 0; i < 3; i++)
		{
			int num2 = 0;
			while (num2 < 3)
			{
				View child = CreateTextButtonView(i, num2, num);
				AddView(child);
				num2++;
				num++;
			}
		}
	}

	private View GetLeftButton(int leftIconResId)
	{
		View view;
		if (leftIconResId != -1)
		{
			view = CreateImageButtonView(3, 0, leftIconResId);
			view.Click += delegate(object? o, EventArgs e)
			{
				BiometryButtonPressed?.Invoke(this, e);
			};
		}
		else
		{
			view = CreateEmptyButtonView(3, 0);
		}
		return view;
	}

	private View GetRightButton(int rightIconResId)
	{
		View view = CreateImageButtonView(3, 2, rightIconResId);
		view.Click += delegate(object? o, EventArgs e)
		{
			RemoveButtonPressed?.Invoke(this, e);
		};
		return view;
	}

	private View CreateTextButtonView(int row, int col, int buttonValue)
	{
		FrameLayout frameLayout = new FrameLayout(base.Context);
		TextView textView = new TextView(base.Context);
		textView.Gravity = GravityFlags.Center;
		textView.SetBackgroundResource(2131230908);
		TextViewCompat.SetTextAppearance(textView, 2131952014);
		textView.Text = buttonValue.ToString();
		FrameLayout.LayoutParams layoutParameters = new FrameLayout.LayoutParams(Converter.DpToPx(64f), Converter.DpToPx(64f))
		{
			Gravity = GravityFlags.Center
		};
		textView.LayoutParameters = layoutParameters;
		frameLayout.AddView(textView);
		AttachLayoutParams(row, col, frameLayout);
		frameLayout.Click += delegate
		{
			NumberButtonPressed?.Invoke(this, buttonValue);
		};
		return frameLayout;
	}

	private View CreateEmptyButtonView(int row, int col)
	{
		FrameLayout frameLayout = new FrameLayout(base.Context);
		AttachLayoutParams(row, col, frameLayout);
		return frameLayout;
	}

	private View CreateImageButtonView(int row, int col, int drawable)
	{
		FrameLayout frameLayout = new FrameLayout(base.Context);
		ImageView imageView = new ImageView(base.Context);
		if (OperatingSystem.IsAndroidVersionAtLeast(23))
		{
			imageView.SetForegroundGravity(GravityFlags.Center);
		}
		FrameLayout.LayoutParams layoutParameters = new FrameLayout.LayoutParams(-2, -2)
		{
			Gravity = GravityFlags.Center
		};
		imageView.LayoutParameters = layoutParameters;
		imageView.SetImageResource(drawable);
		frameLayout.AddView(imageView);
		AttachLayoutParams(row, col, frameLayout);
		return frameLayout;
	}

	private void AttachLayoutParams(int row, int col, View view)
	{
		Spec? rowSpec = GridLayout.InvokeSpec(row, 1f);
		Spec columnSpec = GridLayout.InvokeSpec(col, 1f);
		LayoutParams layoutParams = new LayoutParams(rowSpec, columnSpec);
		layoutParams.SetGravity(7);
		view.LayoutParameters = layoutParams;
	}
}
