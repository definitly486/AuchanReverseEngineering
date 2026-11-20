using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Android.Utils;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Extensions;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Catalog;

[Register("auchan.ZoomableImageView")]
public class ZoomableImageView : ImageView
{
	private enum ZoomableImageState
	{
		Started,
		CanTransfer,
		Transfer,
		Failed,
		Finish
	}

	private class EndAnimationListener(Action action) : Java.Lang.Object(), Animator.IAnimatorListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnAnimationCancel(Animator animation)
		{
		}

		public void OnAnimationEnd(Animator animation)
		{
			action();
		}

		public void OnAnimationRepeat(Animator animation)
		{
		}

		public void OnAnimationStart(Animator animation)
		{
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

	private class UpdateListener(Action<float> action) : Java.Lang.Object(), ValueAnimator.IAnimatorUpdateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnAnimationUpdate(ValueAnimator animation)
		{
			float obj = (float)(animation.AnimatedValue ?? throw new InvalidOperationException());
			action(obj);
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

	private const int CornerRadius = 16;

	private readonly Path _pathBounds = new Path();

	private ZoomableImageState? _currentState;

	private ImageView? _originalImageView;

	private CachingViewHolder? _productItemViewHolder;

	private ProductItemViewModel? _productItemViewModel;

	private string? _zoomImageUrl;

	private PopupWindow? _popupWindow;

	private FrameLayout? _shadow;

	private FrameLayout? _newParent;

	private ViewGroup? _originalParent;

	private float _currentX;

	private float _currentY;

	private float _lastTouchX;

	private float _lastTouchY;

	private float _previousDistance = 1f;

	private float _scale = 1f;

	private (float x, float y)? _firstPointerCoordinate;

	private bool _zoomActivated;

	private bool _secondFingerUp;

	private bool _secondFingerDown;

	private bool _parentListenerForciblyStopped;

	private bool _popupListenerForciblyStopped;

	private bool _touched;

	private bool _finishAnimationStarted;

	protected ZoomableImageView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ZoomableImageView(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public ZoomableImageView(Context? context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public ZoomableImageView(Context? context, IAttributeSet? attrs)
		: base(context, attrs)
	{
	}

	public ZoomableImageView(Context? context)
		: base(context)
	{
	}

	public void Setup(ImageView originalImageView, CachingViewHolder productItemViewHolder, ProductItemViewModel productItemViewModel, ICollection<IDisposable> disposables, string? zoomImageUrl = null)
	{
		Elevation = 1f;
		_originalImageView = originalImageView;
		_zoomImageUrl = zoomImageUrl;
		_originalParent = (ViewGroup)_originalImageView.Parent;
		_originalParent.SetOnTouchListener(new ViewOnTouchListener(HandleParentTouch));
		_productItemViewHolder = productItemViewHolder;
		_productItemViewModel = productItemViewModel;
		_shadow = new FrameLayout(Application.Context);
		_shadow.SetBackgroundColor(new Color(ContextCompat.GetColor(Application.Context, 2131099712)));
		_shadow.LayoutParameters = new ViewGroup.LayoutParams(-1, -1);
		_popupWindow = new PopupWindow(-1, -1);
		_popupWindow.SetTouchInterceptor(new ViewOnTouchListener(HandlePopupWindowTouch));
		_newParent = new FrameLayout(Application.Context);
		_newParent.LayoutParameters = new ViewGroup.LayoutParams(-1, -1);
		Disposable.Create(delegate
		{
			_originalParent?.SetOnTouchListener(null);
			_originalParent = null;
			_originalImageView = null;
			_popupWindow?.SetTouchInterceptor(null);
			_popupWindow = null;
			_productItemViewHolder = null;
			_zoomImageUrl = null;
			_newParent = null;
			_shadow = null;
		}).AddTo(disposables);
	}

	private void CreateShadowLayout()
	{
		_originalParent.LayoutTransition = new LayoutTransition();
		LayoutTransition layoutTransition = _originalParent.LayoutTransition;
		_originalParent.LayoutTransition = null;
		_originalParent.RemoveView(this);
		_newParent.AddView(this);
		_originalParent.LayoutTransition = layoutTransition;
		if (_popupWindow.ContentView == null)
		{
			_newParent.AddView(_shadow);
			_newParent.SetClipChildren(clipChildren: false);
			_popupWindow.ContentView = _newParent;
		}
		_popupWindow?.ShowAtLocation(_originalImageView, GravityFlags.Fill, 0, 0);
	}

	private bool ZoomAndMove(MotionEvent? e)
	{
		if (_zoomActivated)
		{
			_originalImageView.Parent.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
		}
		switch (e.Action)
		{
		case MotionEventActions.Down:
		{
			float x = e.GetX();
			float y = e.GetY();
			_lastTouchX = x;
			_lastTouchY = y;
			break;
		}
		case MotionEventActions.Move:
		{
			if (!_zoomActivated)
			{
				break;
			}
			float num = e.GetX();
			float num2 = e.GetY();
			if (e.PointerCount == 2 || _currentState == ZoomableImageState.Transfer)
			{
				float num3 = 1f;
				if (_currentState == ZoomableImageState.Transfer)
				{
					if (_firstPointerCoordinate.HasValue)
					{
						num = (_firstPointerCoordinate.Value.x + num) / 2f;
						num2 = (_firstPointerCoordinate.Value.y + num2) / 2f;
						num3 = System.Math.Abs(_firstPointerCoordinate.Value.y - num2) + System.Math.Abs(_firstPointerCoordinate.Value.x - num);
					}
				}
				else
				{
					num = (e.GetX(0) + e.GetX(1)) / 2f;
					num2 = (e.GetY(0) + e.GetY(1)) / 2f;
					num3 = System.Math.Abs(e.GetY(0) - e.GetY(1)) + System.Math.Abs(e.GetX(0) - e.GetX(1));
				}
				if (!_secondFingerUp || num3 <= 250f)
				{
					_scale *= num3 / (((int)_previousDistance == 1) ? num3 : _previousDistance);
				}
				_scale = System.Math.Max(1f, System.Math.Min(_scale, 100f));
				_shadow.Alpha = ((_scale / 10f > 0.61f) ? 0.6f : (_scale / 10f));
				_previousDistance = num3;
				_secondFingerDown = true;
				if (num3 <= 200f)
				{
					break;
				}
				float num4 = num - _lastTouchX;
				float num5 = num2 - _lastTouchY;
				if (_secondFingerUp)
				{
					_secondFingerUp = false;
				}
				else
				{
					_currentX += num4;
					_currentY += num5;
				}
			}
			else
			{
				_secondFingerUp = true;
				float num6 = num - _lastTouchX;
				float num7 = num2 - _lastTouchY;
				if (_secondFingerDown)
				{
					_secondFingerDown = false;
				}
				else
				{
					_currentX += num6;
					_currentY += num7;
				}
			}
			Invalidate();
			_lastTouchX = num;
			_lastTouchY = num2;
			break;
		}
		case MotionEventActions.Up:
			if (!_zoomActivated && !_popupListenerForciblyStopped && !_parentListenerForciblyStopped)
			{
				_productItemViewHolder.ItemView.PerformClick();
			}
			else
			{
				ResetImage();
			}
			break;
		case MotionEventActions.Cancel:
			if (_zoomActivated)
			{
				_touched = false;
				ResetImage();
			}
			break;
		}
		return true;
	}

	private void ResetImage()
	{
		if (_currentState != ZoomableImageState.Transfer)
		{
			_finishAnimationStarted = true;
			ValueAnimator valueAnimator = new ValueAnimator();
			valueAnimator.SetFloatValues(_scale, 1f);
			valueAnimator.AddUpdateListener(new UpdateListener(ResetScale));
			ValueAnimator valueAnimator2 = new ValueAnimator();
			valueAnimator2.SetFloatValues(_currentX, 0f);
			valueAnimator2.AddUpdateListener(new UpdateListener(ResetX));
			ValueAnimator valueAnimator3 = new ValueAnimator();
			valueAnimator3.SetFloatValues(_currentY, 0f);
			valueAnimator3.AddUpdateListener(new UpdateListener(ResetY));
			AnimatorSet animatorSet = new AnimatorSet();
			animatorSet.PlayTogether(valueAnimator, valueAnimator2, valueAnimator3);
			animatorSet.SetDuration(400L);
			animatorSet.AddListener(new EndAnimationListener(DeactivateZoom));
			animatorSet.Start();
		}
	}

	private void ActivateZoom()
	{
		if (!_zoomActivated && _originalImageView.Drawable != null)
		{
			_zoomActivated = true;
			int num = 0;
			int identifier = Resources.GetIdentifier("status_bar_height", "dimen", "android");
			if (identifier > 0)
			{
				num = Resources.GetDimensionPixelSize(identifier);
			}
			int[] array = new int[2];
			GetLocationInWindow(array);
			CreateShadowLayout();
			ViewGroup.LayoutParams layoutParameters = LayoutParameters;
			layoutParameters.Width = _originalImageView.Width;
			layoutParameters.Height = _originalImageView.Height;
			LayoutParameters = layoutParameters;
			DisplayMetrics displayMetrics = Util.GetDisplayMetrics();
			this.FromUrlWithSize(_zoomImageUrl ?? _productItemViewModel.ImageUrl, displayMetrics.WidthPixels, displayMetrics.HeightPixels);
			base.Top = 0;
			int num2 = ((_originalImageView.LayoutParameters is ViewGroup.MarginLayoutParams marginLayoutParams) ? marginLayoutParams.TopMargin : base.Top);
			SetX(array[0]);
			SetY(array[1] - num - num2);
			_shadow.Alpha = 0f;
			_originalImageView.Animate()?.Alpha(0f).SetDuration(1L).Start();
		}
	}

	private void DeactivateZoom()
	{
		_zoomActivated = false;
		_previousDistance = 1f;
		_firstPointerCoordinate = null;
		_currentState = null;
		_originalImageView.Animate().Alpha(1f).SetDuration(100L)
			.WithEndAction(new Runnable(delegate
			{
				LayoutParameters = _originalImageView.LayoutParameters;
				_newParent.LayoutTransition = new LayoutTransition();
				LayoutTransition layoutTransition = _newParent.LayoutTransition;
				_newParent.LayoutTransition = null;
				_newParent.RemoveView(this);
				_originalParent.AddView(this);
				_newParent.LayoutTransition = layoutTransition;
				SetImageDrawable(null);
				TranslationX = 0f;
				TranslationY = 0f;
				_popupWindow?.Dismiss();
				_finishAnimationStarted = false;
			}))
			.Start();
	}

	private void ResetScale(float scale)
	{
		_scale = scale;
		_shadow.Alpha = ((_scale / 10f > 0.6f) ? _shadow.Alpha : (_scale / 10f - 0.1f));
		Invalidate();
	}

	private void ResetX(float x)
	{
		_currentX = x;
		Invalidate();
	}

	private void ResetY(float y)
	{
		_currentY = y;
		Invalidate();
	}

	protected override void OnDraw(Canvas canvas)
	{
		canvas.Save();
		canvas.Translate(_currentX, _currentY);
		canvas.Scale(_scale, _scale, (float)base.Width / 2f, (float)base.Height / 2f);
		if (Drawable != null)
		{
			Paint paint = new Paint
			{
				Color = Color.White,
				AntiAlias = true
			};
			paint.SetStyle(Paint.Style.Fill);
			_pathBounds.Reset();
			_pathBounds.AddRoundRect(new RectF(Drawable.Bounds.Left, Drawable.Bounds.Top, base.Width, base.Height), 16f, 16f, Path.Direction.Cw);
			_pathBounds.Close();
			canvas.ClipPath(_pathBounds);
			canvas.DrawRect(new RectF(Drawable.Bounds.Left, Drawable.Bounds.Top, base.Width, base.Height), paint);
		}
		base.OnDraw(canvas);
		canvas.Restore();
	}

	private bool HandleParentTouch(View? v, MotionEvent? e)
	{
		if (_finishAnimationStarted && e.Action != MotionEventActions.Up)
		{
			return true;
		}
		if (e.Action == MotionEventActions.Down)
		{
			_parentListenerForciblyStopped = false;
			_popupListenerForciblyStopped = false;
		}
		if (e.Action == MotionEventActions.Up)
		{
			if (_currentState == ZoomableImageState.Transfer)
			{
				_firstPointerCoordinate = null;
				_currentState = ZoomableImageState.Finish;
				return true;
			}
			if (_parentListenerForciblyStopped)
			{
				_parentListenerForciblyStopped = false;
				_touched = false;
				return true;
			}
			_touched = false;
		}
		if (_currentState == ZoomableImageState.Started && e.PointerCount < 2)
		{
			_currentState = ZoomableImageState.CanTransfer;
			_firstPointerCoordinate = (e.GetX(), e.GetY());
		}
		if (e.PointerCount == 2 && !_currentState.HasValue && !_touched)
		{
			bool num = (float)(base.Left + base.Width) > (e.GetX(0) + e.GetX(1)) / 2f && (float)base.Left < (e.GetX(0) + e.GetX(1)) / 2f;
			bool flag = (float)(base.Top + base.Height) > (e.GetY(0) + e.GetY(1)) / 2f && (float)base.Top < (e.GetY(0) + e.GetY(1)) / 2f;
			if (!num || !flag)
			{
				return true;
			}
			_currentState = ZoomableImageState.Started;
			_touched = true;
			ActivateZoom();
			base.Parent.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
		}
		if (_currentState == ZoomableImageState.CanTransfer)
		{
			_firstPointerCoordinate = (e.GetX(), e.GetY());
		}
		else if (_currentState == ZoomableImageState.Transfer)
		{
			_firstPointerCoordinate = (e.RawX, e.RawY);
			return true;
		}
		return ZoomAndMove(e);
	}

	private bool HandlePopupWindowTouch(View? v, MotionEvent? e)
	{
		if (_finishAnimationStarted)
		{
			return true;
		}
		if (e.Action == MotionEventActions.Down)
		{
			if (!_firstPointerCoordinate.HasValue)
			{
				return ForceStop();
			}
			_currentState = ZoomableImageState.Transfer;
		}
		else
		{
			if (e.Action == MotionEventActions.Up)
			{
				if (_popupListenerForciblyStopped)
				{
					if (_currentState == ZoomableImageState.Finish)
					{
						_touched = false;
					}
					_popupListenerForciblyStopped = false;
					return true;
				}
				if (_firstPointerCoordinate.HasValue && _currentState != ZoomableImageState.Finish)
				{
					_currentState = ZoomableImageState.CanTransfer;
					return true;
				}
				_touched = false;
			}
			if (e.PointerCount == 2)
			{
				if (_firstPointerCoordinate.HasValue)
				{
					return ForceStop();
				}
			}
			else if (e.PointerCount > 2)
			{
				_touched = false;
				return ForceStop();
			}
		}
		return ZoomAndMove(e);
	}

	private bool ForceStop()
	{
		_parentListenerForciblyStopped = true;
		_popupListenerForciblyStopped = true;
		_currentState = ZoomableImageState.Failed;
		ResetImage();
		return true;
	}
}
