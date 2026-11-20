using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/OnApplyWindowInsetsListener", DoNotGenerateAcw = true)]
internal class IOnApplyWindowInsetsListenerInvoker : Java.Lang.Object, IOnApplyWindowInsetsListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_core_view_OnApplyWindowInsetsListener = new XAPeerMembers("androidx/core/view/OnApplyWindowInsetsListener", typeof(IOnApplyWindowInsetsListenerInvoker));

	private static Delegate? cb_onApplyWindowInsets_OnApplyWindowInsets_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat__Landroidx_core_view_WindowInsetsCompat_;

	private static nint java_class_ref => _members_androidx_core_view_OnApplyWindowInsetsListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_OnApplyWindowInsetsListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_view_OnApplyWindowInsetsListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_view_OnApplyWindowInsetsListener.ManagedPeerType;

	public IOnApplyWindowInsetsListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnApplyWindowInsets_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_(nint jnienv, nint native__this, nint native_v, nint native_insets)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IOnApplyWindowInsetsListener? onApplyWindowInsetsListener = Java.Lang.Object.GetObject<IOnApplyWindowInsetsListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View v = Java.Lang.Object.GetObject<Android.Views.View>(native_v, JniHandleOwnership.DoNotTransfer);
			WindowInsetsCompat insets = Java.Lang.Object.GetObject<WindowInsetsCompat>(native_insets, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(onApplyWindowInsetsListener.OnApplyWindowInsets(v, insets));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe WindowInsetsCompat? OnApplyWindowInsets(Android.Views.View? v, WindowInsetsCompat? insets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members_androidx_core_view_OnApplyWindowInsetsListener.InstanceMethods.InvokeAbstractObjectMethod("onApplyWindowInsets.(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(insets);
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
	private static nint n_OnApplyWindowInsets_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat__mm_wrapper(nint jnienv, nint native__this, nint native_v, nint native_insets)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnApplyWindowInsets_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_(jnienv, native__this, native_v, native_insets);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
