using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.View;

[Register("androidx/appcompat/view/ActionMode", DoNotGenerateAcw = true)]
public abstract class ActionMode : Java.Lang.Object
{
	[Register("androidx/appcompat/view/ActionMode$Callback", "", "AndroidX.AppCompat.View.ActionMode/ICallbackInvoker")]
	public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onActionItemClicked", "(Landroidx/appcompat/view/ActionMode;Landroid/view/MenuItem;)Z", "GetOnActionItemClicked_Landroidx_appcompat_view_ActionMode_Landroid_view_MenuItem_Handler:AndroidX.AppCompat.View.ActionMode/ICallbackInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnActionItemClicked(ActionMode? mode, IMenuItem? item);

		[Register("onCreateActionMode", "(Landroidx/appcompat/view/ActionMode;Landroid/view/Menu;)Z", "GetOnCreateActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu_Handler:AndroidX.AppCompat.View.ActionMode/ICallbackInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnCreateActionMode(ActionMode? mode, IMenu? menu);

		[Register("onDestroyActionMode", "(Landroidx/appcompat/view/ActionMode;)V", "GetOnDestroyActionMode_Landroidx_appcompat_view_ActionMode_Handler:AndroidX.AppCompat.View.ActionMode/ICallbackInvoker, Xamarin.AndroidX.AppCompat")]
		void OnDestroyActionMode(ActionMode? mode);

		[Register("onPrepareActionMode", "(Landroidx/appcompat/view/ActionMode;Landroid/view/Menu;)Z", "GetOnPrepareActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu_Handler:AndroidX.AppCompat.View.ActionMode/ICallbackInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnPrepareActionMode(ActionMode? mode, IMenu? menu);
	}

	[Register("androidx/appcompat/view/ActionMode$Callback", DoNotGenerateAcw = true)]
	internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_view_ActionMode_Callback = new XAPeerMembers("androidx/appcompat/view/ActionMode$Callback", typeof(ICallbackInvoker));

		private static Delegate? cb_onActionItemClicked_OnActionItemClicked_Landroidx_appcompat_view_ActionMode_Landroid_view_MenuItem__Z;

		private static Delegate? cb_onCreateActionMode_OnCreateActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu__Z;

		private static Delegate? cb_onDestroyActionMode_OnDestroyActionMode_Landroidx_appcompat_view_ActionMode__V;

		private static Delegate? cb_onPrepareActionMode_OnPrepareActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu__Z;

		private static nint java_class_ref => _members_androidx_appcompat_view_ActionMode_Callback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_view_ActionMode_Callback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_view_ActionMode_Callback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_view_ActionMode_Callback.ManagedPeerType;

		public ICallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnActionItemClicked_Landroidx_appcompat_view_ActionMode_Landroid_view_MenuItem_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_OnActionItemClicked_Landroidx_appcompat_view_ActionMode_Landroid_view_MenuItem_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnActionItemClicked_Landroidx_appcompat_view_ActionMode_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_mode, nint native_item)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
				return callback.OnActionItemClicked(mode, item) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnActionItemClicked(ActionMode? mode, IMenuItem? item)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
				return _members_androidx_appcompat_view_ActionMode_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onActionItemClicked.(Landroidx/appcompat/view/ActionMode;Landroid/view/MenuItem;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
				GC.KeepAlive(item);
			}
		}

		private static Delegate GetOnCreateActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_OnCreateActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnCreateActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu_(nint jnienv, nint native__this, nint native_mode, nint native_menu)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				return callback.OnCreateActionMode(mode, menu) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnCreateActionMode(ActionMode? mode, IMenu? menu)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
				return _members_androidx_appcompat_view_ActionMode_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onCreateActionMode.(Landroidx/appcompat/view/ActionMode;Landroid/view/Menu;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
				GC.KeepAlive(menu);
			}
		}

