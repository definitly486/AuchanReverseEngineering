using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Common.SupportChat.ItemViewModels;

namespace Auchan.Android.SupportChat;

internal sealed class SupportChatLayoutManager : RecyclerView.LayoutManager
{
	private sealed class CustomLinearSmoothScroller : LinearSmoothScroller
	{
		private readonly SupportChatLayoutManager _parent;

		protected override int VerticalSnapPreference => -1;

		public CustomLinearSmoothScroller(Context context, SupportChatLayoutManager parent)
			: base(context)
		{
			_parent = parent;
		}

		public override PointF ComputeScrollVectorForPosition(int targetPosition)
		{
			return _parent.ComputeScrollVectorForPosition(targetPosition);
		}
	}

	private sealed class ViewLayoutInfo
	{
		public View View { get; }

		public int Width { get; }

		public int Height { get; }

		public int Pos { get; }

		public bool Cached { get; }

		public ViewLayoutInfo(View view, int width, int height, int pos, bool cached)
		{
			View = view;
			Width = width;
			Height = height;
			Pos = pos;
			Cached = cached;
		}
	}

	private const string TAG = "SupportChatLayoutManager: ";

	private SparseArray<View> _viewCache = new SparseArray<View>();

	private int _anchorPos;

	public int ItemsPerLine { get; set; }

	public int RatingsPerLine { get; set; }

	private int MaxItemsPerLine
	{
		get
		{
			if (!HaveToLayoutRating())
			{
				return ItemsPerLine;
			}
			return RatingsPerLine;
		}
	}

	public ICollection<MacroItemViewModel> MacroButtons { get; set; }

	public override bool AutoMeasureEnabled
	{
		get
		{
			return true;
		}
		[Obsolete]
		set
		{
			DoNothing(value);
		}
	}

	public SupportChatLayoutManager(Context context)
	{
	}

	public override RecyclerView.LayoutParams GenerateDefaultLayoutParams()
	{
		return new RecyclerView.LayoutParams(-1, -2);
	}

	private static void DoNothing(bool value)
	{
	}

	public override void OnLayoutChildren(RecyclerView.Recycler recycler, RecyclerView.State state)
	{
		DetachAndScrapAttachedViews(recycler);
		Fill(recycler);
		_anchorPos = 0;
		if (ItemCount > 0 && ChildCount < ItemCount)
		{
			while (GetChildrenMaxPosition() < ItemCount - 1)
			{
				int childrenMaxBottom = GetChildrenMaxBottom();
				OffsetChildrenVertical(-childrenMaxBottom);
				Fill(recycler);
			}
		}
		if (ItemCount > 0 && ChildCount == ItemCount)
		{
			int dy = Height - GetChildrenMaxBottom();
			OffsetChildrenVertical(dy);
		}
	}

	private int GetChildrenMaxBottom()
	{
		int num = 0;
		for (int i = 0; i < ChildCount; i++)
		{
			View childAt = GetChildAt(i);
			num = Math.Max(GetDecoratedBottom(childAt), num);
		}
		return num;
	}

	private int GetChildrenMaxPosition()
	{
		int childCount = ChildCount;
		int num = 0;
		for (int i = 0; i < childCount; i++)
		{
			View childAt = GetChildAt(i);
			num = Math.Max(GetPosition(childAt), num);
		}
		return num;
	}

	private void Fill(RecyclerView.Recycler recycler)
	{
		View anchorView = GetAnchorView();
		_viewCache.Clear();
		int i = 0;
		for (int childCount = ChildCount; i < childCount; i++)
		{
			View childAt = GetChildAt(i);
			int position = GetPosition(childAt);
			_viewCache.Put(position, childAt);
		}
		for (int j = 0; j < _viewCache.Size(); j++)
		{
			DetachView(_viewCache.ValueAt(j));
		}
		FillUp(anchorView, recycler);
		FillDown(anchorView, recycler);
		for (int k = 0; k < _viewCache.Size(); k++)
		{
			recycler.RecycleView(_viewCache.ValueAt(k));
		}
	}

