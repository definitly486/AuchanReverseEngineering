using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/ImageView", DoNotGenerateAcw = true)]
public class ImageView : View
{
	[Register("android/widget/ImageView$ScaleType", DoNotGenerateAcw = true)]
	public sealed class ScaleType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/ImageView$ScaleType", typeof(ScaleType));

		[Register("CENTER_CROP")]
		public static ScaleType? CenterCrop => Java.Lang.Object.GetObject<ScaleType>(_members.StaticFields.GetObjectValue("CENTER_CROP.Landroid/widget/ImageView$ScaleType;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ScaleType(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/ImageView", typeof(ImageView));

	private static Delegate? cb_getDrawable_GetDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setImageAlpha_SetImageAlpha_I_V;

	private static Delegate? cb_setImageTintList_SetImageTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_onCreateDrawableState_OnCreateDrawableState_I_arrayI;

	private static Delegate? cb_setImageBitmap_SetImageBitmap_Landroid_graphics_Bitmap__V;

	private static Delegate? cb_setImageDrawable_SetImageDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setImageResource_SetImageResource_I_V;

	private static Delegate? cb_setScaleType_SetScaleType_Landroid_widget_ImageView_ScaleType__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual Drawable? Drawable
	{
		[Register("getDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int ImageAlpha
	{
		[Register("setImageAlpha", "(I)V", "GetSetImageAlpha_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageAlpha.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? ImageTintList
	{
		[Register("setImageTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetImageTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setImageTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected ImageView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe ImageView(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe ImageView(Context? context, IAttributeSet? attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe ImageView(Context? context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ImageView(Context? context)
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

	private static Delegate GetGetDrawableHandler()
	{
		return new _JniMarshal_PP_L(n_GetDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ImageView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Drawable);
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

	private static Delegate GetSetImageAlpha_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetImageAlpha_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetImageAlpha_I(nint jnienv, nint native__this, int alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ImageView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAlpha = alpha;
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

	private static Delegate GetSetImageTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetImageTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetImageTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ImageView? imageView = Java.Lang.Object.GetObject<ImageView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList imageTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			imageView.ImageTintList = imageTintList;
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

	private static Delegate GetOnCreateDrawableState_IHandler()
	{
		return new _JniMarshal_PPI_L(n_OnCreateDrawableState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateDrawableState_I(nint jnienv, nint native__this, int extraSpace)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ImageView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreateDrawableState(extraSpace));
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

	[Register("onCreateDrawableState", "(I)[I", "GetOnCreateDrawableState_IHandler")]
	public new unsafe virtual int[]? OnCreateDrawableState(int extraSpace)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(extraSpace);
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateDrawableState.(I)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	[Register("setColorFilter", "(I)V", "")]
	public unsafe void SetColorFilter(Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("setColorFilter.(I)V", this, ptr);
	}

	private static Delegate GetSetImageBitmap_Landroid_graphics_Bitmap_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetImageBitmap_Landroid_graphics_Bitmap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetImageBitmap_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_bm)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ImageView? imageView = Java.Lang.Object.GetObject<ImageView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap imageBitmap = Java.Lang.Object.GetObject<Bitmap>(native_bm, JniHandleOwnership.DoNotTransfer);
			imageView.SetImageBitmap(imageBitmap);
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

	[Register("setImageBitmap", "(Landroid/graphics/Bitmap;)V", "GetSetImageBitmap_Landroid_graphics_Bitmap_Handler")]
	public unsafe virtual void SetImageBitmap(Bitmap? bm)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bm?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageBitmap.(Landroid/graphics/Bitmap;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bm);
		}
	}

	private static Delegate GetSetImageDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetImageDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetImageDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ImageView? imageView = Java.Lang.Object.GetObject<ImageView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable imageDrawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			imageView.SetImageDrawable(imageDrawable);
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

	[Register("setImageDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetImageDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetImageDrawable(Drawable? drawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawable?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImageDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawable);
		}
	}

	private static Delegate GetSetImageResource_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetImageResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetImageResource_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ImageView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetImageResource(resId);
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

	[Register("setImageResource", "(I)V", "GetSetImageResource_IHandler")]
	public unsafe virtual void SetImageResource(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setImageResource.(I)V", this, ptr);
	}

	private static Delegate GetSetScaleType_Landroid_widget_ImageView_ScaleType_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetScaleType_Landroid_widget_ImageView_ScaleType_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScaleType_Landroid_widget_ImageView_ScaleType_(nint jnienv, nint native__this, nint native_scaleType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ImageView? imageView = Java.Lang.Object.GetObject<ImageView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ScaleType scaleType = Java.Lang.Object.GetObject<ScaleType>(native_scaleType, JniHandleOwnership.DoNotTransfer);
			imageView.SetScaleType(scaleType);
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

	[Register("setScaleType", "(Landroid/widget/ImageView$ScaleType;)V", "GetSetScaleType_Landroid_widget_ImageView_ScaleType_Handler")]
	public unsafe virtual void SetScaleType(ScaleType? scaleType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(scaleType?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleType.(Landroid/widget/ImageView$ScaleType;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(scaleType);
		}
	}
}
