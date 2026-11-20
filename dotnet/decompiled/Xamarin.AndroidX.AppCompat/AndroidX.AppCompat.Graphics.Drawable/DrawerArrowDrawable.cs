using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.Graphics.Drawable;

[Register("androidx/appcompat/graphics/drawable/DrawerArrowDrawable", DoNotGenerateAcw = true)]
public class DrawerArrowDrawable : Android.Graphics.Drawables.Drawable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/graphics/drawable/DrawerArrowDrawable", typeof(DrawerArrowDrawable));

	private static Delegate? cb_getArrowHeadLength_GetArrowHeadLength_F;

	private static Delegate? cb_setArrowHeadLength_SetArrowHeadLength_F_V;

	private static Delegate? cb_getArrowShaftLength_GetArrowShaftLength_F;

	private static Delegate? cb_setArrowShaftLength_SetArrowShaftLength_F_V;

	private static Delegate? cb_getBarLength_GetBarLength_F;

	private static Delegate? cb_setBarLength_SetBarLength_F_V;

	private static Delegate? cb_getBarThickness_GetBarThickness_F;

	private static Delegate? cb_setBarThickness_SetBarThickness_F_V;

	private static Delegate? cb_getColor_GetColor_I;

	private static Delegate? cb_setColor_SetColor_I_V;

	private static Delegate? cb_getDirection_GetDirection_I;

	private static Delegate? cb_setDirection_SetDirection_I_V;

	private static Delegate? cb_getGapSize_GetGapSize_F;

	private static Delegate? cb_setGapSize_SetGapSize_F_V;

	private static Delegate? cb_getOpacity_GetOpacity_I;

	private static Delegate? cb_getProgress_GetProgress_F;

	private static Delegate? cb_setProgress_SetProgress_F_V;

	private static Delegate? cb_isSpinEnabled_IsSpinEnabled_Z;

	private static Delegate? cb_setSpinEnabled_SetSpinEnabled_Z_V;

	private static Delegate? cb_draw_Draw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_setAlpha_SetAlpha_I_V;

	private static Delegate? cb_setColorFilter_SetColorFilter_Landroid_graphics_ColorFilter__V;

	private static Delegate? cb_setVerticalMirror_SetVerticalMirror_Z_V;

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

	public unsafe virtual float ArrowHeadLength
	{
		[Register("getArrowHeadLength", "()F", "GetGetArrowHeadLengthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getArrowHeadLength.()F", this, null);
		}
		[Register("setArrowHeadLength", "(F)V", "GetSetArrowHeadLength_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setArrowHeadLength.(F)V", this, ptr);
		}
	}

	public unsafe virtual float ArrowShaftLength
	{
		[Register("getArrowShaftLength", "()F", "GetGetArrowShaftLengthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getArrowShaftLength.()F", this, null);
		}
		[Register("setArrowShaftLength", "(F)V", "GetSetArrowShaftLength_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setArrowShaftLength.(F)V", this, ptr);
		}
	}

	public unsafe virtual float BarLength
	{
		[Register("getBarLength", "()F", "GetGetBarLengthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBarLength.()F", this, null);
		}
		[Register("setBarLength", "(F)V", "GetSetBarLength_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBarLength.(F)V", this, ptr);
		}
	}

	public unsafe virtual float BarThickness
	{
		[Register("getBarThickness", "()F", "GetGetBarThicknessHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBarThickness.()F", this, null);
		}
		[Register("setBarThickness", "(F)V", "GetSetBarThickness_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBarThickness.(F)V", this, ptr);
		}
	}

	public unsafe virtual int Color
	{
		[Register("getColor", "()I", "GetGetColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getColor.()I", this, null);
		}
		[Register("setColor", "(I)V", "GetSetColor_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColor.(I)V", this, ptr);
		}
	}

	public unsafe virtual int Direction
	{
		[Register("getDirection", "()I", "GetGetDirectionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDirection.()I", this, null);
		}
		[Register("setDirection", "(I)V", "GetSetDirection_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDirection.(I)V", this, ptr);
		}
	}

	public unsafe virtual float GapSize
	{
		[Register("getGapSize", "()F", "GetGetGapSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getGapSize.()F", this, null);
		}
		[Register("setGapSize", "(F)V", "GetSetGapSize_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGapSize.(F)V", this, ptr);
		}
	}

	public unsafe override int Opacity
	{
		[Register("getOpacity", "()I", "GetGetOpacityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOpacity.()I", this, null);
		}
	}

	public unsafe Paint? Paint
	{
		[Register("getPaint", "()Landroid/graphics/Paint;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Paint>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getPaint.()Landroid/graphics/Paint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float Progress
	{
		[Register("getProgress", "()F", "GetGetProgressHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getProgress.()F", this, null);
		}
		[Register("setProgress", "(F)V", "GetSetProgress_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgress.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool SpinEnabled
	{
		[Register("isSpinEnabled", "()Z", "GetIsSpinEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpinEnabled.()Z", this, null);
		}
		[Register("setSpinEnabled", "(Z)V", "GetSetSpinEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpinEnabled.(Z)V", this, ptr);
		}
	}

	protected DrawerArrowDrawable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe DrawerArrowDrawable(Context? context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetArrowHeadLengthHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetArrowHeadLength);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetArrowHeadLength(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArrowHeadLength;
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

	private static Delegate GetSetArrowHeadLength_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetArrowHeadLength_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetArrowHeadLength_F(nint jnienv, nint native__this, float length)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArrowHeadLength = length;
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

	private static Delegate GetGetArrowShaftLengthHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetArrowShaftLength);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetArrowShaftLength(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArrowShaftLength;
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

	private static Delegate GetSetArrowShaftLength_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetArrowShaftLength_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetArrowShaftLength_F(nint jnienv, nint native__this, float length)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArrowShaftLength = length;
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

	private static Delegate GetGetBarLengthHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetBarLength);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBarLength(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BarLength;
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

	private static Delegate GetSetBarLength_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetBarLength_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBarLength_F(nint jnienv, nint native__this, float length)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BarLength = length;
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

	private static Delegate GetGetBarThicknessHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetBarThickness);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBarThickness(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BarThickness;
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

	private static Delegate GetSetBarThickness_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetBarThickness_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBarThickness_F(nint jnienv, nint native__this, float width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BarThickness = width;
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

	private static Delegate GetGetColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Color;
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

	private static Delegate GetSetColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Color = color;
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

	private static Delegate GetGetDirectionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Direction;
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

	private static Delegate GetSetDirection_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDirection_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDirection_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Direction = direction;
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

	private static Delegate GetGetGapSizeHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetGapSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetGapSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GapSize;
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

	private static Delegate GetSetGapSize_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetGapSize_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGapSize_F(nint jnienv, nint native__this, float gap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GapSize = gap;
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

	private static Delegate GetGetOpacityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOpacity);
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
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Opacity;
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

	private static Delegate GetGetProgressHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetProgress);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetProgress(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress;
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

	private static Delegate GetSetProgress_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetProgress_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgress_F(nint jnienv, nint native__this, float progress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress = progress;
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

	private static Delegate GetIsSpinEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSpinEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSpinEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpinEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetSpinEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSpinEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSpinEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerArrowDrawable? drawerArrowDrawable = Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool spinEnabled = native_enabled != 0;
			drawerArrowDrawable.SpinEnabled = spinEnabled;
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

	private static Delegate GetDraw_Landroid_graphics_Canvas_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Draw_Landroid_graphics_Canvas_);
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
			DrawerArrowDrawable? drawerArrowDrawable = Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			drawerArrowDrawable.Draw(canvas);
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
	public unsafe override void Draw(Canvas canvas)
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

	private static Delegate GetSetAlpha_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetAlpha_I);
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
			Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlpha(alpha);
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

	private static Delegate GetSetColorFilter_Landroid_graphics_ColorFilter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetColorFilter_Landroid_graphics_ColorFilter_);
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
			DrawerArrowDrawable? drawerArrowDrawable = Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorFilter colorFilter = Java.Lang.Object.GetObject<ColorFilter>(native_colorFilter, JniHandleOwnership.DoNotTransfer);
			drawerArrowDrawable.SetColorFilter(colorFilter);
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

	private static Delegate GetSetVerticalMirror_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetVerticalMirror_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalMirror_Z(nint jnienv, nint native__this, sbyte native_verticalMirror)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerArrowDrawable? drawerArrowDrawable = Java.Lang.Object.GetObject<DrawerArrowDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool verticalMirror = native_verticalMirror != 0;
			drawerArrowDrawable.SetVerticalMirror(verticalMirror);
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

	[Register("setVerticalMirror", "(Z)V", "GetSetVerticalMirror_ZHandler")]
	public unsafe virtual void SetVerticalMirror(bool verticalMirror)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(verticalMirror ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalMirror.(Z)V", this, ptr);
	}
}