		private static Delegate GetOnDestroyActionMode_Landroidx_appcompat_view_ActionMode_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnDestroyActionMode_Landroidx_appcompat_view_ActionMode_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDestroyActionMode_Landroidx_appcompat_view_ActionMode_(nint jnienv, nint native__this, nint native_mode)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				callback.OnDestroyActionMode(mode);
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

		public unsafe void OnDestroyActionMode(ActionMode? mode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				_members_androidx_appcompat_view_ActionMode_Callback.InstanceMethods.InvokeAbstractVoidMethod("onDestroyActionMode.(Landroidx/appcompat/view/ActionMode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
			}
		}

		private static Delegate GetOnPrepareActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_OnPrepareActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnPrepareActionMode_Landroidx_appcompat_view_ActionMode_Landroid_view_Menu_(nint jnienv, nint native__this, nint native_mode, nint native_menu)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
				IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
				return callback.OnPrepareActionMode(mode, menu) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnPrepareActionMode(ActionMode? mode, IMenu? menu)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
				return _members_androidx_appcompat_view_ActionMode_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onPrepareActionMode.(Landroidx/appcompat/view/ActionMode;Landroid/view/Menu;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mode);
				GC.KeepAlive(menu);
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/view/ActionMode", typeof(ActionMode));

	private static Delegate? cb_getCustomView_GetCustomView_Landroid_view_View_;

	private static Delegate? cb_setCustomView_SetCustomView_Landroid_view_View__V;

	private static Delegate? cb_isTitleOptional_IsTitleOptional_Z;

	private static Delegate? cb_isUiFocusable_IsUiFocusable_Z;

	private static Delegate? cb_getMenu_GetMenu_Landroid_view_Menu_;

	private static Delegate? cb_getMenuInflater_GetMenuInflater_Landroid_view_MenuInflater_;

	private static Delegate? cb_getSubtitle_GetSubtitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setSubtitle_SetSubtitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getTag_GetTag_Ljava_lang_Object_;

	private static Delegate? cb_setTag_SetTag_Ljava_lang_Object__V;

	private static Delegate? cb_getTitle_GetTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getTitleOptionalHint_GetTitleOptionalHint_Z;

	private static Delegate? cb_setTitleOptionalHint_SetTitleOptionalHint_Z_V;

	private static Delegate? cb_finish_Finish_V;

	private static Delegate? cb_invalidate_Invalidate_V;

	private static Delegate? cb_setSubtitle_SetSubtitle_I_V;

	private static Delegate? cb_setTitle_SetTitle_I_V;

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

	public abstract Android.Views.View? CustomView
	{
		[Register("getCustomView", "()Landroid/view/View;", "GetGetCustomViewHandler")]
		get;
		[Register("setCustomView", "(Landroid/view/View;)V", "GetSetCustomView_Landroid_view_View_Handler")]
		set;
	}

	public unsafe virtual bool IsTitleOptional
	{
		[Register("isTitleOptional", "()Z", "GetIsTitleOptionalHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTitleOptional.()Z", this, null);
		}
	}

