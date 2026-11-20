using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/DiskCache$Writer", DoNotGenerateAcw = true)]
internal class IDiskCacheWriterInvoker : Java.Lang.Object, IDiskCacheWriter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_cache_DiskCache_Writer = new XAPeerMembers("com/bumptech/glide/load/engine/cache/DiskCache$Writer", typeof(IDiskCacheWriterInvoker));

	private static Delegate? cb_write_Write_Ljava_io_File__Z;

	private static nint java_class_ref => _members_com_bumptech_glide_load_engine_cache_DiskCache_Writer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_cache_DiskCache_Writer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_cache_DiskCache_Writer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_cache_DiskCache_Writer.ManagedPeerType;

	public IDiskCacheWriterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetWrite_Ljava_io_File_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Write_Ljava_io_File_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Write_Ljava_io_File_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IDiskCacheWriter? diskCacheWriter = Java.Lang.Object.GetObject<IDiskCacheWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			File p = Java.Lang.Object.GetObject<File>(native_p0, JniHandleOwnership.DoNotTransfer);
			return diskCacheWriter.Write(p) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Write(File p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members_com_bumptech_glide_load_engine_cache_DiskCache_Writer.InstanceMethods.InvokeAbstractBooleanMethod("write.(Ljava/io/File;)Z", this, ptr);
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
