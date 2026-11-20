using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Android.Runtime;
using Bumptech.Glide.Load.Engine.BitmapRecycle;
using Java.Interop;
using Java.Lang;
using Java.Nio;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/ImageHeaderParser", DoNotGenerateAcw = true)]
internal class IImageHeaderParserInvoker : Java.Lang.Object, IImageHeaderParser, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_ImageHeaderParser = new XAPeerMembers("com/bumptech/glide/load/ImageHeaderParser", typeof(IImageHeaderParserInvoker));

	private static Delegate? cb_getOrientation_GetOrientation_Ljava_io_InputStream_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool__I;

	private static Delegate? cb_getOrientation_GetOrientation_Ljava_nio_ByteBuffer_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool__I;

	private static Delegate? cb_getType_GetType_Ljava_io_InputStream__Lcom_bumptech_glide_load_ImageHeaderParser_ImageType_;

	private static Delegate? cb_getType_GetType_Ljava_nio_ByteBuffer__Lcom_bumptech_glide_load_ImageHeaderParser_ImageType_;

	private static nint java_class_ref => _members_com_bumptech_glide_load_ImageHeaderParser.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_ImageHeaderParser;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_ImageHeaderParser.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_ImageHeaderParser.ManagedPeerType;

	public IImageHeaderParserInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetOrientation_Ljava_io_InputStream_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool_Handler()
	{
		return new global::_JniMarshal_PPLL_I(n_GetOrientation_Ljava_io_InputStream_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOrientation_Ljava_io_InputStream_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IImageHeaderParser? imageHeaderParser = Java.Lang.Object.GetObject<IImageHeaderParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Stream p = InputStreamInvoker.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
			IArrayPool p2 = Java.Lang.Object.GetObject<IArrayPool>(native_p1, JniHandleOwnership.DoNotTransfer);
			return imageHeaderParser.GetOrientation(p, p2);
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

	public unsafe int GetOrientation(Stream p0, IArrayPool p1)
	{
		nint num = InputStreamAdapter.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return _members_com_bumptech_glide_load_ImageHeaderParser.InstanceMethods.InvokeAbstractInt32Method("getOrientation.(Ljava/io/InputStream;Lcom/bumptech/glide/load/engine/bitmap_recycle/ArrayPool;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetGetOrientation_Ljava_nio_ByteBuffer_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool_Handler()
	{
		return new global::_JniMarshal_PPLL_I(n_GetOrientation_Ljava_nio_ByteBuffer_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOrientation_Ljava_nio_ByteBuffer_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IImageHeaderParser? imageHeaderParser = Java.Lang.Object.GetObject<IImageHeaderParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer p = Java.Lang.Object.GetObject<ByteBuffer>(native_p0, JniHandleOwnership.DoNotTransfer);
			IArrayPool p2 = Java.Lang.Object.GetObject<IArrayPool>(native_p1, JniHandleOwnership.DoNotTransfer);
			return imageHeaderParser.GetOrientation(p, p2);
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

	public unsafe int GetOrientation(ByteBuffer p0, IArrayPool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return _members_com_bumptech_glide_load_ImageHeaderParser.InstanceMethods.InvokeAbstractInt32Method("getOrientation.(Ljava/nio/ByteBuffer;Lcom/bumptech/glide/load/engine/bitmap_recycle/ArrayPool;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetGetType_Ljava_io_InputStream_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetType_Ljava_io_InputStream_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType_Ljava_io_InputStream_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IImageHeaderParser? imageHeaderParser = Java.Lang.Object.GetObject<IImageHeaderParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Stream p = InputStreamInvoker.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(imageHeaderParser.GetType(p));
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

	public unsafe ImageHeaderParserImageType GetType(Stream p0)
	{
		nint num = InputStreamAdapter.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members_com_bumptech_glide_load_ImageHeaderParser.InstanceMethods.InvokeAbstractObjectMethod("getType.(Ljava/io/InputStream;)Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetGetType_Ljava_nio_ByteBuffer_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetType_Ljava_nio_ByteBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType_Ljava_nio_ByteBuffer_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IImageHeaderParser? imageHeaderParser = Java.Lang.Object.GetObject<IImageHeaderParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer p = Java.Lang.Object.GetObject<ByteBuffer>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(imageHeaderParser.GetType(p));
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

	public unsafe ImageHeaderParserImageType GetType(ByteBuffer p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members_com_bumptech_glide_load_ImageHeaderParser.InstanceMethods.InvokeAbstractObjectMethod("getType.(Ljava/nio/ByteBuffer;)Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
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
