using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Shape;

[Register("com/google/android/material/shape/ShapePath", DoNotGenerateAcw = true)]
public class ShapePath : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/ShapePath", typeof(ShapePath));

	private static Delegate? cb_addArc_AddArc_FFFFFF_V;

	private static Delegate? cb_applyToPath_ApplyToPath_Landroid_graphics_Matrix_Landroid_graphics_Path__V;

	private static Delegate? cb_cubicToPoint_CubicToPoint_FFFFFF_V;

	private static Delegate? cb_lineTo_LineTo_FF_V;

	private static Delegate? cb_lineTo_LineTo_FFFF_V;

	private static Delegate? cb_quadToPoint_QuadToPoint_FFFF_V;

	private static Delegate? cb_reset_Reset_FF_V;

	private static Delegate? cb_reset_Reset_FFFF_V;

	[Register("currentShadowAngle")]
	[Obsolete("deprecated")]
	public float CurrentShadowAngle
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("currentShadowAngle.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("currentShadowAngle.F", this, value);
		}
	}

	[Register("endShadowAngle")]
	[Obsolete("deprecated")]
	public float EndShadowAngle
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("endShadowAngle.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("endShadowAngle.F", this, value);
		}
	}

	[Register("endX")]
	[Obsolete("deprecated")]
	public float EndX
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("endX.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("endX.F", this, value);
		}
	}

	[Register("endY")]
	[Obsolete("deprecated")]
	public float EndY
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("endY.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("endY.F", this, value);
		}
	}

	[Register("startX")]
	[Obsolete("deprecated")]
	public float StartX
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("startX.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("startX.F", this, value);
		}
	}

	[Register("startY")]
	[Obsolete("deprecated")]
	public float StartY
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("startY.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("startY.F", this, value);
		}
	}

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

	protected ShapePath(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ShapePath()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(FF)V", "")]
	public unsafe ShapePath(float startX, float startY)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(startX);
			ptr[1] = new JniArgumentValue(startY);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FF)V", this, ptr);
		}
	}

	private static Delegate GetAddArc_FFFFFFHandler()
	{
		return new global::_JniMarshal_PPFFFFFF_V(n_AddArc_FFFFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddArc_FFFFFF(nint jnienv, nint native__this, float left, float top, float right, float bottom, float startAngle, float sweepAngle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ShapePath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddArc(left, top, right, bottom, startAngle, sweepAngle);
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

	[Register("addArc", "(FFFFFF)V", "GetAddArc_FFFFFFHandler")]
	public unsafe virtual void AddArc(float left, float top, float right, float bottom, float startAngle, float sweepAngle)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		ptr[4] = new JniArgumentValue(startAngle);
		ptr[5] = new JniArgumentValue(sweepAngle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("addArc.(FFFFFF)V", this, ptr);
	}

	private static Delegate GetApplyToPath_Landroid_graphics_Matrix_Landroid_graphics_Path_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_ApplyToPath_Landroid_graphics_Matrix_Landroid_graphics_Path_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyToPath_Landroid_graphics_Matrix_Landroid_graphics_Path_(nint jnienv, nint native__this, nint native_transform, nint native_path)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePath? shapePath = Java.Lang.Object.GetObject<ShapePath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Matrix transform = Java.Lang.Object.GetObject<Matrix>(native_transform, JniHandleOwnership.DoNotTransfer);
			Path path = Java.Lang.Object.GetObject<Path>(native_path, JniHandleOwnership.DoNotTransfer);
			shapePath.ApplyToPath(transform, path);
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

	[Register("applyToPath", "(Landroid/graphics/Matrix;Landroid/graphics/Path;)V", "GetApplyToPath_Landroid_graphics_Matrix_Landroid_graphics_Path_Handler")]
	public unsafe virtual void ApplyToPath(Matrix? transform, Path? path)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(transform?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(path?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyToPath.(Landroid/graphics/Matrix;Landroid/graphics/Path;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transform);
			GC.KeepAlive(path);
		}
	}

	private static Delegate GetCubicToPoint_FFFFFFHandler()
	{
		return new global::_JniMarshal_PPFFFFFF_V(n_CubicToPoint_FFFFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CubicToPoint_FFFFFF(nint jnienv, nint native__this, float controlX1, float controlY1, float controlX2, float controlY2, float toX, float toY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ShapePath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CubicToPoint(controlX1, controlY1, controlX2, controlY2, toX, toY);
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

	[Register("cubicToPoint", "(FFFFFF)V", "GetCubicToPoint_FFFFFFHandler")]
	public unsafe virtual void CubicToPoint(float controlX1, float controlY1, float controlX2, float controlY2, float toX, float toY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(controlX1);
		ptr[1] = new JniArgumentValue(controlY1);
		ptr[2] = new JniArgumentValue(controlX2);
		ptr[3] = new JniArgumentValue(controlY2);
		ptr[4] = new JniArgumentValue(toX);
		ptr[5] = new JniArgumentValue(toY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("cubicToPoint.(FFFFFF)V", this, ptr);
	}

	private static Delegate GetLineTo_FFHandler()
	{
		return new global::_JniMarshal_PPFF_V(n_LineTo_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LineTo_FF(nint jnienv, nint native__this, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ShapePath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineTo(x, y);
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

	[Register("lineTo", "(FF)V", "GetLineTo_FFHandler")]
	public unsafe virtual void LineTo(float x, float y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("lineTo.(FF)V", this, ptr);
	}

	private static Delegate GetLineTo_FFFFHandler()
	{
		return new global::_JniMarshal_PPFFFF_V(n_LineTo_FFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LineTo_FFFF(nint jnienv, nint native__this, float x1, float y1, float x2, float y2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ShapePath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineTo(x1, y1, x2, y2);
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

	[Register("lineTo", "(FFFF)V", "GetLineTo_FFFFHandler")]
	public unsafe virtual void LineTo(float x1, float y1, float x2, float y2)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(x1);
		ptr[1] = new JniArgumentValue(y1);
		ptr[2] = new JniArgumentValue(x2);
		ptr[3] = new JniArgumentValue(y2);
		_members.InstanceMethods.InvokeVirtualVoidMethod("lineTo.(FFFF)V", this, ptr);
	}

	private static Delegate GetQuadToPoint_FFFFHandler()
	{
		return new global::_JniMarshal_PPFFFF_V(n_QuadToPoint_FFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_QuadToPoint_FFFF(nint jnienv, nint native__this, float controlX, float controlY, float toX, float toY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ShapePath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).QuadToPoint(controlX, controlY, toX, toY);
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

	[Register("quadToPoint", "(FFFF)V", "GetQuadToPoint_FFFFHandler")]
	public unsafe virtual void QuadToPoint(float controlX, float controlY, float toX, float toY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(controlX);
		ptr[1] = new JniArgumentValue(controlY);
		ptr[2] = new JniArgumentValue(toX);
		ptr[3] = new JniArgumentValue(toY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("quadToPoint.(FFFF)V", this, ptr);
	}

	private static Delegate GetReset_FFHandler()
	{
		return new global::_JniMarshal_PPFF_V(n_Reset_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reset_FF(nint jnienv, nint native__this, float startX, float startY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ShapePath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset(startX, startY);
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

	[Register("reset", "(FF)V", "GetReset_FFHandler")]
	public unsafe virtual void Reset(float startX, float startY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(startX);
		ptr[1] = new JniArgumentValue(startY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("reset.(FF)V", this, ptr);
	}

	private static Delegate GetReset_FFFFHandler()
	{
		return new global::_JniMarshal_PPFFFF_V(n_Reset_FFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reset_FFFF(nint jnienv, nint native__this, float startX, float startY, float shadowStartAngle, float shadowSweepAngle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ShapePath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset(startX, startY, shadowStartAngle, shadowSweepAngle);
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

	[Register("reset", "(FFFF)V", "GetReset_FFFFHandler")]
	public unsafe virtual void Reset(float startX, float startY, float shadowStartAngle, float shadowSweepAngle)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(startX);
		ptr[1] = new JniArgumentValue(startY);
		ptr[2] = new JniArgumentValue(shadowStartAngle);
		ptr[3] = new JniArgumentValue(shadowSweepAngle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("reset.(FFFF)V", this, ptr);
	}
}
