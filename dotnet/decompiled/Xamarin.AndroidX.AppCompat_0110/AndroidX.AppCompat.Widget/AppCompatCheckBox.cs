using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.Widget;

[Register("androidx/appcompat/widget/AppCompatCheckBox", DoNotGenerateAcw = true)]
public class AppCompatCheckBox : CheckBox, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/widget/AppCompatCheckBox", typeof(AppCompatCheckBox));

	private static Delegate? cb_isEmojiCompatEnabled_IsEmojiCompatEnabled_Z;

	private static Delegate? cb_setEmojiCompatEnabled_SetEmojiCompatEnabled_Z_V;

	private static Delegate? cb_getSupportBackgroundTintList_GetSupportBackgroundTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setSupportBackgroundTintList_SetSupportBackgroundTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getSupportBackgroundTintMode_GetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setSupportBackgroundTintMode_SetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_getSupportButtonTintList_GetSupportButtonTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setSupportButtonTintList_SetSupportButtonTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getSupportButtonTintMode_GetSupportButtonTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setSupportButtonTintMode_SetSupportButtonTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_getSupportCompoundDrawablesTintList_GetSupportCompoundDrawablesTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setSupportCompoundDrawablesTintList_SetSupportCompoundDrawablesTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getSupportCompoundDrawablesTintMode_GetSupportCompoundDrawablesTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setSupportCompoundDrawablesTintMode_SetSupportCompoundDrawablesTintMode_Landroid_graphics_PorterDuff_Mode__V;

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

	public unsafe virtual bool EmojiCompatEnabled
	{
		[Register("isEmojiCompatEnabled", "()Z", "GetIsEmojiCompatEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmojiCompatEnabled.()Z", this, null);
		}
		[Register("setEmojiCompatEnabled", "(Z)V", "GetSetEmojiCompatEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEmojiCompatEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? SupportBackgroundTintList
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSupportBackgroundTintList", "()Landroid/content/res/ColorStateList;", "GetGetSupportBackgroundTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportBackgroundTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setSupportBackgroundTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetSupportBackgroundTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportBackgroundTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? SupportBackgroundTintMode
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSupportBackgroundTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetSupportBackgroundTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportBackgroundTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setSupportBackgroundTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportBackgroundTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? SupportButtonTintList
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSupportButtonTintList", "()Landroid/content/res/ColorStateList;", "GetGetSupportButtonTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportButtonTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setSupportButtonTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetSupportButtonTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportButtonTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? SupportButtonTintMode
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSupportButtonTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetSupportButtonTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportButtonTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setSupportButtonTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetSupportButtonTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportButtonTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? SupportCompoundDrawablesTintList
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSupportCompoundDrawablesTintList", "()Landroid/content/res/ColorStateList;", "GetGetSupportCompoundDrawablesTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportCompoundDrawablesTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setSupportCompoundDrawablesTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetSupportCompoundDrawablesTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportCompoundDrawablesTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? SupportCompoundDrawablesTintMode
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSupportCompoundDrawablesTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetSupportCompoundDrawablesTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportCompoundDrawablesTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setSupportCompoundDrawablesTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetSupportCompoundDrawablesTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportCompoundDrawablesTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected AppCompatCheckBox(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe AppCompatCheckBox(Context context)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe AppCompatCheckBox(Context context, IAttributeSet? attrs)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe AppCompatCheckBox(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetIsEmojiCompatEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsEmojiCompatEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEmojiCompatEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EmojiCompatEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetEmojiCompatEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetEmojiCompatEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEmojiCompatEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatCheckBox? appCompatCheckBox = Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool emojiCompatEnabled = native_enabled != 0;
			appCompatCheckBox.EmojiCompatEnabled = emojiCompatEnabled;
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

	private static Delegate GetGetSupportBackgroundTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportBackgroundTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportBackgroundTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportBackgroundTintList);
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

	private static Delegate GetSetSupportBackgroundTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportBackgroundTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportBackgroundTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatCheckBox? appCompatCheckBox = Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList supportBackgroundTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			appCompatCheckBox.SupportBackgroundTintList = supportBackgroundTintList;
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

	private static Delegate GetGetSupportBackgroundTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportBackgroundTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportBackgroundTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportBackgroundTintMode);
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

	private static Delegate GetSetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatCheckBox? appCompatCheckBox = Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode supportBackgroundTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			appCompatCheckBox.SupportBackgroundTintMode = supportBackgroundTintMode;
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

	private static Delegate GetGetSupportButtonTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportButtonTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportButtonTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportButtonTintList);
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

	private static Delegate GetSetSupportButtonTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportButtonTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportButtonTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatCheckBox? appCompatCheckBox = Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList supportButtonTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			appCompatCheckBox.SupportButtonTintList = supportButtonTintList;
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

	private static Delegate GetGetSupportButtonTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportButtonTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportButtonTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportButtonTintMode);
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

	private static Delegate GetSetSupportButtonTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportButtonTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportButtonTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatCheckBox? appCompatCheckBox = Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode supportButtonTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			appCompatCheckBox.SupportButtonTintMode = supportButtonTintMode;
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

	private static Delegate GetGetSupportCompoundDrawablesTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportCompoundDrawablesTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportCompoundDrawablesTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportCompoundDrawablesTintList);
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

	private static Delegate GetSetSupportCompoundDrawablesTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportCompoundDrawablesTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportCompoundDrawablesTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tintList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatCheckBox? appCompatCheckBox = Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList supportCompoundDrawablesTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tintList, JniHandleOwnership.DoNotTransfer);
			appCompatCheckBox.SupportCompoundDrawablesTintList = supportCompoundDrawablesTintList;
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

	private static Delegate GetGetSupportCompoundDrawablesTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportCompoundDrawablesTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportCompoundDrawablesTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportCompoundDrawablesTintMode);
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

	private static Delegate GetSetSupportCompoundDrawablesTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportCompoundDrawablesTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportCompoundDrawablesTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatCheckBox? appCompatCheckBox = Java.Lang.Object.GetObject<AppCompatCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode supportCompoundDrawablesTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			appCompatCheckBox.SupportCompoundDrawablesTintMode = supportCompoundDrawablesTintMode;
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
}
