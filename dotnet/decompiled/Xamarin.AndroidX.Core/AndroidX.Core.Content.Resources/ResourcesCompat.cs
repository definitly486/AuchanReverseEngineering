using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Content.Resources;

[Register("androidx/core/content/res/ResourcesCompat", DoNotGenerateAcw = true)]
public sealed class ResourcesCompat : Java.Lang.Object
{
	[Register("androidx/core/content/res/ResourcesCompat$FontCallback", DoNotGenerateAcw = true)]
	public abstract class FontCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/content/res/ResourcesCompat$FontCallback", typeof(FontCallback));

		private static Delegate? cb_onFontRetrievalFailed_OnFontRetrievalFailed_I_V;

		private static Delegate? cb_onFontRetrieved_OnFontRetrieved_Landroid_graphics_Typeface__V;

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

		protected FontCallback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FontCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("callbackFailAsync", "(ILandroid/os/Handler;)V", "")]
		public unsafe void CallbackFailAsync(int reason, Handler? handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(reason);
				ptr[1] = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("callbackFailAsync.(ILandroid/os/Handler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("callbackSuccessAsync", "(Landroid/graphics/Typeface;Landroid/os/Handler;)V", "")]
		public unsafe void CallbackSuccessAsync(Typeface? typeface, Handler? handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(typeface?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("callbackSuccessAsync.(Landroid/graphics/Typeface;Landroid/os/Handler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(typeface);
				GC.KeepAlive(handler);
			}
		}

		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getHandler", "(Landroid/os/Handler;)Landroid/os/Handler;", "")]
		public unsafe static Handler? GetHandler(Handler? handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Handler>(_members.StaticMethods.InvokeObjectMethod("getHandler.(Landroid/os/Handler;)Landroid/os/Handler;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		private static Delegate GetOnFontRetrievalFailed_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_OnFontRetrievalFailed_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFontRetrievalFailed_I(nint jnienv, nint native__this, int reason)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<FontCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFontRetrievalFailed(reason);
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

		[Register("onFontRetrievalFailed", "(I)V", "GetOnFontRetrievalFailed_IHandler")]
		public abstract void OnFontRetrievalFailed(int reason);

		private static Delegate GetOnFontRetrieved_Landroid_graphics_Typeface_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnFontRetrieved_Landroid_graphics_Typeface_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFontRetrieved_Landroid_graphics_Typeface_(nint jnienv, nint native__this, nint native_typeface)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				FontCallback? fontCallback = Java.Lang.Object.GetObject<FontCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Typeface typeface = Java.Lang.Object.GetObject<Typeface>(native_typeface, JniHandleOwnership.DoNotTransfer);
				fontCallback.OnFontRetrieved(typeface);
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

		[Register("onFontRetrieved", "(Landroid/graphics/Typeface;)V", "GetOnFontRetrieved_Landroid_graphics_Typeface_Handler")]
		public abstract void OnFontRetrieved(Typeface? typeface);
	}

	[Register("androidx/core/content/res/ResourcesCompat$FontCallback", DoNotGenerateAcw = true)]
	internal class FontCallbackInvoker : FontCallback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/content/res/ResourcesCompat$FontCallback", typeof(FontCallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public FontCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onFontRetrievalFailed", "(I)V", "GetOnFontRetrievalFailed_IHandler")]
		public unsafe override void OnFontRetrievalFailed(int reason)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(reason);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onFontRetrievalFailed.(I)V", this, ptr);
		}

		[Register("onFontRetrieved", "(Landroid/graphics/Typeface;)V", "GetOnFontRetrieved_Landroid_graphics_Typeface_Handler")]
		public unsafe override void OnFontRetrieved(Typeface? typeface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(typeface?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onFontRetrieved.(Landroid/graphics/Typeface;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(typeface);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/content/res/ResourcesCompat", typeof(ResourcesCompat));

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

	internal ResourcesCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("clearCachesForTheme", "(Landroid/content/res/Resources$Theme;)V", "")]
	public unsafe static void ClearCachesForTheme(Android.Content.Res.Resources.Theme? theme)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(theme?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("clearCachesForTheme.(Landroid/content/res/Resources$Theme;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(theme);
		}
	}

	[Register("getCachedFont", "(Landroid/content/Context;I)Landroid/graphics/Typeface;", "")]
	public unsafe static Typeface? GetCachedFont(Context? context, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Typeface>(_members.StaticMethods.InvokeObjectMethod("getCachedFont.(Landroid/content/Context;I)Landroid/graphics/Typeface;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getColor", "(Landroid/content/res/Resources;ILandroid/content/res/Resources$Theme;)I", "")]
	public unsafe static int GetColor(Android.Content.Res.Resources? res, int id, Android.Content.Res.Resources.Theme? theme)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(res?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(theme?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getColor.(Landroid/content/res/Resources;ILandroid/content/res/Resources$Theme;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(res);
			GC.KeepAlive(theme);
		}
	}

	[Register("getColorStateList", "(Landroid/content/res/Resources;ILandroid/content/res/Resources$Theme;)Landroid/content/res/ColorStateList;", "")]
	public unsafe static ColorStateList? GetColorStateList(Android.Content.Res.Resources? res, int id, Android.Content.Res.Resources.Theme? theme)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(res?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(theme?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ColorStateList>(_members.StaticMethods.InvokeObjectMethod("getColorStateList.(Landroid/content/res/Resources;ILandroid/content/res/Resources$Theme;)Landroid/content/res/ColorStateList;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(res);
			GC.KeepAlive(theme);
		}
	}

	[Register("getDrawable", "(Landroid/content/res/Resources;ILandroid/content/res/Resources$Theme;)Landroid/graphics/drawable/Drawable;", "")]
	public unsafe static Drawable? GetDrawable(Android.Content.Res.Resources? res, int id, Android.Content.Res.Resources.Theme? theme)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(res?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(theme?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Drawable>(_members.StaticMethods.InvokeObjectMethod("getDrawable.(Landroid/content/res/Resources;ILandroid/content/res/Resources$Theme;)Landroid/graphics/drawable/Drawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(res);
			GC.KeepAlive(theme);
		}
	}

	[Register("getDrawableForDensity", "(Landroid/content/res/Resources;IILandroid/content/res/Resources$Theme;)Landroid/graphics/drawable/Drawable;", "")]
	public unsafe static Drawable? GetDrawableForDensity(Android.Content.Res.Resources? res, int id, int density, Android.Content.Res.Resources.Theme? theme)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(res?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(density);
			ptr[3] = new JniArgumentValue(theme?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Drawable>(_members.StaticMethods.InvokeObjectMethod("getDrawableForDensity.(Landroid/content/res/Resources;IILandroid/content/res/Resources$Theme;)Landroid/graphics/drawable/Drawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(res);
			GC.KeepAlive(theme);
		}
	}

	[Register("getFloat", "(Landroid/content/res/Resources;I)F", "")]
	public unsafe static float GetFloat(Android.Content.Res.Resources? res, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(res?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return _members.StaticMethods.InvokeSingleMethod("getFloat.(Landroid/content/res/Resources;I)F", ptr);
		}
		finally
		{
			GC.KeepAlive(res);
		}
	}

	[Register("getFont", "(Landroid/content/Context;I)Landroid/graphics/Typeface;", "")]
	public unsafe static Typeface? GetFont(Context? context, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Typeface>(_members.StaticMethods.InvokeObjectMethod("getFont.(Landroid/content/Context;I)Landroid/graphics/Typeface;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getFont", "(Landroid/content/Context;ILandroid/util/TypedValue;ILandroidx/core/content/res/ResourcesCompat$FontCallback;)Landroid/graphics/Typeface;", "")]
	public unsafe static Typeface? GetFont(Context? context, int id, TypedValue? value, int style, FontCallback? fontCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(style);
			ptr[4] = new JniArgumentValue(fontCallback?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Typeface>(_members.StaticMethods.InvokeObjectMethod("getFont.(Landroid/content/Context;ILandroid/util/TypedValue;ILandroidx/core/content/res/ResourcesCompat$FontCallback;)Landroid/graphics/Typeface;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(value);
			GC.KeepAlive(fontCallback);
		}
	}

	[Register("getFont", "(Landroid/content/Context;ILandroidx/core/content/res/ResourcesCompat$FontCallback;Landroid/os/Handler;)V", "")]
	public unsafe static void GetFont(Context? context, int id, FontCallback? fontCallback, Handler? handler)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(fontCallback?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("getFont.(Landroid/content/Context;ILandroidx/core/content/res/ResourcesCompat$FontCallback;Landroid/os/Handler;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(fontCallback);
			GC.KeepAlive(handler);
		}
	}
}
