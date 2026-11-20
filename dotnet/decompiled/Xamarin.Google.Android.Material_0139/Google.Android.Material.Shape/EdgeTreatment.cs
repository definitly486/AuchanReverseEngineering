using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Shape;

[Register("com/google/android/material/shape/EdgeTreatment", DoNotGenerateAcw = true)]
public class EdgeTreatment : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/EdgeTreatment", typeof(EdgeTreatment));

	private static Delegate? cb_getEdgePath_GetEdgePath_FFLcom_google_android_material_shape_ShapePath__V;

	private static Delegate? cb_getEdgePath_GetEdgePath_FFFLcom_google_android_material_shape_ShapePath__V;

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

	protected EdgeTreatment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe EdgeTreatment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Obsolete]
	private static Delegate GetGetEdgePath_FFLcom_google_android_material_shape_ShapePath_Handler()
	{
		return new _JniMarshal_PPFFL_V(n_GetEdgePath_FFLcom_google_android_material_shape_ShapePath_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetEdgePath_FFLcom_google_android_material_shape_ShapePath_(nint jnienv, nint native__this, float length, float interpolation, nint native_shapePath)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			EdgeTreatment? edgeTreatment = Java.Lang.Object.GetObject<EdgeTreatment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapePath shapePath = Java.Lang.Object.GetObject<ShapePath>(native_shapePath, JniHandleOwnership.DoNotTransfer);
			edgeTreatment.GetEdgePath(length, interpolation, shapePath);
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

	[Obsolete("deprecated")]
	[Register("getEdgePath", "(FFLcom/google/android/material/shape/ShapePath;)V", "GetGetEdgePath_FFLcom_google_android_material_shape_ShapePath_Handler")]
	public unsafe virtual void GetEdgePath(float length, float interpolation, ShapePath shapePath)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(length);
			ptr[1] = new JniArgumentValue(interpolation);
			ptr[2] = new JniArgumentValue(shapePath?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getEdgePath.(FFLcom/google/android/material/shape/ShapePath;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(shapePath);
		}
	}

	private static Delegate GetGetEdgePath_FFFLcom_google_android_material_shape_ShapePath_Handler()
	{
		return new global::_JniMarshal_PPFFFL_V(n_GetEdgePath_FFFLcom_google_android_material_shape_ShapePath_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetEdgePath_FFFLcom_google_android_material_shape_ShapePath_(nint jnienv, nint native__this, float length, float center, float interpolation, nint native_shapePath)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			EdgeTreatment? edgeTreatment = Java.Lang.Object.GetObject<EdgeTreatment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapePath shapePath = Java.Lang.Object.GetObject<ShapePath>(native_shapePath, JniHandleOwnership.DoNotTransfer);
			edgeTreatment.GetEdgePath(length, center, interpolation, shapePath);
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

	[Register("getEdgePath", "(FFFLcom/google/android/material/shape/ShapePath;)V", "GetGetEdgePath_FFFLcom_google_android_material_shape_ShapePath_Handler")]
	public unsafe virtual void GetEdgePath(float length, float center, float interpolation, ShapePath shapePath)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(length);
			ptr[1] = new JniArgumentValue(center);
			ptr[2] = new JniArgumentValue(interpolation);
			ptr[3] = new JniArgumentValue(shapePath?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getEdgePath.(FFFLcom/google/android/material/shape/ShapePath;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(shapePath);
		}
	}
}
