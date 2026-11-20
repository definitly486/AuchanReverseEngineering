using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.ViewPager2.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Auchan.Common.Controls.ZoomableImageSlider;
using Auchan.Common.Extensions;
using EBind;
using ImageViews.Photo;
using Java.Interop;
using Java.Lang;
using Me.Relex.CircleIndicatorLib;

namespace Auchan.Android.Controls.ZoomableImageSlider;

internal class ZoomableImageSliderFragment : BaseBottomSheetDialogFragment<ZoomableImageSliderViewModel>
{
	private class PhotoViewDoubleTapListener : Java.Lang.Object, GestureDetector.IOnDoubleTapListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private readonly TaskQueue _setScaleQueue = new TaskQueue();

		public required PhotoView PhotoView { get; set; }

		public bool OnDoubleTap(MotionEvent e)
		{
			return false;
		}

		public bool OnDoubleTapEvent(MotionEvent e)
		{
			try
			{
				float scale = PhotoView.Scale;
				float x = e.GetX();
				float y = e.GetY();
				if (scale < PhotoView.MaximumScale)
				{
					_setScaleQueue.Enqueue(() => ChangeScaleAfterDelay(PhotoView.MaximumScale, x, y));
				}
				else
				{
					_setScaleQueue.Enqueue(() => ChangeScaleAfterDelay(PhotoView.MinimumScale, x, y));
				}
			}
			catch (System.Exception)
			{
			}
			return false;
		}

		public bool OnSingleTapConfirmed(MotionEvent e)
		{
			return true;
		}

		private async Task ChangeScaleAfterDelay(float targetScale, float x, float y)
		{
			await Task.Delay(100);
			PhotoView.SetScale(targetScale, x, y, animate: true);
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}
	}

	public readonly List<ImageItemViewModel> ImageItemViewModels = new List<ImageItemViewModel>();

	public int CurrentIndex;

	protected override int LayoutId => 2131493126;

	public override int Theme => 2131951914;

	protected override bool FullScreen => true;

	public ZoomableImageSliderFragment(Func<Fragment, ZoomableImageSliderViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		ViewPager2 viewPager = view.RequireViewById<ViewPager2>(2131298382);
		CircleIndicator bannersIndicator = view.RequireViewById<CircleIndicator>(2131296781);
		EndlessRecyclerAdapter<ImageItemViewModel> adapter = new EndlessRecyclerAdapter<ImageItemViewModel>
		{
			MinItemsForEndless = 30,
			CellLayoutId = 2131493365,
			BindViewHolderDelegate = OnBindBanner
		};
		viewPager.OffscreenPageLimit = 1;
		viewPager.SetPageTransformer(new MarginPageTransformer(Converter.DpToPx(10f)));
		viewPager.Adapter = adapter;
		adapter.DataSource = ImageItemViewModels;
		if (ImageItemViewModels.Count > 1)
		{
			bannersIndicator.CreateIndicators(ImageItemViewModels.Count, 0);
		}
		viewPager.RegisterOnPageChangeCallback(new ViewPager2OnPageChangeCallback(delegate(int position)
		{
			int position2 = adapter.RealPosition(position);
			bannersIndicator.AnimatePageSelected(position2);
		}));
		viewPager.SetCurrentItem(CurrentIndex, smoothScroll: false);
		bannersIndicator.AnimatePageSelected(CurrentIndex);
		imageView.OnClick(Dismiss).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnBindBanner(CachingViewHolder holder, ImageItemViewModel model, int position, CompositeDisposable disposable)
	{
		PhotoView image = holder.RequireCachedView<PhotoView>(2131297319);
		image.FromUrlWithSize(model.ImageUrl, base.Resources.DisplayMetrics.WidthPixels, base.Resources.DisplayMetrics.HeightPixels);
		PhotoViewDoubleTapListener onDoubleTapListener = new PhotoViewDoubleTapListener
		{
			PhotoView = image
		};
		image.SetOnDoubleTapListener(onDoubleTapListener);
		image.Attacher.ViewDrag += new DisposableDelegate<EventHandler<ViewDragEventArgs>>(delegate(object? s, ViewDragEventArgs args)
		{
			float deltaX = args.DeltaX;
			float deltaY = args.DeltaY;
			if (!(image.Scale > 1f) && deltaY > System.Math.Abs(deltaX))
			{
				Dismiss();
			}
		}, delegate(EventHandler<ViewDragEventArgs> h)
		{
			image.Attacher.ViewDrag -= h;
		}).AddTo(disposable);
	}
}
