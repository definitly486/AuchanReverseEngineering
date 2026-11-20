using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Snackbar;

[Register("com/google/android/material/snackbar/ContentViewCallback", DoNotGenerateAcw = true)]
internal class IContentViewCallbackInvoker : Java.Lang.Object, IContentViewCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_material_snackbar_ContentViewCallback = new XAPeerMembers("com/google/android/material/snackbar/ContentViewCallback", typeof(IContentViewCallbackInvoker));

	private static Delegate? cb_animateContentIn_AnimateContentIn_II_V;

	private static Delegate? cb_animateContentOut_AnimateContentOut_II_V;

	private static nint java_class_ref => _members_com_google_android_material_snackbar_ContentViewCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_snackbar_ContentViewCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_material_snackbar_ContentViewCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_material_snackbar_ContentViewCallback.ManagedPeerType;

	public IContentViewCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AnimateContentIn_II(nint jnienv, nint native__this, int p0, int p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IContentViewCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateContentIn(p0, p1);
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

	public unsafe void AnimateContentIn(int p0, int p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		_members_com_google_android_material_snackbar_ContentViewCallback.InstanceMethods.InvokeAbstractVoidMethod("animateContentIn.(II)V", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AnimateContentOut_II(nint jnienv, nint native__this, int p0, int p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IContentViewCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateContentOut(p0, p1);
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

	public unsafe void AnimateContentOut(int p0, int p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		_members_com_google_android_material_snackbar_ContentViewCallback.InstanceMethods.InvokeAbstractVoidMethod("animateContentOut.(II)V", this, ptr);
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
	private static void n_AnimateContentIn_II_mm_wrapper(nint jnienv, nint native__this, int p0, int p1)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_AnimateContentIn_II(jnienv, native__this, p0, p1);
		}
		catch (System.Exception e)
		{
			global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_AnimateContentOut_II_mm_wrapper(nint jnienv, nint native__this, int p0, int p1)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_AnimateContentOut_II(jnienv, native__this, p0, p1);
		}
		catch (System.Exception e)
		{
			global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
