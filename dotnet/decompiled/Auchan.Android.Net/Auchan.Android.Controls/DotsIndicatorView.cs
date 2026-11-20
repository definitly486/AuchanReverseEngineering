using System;
using System.Collections.Generic;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using AndroidX.Core.Content;
using Java.Interop;
using Java.Lang;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

public class DotsIndicatorView : View, ValueAnimator.IAnimatorUpdateListener, IJavaObject, IDisposable, IJavaPeerable, ICustomAnimationListener
{
	private const int MIN_VISIBLE_DOT_COUNT = 6;

	private const int DEFAULT_VISIBLE_DOTS_COUNT = 6;

	private int activeDotSize;

	private int inactiveDotSize;

	private int mediumDotSize;

	private int smallDotSize;

	private int dotMargin;

	private Paint activePaint = new Paint(PaintFlags.AntiAlias);

	private Paint inactivePaint = new Paint(PaintFlags.AntiAlias);

	private int posY;

	private int previousPage;

	private ValueAnimator translationAnim;

	private List<Dot> dotsList = new List<Dot>();

	private int _startPosX;

	private int _marginLeft;

	public int StartPosX
	{
		get
		{
			return _startPosX;
		}
		set
		{
			_startPosX = value + _marginLeft;
		}
	}

	public int NoOfPages { get; set; }

	public int VisibleDotCounts { get; set; } = 6;

	public int CurrentPage { get; private set; }

	public int ActiveDotRadius => activeDotSize / 2;

	public int ActiveDotStartX => activeDotSize + dotMargin;

	public int InactiveDotRadius => inactiveDotSize / 2;

	public int InactiveDotStartX => inactiveDotSize + dotMargin;

	public int MediumDotRadius => mediumDotSize / 2;

	public int MediumDotStartX => mediumDotSize + dotMargin;

	public int SmallDotRadius => smallDotSize / 2;

	public int SmallDotStartX => smallDotSize + dotMargin;

	public DotsIndicatorView(Context context)
		: base(context)
	{
		Setup(context, null);
	}

