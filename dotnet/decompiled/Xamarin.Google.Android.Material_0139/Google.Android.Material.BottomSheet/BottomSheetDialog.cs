using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.BottomSheet;

[Register("com/google/android/material/bottomsheet/BottomSheetDialog", DoNotGenerateAcw = true)]
public class BottomSheetDialog : AppCompatDialog
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/bottomsheet/BottomSheetDialog", typeof(BottomSheetDialog));

	private static Delegate? cb_getBehavior_GetBehavior_Lcom_google_android_material_bottomsheet_BottomSheetBehavior_;

	private static Delegate? cb_getDismissWithAnimation_GetDismissWithAnimation_Z;

	private static Delegate? cb_setDismissWithAnimation_SetDismissWithAnimation_Z_V;

	private static Delegate? cb_getEdgeToEdgeEnabled_GetEdgeToEdgeEnabled_Z;

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

	public unsafe virtual BottomSheetBehavior Behavior
	{
		[Register("getBehavior", "()Lcom/google/android/material/bottomsheet/BottomSheetBehavior;", "GetGetBehaviorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<BottomSheetBehavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBehavior.()Lcom/google/android/material/bottomsheet/BottomSheetBehavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool DismissWithAnimation
	{
		[Register("getDismissWithAnimation", "()Z", "GetGetDismissWithAnimationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getDismissWithAnimation.()Z", this, null);
		}
		[Register("setDismissWithAnimation", "(Z)V", "GetSetDismissWithAnimation_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDismissWithAnimation.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool EdgeToEdgeEnabled
	{
		[Register("getEdgeToEdgeEnabled", "()Z", "GetGetEdgeToEdgeEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getEdgeToEdgeEnabled.()Z", this, null);
		}
	}

	protected BottomSheetDialog(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe BottomSheetDialog(Context context)
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

	[Register(".ctor", "(Landroid/content/Context;ZLandroid/content/DialogInterface$OnCancelListener;)V", "")]
	protected unsafe BottomSheetDialog(Context context, bool cancelable, IDialogInterfaceOnCancelListener? cancelListener)
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
			ptr[1] = new JniArgumentValue(cancelable ? ((sbyte)1) : ((sbyte)0));
			ptr[2] = new JniArgumentValue((cancelListener == null) ? IntPtr.Zero : ((Java.Lang.Object)cancelListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;ZLandroid/content/DialogInterface$OnCancelListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;ZLandroid/content/DialogInterface$OnCancelListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(cancelListener);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;I)V", "")]
	public unsafe BottomSheetDialog(Context context, int theme)
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
			ptr[1] = new JniArgumentValue(theme);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetBehaviorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBehavior);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBehavior(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BottomSheetDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Behavior);
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

	private static Delegate GetGetDismissWithAnimationHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetDismissWithAnimation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetDismissWithAnimation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DismissWithAnimation ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDismissWithAnimation_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDismissWithAnimation_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDismissWithAnimation_Z(nint jnienv, nint native__this, sbyte native_dismissWithAnimation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomSheetDialog? bottomSheetDialog = Java.Lang.Object.GetObject<BottomSheetDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool dismissWithAnimation = native_dismissWithAnimation != 0;
			bottomSheetDialog.DismissWithAnimation = dismissWithAnimation;
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

	private static Delegate GetGetEdgeToEdgeEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetEdgeToEdgeEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetEdgeToEdgeEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomSheetDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EdgeToEdgeEnabled ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("deprecated")]
	[Register("setLightStatusBar", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetLightStatusBar(View view, bool isLight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(isLight ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setLightStatusBar.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}
}
