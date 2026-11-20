using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Renderscripts;

[ObsoletedOSPlatform("android31.0", "This class is obsoleted in this android platform")]
[Register("android/renderscript/Allocation", DoNotGenerateAcw = true)]
public class Allocation : BaseObj
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/renderscript/Allocation", typeof(Allocation));

	private static Delegate? cb_getType_GetType_Landroid_renderscript_Type_;

	private static Delegate? cb_copyTo_CopyTo_Landroid_graphics_Bitmap__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	[ObsoletedOSPlatform("android31.0")]
	public unsafe virtual Type? Type => Java.Lang.Object.GetObject<Type>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Landroid/renderscript/Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	protected Allocation(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android31.0")]
	private static Delegate GetGetTypeHandler()
	{
		return new _JniMarshal_PP_L(n_GetType);
	}

	[ObsoletedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Allocation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
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

	[ObsoletedOSPlatform("android31.0")]
	private static Delegate GetCopyTo_Landroid_graphics_Bitmap_Handler()
	{
		return new _JniMarshal_PPL_V(n_CopyTo_Landroid_graphics_Bitmap_);
	}

	[ObsoletedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CopyTo_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Allocation? allocation = Java.Lang.Object.GetObject<Allocation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap b = Java.Lang.Object.GetObject<Bitmap>(native_b, JniHandleOwnership.DoNotTransfer);
			allocation.CopyTo(b);
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

	[ObsoletedOSPlatform("android31.0")]
	public unsafe virtual void CopyTo(Bitmap? b)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("copyTo.(Landroid/graphics/Bitmap;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(b);
		}
	}

	[ObsoletedOSPlatform("android31.0")]
	public unsafe static Allocation? CreateFromBitmap(RenderScript? rs, Bitmap? b)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(rs?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Allocation>(_members.StaticMethods.InvokeObjectMethod("createFromBitmap.(Landroid/renderscript/RenderScript;Landroid/graphics/Bitmap;)Landroid/renderscript/Allocation;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(rs);
			GC.KeepAlive(b);
		}
	}

	[ObsoletedOSPlatform("android31.0")]
	public unsafe static Allocation? CreateTyped(RenderScript? rs, Type? type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(rs?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Allocation>(_members.StaticMethods.InvokeObjectMethod("createTyped.(Landroid/renderscript/RenderScript;Landroid/renderscript/Type;)Landroid/renderscript/Allocation;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(rs);
			GC.KeepAlive(type);
		}
	}
}
