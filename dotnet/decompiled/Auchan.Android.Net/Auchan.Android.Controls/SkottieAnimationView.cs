using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using DryIoc;
using Java.Interop;
using Microsoft.Maui.ApplicationModel;
using SkiaSharp;
using SkiaSharp.Resources;
using SkiaSharp.Skottie;
using SkiaSharp.Views.Android;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

public sealed class SkottieAnimationView : FrameLayout
{
	private delegate SKRect GetDrawRectDelegate(Animation animation, float canvasScale, SKSizeI size);

	private sealed class GLAnimationView : SKGLTextureView, IAnimationView, IDisposable, ILifecycleEventObserver, ILifecycleObserver, IJavaObject, IJavaPeerable
	{
		private readonly SkottieAnimationView _parent;

		private readonly FragmentActivity? _parentActivity;

		public View AsView => this;

		public GLAnimationView(SkottieAnimationView parent, Context? context)
			: base(context)
		{
			_parent = parent;
			SetOpaque(opaque: false);
			_parentActivity = Platform.CurrentActivity as FragmentActivity;
			if (_parentActivity != null)
			{
				_parentActivity.Lifecycle.AddObserver(this);
			}
		}

		public void StartAnimation()
		{
			Resume();
		}

		protected override void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
		{
			base.OnPaintSurface(e);
			_parent.Render(e.Surface.Canvas, e.Info.Size);
		}

		public void SetSize(SKSizeI size)
		{
			ViewGroup.LayoutParams layoutParams = LayoutParameters ?? new ViewGroup.LayoutParams(size.Width, size.Height);
			layoutParams.Width = size.Width;
			layoutParams.Height = size.Height;
			LayoutParameters = layoutParams;
		}

		public void Pause()
		{
			Task.Run((Action)base.OnPause);
		}

		public void Resume()
		{
			Task.Run((Action)base.OnResume);
		}

		public void OnStateChanged(ILifecycleOwner source, Lifecycle.Event e)
		{
			if (e == Lifecycle.Event.OnPause)
			{
				OnPause();
			}
			else if (e == Lifecycle.Event.OnResume)
			{
				OnResume();
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			_parentActivity?.Lifecycle.RemoveObserver(this);
		}
	}

	private sealed class CanvasAnimationView : SKCanvasView, IAnimationView, IDisposable
	{
		private TaskCompletionSource<object?> _visibilityTaskSource = new TaskCompletionSource<object>();

		private bool _visible;

		private readonly SkottieAnimationView _parent;

		private volatile int _requestId;

		private bool _started;

		private volatile bool _disposed;

		public View AsView => this;

		public CanvasAnimationView(SkottieAnimationView parent, Context? context)
			: base(context)
		{
			_parent = parent;
		}

		public void StartAnimation()
		{
			_requestId++;
			_started = true;
			Task.Run(delegate
			{
				DoAnimateAsync().SafeFireAndForget((Action<Exception>)null, false);
			});
		}

		public void Resume()
		{
			if (!_started)
			{
				StartAnimation();
			}
			_visible = true;
			Interlocked.Exchange(ref _visibilityTaskSource, new TaskCompletionSource<object>()).TrySetResult(null);
		}

		public void Pause()
		{
			_visible = false;
		}

		private async Task DoAnimateAsync()
		{
			_ = 1;
			try
			{
				int rid = _requestId;
				while (rid == _requestId && !_disposed)
				{
					await WaitForVisibilityAsync();
					if (_disposed)
					{
						break;
					}
					PostInvalidate();
					await Task.Delay(ONE_SIXTIETH_OF_SECOND);
				}
			}
			catch (Exception ex)
			{
				DevAnalytics.Report("SkottieAnimationView.DoAnimateAsync", ex);
			}
		}

		private async Task WaitForVisibilityAsync()
		{
			if (!_visible)
			{
				await _visibilityTaskSource.Task;
			}
		}

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			base.OnPaintSurface(e);
			_parent.Render(e.Surface.Canvas, e.Info.Size);
		}

		public void SetSize(SKSizeI size)
		{
			if (!_disposed)
			{
				ViewGroup.LayoutParams layoutParams = LayoutParameters ?? new ViewGroup.LayoutParams(size.Width, size.Height);
				layoutParams.Width = size.Width;
				layoutParams.Height = size.Height;
				LayoutParameters = layoutParams;
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			_disposed = true;
		}
	}

	private interface IAnimationView : IDisposable
	{
		View AsView { get; }

		void StartAnimation();

		void Pause();

		void Resume();

		void SetSize(SKSizeI size);
	}

