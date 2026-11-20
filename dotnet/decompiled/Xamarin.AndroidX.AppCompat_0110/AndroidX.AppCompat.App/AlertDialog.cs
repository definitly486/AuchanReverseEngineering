using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Database;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/AlertDialog", DoNotGenerateAcw = true)]
public class AlertDialog : AppCompatDialog, IDialogInterface, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/appcompat/app/AlertDialog$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/AlertDialog$Builder", typeof(Builder));

		private static Delegate? cb_getContext_GetContext_Landroid_content_Context_;

		private static Delegate? cb_create_Create_Landroidx_appcompat_app_AlertDialog_;

		private static Delegate? cb_setAdapter_SetAdapter_Landroid_widget_ListAdapter_Landroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setCancelable_SetCancelable_Z_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setCursor_SetCursor_Landroid_database_Cursor_Landroid_content_DialogInterface_OnClickListener_Ljava_lang_String__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setCustomTitle_SetCustomTitle_Landroid_view_View__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setIcon_SetIcon_I_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setIconAttribute_SetIconAttribute_I_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setInverseBackgroundForced_SetInverseBackgroundForced_Z_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setItems_SetItems_ILandroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setItems_SetItems_arrayLjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setMessage_SetMessage_I_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setMessage_SetMessage_Ljava_lang_CharSequence__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setMultiChoiceItems_SetMultiChoiceItems_Landroid_database_Cursor_Ljava_lang_String_Ljava_lang_String_Landroid_content_DialogInterface_OnMultiChoiceClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setMultiChoiceItems_SetMultiChoiceItems_IarrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setMultiChoiceItems_SetMultiChoiceItems_arrayLjava_lang_CharSequence_arrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setNegativeButton_SetNegativeButton_ILandroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setNegativeButton_SetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setNegativeButtonIcon_SetNegativeButtonIcon_Landroid_graphics_drawable_Drawable__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setNeutralButton_SetNeutralButton_ILandroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setNeutralButton_SetNeutralButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setNeutralButtonIcon_SetNeutralButtonIcon_Landroid_graphics_drawable_Drawable__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setOnCancelListener_SetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setOnDismissListener_SetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setOnItemSelectedListener_SetOnItemSelectedListener_Landroid_widget_AdapterView_OnItemSelectedListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setOnKeyListener_SetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setPositiveButton_SetPositiveButton_ILandroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setPositiveButton_SetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setPositiveButtonIcon_SetPositiveButtonIcon_Landroid_graphics_drawable_Drawable__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setRecycleOnMeasureEnabled_SetRecycleOnMeasureEnabled_Z_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setSingleChoiceItems_SetSingleChoiceItems_Landroid_database_Cursor_ILjava_lang_String_Landroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setSingleChoiceItems_SetSingleChoiceItems_Landroid_widget_ListAdapter_ILandroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setSingleChoiceItems_SetSingleChoiceItems_IILandroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setSingleChoiceItems_SetSingleChoiceItems_arrayLjava_lang_CharSequence_ILandroid_content_DialogInterface_OnClickListener__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setTitle_SetTitle_I_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setView_SetView_Landroid_view_View__Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setView_SetView_Landroid_view_View_IIII_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_setView_SetView_I_Landroidx_appcompat_app_AlertDialog_Builder_;

		private static Delegate? cb_show_Show_Landroidx_appcompat_app_AlertDialog_;

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

		public unsafe virtual Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public Builder SetAdapter(IListAdapter adapter, EventHandler<DialogClickEventArgs> handler)
		{
			return SetAdapter(adapter, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetCursor(ICursor cursor, EventHandler<DialogClickEventArgs> handler, string labelColumn)
		{
			return SetCursor(cursor, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			}, labelColumn);
		}

		public Builder SetItems(int itemsId, EventHandler<DialogClickEventArgs> handler)
		{
			return SetItems(itemsId, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetItems(ICharSequence[] items, EventHandler<DialogClickEventArgs> handler)
		{
			return SetItems(items, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetItems(string[] items, EventHandler<DialogClickEventArgs> handler)
		{
			return SetItems(items, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetMultiChoiceItems(int itemsId, bool[] checkedItems, EventHandler<DialogMultiChoiceClickEventArgs> handler)
		{
			return SetMultiChoiceItems(itemsId, checkedItems, new IDialogInterfaceOnMultiChoiceClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetMultiChoiceItems(ICharSequence[] items, bool[] checkedItems, EventHandler<DialogMultiChoiceClickEventArgs> handler)
		{
			return SetMultiChoiceItems(items, checkedItems, new IDialogInterfaceOnMultiChoiceClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetMultiChoiceItems(string[] items, bool[] checkedItems, EventHandler<DialogMultiChoiceClickEventArgs> handler)
		{
			return SetMultiChoiceItems(items, checkedItems, new IDialogInterfaceOnMultiChoiceClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetMultiChoiceItems(ICursor cursor, string isCheckedColumn, string labelColumn, EventHandler<DialogMultiChoiceClickEventArgs> handler)
		{
			return SetMultiChoiceItems(cursor, isCheckedColumn, labelColumn, new IDialogInterfaceOnMultiChoiceClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetNegativeButton(int textId, EventHandler<DialogClickEventArgs> handler)
		{
			return SetNegativeButton(textId, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetNegativeButton(ICharSequence text, EventHandler<DialogClickEventArgs> handler)
		{
			return SetNegativeButton(text, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetNegativeButton(string text, EventHandler<DialogClickEventArgs> handler)
		{
			return SetNegativeButton(text, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetNeutralButton(int textId, EventHandler<DialogClickEventArgs> handler)
		{
			return SetNeutralButton(textId, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetNeutralButton(ICharSequence text, EventHandler<DialogClickEventArgs> handler)
		{
			return SetNeutralButton(text, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetNeutralButton(string text, EventHandler<DialogClickEventArgs> handler)
		{
			return SetNeutralButton(text, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetPositiveButton(int textId, EventHandler<DialogClickEventArgs> handler)
		{
			return SetPositiveButton(textId, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetPositiveButton(ICharSequence text, EventHandler<DialogClickEventArgs> handler)
		{
			return SetPositiveButton(text, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetPositiveButton(string text, EventHandler<DialogClickEventArgs> handler)
		{
			return SetPositiveButton(text, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetSingleChoiceItems(int itemsId, int checkedItem, EventHandler<DialogClickEventArgs> handler)
		{
			return SetSingleChoiceItems(itemsId, checkedItem, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetSingleChoiceItems(ICursor cursor, int checkedItem, string labelColumn, EventHandler<DialogClickEventArgs> handler)
		{
			return SetSingleChoiceItems(cursor, checkedItem, labelColumn, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetSingleChoiceItems(ICharSequence[] items, int checkedItem, EventHandler<DialogClickEventArgs> handler)
		{
			return SetSingleChoiceItems(items, checkedItem, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetSingleChoiceItems(string[] items, int checkedItem, EventHandler<DialogClickEventArgs> handler)
		{
			return SetSingleChoiceItems(items, checkedItem, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		public Builder SetSingleChoiceItems(IListAdapter adapter, int checkedItem, EventHandler<DialogClickEventArgs> handler)
		{
			return SetSingleChoiceItems(adapter, checkedItem, new IDialogInterfaceOnClickListenerImplementor
			{
				Handler = handler
			});
		}

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Builder(Context context)
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

		[Register(".ctor", "(Landroid/content/Context;I)V", "")]
		public unsafe Builder(Context context, int themeResId)
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
				ptr[1] = new JniArgumentValue(themeResId);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetContextHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetContext);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetContext(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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

		private static Delegate GetCreateHandler()
		{
			return new global::_JniMarshal_PP_L(n_Create);
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

		[Register("create", "()Landroidx/appcompat/app/AlertDialog;", "GetCreateHandler")]
		public unsafe virtual AlertDialog Create()
		{
			return Java.Lang.Object.GetObject<AlertDialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("create.()Landroidx/appcompat/app/AlertDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetAdapter_Landroid_widget_ListAdapter_Landroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_SetAdapter_Landroid_widget_ListAdapter_Landroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetAdapter_Landroid_widget_ListAdapter_Landroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, nint native_adapter, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IListAdapter adapter = Java.Lang.Object.GetObject<IListAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetAdapter(adapter, listener));
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

		[Register("setAdapter", "(Landroid/widget/ListAdapter;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetAdapter_Landroid_widget_ListAdapter_Landroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetAdapter(IListAdapter? adapter, IDialogInterfaceOnClickListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((adapter == null) ? IntPtr.Zero : ((Java.Lang.Object)adapter).Handle);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAdapter.(Landroid/widget/ListAdapter;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(adapter);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetCancelable_ZHandler()
		{
			return new global::_JniMarshal_PPB_L(n_SetCancelable_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetCancelable_Z(nint jnienv, nint native__this, sbyte native_cancelable)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool cancelable = native_cancelable != 0;
				return JNIEnv.ToLocalJniHandle(builder.SetCancelable(cancelable));
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

		[Register("setCancelable", "(Z)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetCancelable_ZHandler")]
		public unsafe virtual Builder? SetCancelable(bool cancelable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cancelable ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCancelable.(Z)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetCursor_Landroid_database_Cursor_Landroid_content_DialogInterface_OnClickListener_Ljava_lang_String_Handler()
		{
			return new global::_JniMarshal_PPLLL_L(n_SetCursor_Landroid_database_Cursor_Landroid_content_DialogInterface_OnClickListener_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetCursor_Landroid_database_Cursor_Landroid_content_DialogInterface_OnClickListener_Ljava_lang_String_(nint jnienv, nint native__this, nint native_cursor, nint native_listener, nint native_labelColumn)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				string labelColumn = JNIEnv.GetString(native_labelColumn, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetCursor(cursor, listener, labelColumn));
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

		[Register("setCursor", "(Landroid/database/Cursor;Landroid/content/DialogInterface$OnClickListener;Ljava/lang/String;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetCursor_Landroid_database_Cursor_Landroid_content_DialogInterface_OnClickListener_Ljava_lang_String_Handler")]
		public unsafe virtual Builder? SetCursor(ICursor? cursor, IDialogInterfaceOnClickListener? listener, string? labelColumn)
		{
			nint num = JNIEnv.NewString(labelColumn);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				ptr[2] = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCursor.(Landroid/database/Cursor;Landroid/content/DialogInterface$OnClickListener;Ljava/lang/String;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(cursor);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetCustomTitle_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetCustomTitle_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetCustomTitle_Landroid_view_View_(nint jnienv, nint native__this, nint native_customTitleView)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Android.Views.View customTitle = Java.Lang.Object.GetObject<Android.Views.View>(native_customTitleView, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetCustomTitle(customTitle));
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

		[Register("setCustomTitle", "(Landroid/view/View;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetCustomTitle_Landroid_view_View_Handler")]
		public unsafe virtual Builder? SetCustomTitle(Android.Views.View? customTitleView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(customTitleView?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCustomTitle.(Landroid/view/View;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(customTitleView);
			}
		}

		private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetIcon_Landroid_graphics_drawable_Drawable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetIcon(icon));
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

		[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual Builder? SetIcon(Drawable? icon)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIcon.(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(icon);
			}
		}

		private static Delegate GetSetIcon_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetIcon_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetIcon_I(nint jnienv, nint native__this, int iconId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(iconId));
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

		[Register("setIcon", "(I)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetIcon_IHandler")]
		public unsafe virtual Builder? SetIcon(int iconId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(iconId);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIcon.(I)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetIconAttribute_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetIconAttribute_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetIconAttribute_I(nint jnienv, nint native__this, int attrId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIconAttribute(attrId));
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

		[Register("setIconAttribute", "(I)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetIconAttribute_IHandler")]
		public unsafe virtual Builder? SetIconAttribute(int attrId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(attrId);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIconAttribute.(I)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete]
		private static Delegate GetSetInverseBackgroundForced_ZHandler()
		{
			return new global::_JniMarshal_PPB_L(n_SetInverseBackgroundForced_Z);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetInverseBackgroundForced_Z(nint jnienv, nint native__this, sbyte native_useInverseBackground)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool inverseBackgroundForced = native_useInverseBackground != 0;
				return JNIEnv.ToLocalJniHandle(builder.SetInverseBackgroundForced(inverseBackgroundForced));
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
		[Register("setInverseBackgroundForced", "(Z)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetInverseBackgroundForced_ZHandler")]
		public unsafe virtual Builder? SetInverseBackgroundForced(bool useInverseBackground)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(useInverseBackground ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setInverseBackgroundForced.(Z)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetItems_ILandroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPIL_L(n_SetItems_ILandroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetItems_ILandroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, int itemsId, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetItems(itemsId, listener));
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

		[Register("setItems", "(ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetItems_ILandroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetItems(int itemsId, IDialogInterfaceOnClickListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(itemsId);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setItems.(ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetItems_arrayLjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_SetItems_arrayLjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetItems_arrayLjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, nint native_items, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence[] array = (ICharSequence[])JNIEnv.GetArray(native_items, JniHandleOwnership.DoNotTransfer, typeof(ICharSequence));
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				nint result = JNIEnv.ToLocalJniHandle(builder.SetItems(array, listener));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_items);
				}
				return result;
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

		[Register("setItems", "([Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetItems_arrayLjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetItems(ICharSequence[]? items, IDialogInterfaceOnClickListener? listener)
		{
			nint num = JNIEnv.NewArray(items);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setItems.([Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (items != null)
				{
					JNIEnv.CopyArray(num, items);
					JNIEnv.DeleteLocalRef(num);
				}
				GC.KeepAlive(items);
				GC.KeepAlive(listener);
			}
		}

		public Builder? SetItems(string[]? items, IDialogInterfaceOnClickListener? listener)
		{
			ICharSequence[] array = CharSequence.ArrayFromStringArray(items);
			Builder result = SetItems(array, listener);
			if (array != null)
			{
				ICharSequence[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i]?.Dispose();
				}
			}
			return result;
		}

		private static Delegate GetSetMessage_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetMessage_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetMessage_I(nint jnienv, nint native__this, int messageId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMessage(messageId));
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

		[Register("setMessage", "(I)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetMessage_IHandler")]
		public unsafe virtual Builder? SetMessage(int messageId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(messageId);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMessage.(I)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetMessage_Ljava_lang_CharSequence_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetMessage_Ljava_lang_CharSequence_);
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

		[Register("setMessage", "(Ljava/lang/CharSequence;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetMessage_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual Builder? SetMessage(ICharSequence? message)
		{
			nint num = CharSequence.ToLocalJniHandle(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMessage.(Ljava/lang/CharSequence;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

		private static Delegate GetSetMultiChoiceItems_Landroid_database_Cursor_Ljava_lang_String_Ljava_lang_String_Landroid_content_DialogInterface_OnMultiChoiceClickListener_Handler()
		{
			return new global::_JniMarshal_PPLLLL_L(n_SetMultiChoiceItems_Landroid_database_Cursor_Ljava_lang_String_Ljava_lang_String_Landroid_content_DialogInterface_OnMultiChoiceClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetMultiChoiceItems_Landroid_database_Cursor_Ljava_lang_String_Ljava_lang_String_Landroid_content_DialogInterface_OnMultiChoiceClickListener_(nint jnienv, nint native__this, nint native_cursor, nint native_isCheckedColumn, nint native_labelColumn, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
				string isCheckedColumn = JNIEnv.GetString(native_isCheckedColumn, JniHandleOwnership.DoNotTransfer);
				string labelColumn = JNIEnv.GetString(native_labelColumn, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnMultiChoiceClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnMultiChoiceClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetMultiChoiceItems(cursor, isCheckedColumn, labelColumn, listener));
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

		[Register("setMultiChoiceItems", "(Landroid/database/Cursor;Ljava/lang/String;Ljava/lang/String;Landroid/content/DialogInterface$OnMultiChoiceClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetMultiChoiceItems_Landroid_database_Cursor_Ljava_lang_String_Ljava_lang_String_Landroid_content_DialogInterface_OnMultiChoiceClickListener_Handler")]
		public unsafe virtual Builder? SetMultiChoiceItems(ICursor? cursor, string? isCheckedColumn, string? labelColumn, IDialogInterfaceOnMultiChoiceClickListener? listener)
		{
			nint num = JNIEnv.NewString(isCheckedColumn);
			nint num2 = JNIEnv.NewString(labelColumn);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(num2);
				ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMultiChoiceItems.(Landroid/database/Cursor;Ljava/lang/String;Ljava/lang/String;Landroid/content/DialogInterface$OnMultiChoiceClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				JNIEnv.DeleteLocalRef(num2);
				GC.KeepAlive(cursor);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetMultiChoiceItems_IarrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener_Handler()
		{
			return new global::_JniMarshal_PPILL_L(n_SetMultiChoiceItems_IarrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetMultiChoiceItems_IarrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener_(nint jnienv, nint native__this, int itemsId, nint native_checkedItems, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool[] array = (bool[])JNIEnv.GetArray(native_checkedItems, JniHandleOwnership.DoNotTransfer, typeof(bool));
				IDialogInterfaceOnMultiChoiceClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnMultiChoiceClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				nint result = JNIEnv.ToLocalJniHandle(builder.SetMultiChoiceItems(itemsId, array, listener));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_checkedItems);
				}
				return result;
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

		[Register("setMultiChoiceItems", "(I[ZLandroid/content/DialogInterface$OnMultiChoiceClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetMultiChoiceItems_IarrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener_Handler")]
		public unsafe virtual Builder? SetMultiChoiceItems(int itemsId, bool[]? checkedItems, IDialogInterfaceOnMultiChoiceClickListener? listener)
		{
			nint num = JNIEnv.NewArray(checkedItems);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(itemsId);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMultiChoiceItems.(I[ZLandroid/content/DialogInterface$OnMultiChoiceClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (checkedItems != null)
				{
					JNIEnv.CopyArray(num, checkedItems);
					JNIEnv.DeleteLocalRef(num);
				}
				GC.KeepAlive(checkedItems);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetMultiChoiceItems_arrayLjava_lang_CharSequence_arrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener_Handler()
		{
			return new global::_JniMarshal_PPLLL_L(n_SetMultiChoiceItems_arrayLjava_lang_CharSequence_arrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetMultiChoiceItems_arrayLjava_lang_CharSequence_arrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener_(nint jnienv, nint native__this, nint native_items, nint native_checkedItems, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence[] array = (ICharSequence[])JNIEnv.GetArray(native_items, JniHandleOwnership.DoNotTransfer, typeof(ICharSequence));
				bool[] array2 = (bool[])JNIEnv.GetArray(native_checkedItems, JniHandleOwnership.DoNotTransfer, typeof(bool));
				IDialogInterfaceOnMultiChoiceClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnMultiChoiceClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				nint result = JNIEnv.ToLocalJniHandle(builder.SetMultiChoiceItems(array, array2, listener));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_items);
				}
				if (array2 != null)
				{
					JNIEnv.CopyArray(array2, native_checkedItems);
				}
				return result;
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

		[Register("setMultiChoiceItems", "([Ljava/lang/CharSequence;[ZLandroid/content/DialogInterface$OnMultiChoiceClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetMultiChoiceItems_arrayLjava_lang_CharSequence_arrayZLandroid_content_DialogInterface_OnMultiChoiceClickListener_Handler")]
		public unsafe virtual Builder? SetMultiChoiceItems(ICharSequence[]? items, bool[]? checkedItems, IDialogInterfaceOnMultiChoiceClickListener? listener)
		{
			nint num = JNIEnv.NewArray(items);
			nint num2 = JNIEnv.NewArray(checkedItems);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(num2);
				ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMultiChoiceItems.([Ljava/lang/CharSequence;[ZLandroid/content/DialogInterface$OnMultiChoiceClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (items != null)
				{
					JNIEnv.CopyArray(num, items);
					JNIEnv.DeleteLocalRef(num);
				}
				if (checkedItems != null)
				{
					JNIEnv.CopyArray(num2, checkedItems);
					JNIEnv.DeleteLocalRef(num2);
				}
				GC.KeepAlive(items);
				GC.KeepAlive(checkedItems);
				GC.KeepAlive(listener);
			}
		}

		public Builder? SetMultiChoiceItems(string[]? items, bool[]? checkedItems, IDialogInterfaceOnMultiChoiceClickListener? listener)
		{
			ICharSequence[] array = CharSequence.ArrayFromStringArray(items);
			Builder result = SetMultiChoiceItems(array, checkedItems, listener);
			if (array != null)
			{
				ICharSequence[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i]?.Dispose();
				}
			}
			return result;
		}

		private static Delegate GetSetNegativeButton_ILandroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPIL_L(n_SetNegativeButton_ILandroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetNegativeButton_ILandroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, int textId, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetNegativeButton(textId, listener));
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

		[Register("setNegativeButton", "(ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetNegativeButton_ILandroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetNegativeButton(int textId, IDialogInterfaceOnClickListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(textId);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNegativeButton.(ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_SetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_);
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

		[Register("setNegativeButton", "(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetNegativeButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetNegativeButton(ICharSequence? text, IDialogInterfaceOnClickListener? listener)
		{
			nint num = CharSequence.ToLocalJniHandle(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNegativeButton.(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

		private static Delegate GetSetNegativeButtonIcon_Landroid_graphics_drawable_Drawable_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetNegativeButtonIcon_Landroid_graphics_drawable_Drawable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetNegativeButtonIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Drawable negativeButtonIcon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetNegativeButtonIcon(negativeButtonIcon));
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

		[Register("setNegativeButtonIcon", "(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetNegativeButtonIcon_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual Builder? SetNegativeButtonIcon(Drawable? icon)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNegativeButtonIcon.(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(icon);
			}
		}

		private static Delegate GetSetNeutralButton_ILandroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPIL_L(n_SetNeutralButton_ILandroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetNeutralButton_ILandroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, int textId, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetNeutralButton(textId, listener));
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

		[Register("setNeutralButton", "(ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetNeutralButton_ILandroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetNeutralButton(int textId, IDialogInterfaceOnClickListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(textId);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNeutralButton.(ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetNeutralButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_SetNeutralButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetNeutralButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, nint native_text, nint native_listener)
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
				return JNIEnv.ToLocalJniHandle(builder.SetNeutralButton(text, listener));
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

		[Register("setNeutralButton", "(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetNeutralButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetNeutralButton(ICharSequence? text, IDialogInterfaceOnClickListener? listener)
		{
			nint num = CharSequence.ToLocalJniHandle(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNeutralButton.(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(text);
				GC.KeepAlive(listener);
			}
		}

		public Builder? SetNeutralButton(string? text, IDialogInterfaceOnClickListener? listener)
		{
			Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
			Builder? result = SetNeutralButton(obj, listener);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetSetNeutralButtonIcon_Landroid_graphics_drawable_Drawable_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetNeutralButtonIcon_Landroid_graphics_drawable_Drawable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetNeutralButtonIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Drawable neutralButtonIcon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetNeutralButtonIcon(neutralButtonIcon));
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

		[Register("setNeutralButtonIcon", "(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetNeutralButtonIcon_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual Builder? SetNeutralButtonIcon(Drawable? icon)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNeutralButtonIcon.(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(icon);
			}
		}

		private static Delegate GetSetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_);
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

		[Register("setOnCancelListener", "(Landroid/content/DialogInterface$OnCancelListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetOnCancelListener_Landroid_content_DialogInterface_OnCancelListener_Handler")]
		public unsafe virtual Builder? SetOnCancelListener(IDialogInterfaceOnCancelListener? onCancelListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((onCancelListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onCancelListener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOnCancelListener.(Landroid/content/DialogInterface$OnCancelListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(onCancelListener);
			}
		}

		private static Delegate GetSetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_);
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

		[Register("setOnDismissListener", "(Landroid/content/DialogInterface$OnDismissListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetOnDismissListener_Landroid_content_DialogInterface_OnDismissListener_Handler")]
		public unsafe virtual Builder? SetOnDismissListener(IDialogInterfaceOnDismissListener? onDismissListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((onDismissListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onDismissListener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOnDismissListener.(Landroid/content/DialogInterface$OnDismissListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(onDismissListener);
			}
		}

		private static Delegate GetSetOnItemSelectedListener_Landroid_widget_AdapterView_OnItemSelectedListener_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetOnItemSelectedListener_Landroid_widget_AdapterView_OnItemSelectedListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetOnItemSelectedListener_Landroid_widget_AdapterView_OnItemSelectedListener_(nint jnienv, nint native__this, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AdapterView.IOnItemSelectedListener onItemSelectedListener = Java.Lang.Object.GetObject<AdapterView.IOnItemSelectedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetOnItemSelectedListener(onItemSelectedListener));
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

		[Register("setOnItemSelectedListener", "(Landroid/widget/AdapterView$OnItemSelectedListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetOnItemSelectedListener_Landroid_widget_AdapterView_OnItemSelectedListener_Handler")]
		public unsafe virtual Builder? SetOnItemSelectedListener(AdapterView.IOnItemSelectedListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOnItemSelectedListener.(Landroid/widget/AdapterView$OnItemSelectedListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener_(nint jnienv, nint native__this, nint native_onKeyListener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnKeyListener onKeyListener = Java.Lang.Object.GetObject<IDialogInterfaceOnKeyListener>(native_onKeyListener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetOnKeyListener(onKeyListener));
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

		[Register("setOnKeyListener", "(Landroid/content/DialogInterface$OnKeyListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetOnKeyListener_Landroid_content_DialogInterface_OnKeyListener_Handler")]
		public unsafe virtual Builder? SetOnKeyListener(IDialogInterfaceOnKeyListener? onKeyListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((onKeyListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onKeyListener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOnKeyListener.(Landroid/content/DialogInterface$OnKeyListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(onKeyListener);
			}
		}

		private static Delegate GetSetPositiveButton_ILandroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPIL_L(n_SetPositiveButton_ILandroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetPositiveButton_ILandroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, int textId, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetPositiveButton(textId, listener));
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

		[Register("setPositiveButton", "(ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetPositiveButton_ILandroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetPositiveButton(int textId, IDialogInterfaceOnClickListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(textId);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPositiveButton.(ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_SetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_);
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

		[Register("setPositiveButton", "(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetPositiveButton_Ljava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetPositiveButton(ICharSequence? text, IDialogInterfaceOnClickListener? listener)
		{
			nint num = CharSequence.ToLocalJniHandle(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPositiveButton.(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

		private static Delegate GetSetPositiveButtonIcon_Landroid_graphics_drawable_Drawable_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetPositiveButtonIcon_Landroid_graphics_drawable_Drawable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetPositiveButtonIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Drawable positiveButtonIcon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetPositiveButtonIcon(positiveButtonIcon));
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

		[Register("setPositiveButtonIcon", "(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetPositiveButtonIcon_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual Builder? SetPositiveButtonIcon(Drawable? icon)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPositiveButtonIcon.(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(icon);
			}
		}

		private static Delegate GetSetRecycleOnMeasureEnabled_ZHandler()
		{
			return new global::_JniMarshal_PPB_L(n_SetRecycleOnMeasureEnabled_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetRecycleOnMeasureEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool recycleOnMeasureEnabled = native_enabled != 0;
				return JNIEnv.ToLocalJniHandle(builder.SetRecycleOnMeasureEnabled(recycleOnMeasureEnabled));
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

		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setRecycleOnMeasureEnabled", "(Z)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetRecycleOnMeasureEnabled_ZHandler")]
		public unsafe virtual Builder? SetRecycleOnMeasureEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setRecycleOnMeasureEnabled.(Z)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetSingleChoiceItems_Landroid_database_Cursor_ILjava_lang_String_Landroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new _JniMarshal_PPLILL_L(n_SetSingleChoiceItems_Landroid_database_Cursor_ILjava_lang_String_Landroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetSingleChoiceItems_Landroid_database_Cursor_ILjava_lang_String_Landroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, nint native_cursor, int checkedItem, nint native_labelColumn, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
				string labelColumn = JNIEnv.GetString(native_labelColumn, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSingleChoiceItems(cursor, checkedItem, labelColumn, listener));
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

		[Register("setSingleChoiceItems", "(Landroid/database/Cursor;ILjava/lang/String;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetSingleChoiceItems_Landroid_database_Cursor_ILjava_lang_String_Landroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetSingleChoiceItems(ICursor? cursor, int checkedItem, string? labelColumn, IDialogInterfaceOnClickListener? listener)
		{
			nint num = JNIEnv.NewString(labelColumn);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				ptr[1] = new JniArgumentValue(checkedItem);
				ptr[2] = new JniArgumentValue(num);
				ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSingleChoiceItems.(Landroid/database/Cursor;ILjava/lang/String;Landroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(cursor);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetSingleChoiceItems_Landroid_widget_ListAdapter_ILandroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new _JniMarshal_PPLIL_L(n_SetSingleChoiceItems_Landroid_widget_ListAdapter_ILandroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetSingleChoiceItems_Landroid_widget_ListAdapter_ILandroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, nint native_adapter, int checkedItem, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IListAdapter adapter = Java.Lang.Object.GetObject<IListAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSingleChoiceItems(adapter, checkedItem, listener));
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

		[Register("setSingleChoiceItems", "(Landroid/widget/ListAdapter;ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetSingleChoiceItems_Landroid_widget_ListAdapter_ILandroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetSingleChoiceItems(IListAdapter? adapter, int checkedItem, IDialogInterfaceOnClickListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((adapter == null) ? IntPtr.Zero : ((Java.Lang.Object)adapter).Handle);
				ptr[1] = new JniArgumentValue(checkedItem);
				ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSingleChoiceItems.(Landroid/widget/ListAdapter;ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(adapter);
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetSingleChoiceItems_IILandroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new global::_JniMarshal_PPIIL_L(n_SetSingleChoiceItems_IILandroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetSingleChoiceItems_IILandroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, int itemsId, int checkedItem, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSingleChoiceItems(itemsId, checkedItem, listener));
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

		[Register("setSingleChoiceItems", "(IILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetSingleChoiceItems_IILandroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetSingleChoiceItems(int itemsId, int checkedItem, IDialogInterfaceOnClickListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(itemsId);
				ptr[1] = new JniArgumentValue(checkedItem);
				ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSingleChoiceItems.(IILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetSingleChoiceItems_arrayLjava_lang_CharSequence_ILandroid_content_DialogInterface_OnClickListener_Handler()
		{
			return new _JniMarshal_PPLIL_L(n_SetSingleChoiceItems_arrayLjava_lang_CharSequence_ILandroid_content_DialogInterface_OnClickListener_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetSingleChoiceItems_arrayLjava_lang_CharSequence_ILandroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, nint native_items, int checkedItem, nint native_listener)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence[] array = (ICharSequence[])JNIEnv.GetArray(native_items, JniHandleOwnership.DoNotTransfer, typeof(ICharSequence));
				IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
				nint result = JNIEnv.ToLocalJniHandle(builder.SetSingleChoiceItems(array, checkedItem, listener));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_items);
				}
				return result;
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

		[Register("setSingleChoiceItems", "([Ljava/lang/CharSequence;ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetSingleChoiceItems_arrayLjava_lang_CharSequence_ILandroid_content_DialogInterface_OnClickListener_Handler")]
		public unsafe virtual Builder? SetSingleChoiceItems(ICharSequence[]? items, int checkedItem, IDialogInterfaceOnClickListener? listener)
		{
			nint num = JNIEnv.NewArray(items);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(checkedItem);
				ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSingleChoiceItems.([Ljava/lang/CharSequence;ILandroid/content/DialogInterface$OnClickListener;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (items != null)
				{
					JNIEnv.CopyArray(num, items);
					JNIEnv.DeleteLocalRef(num);
				}
				GC.KeepAlive(items);
				GC.KeepAlive(listener);
			}
		}

		public Builder? SetSingleChoiceItems(string[]? items, int checkedItem, IDialogInterfaceOnClickListener? listener)
		{
			ICharSequence[] array = CharSequence.ArrayFromStringArray(items);
			Builder result = SetSingleChoiceItems(array, checkedItem, listener);
			if (array != null)
			{
				ICharSequence[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i]?.Dispose();
				}
			}
			return result;
		}

		private static Delegate GetSetTitle_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetTitle_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetTitle_I(nint jnienv, nint native__this, int titleId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTitle(titleId));
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

		[Register("setTitle", "(I)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetTitle_IHandler")]
		public unsafe virtual Builder? SetTitle(int titleId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(titleId);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTitle.(I)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetTitle_Ljava_lang_CharSequence_);
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

		[Register("setTitle", "(Ljava/lang/CharSequence;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual Builder? SetTitle(ICharSequence? title)
		{
			nint num = CharSequence.ToLocalJniHandle(title);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTitle.(Ljava/lang/CharSequence;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			return new global::_JniMarshal_PPL_L(n_SetView_Landroid_view_View_);
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
				Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
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

		[Register("setView", "(Landroid/view/View;)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetView_Landroid_view_View_Handler")]
		public unsafe virtual Builder? SetView(Android.Views.View? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setView.(Landroid/view/View;)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Obsolete]
		private static Delegate GetSetView_Landroid_view_View_IIIIHandler()
		{
			return new _JniMarshal_PPLIIII_L(n_SetView_Landroid_view_View_IIII);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetView_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_view, int viewSpacingLeft, int viewSpacingTop, int viewSpacingRight, int viewSpacingBottom)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetView(view, viewSpacingLeft, viewSpacingTop, viewSpacingRight, viewSpacingBottom));
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
		[Register("setView", "(Landroid/view/View;IIII)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetView_Landroid_view_View_IIIIHandler")]
		public unsafe virtual Builder? SetView(Android.Views.View? view, int viewSpacingLeft, int viewSpacingTop, int viewSpacingRight, int viewSpacingBottom)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewSpacingLeft);
				ptr[2] = new JniArgumentValue(viewSpacingTop);
				ptr[3] = new JniArgumentValue(viewSpacingRight);
				ptr[4] = new JniArgumentValue(viewSpacingBottom);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setView.(Landroid/view/View;IIII)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetSetView_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetView_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetView_I(nint jnienv, nint native__this, int layoutResId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetView(layoutResId));
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

		[Register("setView", "(I)Landroidx/appcompat/app/AlertDialog$Builder;", "GetSetView_IHandler")]
		public unsafe virtual Builder? SetView(int layoutResId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layoutResId);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setView.(I)Landroidx/appcompat/app/AlertDialog$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetShowHandler()
		{
			return new global::_JniMarshal_PP_L(n_Show);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Show(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show());
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

		[Register("show", "()Landroidx/appcompat/app/AlertDialog;", "GetShowHandler")]
		public unsafe virtual AlertDialog? Show()
		{
			return Java.Lang.Object.GetObject<AlertDialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("show.()Landroidx/appcompat/app/AlertDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private class IDialogInterfaceOnClickListenerImplementor : Java.Lang.Object, IDialogInterfaceOnClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<DialogClickEventArgs> Handler { get; set; }

		public void OnClick(IDialogInterface dialog, int which)
		{
			Handler?.Invoke(dialog, new DialogClickEventArgs(which));
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

	private class IDialogInterfaceOnCancelListenerImplementor : Java.Lang.Object, IDialogInterfaceOnCancelListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler Handler { get; set; }

		public void OnCancel(IDialogInterface dialog)
		{
			Handler?.Invoke(dialog, new EventArgs());
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

	private class IDialogInterfaceOnMultiChoiceClickListenerImplementor : Java.Lang.Object, IDialogInterfaceOnMultiChoiceClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<DialogMultiChoiceClickEventArgs> Handler { get; set; }

		public void OnClick(IDialogInterface dialog, int which, bool isChecked)
		{
			Handler?.Invoke(dialog, new DialogMultiChoiceClickEventArgs(which, isChecked));
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/AlertDialog", typeof(AlertDialog));

	private static Delegate? cb_getListView_GetListView_Landroid_widget_ListView_;

	private static Delegate? cb_getButton_GetButton_I_Landroid_widget_Button_;

	private static Delegate? cb_setButton_SetButton_ILjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener__V;

	private static Delegate? cb_setButton_SetButton_ILjava_lang_CharSequence_Landroid_graphics_drawable_Drawable_Landroid_content_DialogInterface_OnClickListener__V;

	private static Delegate? cb_setButton_SetButton_ILjava_lang_CharSequence_Landroid_os_Message__V;

	private static Delegate? cb_setCustomTitle_SetCustomTitle_Landroid_view_View__V;

	private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setIcon_SetIcon_I_V;

	private static Delegate? cb_setIconAttribute_SetIconAttribute_I_V;

	private static Delegate? cb_setMessage_SetMessage_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setView_SetView_Landroid_view_View__V;

	private static Delegate? cb_setView_SetView_Landroid_view_View_IIII_V;

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

	public unsafe virtual ListView? ListView
	{
		[Register("getListView", "()Landroid/widget/ListView;", "GetGetListViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ListView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getListView.()Landroid/widget/ListView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected AlertDialog(Context context, bool cancelable, EventHandler cancelHandler)
		: this(context, cancelable, new IDialogInterfaceOnCancelListenerImplementor
		{
			Handler = cancelHandler
		})
	{
	}

	public void SetButton(int whichButton, ICharSequence text, EventHandler<DialogClickEventArgs> handler)
	{
		SetButton(whichButton, text, new IDialogInterfaceOnClickListenerImplementor
		{
			Handler = handler
		});
	}

	public void SetButton(int whichButton, string text, EventHandler<DialogClickEventArgs> handler)
	{
		SetButton(whichButton, text, new IDialogInterfaceOnClickListenerImplementor
		{
			Handler = handler
		});
	}

	protected AlertDialog(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	protected unsafe AlertDialog(Context context)
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
	protected unsafe AlertDialog(Context context, bool cancelable, IDialogInterfaceOnCancelListener? cancelListener)
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
	protected unsafe AlertDialog(Context context, int themeResId)
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
			ptr[1] = new JniArgumentValue(themeResId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetListViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetListView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetListView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListView);
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

	private static Delegate GetGetButton_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetButton_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetButton_I(nint jnienv, nint native__this, int whichButton)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetButton(whichButton));
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

	[Register("getButton", "(I)Landroid/widget/Button;", "GetGetButton_IHandler")]
	public unsafe virtual Button? GetButton(int whichButton)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(whichButton);
		return Java.Lang.Object.GetObject<Button>(_members.InstanceMethods.InvokeVirtualObjectMethod("getButton.(I)Landroid/widget/Button;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetButton_ILjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler()
	{
		return new global::_JniMarshal_PPILL_V(n_SetButton_ILjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetButton_ILjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, int whichButton, nint native_text, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AlertDialog? alertDialog = Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			alertDialog.SetButton(whichButton, text, listener);
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

	[Register("setButton", "(ILjava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)V", "GetSetButton_ILjava_lang_CharSequence_Landroid_content_DialogInterface_OnClickListener_Handler")]
	public unsafe virtual void SetButton(int whichButton, ICharSequence? text, IDialogInterfaceOnClickListener? listener)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(whichButton);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setButton.(ILjava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
			GC.KeepAlive(listener);
		}
	}

	public void SetButton(int whichButton, string? text, IDialogInterfaceOnClickListener? listener)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		SetButton(whichButton, obj, listener);
		obj?.Dispose();
	}

	private static Delegate GetSetButton_ILjava_lang_CharSequence_Landroid_graphics_drawable_Drawable_Landroid_content_DialogInterface_OnClickListener_Handler()
	{
		return new global::_JniMarshal_PPILLL_V(n_SetButton_ILjava_lang_CharSequence_Landroid_graphics_drawable_Drawable_Landroid_content_DialogInterface_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetButton_ILjava_lang_CharSequence_Landroid_graphics_drawable_Drawable_Landroid_content_DialogInterface_OnClickListener_(nint jnienv, nint native__this, int whichButton, nint native_text, nint native_icon, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AlertDialog? alertDialog = Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnClickListener listener = Java.Lang.Object.GetObject<IDialogInterfaceOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			alertDialog.SetButton(whichButton, text, icon, listener);
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

	[Register("setButton", "(ILjava/lang/CharSequence;Landroid/graphics/drawable/Drawable;Landroid/content/DialogInterface$OnClickListener;)V", "GetSetButton_ILjava_lang_CharSequence_Landroid_graphics_drawable_Drawable_Landroid_content_DialogInterface_OnClickListener_Handler")]
	public unsafe virtual void SetButton(int whichButton, ICharSequence? text, Drawable? icon, IDialogInterfaceOnClickListener? listener)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(whichButton);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setButton.(ILjava/lang/CharSequence;Landroid/graphics/drawable/Drawable;Landroid/content/DialogInterface$OnClickListener;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
			GC.KeepAlive(icon);
			GC.KeepAlive(listener);
		}
	}

	public void SetButton(int whichButton, string? text, Drawable? icon, IDialogInterfaceOnClickListener? listener)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		SetButton(whichButton, obj, icon, listener);
		obj?.Dispose();
	}

	private static Delegate GetSetButton_ILjava_lang_CharSequence_Landroid_os_Message_Handler()
	{
		return new global::_JniMarshal_PPILL_V(n_SetButton_ILjava_lang_CharSequence_Landroid_os_Message_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetButton_ILjava_lang_CharSequence_Landroid_os_Message_(nint jnienv, nint native__this, int whichButton, nint native_text, nint native_msg)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AlertDialog? alertDialog = Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			Message msg = Java.Lang.Object.GetObject<Message>(native_msg, JniHandleOwnership.DoNotTransfer);
			alertDialog.SetButton(whichButton, text, msg);
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

	[Register("setButton", "(ILjava/lang/CharSequence;Landroid/os/Message;)V", "GetSetButton_ILjava_lang_CharSequence_Landroid_os_Message_Handler")]
	public unsafe virtual void SetButton(int whichButton, ICharSequence? text, Message? msg)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(whichButton);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(msg?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setButton.(ILjava/lang/CharSequence;Landroid/os/Message;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
			GC.KeepAlive(msg);
		}
	}

	public void SetButton(int whichButton, string? text, Message? msg)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		SetButton(whichButton, obj, msg);
		obj?.Dispose();
	}

	private static Delegate GetSetCustomTitle_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCustomTitle_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomTitle_Landroid_view_View_(nint jnienv, nint native__this, nint native_customTitleView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AlertDialog? alertDialog = Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View customTitle = Java.Lang.Object.GetObject<Android.Views.View>(native_customTitleView, JniHandleOwnership.DoNotTransfer);
			alertDialog.SetCustomTitle(customTitle);
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

	[Register("setCustomTitle", "(Landroid/view/View;)V", "GetSetCustomTitle_Landroid_view_View_Handler")]
	public unsafe virtual void SetCustomTitle(Android.Views.View? customTitleView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(customTitleView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomTitle.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(customTitleView);
		}
	}

	private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AlertDialog? alertDialog = Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			alertDialog.SetIcon(icon);
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

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetIcon(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	private static Delegate GetSetIcon_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIcon_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(resId);
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

	[Register("setIcon", "(I)V", "GetSetIcon_IHandler")]
	public unsafe virtual void SetIcon(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setIcon.(I)V", this, ptr);
	}

	private static Delegate GetSetIconAttribute_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIconAttribute_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconAttribute_I(nint jnienv, nint native__this, int attrId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIconAttribute(attrId);
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

	[Register("setIconAttribute", "(I)V", "GetSetIconAttribute_IHandler")]
	public unsafe virtual void SetIconAttribute(int attrId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(attrId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setIconAttribute.(I)V", this, ptr);
	}

	private static Delegate GetSetMessage_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetMessage_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMessage_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_message)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AlertDialog? alertDialog = Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence message = Java.Lang.Object.GetObject<ICharSequence>(native_message, JniHandleOwnership.DoNotTransfer);
			alertDialog.SetMessage(message);
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

	[Register("setMessage", "(Ljava/lang/CharSequence;)V", "GetSetMessage_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetMessage(ICharSequence? message)
	{
		nint num = CharSequence.ToLocalJniHandle(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMessage.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(message);
		}
	}

	public void SetMessage(string? message)
	{
		Java.Lang.String obj = ((message == null) ? null : new Java.Lang.String(message));
		SetMessage(obj);
		obj?.Dispose();
	}

	private static Delegate GetSetView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AlertDialog? alertDialog = Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			alertDialog.SetView(view);
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

	[Register("setView", "(Landroid/view/View;)V", "GetSetView_Landroid_view_View_Handler")]
	public unsafe virtual void SetView(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setView.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetView_Landroid_view_View_IIIIHandler()
	{
		return new global::_JniMarshal_PPLIIII_V(n_SetView_Landroid_view_View_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetView_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_view, int viewSpacingLeft, int viewSpacingTop, int viewSpacingRight, int viewSpacingBottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AlertDialog? alertDialog = Java.Lang.Object.GetObject<AlertDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			alertDialog.SetView(view, viewSpacingLeft, viewSpacingTop, viewSpacingRight, viewSpacingBottom);
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

	[Register("setView", "(Landroid/view/View;IIII)V", "GetSetView_Landroid_view_View_IIIIHandler")]
	public unsafe virtual void SetView(Android.Views.View? view, int viewSpacingLeft, int viewSpacingTop, int viewSpacingRight, int viewSpacingBottom)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(viewSpacingLeft);
			ptr[2] = new JniArgumentValue(viewSpacingTop);
			ptr[3] = new JniArgumentValue(viewSpacingRight);
			ptr[4] = new JniArgumentValue(viewSpacingBottom);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setView.(Landroid/view/View;IIII)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}
}
