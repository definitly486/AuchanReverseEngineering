using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics.Drawables;

[Register("android/graphics/drawable/GradientDrawable", DoNotGenerateAcw = true)]
public class GradientDrawable : Drawable
{
	[Register("android/graphics/drawable/GradientDrawable$Orientation", DoNotGenerateAcw = true)]
	public sealed class Orientation : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/GradientDrawable$Orientation", typeof(Orientation));

		[Register("LEFT_RIGHT")]
		public static Orientation? LeftRight => Java.Lang.Object.GetObject<Orientation>(_members.StaticFields.GetObjectValue("LEFT_RIGHT.Landroid/graphics/drawable/GradientDrawable$Orientation;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Orientation(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/GradientDrawable", typeof(GradientDrawable));

	private static Delegate? cb_getOpacity_GetOpacity_I;

	private static Delegate? cb_draw_Draw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_getCornerRadii_GetCornerRadii_arrayF;

	private static Delegate? cb_setAlpha_SetAlpha_I_V;

	private static Delegate? cb_setColor_SetColor_I_V;

	private static Delegate? cb_setColorFilter_SetColorFilter_Landroid_graphics_ColorFilter__V;

	private static Delegate? cb_setCornerRadii_SetCornerRadii_arrayF_V;

	private static Delegate? cb_setCornerRadius_SetCornerRadius_F_V;

	private static Delegate? cb_setShape_SetShape_I_V;

	private static Delegate? cb_setStroke_SetStroke_II_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int Opacity
	{
		[Register("getOpacity", "()I", "GetGetOpacityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOpacity.()I", this, null);
		}
	}

	protected GradientDrawable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe GradientDrawable()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/graphics/drawable/GradientDrawable$Orientation;[I)V", "")]
	public unsafe GradientDrawable(Orientation? orientation, int[]? colors)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewArray(colors);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(orientation?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/drawable/GradientDrawable$Orientation;[I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/drawable/GradientDrawable$Orientation;[I)V", this, ptr);
		}
		finally
		{
			if (colors != null)
			{
				JNIEnv.CopyArray(num, colors);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(orientation);
			GC.KeepAlive(colors);
		}
	}

	private static Delegate GetGetOpacityHandler()
	{
		return new _JniMarshal_PP_I(n_GetOpacity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOpacity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Opacity;
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

	private static Delegate GetDraw_Landroid_graphics_Canvas_Handler()
	{
		return new _JniMarshal_PPL_V(n_Draw_Landroid_graphics_Canvas_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Draw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_canvas)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GradientDrawable? gradientDrawable = Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			gradientDrawable.Draw(canvas);
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

	[Register("draw", "(Landroid/graphics/Canvas;)V", "GetDraw_Landroid_graphics_Canvas_Handler")]
	public unsafe override void Draw(Canvas? canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("draw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetGetCornerRadiiHandler()
	{
		return new _JniMarshal_PP_L(n_GetCornerRadii);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCornerRadii(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetCornerRadii());
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

	[SupportedOSPlatform("android24.0")]
	[Register("getCornerRadii", "()[F", "GetGetCornerRadiiHandler", ApiSince = 24)]
	public unsafe virtual float[]? GetCornerRadii()
	{
		return (float[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getCornerRadii.()[F", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(float));
	}

	private static Delegate GetSetAlpha_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetAlpha_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAlpha_I(nint jnienv, nint native__this, int alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlpha(alpha);
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

	[Register("setAlpha", "(I)V", "GetSetAlpha_IHandler")]
	public unsafe override void SetAlpha(int alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(alpha);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAlpha.(I)V", this, ptr);
	}

	private static Delegate GetSetColor_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColor_I(nint jnienv, nint native__this, int argb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetColor(argb);
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

	[Register("setColor", "(I)V", "GetSetColor_IHandler")]
	public unsafe virtual void SetColor(int argb)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(argb);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setColor.(I)V", this, ptr);
	}

	private static Delegate GetSetColorFilter_Landroid_graphics_ColorFilter_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetColorFilter_Landroid_graphics_ColorFilter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColorFilter_Landroid_graphics_ColorFilter_(nint jnienv, nint native__this, nint native_colorFilter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GradientDrawable? gradientDrawable = Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorFilter colorFilter = Java.Lang.Object.GetObject<ColorFilter>(native_colorFilter, JniHandleOwnership.DoNotTransfer);
			gradientDrawable.SetColorFilter(colorFilter);
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

	[Register("setColorFilter", "(Landroid/graphics/ColorFilter;)V", "GetSetColorFilter_Landroid_graphics_ColorFilter_Handler")]
	public unsafe override void SetColorFilter(ColorFilter? colorFilter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(colorFilter?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColorFilter.(Landroid/graphics/ColorFilter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(colorFilter);
		}
	}

	private static Delegate GetSetCornerRadii_arrayFHandler()
	{
		return new _JniMarshal_PPL_V(n_SetCornerRadii_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCornerRadii_arrayF(nint jnienv, nint native__this, nint native_radii)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GradientDrawable? gradientDrawable = Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_radii, JniHandleOwnership.DoNotTransfer, typeof(float));
			gradientDrawable.SetCornerRadii(array);
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

	[Register("setCornerRadii", "([F)V", "GetSetCornerRadii_arrayFHandler")]
	public unsafe virtual void SetCornerRadii(float[]? radii)
	{
		nint num = JNIEnv.NewArray(radii);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerRadii.([F)V", this, ptr);
		}
		finally
		{
			if (radii != null)
			{
				JNIEnv.CopyArray(num, radii);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(radii);
		}
	}

	private static Delegate GetSetCornerRadius_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetCornerRadius_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCornerRadius_F(nint jnienv, nint native__this, float radius)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCornerRadius(radius);
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

	[Register("setCornerRadius", "(F)V", "GetSetCornerRadius_FHandler")]
	public unsafe virtual void SetCornerRadius(float radius)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(radius);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerRadius.(F)V", this, ptr);
	}

	private static Delegate GetSetShape_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetShape_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShape_I(nint jnienv, nint native__this, int native_shape)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShape((ShapeType)native_shape);
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

	[Register("setShape", "(I)V", "GetSetShape_IHandler")]
	public unsafe virtual void SetShape(ShapeType shape)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)shape);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setShape.(I)V", this, ptr);
	}

	private static Delegate GetSetStroke_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_SetStroke_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStroke_II(nint jnienv, nint native__this, int width, int native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GradientDrawable? gradientDrawable = Java.Lang.Object.GetObject<GradientDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Color color = new Color(native_color);
			gradientDrawable.SetStroke(width, color);
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

	[Register("setStroke", "(II)V", "GetSetStroke_IIHandler")]
	public unsafe virtual void SetStroke(int width, Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(width);
		ptr[1] = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStroke.(II)V", this, ptr);
	}
}
