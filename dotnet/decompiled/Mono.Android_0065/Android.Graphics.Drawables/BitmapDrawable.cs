using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics.Drawables;

[Register("android/graphics/drawable/BitmapDrawable", DoNotGenerateAcw = true)]
public class BitmapDrawable : Drawable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/BitmapDrawable", typeof(BitmapDrawable));

	private static Delegate? cb_getOpacity_GetOpacity_I;

	private static Delegate? cb_draw_Draw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_setAlpha_SetAlpha_I_V;

	private static Delegate? cb_setColorFilter_SetColorFilter_Landroid_graphics_ColorFilter__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Bitmap? Bitmap => Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBitmap.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe override int Opacity => _members.InstanceMethods.InvokeVirtualInt32Method("getOpacity.()I", this, null);

	protected BitmapDrawable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
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
			return Java.Lang.Object.GetObject<BitmapDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Opacity;
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
			BitmapDrawable? bitmapDrawable = Java.Lang.Object.GetObject<BitmapDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			bitmapDrawable.Draw(canvas);
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
			Java.Lang.Object.GetObject<BitmapDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlpha(alpha);
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

	public unsafe override void SetAlpha(int alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(alpha);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAlpha.(I)V", this, ptr);
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
			BitmapDrawable? bitmapDrawable = Java.Lang.Object.GetObject<BitmapDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorFilter colorFilter = Java.Lang.Object.GetObject<ColorFilter>(native_colorFilter, JniHandleOwnership.DoNotTransfer);
			bitmapDrawable.SetColorFilter(colorFilter);
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
}
