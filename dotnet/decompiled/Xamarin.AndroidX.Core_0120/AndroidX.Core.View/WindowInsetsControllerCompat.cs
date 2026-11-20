using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/WindowInsetsControllerCompat", DoNotGenerateAcw = true)]
public sealed class WindowInsetsControllerCompat : Java.Lang.Object
{
	[Register("androidx/core/view/WindowInsetsControllerCompat$OnControllableInsetsChangedListener", "", "AndroidX.Core.View.WindowInsetsControllerCompat/IOnControllableInsetsChangedListenerInvoker")]
	public interface IOnControllableInsetsChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onControllableInsetsChanged", "(Landroidx/core/view/WindowInsetsControllerCompat;I)V", "GetOnControllableInsetsChanged_Landroidx_core_view_WindowInsetsControllerCompat_IHandler:AndroidX.Core.View.WindowInsetsControllerCompat/IOnControllableInsetsChangedListenerInvoker, Xamarin.AndroidX.Core")]
		void OnControllableInsetsChanged(WindowInsetsControllerCompat? controller, int typeMask);
	}

	[Register("androidx/core/view/WindowInsetsControllerCompat$OnControllableInsetsChangedListener", DoNotGenerateAcw = true)]
	internal class IOnControllableInsetsChangedListenerInvoker : Java.Lang.Object, IOnControllableInsetsChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_view_WindowInsetsControllerCompat_OnControllableInsetsChangedListener = new XAPeerMembers("androidx/core/view/WindowInsetsControllerCompat$OnControllableInsetsChangedListener", typeof(IOnControllableInsetsChangedListenerInvoker));

		private static Delegate? cb_onControllableInsetsChanged_OnControllableInsetsChanged_Landroidx_core_view_WindowInsetsControllerCompat_I_V;

		private static nint java_class_ref => _members_androidx_core_view_WindowInsetsControllerCompat_OnControllableInsetsChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_WindowInsetsControllerCompat_OnControllableInsetsChangedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_view_WindowInsetsControllerCompat_OnControllableInsetsChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_view_WindowInsetsControllerCompat_OnControllableInsetsChangedListener.ManagedPeerType;

		public IOnControllableInsetsChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnControllableInsetsChanged_Landroidx_core_view_WindowInsetsControllerCompat_I(nint jnienv, nint native__this, nint native_controller, int typeMask)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnControllableInsetsChangedListener? onControllableInsetsChangedListener = Java.Lang.Object.GetObject<IOnControllableInsetsChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				WindowInsetsControllerCompat controller = Java.Lang.Object.GetObject<WindowInsetsControllerCompat>(native_controller, JniHandleOwnership.DoNotTransfer);
				onControllableInsetsChangedListener.OnControllableInsetsChanged(controller, typeMask);
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

		public unsafe void OnControllableInsetsChanged(WindowInsetsControllerCompat? controller, int typeMask)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(controller?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(typeMask);
				_members_androidx_core_view_WindowInsetsControllerCompat_OnControllableInsetsChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onControllableInsetsChanged.(Landroidx/core/view/WindowInsetsControllerCompat;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(controller);
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
		private static void n_OnControllableInsetsChanged_Landroidx_core_view_WindowInsetsControllerCompat_I_mm_wrapper(nint jnienv, nint native__this, nint native_controller, int typeMask)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnControllableInsetsChanged_Landroidx_core_view_WindowInsetsControllerCompat_I(jnienv, native__this, native_controller, typeMask);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ControllableInsetsChangedEventArgs : EventArgs
	{
		private WindowInsetsControllerCompat? controller;

		private int typeMask;

		public ControllableInsetsChangedEventArgs(WindowInsetsControllerCompat? controller, int typeMask)
		{
			this.controller = controller;
			this.typeMask = typeMask;
		}
	}

	[Register("mono/androidx/core/view/WindowInsetsControllerCompat_OnControllableInsetsChangedListenerImplementor")]
	internal sealed class IOnControllableInsetsChangedListenerImplementor : Java.Lang.Object, IOnControllableInsetsChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ControllableInsetsChangedEventArgs>? Handler;

		public unsafe IOnControllableInsetsChangedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnControllableInsetsChanged(WindowInsetsControllerCompat? controller, int typeMask)
		{
			Handler?.Invoke(sender, new ControllableInsetsChangedEventArgs(controller, typeMask));
		}

		internal static bool __IsEmpty(IOnControllableInsetsChangedListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowInsetsControllerCompat", typeof(WindowInsetsControllerCompat));

	private WeakReference? weak_implementor_AddOnControllableInsetsChangedListener;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe bool AppearanceLightNavigationBars
	{
		[Register("isAppearanceLightNavigationBars", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isAppearanceLightNavigationBars.()Z", this, null);
		}
		[Register("setAppearanceLightNavigationBars", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setAppearanceLightNavigationBars.(Z)V", this, ptr);
		}
	}

	public unsafe bool AppearanceLightStatusBars
	{
		[Register("isAppearanceLightStatusBars", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isAppearanceLightStatusBars.()Z", this, null);
		}
		[Register("setAppearanceLightStatusBars", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setAppearanceLightStatusBars.(Z)V", this, ptr);
		}
	}

	public unsafe int SystemBarsBehavior
	{
		[Register("getSystemBarsBehavior", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSystemBarsBehavior.()I", this, null);
		}
		[Register("setSystemBarsBehavior", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setSystemBarsBehavior.(I)V", this, ptr);
		}
	}

	public event EventHandler<ControllableInsetsChangedEventArgs> ControllableInsetsChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnControllableInsetsChangedListener, IOnControllableInsetsChangedListenerImplementor>(ref weak_implementor_AddOnControllableInsetsChangedListener, __CreateIOnControllableInsetsChangedListenerImplementor, AddOnControllableInsetsChangedListener, delegate(IOnControllableInsetsChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ControllableInsetsChangedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnControllableInsetsChangedListener, IOnControllableInsetsChangedListenerImplementor.__IsEmpty, delegate(IOnControllableInsetsChangedListener __v)
			{
				RemoveOnControllableInsetsChangedListener(__v);
			}, delegate(IOnControllableInsetsChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ControllableInsetsChangedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	internal WindowInsetsControllerCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/view/Window;Landroid/view/View;)V", "")]
	public unsafe WindowInsetsControllerCompat(Window? window, Android.Views.View? view)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(window?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/Window;Landroid/view/View;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/Window;Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(window);
			GC.KeepAlive(view);
		}
	}

	[Register("addOnControllableInsetsChangedListener", "(Landroidx/core/view/WindowInsetsControllerCompat$OnControllableInsetsChangedListener;)V", "")]
	public unsafe void AddOnControllableInsetsChangedListener(IOnControllableInsetsChangedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addOnControllableInsetsChangedListener.(Landroidx/core/view/WindowInsetsControllerCompat$OnControllableInsetsChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("controlWindowInsetsAnimation", "(IJLandroid/view/animation/Interpolator;Landroid/os/CancellationSignal;Landroidx/core/view/WindowInsetsAnimationControlListenerCompat;)V", "")]
	public unsafe void ControlWindowInsetsAnimation(int types, long durationMillis, IInterpolator? interpolator, CancellationSignal? cancellationSignal, IWindowInsetsAnimationControlListenerCompat? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(types);
			ptr[1] = new JniArgumentValue(durationMillis);
			ptr[2] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			ptr[3] = new JniArgumentValue(cancellationSignal?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("controlWindowInsetsAnimation.(IJLandroid/view/animation/Interpolator;Landroid/os/CancellationSignal;Landroidx/core/view/WindowInsetsAnimationControlListenerCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
			GC.KeepAlive(cancellationSignal);
			GC.KeepAlive(listener);
		}
	}

	[Register("hide", "(I)V", "")]
	public unsafe void Hide(int types)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(types);
		_members.InstanceMethods.InvokeAbstractVoidMethod("hide.(I)V", this, ptr);
	}

	[Register("removeOnControllableInsetsChangedListener", "(Landroidx/core/view/WindowInsetsControllerCompat$OnControllableInsetsChangedListener;)V", "")]
	public unsafe void RemoveOnControllableInsetsChangedListener(IOnControllableInsetsChangedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("removeOnControllableInsetsChangedListener.(Landroidx/core/view/WindowInsetsControllerCompat$OnControllableInsetsChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("show", "(I)V", "")]
	public unsafe void Show(int types)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(types);
		_members.InstanceMethods.InvokeAbstractVoidMethod("show.(I)V", this, ptr);
	}

	[Obsolete("deprecated")]
	[Register("toWindowInsetsControllerCompat", "(Landroid/view/WindowInsetsController;)Landroidx/core/view/WindowInsetsControllerCompat;", "")]
	public unsafe static WindowInsetsControllerCompat? ToWindowInsetsControllerCompat(IWindowInsetsController? insetsController)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((insetsController == null) ? IntPtr.Zero : ((Java.Lang.Object)insetsController).Handle);
			return Java.Lang.Object.GetObject<WindowInsetsControllerCompat>(_members.StaticMethods.InvokeObjectMethod("toWindowInsetsControllerCompat.(Landroid/view/WindowInsetsController;)Landroidx/core/view/WindowInsetsControllerCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(insetsController);
		}
	}

	private IOnControllableInsetsChangedListenerImplementor __CreateIOnControllableInsetsChangedListenerImplementor()
	{
		return new IOnControllableInsetsChangedListenerImplementor(this);
	}
}
