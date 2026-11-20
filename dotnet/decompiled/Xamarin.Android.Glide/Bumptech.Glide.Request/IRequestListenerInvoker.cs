using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Request.Target;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request;

[Register("com/bumptech/glide/request/RequestListener", DoNotGenerateAcw = true)]
internal class IRequestListenerInvoker : Java.Lang.Object, IRequestListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_request_RequestListener = new XAPeerMembers("com/bumptech/glide/request/RequestListener", typeof(IRequestListenerInvoker));

	private static Delegate? cb_onLoadFailed_OnLoadFailed_Lcom_bumptech_glide_load_engine_GlideException_Ljava_lang_Object_Lcom_bumptech_glide_request_target_Target_Z_Z;

	private static Delegate? cb_onResourceReady_OnResourceReady_Ljava_lang_Object_Ljava_lang_Object_Lcom_bumptech_glide_request_target_Target_Lcom_bumptech_glide_load_DataSource_Z_Z;

	private static nint java_class_ref => _members_com_bumptech_glide_request_RequestListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_request_RequestListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_request_RequestListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_request_RequestListener.ManagedPeerType;

	public IRequestListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnLoadFailed_Lcom_bumptech_glide_load_engine_GlideException_Ljava_lang_Object_Lcom_bumptech_glide_request_target_Target_Z(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, sbyte native_p3)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IRequestListener? requestListener = Java.Lang.Object.GetObject<IRequestListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			GlideException p = Java.Lang.Object.GetObject<GlideException>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			ITarget p3 = Java.Lang.Object.GetObject<ITarget>(native_p2, JniHandleOwnership.DoNotTransfer);
			bool p4 = native_p3 != 0;
			return requestListener.OnLoadFailed(p, p2, p3, p4) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnLoadFailed(GlideException? p0, Java.Lang.Object? p1, ITarget p2, bool p3)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			ptr[3] = new JniArgumentValue(p3 ? ((sbyte)1) : ((sbyte)0));
			return _members_com_bumptech_glide_request_RequestListener.InstanceMethods.InvokeAbstractBooleanMethod("onLoadFailed.(Lcom/bumptech/glide/load/engine/GlideException;Ljava/lang/Object;Lcom/bumptech/glide/request/target/Target;Z)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnResourceReady_Ljava_lang_Object_Ljava_lang_Object_Lcom_bumptech_glide_request_target_Target_Lcom_bumptech_glide_load_DataSource_Z(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, nint native_p3, sbyte native_p4)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IRequestListener? requestListener = Java.Lang.Object.GetObject<IRequestListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			ITarget p3 = Java.Lang.Object.GetObject<ITarget>(native_p2, JniHandleOwnership.DoNotTransfer);
			DataSource p4 = Java.Lang.Object.GetObject<DataSource>(native_p3, JniHandleOwnership.DoNotTransfer);
			bool p5 = native_p4 != 0;
			return requestListener.OnResourceReady(p, p2, p3, p4, p5) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnResourceReady(Java.Lang.Object p0, Java.Lang.Object p1, ITarget? p2, DataSource p3, bool p4)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(p4 ? ((sbyte)1) : ((sbyte)0));
			return _members_com_bumptech_glide_request_RequestListener.InstanceMethods.InvokeAbstractBooleanMethod("onResourceReady.(Ljava/lang/Object;Ljava/lang/Object;Lcom/bumptech/glide/request/target/Target;Lcom/bumptech/glide/load/DataSource;Z)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
			GC.KeepAlive(p3);
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
	private static sbyte n_OnLoadFailed_Lcom_bumptech_glide_load_engine_GlideException_Ljava_lang_Object_Lcom_bumptech_glide_request_target_Target_Z_mm_wrapper(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, sbyte native_p3)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnLoadFailed_Lcom_bumptech_glide_load_engine_GlideException_Ljava_lang_Object_Lcom_bumptech_glide_request_target_Target_Z(jnienv, native__this, native_p0, native_p1, native_p2, native_p3);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_OnResourceReady_Ljava_lang_Object_Ljava_lang_Object_Lcom_bumptech_glide_request_target_Target_Lcom_bumptech_glide_load_DataSource_Z_mm_wrapper(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, nint native_p3, sbyte native_p4)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnResourceReady_Ljava_lang_Object_Ljava_lang_Object_Lcom_bumptech_glide_request_target_Target_Lcom_bumptech_glide_load_DataSource_Z(jnienv, native__this, native_p0, native_p1, native_p2, native_p3, native_p4);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
