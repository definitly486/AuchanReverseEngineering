using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Controls;

[Register("auchan.controls.EndlessRecyclerView")]
public class EndlessRecyclerView : RecyclerView
{
	public const int DefaultStyle = -1;

	private EndlessScrollChangedListener _scrollChangedListener;

	private OnLoadMoreListener _onLoadMoreListener;

	private bool _hasNextPage;

	private LinearLayoutManager _linearLayoutManager;

	public bool HasNextPage
	{
		get
		{
			return _hasNextPage;
		}
		set
		{
			if (_hasNextPage != value)
			{
				_hasNextPage = value;
				if (value)
				{
					AddOnScrollListener(_scrollChangedListener);
				}
				else
				{
					RemoveOnScrollListener(_scrollChangedListener);
				}
			}
		}
	}

	public EndlessRecyclerView(Context context)
		: this(context, null)
	{
	}

	public EndlessRecyclerView(Context context, IAttributeSet attrs)
		: this(context, attrs, -1)
	{
	}

	public EndlessRecyclerView(Context context, IAttributeSet attrs, int defStyle)
		: base(context, attrs, defStyle)
	{
		Init(context, attrs, defStyle);
	}

	protected EndlessRecyclerView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public void SetOnLoadMoreListener(OnLoadMoreListener listener)
	{
		_onLoadMoreListener = listener;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (OperatingSystem.IsAndroidVersionAtLeast(23))
			{
				SetOnScrollChangeListener(null);
			}
			RemoveOnScrollListener(_scrollChangedListener);
			_onLoadMoreListener = null;
			_scrollChangedListener?.SetOnLoadMoreListener(null);
			_scrollChangedListener = null;
		}
		base.Dispose(disposing);
	}

	private void Init(Context context, IAttributeSet attrs, int defStyle)
	{
		_scrollChangedListener = new EndlessScrollChangedListener();
		_scrollChangedListener.SetOnLoadMoreListener(new OnLoadMoreListener(OnLoadMore));
		_linearLayoutManager = new LinearLayoutManager(context, 1, reverseLayout: false);
		SetLayoutManager(_linearLayoutManager);
	}

	private void OnLoadMore()
	{
		_onLoadMoreListener?.OnLoadMore();
	}
}
