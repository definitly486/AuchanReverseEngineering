using System;
using System.Reactive.Disposables;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews.Model;

namespace Auchan.Android.Reviews;

internal sealed class TriggerWordsControls
{
	private readonly View _container;

	private readonly View _touchInterceptor;

	private readonly TextView _title;

	private readonly RecyclerView _words;

	public TriggerWordsControls(View view)
	{
		_container = view.RequireViewById<View>(2131298769);
		_touchInterceptor = view.RequireViewById<View>(2131298736);
		_title = view.RequireViewById<TextView>(2131298648);
		_words = view.RequireViewById<RecyclerView>(2131298768);
	}

	public TriggerWordsControls(CachingViewHolder viewHolder)
	{
		_container = viewHolder.RequireCachedView<View>(2131298769);
		_touchInterceptor = viewHolder.RequireCachedView<View>(2131298736);
		_title = viewHolder.RequireCachedView<TextView>(2131298648);
		_words = viewHolder.RequireCachedView<RecyclerView>(2131298768);
	}

	public IDisposable Setup(Review review, Action onClick)
	{
		CompositeDisposable compositeDisposable = new CompositeDisposable();
		_title.Text = review.TitleOfTriggerWords;
		_title.Visibility = review.IsTitleOfTriggerWordsVisible.ToVisibility();
		_words.Visibility = review.IsTriggerWordsVisible.ToVisibility();
		_container.Visibility = review.IsTriggerWordsContainerVisible.ToVisibility();
		if (review.IsTriggerWordsVisible)
		{
			_words.SetAdapter(new ObservableRecyclerAdapter<TriggerWord, CachingViewHolder>
			{
				DataSource = review.TriggerWords,
				CellLayoutId = 2131493357,
				BindViewHolderDelegate = delegate(CachingViewHolder h, TriggerWord i, int _, CompositeDisposable d)
				{
					h.RequireCachedView<TextView>(2131296838).Text = i.Content;
				}
			});
		}
		else
		{
			_words.SetAdapter(null);
		}
		_touchInterceptor.OnClick((Action)delegate
		{
			onClick();
		}).AddTo(compositeDisposable);
		return compositeDisposable;
	}
}
