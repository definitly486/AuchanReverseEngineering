using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/ProgressBar", DoNotGenerateAcw = true)]
public class ProgressBar : View
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/ProgressBar", typeof(ProgressBar));

	private static Delegate? cb_setMax_SetMax_I_V;

	private static Delegate? cb_setMin_SetMin_I_V;

	private static Delegate? cb_getProgress_GetProgress_I;

	private static Delegate? cb_setProgress_SetProgress_I_V;

	private static Delegate? cb_getProgressDrawable_GetProgressDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setProgressDrawable_SetProgressDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroid_os_Parcelable__V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

	private static Delegate? cb_setProgress_SetProgress_IZ_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int Max
	{
		[Register("setMax", "(I)V", "GetSetMax_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMax.(I)V", this, ptr);
		}
	}

	[SupportedOSPlatform("android26.0")]
	public unsafe virtual int Min
	{
		[SupportedOSPlatform("android26.0")]
		[Register("setMin", "(I)V", "GetSetMin_IHandler", ApiSince = 26)]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMin.(I)V", this, ptr);
		}
	}

	public unsafe virtual int Progress
	{
		[Register("getProgress", "()I", "GetGetProgressHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getProgress.()I", this, null);
		}
		[Register("setProgress", "(I)V", "GetSetProgress_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProgress.(I)V", this, ptr);
		}
	}

	public unsafe virtual Drawable? ProgressDrawable
	{
		[Register("getProgressDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetProgressDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getProgressDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setProgressDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetProgressDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected ProgressBar(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe ProgressBar(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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
	public unsafe ProgressBar(Context? context, IAttributeSet? attrs, int defStyleAttr)
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
	public unsafe ProgressBar(Context? context, IAttributeSet? attrs)
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
	public unsafe ProgressBar(Context? context)
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

	private static Delegate GetSetMax_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetMax_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMax_I(nint jnienv, nint native__this, int max)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Max = max;
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

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetSetMin_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetMin_I);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMin_I(nint jnienv, nint native__this, int min)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Min = min;
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

	private static Delegate GetGetProgressHandler()
	{
		return new _JniMarshal_PP_I(n_GetProgress);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetProgress(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress;
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

	private static Delegate GetSetProgress_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetProgress_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgress_I(nint jnienv, nint native__this, int progress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Progress = progress;
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

	private static Delegate GetGetProgressDrawableHandler()
	{
		return new _JniMarshal_PP_L(n_GetProgressDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetProgressDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProgressDrawable);
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

	private static Delegate GetSetProgressDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetProgressDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgressDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_d)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ProgressBar? progressBar = Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable progressDrawable = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			progressBar.ProgressDrawable = progressDrawable;
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

	private static Delegate GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnRestoreInstanceState_Landroid_os_Parcelable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ProgressBar? progressBar = Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			progressBar.OnRestoreInstanceState(state);
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

	[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler")]
	public new unsafe virtual void OnRestoreInstanceState(IParcelable? state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Parcelable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetOnSaveInstanceStateHandler()
	{
		return new _JniMarshal_PP_L(n_OnSaveInstanceState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSaveInstanceState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

	[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
	public new unsafe virtual IParcelable? OnSaveInstanceState()
	{
		return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetSetProgress_IZHandler()
	{
		return new _JniMarshal_PPIB_V(n_SetProgress_IZ);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgress_IZ(nint jnienv, nint native__this, int progress, sbyte native_animate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ProgressBar? progressBar = Java.Lang.Object.GetObject<ProgressBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool animate = native_animate != 0;
			progressBar.SetProgress(progress, animate);
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

	[SupportedOSPlatform("android24.0")]
	[Register("setProgress", "(IZ)V", "GetSetProgress_IZHandler", ApiSince = 24)]
	public unsafe virtual void SetProgress(int progress, bool animate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(progress);
		ptr[1] = new JniArgumentValue(animate ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setProgress.(IZ)V", this, ptr);
	}
}
