using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/OnReceiveContentListener", DoNotGenerateAcw = true)]
internal class IOnReceiveContentListenerInvoker : Java.Lang.Object, IOnReceiveContentListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_core_view_OnReceiveContentListener = new XAPeerMembers("androidx/core/view/OnReceiveContentListener", typeof(IOnReceiveContentListenerInvoker));

	private static Delegate? cb_onReceiveContent_OnReceiveContent_Landroid_view_View_Landroidx_core_view_ContentInfoCompat__Landroidx_core_view_ContentInfoCompat_;

	private static nint java_class_ref => _members_androidx_core_view_OnReceiveContentListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_OnReceiveContentListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_view_OnReceiveContentListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_view_OnReceiveContentListener.ManagedPeerType;

	public IOnReceiveContentListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnReceiveContent_Landroid_view_View_Landroidx_core_view_ContentInfoCompat_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_OnReceiveContent_Landroid_view_View_Landroidx_core_view_ContentInfoCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnReceiveContent_Landroid_view_View_Landroidx_core_view_ContentInfoCompat_(nint jnienv, nint native__this, nint native_view, nint native_payload)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IOnReceiveContentListener? onReceiveContentListener = Java.Lang.Object.GetObject<IOnReceiveContentListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			ContentInfoCompat payload = Java.Lang.Object.GetObject<ContentInfoCompat>(native_payload, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(onReceiveContentListener.OnReceiveContent(view, payload));
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

	public unsafe ContentInfoCompat? OnReceiveContent(Android.Views.View? view, ContentInfoCompat? payload)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ContentInfoCompat>(_members_androidx_core_view_OnReceiveContentListener.InstanceMethods.InvokeAbstractObjectMethod("onReceiveContent.(Landroid/view/View;Landroidx/core/view/ContentInfoCompat;)Landroidx/core/view/ContentInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(payload);
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
}
