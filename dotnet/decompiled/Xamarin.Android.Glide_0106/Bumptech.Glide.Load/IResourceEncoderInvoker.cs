using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/ResourceEncoder", DoNotGenerateAcw = true)]
internal class IResourceEncoderInvoker : Java.Lang.Object, IResourceEncoder, IEncoder, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_Encoder = new XAPeerMembers("com/bumptech/glide/load/Encoder", typeof(IResourceEncoderInvoker));

	private static readonly JniPeerMembers _members_com_bumptech_glide_load_ResourceEncoder = new XAPeerMembers("com/bumptech/glide/load/ResourceEncoder", typeof(IResourceEncoderInvoker));

	private static Delegate? cb_getEncodeStrategy_GetEncodeStrategy_Lcom_bumptech_glide_load_Options__Lcom_bumptech_glide_load_EncodeStrategy_;

	private static Delegate? cb_encode_Encode_Ljava_lang_Object_Ljava_io_File_Lcom_bumptech_glide_load_Options__Z;

	private static nint java_class_ref => _members_com_bumptech_glide_load_ResourceEncoder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_ResourceEncoder;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_ResourceEncoder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_ResourceEncoder.ManagedPeerType;

	public IResourceEncoderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetEncodeStrategy_Lcom_bumptech_glide_load_Options_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetEncodeStrategy_Lcom_bumptech_glide_load_Options_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEncodeStrategy_Lcom_bumptech_glide_load_Options_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IResourceEncoder? resourceEncoder = Java.Lang.Object.GetObject<IResourceEncoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Options p = Java.Lang.Object.GetObject<Options>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(resourceEncoder.GetEncodeStrategy(p));
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

	public unsafe EncodeStrategy GetEncodeStrategy(Options p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<EncodeStrategy>(_members_com_bumptech_glide_load_ResourceEncoder.InstanceMethods.InvokeAbstractObjectMethod("getEncodeStrategy.(Lcom/bumptech/glide/load/Options;)Lcom/bumptech/glide/load/EncodeStrategy;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetEncode_Ljava_lang_Object_Ljava_io_File_Lcom_bumptech_glide_load_Options_Handler()
	{
		return new global::_JniMarshal_PPLLL_B(n_Encode_Ljava_lang_Object_Ljava_io_File_Lcom_bumptech_glide_load_Options_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Encode_Ljava_lang_Object_Ljava_io_File_Lcom_bumptech_glide_load_Options_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IResourceEncoder? resourceEncoder = Java.Lang.Object.GetObject<IResourceEncoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			File p2 = Java.Lang.Object.GetObject<File>(native_p1, JniHandleOwnership.DoNotTransfer);
			Options p3 = Java.Lang.Object.GetObject<Options>(native_p2, JniHandleOwnership.DoNotTransfer);
			return resourceEncoder.Encode(p, p2, p3) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Encode(Java.Lang.Object p0, File p1, Options p2)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			return _members_com_bumptech_glide_load_Encoder.InstanceMethods.InvokeAbstractBooleanMethod("encode.(Ljava/lang/Object;Ljava/io/File;Lcom/bumptech/glide/load/Options;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
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
