using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewTreeObserver", DoNotGenerateAcw = true)]
public sealed class ViewTreeObserver : Java.Lang.Object
{
	[Register("android/view/ViewTreeObserver$OnGlobalLayoutListener", "", "Android.Views.ViewTreeObserver/IOnGlobalLayoutListenerInvoker")]
	public interface IOnGlobalLayoutListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onGlobalLayout", "()V", "GetOnGlobalLayoutHandler:Android.Views.ViewTreeObserver/IOnGlobalLayoutListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnGlobalLayout();
	}

	[Register("android/view/ViewTreeObserver$OnGlobalLayoutListener", DoNotGenerateAcw = true)]
	internal class IOnGlobalLayoutListenerInvoker : Java.Lang.Object, IOnGlobalLayoutListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_ViewTreeObserver_OnGlobalLayoutListener = new XAPeerMembers("android/view/ViewTreeObserver$OnGlobalLayoutListener", typeof(IOnGlobalLayoutListenerInvoker));

		private static Delegate? cb_onGlobalLayout_OnGlobalLayout_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_ViewTreeObserver_OnGlobalLayoutListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_ViewTreeObserver_OnGlobalLayoutListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_ViewTreeObserver_OnGlobalLayoutListener.ManagedPeerType;

		public IOnGlobalLayoutListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnGlobalLayout(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnGlobalLayoutListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnGlobalLayout();
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

		public unsafe void OnGlobalLayout()
		{
			_members_android_view_ViewTreeObserver_OnGlobalLayoutListener.InstanceMethods.InvokeAbstractVoidMethod("onGlobalLayout.()V", this, null);
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
		private static void n_OnGlobalLayout_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnGlobalLayout(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("mono/android/view/ViewTreeObserver_OnGlobalLayoutListenerImplementor")]
	internal sealed class IOnGlobalLayoutListenerImplementor : Java.Lang.Object, IOnGlobalLayoutListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler? Handler;

		public unsafe IOnGlobalLayoutListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnGlobalLayout()
		{
			Handler?.Invoke(sender, new EventArgs());
		}

		internal static bool __IsEmpty(IOnGlobalLayoutListenerImplementor value)
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

	[Register("android/view/ViewTreeObserver$OnScrollChangedListener", "", "Android.Views.ViewTreeObserver/IOnScrollChangedListenerInvoker")]
	public interface IOnScrollChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScrollChanged", "()V", "GetOnScrollChangedHandler:Android.Views.ViewTreeObserver/IOnScrollChangedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnScrollChanged();
	}

	[Register("android/view/ViewTreeObserver$OnScrollChangedListener", DoNotGenerateAcw = true)]
	internal class IOnScrollChangedListenerInvoker : Java.Lang.Object, IOnScrollChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_ViewTreeObserver_OnScrollChangedListener = new XAPeerMembers("android/view/ViewTreeObserver$OnScrollChangedListener", typeof(IOnScrollChangedListenerInvoker));

		private static Delegate? cb_onScrollChanged_OnScrollChanged_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_ViewTreeObserver_OnScrollChangedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_ViewTreeObserver_OnScrollChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_ViewTreeObserver_OnScrollChangedListener.ManagedPeerType;

		public IOnScrollChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnScrollChanged(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnScrollChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScrollChanged();
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

		public unsafe void OnScrollChanged()
		{
			_members_android_view_ViewTreeObserver_OnScrollChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onScrollChanged.()V", this, null);
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
		private static void n_OnScrollChanged_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnScrollChanged(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("mono/android/view/ViewTreeObserver_OnScrollChangedListenerImplementor")]
	internal sealed class IOnScrollChangedListenerImplementor : Java.Lang.Object, IOnScrollChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler? Handler;

		public unsafe IOnScrollChangedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnScrollChanged()
		{
			Handler?.Invoke(sender, new EventArgs());
		}

		internal static bool __IsEmpty(IOnScrollChangedListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewTreeObserver", typeof(ViewTreeObserver));

	private WeakReference? weak_implementor_AddOnGlobalLayoutListener;

	private WeakReference? weak_implementor_AddOnScrollChangedListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe bool IsAlive
	{
		[Register("isAlive", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isAlive.()Z", this, null);
		}
	}

	public event EventHandler GlobalLayout
	{
		add
		{
			EventHelper.AddEventHandler<IOnGlobalLayoutListener, IOnGlobalLayoutListenerImplementor>(ref weak_implementor_AddOnGlobalLayoutListener, __CreateIOnGlobalLayoutListenerImplementor, AddOnGlobalLayoutListener, delegate(IOnGlobalLayoutListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnGlobalLayoutListener, IOnGlobalLayoutListenerImplementor.__IsEmpty, delegate(IOnGlobalLayoutListener __v)
			{
				RemoveOnGlobalLayoutListener(__v);
			}, delegate(IOnGlobalLayoutListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler ScrollChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnScrollChangedListener, IOnScrollChangedListenerImplementor>(ref weak_implementor_AddOnScrollChangedListener, __CreateIOnScrollChangedListenerImplementor, AddOnScrollChangedListener, delegate(IOnScrollChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnScrollChangedListener, IOnScrollChangedListenerImplementor.__IsEmpty, delegate(IOnScrollChangedListener __v)
			{
				RemoveOnScrollChangedListener(__v);
			}, delegate(IOnScrollChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	internal ViewTreeObserver(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("addOnGlobalLayoutListener", "(Landroid/view/ViewTreeObserver$OnGlobalLayoutListener;)V", "")]
	public unsafe void AddOnGlobalLayoutListener(IOnGlobalLayoutListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addOnGlobalLayoutListener.(Landroid/view/ViewTreeObserver$OnGlobalLayoutListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("addOnScrollChangedListener", "(Landroid/view/ViewTreeObserver$OnScrollChangedListener;)V", "")]
	public unsafe void AddOnScrollChangedListener(IOnScrollChangedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addOnScrollChangedListener.(Landroid/view/ViewTreeObserver$OnScrollChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("removeOnGlobalLayoutListener", "(Landroid/view/ViewTreeObserver$OnGlobalLayoutListener;)V", "")]
	public unsafe void RemoveOnGlobalLayoutListener(IOnGlobalLayoutListener? victim)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((victim == null) ? IntPtr.Zero : ((Java.Lang.Object)victim).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("removeOnGlobalLayoutListener.(Landroid/view/ViewTreeObserver$OnGlobalLayoutListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(victim);
		}
	}

	[Register("removeOnScrollChangedListener", "(Landroid/view/ViewTreeObserver$OnScrollChangedListener;)V", "")]
	public unsafe void RemoveOnScrollChangedListener(IOnScrollChangedListener? victim)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((victim == null) ? IntPtr.Zero : ((Java.Lang.Object)victim).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("removeOnScrollChangedListener.(Landroid/view/ViewTreeObserver$OnScrollChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(victim);
		}
	}

	private IOnGlobalLayoutListenerImplementor __CreateIOnGlobalLayoutListenerImplementor()
	{
		return new IOnGlobalLayoutListenerImplementor(this);
	}

	private IOnScrollChangedListenerImplementor __CreateIOnScrollChangedListenerImplementor()
	{
		return new IOnScrollChangedListenerImplementor(this);
	}
}
