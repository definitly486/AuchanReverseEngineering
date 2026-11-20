using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Path", DoNotGenerateAcw = true)]
public class Path : Java.Lang.Object
{
	[Register("android/graphics/Path$Direction", DoNotGenerateAcw = true)]
	public sealed class Direction : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Path$Direction", typeof(Direction));

		[Register("CW")]
		public static Direction? Cw => Java.Lang.Object.GetObject<Direction>(_members.StaticFields.GetObjectValue("CW.Landroid/graphics/Path$Direction;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Direction(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/graphics/Path$FillType", DoNotGenerateAcw = true)]
	public sealed class FillType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Path$FillType", typeof(FillType));

		[Register("INVERSE_WINDING")]
		public static FillType? InverseWinding => Java.Lang.Object.GetObject<FillType>(_members.StaticFields.GetObjectValue("INVERSE_WINDING.Landroid/graphics/Path$FillType;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal FillType(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Path", typeof(Path));

	private static Delegate? cb_addCircle_AddCircle_FFFLandroid_graphics_Path_Direction__V;

	private static Delegate? cb_addRoundRect_AddRoundRect_Landroid_graphics_RectF_FFLandroid_graphics_Path_Direction__V;

	private static Delegate? cb_addRoundRect_AddRoundRect_Landroid_graphics_RectF_arrayFLandroid_graphics_Path_Direction__V;

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_lineTo_LineTo_FF_V;

	private static Delegate? cb_moveTo_MoveTo_FF_V;

	private static Delegate? cb_reset_Reset_V;

	private static Delegate? cb_set_Set_Landroid_graphics_Path__V;

	private static Delegate? cb_setFillType_SetFillType_Landroid_graphics_Path_FillType__V;

	private static Delegate? cb_transform_Transform_Landroid_graphics_Matrix__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Path(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Path()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetAddCircle_FFFLandroid_graphics_Path_Direction_Handler()
	{
		return new _JniMarshal_PPFFFL_V(n_AddCircle_FFFLandroid_graphics_Path_Direction_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCircle_FFFLandroid_graphics_Path_Direction_(nint jnienv, nint native__this, float x, float y, float radius, nint native_dir)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Path? path = Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Direction dir = Java.Lang.Object.GetObject<Direction>(native_dir, JniHandleOwnership.DoNotTransfer);
			path.AddCircle(x, y, radius, dir);
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

	[Register("addCircle", "(FFFLandroid/graphics/Path$Direction;)V", "GetAddCircle_FFFLandroid_graphics_Path_Direction_Handler")]
	public unsafe virtual void AddCircle(float x, float y, float radius, Direction dir)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			ptr[2] = new JniArgumentValue(radius);
			ptr[3] = new JniArgumentValue(dir?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCircle.(FFFLandroid/graphics/Path$Direction;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dir);
		}
	}

	private static Delegate GetAddRoundRect_Landroid_graphics_RectF_FFLandroid_graphics_Path_Direction_Handler()
	{
		return new _JniMarshal_PPLFFL_V(n_AddRoundRect_Landroid_graphics_RectF_FFLandroid_graphics_Path_Direction_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddRoundRect_Landroid_graphics_RectF_FFLandroid_graphics_Path_Direction_(nint jnienv, nint native__this, nint native_rect, float rx, float ry, nint native_dir)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Path? path = Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RectF rect = Java.Lang.Object.GetObject<RectF>(native_rect, JniHandleOwnership.DoNotTransfer);
			Direction dir = Java.Lang.Object.GetObject<Direction>(native_dir, JniHandleOwnership.DoNotTransfer);
			path.AddRoundRect(rect, rx, ry, dir);
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

	[Register("addRoundRect", "(Landroid/graphics/RectF;FFLandroid/graphics/Path$Direction;)V", "GetAddRoundRect_Landroid_graphics_RectF_FFLandroid_graphics_Path_Direction_Handler")]
	public unsafe virtual void AddRoundRect(RectF rect, float rx, float ry, Direction dir)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(rx);
			ptr[2] = new JniArgumentValue(ry);
			ptr[3] = new JniArgumentValue(dir?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addRoundRect.(Landroid/graphics/RectF;FFLandroid/graphics/Path$Direction;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(rect);
			GC.KeepAlive(dir);
		}
	}

	private static Delegate GetAddRoundRect_Landroid_graphics_RectF_arrayFLandroid_graphics_Path_Direction_Handler()
	{
		return new _JniMarshal_PPLLL_V(n_AddRoundRect_Landroid_graphics_RectF_arrayFLandroid_graphics_Path_Direction_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddRoundRect_Landroid_graphics_RectF_arrayFLandroid_graphics_Path_Direction_(nint jnienv, nint native__this, nint native_rect, nint native_radii, nint native_dir)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Path? path = Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RectF rect = Java.Lang.Object.GetObject<RectF>(native_rect, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_radii, JniHandleOwnership.DoNotTransfer, typeof(float));
			Direction dir = Java.Lang.Object.GetObject<Direction>(native_dir, JniHandleOwnership.DoNotTransfer);
			path.AddRoundRect(rect, array, dir);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_radii);
			}
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

	[Register("addRoundRect", "(Landroid/graphics/RectF;[FLandroid/graphics/Path$Direction;)V", "GetAddRoundRect_Landroid_graphics_RectF_arrayFLandroid_graphics_Path_Direction_Handler")]
	public unsafe virtual void AddRoundRect(RectF rect, float[] radii, Direction dir)
	{
		nint num = JNIEnv.NewArray(radii);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(dir?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addRoundRect.(Landroid/graphics/RectF;[FLandroid/graphics/Path$Direction;)V", this, ptr);
		}
		finally
		{
			if (radii != null)
			{
				JNIEnv.CopyArray(num, radii);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(rect);
			GC.KeepAlive(radii);
			GC.KeepAlive(dir);
		}
	}

	private static Delegate GetCloseHandler()
	{
		return new _JniMarshal_PP_V(n_Close);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	[Register("close", "()V", "GetCloseHandler")]
	public unsafe virtual void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}

	private static Delegate GetLineTo_FFHandler()
	{
		return new _JniMarshal_PPFF_V(n_LineTo_FF);
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
			Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineTo(x, y);
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

	private static Delegate GetMoveTo_FFHandler()
	{
		return new _JniMarshal_PPFF_V(n_MoveTo_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_MoveTo_FF(nint jnienv, nint native__this, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveTo(x, y);
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

	[Register("moveTo", "(FF)V", "GetMoveTo_FFHandler")]
	public unsafe virtual void MoveTo(float x, float y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("moveTo.(FF)V", this, ptr);
	}

	private static Delegate GetResetHandler()
	{
		return new _JniMarshal_PP_V(n_Reset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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

	[Register("reset", "()V", "GetResetHandler")]
	public unsafe virtual void Reset()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
	}

	private static Delegate GetSet_Landroid_graphics_Path_Handler()
	{
		return new _JniMarshal_PPL_V(n_Set_Landroid_graphics_Path_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Set_Landroid_graphics_Path_(nint jnienv, nint native__this, nint native_src)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Path? path = Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Path src = Java.Lang.Object.GetObject<Path>(native_src, JniHandleOwnership.DoNotTransfer);
			path.Set(src);
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

	[Register("set", "(Landroid/graphics/Path;)V", "GetSet_Landroid_graphics_Path_Handler")]
	public unsafe virtual void Set(Path src)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("set.(Landroid/graphics/Path;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(src);
		}
	}

	private static Delegate GetSetFillType_Landroid_graphics_Path_FillType_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetFillType_Landroid_graphics_Path_FillType_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFillType_Landroid_graphics_Path_FillType_(nint jnienv, nint native__this, nint native_ft)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Path? path = Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FillType fillType = Java.Lang.Object.GetObject<FillType>(native_ft, JniHandleOwnership.DoNotTransfer);
			path.SetFillType(fillType);
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

	[Register("setFillType", "(Landroid/graphics/Path$FillType;)V", "GetSetFillType_Landroid_graphics_Path_FillType_Handler")]
	public unsafe virtual void SetFillType(FillType ft)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ft?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFillType.(Landroid/graphics/Path$FillType;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ft);
		}
	}

	private static Delegate GetTransform_Landroid_graphics_Matrix_Handler()
	{
		return new _JniMarshal_PPL_V(n_Transform_Landroid_graphics_Matrix_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Transform_Landroid_graphics_Matrix_(nint jnienv, nint native__this, nint native_matrix)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Path? path = Java.Lang.Object.GetObject<Path>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Matrix matrix = Java.Lang.Object.GetObject<Matrix>(native_matrix, JniHandleOwnership.DoNotTransfer);
			path.Transform(matrix);
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

	[Register("transform", "(Landroid/graphics/Matrix;)V", "GetTransform_Landroid_graphics_Matrix_Handler")]
	public unsafe virtual void Transform(Matrix matrix)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(matrix?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("transform.(Landroid/graphics/Matrix;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(matrix);
		}
	}
}
