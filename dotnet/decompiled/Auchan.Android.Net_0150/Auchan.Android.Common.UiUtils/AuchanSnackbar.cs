using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.Animation;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Extensions;
using Auchan.Android.Helpers;
using Auchan.Android.Utils;
using Auchan.Common.Common;
using Google.Android.Material.Card;
using Google.Android.Material.Snackbar;
using Java.Interop;
using Java.Lang;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Common.UiUtils;

public sealed class AuchanSnackbar : BaseTransientBottomBar
{
	private sealed class Callback : BaseCallback
	{
		private readonly PopupWindow _popupWindow;

		private readonly string _message;

		private readonly SnackbarStyle _style;

		private readonly DroidInfoMessageService _droidInfoMessageService;

		private readonly DateTime _shownAt = DateTime.UtcNow;

		public Callback(PopupWindow popupWindow, string message, SnackbarStyle style, DroidInfoMessageService droidInfoMessageService)
		{
			_popupWindow = popupWindow;
			_message = message;
			_style = style;
			_droidInfoMessageService = droidInfoMessageService;
		}

		public override async void OnDismissed(Java.Lang.Object? transientBottomBar, int e)
		{
			base.OnDismissed(transientBottomBar, e);
			TimeSpan moreTimeToDisplay = default(TimeSpan);
			if (transientBottomBar is AuchanSnackbar auchanSnackbar)
			{
				auchanSnackbar.RemoveCallback(this);
				TimeSpan timeSpan = DateTime.UtcNow - _shownAt;
				moreTimeToDisplay = auchanSnackbar._duration - timeSpan;
			}
			_popupWindow.Dismiss();
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			if (moreTimeToDisplay > TimeSpan.FromSeconds(1L))
			{
				_droidInfoMessageService.ShowSnackbar(_message, moreTimeToDisplay, _style);
			}
		}
	}

	private sealed class ContentViewCallback : Java.Lang.Object, IContentViewCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private readonly Controls _controls;

		public ContentViewCallback(Controls controls)
		{
			_controls = controls;
		}

		public void AnimateContentIn(int p0, int p1)
		{
			ObjectAnimator objectAnimator = ObjectAnimator.OfFloat(_controls.IconImage, global::Android.Views.View.ScaleXs, 0f, 1f);
			ObjectAnimator objectAnimator2 = ObjectAnimator.OfFloat(_controls.IconImage, global::Android.Views.View.ScaleYs, 0f, 1f);
			AnimatorSet animatorSet = new AnimatorSet();
			animatorSet.PlayTogether(objectAnimator, objectAnimator2);
			animatorSet.SetInterpolator(new OvershootInterpolator());
			animatorSet.SetDuration(450L);
			animatorSet.StartDelay = 100L;
			animatorSet.Start();
		}

		public void AnimateContentOut(int p0, int p1)
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

	private sealed class Controls(View view)
	{
		public View View => view;

		public MaterialCardView CardView { get; } = view.RequireViewById<MaterialCardView>(2131298403);

		public TextView MessageLabel { get; } = view.RequireViewById<TextView>(2131297571);

		public ImageView IconImage { get; } = view.RequireViewById<ImageView>(2131297308);
	}

	private TimeSpan _duration;

	private AuchanSnackbar(ViewGroup parent, Controls controls)
		: base(parent, controls.View, new ContentViewCallback(controls))
	{
		View.SetBackgroundColor(new Color(ContextCompat.GetColor(parent.Context, 17170445)));
		View.SetPadding(Util.ConvertDpToPixels(13f), 0, Util.ConvertDpToPixels(13f), 0);
	}

	public static AuchanSnackbar Make(ViewGroup atTopOf, string message, SnackbarStyle style, DroidInfoMessageService droidInfoMessageService)
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("should be called from main thread");
		}
		FrameLayout frameLayout = new FrameLayout(atTopOf.Context)
		{
			Background = new ColorDrawable(Color.Transparent)
		};
		frameLayout.UpdateLayoutParams(delegate(ViewGroup.LayoutParams lp)
		{
			lp.Height = -2;
			lp.Width = -1;
		});
		PopupWindow popupWindow = new PopupWindow(frameLayout, -1, -2)
		{
			Focusable = false,
			OutsideTouchable = false,
			Touchable = true,
			SoftInputMode = SoftInput.StateAlwaysHidden,
			WindowLayoutType = WindowManagerTypes.ApplicationAttachedDialog
		};
		popupWindow.ShowAtLocation(atTopOf.RootView, GravityFlags.AxisXShift, 0, 0);
		Controls controls = new Controls(LayoutInflater.From(frameLayout.Context).Inflate(2131493533, frameLayout, attachToRoot: false));
		controls.MessageLabel.Text = message;
		controls.IconImage.Visibility = (style != SnackbarStyle.None).ToVisibility();
		Color color = style switch
		{
			SnackbarStyle.Success => Color.Rgb(229, 250, 225), 
			SnackbarStyle.Warning => Color.Rgb(255, 236, 222), 
			SnackbarStyle.Error => Color.Rgb(255, 235, 235), 
			_ => Color.Rgb(229, 250, 225), 
		};
		controls.CardView.SetCardBackgroundColor(color);
		controls.CardView.Radius = 16f;
		Color textColor = style switch
		{
			SnackbarStyle.Success => Color.Rgb(0, 133, 77), 
			SnackbarStyle.Warning => Color.Rgb(178, 75, 0), 
			SnackbarStyle.Error => Color.Rgb(224, 0, 26), 
			_ => Color.Rgb(0, 133, 77), 
		};
		controls.MessageLabel.SetTextColor(textColor);
		if (style != SnackbarStyle.None)
		{
			controls.IconImage.SetImageResource(SnackbarImageHelper.GetImageId(style));
		}
		AuchanSnackbar auchanSnackbar = new AuchanSnackbar(frameLayout, controls);
		auchanSnackbar.AddCallback(new Callback(popupWindow, message, style, droidInfoMessageService));
		return auchanSnackbar;
	}

	public void SetDuration(TimeSpan duration)
	{
		_duration = duration;
		base.SetDuration((int)duration.TotalMilliseconds);
	}

	public override Java.Lang.Object SetDuration(int duration)
	{
		_duration = TimeSpan.FromMilliseconds(duration);
		return base.SetDuration(duration);
	}
}
