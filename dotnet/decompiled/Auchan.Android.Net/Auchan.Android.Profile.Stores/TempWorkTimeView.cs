using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Base.WidgetBases;
using Auchan.Common.Profile.Stores.Models;

namespace Auchan.Android.Profile.Stores;

[Register("auchan.TempWorkTimeView")]
public class TempWorkTimeView : LinearLayoutWidgetBase
{
	private TextView _titleText;

	private ViewGroup _leftLayout;

	private ViewGroup _rightLayout;

	protected TempWorkTimeView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public TempWorkTimeView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public TempWorkTimeView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public TempWorkTimeView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public TempWorkTimeView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493201, this);
		_titleText = view.RequireViewById<TextView>(2131298649);
		_leftLayout = view.RequireViewById<ViewGroup>(2131297427);
		_rightLayout = view.RequireViewById<ViewGroup>(2131298247);
	}

	public void Setup(FullStoreModel storesItemViewModel, string title)
	{
		_leftLayout.RemoveAllViews();
		_rightLayout.RemoveAllViews();
		_titleText.Text = title;
		foreach (TempWorkHoursModel tempWorkHour in storesItemViewModel.TempWorkHours)
		{
			TextView textView = new TextView(base.Context);
			textView.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131099849)));
			textView.SetTextSize(ComplexUnitType.Sp, 14f);
			textView.Text = tempWorkHour.DateText;
			_leftLayout.AddView(textView);
			TextView textView2 = new TextView(base.Context);
			textView2.Gravity = GravityFlags.Right;
			textView2.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131099849)));
			textView2.SetTextSize(ComplexUnitType.Sp, 14f);
			textView2.Text = tempWorkHour.TimeText;
			_rightLayout.AddView(textView2);
		}
	}
}
