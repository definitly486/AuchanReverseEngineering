using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.Widget;

[Register("androidx/appcompat/widget/SwitchCompat", DoNotGenerateAcw = true)]
public class SwitchCompat : CompoundButton, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/widget/SwitchCompat", typeof(SwitchCompat));

	private static Delegate? cb_isEmojiCompatEnabled_IsEmojiCompatEnabled_Z;

	private static Delegate? cb_setEmojiCompatEnabled_SetEmojiCompatEnabled_Z_V;

	private static Delegate? cb_getShowText_GetShowText_Z;

	private static Delegate? cb_setShowText_SetShowText_Z_V;

	private static Delegate? cb_getSplitTrack_GetSplitTrack_Z;

	private static Delegate? cb_setSplitTrack_SetSplitTrack_Z_V;

	private static Delegate? cb_getSwitchMinWidth_GetSwitchMinWidth_I;

	private static Delegate? cb_setSwitchMinWidth_SetSwitchMinWidth_I_V;

	private static Delegate? cb_getSwitchPadding_GetSwitchPadding_I;

	private static Delegate? cb_setSwitchPadding_SetSwitchPadding_I_V;

	private static Delegate? cb_getTextOff_GetTextOff_Ljava_lang_CharSequence_;

	private static Delegate? cb_setTextOff_SetTextOff_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getTextOn_GetTextOn_Ljava_lang_CharSequence_;

	private static Delegate? cb_setTextOn_SetTextOn_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getThumbDrawable_GetThumbDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setThumbDrawable_SetThumbDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getThumbTextPadding_GetThumbTextPadding_I;

	private static Delegate? cb_setThumbTextPadding_SetThumbTextPadding_I_V;

	private static Delegate? cb_getThumbTintList_GetThumbTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setThumbTintList_SetThumbTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getThumbTintMode_GetThumbTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setThumbTintMode_SetThumbTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_getTrackDrawable_GetTrackDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setTrackDrawable_SetTrackDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getTrackTintList_GetTrackTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTrackTintList_SetTrackTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getTrackTintMode_GetTrackTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setTrackTintMode_SetTrackTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_onMeasure_OnMeasure_II_V;

	private static Delegate? cb_setSwitchTextAppearance_SetSwitchTextAppearance_Landroid_content_Context_I_V;

	private static Delegate? cb_setSwitchTypeface_SetSwitchTypeface_Landroid_graphics_Typeface__V;

	private static Delegate? cb_setSwitchTypeface_SetSwitchTypeface_Landroid_graphics_Typeface_I_V;

	private static Delegate? cb_setThumbResource_SetThumbResource_I_V;

	private static Delegate? cb_setTrackResource_SetTrackResource_I_V;

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

	public unsafe virtual bool ShowText
	{
		[Register("getShowText", "()Z", "GetGetShowTextHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getShowText.()Z", this, null);
		}
		[Register("setShowText", "(Z)V", "GetSetShowText_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShowText.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool SplitTrack
	{
		[Register("getSplitTrack", "()Z", "GetGetSplitTrackHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getSplitTrack.()Z", this, null);
		}
		[Register("setSplitTrack", "(Z)V", "GetSetSplitTrack_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSplitTrack.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int SwitchMinWidth
	{
		[Register("getSwitchMinWidth", "()I", "GetGetSwitchMinWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSwitchMinWidth.()I", this, null);
		}
		[Register("setSwitchMinWidth", "(I)V", "GetSetSwitchMinWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSwitchMinWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int SwitchPadding
	{
		[Register("getSwitchPadding", "()I", "GetGetSwitchPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSwitchPadding.()I", this, null);
		}
		[Register("setSwitchPadding", "(I)V", "GetSetSwitchPadding_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSwitchPadding.(I)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? TextOffFormatted
	{
		[Register("getTextOff", "()Ljava/lang/CharSequence;", "GetGetTextOffHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTextOff.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTextOff", "(Ljava/lang/CharSequence;)V", "GetSetTextOff_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTextOff.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? TextOff
	{
		get
		{
			if (TextOffFormatted != null)
			{
				return TextOffFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(TextOffFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual ICharSequence? TextOnFormatted
	{
		[Register("getTextOn", "()Ljava/lang/CharSequence;", "GetGetTextOnHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTextOn.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTextOn", "(Ljava/lang/CharSequence;)V", "GetSetTextOn_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTextOn.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? TextOn
	{
		get
		{
			if (TextOnFormatted != null)
			{
				return TextOnFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(TextOnFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual Drawable? ThumbDrawable
	{
		[Register("getThumbDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetThumbDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getThumbDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setThumbDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetThumbDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected unsafe float ThumbPosition
	{
		[Register("getThumbPosition", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getThumbPosition.()F", this, null);
		}
	}

	public unsafe virtual int ThumbTextPadding
	{
		[Register("getThumbTextPadding", "()I", "GetGetThumbTextPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getThumbTextPadding.()I", this, null);
		}
		[Register("setThumbTextPadding", "(I)V", "GetSetThumbTextPadding_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbTextPadding.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? ThumbTintList
	{
		[Register("getThumbTintList", "()Landroid/content/res/ColorStateList;", "GetGetThumbTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getThumbTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setThumbTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetThumbTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? ThumbTintMode
	{
		[Register("getThumbTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetThumbTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getThumbTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setThumbTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetThumbTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual Drawable? TrackDrawable
	{
		[Register("getTrackDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetTrackDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTrackDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTrackDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetTrackDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? TrackTintList
	{
		[Register("getTrackTintList", "()Landroid/content/res/ColorStateList;", "GetGetTrackTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTrackTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTrackTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetTrackTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? TrackTintMode
	{
		[Register("getTrackTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetTrackTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTrackTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTrackTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetTrackTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected SwitchCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe SwitchCompat(Context context)
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
	public unsafe SwitchCompat(Context context, IAttributeSet? attrs)
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
	public unsafe SwitchCompat(Context context, IAttributeSet? attrs, int defStyleAttr)
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
			return Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EmojiCompatEnabled ? ((sbyte)1) : ((sbyte)0);
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
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool emojiCompatEnabled = native_enabled != 0;
			switchCompat.EmojiCompatEnabled = emojiCompatEnabled;
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

	private static Delegate GetGetShowTextHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetShowText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetShowText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowText ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetShowText_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShowText_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShowText_Z(nint jnienv, nint native__this, sbyte native_showText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool showText = native_showText != 0;
			switchCompat.ShowText = showText;
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

	private static Delegate GetGetSplitTrackHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetSplitTrack);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetSplitTrack(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SplitTrack ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetSplitTrack_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSplitTrack_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSplitTrack_Z(nint jnienv, nint native__this, sbyte native_splitTrack)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool splitTrack = native_splitTrack != 0;
			switchCompat.SplitTrack = splitTrack;
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

	private static Delegate GetGetSwitchMinWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSwitchMinWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSwitchMinWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SwitchMinWidth;
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

	private static Delegate GetSetSwitchMinWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSwitchMinWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSwitchMinWidth_I(nint jnienv, nint native__this, int pixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SwitchMinWidth = pixels;
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

	private static Delegate GetGetSwitchPaddingHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSwitchPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSwitchPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SwitchPadding;
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

	private static Delegate GetSetSwitchPadding_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSwitchPadding_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSwitchPadding_I(nint jnienv, nint native__this, int pixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SwitchPadding = pixels;
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

	private static Delegate GetGetTextOffHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTextOff);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTextOff(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextOffFormatted);
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

	private static Delegate GetSetTextOff_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTextOff_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextOff_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_textOff)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence textOffFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_textOff, JniHandleOwnership.DoNotTransfer);
			switchCompat.TextOffFormatted = textOffFormatted;
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

	private static Delegate GetGetTextOnHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTextOn);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTextOn(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextOnFormatted);
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

	private static Delegate GetSetTextOn_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTextOn_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextOn_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_textOn)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence textOnFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_textOn, JniHandleOwnership.DoNotTransfer);
			switchCompat.TextOnFormatted = textOnFormatted;
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

	private static Delegate GetGetThumbDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetThumbDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetThumbDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbDrawable);
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

	private static Delegate GetSetThumbDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetThumbDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_thumb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable thumbDrawable = Java.Lang.Object.GetObject<Drawable>(native_thumb, JniHandleOwnership.DoNotTransfer);
			switchCompat.ThumbDrawable = thumbDrawable;
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

	private static Delegate GetGetThumbTextPaddingHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetThumbTextPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetThumbTextPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbTextPadding;
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

	private static Delegate GetSetThumbTextPadding_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbTextPadding_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbTextPadding_I(nint jnienv, nint native__this, int pixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbTextPadding = pixels;
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

	private static Delegate GetGetThumbTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetThumbTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetThumbTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbTintList);
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

	private static Delegate GetSetThumbTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetThumbTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList thumbTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			switchCompat.ThumbTintList = thumbTintList;
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

	private static Delegate GetGetThumbTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetThumbTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetThumbTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbTintMode);
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

	private static Delegate GetSetThumbTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetThumbTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode thumbTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			switchCompat.ThumbTintMode = thumbTintMode;
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

	private static Delegate GetGetTrackDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTrackDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTrackDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackDrawable);
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

	private static Delegate GetSetTrackDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTrackDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_track)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable trackDrawable = Java.Lang.Object.GetObject<Drawable>(native_track, JniHandleOwnership.DoNotTransfer);
			switchCompat.TrackDrawable = trackDrawable;
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

	private static Delegate GetGetTrackTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTrackTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTrackTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackTintList);
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

	private static Delegate GetSetTrackTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTrackTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList trackTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			switchCompat.TrackTintList = trackTintList;
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

	private static Delegate GetGetTrackTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTrackTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTrackTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackTintMode);
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

	private static Delegate GetSetTrackTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTrackTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode trackTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			switchCompat.TrackTintMode = trackTintMode;
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

	private static Delegate GetOnMeasure_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_OnMeasure_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnMeasure_II(nint jnienv, nint native__this, int widthMeasureSpec, int heightMeasureSpec)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMeasure(widthMeasureSpec, heightMeasureSpec);
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

	[Register("onMeasure", "(II)V", "GetOnMeasure_IIHandler")]
	public new unsafe virtual void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(widthMeasureSpec);
		ptr[1] = new JniArgumentValue(heightMeasureSpec);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onMeasure.(II)V", this, ptr);
	}

	[Register("setEnforceSwitchWidth", "(Z)V", "")]
	protected unsafe void SetEnforceSwitchWidth(bool enforceSwitchWidth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enforceSwitchWidth ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("setEnforceSwitchWidth.(Z)V", this, ptr);
	}

	private static Delegate GetSetSwitchTextAppearance_Landroid_content_Context_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetSwitchTextAppearance_Landroid_content_Context_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSwitchTextAppearance_Landroid_content_Context_I(nint jnienv, nint native__this, nint native_context, int resid)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			switchCompat.SetSwitchTextAppearance(context, resid);
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

	[Register("setSwitchTextAppearance", "(Landroid/content/Context;I)V", "GetSetSwitchTextAppearance_Landroid_content_Context_IHandler")]
	public unsafe virtual void SetSwitchTextAppearance(Context? context, int resid)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resid);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSwitchTextAppearance.(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetSetSwitchTypeface_Landroid_graphics_Typeface_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSwitchTypeface_Landroid_graphics_Typeface_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSwitchTypeface_Landroid_graphics_Typeface_(nint jnienv, nint native__this, nint native_typeface)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Typeface switchTypeface = Java.Lang.Object.GetObject<Typeface>(native_typeface, JniHandleOwnership.DoNotTransfer);
			switchCompat.SetSwitchTypeface(switchTypeface);
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

	[Register("setSwitchTypeface", "(Landroid/graphics/Typeface;)V", "GetSetSwitchTypeface_Landroid_graphics_Typeface_Handler")]
	public unsafe virtual void SetSwitchTypeface(Typeface? typeface)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(typeface?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSwitchTypeface.(Landroid/graphics/Typeface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(typeface);
		}
	}

	private static Delegate GetSetSwitchTypeface_Landroid_graphics_Typeface_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetSwitchTypeface_Landroid_graphics_Typeface_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSwitchTypeface_Landroid_graphics_Typeface_I(nint jnienv, nint native__this, nint native_tf, int style)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwitchCompat? switchCompat = Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Typeface tf = Java.Lang.Object.GetObject<Typeface>(native_tf, JniHandleOwnership.DoNotTransfer);
			switchCompat.SetSwitchTypeface(tf, style);
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

	[Register("setSwitchTypeface", "(Landroid/graphics/Typeface;I)V", "GetSetSwitchTypeface_Landroid_graphics_Typeface_IHandler")]
	public unsafe virtual void SetSwitchTypeface(Typeface? tf, int style)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(tf?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(style);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSwitchTypeface.(Landroid/graphics/Typeface;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tf);
		}
	}

	private static Delegate GetSetThumbResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbResource_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThumbResource(resId);
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

	[Register("setThumbResource", "(I)V", "GetSetThumbResource_IHandler")]
	public unsafe virtual void SetThumbResource(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbResource.(I)V", this, ptr);
	}

	private static Delegate GetSetTrackResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTrackResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackResource_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwitchCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTrackResource(resId);
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

	[Register("setTrackResource", "(I)V", "GetSetTrackResource_IHandler")]
	public unsafe virtual void SetTrackResource(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackResource.(I)V", this, ptr);
	}
}
