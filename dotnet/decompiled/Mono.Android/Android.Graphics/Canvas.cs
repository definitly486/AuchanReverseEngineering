using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Canvas", DoNotGenerateAcw = true)]
public class Canvas : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Canvas", typeof(Canvas));

	private static Delegate? cb_getHeight_GetHeight_I;

	private static Delegate? cb_getWidth_GetWidth_I;

	private static Delegate? cb_clipPath_ClipPath_Landroid_graphics_Path__Z;

	private static Delegate? cb_drawBitmap_DrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_Rect_Landroid_graphics_Paint__V;

	private static Delegate? cb_drawBitmap_DrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_RectF_Landroid_graphics_Paint__V;

	private static Delegate? cb_drawBitmap_DrawBitmap_Landroid_graphics_Bitmap_FFLandroid_graphics_Paint__V;

	private static Delegate? cb_drawCircle_DrawCircle_FFFLandroid_graphics_Paint__V;

	private static Delegate? cb_drawPath_DrawPath_Landroid_graphics_Path_Landroid_graphics_Paint__V;

	private static Delegate? cb_drawRect_DrawRect_Landroid_graphics_RectF_Landroid_graphics_Paint__V;

	private static Delegate? cb_drawText_DrawText_Ljava_lang_String_FFLandroid_graphics_Paint__V;

	private static Delegate? cb_restore_Restore_V;

	private static Delegate? cb_save_Save_I;

	private static Delegate? cb_scale_Scale_FF_V;

	private static Delegate? cb_setBitmap_SetBitmap_Landroid_graphics_Bitmap__V;

	private static Delegate? cb_translate_Translate_FF_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.()I", this, null);
		}
	}

	public unsafe virtual int Width
	{
		[Register("getWidth", "()I", "GetGetWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.()I", this, null);
		}
	}

	protected Canvas(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Canvas()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/graphics/Bitmap;)V", "")]
	public unsafe Canvas(Bitmap bitmap)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/Bitmap;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/Bitmap;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bitmap);
		}
	}

	private static Delegate GetGetHeightHandler()
	{
		return new _JniMarshal_PP_I(n_GetHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
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

	private static Delegate GetGetWidthHandler()
	{
		return new _JniMarshal_PP_I(n_GetWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
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

	private static Delegate GetClipPath_Landroid_graphics_Path_Handler()
	{
		return new _JniMarshal_PPL_B(n_ClipPath_Landroid_graphics_Path_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ClipPath_Landroid_graphics_Path_(nint jnienv, nint native__this, nint native_path)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Path path = Java.Lang.Object.GetObject<Path>(native_path, JniHandleOwnership.DoNotTransfer);
			return canvas.ClipPath(path) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("clipPath", "(Landroid/graphics/Path;)Z", "GetClipPath_Landroid_graphics_Path_Handler")]
	public unsafe virtual bool ClipPath(Path path)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(path?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("clipPath.(Landroid/graphics/Path;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(path);
		}
	}

	private static Delegate GetDrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_Rect_Landroid_graphics_Paint_Handler()
	{
		return new _JniMarshal_PPLLLL_V(n_DrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_Rect_Landroid_graphics_Paint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_Rect_Landroid_graphics_Paint_(nint jnienv, nint native__this, nint native_bitmap, nint native_src, nint native_dst, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			Rect src = Java.Lang.Object.GetObject<Rect>(native_src, JniHandleOwnership.DoNotTransfer);
			Rect dst = Java.Lang.Object.GetObject<Rect>(native_dst, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			canvas.DrawBitmap(bitmap, src, dst, paint);
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

	[Register("drawBitmap", "(Landroid/graphics/Bitmap;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Paint;)V", "GetDrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_Rect_Landroid_graphics_Paint_Handler")]
	public unsafe virtual void DrawBitmap(Bitmap bitmap, Rect? src, Rect dst, Paint? paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(dst?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawBitmap.(Landroid/graphics/Bitmap;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Paint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bitmap);
			GC.KeepAlive(src);
			GC.KeepAlive(dst);
			GC.KeepAlive(paint);
		}
	}

	private static Delegate GetDrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_RectF_Landroid_graphics_Paint_Handler()
	{
		return new _JniMarshal_PPLLLL_V(n_DrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_RectF_Landroid_graphics_Paint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_RectF_Landroid_graphics_Paint_(nint jnienv, nint native__this, nint native_bitmap, nint native_src, nint native_dst, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			Rect src = Java.Lang.Object.GetObject<Rect>(native_src, JniHandleOwnership.DoNotTransfer);
			RectF dst = Java.Lang.Object.GetObject<RectF>(native_dst, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			canvas.DrawBitmap(bitmap, src, dst, paint);
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

	[Register("drawBitmap", "(Landroid/graphics/Bitmap;Landroid/graphics/Rect;Landroid/graphics/RectF;Landroid/graphics/Paint;)V", "GetDrawBitmap_Landroid_graphics_Bitmap_Landroid_graphics_Rect_Landroid_graphics_RectF_Landroid_graphics_Paint_Handler")]
	public unsafe virtual void DrawBitmap(Bitmap bitmap, Rect? src, RectF dst, Paint? paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(dst?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawBitmap.(Landroid/graphics/Bitmap;Landroid/graphics/Rect;Landroid/graphics/RectF;Landroid/graphics/Paint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bitmap);
			GC.KeepAlive(src);
			GC.KeepAlive(dst);
			GC.KeepAlive(paint);
		}
	}

	private static Delegate GetDrawBitmap_Landroid_graphics_Bitmap_FFLandroid_graphics_Paint_Handler()
	{
		return new _JniMarshal_PPLFFL_V(n_DrawBitmap_Landroid_graphics_Bitmap_FFLandroid_graphics_Paint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawBitmap_Landroid_graphics_Bitmap_FFLandroid_graphics_Paint_(nint jnienv, nint native__this, nint native_bitmap, float left, float top, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			canvas.DrawBitmap(bitmap, left, top, paint);
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

	[Register("drawBitmap", "(Landroid/graphics/Bitmap;FFLandroid/graphics/Paint;)V", "GetDrawBitmap_Landroid_graphics_Bitmap_FFLandroid_graphics_Paint_Handler")]
	public unsafe virtual void DrawBitmap(Bitmap bitmap, float left, float top, Paint? paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(left);
			ptr[2] = new JniArgumentValue(top);
			ptr[3] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawBitmap.(Landroid/graphics/Bitmap;FFLandroid/graphics/Paint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bitmap);
			GC.KeepAlive(paint);
		}
	}

	private static Delegate GetDrawCircle_FFFLandroid_graphics_Paint_Handler()
	{
		return new _JniMarshal_PPFFFL_V(n_DrawCircle_FFFLandroid_graphics_Paint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawCircle_FFFLandroid_graphics_Paint_(nint jnienv, nint native__this, float cx, float cy, float radius, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			canvas.DrawCircle(cx, cy, radius, paint);
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

	[Register("drawCircle", "(FFFLandroid/graphics/Paint;)V", "GetDrawCircle_FFFLandroid_graphics_Paint_Handler")]
	public unsafe virtual void DrawCircle(float cx, float cy, float radius, Paint paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(cx);
			ptr[1] = new JniArgumentValue(cy);
			ptr[2] = new JniArgumentValue(radius);
			ptr[3] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawCircle.(FFFLandroid/graphics/Paint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(paint);
		}
	}

	private static Delegate GetDrawPath_Landroid_graphics_Path_Landroid_graphics_Paint_Handler()
	{
		return new _JniMarshal_PPLL_V(n_DrawPath_Landroid_graphics_Path_Landroid_graphics_Paint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawPath_Landroid_graphics_Path_Landroid_graphics_Paint_(nint jnienv, nint native__this, nint native_path, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Path path = Java.Lang.Object.GetObject<Path>(native_path, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			canvas.DrawPath(path, paint);
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

	[Register("drawPath", "(Landroid/graphics/Path;Landroid/graphics/Paint;)V", "GetDrawPath_Landroid_graphics_Path_Landroid_graphics_Paint_Handler")]
	public unsafe virtual void DrawPath(Path path, Paint paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(path?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawPath.(Landroid/graphics/Path;Landroid/graphics/Paint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(path);
			GC.KeepAlive(paint);
		}
	}

	private static Delegate GetDrawRect_Landroid_graphics_RectF_Landroid_graphics_Paint_Handler()
	{
		return new _JniMarshal_PPLL_V(n_DrawRect_Landroid_graphics_RectF_Landroid_graphics_Paint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawRect_Landroid_graphics_RectF_Landroid_graphics_Paint_(nint jnienv, nint native__this, nint native_rect, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RectF rect = Java.Lang.Object.GetObject<RectF>(native_rect, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			canvas.DrawRect(rect, paint);
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

	[Register("drawRect", "(Landroid/graphics/RectF;Landroid/graphics/Paint;)V", "GetDrawRect_Landroid_graphics_RectF_Landroid_graphics_Paint_Handler")]
	public unsafe virtual void DrawRect(RectF rect, Paint paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawRect.(Landroid/graphics/RectF;Landroid/graphics/Paint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(rect);
			GC.KeepAlive(paint);
		}
	}

	private static Delegate GetDrawText_Ljava_lang_String_FFLandroid_graphics_Paint_Handler()
	{
		return new _JniMarshal_PPLFFL_V(n_DrawText_Ljava_lang_String_FFLandroid_graphics_Paint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawText_Ljava_lang_String_FFLandroid_graphics_Paint_(nint jnienv, nint native__this, nint native_text, float x, float y, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			canvas.DrawText(text, x, y, paint);
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

	[Register("drawText", "(Ljava/lang/String;FFLandroid/graphics/Paint;)V", "GetDrawText_Ljava_lang_String_FFLandroid_graphics_Paint_Handler")]
	public unsafe virtual void DrawText(string text, float x, float y, Paint paint)
	{
		nint num = JNIEnv.NewString(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(x);
			ptr[2] = new JniArgumentValue(y);
			ptr[3] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawText.(Ljava/lang/String;FFLandroid/graphics/Paint;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(paint);
		}
	}

	private static Delegate GetRestoreHandler()
	{
		return new _JniMarshal_PP_V(n_Restore);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Restore(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Restore();
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

	[Register("restore", "()V", "GetRestoreHandler")]
	public unsafe virtual void Restore()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("restore.()V", this, null);
	}

	private static Delegate GetSaveHandler()
	{
		return new _JniMarshal_PP_I(n_Save);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Save(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Save();
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

	[Register("save", "()I", "GetSaveHandler")]
	public unsafe virtual int Save()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("save.()I", this, null);
	}

	[Register("scale", "(FFFF)V", "")]
	public unsafe void Scale(float sx, float sy, float px, float py)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(sx);
		ptr[1] = new JniArgumentValue(sy);
		ptr[2] = new JniArgumentValue(px);
		ptr[3] = new JniArgumentValue(py);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("scale.(FFFF)V", this, ptr);
	}

	private static Delegate GetScale_FFHandler()
	{
		return new _JniMarshal_PPFF_V(n_Scale_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Scale_FF(nint jnienv, nint native__this, float sx, float sy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scale(sx, sy);
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

	[Register("scale", "(FF)V", "GetScale_FFHandler")]
	public unsafe virtual void Scale(float sx, float sy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(sx);
		ptr[1] = new JniArgumentValue(sy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("scale.(FF)V", this, ptr);
	}

	private static Delegate GetSetBitmap_Landroid_graphics_Bitmap_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetBitmap_Landroid_graphics_Bitmap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBitmap_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_bitmap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Canvas? canvas = Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			canvas.SetBitmap(bitmap);
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

	[Register("setBitmap", "(Landroid/graphics/Bitmap;)V", "GetSetBitmap_Landroid_graphics_Bitmap_Handler")]
	public unsafe virtual void SetBitmap(Bitmap? bitmap)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBitmap.(Landroid/graphics/Bitmap;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bitmap);
		}
	}

	private static Delegate GetTranslate_FFHandler()
	{
		return new _JniMarshal_PPFF_V(n_Translate_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Translate_FF(nint jnienv, nint native__this, float dx, float dy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Canvas>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Translate(dx, dy);
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

	[Register("translate", "(FF)V", "GetTranslate_FFHandler")]
	public unsafe virtual void Translate(float dx, float dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("translate.(FF)V", this, ptr);
	}
}