	private enum State
	{
		Stop,
		Play,
		Pause
	}

	private enum ScaleType
	{
		Matrix,
		FitXY,
		FitStart,
		FitCenter,
		FitEnd,
		Center,
		CenterCrop,
		CenterInside,
		Length
	}

	private static TimeSpan ONE_SIXTIETH_OF_SECOND = TimeSpan.FromMilliseconds(16L);

	private volatile IAnimationView? _animationView;

	private readonly ViewGroup.LayoutParams _childLayoutParams;

	private bool _loop;

	private bool _autoplay;

	private bool _hardwareAcceleration;

	private volatile Animation? _animation;

	private DateTime _startTime;

	private TimeSpan _animationDuration;

	private bool _visible;

	private State _state;

	private ScaleType _scaleType;

	private GetDrawRectDelegate _getDrawRectDelegate;

	public double Progress { get; set; }

	public Animation? Animation => _animation;

	private static bool IsProbablyRunningOnEmulator
	{
		get
		{
			if (Build.Manufacturer == "Google" && Build.Brand == "google")
			{
				string? fingerprint = Build.Fingerprint;
				if (fingerprint != null && fingerprint.StartsWith("google/sdk_gphone_"))
				{
					string? fingerprint2 = Build.Fingerprint;
					if (fingerprint2 != null && fingerprint2.EndsWith(":user/release-keys"))
					{
						string? product = Build.Product;
						if (product != null && product.StartsWith("sdk_gphone_"))
						{
							string? model = Build.Model;
							if (model != null && model.StartsWith("sdk_gphone_"))
							{
								goto IL_0220;
							}
						}
					}
				}
				string? fingerprint3 = Build.Fingerprint;
				if (fingerprint3 != null && fingerprint3.StartsWith("google/sdk_gphone64_"))
				{
					string? fingerprint4 = Build.Fingerprint;
					if (fingerprint4 == null || !fingerprint4.EndsWith(":userdebug/dev-keys"))
					{
						string? fingerprint5 = Build.Fingerprint;
						if (fingerprint5 == null || !fingerprint5.EndsWith(":user/release-keys"))
						{
							goto IL_0106;
						}
					}
					string? product2 = Build.Product;
					if (product2 != null && product2.StartsWith("sdk_gphone64_"))
					{
						string? model2 = Build.Model;
						if (model2 != null && model2.StartsWith("sdk_gphone64_"))
						{
							goto IL_0220;
						}
					}
				}
			}
			goto IL_0106;
			IL_0106:
			string? fingerprint6 = Build.Fingerprint;
			if (fingerprint6 == null || !fingerprint6.StartsWith("generic"))
			{
				string? fingerprint7 = Build.Fingerprint;
				if (fingerprint7 == null || !fingerprint7.StartsWith("unknown"))
				{
					string? model3 = Build.Model;
					if (model3 == null || !model3.Contains("google_sdk"))
					{
						string? model4 = Build.Model;
						if (model4 == null || !model4.Contains("Emulator"))
						{
							string? model5 = Build.Model;
							if ((model5 == null || !model5.Contains("Android SDK built for x86")) && (!("QC_Reference_Phone" == Build.Board) || string.Equals("Xiaomi", Build.Manufacturer, StringComparison.InvariantCultureIgnoreCase)))
							{
								string? manufacturer = Build.Manufacturer;
								if (manufacturer == null || !manufacturer.Contains("Genymotion"))
								{
									string? host = Build.Host;
									if (host == null || !host.StartsWith("Build"))
									{
										string? brand = Build.Brand;
										if (brand != null && brand.StartsWith("generic"))
										{
											string? device = Build.Device;
											if (device != null && device.StartsWith("generic"))
											{
												goto IL_0220;
											}
										}
										return Build.Product == "google_sdk";
									}
								}
							}
						}
					}
				}
			}
			goto IL_0220;
			IL_0220:
			return true;
		}
	}

	public SkottieAnimationView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
		ViewGroup.LayoutParams childLayoutParams = new ViewGroup.LayoutParams(0, 0);
		GetDrawRectDelegate getDrawRectDelegate = GetFitCenter;
		_childLayoutParams = childLayoutParams;
		_getDrawRectDelegate = getDrawRectDelegate;
	}

	public SkottieAnimationView(Context context)
		: base(context)
	{
		(_childLayoutParams, _getDrawRectDelegate) = Init(this, context, null);
	}

