using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Paint", DoNotGenerateAcw = true)]
public class Paint : Java.Lang.Object
{
	[Register("android/graphics/Paint$Style", DoNotGenerateAcw = true)]
	public sealed class Style : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Paint$Style", typeof(Style));

		[Register("FILL")]
		public static Style? Fill => Java.Lang.Object.GetObject<Style>(_members.StaticFields.GetObjectValue("FILL.Landroid/graphics/Paint$Style;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STROKE")]
		public static Style? Stroke => Java.Lang.Object.GetObject<Style>(_members.StaticFields.GetObjectValue("STROKE.Landroid/graphics/Paint$Style;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Style(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Paint", typeof(Paint));

	private static Delegate? cb_setAlpha_SetAlpha_I_V;

	private static Delegate? cb_getColor_GetColor_I;

	private static Delegate? cb_setColor_SetColor_I_V;

	private static Delegate? cb_setStrokeWidth_SetStrokeWidth_F_V;

	private static Delegate? cb_setTextSize_SetTextSize_F_V;

	private static Delegate? cb_measureText_MeasureText_Ljava_lang_String_II_F;

	private static Delegate? cb_measureText_MeasureText_Ljava_lang_String__F;

	private static Delegate? cb_setMaskFilter_SetMaskFilter_Landroid_graphics_MaskFilter__Landroid_graphics_MaskFilter_;

	private static Delegate? cb_setPathEffect_SetPathEffect_Landroid_graphics_PathEffect__Landroid_graphics_PathEffect_;

	private static Delegate? cb_setStyle_SetStyle_Landroid_graphics_Paint_Style__V;

	private static Delegate? cb_setTypeface_SetTypeface_Landroid_graphics_Typeface__Landroid_graphics_Typeface_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int Alpha
	{
		[Register("setAlpha", "(I)V", "GetSetAlpha_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAlpha.(I)V", this, ptr);
		}
	}

	public unsafe bool AntiAlias
	{
		[Register("setAntiAlias", "(Z)V", "GetSetAntiAlias_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAntiAlias.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Color Color
	{
		[Register("getColor", "()I", "GetGetColorHandler")]
		get
		{
			return new Color(_members.InstanceMethods.InvokeVirtualInt32Method("getColor.()I", this, null));
		}
		[Register("setColor", "(I)V", "GetSetColor_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value.ToArgb());
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColor.(I)V", this, ptr);
		}
	}

	public unsafe virtual float StrokeWidth
	{
		[Register("setStrokeWidth", "(F)V", "GetSetStrokeWidth_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeWidth.(F)V", this, ptr);
		}
	}

	public unsafe virtual float TextSize
	{
		[Register("setTextSize", "(F)V", "GetSetTextSize_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextSize.(F)V", this, ptr);
		}
	}

	public unsafe bool UnderlineText
	{
		[Register("setUnderlineText", "(Z)V", "GetSetUnderlineText_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUnderlineText.(Z)V", this, ptr);
		}
	}

	protected Paint(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Paint()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe Paint(PaintFlags flags)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)flags);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	private static Delegate GetSetAlpha_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetAlpha_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAlpha_I(nint jnienv, nint native__this, int a)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Alpha = a;
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
		return new _JniMarshal_PP_I(n_GetColor);
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
			return Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Color.ToArgb();
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
		return new _JniMarshal_PPI_V(n_SetColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColor_I(nint jnienv, nint native__this, int native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Paint? paint = Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Color color = new Color(native_color);
			paint.Color = color;
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

	private static Delegate GetSetStrokeWidth_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetStrokeWidth_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeWidth_F(nint jnienv, nint native__this, float width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth = width;
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

	private static Delegate GetSetTextSize_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetTextSize_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextSize_F(nint jnienv, nint native__this, float textSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextSize = textSize;
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

	private static Delegate GetMeasureText_Ljava_lang_String_IIHandler()
	{
		return new _JniMarshal_PPLII_F(n_MeasureText_Ljava_lang_String_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_MeasureText_Ljava_lang_String_II(nint jnienv, nint native__this, nint native_text, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			Paint? paint = Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			return paint.MeasureText(text, start, end);
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

	[Register("measureText", "(Ljava/lang/String;II)F", "GetMeasureText_Ljava_lang_String_IIHandler")]
	public unsafe virtual float MeasureText(string? text, int start, int end)
	{
		nint num = JNIEnv.NewString(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("measureText.(Ljava/lang/String;II)F", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetMeasureText_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_F(n_MeasureText_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_MeasureText_Ljava_lang_String_(nint jnienv, nint native__this, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			Paint? paint = Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			return paint.MeasureText(text);
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

	[Register("measureText", "(Ljava/lang/String;)F", "GetMeasureText_Ljava_lang_String_Handler")]
	public unsafe virtual float MeasureText(string? text)
	{
		nint num = JNIEnv.NewString(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("measureText.(Ljava/lang/String;)F", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetMaskFilter_Landroid_graphics_MaskFilter_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetMaskFilter_Landroid_graphics_MaskFilter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetMaskFilter_Landroid_graphics_MaskFilter_(nint jnienv, nint native__this, nint native_maskfilter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Paint? paint = Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MaskFilter maskFilter = Java.Lang.Object.GetObject<MaskFilter>(native_maskfilter, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(paint.SetMaskFilter(maskFilter));
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

	[Register("setMaskFilter", "(Landroid/graphics/MaskFilter;)Landroid/graphics/MaskFilter;", "GetSetMaskFilter_Landroid_graphics_MaskFilter_Handler")]
	public unsafe virtual MaskFilter? SetMaskFilter(MaskFilter? maskfilter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(maskfilter?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<MaskFilter>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMaskFilter.(Landroid/graphics/MaskFilter;)Landroid/graphics/MaskFilter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(maskfilter);
		}
	}

	private static Delegate GetSetPathEffect_Landroid_graphics_PathEffect_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetPathEffect_Landroid_graphics_PathEffect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetPathEffect_Landroid_graphics_PathEffect_(nint jnienv, nint native__this, nint native_effect)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Paint? paint = Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PathEffect pathEffect = Java.Lang.Object.GetObject<PathEffect>(native_effect, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(paint.SetPathEffect(pathEffect));
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

	[Register("setPathEffect", "(Landroid/graphics/PathEffect;)Landroid/graphics/PathEffect;", "GetSetPathEffect_Landroid_graphics_PathEffect_Handler")]
	public unsafe virtual PathEffect? SetPathEffect(PathEffect? effect)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(effect?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<PathEffect>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPathEffect.(Landroid/graphics/PathEffect;)Landroid/graphics/PathEffect;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(effect);
		}
	}

	private static Delegate GetSetStyle_Landroid_graphics_Paint_Style_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetStyle_Landroid_graphics_Paint_Style_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStyle_Landroid_graphics_Paint_Style_(nint jnienv, nint native__this, nint native_style)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Paint? paint = Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Style style = Java.Lang.Object.GetObject<Style>(native_style, JniHandleOwnership.DoNotTransfer);
			paint.SetStyle(style);
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

	[Register("setStyle", "(Landroid/graphics/Paint$Style;)V", "GetSetStyle_Landroid_graphics_Paint_Style_Handler")]
	public unsafe virtual void SetStyle(Style? style)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(style?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStyle.(Landroid/graphics/Paint$Style;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(style);
		}
	}

	private static Delegate GetSetTypeface_Landroid_graphics_Typeface_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetTypeface_Landroid_graphics_Typeface_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTypeface_Landroid_graphics_Typeface_(nint jnienv, nint native__this, nint native_typeface)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Paint? paint = Java.Lang.Object.GetObject<Paint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Typeface typeface = Java.Lang.Object.GetObject<Typeface>(native_typeface, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(paint.SetTypeface(typeface));
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

	[Register("setTypeface", "(Landroid/graphics/Typeface;)Landroid/graphics/Typeface;", "GetSetTypeface_Landroid_graphics_Typeface_Handler")]
	public unsafe virtual Typeface? SetTypeface(Typeface? typeface)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(typeface?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Typeface>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTypeface.(Landroid/graphics/Typeface;)Landroid/graphics/Typeface;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(typeface);
		}
	}
}