	public DotsIndicatorView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Setup(context, attrs);
	}

	public DotsIndicatorView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Setup(context, attrs);
	}

	public DotsIndicatorView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Setup(context, attrs);
	}

	private void Setup(Context context, IAttributeSet attributeSet)
	{
		Resources resources = Resources;
		if (attributeSet != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attributeSet, ResourceConstant.Styleable.InstaDotView);
			activePaint.SetStyle(Paint.Style.Fill);
			activePaint.Color = typedArray.GetColor(0, ContextCompat.GetColor(base.Context, 2131099704));
			inactivePaint.SetStyle(Paint.Style.Fill);
			inactivePaint.Color = typedArray.GetColor(2, ContextCompat.GetColor(base.Context, 2131099700));
			activeDotSize = typedArray.GetDimensionPixelSize(1, resources.GetDimensionPixelSize(2131165340));
			inactiveDotSize = typedArray.GetDimensionPixelSize(3, resources.GetDimensionPixelSize(2131165341));
			mediumDotSize = typedArray.GetDimensionPixelSize(5, resources.GetDimensionPixelSize(2131165343));
			smallDotSize = typedArray.GetDimensionPixelSize(6, resources.GetDimensionPixelSize(2131165344));
			dotMargin = typedArray.GetDimensionPixelSize(4, resources.GetDimensionPixelSize(2131165342));
			SetVisibleDotCounts(typedArray.GetInteger(7, 6));
			typedArray.Recycle();
		}
		posY = activeDotSize / 2;
		InitCircles();
	}

	public void SetPage(int pos)
	{
		for (int i = CurrentPage + 1; i <= pos; i++)
		{
			OnDirectPageChange(i);
			UpdateLayoutLocation((NoOfPages > VisibleDotCounts) ? SmallDotStartX : 0);
		}
	}

	private void OnDirectPageChange(int page)
	{
		CurrentPage = page;
		if (page != previousPage && page >= 0 && page <= NoOfPages - 1)
		{
			UpdateDots(withoutAnimation: true);
			previousPage = CurrentPage;
		}
	}

	public void SetVisibleDotCounts(int visibleDotCounts)
	{
		if (visibleDotCounts < 6)
		{
			throw new RuntimeException("Visible Dot count cannot be smaller than " + 6);
		}
		VisibleDotCounts = visibleDotCounts;
		Recreate();
	}

	public void SetNoOfPages(int noOfPages)
	{
		if (noOfPages != NoOfPages)
		{
			Visibility = ((noOfPages <= 1) ? ViewStates.Gone : ViewStates.Visible);
			NoOfPages = noOfPages;
			Recreate();
		}
	}

	public void Recreate()
	{
		InitCircles();
		RequestLayout();
		Invalidate();
	}

	protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		int num = (activeDotSize + dotMargin) * (dotsList.Count + 1);
		int num2 = activeDotSize;
		MeasureSpecMode mode = MeasureSpec.GetMode(widthMeasureSpec);
		int size = MeasureSpec.GetSize(widthMeasureSpec);
		MeasureSpecMode mode2 = MeasureSpec.GetMode(heightMeasureSpec);
		int size2 = MeasureSpec.GetSize(heightMeasureSpec);
		SetMeasuredDimension(mode switch
		{
			MeasureSpecMode.Exactly => size, 
			MeasureSpecMode.AtMost => Java.Lang.Math.Min(num, size), 
			_ => num, 
		}, mode2 switch
		{
			MeasureSpecMode.Exactly => size2, 
			MeasureSpecMode.AtMost => Java.Lang.Math.Min(num2, size2), 
			_ => num2, 
		});
	}

	protected override void OnDraw(Canvas canvas)
	{
		base.OnDraw(canvas);
		DrawCircles(canvas);
	}

	private void DrawCircles(Canvas canvas)
	{
		int num = StartPosX;
		for (int i = 0; i < dotsList.Count; i++)
		{
			Dot dot = dotsList[i];
			Paint paint = inactivePaint;
			int num2;
			switch (dot.State)
			{
			case Dot.DotState.Active:
				paint = activePaint;
				num2 = ActiveDotRadius;
				num += ActiveDotStartX;
				break;
			case Dot.DotState.Inactive:
				num2 = InactiveDotRadius;
				num += InactiveDotStartX;
				break;
			case Dot.DotState.Medium:
				num2 = MediumDotRadius;
				num += MediumDotStartX;
				break;
			case Dot.DotState.Small:
				num2 = SmallDotRadius;
				num += SmallDotStartX;
				break;
			default:
				num2 = 0;
				num = 0;
				break;
			}
			canvas.DrawCircle(num, posY, num2, paint);
		}
	}

	private void InitCircles()
	{
		int num = Java.Lang.Math.Min(NoOfPages, VisibleDotCounts);
		if (num >= 1)
		{
			StartPosX = ((NoOfPages > VisibleDotCounts) ? SmallDotStartX : 0);
			dotsList = new List<Dot>(num);
			for (int i = 0; i < num; i++)
			{
				Dot dot = new Dot();
				Dot.DotState state = ((NoOfPages <= VisibleDotCounts) ? ((i == 0) ? Dot.DotState.Active : Dot.DotState.Inactive) : ((i != VisibleDotCounts - 1) ? ((i == VisibleDotCounts - 2) ? Dot.DotState.Medium : ((i == 0) ? Dot.DotState.Active : Dot.DotState.Inactive)) : Dot.DotState.Small));
				dot.State = state;
				dotsList.Add(dot);
			}
			Invalidate();
		}
	}

	public void OnPageChange(int page)
	{
		CurrentPage = page;
		if (page != previousPage && page >= 0 && page <= NoOfPages - 1)
		{
			UpdateDots(withoutAnimation: false);
			previousPage = CurrentPage;
		}
	}

	private void UpdateDots(bool withoutAnimation)
	{
		if (NoOfPages <= VisibleDotCounts)
		{
			SetupNormalDots();
			return;
		}
		for (int i = 0; i < dotsList.Count; i++)
		{
			Dot dot = dotsList[i];
			if (dot.State == Dot.DotState.Active)
			{
				dot.State = Dot.DotState.Inactive;
				if (CurrentPage > previousPage)
				{
					SetupFlexibleCirclesRight(i, withoutAnimation);
				}
				else
				{
					SetupFlexibleCirclesLeft(i, withoutAnimation);
				}
				break;
			}
		}
	}

	private void SetupFlexibleCirclesLeft(int position, bool withoutAnimation)
	{
		if (position <= 2)
		{
			if (CurrentPage == 0)
			{
				dotsList[0].State = Dot.DotState.Active;
				Invalidate();
			}
			else if (CurrentPage == 1)
			{
				dotsList[0].State = Dot.DotState.Medium;
				dotsList[1].State = Dot.DotState.Active;
				Invalidate();
			}
			else
			{
				RemoveAddLeft(position, withoutAnimation);
			}
		}
		else
		{
			dotsList[position - 1].State = Dot.DotState.Active;
			Invalidate();
		}
	}

	private void RemoveAddLeft(int position, bool withoutAnimation)
	{
		dotsList.RemoveAt(dotsList.Count - 1);
		StartPosX = 0;
		if (withoutAnimation)
		{
			EndAnimation(DotDirection.Left, position);
		}
		else
		{
			GetTranslationAnimation(StartPosX, SmallDotStartX, this, position, DotDirection.Left).Start();
		}
	}

	private void SetupFlexibleCirclesRight(int position, bool withoutAnimation)
	{
		if (position >= VisibleDotCounts - 3)
		{
			if (CurrentPage == NoOfPages - 1)
			{
				dotsList[dotsList.Count - 1].State = Dot.DotState.Active;
				Invalidate();
			}
			else if (CurrentPage == NoOfPages - 2)
			{
				dotsList[dotsList.Count - 1].State = Dot.DotState.Medium;
				dotsList[dotsList.Count - 2].State = Dot.DotState.Active;
				Invalidate();
			}
			else
			{
				RemoveAddRight(position, withoutAnimation);
			}
		}
		else
		{
			dotsList[position + 1].State = Dot.DotState.Active;
			Invalidate();
		}
	}

	private void RemoveAddRight(int position, bool withoutAnimation)
	{
		dotsList.RemoveAt(0);
		StartPosX += SmallDotStartX;
		if (withoutAnimation)
		{
			EndAnimation(DotDirection.Right, position);
		}
		else
		{
			GetTranslationAnimation(StartPosX, SmallDotStartX, this, position, DotDirection.Right).Start();
		}
	}

	private void SetupNormalDots()
	{
		dotsList[CurrentPage].State = Dot.DotState.Active;
		dotsList[previousPage].State = Dot.DotState.Inactive;
		Invalidate();
	}

	private ValueAnimator GetTranslationAnimation(int from, int to, ICustomAnimationListener listener, int position, DotDirection dotDirection)
	{
		if (translationAnim != null)
		{
			translationAnim.Cancel();
		}
		translationAnim = ValueAnimator.OfInt(from, to);
		translationAnim.SetDuration(120L);
		translationAnim.SetInterpolator(new AccelerateDecelerateInterpolator());
		translationAnim.AddUpdateListener(this);
		translationAnim.AddListener(new AnimationListener(listener, position, dotDirection));
		return translationAnim;
	}

	public void OnAnimationUpdate(ValueAnimator animation)
	{
		int val = (int)animation.AnimatedValue;
		UpdateLayoutLocation(val);
	}

	void ICustomAnimationListener.OnAnimationEnd(DotDirection dotDirection, int position)
	{
		EndAnimation(dotDirection, position);
	}

	private void EndAnimation(DotDirection dotDirection, int position)
	{
		if (dotDirection == DotDirection.Left)
		{
			dotsList[dotsList.Count - 1].State = Dot.DotState.Small;
			dotsList[dotsList.Count - 2].State = Dot.DotState.Medium;
		}
		if (dotDirection == DotDirection.Right)
		{
			dotsList[0].State = Dot.DotState.Small;
			dotsList[1].State = Dot.DotState.Medium;
		}
		Dot dot = new Dot();
		dot.State = Dot.DotState.Active;
		dotsList.Insert(position, dot);
		Invalidate();
	}

	private void UpdateLayoutLocation(int val)
	{
		if (StartPosX != val)
		{
			StartPosX = val;
			Invalidate();
		}
	}
}