	public SkottieAnimationView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		(_childLayoutParams, _getDrawRectDelegate) = Init(this, context, attrs);
	}

	public SkottieAnimationView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		(_childLayoutParams, _getDrawRectDelegate) = Init(this, context, attrs);
	}

	private SkottieAnimationView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		(_childLayoutParams, _getDrawRectDelegate) = Init(this, context, attrs);
	}

	private static (ViewGroup.LayoutParams, GetDrawRectDelegate) Init(SkottieAnimationView @this, Context context, IAttributeSet? attrs)
	{
		string text = null;
		if (attrs != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.SkottieAnimationView);
			@this._loop = typedArray.GetBoolean(4, defValue: false);
			@this._autoplay = typedArray.GetBoolean(1, defValue: false);
			@this._hardwareAcceleration = typedArray.GetBoolean(2, defValue: true);
			if (@this._hardwareAcceleration && IsProbablyRunningOnEmulator)
			{
				@this._hardwareAcceleration = false;
			}
			text = typedArray.GetString(3);
			int num = typedArray.GetInt(0, -1);
			if (num >= 0 && num < 8)
			{
				@this._scaleType = (ScaleType)num;
			}
			typedArray.Recycle();
		}
		ViewGroup.LayoutParams layoutParams = new ViewGroup.LayoutParams(-1, -1);
		if (@this.IsInEditMode)
		{
			TextView child = new TextView(context)
			{
				Text = $"{"SkottieAnimationView"} in design mode, loop: {@this._loop}, autoplay, {@this._autoplay}, hwa {@this._hardwareAcceleration}, fileName [{text}]",
				LayoutParameters = layoutParams
			};
			@this.AddView(child);
			return (layoutParams, @this.ScaleTypeToDelegate());
		}
		if (!string.IsNullOrEmpty(text))
		{
			using Stream stream = context.Assets?.Open(text);
			if (stream != null)
			{
				@this.SetAnimation(stream);
				if (@this._autoplay)
				{
					@this.Play();
				}
			}
		}
		return (layoutParams, @this.ScaleTypeToDelegate());
	}

	private void CreateGLAnimationView(Context context, ViewGroup.LayoutParams lp)
	{
		GLAnimationView gLAnimationView = new GLAnimationView(this, context);
		gLAnimationView.LayoutParameters = lp;
		AddView(gLAnimationView);
		_animationView = gLAnimationView;
	}

	private void CreateCanvasAnimationView(Context context, ViewGroup.LayoutParams lp)
	{
		CanvasAnimationView canvasAnimationView = new CanvasAnimationView(this, context);
		canvasAnimationView.LayoutParameters = lp;
		AddView(canvasAnimationView);
		_animationView = canvasAnimationView;
	}

	private void CreateAnimationView()
	{
		if (_hardwareAcceleration)
		{
			CreateGLAnimationView(base.Context, _childLayoutParams);
		}
		else
		{
			CreateCanvasAnimationView(base.Context, _childLayoutParams);
		}
	}

	private void RemoveAnimationView()
	{
		IAnimationView animationView = Interlocked.Exchange(ref _animationView, null);
		RemoveView(animationView as View);
		animationView?.Dispose();
	}

	public void FromUrl(string url, string cacheKey = "")
	{
		FromUrlAsync(url, cacheKey).SafeFireAndForget((Action<Exception>)null, false);
	}

	public async Task FromUrlAsync(string url, string cacheKey)
	{
		ILottieFetcher lottieFetcher = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ILottieFetcher>();
		Stream stream = await Task.Run(() => lottieFetcher.FetchStreamAsync(url));
		if (stream != null)
		{
			SetAnimation(stream);
			if (_autoplay)
			{
				Play();
			}
		}
	}

	private void SetAnimation(Stream data)
	{
		AnimationBuilder animationBuilder = SkiaSharp.Skottie.Animation.CreateBuilder();
		CachingResourceProvider resourceProvider = new CachingResourceProvider(new DataUriResourceProvider());
		animationBuilder.SetResourceProvider(resourceProvider);
		Animation animation = animationBuilder.Build(data);
		if (animation != null)
		{
			_animationDuration = animation.Duration;
			_animationView?.SetSize(GetAnimationViewSize(animation));
			_animation = animation;
			if (_visible && _state == State.Play)
			{
				_startTime = DateTime.UtcNow;
				_animationView?.Resume();
			}
		}
	}

	protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
	{
		base.OnSizeChanged(w, h, oldw, oldh);
		UpdateAnimationLayoutAsync().SafeFireAndForget((Action<Exception>)null, false);
		async Task UpdateAnimationLayoutAsync()
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			if (_animation != null)
			{
				_animationView?.SetSize(GetAnimationViewSize(_animation));
				_animationView?.AsView.Invalidate();
				_animationView?.AsView.RequestLayout();
			}
		}
	}

	private SKSizeI GetAnimationViewSize(Animation animation)
	{
		int width = CalculateLayoutDimension(LayoutParameters?.Width, base.Width, Converter.DpToPx(animation.Size.Width));
		int height = CalculateLayoutDimension(LayoutParameters?.Height, base.Height, Converter.DpToPx(animation.Size.Height));
		return new SKSizeI(width, height);
		static int CalculateLayoutDimension(int? lp, int dim, int @default)
		{
			if (lp == 0)
			{
				return dim;
			}
			if (lp == -1)
			{
				return -1;
			}
			if (lp == -2)
			{
				return @default;
			}
			return lp ?? @default;
		}
	}

	public void Play()
	{
		switch (_state)
		{
		case State.Play:
			return;
		case State.Stop:
			_startTime = DateTime.UtcNow;
			break;
		}
		_state = State.Play;
		if (_visible && _animation != null)
		{
			_animationView?.Resume();
		}
	}

	public void Pause()
	{
		if (_state != State.Pause && _state == State.Play)
		{
			_state = State.Pause;
			_animationView?.Pause();
		}
	}

	public void Stop()
	{
		if (_state != State.Stop)
		{
			_state = State.Stop;
			_animationView?.Pause();
		}
	}

	private void Render(SKCanvas canvas, SKSizeI size)
	{
		Animation animation = _animation;
		if (animation == null)
		{
			return;
		}
		float num = (float)size.Width / (float)base.Width;
		SKRect dst = _getDrawRectDelegate(animation, num, size);
		canvas.Clear(SKColors.Transparent);
		canvas.Scale(num);
		if (_state == State.Pause || _state == State.Stop)
		{
			animation.Render(canvas, dst);
		}
		else if (_state == State.Play)
		{
			TimeSpan timeSpan = DateTime.UtcNow - _startTime;
			TimeSpan timeSpan2 = TimeSpan.FromTicks(timeSpan.Ticks % _animationDuration.Ticks);
			bool flag = timeSpan.Ticks / _animationDuration.Ticks > 0 && !_loop;
			animation.SeekFrameTime(flag ? animation.Duration : timeSpan2);
			animation.Render(canvas, dst);
			if (flag)
			{
				Pause();
			}
		}
	}

	private SKRect GetFitCenter(Animation animation, float canvasScale, SKSizeI size)
	{
		SKSize sKSize = new SKSize((float)size.Width / canvasScale, (float)size.Height / canvasScale);
		float num = Math.Min(sKSize.Width / animation.Size.Width, sKSize.Height / animation.Size.Height);
		SKSize size2 = new SKSize(animation.Size.Width * num, animation.Size.Height * num);
		return SKRect.Create(new SKPoint((float)base.Width / 2f - size2.Width / 2f, (float)base.Height / 2f - size2.Height / 2f), size2);
	}

	private SKRect GetCenterCrop(Animation animation, float canvasScale, SKSizeI size)
	{
		SKSize sKSize = new SKSize((float)size.Width / canvasScale, (float)size.Height / canvasScale);
		float num = Math.Max(sKSize.Width / animation.Size.Width, sKSize.Height / animation.Size.Height);
		SKSize size2 = new SKSize(animation.Size.Width * num, animation.Size.Height * num);
		return SKRect.Create(new SKPoint((float)base.Width / 2f - size2.Width / 2f, (float)base.Height / 2f - size2.Height / 2f), size2);
	}

	private GetDrawRectDelegate ScaleTypeToDelegate()
	{
		if (_scaleType == ScaleType.CenterCrop)
		{
			return GetCenterCrop;
		}
		return GetFitCenter;
	}

	protected override void OnVisibilityChanged(View changedView, ViewStates visibility)
	{
		base.OnVisibilityChanged(changedView, visibility);
		OnVisibilityChanged(visibility);
	}

	protected override void OnAttachedToWindow()
	{
		base.OnAttachedToWindow();
		OnVisibilityChanged(Visibility);
	}

	protected override void OnDetachedFromWindow()
	{
		base.OnDetachedFromWindow();
		OnVisibilityChanged(ViewStates.Gone);
	}

	private void OnVisibilityChanged(ViewStates visibility)
	{
		if (visibility == ViewStates.Visible && !_visible)
		{
			_visible = true;
			CreateAnimationView();
			if (_state == State.Play)
			{
				_animationView?.Resume();
			}
		}
		else if (visibility != ViewStates.Visible && _visible)
		{
			_visible = false;
			_animationView?.Pause();
			RemoveAnimationView();
		}
	}
}
