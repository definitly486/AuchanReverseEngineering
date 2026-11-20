using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Shape;

[Register("com/google/android/material/shape/CornerTreatment", DoNotGenerateAcw = true)]
public class CornerTreatment : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/CornerTreatment", typeof(CornerTreatment));

	private static Delegate? cb_getCornerPath_GetCornerPath_Lcom_google_android_material_shape_ShapePath_FFLandroid_graphics_RectF_Lcom_google_android_material_shape_CornerSize__V;

	private static Delegate? cb_getCornerPath_GetCornerPath_Lcom_google_android_material_shape_ShapePath_FFF_V;

	private static Delegate? cb_getCornerPath_GetCornerPath_FFLcom_google_android_material_shape_ShapePath__V;

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

	protected CornerTreatment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe CornerTreatment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCornerPath_Lcom_google_android_material_shape_ShapePath_FFLandroid_graphics_RectF_Lcom_google_android_material_shape_CornerSize_Handler()
	{
		return new _JniMarshal_PPLFFLL_V(n_GetCornerPath_Lcom_google_android_material_shape_ShapePath_FFLandroid_graphics_RectF_Lcom_google_android_material_shape_CornerSize_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetCornerPath_Lcom_google_android_material_shape_ShapePath_FFLandroid_graphics_RectF_Lcom_google_android_material_shape_CornerSize_(nint jnienv, nint native__this, nint native_shapePath, float angle, float interpolation, nint native_bounds, nint native_size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CornerTreatment? cornerTreatment = Java.Lang.Object.GetObject<CornerTreatment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapePath shapePath = Java.Lang.Object.GetObject<ShapePath>(native_shapePath, JniHandleOwnership.DoNotTransfer);
			RectF bounds = Java.Lang.Object.GetObject<RectF>(native_bounds, JniHandleOwnership.DoNotTransfer);
			ICornerSize size = Java.Lang.Object.GetObject<ICornerSize>(native_size, JniHandleOwnership.DoNotTransfer);
			cornerTreatment.GetCornerPath(shapePath, angle, interpolation, bounds, size);
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

	[Register("getCornerPath", "(Lcom/google/android/material/shape/ShapePath;FFLandroid/graphics/RectF;Lcom/google/android/material/shape/CornerSize;)V", "GetGetCornerPath_Lcom_google_android_material_shape_ShapePath_FFLandroid_graphics_RectF_Lcom_google_android_material_shape_CornerSize_Handler")]
	public unsafe virtual void GetCornerPath(ShapePath shapePath, float angle, float interpolation, RectF bounds, ICornerSize size)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(shapePath?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(angle);
			ptr[2] = new JniArgumentValue(interpolation);
			ptr[3] = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue((size == null) ? IntPtr.Zero : ((Java.Lang.Object)size).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getCornerPath.(Lcom/google/android/material/shape/ShapePath;FFLandroid/graphics/RectF;Lcom/google/android/material/shape/CornerSize;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(shapePath);
			GC.KeepAlive(bounds);
			GC.KeepAlive(size);
		}
	}

	private static Delegate GetGetCornerPath_Lcom_google_android_material_shape_ShapePath_FFFHandler()
	{
		return new _JniMarshal_PPLFFF_V(n_GetCornerPath_Lcom_google_android_material_shape_ShapePath_FFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetCornerPath_Lcom_google_android_material_shape_ShapePath_FFF(nint jnienv, nint native__this, nint native_shapePath, float angle, float interpolation, float radius)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CornerTreatment? cornerTreatment = Java.Lang.Object.GetObject<CornerTreatment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapePath shapePath = Java.Lang.Object.GetObject<ShapePath>(native_shapePath, JniHandleOwnership.DoNotTransfer);
			cornerTreatment.GetCornerPath(shapePath, angle, interpolation, radius);
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

	[Register("getCornerPath", "(Lcom/google/android/material/shape/ShapePath;FFF)V", "GetGetCornerPath_Lcom_google_android_material_shape_ShapePath_FFFHandler")]
	public unsafe virtual void GetCornerPath(ShapePath shapePath, float angle, float interpolation, float radius)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(shapePath?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(angle);
			ptr[2] = new JniArgumentValue(interpolation);
			ptr[3] = new JniArgumentValue(radius);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getCornerPath.(Lcom/google/android/material/shape/ShapePath;FFF)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(shapePath);
		}
	}

	[Obsolete]
	private static Delegate GetGetCornerPath_FFLcom_google_android_material_shape_ShapePath_Handler()
	{
		return new _JniMarshal_PPFFL_V(n_GetCornerPath_FFLcom_google_android_material_shape_ShapePath_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetCornerPath_FFLcom_google_android_material_shape_ShapePath_(nint jnienv, nint native__this, float angle, float interpolation, nint native_shapePath)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CornerTreatment? cornerTreatment = Java.Lang.Object.GetObject<CornerTreatment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapePath shapePath = Java.Lang.Object.GetObject<ShapePath>(native_shapePath, JniHandleOwnership.DoNotTransfer);
			cornerTreatment.GetCornerPath(angle, interpolation, shapePath);
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
	[Register("getCornerPath", "(FFLcom/google/android/material/shape/ShapePath;)V", "GetGetCornerPath_FFLcom_google_android_material_shape_ShapePath_Handler")]
	public unsafe virtual void GetCornerPath(float angle, float interpolation, ShapePath shapePath)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(angle);
			ptr[1] = new JniArgumentValue(interpolation);
			ptr[2] = new JniArgumentValue(shapePath?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getCornerPath.(FFLcom/google/android/material/shape/ShapePath;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(shapePath);
		}
	}
}
