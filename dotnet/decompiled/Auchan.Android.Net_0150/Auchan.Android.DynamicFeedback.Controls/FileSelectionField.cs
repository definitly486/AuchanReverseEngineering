using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DynamicFeedback;
using Microsoft.Maui.Storage;

namespace Auchan.Android.DynamicFeedback.Controls;

public class FileSelectionField : LinearLayoutWidgetBase
{
	private readonly DynamicFeedbackViewModel _dynamicFeedbackViewModel;

	private readonly ILifecycleOwner _viewLifecycleOwner;

	private readonly LinearLayout _FileResultsView;

	private readonly LinearLayout _filesInteractionGroup;

	public FileSelectionField(Context context, DynamicFeedbackViewModel dynamicFeedbackViewModel, ILifecycleOwner viewLifecycleOwner)
		: base(context)
	{
		_dynamicFeedbackViewModel = dynamicFeedbackViewModel;
		_viewLifecycleOwner = viewLifecycleOwner;
		View view = View.Inflate(context, 2131493154, this);
		AppCompatButton appCompatButton = view.RequireViewById<AppCompatButton>(2131298333);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131298199);
		_filesInteractionGroup = view.RequireViewById<LinearLayout>(2131297154);
		_FileResultsView = _filesInteractionGroup.RequireViewById<LinearLayout>(2131297561);
		_dynamicFeedbackViewModel.FileResults.CollectionChanged += ChangeFileResultsTrigger;
		_dynamicFeedbackViewModel.BindEvents(((View)appCompatButton).OnClick((Action)delegate
		{
			_dynamicFeedbackViewModel.UploadImage().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)linearLayout).OnClick((Action)delegate
		{
			_dynamicFeedbackViewModel.OnRemoveFileResultsClicked();
		})).AutoDisposeOnDestroy(_viewLifecycleOwner);
		ChangeFileResultsView(_dynamicFeedbackViewModel.FileResults);
	}

	private void ChangeFileResultsTrigger(object? sender, NotifyCollectionChangedEventArgs e)
	{
		ChangeFileResultsView(_dynamicFeedbackViewModel.FileResults);
	}

	private void ChangeFileResultsView(ObservableRangeCollection<FileResult> FileResults)
	{
		_FileResultsView.RemoveAllViews();
		int num = 0;
		foreach (FileResult file in FileResults)
		{
			RelativeLayout relativeLayout = new RelativeLayout(base.Context);
			ImageView imageView = new ImageView(base.Context);
			imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
			LayoutParams layoutParams = new LayoutParams(350, 350);
			layoutParams.SetMargins(0, 32, 18, 0);
			imageView.LayoutParameters = layoutParams;
			imageView.SetBackgroundResource(2131230910);
			imageView.ClipToOutline = true;
			imageView.SetImageBitmap(BitmapFactory.DecodeFile(file.FullPath));
			relativeLayout.AddView(imageView);
			ImageView imageView2 = new ImageView(base.Context);
			LayoutParams layoutParams2 = new LayoutParams(60, 60);
			layoutParams2.SetMargins(308, 0, 0, 350);
			imageView2.LayoutParameters = layoutParams2;
			imageView2.Id = num;
			imageView2.SetImageResource(2131231122);
			relativeLayout.AddView(imageView2);
			_FileResultsView.AddView(relativeLayout);
			num++;
			((View)imageView2).OnClick((Action)delegate
			{
				RemoveImage(file);
			}).AutoDisposeOnDestroy(_viewLifecycleOwner);
		}
		_filesInteractionGroup.Visibility = (_dynamicFeedbackViewModel.FileResults.Count != 0).ToVisibility();
	}

	private void RemoveImage(FileResult file)
	{
		_filesInteractionGroup.Visibility = (_dynamicFeedbackViewModel.FileResults.Count != 1).ToVisibility();
		if (_dynamicFeedbackViewModel.FileResults.Remove(file))
		{
			ChangeFileResultsView(_dynamicFeedbackViewModel.FileResults);
		}
	}
}
