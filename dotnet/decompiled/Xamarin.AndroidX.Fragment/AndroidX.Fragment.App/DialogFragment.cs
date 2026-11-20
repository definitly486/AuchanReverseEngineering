using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.Activity;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/DialogFragment", DoNotGenerateAcw = true)]
public class DialogFragment : Fragment, IDialogInterfaceOnCancelListener, IJavaObject, IDisposable, IJavaPeerable, IDialogInterfaceOnDismissListener
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/DialogFragment", typeof(DialogFragment));

	private static Delegate? cb_isCancelable_IsCancelable_Z;

	private static Delegate? cb_setCancelable_SetCancelable_Z_V;

	private static Delegate? cb_getDialog_GetDialog_Landroid_app_Dialog_;

	private static Delegate? cb_getShowsDialog_GetShowsDialog_Z;

	private static Delegate? cb_setShowsDialog_SetShowsDialog_Z_V;

	private static Delegate? cb_getTheme_GetTheme_I;

	private static Delegate? cb_dismiss_Dismiss_V;

	private static Delegate? cb_dismissAllowingStateLoss_DismissAllowingStateLoss_V;

	private static Delegate? cb_dismissNow_DismissNow_V;

	private static Delegate? cb_onCancel_OnCancel_Landroid_content_DialogInterface__V;

	private static Delegate? cb_onCreateDialog_OnCreateDialog_Landroid_os_Bundle__Landroid_app_Dialog_;

	private static Delegate? cb_onDismiss_OnDismiss_Landroid_content_DialogInterface__V;

	private static Delegate? cb_setStyle_SetStyle_II_V;

	private static Delegate? cb_setupDialog_SetupDialog_Landroid_app_Dialog_I_V;

	private static Delegate? cb_show_Show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String__V;

	private static Delegate? cb_show_Show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String__I;

	private static Delegate? cb_showNow_ShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String__V;

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual bool Cancelable
	{
		[Register("isCancelable", "()Z", "GetIsCancelableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCancelable.()Z", this, null);
		}
		[Register("setCancelable", "(Z)V", "GetSetCancelable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCancelable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Dialog? Dialog
	{
		[Register("getDialog", "()Landroid/app/Dialog;", "GetGetDialogHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDialog.()Landroid/app/Dialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool ShowsDialog
	{
		[Register("getShowsDialog", "()Z", "GetGetShowsDialogHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getShowsDialog.()Z", this, null);
		}
		[Register("setShowsDialog", "(Z)V", "GetSetShowsDialog_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShowsDialog.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int Theme
	{
		[Register("getTheme", "()I", "GetGetThemeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTheme.()I", this, null);
		}
	}

	protected DialogFragment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe DialogFragment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe DialogFragment(int contentLayoutId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentLayoutId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCancelable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancelable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetCancelable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCancelable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCancelable_Z(nint jnienv, nint native__this, sbyte native_cancelable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool cancelable = native_cancelable != 0;
			dialogFragment.Cancelable = cancelable;
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

	private static Delegate GetGetDialogHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDialog);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDialog(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dialog);
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

	private static Delegate GetGetShowsDialogHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetShowsDialog);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetShowsDialog(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowsDialog ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetShowsDialog_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShowsDialog_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShowsDialog_Z(nint jnienv, nint native__this, sbyte native_showsDialog)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool showsDialog = native_showsDialog != 0;
			dialogFragment.ShowsDialog = showsDialog;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTheme(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Theme;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dismiss(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismiss();
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

	[Register("dismiss", "()V", "GetDismissHandler")]
	public unsafe virtual void Dismiss()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("dismiss.()V", this, null);
	}

	private static Delegate GetDismissAllowingStateLossHandler()
	{
		return new global::_JniMarshal_PP_V(n_DismissAllowingStateLoss);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DismissAllowingStateLoss(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DismissAllowingStateLoss();
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

	[Register("dismissAllowingStateLoss", "()V", "GetDismissAllowingStateLossHandler")]
	public unsafe virtual void DismissAllowingStateLoss()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("dismissAllowingStateLoss.()V", this, null);
	}

	private static Delegate GetDismissNowHandler()
	{
		return new global::_JniMarshal_PP_V(n_DismissNow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DismissNow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DismissNow();
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

	[Register("dismissNow", "()V", "GetDismissNowHandler")]
	public unsafe virtual void DismissNow()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("dismissNow.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCancel_Landroid_content_DialogInterface_(nint jnienv, nint native__this, nint native_dialog)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
			dialogFragment.OnCancel(dialog);
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

	[Register("onCancel", "(Landroid/content/DialogInterface;)V", "GetOnCancel_Landroid_content_DialogInterface_Handler")]
	public unsafe virtual void OnCancel(IDialogInterface dialog)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCancel.(Landroid/content/DialogInterface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateDialog_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(dialogFragment.OnCreateDialog(savedInstanceState));
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

	[Register("onCreateDialog", "(Landroid/os/Bundle;)Landroid/app/Dialog;", "GetOnCreateDialog_Landroid_os_Bundle_Handler")]
	public unsafe virtual Dialog OnCreateDialog(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateDialog.(Landroid/os/Bundle;)Landroid/app/Dialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDismiss_Landroid_content_DialogInterface_(nint jnienv, nint native__this, nint native_dialog)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDialogInterface dialog = Java.Lang.Object.GetObject<IDialogInterface>(native_dialog, JniHandleOwnership.DoNotTransfer);
			dialogFragment.OnDismiss(dialog);
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

	[Register("onDismiss", "(Landroid/content/DialogInterface;)V", "GetOnDismiss_Landroid_content_DialogInterface_Handler")]
	public unsafe virtual void OnDismiss(IDialogInterface dialog)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dialog == null) ? IntPtr.Zero : ((Java.Lang.Object)dialog).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDismiss.(Landroid/content/DialogInterface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
		}
	}

	[Register("requireComponentDialog", "()Landroidx/activity/ComponentDialog;", "")]
	public unsafe ComponentDialog RequireComponentDialog()
	{
		return Java.Lang.Object.GetObject<ComponentDialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireComponentDialog.()Landroidx/activity/ComponentDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("requireDialog", "()Landroid/app/Dialog;", "")]
	public unsafe Dialog RequireDialog()
	{
		return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("requireDialog.()Landroid/app/Dialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetStyle_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetStyle_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStyle_II(nint jnienv, nint native__this, int style, int theme)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStyle(style, theme);
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

	[Register("setStyle", "(II)V", "GetSetStyle_IIHandler")]
	public unsafe virtual void SetStyle(int style, int theme)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(style);
		ptr[1] = new JniArgumentValue(theme);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStyle.(II)V", this, ptr);
	}

	private static Delegate GetSetupDialog_Landroid_app_Dialog_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetupDialog_Landroid_app_Dialog_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetupDialog_Landroid_app_Dialog_I(nint jnienv, nint native__this, nint native_dialog, int style)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Dialog dialog = Java.Lang.Object.GetObject<Dialog>(native_dialog, JniHandleOwnership.DoNotTransfer);
			dialogFragment.SetupDialog(dialog, style);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setupDialog", "(Landroid/app/Dialog;I)V", "GetSetupDialog_Landroid_app_Dialog_IHandler")]
	public unsafe virtual void SetupDialog(Dialog dialog, int style)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dialog?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(style);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setupDialog.(Landroid/app/Dialog;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dialog);
		}
	}

	private static Delegate GetShow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Show_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_(nint jnienv, nint native__this, nint native_manager, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager manager = Java.Lang.Object.GetObject<FragmentManager>(native_manager, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			dialogFragment.Show(manager, tag);
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

	[Register("show", "(Landroidx/fragment/app/FragmentManager;Ljava/lang/String;)V", "GetShow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_Handler")]
	public unsafe virtual void Show(FragmentManager manager, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(manager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.(Landroidx/fragment/app/FragmentManager;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(manager);
		}
	}

	private static Delegate GetShow_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_I(n_Show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Show_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_(nint jnienv, nint native__this, nint native_transaction, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentTransaction transaction = Java.Lang.Object.GetObject<FragmentTransaction>(native_transaction, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			return dialogFragment.Show(transaction, tag);
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

	[Register("show", "(Landroidx/fragment/app/FragmentTransaction;Ljava/lang/String;)I", "GetShow_Landroidx_fragment_app_FragmentTransaction_Ljava_lang_String_Handler")]
	public unsafe virtual int Show(FragmentTransaction transaction, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(transaction?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("show.(Landroidx/fragment/app/FragmentTransaction;Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(transaction);
		}
	}

	private static Delegate GetShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_ShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_(nint jnienv, nint native__this, nint native_manager, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DialogFragment? dialogFragment = Java.Lang.Object.GetObject<DialogFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentManager manager = Java.Lang.Object.GetObject<FragmentManager>(native_manager, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			dialogFragment.ShowNow(manager, tag);
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

	[Register("showNow", "(Landroidx/fragment/app/FragmentManager;Ljava/lang/String;)V", "GetShowNow_Landroidx_fragment_app_FragmentManager_Ljava_lang_String_Handler")]
	public unsafe virtual void ShowNow(FragmentManager manager, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(manager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("showNow.(Landroidx/fragment/app/FragmentManager;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(manager);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}

	[UnmanagedCallersOnly]
	private static int n_GetTheme_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetTheme(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_OnCreateDialog_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnCreateDialog_Landroid_os_Bundle_(jnienv, native__this, native_savedInstanceState);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDismiss_Landroid_content_DialogInterface__mm_wrapper(nint jnienv, nint native__this, nint native_dialog)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDismiss_Landroid_content_DialogInterface_(jnienv, native__this, native_dialog);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_Dismiss_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Dismiss(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnCancel_Landroid_content_DialogInterface__mm_wrapper(nint jnienv, nint native__this, nint native_dialog)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnCancel_Landroid_content_DialogInterface_(jnienv, native__this, native_dialog);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_IsCancelable_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_IsCancelable(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
