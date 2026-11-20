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

[Register("android/widget/SeekBar", DoNotGenerateAcw = true)]
public class SeekBar : AbsSeekBar
{
	[Register("android/widget/SeekBar$OnSeekBarChangeListener", "", "Android.Widget.SeekBar/IOnSeekBarChangeListenerInvoker")]
	public interface IOnSeekBarChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onProgressChanged", "(Landroid/widget/SeekBar;IZ)V", "GetOnProgressChanged_Landroid_widget_SeekBar_IZHandler:Android.Widget.SeekBar/IOnSeekBarChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnProgressChanged(SeekBar? seekBar, int progress, bool fromUser);

		[Register("onStartTrackingTouch", "(Landroid/widget/SeekBar;)V", "GetOnStartTrackingTouch_Landroid_widget_SeekBar_Handler:Android.Widget.SeekBar/IOnSeekBarChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnStartTrackingTouch(SeekBar? seekBar);

		[Register("onStopTrackingTouch", "(Landroid/widget/SeekBar;)V", "GetOnStopTrackingTouch_Landroid_widget_SeekBar_Handler:Android.Widget.SeekBar/IOnSeekBarChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnStopTrackingTouch(SeekBar? seekBar);
	}

	[Register("android/widget/SeekBar$OnSeekBarChangeListener", DoNotGenerateAcw = true)]
	internal class IOnSeekBarChangeListenerInvoker : Java.Lang.Object, IOnSeekBarChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_SeekBar_OnSeekBarChangeListener = new XAPeerMembers("android/widget/SeekBar$OnSeekBarChangeListener", typeof(IOnSeekBarChangeListenerInvoker));

		private static Delegate? cb_onProgressChanged_OnProgressChanged_Landroid_widget_SeekBar_IZ_V;

		private static Delegate? cb_onStartTrackingTouch_OnStartTrackingTouch_Landroid_widget_SeekBar__V;

		private static Delegate? cb_onStopTrackingTouch_OnStopTrackingTouch_Landroid_widget_SeekBar__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_SeekBar_OnSeekBarChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_SeekBar_OnSeekBarChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_SeekBar_OnSeekBarChangeListener.ManagedPeerType;

		public IOnSeekBarChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnProgressChanged_Landroid_widget_SeekBar_IZ(nint jnienv, nint native__this, nint native_seekBar, int progress, sbyte native_fromUser)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnSeekBarChangeListener? onSeekBarChangeListener = Java.Lang.Object.GetObject<IOnSeekBarChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SeekBar seekBar = Java.Lang.Object.GetObject<SeekBar>(native_seekBar, JniHandleOwnership.DoNotTransfer);
				bool fromUser = native_fromUser != 0;
				onSeekBarChangeListener.OnProgressChanged(seekBar, progress, fromUser);
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

		public unsafe void OnProgressChanged(SeekBar? seekBar, int progress, bool fromUser)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(seekBar?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(progress);
				ptr[2] = new JniArgumentValue(fromUser ? ((sbyte)1) : ((sbyte)0));
				_members_android_widget_SeekBar_OnSeekBarChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onProgressChanged.(Landroid/widget/SeekBar;IZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(seekBar);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStartTrackingTouch_Landroid_widget_SeekBar_(nint jnienv, nint native__this, nint native_seekBar)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnSeekBarChangeListener? onSeekBarChangeListener = Java.Lang.Object.GetObject<IOnSeekBarChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SeekBar seekBar = Java.Lang.Object.GetObject<SeekBar>(native_seekBar, JniHandleOwnership.DoNotTransfer);
				onSeekBarChangeListener.OnStartTrackingTouch(seekBar);
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

		public unsafe void OnStartTrackingTouch(SeekBar? seekBar)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(seekBar?.Handle ?? IntPtr.Zero);
				_members_android_widget_SeekBar_OnSeekBarChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onStartTrackingTouch.(Landroid/widget/SeekBar;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(seekBar);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStopTrackingTouch_Landroid_widget_SeekBar_(nint jnienv, nint native__this, nint native_seekBar)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnSeekBarChangeListener? onSeekBarChangeListener = Java.Lang.Object.GetObject<IOnSeekBarChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SeekBar seekBar = Java.Lang.Object.GetObject<SeekBar>(native_seekBar, JniHandleOwnership.DoNotTransfer);
				onSeekBarChangeListener.OnStopTrackingTouch(seekBar);
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

		public unsafe void OnStopTrackingTouch(SeekBar? seekBar)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(seekBar?.Handle ?? IntPtr.Zero);
				_members_android_widget_SeekBar_OnSeekBarChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onStopTrackingTouch.(Landroid/widget/SeekBar;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(seekBar);
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
		private static void n_OnProgressChanged_Landroid_widget_SeekBar_IZ_mm_wrapper(nint jnienv, nint native__this, nint native_seekBar, int progress, sbyte native_fromUser)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnProgressChanged_Landroid_widget_SeekBar_IZ(jnienv, native__this, native_seekBar, progress, native_fromUser);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnStartTrackingTouch_Landroid_widget_SeekBar__mm_wrapper(nint jnienv, nint native__this, nint native_seekBar)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnStartTrackingTouch_Landroid_widget_SeekBar_(jnienv, native__this, native_seekBar);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnStopTrackingTouch_Landroid_widget_SeekBar__mm_wrapper(nint jnienv, nint native__this, nint native_seekBar)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnStopTrackingTouch_Landroid_widget_SeekBar_(jnienv, native__this, native_seekBar);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ProgressChangedEventArgs : EventArgs
	{
		private SeekBar? seekBar;

		private int progress;

		private bool fromUser;

		public int Progress => progress;

		public ProgressChangedEventArgs(SeekBar? seekBar, int progress, bool fromUser)
		{
			this.seekBar = seekBar;
			this.progress = progress;
			this.fromUser = fromUser;
		}
	}

	public class StartTrackingTouchEventArgs : EventArgs
	{
		private SeekBar? seekBar;

		public StartTrackingTouchEventArgs(SeekBar? seekBar)
		{
			this.seekBar = seekBar;
		}
	}

	public class StopTrackingTouchEventArgs : EventArgs
	{
		private SeekBar? seekBar;

		public StopTrackingTouchEventArgs(SeekBar? seekBar)
		{
			this.seekBar = seekBar;
		}
	}

	[Register("mono/android/widget/SeekBar_OnSeekBarChangeListenerImplementor")]
	internal sealed class IOnSeekBarChangeListenerImplementor : Java.Lang.Object, IOnSeekBarChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ProgressChangedEventArgs>? OnProgressChangedHandler;

		public EventHandler<StartTrackingTouchEventArgs>? OnStartTrackingTouchHandler;

		public EventHandler<StopTrackingTouchEventArgs>? OnStopTrackingTouchHandler;

		public unsafe IOnSeekBarChangeListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnProgressChanged(SeekBar? seekBar, int progress, bool fromUser)
		{
			OnProgressChangedHandler?.Invoke(sender, new ProgressChangedEventArgs(seekBar, progress, fromUser));
		}

		public void OnStartTrackingTouch(SeekBar? seekBar)
		{
			OnStartTrackingTouchHandler?.Invoke(sender, new StartTrackingTouchEventArgs(seekBar));
		}

		public void OnStopTrackingTouch(SeekBar? seekBar)
		{
			OnStopTrackingTouchHandler?.Invoke(sender, new StopTrackingTouchEventArgs(seekBar));
		}

		internal static bool __IsEmpty(IOnSeekBarChangeListenerImplementor value)
		{
			if (value.OnProgressChangedHandler == null && value.OnStartTrackingTouchHandler == null)
			{
				return value.OnStopTrackingTouchHandler == null;
			}
			return false;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/SeekBar", typeof(SeekBar));

	private static Delegate? cb_setOnSeekBarChangeListener_SetOnSeekBarChangeListener_Landroid_widget_SeekBar_OnSeekBarChangeListener__V;

	private WeakReference? weak_implementor_SetOnSeekBarChangeListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public event EventHandler<ProgressChangedEventArgs> ProgressChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnSeekBarChangeListener, IOnSeekBarChangeListenerImplementor>(ref weak_implementor_SetOnSeekBarChangeListener, __CreateIOnSeekBarChangeListenerImplementor, SetOnSeekBarChangeListener, delegate(IOnSeekBarChangeListenerImplementor __h)
			{
				__h.OnProgressChangedHandler = (EventHandler<ProgressChangedEventArgs>)Delegate.Combine(__h.OnProgressChangedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnSeekBarChangeListener, IOnSeekBarChangeListenerImplementor>(ref weak_implementor_SetOnSeekBarChangeListener, IOnSeekBarChangeListenerImplementor.__IsEmpty, delegate
			{
				SetOnSeekBarChangeListener(null);
			}, delegate(IOnSeekBarChangeListenerImplementor __h)
			{
				__h.OnProgressChangedHandler = (EventHandler<ProgressChangedEventArgs>)Delegate.Remove(__h.OnProgressChangedHandler, value);
			});
		}
	}

	public event EventHandler<StartTrackingTouchEventArgs> StartTrackingTouch
	{
		add
		{
			EventHelper.AddEventHandler<IOnSeekBarChangeListener, IOnSeekBarChangeListenerImplementor>(ref weak_implementor_SetOnSeekBarChangeListener, __CreateIOnSeekBarChangeListenerImplementor, SetOnSeekBarChangeListener, delegate(IOnSeekBarChangeListenerImplementor __h)
			{
				__h.OnStartTrackingTouchHandler = (EventHandler<StartTrackingTouchEventArgs>)Delegate.Combine(__h.OnStartTrackingTouchHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnSeekBarChangeListener, IOnSeekBarChangeListenerImplementor>(ref weak_implementor_SetOnSeekBarChangeListener, IOnSeekBarChangeListenerImplementor.__IsEmpty, delegate
			{
				SetOnSeekBarChangeListener(null);
			}, delegate(IOnSeekBarChangeListenerImplementor __h)
			{
				__h.OnStartTrackingTouchHandler = (EventHandler<StartTrackingTouchEventArgs>)Delegate.Remove(__h.OnStartTrackingTouchHandler, value);
			});
		}
	}

	protected SeekBar(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe SeekBar(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	public unsafe SeekBar(Context? context, IAttributeSet? attrs)
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

	private static Delegate GetSetOnSeekBarChangeListener_Landroid_widget_SeekBar_OnSeekBarChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnSeekBarChangeListener_Landroid_widget_SeekBar_OnSeekBarChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnSeekBarChangeListener_Landroid_widget_SeekBar_OnSeekBarChangeListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SeekBar? seekBar = Java.Lang.Object.GetObject<SeekBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnSeekBarChangeListener onSeekBarChangeListener = Java.Lang.Object.GetObject<IOnSeekBarChangeListener>(native_l, JniHandleOwnership.DoNotTransfer);
			seekBar.SetOnSeekBarChangeListener(onSeekBarChangeListener);
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

	public unsafe virtual void SetOnSeekBarChangeListener(IOnSeekBarChangeListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnSeekBarChangeListener.(Landroid/widget/SeekBar$OnSeekBarChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	private IOnSeekBarChangeListenerImplementor __CreateIOnSeekBarChangeListenerImplementor()
	{
		return new IOnSeekBarChangeListenerImplementor(this);
	}
}
