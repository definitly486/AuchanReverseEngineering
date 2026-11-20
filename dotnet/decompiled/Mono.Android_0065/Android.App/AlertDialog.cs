using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.App;

[Register("android/app/AlertDialog", DoNotGenerateAcw = true)]
public class AlertDialog : Dialog, IDialogInterface, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/app/AlertDialog$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/AlertDialog$Builder", typeof(Builder));

		private static Delegate? cb_create_Create_Landroid_app_AlertDialog_;

		private static Delegate? cb_setMessage_SetMessage_Ljava_lang_CharSequence__Landroid_app_AlertDialog_Builder_;

		private static Delegate? cb_setNegativeButton_SetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener__Landroid_app_AlertDialog_Builder_;

		private static Delegate? cb_setOnCancelListener_SetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener__Landroid_app_AlertDialog_Builder_;

		private static Delegate? cb_setOnDismissListener_SetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener__Landroid_app_AlertDialog_Builder_;

		private static Delegate? cb_setPositiveButton_SetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener__Landroid_app_AlertDialog_Builder_;

		private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__Landroid_app_AlertDialog_Builder_;

		private static Delegate? cb_setView_SetView_Landroid_view_View__Landroid_app_AlertDialog_Builder_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public Builder? SetNegativeButton(string text, EventHandler<DialogClickEventArgs> handler)
		{
			return SetNegativeButton(text, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder? SetPositiveButton(string text, EventHandler<DialogClickEventArgs> handler)
		{
			return SetPositiveButton(text, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Builder(Context? context)
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

		private static Delegate GetCreateHandler()
		{
			return new _JniMarshal_PP_L(n_Create);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Create(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Create());
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

		[Register("create", "()Landroid/app/AlertDialog;", "GetCreateHandler")]
		public unsafe virtual AlertDialog? Create()
		{
			return Java.Lang.Object.GetObject<AlertDialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("create.()Landroid/app/AlertDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetMessage_Ljava_lang_CharSequence_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetMessage_Ljava_lang_CharSequence_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetMessage_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_message)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence message = Java.Lang.Object.GetObject<ICharSequence>(native_message, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetMessage(message));
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

		[Register("setMessage", "(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;", "GetSetMessage_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual Builder? SetMessage(ICharSequence? message)
		{
			nint num = CharSequence.ToLocalJniHandle(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMessage.(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(message);
			}
		}

		public Builder? SetMessage(string? message)
		{
			Java.Lang.String obj = ((message == null) ? null : new Java.Lang.String(message));
			Builder? result = SetMessage(obj);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetSetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new _JniMarshal_PPLL_L(n_SetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, nint native_text, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetNegativeButton(text, listener));
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

		[Register("setNegativeButton", "(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;", "GetSetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetNegativeButton(ICharSequence? text, IDialogInterfaceOnClickListener? listener)
		{
			nint num = CharSequence.ToLocalJniHandle(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNegativeButton.(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(text);
				GC.KeepAlive(listener);
			}
		}

		public Builder? SetNegativeButton(string? text, IDialogInterfaceOnClickListener? listener)
		{
			Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
			Builder? result = SetNegativeButton(obj, listener);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetSetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_(nint jnienv, nint native__this, nint native_onCancelListener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnCancelListener onCancelListener = Java.Lang.Object.GetObject<IDialogInterfaceOnCancelListener>(native_onCancelListener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetOnCancelListener(onCancelListener));
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

		[Register("setOnCancelListener", "(Landroid/content/DialogInterface$OnCancelListener;)Landroid/app/AlertDialog$Builder;", "GetSetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_Handler")]
		public unsafe virtual Builder? SetOnCancelListener(IDialogInterfaceOnCancelListener? onCancelListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((onCancelListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onCancelListener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOnCancelListener.(Landroid/content/DialogInterface$OnCancelListener;)Landroid/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(onCancelListener);
			}
		}

		private static Delegate GetSetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_(nint jnienv, nint native__this, nint native_onDismissListener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnDismissListener onDismissListener = Java.Lang.Object.GetObject<IDialogInterfaceOnDismissListener>(native_onDismissListener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetOnDismissListener(onDismissListener));
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

		[Register("setOnDismissListener", "(Landroid/content/DialogInterface$OnDismissListener;)Landroid/app/AlertDialog$Builder;", "GetSetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_Handler")]
		public unsafe virtual Builder? SetOnDismissListener(IDialogInterfaceOnDismissListener? onDismissListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((onDismissListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onDismissListener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOnDismissListener.(Landroid/content/DialogInterface$OnDismissListener;)Landroid/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(onDismissListener);
			}
		}

		private static Delegate GetSetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new _JniMarshal_PPLL_L(n_SetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, nint native_text, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetPositiveButton(text, listener));
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

		[Register("setPositiveButton", "(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;", "GetSetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetPositiveButton(ICharSequence? text, IDialogInterfaceOnClickListener? listener)
		{
			nint num = CharSequence.ToLocalJniHandle(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPositiveButton.(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(text);
				GC.KeepAlive(listener);
			}
		}

		public Builder? SetPositiveButton(string? text, IDialogInterfaceOnClickListener? listener)
		{
			Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
			Builder? result = SetPositiveButton(obj, listener);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetTitle_Ljava_lang_CharSequence_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetTitle(title));
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

		[Register("setTitle", "(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual Builder? SetTitle(ICharSequence? title)
		{
			nint num = CharSequence.ToLocalJniHandle(title);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTitle.(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(title);
			}
		}

		public Builder? SetTitle(string? title)
		{
			Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
			Builder? result = SetTitle(obj);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetSetView_Landroid_view_View_Handler()
		{
			return new _JniMarshal_PPL_L(n_SetView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetView(view));
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

		[Register("setView", "(Landroid/view/View;)Landroid/app/AlertDialog$Builder;", "GetSetView_Landroid_view_View_Handler")]
		public unsafe virtual Builder? SetView(View? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setView.(Landroid/view/View;)Landroid/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/AlertDialog", typeof(AlertDialog));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected AlertDialog(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
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
}
