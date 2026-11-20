using System;
using System.Collections.ObjectModel;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Reviews;
using Bumptech.Glide;
using Java.IO;
using Microsoft.Maui.Storage;

namespace Auchan.Android.Reviews;

[Register("auchan.PhotoSelectionView")]
public class PhotoSelectionView : LinearLayoutWidgetBase
{
	private LinearLayout _fileResultsView;

	private LinearLayout _filesInteractionGroup;

	private LinearLayout _removeFilesView;

	private Action _onRemoveAllItems = delegate
	{
	};

	protected PhotoSelectionView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PhotoSelectionView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public PhotoSelectionView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public PhotoSelectionView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public PhotoSelectionView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493169, this);
		_filesInteractionGroup = view.RequireViewById<LinearLayout>(2131297154);
		_fileResultsView = view.RequireViewById<LinearLayout>(2131297561);
		_removeFilesView = view.RequireViewById<LinearLayout>(2131298199);
		_removeFilesView.Click += delegate
		{
			_onRemoveAllItems();
		};
	}

	public void ChangeFileResultsView(ObservableRangeCollection<FileResult> fileResults, ObservableRangeCollection<AddReviewViewModel.ImageLoadFailedStubItem> imageLoadFailedStubs, Action<FileResult> onRemoveItem, Action<Guid> onRemoveStubItem, Action onRemoveAllItems, Action<FileResult> onImagePreviewLoadFailed, ILifecycleOwner viewLifecycleOwner)
	{
		_onRemoveAllItems = onRemoveAllItems;
		_fileResultsView.RemoveAllViews();
		int num = Converter.DpToPx(100f);
		int top = Converter.DpToPx(8f);
		int right = Converter.DpToPx(16f);
		int num2 = Converter.DpToPx(20f);
		int num3 = Converter.DpToPx(24f);
		int num4 = Converter.DpToPx(16f);
		int num5 = Converter.DpToPx(1f);
		int num6 = 0;
		foreach (FileResult file in fileResults)
		{
			RelativeLayout relativeLayout = new RelativeLayout(base.Context);
			ImageView imageView = new ImageView(base.Context);
			imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
			int num7 = ((num6 == 0) ? num2 : 0);
			LayoutParams layoutParams = new LayoutParams(num, num);
			layoutParams.SetMargins(num7, top, right, 0);
			imageView.LayoutParameters = layoutParams;
			imageView.SetBackgroundResource(2131230910);
			imageView.ClipToOutline = true;
			relativeLayout.AddView(imageView);
			ImageView imageView2 = new ImageView(base.Context);
			LayoutParams layoutParams2 = new LayoutParams(num3, num3);
			layoutParams2.SetMargins(num7 + num - num4, 0, 0, 0);
			imageView2.LayoutParameters = layoutParams2;
			imageView2.Id = num6;
			imageView2.SetImageResource(2131231126);
			relativeLayout.AddView(imageView2);
			_fileResultsView.AddView(relativeLayout);
			Glide.With(base.Context).Load(new File(file.FullPath)).Listener(new GlideLoadingListener(delegate
			{
			}, delegate
			{
				onImagePreviewLoadFailed(file);
			}))
				.Into(imageView);
			num6++;
			((View)imageView2).OnClick((Action)delegate
			{
				onRemoveItem(file);
			}).AutoDisposeOnDestroy(viewLifecycleOwner);
		}
		foreach (AddReviewViewModel.ImageLoadFailedStubItem failedStubItem in imageLoadFailedStubs)
		{
			RelativeLayout relativeLayout2 = new RelativeLayout(base.Context);
			int num8 = ((num6 == 0) ? num2 : 0);
			LayoutParams layoutParams3 = new LayoutParams(num, num);
			layoutParams3.SetMargins(num8, top, right, 0);
			FrameLayout frameLayout = new FrameLayout(base.Context);
			frameLayout.LayoutParameters = layoutParams3;
			frameLayout.SetBackgroundResource(2131230905);
			frameLayout.ClipToOutline = true;
			ImageView imageView3 = new ImageView(base.Context);
			imageView3.SetScaleType(ImageView.ScaleType.CenterCrop);
			FrameLayout.LayoutParams layoutParams4 = new FrameLayout.LayoutParams(-1, -1);
			layoutParams4.SetMargins(num5, num5, num5, num5);
			imageView3.LayoutParameters = layoutParams4;
			imageView3.SetImageResource(2131689489);
			imageView3.SetBackgroundResource(2131230917);
			imageView3.ClipToOutline = true;
			frameLayout.AddView(imageView3);
			relativeLayout2.AddView(frameLayout);
			ImageView imageView4 = new ImageView(base.Context);
			LayoutParams layoutParams5 = new LayoutParams(num3, num3);
			layoutParams5.SetMargins(num8 + num - num4, 0, 0, 0);
			imageView4.LayoutParameters = layoutParams5;
			imageView4.Id = num6;
			imageView4.SetImageResource(2131231126);
			relativeLayout2.AddView(imageView4);
			_fileResultsView.AddView(relativeLayout2);
			num6++;
			((View)imageView4).OnClick((Action)delegate
			{
				onRemoveStubItem(failedStubItem.Id);
			}).AutoDisposeOnDestroy(viewLifecycleOwner);
		}
		int num9 = fileResults.Count + imageLoadFailedStubs.Count;
		_removeFilesView.Visibility = (num9 > 1).ToVisibility();
		_filesInteractionGroup.Visibility = (num9 != 0).ToVisibility();
	}
}