	private void FillUp(View anchorView, RecyclerView.Recycler recycler)
	{
		Rect rect = new Rect();
		int num;
		if (anchorView != null)
		{
			num = GetPosition(anchorView);
			GetDecoratedRect(anchorView, rect);
		}
		else
		{
			num = _anchorPos;
		}
		bool flag = true;
		Rect prevViewRect = new Rect(rect);
		Rect rect2 = new Rect();
		List<ViewLayoutInfo> line = new List<ViewLayoutInfo>();
		int num2 = 0;
		int num3 = num - 1;
		while (flag && num3 >= 0)
		{
			View view = _viewCache.Get(num3);
			ViewLayoutInfo viewLayoutInfo;
			if (view != null)
			{
				GetDecoratedRect(view, rect2);
				viewLayoutInfo = new ViewLayoutInfo(view, rect2.Width(), rect2.Height(), num3, cached: true);
			}
			else
			{
				view = recycler.GetViewForPosition(num3);
				(int width, int height) tuple = Measure(view, IsNeedToLayoutAtFullWidth(view));
				int item = tuple.width;
				int item2 = tuple.height;
				viewLayoutInfo = new ViewLayoutInfo(view, item, item2, num3, cached: false);
			}
			if (num2 + viewLayoutInfo.Width > Width || (MaxItemsPerLine > 0 && line.Count == MaxItemsPerLine))
			{
				View view2 = LayoutLine();
				num2 = 0;
				if (view2 != null)
				{
					GetDecoratedRect(view2, prevViewRect);
				}
				flag = prevViewRect.Top > 0;
			}
			num2 += viewLayoutInfo.Width;
			if (flag || num3 == 1)
			{
				line.Insert(0, viewLayoutInfo);
			}
			else if (!viewLayoutInfo.Cached)
			{
				recycler.RecycleView(viewLayoutInfo.View);
			}
			num3--;
		}
		LayoutLine();
		View LayoutLine()
		{
			int num4 = PaddingLeft;
			View result = null;
			for (int i = 0; i < line.Count; i++)
			{
				ViewLayoutInfo viewLayoutInfo2 = line[i];
				if (viewLayoutInfo2.Cached)
				{
					AttachView(viewLayoutInfo2.View, 0);
					_viewCache.Remove(viewLayoutInfo2.Pos);
				}
				else
				{
					AddView(viewLayoutInfo2.View, 0);
					LayoutDecorated(viewLayoutInfo2.View, num4, prevViewRect.Top - viewLayoutInfo2.Height, num4 + viewLayoutInfo2.Width, prevViewRect.Top);
				}
				num4 = GetDecoratedRight(viewLayoutInfo2.View);
				result = viewLayoutInfo2.View;
			}
			line.Clear();
			return result;
		}
	}

	private void FillDown(View anchorView, RecyclerView.Recycler recycler)
	{
		Rect rect = new Rect();
		int num;
		if (anchorView != null)
		{
			num = GetPosition(anchorView);
			GetDecoratedRect(anchorView, rect);
		}
		else
		{
			num = _anchorPos;
		}
		int num2 = num;
		bool flag = true;
		int height = Height;
		Rect rect2 = new Rect(rect);
		int itemCount = ItemCount;
		int num3 = 0;
		while (flag && num2 < itemCount)
		{
			View view = _viewCache.Get(num2);
			if (view == null)
			{
				bool flag2 = false;
				while (!flag2 && num2 < ItemCount)
				{
					view = recycler.GetViewForPosition(num2);
					var (num4, num5) = Measure(view, IsNeedToLayoutAtFullWidth(view));
					AddView(view);
					flag2 = rect2.Right + num4 > Width || (MaxItemsPerLine > 0 && num3 == MaxItemsPerLine);
					int num6 = (flag2 ? PaddingLeft : rect2.Right);
					int num7 = (flag2 ? rect2.Bottom : rect2.Top);
					LayoutDecorated(view, num6, num7, num6 + num4, num7 + num5);
					GetDecoratedRect(view, rect2);
					num2++;
					if (flag2)
					{
						num3 = 0;
					}
					num3++;
				}
			}
			else
			{
				AttachView(view);
				_viewCache.Remove(num2);
				GetDecoratedRect(view, rect2);
				num3 = ((rect2.Left <= 0) ? 1 : (num3 + 1));
				num2++;
			}
			flag = rect2.Top <= height;
		}
	}

	private bool IsNeedToLayoutAtFullWidth(View view)
	{
		ICollection<MacroItemViewModel> macroButtons = MacroButtons;
		if (macroButtons != null && macroButtons.Count == 1)
		{
			return !(view is IChatContentView);
		}
		return false;
	}

	private bool HaveToLayoutRating()
	{
		return MacroButtons.All((MacroItemViewModel x) => x.IsRating);
	}

	private void GetDecoratedRect(View view, Rect rect)
	{
		rect.Top = GetDecoratedTop(view);
		rect.Bottom = GetDecoratedBottom(view);
		rect.Left = GetDecoratedLeft(view);
		rect.Right = GetDecoratedRight(view);
	}

