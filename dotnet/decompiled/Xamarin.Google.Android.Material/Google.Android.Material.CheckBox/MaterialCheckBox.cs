using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.CheckBox;

[Register("com/google/android/material/checkbox/MaterialCheckBox", DoNotGenerateAcw = true)]
public class MaterialCheckBox : AppCompatCheckBox
{
	[Register("com/google/android/material/checkbox/MaterialCheckBox$OnCheckedStateChangedListener", "", "Google.Android.Material.CheckBox.MaterialCheckBox/IOnCheckedStateChangedListenerInvoker")]
	public interface IOnCheckedStateChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCheckedStateChangedListener", "(Lcom/google/android/material/checkbox/MaterialCheckBox;I)V", "GetOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_IHandler:Google.Android.Material.CheckBox.MaterialCheckBox/IOnCheckedStateChangedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnCheckedStateChangedListener(MaterialCheckBox p0, int p1);
	}

	[Register("com/google/android/material/checkbox/MaterialCheckBox$OnCheckedStateChangedListener", DoNotGenerateAcw = true)]
	internal class IOnCheckedStateChangedListenerInvoker : Java.Lang.Object, IOnCheckedStateChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener = new XAPeerMembers("com/google/android/material/checkbox/MaterialCheckBox$OnCheckedStateChangedListener", typeof(IOnCheckedStateChangedListenerInvoker));

		private static Delegate? cb_onCheckedStateChangedListener_OnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_I_V;

		private static nint java_class_ref => _members_com_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener.ManagedPeerType;

		public IOnCheckedStateChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_I(nint jnienv, nint native__this, nint native_p0, int p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnCheckedStateChangedListener? onCheckedStateChangedListener = Java.Lang.Object.GetObject<IOnCheckedStateChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MaterialCheckBox p2 = Java.Lang.Object.GetObject<MaterialCheckBox>(native_p0, JniHandleOwnership.DoNotTransfer);
				onCheckedStateChangedListener.OnCheckedStateChangedListener(p2, p1);
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

		public unsafe void OnCheckedStateChangedListener(MaterialCheckBox p0, int p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members_com_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onCheckedStateChangedListener.(Lcom/google/android/material/checkbox/MaterialCheckBox;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
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
		private static void n_OnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_I_mm_wrapper(nint jnienv, nint native__this, nint native_p0, int p1)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_I(jnienv, native__this, native_p0, p1);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class CheckedStateChangedEventArgs : EventArgs
	{
		private MaterialCheckBox p0;

		private int p1;

		public CheckedStateChangedEventArgs(MaterialCheckBox p0, int p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}

	[Register("mono/com/google/android/material/checkbox/MaterialCheckBox_OnCheckedStateChangedListenerImplementor")]
	internal sealed class IOnCheckedStateChangedListenerImplementor : Java.Lang.Object, IOnCheckedStateChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<CheckedStateChangedEventArgs>? Handler;

		public unsafe IOnCheckedStateChangedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnCheckedStateChangedListener(MaterialCheckBox p0, int p1)
		{
			Handler?.Invoke(sender, new CheckedStateChangedEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IOnCheckedStateChangedListenerImplementor value)
		{
			return value.Handler == null;
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

	[Register("com/google/android/material/checkbox/MaterialCheckBox$OnErrorChangedListener", "", "Google.Android.Material.CheckBox.MaterialCheckBox/IOnErrorChangedListenerInvoker")]
	public interface IOnErrorChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onErrorChanged", "(Lcom/google/android/material/checkbox/MaterialCheckBox;Z)V", "GetOnErrorChanged_Lcom_google_android_material_checkbox_MaterialCheckBox_ZHandler:Google.Android.Material.CheckBox.MaterialCheckBox/IOnErrorChangedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnErrorChanged(MaterialCheckBox p0, bool p1);
	}

	[Register("com/google/android/material/checkbox/MaterialCheckBox$OnErrorChangedListener", DoNotGenerateAcw = true)]
	internal class IOnErrorChangedListenerInvoker : Java.Lang.Object, IOnErrorChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener = new XAPeerMembers("com/google/android/material/checkbox/MaterialCheckBox$OnErrorChangedListener", typeof(IOnErrorChangedListenerInvoker));

		private static Delegate? cb_onErrorChanged_OnErrorChanged_Lcom_google_android_material_checkbox_MaterialCheckBox_Z_V;

		private static nint java_class_ref => _members_com_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener.ManagedPeerType;

		public IOnErrorChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnErrorChanged_Lcom_google_android_material_checkbox_MaterialCheckBox_Z(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnErrorChangedListener? onErrorChangedListener = Java.Lang.Object.GetObject<IOnErrorChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MaterialCheckBox p = Java.Lang.Object.GetObject<MaterialCheckBox>(native_p0, JniHandleOwnership.DoNotTransfer);
				bool p2 = native_p1 != 0;
				onErrorChangedListener.OnErrorChanged(p, p2);
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

		public unsafe void OnErrorChanged(MaterialCheckBox p0, bool p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
				_members_com_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onErrorChanged.(Lcom/google/android/material/checkbox/MaterialCheckBox;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
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
		private static void n_OnErrorChanged_Lcom_google_android_material_checkbox_MaterialCheckBox_Z_mm_wrapper(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnErrorChanged_Lcom_google_android_material_checkbox_MaterialCheckBox_Z(jnienv, native__this, native_p0, native_p1);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ErrorChangedEventArgs : EventArgs
	{
		private MaterialCheckBox p0;

		private bool p1;

		public ErrorChangedEventArgs(MaterialCheckBox p0, bool p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}

	[Register("mono/com/google/android/material/checkbox/MaterialCheckBox_OnErrorChangedListenerImplementor")]
	internal sealed class IOnErrorChangedListenerImplementor : Java.Lang.Object, IOnErrorChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ErrorChangedEventArgs>? Handler;

		public unsafe IOnErrorChangedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnErrorChanged(MaterialCheckBox p0, bool p1)
		{
			Handler?.Invoke(sender, new ErrorChangedEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IOnErrorChangedListenerImplementor value)
		{
			return value.Handler == null;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/checkbox/MaterialCheckBox", typeof(MaterialCheckBox));

	private static Delegate? cb_getButtonIconDrawable_GetButtonIconDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setButtonIconDrawable_SetButtonIconDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getButtonIconTintList_GetButtonIconTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setButtonIconTintList_SetButtonIconTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getButtonIconTintMode_GetButtonIconTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setButtonIconTintMode_SetButtonIconTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_isCenterIfNoTextEnabled_IsCenterIfNoTextEnabled_Z;

	private static Delegate? cb_setCenterIfNoTextEnabled_SetCenterIfNoTextEnabled_Z_V;

	private static Delegate? cb_getCheckedState_GetCheckedState_I;

	private static Delegate? cb_setCheckedState_SetCheckedState_I_V;

	private static Delegate? cb_getErrorAccessibilityLabel_GetErrorAccessibilityLabel_Ljava_lang_CharSequence_;

	private static Delegate? cb_setErrorAccessibilityLabel_SetErrorAccessibilityLabel_Ljava_lang_CharSequence__V;

	private static Delegate? cb_isErrorShown_IsErrorShown_Z;

	private static Delegate? cb_setErrorShown_SetErrorShown_Z_V;

	private static Delegate? cb_isUseMaterialThemeColors_IsUseMaterialThemeColors_Z;

	private static Delegate? cb_setUseMaterialThemeColors_SetUseMaterialThemeColors_Z_V;

	private static Delegate? cb_addOnCheckedStateChangedListener_AddOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener__V;

	private static Delegate? cb_addOnErrorChangedListener_AddOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener__V;

	private static Delegate? cb_clearOnCheckedStateChangedListeners_ClearOnCheckedStateChangedListeners_V;

	private static Delegate? cb_clearOnErrorChangedListeners_ClearOnErrorChangedListeners_V;

	private static Delegate? cb_removeOnCheckedStateChangedListener_RemoveOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener__V;

	private static Delegate? cb_removeOnErrorChangedListener_RemoveOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener__V;

	private static Delegate? cb_setButtonIconDrawableResource_SetButtonIconDrawableResource_I_V;

	private static Delegate? cb_setErrorAccessibilityLabelResource_SetErrorAccessibilityLabelResource_I_V;

	private WeakReference? weak_implementor_AddOnCheckedStateChangedListener;

	private WeakReference? weak_implementor_AddOnErrorChangedListener;

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

	public unsafe virtual Drawable? ButtonIconDrawable
	{
		[Register("getButtonIconDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetButtonIconDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getButtonIconDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setButtonIconDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetButtonIconDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonIconDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? ButtonIconTintList
	{
		[Register("getButtonIconTintList", "()Landroid/content/res/ColorStateList;", "GetGetButtonIconTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getButtonIconTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setButtonIconTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetButtonIconTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonIconTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode ButtonIconTintMode
	{
		[Register("getButtonIconTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetButtonIconTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getButtonIconTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setButtonIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetButtonIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonIconTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool CenterIfNoTextEnabled
	{
		[Register("isCenterIfNoTextEnabled", "()Z", "GetIsCenterIfNoTextEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCenterIfNoTextEnabled.()Z", this, null);
		}
		[Register("setCenterIfNoTextEnabled", "(Z)V", "GetSetCenterIfNoTextEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCenterIfNoTextEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int CheckedState
	{
		[Register("getCheckedState", "()I", "GetGetCheckedStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCheckedState.()I", this, null);
		}
		[Register("setCheckedState", "(I)V", "GetSetCheckedState_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckedState.(I)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? ErrorAccessibilityLabelFormatted
	{
		[Register("getErrorAccessibilityLabel", "()Ljava/lang/CharSequence;", "GetGetErrorAccessibilityLabelHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorAccessibilityLabel.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setErrorAccessibilityLabel", "(Ljava/lang/CharSequence;)V", "GetSetErrorAccessibilityLabel_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorAccessibilityLabel.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? ErrorAccessibilityLabel
	{
		get
		{
			if (ErrorAccessibilityLabelFormatted != null)
			{
				return ErrorAccessibilityLabelFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(ErrorAccessibilityLabelFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual bool ErrorShown
	{
		[Register("isErrorShown", "()Z", "GetIsErrorShownHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isErrorShown.()Z", this, null);
		}
		[Register("setErrorShown", "(Z)V", "GetSetErrorShown_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorShown.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool UseMaterialThemeColors
	{
		[Register("isUseMaterialThemeColors", "()Z", "GetIsUseMaterialThemeColorsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUseMaterialThemeColors.()Z", this, null);
		}
		[Register("setUseMaterialThemeColors", "(Z)V", "GetSetUseMaterialThemeColors_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUseMaterialThemeColors.(Z)V", this, ptr);
		}
	}

	public event EventHandler<CheckedStateChangedEventArgs> CheckedStateChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnCheckedStateChangedListener, IOnCheckedStateChangedListenerImplementor>(ref weak_implementor_AddOnCheckedStateChangedListener, __CreateIOnCheckedStateChangedListenerImplementor, AddOnCheckedStateChangedListener, delegate(IOnCheckedStateChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CheckedStateChangedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnCheckedStateChangedListener, IOnCheckedStateChangedListenerImplementor.__IsEmpty, delegate(IOnCheckedStateChangedListener __v)
			{
				RemoveOnCheckedStateChangedListener(__v);
			}, delegate(IOnCheckedStateChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<CheckedStateChangedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<ErrorChangedEventArgs> ErrorChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnErrorChangedListener, IOnErrorChangedListenerImplementor>(ref weak_implementor_AddOnErrorChangedListener, __CreateIOnErrorChangedListenerImplementor, AddOnErrorChangedListener, delegate(IOnErrorChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ErrorChangedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnErrorChangedListener, IOnErrorChangedListenerImplementor.__IsEmpty, delegate(IOnErrorChangedListener __v)
			{
				RemoveOnErrorChangedListener(__v);
			}, delegate(IOnErrorChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ErrorChangedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected MaterialCheckBox(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe MaterialCheckBox(Context? context)
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
	public unsafe MaterialCheckBox(Context? context, IAttributeSet? attrs)
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
	public unsafe MaterialCheckBox(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetGetButtonIconDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetButtonIconDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetButtonIconDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ButtonIconDrawable);
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

	private static Delegate GetSetButtonIconDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetButtonIconDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetButtonIconDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable buttonIconDrawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			materialCheckBox.ButtonIconDrawable = buttonIconDrawable;
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

	private static Delegate GetGetButtonIconTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetButtonIconTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetButtonIconTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ButtonIconTintList);
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

	private static Delegate GetSetButtonIconTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetButtonIconTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetButtonIconTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tintList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList buttonIconTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tintList, JniHandleOwnership.DoNotTransfer);
			materialCheckBox.ButtonIconTintList = buttonIconTintList;
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

	private static Delegate GetGetButtonIconTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetButtonIconTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetButtonIconTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ButtonIconTintMode);
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

	private static Delegate GetSetButtonIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetButtonIconTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetButtonIconTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode buttonIconTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			materialCheckBox.ButtonIconTintMode = buttonIconTintMode;
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

	private static Delegate GetIsCenterIfNoTextEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCenterIfNoTextEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCenterIfNoTextEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterIfNoTextEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetCenterIfNoTextEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCenterIfNoTextEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCenterIfNoTextEnabled_Z(nint jnienv, nint native__this, sbyte native_centerIfNoTextEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool centerIfNoTextEnabled = native_centerIfNoTextEnabled != 0;
			materialCheckBox.CenterIfNoTextEnabled = centerIfNoTextEnabled;
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

	private static Delegate GetGetCheckedStateHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCheckedState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCheckedState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedState;
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

	private static Delegate GetSetCheckedState_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCheckedState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckedState_I(nint jnienv, nint native__this, int checkedState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CheckedState = checkedState;
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

	private static Delegate GetGetErrorAccessibilityLabelHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetErrorAccessibilityLabel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetErrorAccessibilityLabel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorAccessibilityLabelFormatted);
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

	private static Delegate GetSetErrorAccessibilityLabel_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetErrorAccessibilityLabel_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorAccessibilityLabel_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_errorAccessibilityLabel)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence errorAccessibilityLabelFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_errorAccessibilityLabel, JniHandleOwnership.DoNotTransfer);
			materialCheckBox.ErrorAccessibilityLabelFormatted = errorAccessibilityLabelFormatted;
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

	private static Delegate GetIsErrorShownHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsErrorShown);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsErrorShown(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorShown ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetErrorShown_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetErrorShown_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorShown_Z(nint jnienv, nint native__this, sbyte native_errorShown)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool errorShown = native_errorShown != 0;
			materialCheckBox.ErrorShown = errorShown;
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

	private static Delegate GetIsUseMaterialThemeColorsHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsUseMaterialThemeColors);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsUseMaterialThemeColors(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseMaterialThemeColors ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetUseMaterialThemeColors_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUseMaterialThemeColors_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUseMaterialThemeColors_Z(nint jnienv, nint native__this, sbyte native_useMaterialThemeColors)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool useMaterialThemeColors = native_useMaterialThemeColors != 0;
			materialCheckBox.UseMaterialThemeColors = useMaterialThemeColors;
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

	private static Delegate GetAddOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCheckedStateChangedListener listener = Java.Lang.Object.GetObject<IOnCheckedStateChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			materialCheckBox.AddOnCheckedStateChangedListener(listener);
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

	[Register("addOnCheckedStateChangedListener", "(Lcom/google/android/material/checkbox/MaterialCheckBox$OnCheckedStateChangedListener;)V", "GetAddOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener_Handler")]
	public unsafe virtual void AddOnCheckedStateChangedListener(IOnCheckedStateChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnCheckedStateChangedListener.(Lcom/google/android/material/checkbox/MaterialCheckBox$OnCheckedStateChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnErrorChangedListener listener = Java.Lang.Object.GetObject<IOnErrorChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			materialCheckBox.AddOnErrorChangedListener(listener);
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

	[Register("addOnErrorChangedListener", "(Lcom/google/android/material/checkbox/MaterialCheckBox$OnErrorChangedListener;)V", "GetAddOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener_Handler")]
	public unsafe virtual void AddOnErrorChangedListener(IOnErrorChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnErrorChangedListener.(Lcom/google/android/material/checkbox/MaterialCheckBox$OnErrorChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetClearOnCheckedStateChangedListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnCheckedStateChangedListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnCheckedStateChangedListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnCheckedStateChangedListeners();
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

	[Register("clearOnCheckedStateChangedListeners", "()V", "GetClearOnCheckedStateChangedListenersHandler")]
	public unsafe virtual void ClearOnCheckedStateChangedListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnCheckedStateChangedListeners.()V", this, null);
	}

	private static Delegate GetClearOnErrorChangedListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnErrorChangedListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnErrorChangedListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnErrorChangedListeners();
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

	[Register("clearOnErrorChangedListeners", "()V", "GetClearOnErrorChangedListenersHandler")]
	public unsafe virtual void ClearOnErrorChangedListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnErrorChangedListeners.()V", this, null);
	}

	private static Delegate GetRemoveOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCheckedStateChangedListener listener = Java.Lang.Object.GetObject<IOnCheckedStateChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			materialCheckBox.RemoveOnCheckedStateChangedListener(listener);
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

	[Register("removeOnCheckedStateChangedListener", "(Lcom/google/android/material/checkbox/MaterialCheckBox$OnCheckedStateChangedListener;)V", "GetRemoveOnCheckedStateChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnCheckedStateChangedListener_Handler")]
	public unsafe virtual void RemoveOnCheckedStateChangedListener(IOnCheckedStateChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnCheckedStateChangedListener.(Lcom/google/android/material/checkbox/MaterialCheckBox$OnCheckedStateChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialCheckBox? materialCheckBox = Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnErrorChangedListener listener = Java.Lang.Object.GetObject<IOnErrorChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			materialCheckBox.RemoveOnErrorChangedListener(listener);
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

	[Register("removeOnErrorChangedListener", "(Lcom/google/android/material/checkbox/MaterialCheckBox$OnErrorChangedListener;)V", "GetRemoveOnErrorChangedListener_Lcom_google_android_material_checkbox_MaterialCheckBox_OnErrorChangedListener_Handler")]
	public unsafe virtual void RemoveOnErrorChangedListener(IOnErrorChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnErrorChangedListener.(Lcom/google/android/material/checkbox/MaterialCheckBox$OnErrorChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetButtonIconDrawableResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetButtonIconDrawableResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetButtonIconDrawableResource_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetButtonIconDrawableResource(resId);
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

	[Register("setButtonIconDrawableResource", "(I)V", "GetSetButtonIconDrawableResource_IHandler")]
	public unsafe virtual void SetButtonIconDrawableResource(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonIconDrawableResource.(I)V", this, ptr);
	}

	private static Delegate GetSetErrorAccessibilityLabelResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetErrorAccessibilityLabelResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorAccessibilityLabelResource_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialCheckBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetErrorAccessibilityLabelResource(resId);
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

	[Register("setErrorAccessibilityLabelResource", "(I)V", "GetSetErrorAccessibilityLabelResource_IHandler")]
	public unsafe virtual void SetErrorAccessibilityLabelResource(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorAccessibilityLabelResource.(I)V", this, ptr);
	}

	private IOnCheckedStateChangedListenerImplementor __CreateIOnCheckedStateChangedListenerImplementor()
	{
		return new IOnCheckedStateChangedListenerImplementor(this);
	}

	private IOnErrorChangedListenerImplementor __CreateIOnErrorChangedListenerImplementor()
	{
		return new IOnErrorChangedListenerImplementor(this);
	}
}
