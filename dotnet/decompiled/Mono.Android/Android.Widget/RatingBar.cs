using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/RatingBar", DoNotGenerateAcw = true)]
public class RatingBar : AbsSeekBar
{
	[Register("android/widget/RatingBar$OnRatingBarChangeListener", "", "Android.Widget.RatingBar/IOnRatingBarChangeListenerInvoker")]
	public interface IOnRatingBarChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onRatingChanged", "(Landroid/widget/RatingBar;FZ)V", "GetOnRatingChanged_Landroid_widget_RatingBar_FZHandler:Android.Widget.RatingBar/IOnRatingBarChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnRatingChanged(RatingBar? ratingBar, float rating, bool fromUser);
	}

	[Register("android/widget/RatingBar$OnRatingBarChangeListener", DoNotGenerateAcw = true)]
	internal class IOnRatingBarChangeListenerInvoker : Java.Lang.Object, IOnRatingBarChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_RatingBar_OnRatingBarChangeListener = new XAPeerMembers("android/widget/RatingBar$OnRatingBarChangeListener", typeof(IOnRatingBarChangeListenerInvoker));

		private static Delegate? cb_onRatingChanged_OnRatingChanged_Landroid_widget_RatingBar_FZ_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_RatingBar_OnRatingBarChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_RatingBar_OnRatingBarChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_RatingBar_OnRatingBarChangeListener.ManagedPeerType;

		public IOnRatingBarChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnRatingChanged_Landroid_widget_RatingBar_FZ(nint jnienv, nint native__this, nint native_ratingBar, float rating, sbyte native_fromUser)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnRatingBarChangeListener? onRatingBarChangeListener = Java.Lang.Object.GetObject<IOnRatingBarChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RatingBar ratingBar = Java.Lang.Object.GetObject<RatingBar>(native_ratingBar, JniHandleOwnership.DoNotTransfer);
				bool fromUser = native_fromUser != 0;
				onRatingBarChangeListener.OnRatingChanged(ratingBar, rating, fromUser);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnRatingChanged(RatingBar? ratingBar, float rating, bool fromUser)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(ratingBar?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(rating);
				ptr[2] = new JniArgumentValue(fromUser ? ((sbyte)1) : ((sbyte)0));
				_members_android_widget_RatingBar_OnRatingBarChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onRatingChanged.(Landroid/widget/RatingBar;FZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(ratingBar);
			}
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

		[UnmanagedCallersOnly]
		private static void n_OnRatingChanged_Landroid_widget_RatingBar_FZ_mm_wrapper(nint jnienv, nint native__this, nint native_ratingBar, float rating, sbyte native_fromUser)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnRatingChanged_Landroid_widget_RatingBar_FZ(jnienv, native__this, native_ratingBar, rating, native_fromUser);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class RatingBarChangeEventArgs : EventArgs
	{
		private float rating;

		private bool fromUser;

		public RatingBarChangeEventArgs(float rating, bool fromUser)
		{
			this.rating = rating;
			this.fromUser = fromUser;
		}
	}

	[Register("mono/android/widget/RatingBar_OnRatingBarChangeListenerImplementor")]
	internal sealed class IOnRatingBarChangeListenerImplementor : Java.Lang.Object, IOnRatingBarChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<RatingBarChangeEventArgs>? Handler;

		public unsafe IOnRatingBarChangeListenerImplementor()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		public void OnRatingChanged(RatingBar? ratingBar, float rating, bool fromUser)
		{
			Handler?.Invoke(ratingBar, new RatingBarChangeEventArgs(rating, fromUser));
		}

		internal static bool __IsEmpty(IOnRatingBarChangeListenerImplementor value)
		{
			return value.Handler == null;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/RatingBar", typeof(RatingBar));

	private static Delegate? cb_setOnRatingBarChangeListener_SetOnRatingBarChangeListener_Landroid_widget_RatingBar_OnRatingBarChangeListener__V;

	private static Delegate? cb_getRating_GetRating_F;

	private static Delegate? cb_setRating_SetRating_F_V;

	private WeakReference? weak_implementor___SetOnRatingBarChangeListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual IOnRatingBarChangeListener? OnRatingBarChangeListener
	{
		[Register("setOnRatingBarChangeListener", "(Landroid/widget/RatingBar$OnRatingBarChangeListener;)V", "GetSetOnRatingBarChangeListener_Landroid_widget_RatingBar_OnRatingBarChangeListener_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnRatingBarChangeListener.(Landroid/widget/RatingBar$OnRatingBarChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual float Rating
	{
		[Register("getRating", "()F", "GetGetRatingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRating.()F", this, null);
		}
		[Register("setRating", "(F)V", "GetSetRating_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRating.(F)V", this, ptr);
		}
	}

	public event EventHandler<RatingBarChangeEventArgs> RatingBarChange
	{
		add
		{
			EventHelper.AddEventHandler(ref weak_implementor___SetOnRatingBarChangeListener, __CreateIOnRatingBarChangeListenerImplementor, delegate(IOnRatingBarChangeListener __v)
			{
				OnRatingBarChangeListener = __v;
			}, delegate(IOnRatingBarChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<RatingBarChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnRatingBarChangeListener, IOnRatingBarChangeListenerImplementor>(ref weak_implementor___SetOnRatingBarChangeListener, IOnRatingBarChangeListenerImplementor.__IsEmpty, delegate
			{
				OnRatingBarChangeListener = null;
			}, delegate(IOnRatingBarChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<RatingBarChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected RatingBar(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe RatingBar(Context? context, IAttributeSet? attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe RatingBar(Context? context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetSetOnRatingBarChangeListener_Landroid_widget_RatingBar_OnRatingBarChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnRatingBarChangeListener_Landroid_widget_RatingBar_OnRatingBarChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnRatingBarChangeListener_Landroid_widget_RatingBar_OnRatingBarChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RatingBar? ratingBar = Java.Lang.Object.GetObject<RatingBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnRatingBarChangeListener onRatingBarChangeListener = Java.Lang.Object.GetObject<IOnRatingBarChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			ratingBar.OnRatingBarChangeListener = onRatingBarChangeListener;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetRatingHandler()
	{
		return new _JniMarshal_PP_F(n_GetRating);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetRating(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<RatingBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rating;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetRating_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetRating_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRating_F(nint jnienv, nint native__this, float rating)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RatingBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rating = rating;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private IOnRatingBarChangeListenerImplementor __CreateIOnRatingBarChangeListenerImplementor()
	{
		return new IOnRatingBarChangeListenerImplementor();
	}
}