	public unsafe virtual bool IsUiFocusable
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isUiFocusable", "()Z", "GetIsUiFocusableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUiFocusable.()Z", this, null);
		}
	}

	public abstract IMenu? Menu
	{
		[Register("getMenu", "()Landroid/view/Menu;", "GetGetMenuHandler")]
		get;
	}

	public abstract MenuInflater? MenuInflater
	{
		[Register("getMenuInflater", "()Landroid/view/MenuInflater;", "GetGetMenuInflaterHandler")]
		get;
	}

	public abstract ICharSequence? SubtitleFormatted
	{
		[Register("getSubtitle", "()Ljava/lang/CharSequence;", "GetGetSubtitleHandler")]
		get;
		[Register("setSubtitle", "(Ljava/lang/CharSequence;)V", "GetSetSubtitle_Ljava_lang_CharSequence_Handler")]
		set;
	}

	public unsafe string? Subtitle
	{
		get
		{
			if (SubtitleFormatted != null)
			{
				return SubtitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			JniObjectReference reference = JniEnvironment.Strings.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reference);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setSubtitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference);
			}
		}
	}

	public unsafe virtual Java.Lang.Object? Tag
	{
		[Register("getTag", "()Ljava/lang/Object;", "GetGetTagHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTag", "(Ljava/lang/Object;)V", "GetSetTag_Ljava_lang_Object_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTag.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public abstract ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler")]
		get;
		[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
		set;
	}

	public unsafe string? Title
	{
		get
		{
			if (TitleFormatted != null)
			{
				return TitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			JniObjectReference reference = JniEnvironment.Strings.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reference);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference);
			}
		}
	}

	public unsafe virtual bool TitleOptionalHint
	{
		[Register("getTitleOptionalHint", "()Z", "GetGetTitleOptionalHintHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getTitleOptionalHint.()Z", this, null);
		}
		[Register("setTitleOptionalHint", "(Z)V", "GetSetTitleOptionalHint_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleOptionalHint.(Z)V", this, ptr);
		}
	}

	protected ActionMode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ActionMode()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCustomViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCustomView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCustomView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomView);
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

	private static Delegate GetSetCustomView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCustomView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomView_Landroid_view_View_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionMode? actionMode = Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View customView = Java.Lang.Object.GetObject<Android.Views.View>(native_p0, JniHandleOwnership.DoNotTransfer);
			actionMode.CustomView = customView;
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

	private static Delegate GetIsTitleOptionalHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsTitleOptional);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTitleOptional(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTitleOptional ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsUiFocusableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsUiFocusable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsUiFocusable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsUiFocusable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetMenuHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Menu);
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

	private static Delegate GetGetMenuInflaterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMenuInflater);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenuInflater(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MenuInflater);
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

	private static Delegate GetGetSubtitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSubtitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSubtitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubtitleFormatted);
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

	private static Delegate GetSetSubtitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSubtitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionMode? actionMode = Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence subtitleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_p0, JniHandleOwnership.DoNotTransfer);
			actionMode.SubtitleFormatted = subtitleFormatted;
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

	private static Delegate GetGetTagHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTag);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTag(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Tag);
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

	private static Delegate GetSetTag_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTag_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTag_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionMode? actionMode = Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			actionMode.Tag = tag;
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

	private static Delegate GetGetTitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleFormatted);
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

	private static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionMode? actionMode = Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence titleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_p0, JniHandleOwnership.DoNotTransfer);
			actionMode.TitleFormatted = titleFormatted;
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

	private static Delegate GetGetTitleOptionalHintHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetTitleOptionalHint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetTitleOptionalHint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleOptionalHint ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetTitleOptionalHint_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetTitleOptionalHint_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleOptionalHint_Z(nint jnienv, nint native__this, sbyte native_titleOptional)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionMode? actionMode = Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool titleOptionalHint = native_titleOptional != 0;
			actionMode.TitleOptionalHint = titleOptionalHint;
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

	private static Delegate GetFinishHandler()
	{
		return new global::_JniMarshal_PP_V(n_Finish);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Finish(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Finish();
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

	[Register("finish", "()V", "GetFinishHandler")]
	public abstract void Finish();

	private static Delegate GetInvalidateHandler()
	{
		return new global::_JniMarshal_PP_V(n_Invalidate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Invalidate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Invalidate();
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

	[Register("invalidate", "()V", "GetInvalidateHandler")]
	public abstract void Invalidate();

	private static Delegate GetSetSubtitle_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSubtitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitle_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSubtitle(resId);
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

	[Register("setSubtitle", "(I)V", "GetSetSubtitle_IHandler")]
	public abstract void SetSubtitle(int resId);

	private static Delegate GetSetTitle_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitle_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionMode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTitle(resId);
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

	[Register("setTitle", "(I)V", "GetSetTitle_IHandler")]
	public abstract void SetTitle(int resId);
}
