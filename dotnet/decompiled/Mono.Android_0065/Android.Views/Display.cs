using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/Display", DoNotGenerateAcw = true)]
public class Display : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/Display", typeof(Display));

	private static Delegate? cb_getRefreshRate_GetRefreshRate_F;

	private static Delegate? cb_getRotation_GetRotation_I;

	private static Delegate? cb_getMetrics_GetMetrics_Landroid_util_DisplayMetrics__V;

	private static Delegate? cb_getRealMetrics_GetRealMetrics_Landroid_util_DisplayMetrics__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual float RefreshRate => _members.InstanceMethods.InvokeVirtualSingleMethod("getRefreshRate.()F", this, null);

	public unsafe virtual SurfaceOrientation Rotation => (SurfaceOrientation)_members.InstanceMethods.InvokeVirtualInt32Method("getRotation.()I", this, null);

	protected Display(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetRefreshRateHandler()
	{
		return new _JniMarshal_PP_F(n_GetRefreshRate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetRefreshRate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Display>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RefreshRate;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetRotationHandler()
	{
		return new _JniMarshal_PP_I(n_GetRotation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRotation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<Display>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rotation;
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

	[ObsoletedOSPlatform("android30.0")]
	private static Delegate GetGetMetrics_Landroid_util_DisplayMetrics_Handler()
	{
		return new _JniMarshal_PPL_V(n_GetMetrics_Landroid_util_DisplayMetrics_);
	}

	[ObsoletedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetMetrics_Landroid_util_DisplayMetrics_(nint jnienv, nint native__this, nint native_outMetrics)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Display? display = Java.Lang.Object.GetObject<Display>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DisplayMetrics outMetrics = Java.Lang.Object.GetObject<DisplayMetrics>(native_outMetrics, JniHandleOwnership.DoNotTransfer);
			display.GetMetrics(outMetrics);
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

	[ObsoletedOSPlatform("android30.0")]
	public unsafe virtual void GetMetrics(DisplayMetrics? outMetrics)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outMetrics?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getMetrics.(Landroid/util/DisplayMetrics;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outMetrics);
		}
	}

	[ObsoletedOSPlatform("android31.0")]
	private static Delegate GetGetRealMetrics_Landroid_util_DisplayMetrics_Handler()
	{
		return new _JniMarshal_PPL_V(n_GetRealMetrics_Landroid_util_DisplayMetrics_);
	}

	[ObsoletedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetRealMetrics_Landroid_util_DisplayMetrics_(nint jnienv, nint native__this, nint native_outMetrics)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Display? display = Java.Lang.Object.GetObject<Display>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DisplayMetrics outMetrics = Java.Lang.Object.GetObject<DisplayMetrics>(native_outMetrics, JniHandleOwnership.DoNotTransfer);
			display.GetRealMetrics(outMetrics);
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
	public unsafe virtual void GetRealMetrics(DisplayMetrics? outMetrics)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outMetrics?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getRealMetrics.(Landroid/util/DisplayMetrics;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outMetrics);
		}
	}
}
