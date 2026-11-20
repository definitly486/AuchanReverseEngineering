using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Common.Base;

namespace Auchan.Android.Base;

public abstract class BaseCustomView : LinearLayout
{
	protected abstract int LayoutId { get; }

	protected virtual int[] AttributeIds { get; }

	protected Fragment ParentFragment { get; private set; }

	protected View View { get; private set; }

	protected BaseCustomView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public BaseCustomView(Context context)
		: base(context)
	{
		DoInit(context);
	}

	public BaseCustomView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		DoInit(context, attrs);
	}

	public BaseCustomView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		DoInit(context, attrs);
	}

	public BaseCustomView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		DoInit(context, attrs);
	}

	private void DoInit(Context context, IAttributeSet attrs = null)
	{
		View = View.Inflate(context, LayoutId, this);
		if (attrs != null && AttributeIds != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, AttributeIds, 0, 0);
			LoadAttributes(typedArray);
			typedArray.Recycle();
		}
		if (!IsInEditMode)
		{
			Init(context, attrs);
		}
	}

	protected virtual void Init(Context context, IAttributeSet attrs = null)
	{
	}

	protected virtual void LoadAttributes(TypedArray attributes)
	{
	}

	public void SetParentFragment(Fragment parent)
	{
		ParentFragment = parent;
	}
}
public abstract class BaseCustomView<TElementViewModel> : BaseCustomView where TElementViewModel : ElementViewModel
{
	protected TElementViewModel ViewModel { get; private set; }

	protected ICollection<IDisposable> Disposables { get; private set; }

	protected BaseCustomView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public BaseCustomView(Context context)
		: base(context)
	{
	}

	public BaseCustomView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public BaseCustomView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public BaseCustomView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public virtual void Bind(TElementViewModel viewModel, ILifecycleOwner lifecycleOwner)
	{
		ViewModel = viewModel;
		Disposables = new CompositeDisposable();
		Disposables.AutoDisposeAllOnDestroy(lifecycleOwner);
		DoBind();
	}

	public virtual void Bind(TElementViewModel viewModel, ICollection<IDisposable> disposables)
	{
		ViewModel = viewModel;
		Disposables = disposables;
		DoBind();
	}

	protected abstract void DoBind();
}
