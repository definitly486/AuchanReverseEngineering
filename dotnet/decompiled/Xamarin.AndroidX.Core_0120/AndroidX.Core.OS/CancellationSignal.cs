using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.OS;

[Obsolete("This class is obsoleted in this android platform")]
[Register("androidx/core/os/CancellationSignal", DoNotGenerateAcw = true)]
public sealed class CancellationSignal : Java.Lang.Object
{
	[Register("androidx/core/os/CancellationSignal$OnCancelListener", "", "AndroidX.Core.OS.CancellationSignal/IOnCancelListenerInvoker")]
	public interface IOnCancelListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCancel", "()V", "GetOnCancelHandler:AndroidX.Core.OS.CancellationSignal/IOnCancelListenerInvoker, Xamarin.AndroidX.Core")]
		void OnCancel();
	}

	[Register("androidx/core/os/CancellationSignal$OnCancelListener", DoNotGenerateAcw = true)]
	internal class IOnCancelListenerInvoker : Java.Lang.Object, IOnCancelListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_os_CancellationSignal_OnCancelListener = new XAPeerMembers("androidx/core/os/CancellationSignal$OnCancelListener", typeof(IOnCancelListenerInvoker));

		private static Delegate? cb_onCancel_OnCancel_V;

		private static nint java_class_ref => _members_androidx_core_os_CancellationSignal_OnCancelListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_os_CancellationSignal_OnCancelListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_os_CancellationSignal_OnCancelListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_os_CancellationSignal_OnCancelListener.ManagedPeerType;

		public IOnCancelListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnCancel(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnCancelListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCancel();
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

		public unsafe void OnCancel()
		{
			_members_androidx_core_os_CancellationSignal_OnCancelListener.InstanceMethods.InvokeAbstractVoidMethod("onCancel.()V", this, null);
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
		private static void n_OnCancel_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnCancel(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("mono/androidx/core/os/CancellationSignal_OnCancelListenerImplementor")]
	internal sealed class IOnCancelListenerImplementor : Java.Lang.Object, IOnCancelListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler? Handler;

		public unsafe IOnCancelListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnCancel()
		{
			Handler?.Invoke(sender, new EventArgs());
		}

		internal static bool __IsEmpty(IOnCancelListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/os/CancellationSignal", typeof(CancellationSignal));

	private WeakReference? weak_implementor_SetOnCancelListener;

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

	public unsafe Java.Lang.Object? CancellationSignalObject
	{
		[Register("getCancellationSignalObject", "()Ljava/lang/Object;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCancellationSignalObject.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsCanceled
	{
		[Register("isCanceled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCanceled.()Z", this, null);
		}
	}

	public event EventHandler CancelEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnCancelListener, IOnCancelListenerImplementor>(ref weak_implementor_SetOnCancelListener, __CreateIOnCancelListenerImplementor, SetOnCancelListener, delegate(IOnCancelListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnCancelListener, IOnCancelListenerImplementor>(ref weak_implementor_SetOnCancelListener, IOnCancelListenerImplementor.__IsEmpty, delegate
			{
				SetOnCancelListener(null);
			}, delegate(IOnCancelListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	internal CancellationSignal(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe CancellationSignal()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("cancel", "()V", "")]
	public unsafe void Cancel()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
	}

	[Register("setOnCancelListener", "(Landroidx/core/os/CancellationSignal$OnCancelListener;)V", "")]
	public unsafe void SetOnCancelListener(IOnCancelListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setOnCancelListener.(Landroidx/core/os/CancellationSignal$OnCancelListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("throwIfCanceled", "()V", "")]
	public unsafe void ThrowIfCanceled()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("throwIfCanceled.()V", this, null);
	}

	private IOnCancelListenerImplementor __CreateIOnCancelListenerImplementor()
	{
		return new IOnCancelListenerImplementor(this);
	}
}
