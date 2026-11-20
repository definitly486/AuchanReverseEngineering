using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Android.Runtime;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Base;

public class CachingViewHolder : RecyclerView.ViewHolder
{
	private readonly Dictionary<int, View> _cachedSubViews = new Dictionary<int, View>();

	public CachingViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public CachingViewHolder(View itemView)
		: base(itemView)
	{
	}

	public TView? FindCachedView<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] TView>(int viewId) where TView : notnull, View
	{
		if (_cachedSubViews.ContainsKey(viewId))
		{
			return (TView)_cachedSubViews[viewId];
		}
		TView val = base.ItemView.FindViewById<TView>(viewId);
		if (val != null)
		{
			_cachedSubViews.Add(viewId, val);
		}
		return val;
	}

	public View? FindCachedView(int viewId)
	{
		return FindCachedView<View>(viewId);
	}
}
