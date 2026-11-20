using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews.Model;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Reviews;

[Register("auchan.ReviewCommentView")]
public class ReviewCommentView : LinearLayoutWidgetBase
{
	private TextView _nameText;

	private TextView _commentText;

	private TextView _titleText;

	private TextView _dateText;

	private TextView _showAllButton;

	public string guid = Guid.NewGuid().ToString();

	protected ReviewCommentView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ReviewCommentView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public ReviewCommentView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public ReviewCommentView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public ReviewCommentView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493185, this);
		_nameText = view.RequireViewById<TextView>(2131297635);
		_titleText = view.RequireViewById<TextView>(2131298649);
		_commentText = view.RequireViewById<TextView>(2131296822);
		_dateText = view.RequireViewById<TextView>(2131296890);
		_showAllButton = view.RequireViewById<TextView>(2131298365);
	}

	protected override void OnLayout(bool changed, int l, int t, int r, int b)
	{
		base.OnLayout(changed, l, t, r, b);
		int num = Math.Min(_commentText.MaxLines, _commentText.LineCount);
		int num2 = Math.Min(_commentText.Layout.GetLineEnd(num - 1), _commentText.Text.Length - _commentText.Layout.GetEllipsisCount(num - 1));
		ViewStates visibility = _showAllButton.Visibility;
		_showAllButton.Visibility = ((num2 >= _commentText.Text.Length) ? ViewStates.Gone : ViewStates.Visible);
		if (visibility != _showAllButton.Visibility)
		{
			MainThread.InvokeOnMainThreadAsync(async delegate
			{
				await Task.Delay(10);
				RequestLayout();
			});
		}
	}

	public void UpdateWithComment(ReviewComment comment, string title, CompositeDisposable disposable)
	{
		_titleText.Text = title;
		_nameText.Text = comment.Author;
		_commentText.Text = comment.Text;
		_commentText.SetMaxLines(5);
		_dateText.Text = comment.CreatedAt.GetValueOrDefault().ToLongDateWithFullMonth();
		_showAllButton.Text = "Читать полностью";
		((View)_showAllButton).OnClick((Action)delegate
		{
			_showAllButton.Visibility = ViewStates.Gone;
			_commentText.SetMaxLines(int.MaxValue);
			RequestLayout();
		}).AddTo(disposable);
	}
}