	private (int widthSpec, int heightSpec) MakeMeasureSpecForView(View view, bool enforceWidth)
	{
		int item = View.MeasureSpec.MakeMeasureSpec(Width - PaddingRight - PaddingLeft, (!enforceWidth && view.LayoutParameters.Width == -2) ? MeasureSpecMode.AtMost : MeasureSpecMode.Exactly);
		int item2 = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.AtMost);
		return (widthSpec: item, heightSpec: item2);
	}

	private (int width, int height) Measure(View view, bool enforceWidth)
	{
		var (widthSpec, heightSpec) = MakeMeasureSpecForView(view, enforceWidth);
		MeasureChildWithDecorationsAndMargin(view, widthSpec, heightSpec);
		int decoratedMeasuredWidth = GetDecoratedMeasuredWidth(view);
		int decoratedMeasuredHeight = GetDecoratedMeasuredHeight(view);
		return (width: decoratedMeasuredWidth, height: decoratedMeasuredHeight);
	}

	private View GetAnchorView()
	{
		int childCount = ChildCount;
		Rect r = new Rect(0, 0, Width, Height);
		Rect rect = new Rect();
		int num = 0;
		View result = null;
		for (int i = 0; i < childCount; i++)
		{
			View childAt = GetChildAt(i);
			GetDecoratedRect(childAt, rect);
			if (rect.Intersect(r) && rect.Left == 0 && rect.Width() * rect.Height() > num)
			{
				result = childAt;
			}
		}
		return result;
	}

	public override void SmoothScrollToPosition(RecyclerView recyclerView, RecyclerView.State state, int position)
	{
		if (position < ItemCount)
		{
			CustomLinearSmoothScroller customLinearSmoothScroller = new CustomLinearSmoothScroller(recyclerView.Context, this);
			customLinearSmoothScroller.TargetPosition = position;
			StartSmoothScroll(customLinearSmoothScroller);
		}
	}

	private PointF ComputeScrollVectorForPosition(int targetPosition)
	{
		if (ChildCount == 0)
		{
			return null;
		}
		int position = GetPosition(GetChildAt(0));
		int num = ((targetPosition >= position) ? 1 : (-1));
		return new PointF(0f, num);
	}

	public override bool CanScrollVertically()
	{
		return true;
	}

	public override bool CanScrollHorizontally()
	{
		return false;
	}

	public override int ScrollVerticallyBy(int dy, RecyclerView.Recycler recycler, RecyclerView.State state)
	{
		int num = ScrollVerticallyInternal(dy);
		OffsetChildrenVertical(-num);
		Fill(recycler);
		return num;
	}

	private int ScrollVerticallyInternal(int dy)
	{
		int childCount = ChildCount;
		int itemCount = ItemCount;
		if (childCount == 0)
		{
			return 0;
		}
		View childAt = GetChildAt(0);
		View childAt2 = GetChildAt(childCount - 1);
		int decoratedTop = GetDecoratedTop(childAt);
		int num = GetDecoratedBottom(childAt2) - decoratedTop;
		if (itemCount == childCount && num <= Height)
		{
			return 0;
		}
		int result = 0;
		if (dy < 0)
		{
			View childAt3 = GetChildAt(0);
			result = ((GetPosition(childAt3) <= 0) ? Math.Max(GetDecoratedTop(childAt3), dy) : dy);
		}
		else if (dy > 0)
		{
			View childAt4 = GetChildAt(childCount - 1);
			if (GetPosition(childAt4) < itemCount - 1)
			{
				result = dy;
			}
			else
			{
				int decoratedBottom = GetDecoratedBottom(childAt4);
				int height = Height;
				result = Math.Min(decoratedBottom - height, dy);
			}
		}
		return result;
	}

	private void MeasureChildWithDecorationsAndMargin(View child, int widthSpec, int heightSpec)
	{
		Rect rect = new Rect();
		CalculateItemDecorationsForChild(child, rect);
		RecyclerView.LayoutParams layoutParams = (RecyclerView.LayoutParams)child.LayoutParameters;
		widthSpec = UpdateSpecWithExtra(widthSpec, layoutParams.LeftMargin + rect.Left, layoutParams.RightMargin + rect.Right);
		heightSpec = UpdateSpecWithExtra(heightSpec, layoutParams.TopMargin + rect.Top, layoutParams.BottomMargin + rect.Bottom);
		child.Measure(widthSpec, heightSpec);
	}

	private int UpdateSpecWithExtra(int spec, int startInset, int endInset)
	{
		if (startInset == 0 && endInset == 0)
		{
			return spec;
		}
		MeasureSpecMode mode = View.MeasureSpec.GetMode(spec);
		if (mode == MeasureSpecMode.AtMost || mode == MeasureSpecMode.Exactly)
		{
			return View.MeasureSpec.MakeMeasureSpec(View.MeasureSpec.GetSize(spec) - startInset - endInset, mode);
		}
		return spec;
	}
}
