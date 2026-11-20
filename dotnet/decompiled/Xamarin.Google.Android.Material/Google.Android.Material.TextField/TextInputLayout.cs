using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.View;
using Google.Android.Material.Shape;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.TextField;

[Register("com/google/android/material/textfield/TextInputLayout", DoNotGenerateAcw = true)]
public class TextInputLayout : LinearLayout, ViewTreeObserver.IOnGlobalLayoutListener, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/google/android/material/textfield/TextInputLayout$AccessibilityDelegate", DoNotGenerateAcw = true)]
	public new class AccessibilityDelegate : AccessibilityDelegateCompat
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/textfield/TextInputLayout$AccessibilityDelegate", typeof(AccessibilityDelegate));

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

		protected AccessibilityDelegate(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/material/textfield/TextInputLayout;)V", "")]
		public unsafe AccessibilityDelegate(TextInputLayout layout)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/material/textfield/TextInputLayout;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/material/textfield/TextInputLayout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layout);
			}
		}
	}

	[Register("com/google/android/material/textfield/TextInputLayout$LengthCounter", "", "Google.Android.Material.TextField.TextInputLayout/ILengthCounterInvoker")]
	public interface ILengthCounter : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("countLength", "(Landroid/text/Editable;)I", "GetCountLength_Landroid_text_Editable_Handler:Google.Android.Material.TextField.TextInputLayout/ILengthCounterInvoker, Xamarin.Google.Android.Material")]
		int CountLength(IEditable? p0);
	}

	[Register("com/google/android/material/textfield/TextInputLayout$LengthCounter", DoNotGenerateAcw = true)]
	internal class ILengthCounterInvoker : Java.Lang.Object, ILengthCounter, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_textfield_TextInputLayout_LengthCounter = new XAPeerMembers("com/google/android/material/textfield/TextInputLayout$LengthCounter", typeof(ILengthCounterInvoker));

		private static Delegate? cb_countLength_CountLength_Landroid_text_Editable__I;

		private static nint java_class_ref => _members_com_google_android_material_textfield_TextInputLayout_LengthCounter.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_textfield_TextInputLayout_LengthCounter;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_textfield_TextInputLayout_LengthCounter.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_textfield_TextInputLayout_LengthCounter.ManagedPeerType;

		public ILengthCounterInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetCountLength_Landroid_text_Editable_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_CountLength_Landroid_text_Editable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_CountLength_Landroid_text_Editable_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ILengthCounter? lengthCounter = Java.Lang.Object.GetObject<ILengthCounter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IEditable p = Java.Lang.Object.GetObject<IEditable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return lengthCounter.CountLength(p);
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

		public unsafe int CountLength(IEditable? p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return _members_com_google_android_material_textfield_TextInputLayout_LengthCounter.InstanceMethods.InvokeAbstractInt32Method("countLength.(Landroid/text/Editable;)I", this, ptr);
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
	}

	[Register("com/google/android/material/textfield/TextInputLayout$OnEditTextAttachedListener", "", "Google.Android.Material.TextField.TextInputLayout/IOnEditTextAttachedListenerInvoker")]
	public interface IOnEditTextAttachedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onEditTextAttached", "(Lcom/google/android/material/textfield/TextInputLayout;)V", "GetOnEditTextAttached_Lcom_google_android_material_textfield_TextInputLayout_Handler:Google.Android.Material.TextField.TextInputLayout/IOnEditTextAttachedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnEditTextAttached(TextInputLayout p0);
	}

	[Register("com/google/android/material/textfield/TextInputLayout$OnEditTextAttachedListener", DoNotGenerateAcw = true)]
	internal class IOnEditTextAttachedListenerInvoker : Java.Lang.Object, IOnEditTextAttachedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener = new XAPeerMembers("com/google/android/material/textfield/TextInputLayout$OnEditTextAttachedListener", typeof(IOnEditTextAttachedListenerInvoker));

		private static Delegate? cb_onEditTextAttached_OnEditTextAttached_Lcom_google_android_material_textfield_TextInputLayout__V;

		private static nint java_class_ref => _members_com_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener.ManagedPeerType;

		public IOnEditTextAttachedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnEditTextAttached_Lcom_google_android_material_textfield_TextInputLayout_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnEditTextAttachedListener? onEditTextAttachedListener = Java.Lang.Object.GetObject<IOnEditTextAttachedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				TextInputLayout p = Java.Lang.Object.GetObject<TextInputLayout>(native_p0, JniHandleOwnership.DoNotTransfer);
				onEditTextAttachedListener.OnEditTextAttached(p);
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

		public unsafe void OnEditTextAttached(TextInputLayout p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members_com_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener.InstanceMethods.InvokeAbstractVoidMethod("onEditTextAttached.(Lcom/google/android/material/textfield/TextInputLayout;)V", this, ptr);
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
		private static void n_OnEditTextAttached_Lcom_google_android_material_textfield_TextInputLayout__mm_wrapper(nint jnienv, nint native__this, nint native_p0)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnEditTextAttached_Lcom_google_android_material_textfield_TextInputLayout_(jnienv, native__this, native_p0);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class EditTextAttachedEventArgs : EventArgs
	{
		private TextInputLayout p0;

		public EditTextAttachedEventArgs(TextInputLayout p0)
		{
			this.p0 = p0;
		}
	}

	[Register("mono/com/google/android/material/textfield/TextInputLayout_OnEditTextAttachedListenerImplementor")]
	internal sealed class IOnEditTextAttachedListenerImplementor : Java.Lang.Object, IOnEditTextAttachedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<EditTextAttachedEventArgs>? Handler;

		public unsafe IOnEditTextAttachedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnEditTextAttached(TextInputLayout p0)
		{
			Handler?.Invoke(sender, new EditTextAttachedEventArgs(p0));
		}

		internal static bool __IsEmpty(IOnEditTextAttachedListenerImplementor value)
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

	[Register("com/google/android/material/textfield/TextInputLayout$OnEndIconChangedListener", "", "Google.Android.Material.TextField.TextInputLayout/IOnEndIconChangedListenerInvoker")]
	public interface IOnEndIconChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onEndIconChanged", "(Lcom/google/android/material/textfield/TextInputLayout;I)V", "GetOnEndIconChanged_Lcom_google_android_material_textfield_TextInputLayout_IHandler:Google.Android.Material.TextField.TextInputLayout/IOnEndIconChangedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnEndIconChanged(TextInputLayout p0, int p1);
	}

	[Register("com/google/android/material/textfield/TextInputLayout$OnEndIconChangedListener", DoNotGenerateAcw = true)]
	internal class IOnEndIconChangedListenerInvoker : Java.Lang.Object, IOnEndIconChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener = new XAPeerMembers("com/google/android/material/textfield/TextInputLayout$OnEndIconChangedListener", typeof(IOnEndIconChangedListenerInvoker));

		private static Delegate? cb_onEndIconChanged_OnEndIconChanged_Lcom_google_android_material_textfield_TextInputLayout_I_V;

		private static nint java_class_ref => _members_com_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener.ManagedPeerType;

		public IOnEndIconChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnEndIconChanged_Lcom_google_android_material_textfield_TextInputLayout_I(nint jnienv, nint native__this, nint native_p0, int p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnEndIconChangedListener? onEndIconChangedListener = Java.Lang.Object.GetObject<IOnEndIconChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				TextInputLayout p2 = Java.Lang.Object.GetObject<TextInputLayout>(native_p0, JniHandleOwnership.DoNotTransfer);
				onEndIconChangedListener.OnEndIconChanged(p2, p1);
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

		public unsafe void OnEndIconChanged(TextInputLayout p0, int p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members_com_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onEndIconChanged.(Lcom/google/android/material/textfield/TextInputLayout;I)V", this, ptr);
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
		private static void n_OnEndIconChanged_Lcom_google_android_material_textfield_TextInputLayout_I_mm_wrapper(nint jnienv, nint native__this, nint native_p0, int p1)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnEndIconChanged_Lcom_google_android_material_textfield_TextInputLayout_I(jnienv, native__this, native_p0, p1);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class EndIconChangedEventArgs : EventArgs
	{
		private TextInputLayout p0;

		private int p1;

		public EndIconChangedEventArgs(TextInputLayout p0, int p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}

	[Register("mono/com/google/android/material/textfield/TextInputLayout_OnEndIconChangedListenerImplementor")]
	internal sealed class IOnEndIconChangedListenerImplementor : Java.Lang.Object, IOnEndIconChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<EndIconChangedEventArgs>? Handler;

		public unsafe IOnEndIconChangedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnEndIconChanged(TextInputLayout p0, int p1)
		{
			Handler?.Invoke(sender, new EndIconChangedEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(IOnEndIconChangedListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/textfield/TextInputLayout", typeof(TextInputLayout));

	private static Delegate? cb_getBoxBackgroundColor_GetBoxBackgroundColor_I;

	private static Delegate? cb_setBoxBackgroundColor_SetBoxBackgroundColor_I_V;

	private static Delegate? cb_getBoxBackgroundMode_GetBoxBackgroundMode_I;

	private static Delegate? cb_setBoxBackgroundMode_SetBoxBackgroundMode_I_V;

	private static Delegate? cb_getBoxCollapsedPaddingTop_GetBoxCollapsedPaddingTop_I;

	private static Delegate? cb_setBoxCollapsedPaddingTop_SetBoxCollapsedPaddingTop_I_V;

	private static Delegate? cb_getBoxCornerRadiusBottomEnd_GetBoxCornerRadiusBottomEnd_F;

	private static Delegate? cb_getBoxCornerRadiusBottomStart_GetBoxCornerRadiusBottomStart_F;

	private static Delegate? cb_getBoxCornerRadiusTopEnd_GetBoxCornerRadiusTopEnd_F;

	private static Delegate? cb_getBoxCornerRadiusTopStart_GetBoxCornerRadiusTopStart_F;

	private static Delegate? cb_getBoxStrokeColor_GetBoxStrokeColor_I;

	private static Delegate? cb_setBoxStrokeColor_SetBoxStrokeColor_I_V;

	private static Delegate? cb_getBoxStrokeErrorColor_GetBoxStrokeErrorColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setBoxStrokeErrorColor_SetBoxStrokeErrorColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getBoxStrokeWidth_GetBoxStrokeWidth_I;

	private static Delegate? cb_setBoxStrokeWidth_SetBoxStrokeWidth_I_V;

	private static Delegate? cb_getBoxStrokeWidthFocused_GetBoxStrokeWidthFocused_I;

	private static Delegate? cb_setBoxStrokeWidthFocused_SetBoxStrokeWidthFocused_I_V;

	private static Delegate? cb_isCounterEnabled_IsCounterEnabled_Z;

	private static Delegate? cb_setCounterEnabled_SetCounterEnabled_Z_V;

	private static Delegate? cb_getCounterMaxLength_GetCounterMaxLength_I;

	private static Delegate? cb_setCounterMaxLength_SetCounterMaxLength_I_V;

	private static Delegate? cb_getCounterOverflowTextColor_GetCounterOverflowTextColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setCounterOverflowTextColor_SetCounterOverflowTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getCounterTextColor_GetCounterTextColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setCounterTextColor_SetCounterTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getCursorColor_GetCursorColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setCursorColor_SetCursorColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getCursorErrorColor_GetCursorErrorColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setCursorErrorColor_SetCursorErrorColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getDefaultHintTextColor_GetDefaultHintTextColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setDefaultHintTextColor_SetDefaultHintTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getEditText_GetEditText_Landroid_widget_EditText_;

	private static Delegate? cb_isEndIconCheckable_IsEndIconCheckable_Z;

	private static Delegate? cb_setEndIconCheckable_SetEndIconCheckable_Z_V;

	private static Delegate? cb_getEndIconContentDescription_GetEndIconContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setEndIconContentDescription_SetEndIconContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getEndIconDrawable_GetEndIconDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setEndIconDrawable_SetEndIconDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getEndIconMinSize_GetEndIconMinSize_I;

	private static Delegate? cb_setEndIconMinSize_SetEndIconMinSize_I_V;

	private static Delegate? cb_getEndIconMode_GetEndIconMode_I;

	private static Delegate? cb_setEndIconMode_SetEndIconMode_I_V;

	private static Delegate? cb_getEndIconScaleType_GetEndIconScaleType_Landroid_widget_ImageView_ScaleType_;

	private static Delegate? cb_setEndIconScaleType_SetEndIconScaleType_Landroid_widget_ImageView_ScaleType__V;

	private static Delegate? cb_isEndIconVisible_IsEndIconVisible_Z;

	private static Delegate? cb_setEndIconVisible_SetEndIconVisible_Z_V;

	private static Delegate? cb_getError_GetError_Ljava_lang_CharSequence_;

	private static Delegate? cb_setError_SetError_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getErrorAccessibilityLiveRegion_GetErrorAccessibilityLiveRegion_I;

	private static Delegate? cb_setErrorAccessibilityLiveRegion_SetErrorAccessibilityLiveRegion_I_V;

	private static Delegate? cb_getErrorContentDescription_GetErrorContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setErrorContentDescription_SetErrorContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getErrorCurrentTextColors_GetErrorCurrentTextColors_I;

	private static Delegate? cb_isErrorEnabled_IsErrorEnabled_Z;

	private static Delegate? cb_setErrorEnabled_SetErrorEnabled_Z_V;

	private static Delegate? cb_getErrorIconDrawable_GetErrorIconDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setErrorIconDrawable_SetErrorIconDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_isExpandedHintEnabled_IsExpandedHintEnabled_Z;

	private static Delegate? cb_setExpandedHintEnabled_SetExpandedHintEnabled_Z_V;

	private static Delegate? cb_getHelperText_GetHelperText_Ljava_lang_CharSequence_;

	private static Delegate? cb_setHelperText_SetHelperText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getHelperTextCurrentTextColor_GetHelperTextCurrentTextColor_I;

	private static Delegate? cb_isHelperTextEnabled_IsHelperTextEnabled_Z;

	private static Delegate? cb_setHelperTextEnabled_SetHelperTextEnabled_Z_V;

	private static Delegate? cb_getHint_GetHint_Ljava_lang_CharSequence_;

	private static Delegate? cb_setHint_SetHint_Ljava_lang_CharSequence__V;

	private static Delegate? cb_isHintAnimationEnabled_IsHintAnimationEnabled_Z;

	private static Delegate? cb_setHintAnimationEnabled_SetHintAnimationEnabled_Z_V;

	private static Delegate? cb_isHintEnabled_IsHintEnabled_Z;

	private static Delegate? cb_setHintEnabled_SetHintEnabled_Z_V;

	private static Delegate? cb_getHintTextColor_GetHintTextColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setHintTextColor_SetHintTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_isProvidingHint_IsProvidingHint_Z;

	private static Delegate? cb_getLengthCounter_GetLengthCounter_Lcom_google_android_material_textfield_TextInputLayout_LengthCounter_;

	private static Delegate? cb_setLengthCounter_SetLengthCounter_Lcom_google_android_material_textfield_TextInputLayout_LengthCounter__V;

	private static Delegate? cb_getMaxEms_GetMaxEms_I;

	private static Delegate? cb_setMaxEms_SetMaxEms_I_V;

	private static Delegate? cb_getMaxWidth_GetMaxWidth_I;

	private static Delegate? cb_setMaxWidth_SetMaxWidth_I_V;

	private static Delegate? cb_getMinEms_GetMinEms_I;

	private static Delegate? cb_setMinEms_SetMinEms_I_V;

	private static Delegate? cb_getMinWidth_GetMinWidth_I;

	private static Delegate? cb_setMinWidth_SetMinWidth_I_V;

	private static Delegate? cb_getPasswordVisibilityToggleContentDescription_GetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setPasswordVisibilityToggleContentDescription_SetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getPasswordVisibilityToggleDrawable_GetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setPasswordVisibilityToggleDrawable_SetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_isPasswordVisibilityToggleEnabled_IsPasswordVisibilityToggleEnabled_Z;

	private static Delegate? cb_setPasswordVisibilityToggleEnabled_SetPasswordVisibilityToggleEnabled_Z_V;

	private static Delegate? cb_getPlaceholderText_GetPlaceholderText_Ljava_lang_CharSequence_;

	private static Delegate? cb_setPlaceholderText_SetPlaceholderText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getPlaceholderTextAppearance_GetPlaceholderTextAppearance_I;

	private static Delegate? cb_setPlaceholderTextAppearance_SetPlaceholderTextAppearance_I_V;

	private static Delegate? cb_getPlaceholderTextColor_GetPlaceholderTextColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setPlaceholderTextColor_SetPlaceholderTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getPrefixText_GetPrefixText_Ljava_lang_CharSequence_;

	private static Delegate? cb_setPrefixText_SetPrefixText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getPrefixTextColor_GetPrefixTextColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setPrefixTextColor_SetPrefixTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getPrefixTextView_GetPrefixTextView_Landroid_widget_TextView_;

	private static Delegate? cb_getShapeAppearanceModel_GetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_setShapeAppearanceModel_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel__V;

	private static Delegate? cb_isStartIconCheckable_IsStartIconCheckable_Z;

	private static Delegate? cb_setStartIconCheckable_SetStartIconCheckable_Z_V;

	private static Delegate? cb_getStartIconContentDescription_GetStartIconContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setStartIconContentDescription_SetStartIconContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getStartIconDrawable_GetStartIconDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setStartIconDrawable_SetStartIconDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getStartIconMinSize_GetStartIconMinSize_I;

	private static Delegate? cb_setStartIconMinSize_SetStartIconMinSize_I_V;

	private static Delegate? cb_getStartIconScaleType_GetStartIconScaleType_Landroid_widget_ImageView_ScaleType_;

	private static Delegate? cb_setStartIconScaleType_SetStartIconScaleType_Landroid_widget_ImageView_ScaleType__V;

	private static Delegate? cb_isStartIconVisible_IsStartIconVisible_Z;

	private static Delegate? cb_setStartIconVisible_SetStartIconVisible_Z_V;

	private static Delegate? cb_getSuffixText_GetSuffixText_Ljava_lang_CharSequence_;

	private static Delegate? cb_setSuffixText_SetSuffixText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getSuffixTextColor_GetSuffixTextColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setSuffixTextColor_SetSuffixTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getSuffixTextView_GetSuffixTextView_Landroid_widget_TextView_;

	private static Delegate? cb_getTypeface_GetTypeface_Landroid_graphics_Typeface_;

	private static Delegate? cb_setTypeface_SetTypeface_Landroid_graphics_Typeface__V;

	private static Delegate? cb_addOnEditTextAttachedListener_AddOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener__V;

	private static Delegate? cb_addOnEndIconChangedListener_AddOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener__V;

	private static Delegate? cb_clearOnEditTextAttachedListeners_ClearOnEditTextAttachedListeners_V;

	private static Delegate? cb_clearOnEndIconChangedListeners_ClearOnEndIconChangedListeners_V;

	private static Delegate? cb_dispatchRestoreInstanceState_DispatchRestoreInstanceState_Landroid_util_SparseArray__V;

	private static Delegate? cb_onGlobalLayout_OnGlobalLayout_V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

	private static Delegate? cb_passwordVisibilityToggleRequested_PasswordVisibilityToggleRequested_Z_V;

	private static Delegate? cb_refreshEndIconDrawableState_RefreshEndIconDrawableState_V;

	private static Delegate? cb_refreshErrorIconDrawableState_RefreshErrorIconDrawableState_V;

	private static Delegate? cb_refreshStartIconDrawableState_RefreshStartIconDrawableState_V;

	private static Delegate? cb_removeOnEditTextAttachedListener_RemoveOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener__V;

	private static Delegate? cb_removeOnEndIconChangedListener_RemoveOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener__V;

	private static Delegate? cb_setBoxBackgroundColorResource_SetBoxBackgroundColorResource_I_V;

	private static Delegate? cb_setBoxBackgroundColorStateList_SetBoxBackgroundColorStateList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setBoxCornerFamily_SetBoxCornerFamily_I_V;

	private static Delegate? cb_setBoxCornerRadii_SetBoxCornerRadii_FFFF_V;

	private static Delegate? cb_setBoxCornerRadiiResources_SetBoxCornerRadiiResources_IIII_V;

	private static Delegate? cb_setBoxStrokeColorStateList_SetBoxStrokeColorStateList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setBoxStrokeWidthFocusedResource_SetBoxStrokeWidthFocusedResource_I_V;

	private static Delegate? cb_setBoxStrokeWidthResource_SetBoxStrokeWidthResource_I_V;

	private static Delegate? cb_setCounterOverflowTextAppearance_SetCounterOverflowTextAppearance_I_V;

	private static Delegate? cb_setCounterTextAppearance_SetCounterTextAppearance_I_V;

	private static Delegate? cb_setEndIconActivated_SetEndIconActivated_Z_V;

	private static Delegate? cb_setEndIconContentDescription_SetEndIconContentDescription_I_V;

	private static Delegate? cb_setEndIconDrawable_SetEndIconDrawable_I_V;

	private static Delegate? cb_setEndIconOnClickListener_SetEndIconOnClickListener_Landroid_view_View_OnClickListener__V;

	private static Delegate? cb_setEndIconOnLongClickListener_SetEndIconOnLongClickListener_Landroid_view_View_OnLongClickListener__V;

	private static Delegate? cb_setEndIconTintList_SetEndIconTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setEndIconTintMode_SetEndIconTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_setErrorIconDrawable_SetErrorIconDrawable_I_V;

	private static Delegate? cb_setErrorIconOnClickListener_SetErrorIconOnClickListener_Landroid_view_View_OnClickListener__V;

	private static Delegate? cb_setErrorIconOnLongClickListener_SetErrorIconOnLongClickListener_Landroid_view_View_OnLongClickListener__V;

	private static Delegate? cb_setErrorIconTintList_SetErrorIconTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setErrorIconTintMode_SetErrorIconTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_setErrorTextAppearance_SetErrorTextAppearance_I_V;

	private static Delegate? cb_setErrorTextColor_SetErrorTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setHelperTextColor_SetHelperTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setHelperTextTextAppearance_SetHelperTextTextAppearance_I_V;

	private static Delegate? cb_setHint_SetHint_I_V;

	private static Delegate? cb_setHintTextAppearance_SetHintTextAppearance_I_V;

	private static Delegate? cb_setMaxWidthResource_SetMaxWidthResource_I_V;

	private static Delegate? cb_setMinWidthResource_SetMinWidthResource_I_V;

	private static Delegate? cb_setPasswordVisibilityToggleContentDescription_SetPasswordVisibilityToggleContentDescription_I_V;

	private static Delegate? cb_setPasswordVisibilityToggleDrawable_SetPasswordVisibilityToggleDrawable_I_V;

	private static Delegate? cb_setPasswordVisibilityToggleTintList_SetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setPasswordVisibilityToggleTintMode_SetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_setPrefixTextAppearance_SetPrefixTextAppearance_I_V;

	private static Delegate? cb_setStartIconContentDescription_SetStartIconContentDescription_I_V;

	private static Delegate? cb_setStartIconDrawable_SetStartIconDrawable_I_V;

	private static Delegate? cb_setStartIconOnClickListener_SetStartIconOnClickListener_Landroid_view_View_OnClickListener__V;

	private static Delegate? cb_setStartIconOnLongClickListener_SetStartIconOnLongClickListener_Landroid_view_View_OnLongClickListener__V;

	private static Delegate? cb_setStartIconTintList_SetStartIconTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setStartIconTintMode_SetStartIconTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_setSuffixTextAppearance_SetSuffixTextAppearance_I_V;

	private static Delegate? cb_setTextInputAccessibilityDelegate_SetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate__V;

	private WeakReference? weak_implementor_AddOnEditTextAttachedListener;

	private WeakReference? weak_implementor_AddOnEndIconChangedListener;

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			base.Enabled = value;
		}
	}

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

	public unsafe virtual int BoxBackgroundColor
	{
		[Register("getBoxBackgroundColor", "()I", "GetGetBoxBackgroundColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBoxBackgroundColor.()I", this, null);
		}
		[Register("setBoxBackgroundColor", "(I)V", "GetSetBoxBackgroundColor_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxBackgroundColor.(I)V", this, ptr);
		}
	}

	public unsafe virtual int BoxBackgroundMode
	{
		[Register("getBoxBackgroundMode", "()I", "GetGetBoxBackgroundModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBoxBackgroundMode.()I", this, null);
		}
		[Register("setBoxBackgroundMode", "(I)V", "GetSetBoxBackgroundMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxBackgroundMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual int BoxCollapsedPaddingTop
	{
		[Register("getBoxCollapsedPaddingTop", "()I", "GetGetBoxCollapsedPaddingTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBoxCollapsedPaddingTop.()I", this, null);
		}
		[Register("setBoxCollapsedPaddingTop", "(I)V", "GetSetBoxCollapsedPaddingTop_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxCollapsedPaddingTop.(I)V", this, ptr);
		}
	}

	public unsafe virtual float BoxCornerRadiusBottomEnd
	{
		[Register("getBoxCornerRadiusBottomEnd", "()F", "GetGetBoxCornerRadiusBottomEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBoxCornerRadiusBottomEnd.()F", this, null);
		}
	}

	public unsafe virtual float BoxCornerRadiusBottomStart
	{
		[Register("getBoxCornerRadiusBottomStart", "()F", "GetGetBoxCornerRadiusBottomStartHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBoxCornerRadiusBottomStart.()F", this, null);
		}
	}

	public unsafe virtual float BoxCornerRadiusTopEnd
	{
		[Register("getBoxCornerRadiusTopEnd", "()F", "GetGetBoxCornerRadiusTopEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBoxCornerRadiusTopEnd.()F", this, null);
		}
	}

	public unsafe virtual float BoxCornerRadiusTopStart
	{
		[Register("getBoxCornerRadiusTopStart", "()F", "GetGetBoxCornerRadiusTopStartHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBoxCornerRadiusTopStart.()F", this, null);
		}
	}

	public unsafe virtual int BoxStrokeColor
	{
		[Register("getBoxStrokeColor", "()I", "GetGetBoxStrokeColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBoxStrokeColor.()I", this, null);
		}
		[Register("setBoxStrokeColor", "(I)V", "GetSetBoxStrokeColor_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxStrokeColor.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? BoxStrokeErrorColor
	{
		[Register("getBoxStrokeErrorColor", "()Landroid/content/res/ColorStateList;", "GetGetBoxStrokeErrorColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBoxStrokeErrorColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setBoxStrokeErrorColor", "(Landroid/content/res/ColorStateList;)V", "GetSetBoxStrokeErrorColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxStrokeErrorColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int BoxStrokeWidth
	{
		[Register("getBoxStrokeWidth", "()I", "GetGetBoxStrokeWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBoxStrokeWidth.()I", this, null);
		}
		[Register("setBoxStrokeWidth", "(I)V", "GetSetBoxStrokeWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxStrokeWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int BoxStrokeWidthFocused
	{
		[Register("getBoxStrokeWidthFocused", "()I", "GetGetBoxStrokeWidthFocusedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBoxStrokeWidthFocused.()I", this, null);
		}
		[Register("setBoxStrokeWidthFocused", "(I)V", "GetSetBoxStrokeWidthFocused_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxStrokeWidthFocused.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool CounterEnabled
	{
		[Register("isCounterEnabled", "()Z", "GetIsCounterEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCounterEnabled.()Z", this, null);
		}
		[Register("setCounterEnabled", "(Z)V", "GetSetCounterEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCounterEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int CounterMaxLength
	{
		[Register("getCounterMaxLength", "()I", "GetGetCounterMaxLengthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCounterMaxLength.()I", this, null);
		}
		[Register("setCounterMaxLength", "(I)V", "GetSetCounterMaxLength_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCounterMaxLength.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? CounterOverflowTextColor
	{
		[Register("getCounterOverflowTextColor", "()Landroid/content/res/ColorStateList;", "GetGetCounterOverflowTextColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCounterOverflowTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCounterOverflowTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetCounterOverflowTextColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCounterOverflowTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? CounterTextColor
	{
		[Register("getCounterTextColor", "()Landroid/content/res/ColorStateList;", "GetGetCounterTextColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCounterTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCounterTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetCounterTextColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCounterTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? CursorColor
	{
		[Register("getCursorColor", "()Landroid/content/res/ColorStateList;", "GetGetCursorColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCursorColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCursorColor", "(Landroid/content/res/ColorStateList;)V", "GetSetCursorColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCursorColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? CursorErrorColor
	{
		[Register("getCursorErrorColor", "()Landroid/content/res/ColorStateList;", "GetGetCursorErrorColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCursorErrorColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCursorErrorColor", "(Landroid/content/res/ColorStateList;)V", "GetSetCursorErrorColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCursorErrorColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? DefaultHintTextColor
	{
		[Register("getDefaultHintTextColor", "()Landroid/content/res/ColorStateList;", "GetGetDefaultHintTextColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultHintTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setDefaultHintTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetDefaultHintTextColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDefaultHintTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual EditText? EditText
	{
		[Register("getEditText", "()Landroid/widget/EditText;", "GetGetEditTextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<EditText>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEditText.()Landroid/widget/EditText;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool EndIconCheckable
	{
		[Register("isEndIconCheckable", "()Z", "GetIsEndIconCheckableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEndIconCheckable.()Z", this, null);
		}
		[Register("setEndIconCheckable", "(Z)V", "GetSetEndIconCheckable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconCheckable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? EndIconContentDescriptionFormatted
	{
		[Register("getEndIconContentDescription", "()Ljava/lang/CharSequence;", "GetGetEndIconContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEndIconContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setEndIconContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetEndIconContentDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? EndIconContentDescription
	{
		get
		{
			if (EndIconContentDescriptionFormatted != null)
			{
				return EndIconContentDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(EndIconContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual Drawable? EndIconDrawable
	{
		[Register("getEndIconDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetEndIconDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEndIconDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setEndIconDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetEndIconDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int EndIconMinSize
	{
		[Register("getEndIconMinSize", "()I", "GetGetEndIconMinSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getEndIconMinSize.()I", this, null);
		}
		[Register("setEndIconMinSize", "(I)V", "GetSetEndIconMinSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconMinSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual int EndIconMode
	{
		[Register("getEndIconMode", "()I", "GetGetEndIconModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getEndIconMode.()I", this, null);
		}
		[Register("setEndIconMode", "(I)V", "GetSetEndIconMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual ImageView.ScaleType EndIconScaleType
	{
		[Register("getEndIconScaleType", "()Landroid/widget/ImageView$ScaleType;", "GetGetEndIconScaleTypeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ImageView.ScaleType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEndIconScaleType.()Landroid/widget/ImageView$ScaleType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setEndIconScaleType", "(Landroid/widget/ImageView$ScaleType;)V", "GetSetEndIconScaleType_Landroid_widget_ImageView_ScaleType_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconScaleType.(Landroid/widget/ImageView$ScaleType;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool EndIconVisible
	{
		[Register("isEndIconVisible", "()Z", "GetIsEndIconVisibleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEndIconVisible.()Z", this, null);
		}
		[Register("setEndIconVisible", "(Z)V", "GetSetEndIconVisible_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconVisible.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? ErrorFormatted
	{
		[Register("getError", "()Ljava/lang/CharSequence;", "GetGetErrorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getError.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setError", "(Ljava/lang/CharSequence;)V", "GetSetError_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setError.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? Error
	{
		get
		{
			if (ErrorFormatted != null)
			{
				return ErrorFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(ErrorFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual int ErrorAccessibilityLiveRegion
	{
		[Register("getErrorAccessibilityLiveRegion", "()I", "GetGetErrorAccessibilityLiveRegionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getErrorAccessibilityLiveRegion.()I", this, null);
		}
		[Register("setErrorAccessibilityLiveRegion", "(I)V", "GetSetErrorAccessibilityLiveRegion_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorAccessibilityLiveRegion.(I)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? ErrorContentDescriptionFormatted
	{
		[Register("getErrorContentDescription", "()Ljava/lang/CharSequence;", "GetGetErrorContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setErrorContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetErrorContentDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? ErrorContentDescription
	{
		get
		{
			if (ErrorContentDescriptionFormatted != null)
			{
				return ErrorContentDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(ErrorContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual int ErrorCurrentTextColors
	{
		[Register("getErrorCurrentTextColors", "()I", "GetGetErrorCurrentTextColorsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getErrorCurrentTextColors.()I", this, null);
		}
	}

	public unsafe virtual bool ErrorEnabled
	{
		[Register("isErrorEnabled", "()Z", "GetIsErrorEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isErrorEnabled.()Z", this, null);
		}
		[Register("setErrorEnabled", "(Z)V", "GetSetErrorEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Drawable? ErrorIconDrawable
	{
		[Register("getErrorIconDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetErrorIconDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorIconDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setErrorIconDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetErrorIconDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorIconDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool ExpandedHintEnabled
	{
		[Register("isExpandedHintEnabled", "()Z", "GetIsExpandedHintEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isExpandedHintEnabled.()Z", this, null);
		}
		[Register("setExpandedHintEnabled", "(Z)V", "GetSetExpandedHintEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExpandedHintEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? HelperTextFormatted
	{
		[Register("getHelperText", "()Ljava/lang/CharSequence;", "GetGetHelperTextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHelperText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setHelperText", "(Ljava/lang/CharSequence;)V", "GetSetHelperText_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHelperText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? HelperText
	{
		get
		{
			if (HelperTextFormatted != null)
			{
				return HelperTextFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(HelperTextFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual int HelperTextCurrentTextColor
	{
		[Register("getHelperTextCurrentTextColor", "()I", "GetGetHelperTextCurrentTextColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHelperTextCurrentTextColor.()I", this, null);
		}
	}

	public unsafe virtual bool HelperTextEnabled
	{
		[Register("isHelperTextEnabled", "()Z", "GetIsHelperTextEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHelperTextEnabled.()Z", this, null);
		}
		[Register("setHelperTextEnabled", "(Z)V", "GetSetHelperTextEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHelperTextEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? HintFormatted
	{
		[Register("getHint", "()Ljava/lang/CharSequence;", "GetGetHintHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHint.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setHint", "(Ljava/lang/CharSequence;)V", "GetSetHint_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHint.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? Hint
	{
		get
		{
			if (HintFormatted != null)
			{
				return HintFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(HintFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual bool HintAnimationEnabled
	{
		[Register("isHintAnimationEnabled", "()Z", "GetIsHintAnimationEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHintAnimationEnabled.()Z", this, null);
		}
		[Register("setHintAnimationEnabled", "(Z)V", "GetSetHintAnimationEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHintAnimationEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool HintEnabled
	{
		[Register("isHintEnabled", "()Z", "GetIsHintEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHintEnabled.()Z", this, null);
		}
		[Register("setHintEnabled", "(Z)V", "GetSetHintEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHintEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? HintTextColor
	{
		[Register("getHintTextColor", "()Landroid/content/res/ColorStateList;", "GetGetHintTextColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHintTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setHintTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetHintTextColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHintTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool IsProvidingHint
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isProvidingHint", "()Z", "GetIsProvidingHintHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isProvidingHint.()Z", this, null);
		}
	}

	public unsafe virtual ILengthCounter LengthCounter
	{
		[Register("getLengthCounter", "()Lcom/google/android/material/textfield/TextInputLayout$LengthCounter;", "GetGetLengthCounterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ILengthCounter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLengthCounter.()Lcom/google/android/material/textfield/TextInputLayout$LengthCounter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setLengthCounter", "(Lcom/google/android/material/textfield/TextInputLayout$LengthCounter;)V", "GetSetLengthCounter_Lcom_google_android_material_textfield_TextInputLayout_LengthCounter_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLengthCounter.(Lcom/google/android/material/textfield/TextInputLayout$LengthCounter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int MaxEms
	{
		[Register("getMaxEms", "()I", "GetGetMaxEmsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxEms.()I", this, null);
		}
		[Register("setMaxEms", "(I)V", "GetSetMaxEms_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxEms.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MaxWidth
	{
		[Register("getMaxWidth", "()I", "GetGetMaxWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxWidth.()I", this, null);
		}
		[Register("setMaxWidth", "(I)V", "GetSetMaxWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MinEms
	{
		[Register("getMinEms", "()I", "GetGetMinEmsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinEms.()I", this, null);
		}
		[Register("setMinEms", "(I)V", "GetSetMinEms_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinEms.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MinWidth
	{
		[Register("getMinWidth", "()I", "GetGetMinWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinWidth.()I", this, null);
		}
		[Register("setMinWidth", "(I)V", "GetSetMinWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinWidth.(I)V", this, ptr);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual ICharSequence? PasswordVisibilityToggleContentDescriptionFormatted
	{
		[Register("getPasswordVisibilityToggleContentDescription", "()Ljava/lang/CharSequence;", "GetGetPasswordVisibilityToggleContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPasswordVisibilityToggleContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPasswordVisibilityToggleContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? PasswordVisibilityToggleContentDescription
	{
		get
		{
			if (PasswordVisibilityToggleContentDescriptionFormatted != null)
			{
				return PasswordVisibilityToggleContentDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(PasswordVisibilityToggleContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual Drawable? PasswordVisibilityToggleDrawable
	{
		[Register("getPasswordVisibilityToggleDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetPasswordVisibilityToggleDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPasswordVisibilityToggleDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPasswordVisibilityToggleDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual bool PasswordVisibilityToggleEnabled
	{
		[Register("isPasswordVisibilityToggleEnabled", "()Z", "GetIsPasswordVisibilityToggleEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPasswordVisibilityToggleEnabled.()Z", this, null);
		}
		[Register("setPasswordVisibilityToggleEnabled", "(Z)V", "GetSetPasswordVisibilityToggleEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? PlaceholderTextFormatted
	{
		[Register("getPlaceholderText", "()Ljava/lang/CharSequence;", "GetGetPlaceholderTextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPlaceholderText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPlaceholderText", "(Ljava/lang/CharSequence;)V", "GetSetPlaceholderText_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPlaceholderText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? PlaceholderText
	{
		get
		{
			if (PlaceholderTextFormatted != null)
			{
				return PlaceholderTextFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(PlaceholderTextFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual int PlaceholderTextAppearance
	{
		[Register("getPlaceholderTextAppearance", "()I", "GetGetPlaceholderTextAppearanceHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPlaceholderTextAppearance.()I", this, null);
		}
		[Register("setPlaceholderTextAppearance", "(I)V", "GetSetPlaceholderTextAppearance_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPlaceholderTextAppearance.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? PlaceholderTextColor
	{
		[Register("getPlaceholderTextColor", "()Landroid/content/res/ColorStateList;", "GetGetPlaceholderTextColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPlaceholderTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPlaceholderTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetPlaceholderTextColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPlaceholderTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ICharSequence? PrefixTextFormatted
	{
		[Register("getPrefixText", "()Ljava/lang/CharSequence;", "GetGetPrefixTextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrefixText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPrefixText", "(Ljava/lang/CharSequence;)V", "GetSetPrefixText_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPrefixText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? PrefixText
	{
		get
		{
			if (PrefixTextFormatted != null)
			{
				return PrefixTextFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(PrefixTextFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual ColorStateList? PrefixTextColor
	{
		[Register("getPrefixTextColor", "()Landroid/content/res/ColorStateList;", "GetGetPrefixTextColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrefixTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPrefixTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetPrefixTextColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPrefixTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual TextView PrefixTextView
	{
		[Register("getPrefixTextView", "()Landroid/widget/TextView;", "GetGetPrefixTextViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<TextView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrefixTextView.()Landroid/widget/TextView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ShapeAppearanceModel ShapeAppearanceModel
	{
		[Register("getShapeAppearanceModel", "()Lcom/google/android/material/shape/ShapeAppearanceModel;", "GetGetShapeAppearanceModelHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShapeAppearanceModel.()Lcom/google/android/material/shape/ShapeAppearanceModel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setShapeAppearanceModel", "(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", "GetSetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShapeAppearanceModel.(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool StartIconCheckable
	{
		[Register("isStartIconCheckable", "()Z", "GetIsStartIconCheckableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStartIconCheckable.()Z", this, null);
		}
		[Register("setStartIconCheckable", "(Z)V", "GetSetStartIconCheckable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconCheckable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? StartIconContentDescriptionFormatted
	{
		[Register("getStartIconContentDescription", "()Ljava/lang/CharSequence;", "GetGetStartIconContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStartIconContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStartIconContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetStartIconContentDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? StartIconContentDescription
	{
		get
		{
			if (StartIconContentDescriptionFormatted != null)
			{
				return StartIconContentDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(StartIconContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual Drawable? StartIconDrawable
	{
		[Register("getStartIconDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetStartIconDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStartIconDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStartIconDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetStartIconDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int StartIconMinSize
	{
		[Register("getStartIconMinSize", "()I", "GetGetStartIconMinSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getStartIconMinSize.()I", this, null);
		}
		[Register("setStartIconMinSize", "(I)V", "GetSetStartIconMinSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconMinSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual ImageView.ScaleType StartIconScaleType
	{
		[Register("getStartIconScaleType", "()Landroid/widget/ImageView$ScaleType;", "GetGetStartIconScaleTypeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ImageView.ScaleType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStartIconScaleType.()Landroid/widget/ImageView$ScaleType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStartIconScaleType", "(Landroid/widget/ImageView$ScaleType;)V", "GetSetStartIconScaleType_Landroid_widget_ImageView_ScaleType_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconScaleType.(Landroid/widget/ImageView$ScaleType;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool StartIconVisible
	{
		[Register("isStartIconVisible", "()Z", "GetIsStartIconVisibleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStartIconVisible.()Z", this, null);
		}
		[Register("setStartIconVisible", "(Z)V", "GetSetStartIconVisible_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconVisible.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? SuffixTextFormatted
	{
		[Register("getSuffixText", "()Ljava/lang/CharSequence;", "GetGetSuffixTextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSuffixText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSuffixText", "(Ljava/lang/CharSequence;)V", "GetSetSuffixText_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSuffixText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? SuffixText
	{
		get
		{
			if (SuffixTextFormatted != null)
			{
				return SuffixTextFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(SuffixTextFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual ColorStateList? SuffixTextColor
	{
		[Register("getSuffixTextColor", "()Landroid/content/res/ColorStateList;", "GetGetSuffixTextColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSuffixTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSuffixTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetSuffixTextColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSuffixTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual TextView SuffixTextView
	{
		[Register("getSuffixTextView", "()Landroid/widget/TextView;", "GetGetSuffixTextViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<TextView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSuffixTextView.()Landroid/widget/TextView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Typeface? Typeface
	{
		[Register("getTypeface", "()Landroid/graphics/Typeface;", "GetGetTypefaceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Typeface>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTypeface.()Landroid/graphics/Typeface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTypeface", "(Landroid/graphics/Typeface;)V", "GetSetTypeface_Landroid_graphics_Typeface_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTypeface.(Landroid/graphics/Typeface;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public event EventHandler<EditTextAttachedEventArgs> EditTextAttached
	{
		add
		{
			EventHelper.AddEventHandler<IOnEditTextAttachedListener, IOnEditTextAttachedListenerImplementor>(ref weak_implementor_AddOnEditTextAttachedListener, __CreateIOnEditTextAttachedListenerImplementor, AddOnEditTextAttachedListener, delegate(IOnEditTextAttachedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<EditTextAttachedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnEditTextAttachedListener, IOnEditTextAttachedListenerImplementor.__IsEmpty, delegate(IOnEditTextAttachedListener __v)
			{
				RemoveOnEditTextAttachedListener(__v);
			}, delegate(IOnEditTextAttachedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<EditTextAttachedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<EndIconChangedEventArgs> EndIconChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnEndIconChangedListener, IOnEndIconChangedListenerImplementor>(ref weak_implementor_AddOnEndIconChangedListener, __CreateIOnEndIconChangedListenerImplementor, AddOnEndIconChangedListener, delegate(IOnEndIconChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<EndIconChangedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnEndIconChangedListener, IOnEndIconChangedListenerImplementor.__IsEmpty, delegate(IOnEndIconChangedListener __v)
			{
				RemoveOnEndIconChangedListener(__v);
			}, delegate(IOnEndIconChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<EndIconChangedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public void SetEnabled(bool enabled)
	{
		Enabled = enabled;
	}

	protected TextInputLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe TextInputLayout(Context context)
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
	public unsafe TextInputLayout(Context context, IAttributeSet? attrs)
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
	public unsafe TextInputLayout(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetGetBoxBackgroundColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBoxBackgroundColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBoxBackgroundColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxBackgroundColor;
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

	private static Delegate GetSetBoxBackgroundColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxBackgroundColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxBackgroundColor_I(nint jnienv, nint native__this, int boxBackgroundColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxBackgroundColor = boxBackgroundColor;
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

	private static Delegate GetGetBoxBackgroundModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBoxBackgroundMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBoxBackgroundMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxBackgroundMode;
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

	private static Delegate GetSetBoxBackgroundMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxBackgroundMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxBackgroundMode_I(nint jnienv, nint native__this, int boxBackgroundMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxBackgroundMode = boxBackgroundMode;
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

	private static Delegate GetGetBoxCollapsedPaddingTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBoxCollapsedPaddingTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBoxCollapsedPaddingTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCollapsedPaddingTop;
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

	private static Delegate GetSetBoxCollapsedPaddingTop_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxCollapsedPaddingTop_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxCollapsedPaddingTop_I(nint jnienv, nint native__this, int boxCollapsedPaddingTop)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCollapsedPaddingTop = boxCollapsedPaddingTop;
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

	private static Delegate GetGetBoxCornerRadiusBottomEndHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetBoxCornerRadiusBottomEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBoxCornerRadiusBottomEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCornerRadiusBottomEnd;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBoxCornerRadiusBottomStartHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetBoxCornerRadiusBottomStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBoxCornerRadiusBottomStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCornerRadiusBottomStart;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBoxCornerRadiusTopEndHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetBoxCornerRadiusTopEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBoxCornerRadiusTopEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCornerRadiusTopEnd;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBoxCornerRadiusTopStartHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetBoxCornerRadiusTopStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBoxCornerRadiusTopStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCornerRadiusTopStart;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBoxStrokeColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBoxStrokeColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBoxStrokeColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeColor;
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

	private static Delegate GetSetBoxStrokeColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxStrokeColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxStrokeColor_I(nint jnienv, nint native__this, int boxStrokeColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeColor = boxStrokeColor;
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

	private static Delegate GetGetBoxStrokeErrorColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBoxStrokeErrorColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBoxStrokeErrorColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeErrorColor);
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

	private static Delegate GetSetBoxStrokeErrorColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBoxStrokeErrorColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxStrokeErrorColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_strokeErrorColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList boxStrokeErrorColor = Java.Lang.Object.GetObject<ColorStateList>(native_strokeErrorColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.BoxStrokeErrorColor = boxStrokeErrorColor;
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

	private static Delegate GetGetBoxStrokeWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBoxStrokeWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBoxStrokeWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeWidth;
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

	private static Delegate GetSetBoxStrokeWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxStrokeWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxStrokeWidth_I(nint jnienv, nint native__this, int boxStrokeWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeWidth = boxStrokeWidth;
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

	private static Delegate GetGetBoxStrokeWidthFocusedHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBoxStrokeWidthFocused);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBoxStrokeWidthFocused(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeWidthFocused;
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

	private static Delegate GetSetBoxStrokeWidthFocused_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxStrokeWidthFocused_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxStrokeWidthFocused_I(nint jnienv, nint native__this, int boxStrokeWidthFocused)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeWidthFocused = boxStrokeWidthFocused;
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

	private static Delegate GetIsCounterEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCounterEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCounterEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetCounterEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCounterEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCounterEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool counterEnabled = native_enabled != 0;
			textInputLayout.CounterEnabled = counterEnabled;
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

	private static Delegate GetGetCounterMaxLengthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCounterMaxLength);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCounterMaxLength(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterMaxLength;
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

	private static Delegate GetSetCounterMaxLength_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCounterMaxLength_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCounterMaxLength_I(nint jnienv, nint native__this, int maxLength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterMaxLength = maxLength;
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

	private static Delegate GetGetCounterOverflowTextColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCounterOverflowTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCounterOverflowTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterOverflowTextColor);
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

	private static Delegate GetSetCounterOverflowTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCounterOverflowTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCounterOverflowTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_counterOverflowTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList counterOverflowTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_counterOverflowTextColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.CounterOverflowTextColor = counterOverflowTextColor;
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

	private static Delegate GetGetCounterTextColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCounterTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCounterTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterTextColor);
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

	private static Delegate GetSetCounterTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCounterTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCounterTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_counterTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList counterTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_counterTextColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.CounterTextColor = counterTextColor;
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

	private static Delegate GetGetCursorColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCursorColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCursorColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CursorColor);
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

	private static Delegate GetSetCursorColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCursorColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCursorColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_cursorColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList cursorColor = Java.Lang.Object.GetObject<ColorStateList>(native_cursorColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.CursorColor = cursorColor;
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

	private static Delegate GetGetCursorErrorColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCursorErrorColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCursorErrorColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CursorErrorColor);
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

	private static Delegate GetSetCursorErrorColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCursorErrorColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCursorErrorColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_cursorErrorColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList cursorErrorColor = Java.Lang.Object.GetObject<ColorStateList>(native_cursorErrorColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.CursorErrorColor = cursorErrorColor;
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

	private static Delegate GetGetDefaultHintTextColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDefaultHintTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefaultHintTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultHintTextColor);
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

	private static Delegate GetSetDefaultHintTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetDefaultHintTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDefaultHintTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_textColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList defaultHintTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_textColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.DefaultHintTextColor = defaultHintTextColor;
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

	private static Delegate GetGetEditTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetEditText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEditText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EditText);
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

	private static Delegate GetIsEndIconCheckableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsEndIconCheckable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEndIconCheckable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconCheckable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetEndIconCheckable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetEndIconCheckable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconCheckable_Z(nint jnienv, nint native__this, sbyte native_endIconCheckable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool endIconCheckable = native_endIconCheckable != 0;
			textInputLayout.EndIconCheckable = endIconCheckable;
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

	private static Delegate GetGetEndIconContentDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetEndIconContentDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEndIconContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconContentDescriptionFormatted);
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

	private static Delegate GetSetEndIconContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEndIconContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_endIconContentDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence endIconContentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_endIconContentDescription, JniHandleOwnership.DoNotTransfer);
			textInputLayout.EndIconContentDescriptionFormatted = endIconContentDescriptionFormatted;
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

	private static Delegate GetGetEndIconDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetEndIconDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEndIconDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconDrawable);
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

	private static Delegate GetSetEndIconDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEndIconDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_endIconDrawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable endIconDrawable = Java.Lang.Object.GetObject<Drawable>(native_endIconDrawable, JniHandleOwnership.DoNotTransfer);
			textInputLayout.EndIconDrawable = endIconDrawable;
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

	private static Delegate GetGetEndIconMinSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetEndIconMinSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetEndIconMinSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconMinSize;
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

	private static Delegate GetSetEndIconMinSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetEndIconMinSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconMinSize_I(nint jnienv, nint native__this, int iconSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconMinSize = iconSize;
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

	private static Delegate GetGetEndIconModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetEndIconMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetEndIconMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconMode;
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

	private static Delegate GetSetEndIconMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetEndIconMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconMode_I(nint jnienv, nint native__this, int endIconMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconMode = endIconMode;
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

	private static Delegate GetGetEndIconScaleTypeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetEndIconScaleType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEndIconScaleType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconScaleType);
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

	private static Delegate GetSetEndIconScaleType_Landroid_widget_ImageView_ScaleType_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEndIconScaleType_Landroid_widget_ImageView_ScaleType_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconScaleType_Landroid_widget_ImageView_ScaleType_(nint jnienv, nint native__this, nint native_scaleType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ImageView.ScaleType endIconScaleType = Java.Lang.Object.GetObject<ImageView.ScaleType>(native_scaleType, JniHandleOwnership.DoNotTransfer);
			textInputLayout.EndIconScaleType = endIconScaleType;
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

	private static Delegate GetIsEndIconVisibleHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsEndIconVisible);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEndIconVisible(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndIconVisible ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetEndIconVisible_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetEndIconVisible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconVisible_Z(nint jnienv, nint native__this, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool endIconVisible = native_visible != 0;
			textInputLayout.EndIconVisible = endIconVisible;
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

	private static Delegate GetGetErrorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetError);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetError(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorFormatted);
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

	private static Delegate GetSetError_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetError_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetError_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_errorText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence errorFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_errorText, JniHandleOwnership.DoNotTransfer);
			textInputLayout.ErrorFormatted = errorFormatted;
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

	private static Delegate GetGetErrorAccessibilityLiveRegionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetErrorAccessibilityLiveRegion);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetErrorAccessibilityLiveRegion(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorAccessibilityLiveRegion;
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

	private static Delegate GetSetErrorAccessibilityLiveRegion_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetErrorAccessibilityLiveRegion_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorAccessibilityLiveRegion_I(nint jnienv, nint native__this, int errorAccessibilityLiveRegion)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorAccessibilityLiveRegion = errorAccessibilityLiveRegion;
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

	private static Delegate GetGetErrorContentDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetErrorContentDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetErrorContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorContentDescriptionFormatted);
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

	private static Delegate GetSetErrorContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetErrorContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_errorContentDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence errorContentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_errorContentDescription, JniHandleOwnership.DoNotTransfer);
			textInputLayout.ErrorContentDescriptionFormatted = errorContentDescriptionFormatted;
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

	private static Delegate GetGetErrorCurrentTextColorsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetErrorCurrentTextColors);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetErrorCurrentTextColors(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorCurrentTextColors;
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

	private static Delegate GetIsErrorEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsErrorEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsErrorEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetErrorEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetErrorEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool errorEnabled = native_enabled != 0;
			textInputLayout.ErrorEnabled = errorEnabled;
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

	private static Delegate GetGetErrorIconDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetErrorIconDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetErrorIconDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorIconDrawable);
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

	private static Delegate GetSetErrorIconDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetErrorIconDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorIconDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_errorIconDrawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable errorIconDrawable = Java.Lang.Object.GetObject<Drawable>(native_errorIconDrawable, JniHandleOwnership.DoNotTransfer);
			textInputLayout.ErrorIconDrawable = errorIconDrawable;
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

	private static Delegate GetIsExpandedHintEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsExpandedHintEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsExpandedHintEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedHintEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetExpandedHintEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetExpandedHintEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExpandedHintEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool expandedHintEnabled = native_enabled != 0;
			textInputLayout.ExpandedHintEnabled = expandedHintEnabled;
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

	private static Delegate GetGetHelperTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHelperText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHelperText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HelperTextFormatted);
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

	private static Delegate GetSetHelperText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHelperText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHelperText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_helperText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence helperTextFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_helperText, JniHandleOwnership.DoNotTransfer);
			textInputLayout.HelperTextFormatted = helperTextFormatted;
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

	private static Delegate GetGetHelperTextCurrentTextColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHelperTextCurrentTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHelperTextCurrentTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HelperTextCurrentTextColor;
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

	private static Delegate GetIsHelperTextEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHelperTextEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHelperTextEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HelperTextEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHelperTextEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHelperTextEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHelperTextEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool helperTextEnabled = native_enabled != 0;
			textInputLayout.HelperTextEnabled = helperTextEnabled;
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

	private static Delegate GetGetHintHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintFormatted);
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

	private static Delegate GetSetHint_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHint_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHint_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_hint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence hintFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_hint, JniHandleOwnership.DoNotTransfer);
			textInputLayout.HintFormatted = hintFormatted;
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

	private static Delegate GetIsHintAnimationEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHintAnimationEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHintAnimationEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintAnimationEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHintAnimationEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHintAnimationEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHintAnimationEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hintAnimationEnabled = native_enabled != 0;
			textInputLayout.HintAnimationEnabled = hintAnimationEnabled;
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

	private static Delegate GetIsHintEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHintEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHintEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHintEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHintEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHintEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hintEnabled = native_enabled != 0;
			textInputLayout.HintEnabled = hintEnabled;
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

	private static Delegate GetGetHintTextColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHintTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHintTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintTextColor);
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

	private static Delegate GetSetHintTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHintTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHintTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_hintTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList hintTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_hintTextColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.HintTextColor = hintTextColor;
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

	private static Delegate GetIsProvidingHintHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsProvidingHint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsProvidingHint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsProvidingHint ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLengthCounterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLengthCounter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLengthCounter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LengthCounter);
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

	private static Delegate GetSetLengthCounter_Lcom_google_android_material_textfield_TextInputLayout_LengthCounter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLengthCounter_Lcom_google_android_material_textfield_TextInputLayout_LengthCounter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLengthCounter_Lcom_google_android_material_textfield_TextInputLayout_LengthCounter_(nint jnienv, nint native__this, nint native_lengthCounter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILengthCounter lengthCounter = Java.Lang.Object.GetObject<ILengthCounter>(native_lengthCounter, JniHandleOwnership.DoNotTransfer);
			textInputLayout.LengthCounter = lengthCounter;
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

	private static Delegate GetGetMaxEmsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxEms);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxEms(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxEms;
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

	private static Delegate GetSetMaxEms_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxEms_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxEms_I(nint jnienv, nint native__this, int maxEms)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxEms = maxEms;
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

	private static Delegate GetGetMaxWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth;
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

	private static Delegate GetSetMaxWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxWidth_I(nint jnienv, nint native__this, int maxWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth = maxWidth;
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

	private static Delegate GetGetMinEmsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMinEms);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinEms(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinEms;
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

	private static Delegate GetSetMinEms_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMinEms_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinEms_I(nint jnienv, nint native__this, int minEms)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinEms = minEms;
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

	private static Delegate GetGetMinWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMinWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth;
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

	private static Delegate GetSetMinWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMinWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinWidth_I(nint jnienv, nint native__this, int minWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth = minWidth;
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

	[Obsolete]
	private static Delegate GetGetPasswordVisibilityToggleContentDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPasswordVisibilityToggleContentDescription);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPasswordVisibilityToggleContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PasswordVisibilityToggleContentDescriptionFormatted);
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

	[Obsolete]
	private static Delegate GetSetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_description)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence passwordVisibilityToggleContentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_description, JniHandleOwnership.DoNotTransfer);
			textInputLayout.PasswordVisibilityToggleContentDescriptionFormatted = passwordVisibilityToggleContentDescriptionFormatted;
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

	[Obsolete]
	private static Delegate GetGetPasswordVisibilityToggleDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPasswordVisibilityToggleDrawable);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPasswordVisibilityToggleDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PasswordVisibilityToggleDrawable);
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

	[Obsolete]
	private static Delegate GetSetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable passwordVisibilityToggleDrawable = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			textInputLayout.PasswordVisibilityToggleDrawable = passwordVisibilityToggleDrawable;
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

	[Obsolete]
	private static Delegate GetIsPasswordVisibilityToggleEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsPasswordVisibilityToggleEnabled);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsPasswordVisibilityToggleEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PasswordVisibilityToggleEnabled ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete]
	private static Delegate GetSetPasswordVisibilityToggleEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetPasswordVisibilityToggleEnabled_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPasswordVisibilityToggleEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool passwordVisibilityToggleEnabled = native_enabled != 0;
			textInputLayout.PasswordVisibilityToggleEnabled = passwordVisibilityToggleEnabled;
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

	private static Delegate GetGetPlaceholderTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPlaceholderText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPlaceholderText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PlaceholderTextFormatted);
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

	private static Delegate GetSetPlaceholderText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPlaceholderText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPlaceholderText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_placeholderText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence placeholderTextFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_placeholderText, JniHandleOwnership.DoNotTransfer);
			textInputLayout.PlaceholderTextFormatted = placeholderTextFormatted;
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

	private static Delegate GetGetPlaceholderTextAppearanceHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetPlaceholderTextAppearance);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPlaceholderTextAppearance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PlaceholderTextAppearance;
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

	private static Delegate GetSetPlaceholderTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPlaceholderTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPlaceholderTextAppearance_I(nint jnienv, nint native__this, int placeholderTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PlaceholderTextAppearance = placeholderTextAppearance;
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

	private static Delegate GetGetPlaceholderTextColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPlaceholderTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPlaceholderTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PlaceholderTextColor);
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

	private static Delegate GetSetPlaceholderTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPlaceholderTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPlaceholderTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_placeholderTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList placeholderTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_placeholderTextColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.PlaceholderTextColor = placeholderTextColor;
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

	private static Delegate GetGetPrefixTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPrefixText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPrefixText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrefixTextFormatted);
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

	private static Delegate GetSetPrefixText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPrefixText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPrefixText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_prefixText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence prefixTextFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_prefixText, JniHandleOwnership.DoNotTransfer);
			textInputLayout.PrefixTextFormatted = prefixTextFormatted;
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

	private static Delegate GetGetPrefixTextColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPrefixTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPrefixTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrefixTextColor);
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

	private static Delegate GetSetPrefixTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPrefixTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPrefixTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_prefixTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList prefixTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_prefixTextColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.PrefixTextColor = prefixTextColor;
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

	private static Delegate GetGetPrefixTextViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPrefixTextView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPrefixTextView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrefixTextView);
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

	private static Delegate GetGetShapeAppearanceModelHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetShapeAppearanceModel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetShapeAppearanceModel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShapeAppearanceModel);
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

	private static Delegate GetSetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_(nint jnienv, nint native__this, nint native_shapeAppearanceModel)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapeAppearanceModel shapeAppearanceModel = Java.Lang.Object.GetObject<ShapeAppearanceModel>(native_shapeAppearanceModel, JniHandleOwnership.DoNotTransfer);
			textInputLayout.ShapeAppearanceModel = shapeAppearanceModel;
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

	private static Delegate GetIsStartIconCheckableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsStartIconCheckable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsStartIconCheckable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartIconCheckable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetStartIconCheckable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetStartIconCheckable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconCheckable_Z(nint jnienv, nint native__this, sbyte native_startIconCheckable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool startIconCheckable = native_startIconCheckable != 0;
			textInputLayout.StartIconCheckable = startIconCheckable;
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

	private static Delegate GetGetStartIconContentDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStartIconContentDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStartIconContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartIconContentDescriptionFormatted);
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

	private static Delegate GetSetStartIconContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStartIconContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_startIconContentDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence startIconContentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_startIconContentDescription, JniHandleOwnership.DoNotTransfer);
			textInputLayout.StartIconContentDescriptionFormatted = startIconContentDescriptionFormatted;
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

	private static Delegate GetGetStartIconDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStartIconDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStartIconDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartIconDrawable);
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

	private static Delegate GetSetStartIconDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStartIconDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_startIconDrawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable startIconDrawable = Java.Lang.Object.GetObject<Drawable>(native_startIconDrawable, JniHandleOwnership.DoNotTransfer);
			textInputLayout.StartIconDrawable = startIconDrawable;
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

	private static Delegate GetGetStartIconMinSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetStartIconMinSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetStartIconMinSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartIconMinSize;
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

	private static Delegate GetSetStartIconMinSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStartIconMinSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconMinSize_I(nint jnienv, nint native__this, int iconSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartIconMinSize = iconSize;
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

	private static Delegate GetGetStartIconScaleTypeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStartIconScaleType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStartIconScaleType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartIconScaleType);
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

	private static Delegate GetSetStartIconScaleType_Landroid_widget_ImageView_ScaleType_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStartIconScaleType_Landroid_widget_ImageView_ScaleType_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconScaleType_Landroid_widget_ImageView_ScaleType_(nint jnienv, nint native__this, nint native_scaleType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ImageView.ScaleType startIconScaleType = Java.Lang.Object.GetObject<ImageView.ScaleType>(native_scaleType, JniHandleOwnership.DoNotTransfer);
			textInputLayout.StartIconScaleType = startIconScaleType;
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

	private static Delegate GetIsStartIconVisibleHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsStartIconVisible);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsStartIconVisible(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartIconVisible ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetStartIconVisible_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetStartIconVisible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconVisible_Z(nint jnienv, nint native__this, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool startIconVisible = native_visible != 0;
			textInputLayout.StartIconVisible = startIconVisible;
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

	private static Delegate GetGetSuffixTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSuffixText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSuffixText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SuffixTextFormatted);
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

	private static Delegate GetSetSuffixText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSuffixText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSuffixText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_suffixText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence suffixTextFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_suffixText, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SuffixTextFormatted = suffixTextFormatted;
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

	private static Delegate GetGetSuffixTextColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSuffixTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSuffixTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SuffixTextColor);
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

	private static Delegate GetSetSuffixTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSuffixTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSuffixTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_suffixTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList suffixTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_suffixTextColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SuffixTextColor = suffixTextColor;
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

	private static Delegate GetGetSuffixTextViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSuffixTextView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSuffixTextView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SuffixTextView);
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

	private static Delegate GetGetTypefaceHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTypeface);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTypeface(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Typeface);
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

	private static Delegate GetSetTypeface_Landroid_graphics_Typeface_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTypeface_Landroid_graphics_Typeface_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTypeface_Landroid_graphics_Typeface_(nint jnienv, nint native__this, nint native_typeface)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Typeface typeface = Java.Lang.Object.GetObject<Typeface>(native_typeface, JniHandleOwnership.DoNotTransfer);
			textInputLayout.Typeface = typeface;
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

	private static Delegate GetAddOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnEditTextAttachedListener listener = Java.Lang.Object.GetObject<IOnEditTextAttachedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.AddOnEditTextAttachedListener(listener);
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

	[Register("addOnEditTextAttachedListener", "(Lcom/google/android/material/textfield/TextInputLayout$OnEditTextAttachedListener;)V", "GetAddOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener_Handler")]
	public unsafe virtual void AddOnEditTextAttachedListener(IOnEditTextAttachedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnEditTextAttachedListener.(Lcom/google/android/material/textfield/TextInputLayout$OnEditTextAttachedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnEndIconChangedListener listener = Java.Lang.Object.GetObject<IOnEndIconChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.AddOnEndIconChangedListener(listener);
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

	[Register("addOnEndIconChangedListener", "(Lcom/google/android/material/textfield/TextInputLayout$OnEndIconChangedListener;)V", "GetAddOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener_Handler")]
	public unsafe virtual void AddOnEndIconChangedListener(IOnEndIconChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnEndIconChangedListener.(Lcom/google/android/material/textfield/TextInputLayout$OnEndIconChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetClearOnEditTextAttachedListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnEditTextAttachedListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnEditTextAttachedListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnEditTextAttachedListeners();
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

	[Register("clearOnEditTextAttachedListeners", "()V", "GetClearOnEditTextAttachedListenersHandler")]
	public unsafe virtual void ClearOnEditTextAttachedListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnEditTextAttachedListeners.()V", this, null);
	}

	private static Delegate GetClearOnEndIconChangedListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnEndIconChangedListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnEndIconChangedListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnEndIconChangedListeners();
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

	[Register("clearOnEndIconChangedListeners", "()V", "GetClearOnEndIconChangedListenersHandler")]
	public unsafe virtual void ClearOnEndIconChangedListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnEndIconChangedListeners.()V", this, null);
	}

	private static Delegate GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_DispatchRestoreInstanceState_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchRestoreInstanceState_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SparseArray container = Java.Lang.Object.GetObject<SparseArray>(native_container, JniHandleOwnership.DoNotTransfer);
			textInputLayout.DispatchRestoreInstanceState(container);
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

	[Register("dispatchRestoreInstanceState", "(Landroid/util/SparseArray;)V", "GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler")]
	protected unsafe override void DispatchRestoreInstanceState(SparseArray container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchRestoreInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetOnGlobalLayoutHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnGlobalLayout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnGlobalLayout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnGlobalLayout();
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

	[Register("onGlobalLayout", "()V", "GetOnGlobalLayoutHandler")]
	public unsafe virtual void OnGlobalLayout()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onGlobalLayout.()V", this, null);
	}

	private static Delegate GetOnSaveInstanceStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_OnSaveInstanceState);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

	[Obsolete]
	private static Delegate GetPasswordVisibilityToggleRequested_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_PasswordVisibilityToggleRequested_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PasswordVisibilityToggleRequested_Z(nint jnienv, nint native__this, sbyte native_shouldSkipAnimations)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shouldSkipAnimations = native_shouldSkipAnimations != 0;
			textInputLayout.PasswordVisibilityToggleRequested(shouldSkipAnimations);
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

	[Obsolete("deprecated")]
	[Register("passwordVisibilityToggleRequested", "(Z)V", "GetPasswordVisibilityToggleRequested_ZHandler")]
	public unsafe virtual void PasswordVisibilityToggleRequested(bool shouldSkipAnimations)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shouldSkipAnimations ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("passwordVisibilityToggleRequested.(Z)V", this, ptr);
	}

	private static Delegate GetRefreshEndIconDrawableStateHandler()
	{
		return new global::_JniMarshal_PP_V(n_RefreshEndIconDrawableState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RefreshEndIconDrawableState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RefreshEndIconDrawableState();
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

	[Register("refreshEndIconDrawableState", "()V", "GetRefreshEndIconDrawableStateHandler")]
	public unsafe virtual void RefreshEndIconDrawableState()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("refreshEndIconDrawableState.()V", this, null);
	}

	private static Delegate GetRefreshErrorIconDrawableStateHandler()
	{
		return new global::_JniMarshal_PP_V(n_RefreshErrorIconDrawableState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RefreshErrorIconDrawableState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RefreshErrorIconDrawableState();
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

	[Register("refreshErrorIconDrawableState", "()V", "GetRefreshErrorIconDrawableStateHandler")]
	public unsafe virtual void RefreshErrorIconDrawableState()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("refreshErrorIconDrawableState.()V", this, null);
	}

	private static Delegate GetRefreshStartIconDrawableStateHandler()
	{
		return new global::_JniMarshal_PP_V(n_RefreshStartIconDrawableState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RefreshStartIconDrawableState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RefreshStartIconDrawableState();
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

	[Register("refreshStartIconDrawableState", "()V", "GetRefreshStartIconDrawableStateHandler")]
	public unsafe virtual void RefreshStartIconDrawableState()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("refreshStartIconDrawableState.()V", this, null);
	}

	private static Delegate GetRemoveOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnEditTextAttachedListener listener = Java.Lang.Object.GetObject<IOnEditTextAttachedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.RemoveOnEditTextAttachedListener(listener);
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

	[Register("removeOnEditTextAttachedListener", "(Lcom/google/android/material/textfield/TextInputLayout$OnEditTextAttachedListener;)V", "GetRemoveOnEditTextAttachedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEditTextAttachedListener_Handler")]
	public unsafe virtual void RemoveOnEditTextAttachedListener(IOnEditTextAttachedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnEditTextAttachedListener.(Lcom/google/android/material/textfield/TextInputLayout$OnEditTextAttachedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnEndIconChangedListener listener = Java.Lang.Object.GetObject<IOnEndIconChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.RemoveOnEndIconChangedListener(listener);
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

	[Register("removeOnEndIconChangedListener", "(Lcom/google/android/material/textfield/TextInputLayout$OnEndIconChangedListener;)V", "GetRemoveOnEndIconChangedListener_Lcom_google_android_material_textfield_TextInputLayout_OnEndIconChangedListener_Handler")]
	public unsafe virtual void RemoveOnEndIconChangedListener(IOnEndIconChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnEndIconChangedListener.(Lcom/google/android/material/textfield/TextInputLayout$OnEndIconChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetBoxBackgroundColorResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxBackgroundColorResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxBackgroundColorResource_I(nint jnienv, nint native__this, int boxBackgroundColorId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxBackgroundColorResource(boxBackgroundColorId);
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

	[Register("setBoxBackgroundColorResource", "(I)V", "GetSetBoxBackgroundColorResource_IHandler")]
	public unsafe virtual void SetBoxBackgroundColorResource(int boxBackgroundColorId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(boxBackgroundColorId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxBackgroundColorResource.(I)V", this, ptr);
	}

	private static Delegate GetSetBoxBackgroundColorStateList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBoxBackgroundColorStateList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxBackgroundColorStateList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_boxBackgroundColorStateList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList boxBackgroundColorStateList = Java.Lang.Object.GetObject<ColorStateList>(native_boxBackgroundColorStateList, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetBoxBackgroundColorStateList(boxBackgroundColorStateList);
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

	[Register("setBoxBackgroundColorStateList", "(Landroid/content/res/ColorStateList;)V", "GetSetBoxBackgroundColorStateList_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetBoxBackgroundColorStateList(ColorStateList boxBackgroundColorStateList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(boxBackgroundColorStateList?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxBackgroundColorStateList.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(boxBackgroundColorStateList);
		}
	}

	private static Delegate GetSetBoxCornerFamily_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxCornerFamily_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxCornerFamily_I(nint jnienv, nint native__this, int cornerFamily)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxCornerFamily(cornerFamily);
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

	[Register("setBoxCornerFamily", "(I)V", "GetSetBoxCornerFamily_IHandler")]
	public unsafe virtual void SetBoxCornerFamily(int cornerFamily)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cornerFamily);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxCornerFamily.(I)V", this, ptr);
	}

	private static Delegate GetSetBoxCornerRadii_FFFFHandler()
	{
		return new global::_JniMarshal_PPFFFF_V(n_SetBoxCornerRadii_FFFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxCornerRadii_FFFF(nint jnienv, nint native__this, float boxCornerRadiusTopStart, float boxCornerRadiusTopEnd, float boxCornerRadiusBottomStart, float boxCornerRadiusBottomEnd)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxCornerRadii(boxCornerRadiusTopStart, boxCornerRadiusTopEnd, boxCornerRadiusBottomStart, boxCornerRadiusBottomEnd);
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

	[Register("setBoxCornerRadii", "(FFFF)V", "GetSetBoxCornerRadii_FFFFHandler")]
	public unsafe virtual void SetBoxCornerRadii(float boxCornerRadiusTopStart, float boxCornerRadiusTopEnd, float boxCornerRadiusBottomStart, float boxCornerRadiusBottomEnd)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(boxCornerRadiusTopStart);
		ptr[1] = new JniArgumentValue(boxCornerRadiusTopEnd);
		ptr[2] = new JniArgumentValue(boxCornerRadiusBottomStart);
		ptr[3] = new JniArgumentValue(boxCornerRadiusBottomEnd);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxCornerRadii.(FFFF)V", this, ptr);
	}

	private static Delegate GetSetBoxCornerRadiiResources_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_SetBoxCornerRadiiResources_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxCornerRadiiResources_IIII(nint jnienv, nint native__this, int boxCornerRadiusTopStartId, int boxCornerRadiusTopEndId, int boxCornerRadiusBottomEndId, int boxCornerRadiusBottomStartId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxCornerRadiiResources(boxCornerRadiusTopStartId, boxCornerRadiusTopEndId, boxCornerRadiusBottomEndId, boxCornerRadiusBottomStartId);
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

	[Register("setBoxCornerRadiiResources", "(IIII)V", "GetSetBoxCornerRadiiResources_IIIIHandler")]
	public unsafe virtual void SetBoxCornerRadiiResources(int boxCornerRadiusTopStartId, int boxCornerRadiusTopEndId, int boxCornerRadiusBottomEndId, int boxCornerRadiusBottomStartId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(boxCornerRadiusTopStartId);
		ptr[1] = new JniArgumentValue(boxCornerRadiusTopEndId);
		ptr[2] = new JniArgumentValue(boxCornerRadiusBottomEndId);
		ptr[3] = new JniArgumentValue(boxCornerRadiusBottomStartId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxCornerRadiiResources.(IIII)V", this, ptr);
	}

	private static Delegate GetSetBoxStrokeColorStateList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBoxStrokeColorStateList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxStrokeColorStateList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_boxStrokeColorStateList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList boxStrokeColorStateList = Java.Lang.Object.GetObject<ColorStateList>(native_boxStrokeColorStateList, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetBoxStrokeColorStateList(boxStrokeColorStateList);
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

	[Register("setBoxStrokeColorStateList", "(Landroid/content/res/ColorStateList;)V", "GetSetBoxStrokeColorStateList_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetBoxStrokeColorStateList(ColorStateList boxStrokeColorStateList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(boxStrokeColorStateList?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxStrokeColorStateList.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(boxStrokeColorStateList);
		}
	}

	private static Delegate GetSetBoxStrokeWidthFocusedResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxStrokeWidthFocusedResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxStrokeWidthFocusedResource_I(nint jnienv, nint native__this, int boxStrokeWidthFocusedResId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxStrokeWidthFocusedResource(boxStrokeWidthFocusedResId);
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

	[Register("setBoxStrokeWidthFocusedResource", "(I)V", "GetSetBoxStrokeWidthFocusedResource_IHandler")]
	public unsafe virtual void SetBoxStrokeWidthFocusedResource(int boxStrokeWidthFocusedResId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(boxStrokeWidthFocusedResId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxStrokeWidthFocusedResource.(I)V", this, ptr);
	}

	private static Delegate GetSetBoxStrokeWidthResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBoxStrokeWidthResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoxStrokeWidthResource_I(nint jnienv, nint native__this, int boxStrokeWidthResId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxStrokeWidthResource(boxStrokeWidthResId);
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

	[Register("setBoxStrokeWidthResource", "(I)V", "GetSetBoxStrokeWidthResource_IHandler")]
	public unsafe virtual void SetBoxStrokeWidthResource(int boxStrokeWidthResId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(boxStrokeWidthResId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxStrokeWidthResource.(I)V", this, ptr);
	}

	private static Delegate GetSetCounterOverflowTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCounterOverflowTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCounterOverflowTextAppearance_I(nint jnienv, nint native__this, int counterOverflowTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCounterOverflowTextAppearance(counterOverflowTextAppearance);
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

	[Register("setCounterOverflowTextAppearance", "(I)V", "GetSetCounterOverflowTextAppearance_IHandler")]
	public unsafe virtual void SetCounterOverflowTextAppearance(int counterOverflowTextAppearance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(counterOverflowTextAppearance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCounterOverflowTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetCounterTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCounterTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCounterTextAppearance_I(nint jnienv, nint native__this, int counterTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCounterTextAppearance(counterTextAppearance);
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

	[Register("setCounterTextAppearance", "(I)V", "GetSetCounterTextAppearance_IHandler")]
	public unsafe virtual void SetCounterTextAppearance(int counterTextAppearance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(counterTextAppearance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCounterTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetEndIconActivated_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetEndIconActivated_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconActivated_Z(nint jnienv, nint native__this, sbyte native_endIconActivated)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool endIconActivated = native_endIconActivated != 0;
			textInputLayout.SetEndIconActivated(endIconActivated);
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

	[Register("setEndIconActivated", "(Z)V", "GetSetEndIconActivated_ZHandler")]
	public unsafe virtual void SetEndIconActivated(bool endIconActivated)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(endIconActivated ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconActivated.(Z)V", this, ptr);
	}

	private static Delegate GetSetEndIconContentDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetEndIconContentDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconContentDescription_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEndIconContentDescription(resId);
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

	[Register("setEndIconContentDescription", "(I)V", "GetSetEndIconContentDescription_IHandler")]
	public unsafe virtual void SetEndIconContentDescription(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconContentDescription.(I)V", this, ptr);
	}

	private static Delegate GetSetEndIconDrawable_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetEndIconDrawable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconDrawable_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEndIconDrawable(resId);
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

	[Register("setEndIconDrawable", "(I)V", "GetSetEndIconDrawable_IHandler")]
	public unsafe virtual void SetEndIconDrawable(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconDrawable.(I)V", this, ptr);
	}

	private static Delegate GetSetEndIconOnClickListener_Landroid_view_View_OnClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEndIconOnClickListener_Landroid_view_View_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconOnClickListener_Landroid_view_View_OnClickListener_(nint jnienv, nint native__this, nint native_endIconOnClickListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnClickListener endIconOnClickListener = Java.Lang.Object.GetObject<IOnClickListener>(native_endIconOnClickListener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetEndIconOnClickListener(endIconOnClickListener);
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

	[Register("setEndIconOnClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetEndIconOnClickListener_Landroid_view_View_OnClickListener_Handler")]
	public unsafe virtual void SetEndIconOnClickListener(IOnClickListener? endIconOnClickListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((endIconOnClickListener == null) ? IntPtr.Zero : ((Java.Lang.Object)endIconOnClickListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconOnClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(endIconOnClickListener);
		}
	}

	private static Delegate GetSetEndIconOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEndIconOnLongClickListener_Landroid_view_View_OnLongClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconOnLongClickListener_Landroid_view_View_OnLongClickListener_(nint jnienv, nint native__this, nint native_endIconOnLongClickListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLongClickListener endIconOnLongClickListener = Java.Lang.Object.GetObject<IOnLongClickListener>(native_endIconOnLongClickListener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetEndIconOnLongClickListener(endIconOnLongClickListener);
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

	[Register("setEndIconOnLongClickListener", "(Landroid/view/View$OnLongClickListener;)V", "GetSetEndIconOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler")]
	public unsafe virtual void SetEndIconOnLongClickListener(IOnLongClickListener? endIconOnLongClickListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((endIconOnLongClickListener == null) ? IntPtr.Zero : ((Java.Lang.Object)endIconOnLongClickListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconOnLongClickListener.(Landroid/view/View$OnLongClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(endIconOnLongClickListener);
		}
	}

	private static Delegate GetSetEndIconTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEndIconTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_endIconTintList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList endIconTintList = Java.Lang.Object.GetObject<ColorStateList>(native_endIconTintList, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetEndIconTintList(endIconTintList);
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

	[Register("setEndIconTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetEndIconTintList_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetEndIconTintList(ColorStateList? endIconTintList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(endIconTintList?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(endIconTintList);
		}
	}

	private static Delegate GetSetEndIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEndIconTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEndIconTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_endIconTintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode endIconTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_endIconTintMode, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetEndIconTintMode(endIconTintMode);
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

	[Register("setEndIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetEndIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
	public unsafe virtual void SetEndIconTintMode(PorterDuff.Mode? endIconTintMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(endIconTintMode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndIconTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(endIconTintMode);
		}
	}

	private static Delegate GetSetErrorIconDrawable_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetErrorIconDrawable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorIconDrawable_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetErrorIconDrawable(resId);
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

	[Register("setErrorIconDrawable", "(I)V", "GetSetErrorIconDrawable_IHandler")]
	public unsafe virtual void SetErrorIconDrawable(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorIconDrawable.(I)V", this, ptr);
	}

	private static Delegate GetSetErrorIconOnClickListener_Landroid_view_View_OnClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetErrorIconOnClickListener_Landroid_view_View_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorIconOnClickListener_Landroid_view_View_OnClickListener_(nint jnienv, nint native__this, nint native_errorIconOnClickListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnClickListener errorIconOnClickListener = Java.Lang.Object.GetObject<IOnClickListener>(native_errorIconOnClickListener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetErrorIconOnClickListener(errorIconOnClickListener);
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

	[Register("setErrorIconOnClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetErrorIconOnClickListener_Landroid_view_View_OnClickListener_Handler")]
	public unsafe virtual void SetErrorIconOnClickListener(IOnClickListener? errorIconOnClickListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((errorIconOnClickListener == null) ? IntPtr.Zero : ((Java.Lang.Object)errorIconOnClickListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorIconOnClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(errorIconOnClickListener);
		}
	}

	private static Delegate GetSetErrorIconOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetErrorIconOnLongClickListener_Landroid_view_View_OnLongClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorIconOnLongClickListener_Landroid_view_View_OnLongClickListener_(nint jnienv, nint native__this, nint native_errorIconOnLongClickListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLongClickListener errorIconOnLongClickListener = Java.Lang.Object.GetObject<IOnLongClickListener>(native_errorIconOnLongClickListener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetErrorIconOnLongClickListener(errorIconOnLongClickListener);
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

	[Register("setErrorIconOnLongClickListener", "(Landroid/view/View$OnLongClickListener;)V", "GetSetErrorIconOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler")]
	public unsafe virtual void SetErrorIconOnLongClickListener(IOnLongClickListener? errorIconOnLongClickListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((errorIconOnLongClickListener == null) ? IntPtr.Zero : ((Java.Lang.Object)errorIconOnLongClickListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorIconOnLongClickListener.(Landroid/view/View$OnLongClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(errorIconOnLongClickListener);
		}
	}

	private static Delegate GetSetErrorIconTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetErrorIconTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorIconTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_errorIconTintList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList errorIconTintList = Java.Lang.Object.GetObject<ColorStateList>(native_errorIconTintList, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetErrorIconTintList(errorIconTintList);
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

	[Register("setErrorIconTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetErrorIconTintList_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetErrorIconTintList(ColorStateList? errorIconTintList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorIconTintList?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorIconTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(errorIconTintList);
		}
	}

	private static Delegate GetSetErrorIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetErrorIconTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorIconTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_errorIconTintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode errorIconTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_errorIconTintMode, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetErrorIconTintMode(errorIconTintMode);
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

	[Register("setErrorIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetErrorIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
	public unsafe virtual void SetErrorIconTintMode(PorterDuff.Mode? errorIconTintMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorIconTintMode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorIconTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(errorIconTintMode);
		}
	}

	private static Delegate GetSetErrorTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetErrorTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorTextAppearance_I(nint jnienv, nint native__this, int errorTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetErrorTextAppearance(errorTextAppearance);
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

	[Register("setErrorTextAppearance", "(I)V", "GetSetErrorTextAppearance_IHandler")]
	public unsafe virtual void SetErrorTextAppearance(int errorTextAppearance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(errorTextAppearance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetErrorTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetErrorTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_errorTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList errorTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_errorTextColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetErrorTextColor(errorTextColor);
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

	[Register("setErrorTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetErrorTextColor_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetErrorTextColor(ColorStateList? errorTextColor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorTextColor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(errorTextColor);
		}
	}

	private static Delegate GetSetHelperTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHelperTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHelperTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_helperTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList helperTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_helperTextColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetHelperTextColor(helperTextColor);
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

	[Register("setHelperTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetHelperTextColor_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetHelperTextColor(ColorStateList? helperTextColor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(helperTextColor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHelperTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(helperTextColor);
		}
	}

	private static Delegate GetSetHelperTextTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHelperTextTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHelperTextTextAppearance_I(nint jnienv, nint native__this, int helperTextTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHelperTextTextAppearance(helperTextTextAppearance);
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

	[Register("setHelperTextTextAppearance", "(I)V", "GetSetHelperTextTextAppearance_IHandler")]
	public unsafe virtual void SetHelperTextTextAppearance(int helperTextTextAppearance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(helperTextTextAppearance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHelperTextTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetHint_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHint_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHint_I(nint jnienv, nint native__this, int textHintId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHint(textHintId);
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

	[Register("setHint", "(I)V", "GetSetHint_IHandler")]
	public unsafe virtual void SetHint(int textHintId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(textHintId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHint.(I)V", this, ptr);
	}

	private static Delegate GetSetHintTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHintTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHintTextAppearance_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHintTextAppearance(resId);
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

	[Register("setHintTextAppearance", "(I)V", "GetSetHintTextAppearance_IHandler")]
	public unsafe virtual void SetHintTextAppearance(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHintTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetMaxWidthResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxWidthResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxWidthResource_I(nint jnienv, nint native__this, int maxWidthId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxWidthResource(maxWidthId);
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

	[Register("setMaxWidthResource", "(I)V", "GetSetMaxWidthResource_IHandler")]
	public unsafe virtual void SetMaxWidthResource(int maxWidthId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(maxWidthId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxWidthResource.(I)V", this, ptr);
	}

	private static Delegate GetSetMinWidthResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMinWidthResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinWidthResource_I(nint jnienv, nint native__this, int minWidthId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMinWidthResource(minWidthId);
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

	[Register("setMinWidthResource", "(I)V", "GetSetMinWidthResource_IHandler")]
	public unsafe virtual void SetMinWidthResource(int minWidthId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(minWidthId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMinWidthResource.(I)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetPasswordVisibilityToggleContentDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPasswordVisibilityToggleContentDescription_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPasswordVisibilityToggleContentDescription_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPasswordVisibilityToggleContentDescription(resId);
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

	[Obsolete("deprecated")]
	[Register("setPasswordVisibilityToggleContentDescription", "(I)V", "GetSetPasswordVisibilityToggleContentDescription_IHandler")]
	public unsafe virtual void SetPasswordVisibilityToggleContentDescription(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleContentDescription.(I)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetPasswordVisibilityToggleDrawable_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPasswordVisibilityToggleDrawable_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPasswordVisibilityToggleDrawable_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPasswordVisibilityToggleDrawable(resId);
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

	[Obsolete("deprecated")]
	[Register("setPasswordVisibilityToggleDrawable", "(I)V", "GetSetPasswordVisibilityToggleDrawable_IHandler")]
	public unsafe virtual void SetPasswordVisibilityToggleDrawable(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleDrawable.(I)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tintList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList passwordVisibilityToggleTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tintList, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetPasswordVisibilityToggleTintList(passwordVisibilityToggleTintList);
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

	[Obsolete("deprecated")]
	[Register("setPasswordVisibilityToggleTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetPasswordVisibilityToggleTintList(ColorStateList? tintList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tintList?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tintList);
		}
	}

	[Obsolete]
	private static Delegate GetSetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode passwordVisibilityToggleTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_mode, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetPasswordVisibilityToggleTintMode(passwordVisibilityToggleTintMode);
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

	[Obsolete("deprecated")]
	[Register("setPasswordVisibilityToggleTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
	public unsafe virtual void SetPasswordVisibilityToggleTintMode(PorterDuff.Mode? mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mode);
		}
	}

	private static Delegate GetSetPrefixTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPrefixTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPrefixTextAppearance_I(nint jnienv, nint native__this, int prefixTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPrefixTextAppearance(prefixTextAppearance);
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

	[Register("setPrefixTextAppearance", "(I)V", "GetSetPrefixTextAppearance_IHandler")]
	public unsafe virtual void SetPrefixTextAppearance(int prefixTextAppearance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(prefixTextAppearance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPrefixTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetStartIconContentDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStartIconContentDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconContentDescription_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStartIconContentDescription(resId);
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

	[Register("setStartIconContentDescription", "(I)V", "GetSetStartIconContentDescription_IHandler")]
	public unsafe virtual void SetStartIconContentDescription(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconContentDescription.(I)V", this, ptr);
	}

	private static Delegate GetSetStartIconDrawable_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStartIconDrawable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconDrawable_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStartIconDrawable(resId);
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

	[Register("setStartIconDrawable", "(I)V", "GetSetStartIconDrawable_IHandler")]
	public unsafe virtual void SetStartIconDrawable(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconDrawable.(I)V", this, ptr);
	}

	private static Delegate GetSetStartIconOnClickListener_Landroid_view_View_OnClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStartIconOnClickListener_Landroid_view_View_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconOnClickListener_Landroid_view_View_OnClickListener_(nint jnienv, nint native__this, nint native_startIconOnClickListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnClickListener startIconOnClickListener = Java.Lang.Object.GetObject<IOnClickListener>(native_startIconOnClickListener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetStartIconOnClickListener(startIconOnClickListener);
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

	[Register("setStartIconOnClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetStartIconOnClickListener_Landroid_view_View_OnClickListener_Handler")]
	public unsafe virtual void SetStartIconOnClickListener(IOnClickListener? startIconOnClickListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((startIconOnClickListener == null) ? IntPtr.Zero : ((Java.Lang.Object)startIconOnClickListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconOnClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(startIconOnClickListener);
		}
	}

	private static Delegate GetSetStartIconOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStartIconOnLongClickListener_Landroid_view_View_OnLongClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconOnLongClickListener_Landroid_view_View_OnLongClickListener_(nint jnienv, nint native__this, nint native_startIconOnLongClickListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLongClickListener startIconOnLongClickListener = Java.Lang.Object.GetObject<IOnLongClickListener>(native_startIconOnLongClickListener, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetStartIconOnLongClickListener(startIconOnLongClickListener);
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

	[Register("setStartIconOnLongClickListener", "(Landroid/view/View$OnLongClickListener;)V", "GetSetStartIconOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler")]
	public unsafe virtual void SetStartIconOnLongClickListener(IOnLongClickListener? startIconOnLongClickListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((startIconOnLongClickListener == null) ? IntPtr.Zero : ((Java.Lang.Object)startIconOnLongClickListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconOnLongClickListener.(Landroid/view/View$OnLongClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(startIconOnLongClickListener);
		}
	}

	private static Delegate GetSetStartIconTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStartIconTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_startIconTintList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList startIconTintList = Java.Lang.Object.GetObject<ColorStateList>(native_startIconTintList, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetStartIconTintList(startIconTintList);
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

	[Register("setStartIconTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetStartIconTintList_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetStartIconTintList(ColorStateList? startIconTintList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(startIconTintList?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(startIconTintList);
		}
	}

	private static Delegate GetSetStartIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStartIconTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartIconTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_startIconTintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode startIconTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_startIconTintMode, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetStartIconTintMode(startIconTintMode);
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

	[Register("setStartIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetStartIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
	public unsafe virtual void SetStartIconTintMode(PorterDuff.Mode? startIconTintMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(startIconTintMode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartIconTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(startIconTintMode);
		}
	}

	private static Delegate GetSetSuffixTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSuffixTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSuffixTextAppearance_I(nint jnienv, nint native__this, int suffixTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSuffixTextAppearance(suffixTextAppearance);
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

	[Register("setSuffixTextAppearance", "(I)V", "GetSetSuffixTextAppearance_IHandler")]
	public unsafe virtual void SetSuffixTextAppearance(int suffixTextAppearance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(suffixTextAppearance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSuffixTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_(nint jnienv, nint native__this, nint native__delegate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputLayout? textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityDelegate textInputAccessibilityDelegate = Java.Lang.Object.GetObject<AccessibilityDelegate>(native__delegate, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetTextInputAccessibilityDelegate(textInputAccessibilityDelegate);
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

	[Register("setTextInputAccessibilityDelegate", "(Lcom/google/android/material/textfield/TextInputLayout$AccessibilityDelegate;)V", "GetSetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_Handler")]
	public unsafe virtual void SetTextInputAccessibilityDelegate(AccessibilityDelegate? @delegate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(@delegate?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextInputAccessibilityDelegate.(Lcom/google/android/material/textfield/TextInputLayout$AccessibilityDelegate;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@delegate);
		}
	}

	private IOnEditTextAttachedListenerImplementor __CreateIOnEditTextAttachedListenerImplementor()
	{
		return new IOnEditTextAttachedListenerImplementor(this);
	}

	private IOnEndIconChangedListenerImplementor __CreateIOnEndIconChangedListenerImplementor()
	{
		return new IOnEndIconChangedListenerImplementor(this);
	}
}
