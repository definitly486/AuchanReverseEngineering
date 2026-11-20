using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/TextView", DoNotGenerateAcw = true)]
public class TextView : View, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/widget/TextView$BufferType", DoNotGenerateAcw = true)]
	public sealed class BufferType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/TextView$BufferType", typeof(BufferType));

		[Register("EDITABLE")]
		public static BufferType? Editable => Java.Lang.Object.GetObject<BufferType>(_members.StaticFields.GetObjectValue("EDITABLE.Landroid/widget/TextView$BufferType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NORMAL")]
		public static BufferType? Normal => Java.Lang.Object.GetObject<BufferType>(_members.StaticFields.GetObjectValue("NORMAL.Landroid/widget/TextView$BufferType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SPANNABLE")]
		public static BufferType? Spannable => Java.Lang.Object.GetObject<BufferType>(_members.StaticFields.GetObjectValue("SPANNABLE.Landroid/widget/TextView$BufferType;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BufferType(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/widget/TextView$OnEditorActionListener", "", "Android.Widget.TextView/IOnEditorActionListenerInvoker")]
	public interface IOnEditorActionListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onEditorAction", "(Landroid/widget/TextView;ILandroid/view/KeyEvent;)Z", "GetOnEditorAction_Landroid_widget_TextView_ILandroid_view_KeyEvent_Handler:Android.Widget.TextView/IOnEditorActionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnEditorAction(TextView? v, ImeAction actionId, KeyEvent? e);
	}

	[Register("android/widget/TextView$OnEditorActionListener", DoNotGenerateAcw = true)]
	internal class IOnEditorActionListenerInvoker : Java.Lang.Object, IOnEditorActionListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_TextView_OnEditorActionListener = new XAPeerMembers("android/widget/TextView$OnEditorActionListener", typeof(IOnEditorActionListenerInvoker));

		private static Delegate? cb_onEditorAction_OnEditorAction_Landroid_widget_TextView_ILandroid_view_KeyEvent__Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_TextView_OnEditorActionListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_TextView_OnEditorActionListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_TextView_OnEditorActionListener.ManagedPeerType;

		public IOnEditorActionListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnEditorAction_Landroid_widget_TextView_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_v, int native_actionId, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnEditorActionListener? onEditorActionListener = Java.Lang.Object.GetObject<IOnEditorActionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				TextView v = Java.Lang.Object.GetObject<TextView>(native_v, JniHandleOwnership.DoNotTransfer);
				KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onEditorActionListener.OnEditorAction(v, (ImeAction)native_actionId, e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnEditorAction(TextView? v, ImeAction actionId, KeyEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)actionId);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_widget_TextView_OnEditorActionListener.InstanceMethods.InvokeAbstractBooleanMethod("onEditorAction.(Landroid/widget/TextView;ILandroid/view/KeyEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
				GC.KeepAlive(e);
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
		private static sbyte n_OnEditorAction_Landroid_widget_TextView_ILandroid_view_KeyEvent__mm_wrapper(nint jnienv, nint native__this, nint native_v, int native_actionId, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnEditorAction_Landroid_widget_TextView_ILandroid_view_KeyEvent_(jnienv, native__this, native_v, native_actionId, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	public class EditorActionEventArgs : EventArgs
	{
		private bool handled;

		private ImeAction actionId;

		private KeyEvent? e;

		public bool Handled => handled;

		public ImeAction ActionId => actionId;

		public EditorActionEventArgs(bool handled, ImeAction actionId, KeyEvent? e)
		{
			this.handled = handled;
			this.actionId = actionId;
			this.e = e;
		}
	}

	[Register("mono/android/widget/TextView_OnEditorActionListenerImplementor")]
	internal sealed class IOnEditorActionListenerImplementor : Java.Lang.Object, IOnEditorActionListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<EditorActionEventArgs>? Handler;

		public unsafe IOnEditorActionListenerImplementor()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		public bool OnEditorAction(TextView? v, ImeAction actionId, KeyEvent? e)
		{
			EventHandler<EditorActionEventArgs> handler = Handler;
			if (handler == null)
			{
				return false;
			}
			EditorActionEventArgs e2 = new EditorActionEventArgs(handled: true, actionId, e);
			handler(v, e2);
			return e2.Handled;
		}

		internal static bool __IsEmpty(IOnEditorActionListenerImplementor value)
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

	private static nint id_addTextChangedListener;

	private WeakReference? implementor_TextWatcher;

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/TextView", typeof(TextView));

	private static Delegate? cb_getCompoundPaddingLeft_GetCompoundPaddingLeft_I;

	private static Delegate? cb_getCompoundPaddingRight_GetCompoundPaddingRight_I;

	private static Delegate? cb_setEllipsize_SetEllipsize_Landroid_text_TextUtils_TruncateAt__V;

	private static Delegate? cb_setGravity_SetGravity_I_V;

	private static Delegate? cb_setImeOptions_SetImeOptions_I_V;

	private static Delegate? cb_getInputType_GetInputType_I;

	private static Delegate? cb_setInputType_SetInputType_I_V;

	private static Delegate? cb_setLetterSpacing_SetLetterSpacing_F_V;

	private static Delegate? cb_getLineCount_GetLineCount_I;

	private static Delegate? cb_getMaxLines_GetMaxLines_I;

	private static Delegate? cb_getPaint_GetPaint_Landroid_text_TextPaint_;

	private static Delegate? cb_getPaintFlags_GetPaintFlags_I;

	private static Delegate? cb_setPaintFlags_SetPaintFlags_I_V;

	private static Delegate? cb_setTextSelectHandle_SetTextSelectHandle_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setTextSelectHandleLeft_SetTextSelectHandleLeft_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setTextSelectHandleRight_SetTextSelectHandleRight_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getTextSize_GetTextSize_F;

	private static Delegate? cb_getTotalPaddingLeft_GetTotalPaddingLeft_I;

	private static Delegate? cb_getTotalPaddingTop_GetTotalPaddingTop_I;

	private static Delegate? cb_getTypeface_GetTypeface_Landroid_graphics_Typeface_;

	private static Delegate? cb_addTextChangedListener_AddTextChangedListener_Landroid_text_TextWatcher__V;

	private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroid_os_Parcelable__V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

	private static Delegate? cb_setAllCaps_SetAllCaps_Z_V;

	private static Delegate? cb_setCompoundDrawablesWithIntrinsicBounds_SetCompoundDrawablesWithIntrinsicBounds_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setCompoundDrawablesWithIntrinsicBounds_SetCompoundDrawablesWithIntrinsicBounds_IIII_V;

	private static Delegate? cb_setFilters_SetFilters_arrayLandroid_text_InputFilter__V;

	private static Delegate? cb_setHeight_SetHeight_I_V;

	private static Delegate? cb_setHighlightColor_SetHighlightColor_I_V;

	private static Delegate? cb_setIncludeFontPadding_SetIncludeFontPadding_Z_V;

	private static Delegate? cb_setMaxLines_SetMaxLines_I_V;

	private static Delegate? cb_setOnEditorActionListener_SetOnEditorActionListener_Landroid_widget_TextView_OnEditorActionListener__V;

	private static Delegate? cb_setRawInputType_SetRawInputType_I_V;

	private static Delegate? cb_setSingleLine_SetSingleLine_V;

	private static Delegate? cb_setSingleLine_SetSingleLine_Z_V;

	private static Delegate? cb_setText_SetText_Ljava_lang_CharSequence_Landroid_widget_TextView_BufferType__V;

	private static Delegate? cb_setTextAppearance_SetTextAppearance_I_V;

	private static Delegate? cb_setTextColor_SetTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setTextColor_SetTextColor_I_V;

	private static Delegate? cb_setTextIsSelectable_SetTextIsSelectable_Z_V;

	private static Delegate? cb_setTextSize_SetTextSize_IF_V;

	private static Delegate? cb_setTypeface_SetTypeface_Landroid_graphics_Typeface_I_V;

	private static Delegate? cb_setWidth_SetWidth_I_V;

	private WeakReference? weak_implementor_SetOnEditorActionListener;

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

	public unsafe virtual int CompoundPaddingLeft => _members.InstanceMethods.InvokeVirtualInt32Method("getCompoundPaddingLeft.()I", this, null);

	public unsafe virtual int CompoundPaddingRight => _members.InstanceMethods.InvokeVirtualInt32Method("getCompoundPaddingRight.()I", this, null);

	public unsafe int CurrentTextColor => _members.InstanceMethods.InvokeNonvirtualInt32Method("getCurrentTextColor.()I", this, null);

	public unsafe virtual TextUtils.TruncateAt? Ellipsize
	{
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEllipsize.(Landroid/text/TextUtils$TruncateAt;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual GravityFlags Gravity
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGravity.(I)V", this, ptr);
		}
	}

	public unsafe ICharSequence? HintFormatted => Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHint.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Hint
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
			JniObjectReference reference = JniEnvironment.Strings.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reference);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setHint.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference);
			}
		}
	}

	public unsafe virtual ImeAction ImeOptions
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImeOptions.(I)V", this, ptr);
		}
	}

	public unsafe virtual InputTypes InputType
	{
		get
		{
			return (InputTypes)_members.InstanceMethods.InvokeVirtualInt32Method("getInputType.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInputType.(I)V", this, ptr);
		}
	}

	public unsafe IKeyListener? KeyListener
	{
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyListener.(Landroid/text/method/KeyListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public new unsafe Layout? Layout => Java.Lang.Object.GetObject<Layout>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLayout.()Landroid/text/Layout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual float LetterSpacing
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLetterSpacing.(F)V", this, ptr);
		}
	}

	public unsafe virtual int LineCount => _members.InstanceMethods.InvokeVirtualInt32Method("getLineCount.()I", this, null);

	public unsafe virtual int MaxLines => _members.InstanceMethods.InvokeVirtualInt32Method("getMaxLines.()I", this, null);

	public unsafe IMovementMethod? MovementMethod
	{
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMovementMethod.(Landroid/text/method/MovementMethod;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual TextPaint? Paint => Java.Lang.Object.GetObject<TextPaint>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPaint.()Landroid/text/TextPaint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual PaintFlags PaintFlags
	{
		get
		{
			return (PaintFlags)_members.InstanceMethods.InvokeVirtualInt32Method("getPaintFlags.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPaintFlags.(I)V", this, ptr);
		}
	}

	public unsafe bool ShowSoftInputOnFocus
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setShowSoftInputOnFocus.(Z)V", this, ptr);
		}
	}

	public unsafe ICharSequence? TextFormatted
	{
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe string? Text
	{
		get
		{
			if (TextFormatted != null)
			{
				return TextFormatted.ToString();
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
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference);
			}
		}
	}

	public unsafe ColorStateList? TextColors => Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTextColors.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android29.0")]
	public unsafe virtual Drawable? TextSelectHandle
	{
		[SupportedOSPlatform("android29.0")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTextSelectHandle.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[SupportedOSPlatform("android29.0")]
	public unsafe virtual Drawable? TextSelectHandleLeft
	{
		[SupportedOSPlatform("android29.0")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTextSelectHandleLeft.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[SupportedOSPlatform("android29.0")]
	public unsafe virtual Drawable? TextSelectHandleRight
	{
		[SupportedOSPlatform("android29.0")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTextSelectHandleRight.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual float TextSize => _members.InstanceMethods.InvokeVirtualSingleMethod("getTextSize.()F", this, null);

	public unsafe virtual int TotalPaddingLeft => _members.InstanceMethods.InvokeVirtualInt32Method("getTotalPaddingLeft.()I", this, null);

	public unsafe virtual int TotalPaddingTop => _members.InstanceMethods.InvokeVirtualInt32Method("getTotalPaddingTop.()I", this, null);

	public unsafe virtual Typeface? Typeface => Java.Lang.Object.GetObject<Typeface>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTypeface.()Landroid/graphics/Typeface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public event EventHandler<AfterTextChangedEventArgs> AfterTextChanged
	{
		add
		{
			if (implementor_TextWatcher == null || !implementor_TextWatcher.IsAlive)
			{
				implementor_TextWatcher = new WeakReference(new TextWatcherImplementor(this, null, null, value));
				AddTextChangedListener((TextWatcherImplementor)implementor_TextWatcher.Target);
			}
			else
			{
				TextWatcherImplementor obj = (TextWatcherImplementor)implementor_TextWatcher.Target;
				obj.AfterTextChanged = (EventHandler<AfterTextChangedEventArgs>)Delegate.Combine(obj.AfterTextChanged, value);
			}
		}
		remove
		{
			TextWatcherImplementor textWatcherImplementor = ((implementor_TextWatcher != null) ? ((TextWatcherImplementor)implementor_TextWatcher.Target) : null);
			if (textWatcherImplementor != null)
			{
				textWatcherImplementor.AfterTextChanged = (EventHandler<AfterTextChangedEventArgs>)Delegate.Remove(textWatcherImplementor.AfterTextChanged, value);
			}
		}
	}

	public event EventHandler<TextChangedEventArgs> TextChanged
	{
		add
		{
			if (implementor_TextWatcher == null || !implementor_TextWatcher.IsAlive)
			{
				implementor_TextWatcher = new WeakReference(new TextWatcherImplementor(this, value, null, null));
				AddTextChangedListener((TextWatcherImplementor)implementor_TextWatcher.Target);
			}
			else
			{
				TextWatcherImplementor obj = (TextWatcherImplementor)implementor_TextWatcher.Target;
				obj.TextChanged = (EventHandler<TextChangedEventArgs>)Delegate.Combine(obj.TextChanged, value);
			}
		}
		remove
		{
			TextWatcherImplementor textWatcherImplementor = ((implementor_TextWatcher != null) ? ((TextWatcherImplementor)implementor_TextWatcher.Target) : null);
			if (textWatcherImplementor != null)
			{
				textWatcherImplementor.TextChanged = (EventHandler<TextChangedEventArgs>)Delegate.Remove(textWatcherImplementor.TextChanged, value);
			}
		}
	}

	public event EventHandler<EditorActionEventArgs> EditorAction
	{
		add
		{
			EventHelper.AddEventHandler<IOnEditorActionListener, IOnEditorActionListenerImplementor>(ref weak_implementor_SetOnEditorActionListener, __CreateIOnEditorActionListenerImplementor, SetOnEditorActionListener, delegate(IOnEditorActionListenerImplementor __h)
			{
				__h.Handler = (EventHandler<EditorActionEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnEditorActionListener, IOnEditorActionListenerImplementor>(ref weak_implementor_SetOnEditorActionListener, IOnEditorActionListenerImplementor.__IsEmpty, delegate
			{
				SetOnEditorActionListener(null);
			}, delegate(IOnEditorActionListenerImplementor __h)
			{
				__h.Handler = (EventHandler<EditorActionEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	private void AddTextChangedListener(TextWatcherImplementor watcher)
	{
		if (id_addTextChangedListener == IntPtr.Zero)
		{
			id_addTextChangedListener = JNIEnv.GetMethodID(class_ref, "addTextChangedListener", "(Landroid/text/TextWatcher;)V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_addTextChangedListener, new JValue(watcher));
	}

	protected TextView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe TextView(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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

	public unsafe TextView(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	public unsafe TextView(Context? context, IAttributeSet? attrs)
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

	public unsafe TextView(Context? context)
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

	private static Delegate GetGetCompoundPaddingLeftHandler()
	{
		return new _JniMarshal_PP_I(n_GetCompoundPaddingLeft);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCompoundPaddingLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompoundPaddingLeft;
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

	private static Delegate GetGetCompoundPaddingRightHandler()
	{
		return new _JniMarshal_PP_I(n_GetCompoundPaddingRight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCompoundPaddingRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompoundPaddingRight;
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

	private static Delegate GetSetEllipsize_Landroid_text_TextUtils_TruncateAt_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetEllipsize_Landroid_text_TextUtils_TruncateAt_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEllipsize_Landroid_text_TextUtils_TruncateAt_(nint jnienv, nint native__this, nint native__where)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextUtils.TruncateAt ellipsize = Java.Lang.Object.GetObject<TextUtils.TruncateAt>(native__where, JniHandleOwnership.DoNotTransfer);
			textView.Ellipsize = ellipsize;
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

	private static Delegate GetSetGravity_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGravity_I(nint jnienv, nint native__this, int native_gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Gravity = (GravityFlags)native_gravity;
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

	private static Delegate GetSetImeOptions_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetImeOptions_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetImeOptions_I(nint jnienv, nint native__this, int native_imeOptions)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImeOptions = (ImeAction)native_imeOptions;
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

	private static Delegate GetGetInputTypeHandler()
	{
		return new _JniMarshal_PP_I(n_GetInputType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInputType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType;
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

	private static Delegate GetSetInputType_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetInputType_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInputType_I(nint jnienv, nint native__this, int native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType = (InputTypes)native_type;
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

	private static Delegate GetSetLetterSpacing_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetLetterSpacing_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLetterSpacing_F(nint jnienv, nint native__this, float letterSpacing)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LetterSpacing = letterSpacing;
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

	private static Delegate GetGetLineCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetLineCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLineCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineCount;
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

	private static Delegate GetGetMaxLinesHandler()
	{
		return new _JniMarshal_PP_I(n_GetMaxLines);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxLines(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxLines;
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

	private static Delegate GetGetPaintHandler()
	{
		return new _JniMarshal_PP_L(n_GetPaint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPaint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Paint);
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

	private static Delegate GetGetPaintFlagsHandler()
	{
		return new _JniMarshal_PP_I(n_GetPaintFlags);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPaintFlags(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaintFlags;
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

	private static Delegate GetSetPaintFlags_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetPaintFlags_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPaintFlags_I(nint jnienv, nint native__this, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaintFlags = (PaintFlags)native_flags;
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

	[SupportedOSPlatform("android29.0")]
	private static Delegate GetSetTextSelectHandle_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetTextSelectHandle_Landroid_graphics_drawable_Drawable_);
	}

	[SupportedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextSelectHandle_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_textSelectHandle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable textSelectHandle = Java.Lang.Object.GetObject<Drawable>(native_textSelectHandle, JniHandleOwnership.DoNotTransfer);
			textView.TextSelectHandle = textSelectHandle;
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

	[SupportedOSPlatform("android29.0")]
	private static Delegate GetSetTextSelectHandleLeft_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetTextSelectHandleLeft_Landroid_graphics_drawable_Drawable_);
	}

	[SupportedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextSelectHandleLeft_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_textSelectHandleLeft)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable textSelectHandleLeft = Java.Lang.Object.GetObject<Drawable>(native_textSelectHandleLeft, JniHandleOwnership.DoNotTransfer);
			textView.TextSelectHandleLeft = textSelectHandleLeft;
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

	[SupportedOSPlatform("android29.0")]
	private static Delegate GetSetTextSelectHandleRight_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetTextSelectHandleRight_Landroid_graphics_drawable_Drawable_);
	}

	[SupportedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextSelectHandleRight_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_textSelectHandleRight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable textSelectHandleRight = Java.Lang.Object.GetObject<Drawable>(native_textSelectHandleRight, JniHandleOwnership.DoNotTransfer);
			textView.TextSelectHandleRight = textSelectHandleRight;
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

	private static Delegate GetGetTextSizeHandler()
	{
		return new _JniMarshal_PP_F(n_GetTextSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTextSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextSize;
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

	private static Delegate GetGetTotalPaddingLeftHandler()
	{
		return new _JniMarshal_PP_I(n_GetTotalPaddingLeft);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTotalPaddingLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TotalPaddingLeft;
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

	private static Delegate GetGetTotalPaddingTopHandler()
	{
		return new _JniMarshal_PP_I(n_GetTotalPaddingTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTotalPaddingTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TotalPaddingTop;
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
		return new _JniMarshal_PP_L(n_GetTypeface);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Typeface);
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

	private static Delegate GetAddTextChangedListener_Landroid_text_TextWatcher_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddTextChangedListener_Landroid_text_TextWatcher_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTextChangedListener_Landroid_text_TextWatcher_(nint jnienv, nint native__this, nint native_watcher)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITextWatcher watcher = Java.Lang.Object.GetObject<ITextWatcher>(native_watcher, JniHandleOwnership.DoNotTransfer);
			textView.AddTextChangedListener(watcher);
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

	public unsafe virtual void AddTextChangedListener(ITextWatcher? watcher)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((watcher == null) ? IntPtr.Zero : ((Java.Lang.Object)watcher).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTextChangedListener.(Landroid/text/TextWatcher;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(watcher);
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
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			textView.OnRestoreInstanceState(state);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

	public new unsafe virtual IParcelable? OnSaveInstanceState()
	{
		return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetAllCaps_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetAllCaps_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAllCaps_Z(nint jnienv, nint native__this, sbyte native_allCaps)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool allCaps = native_allCaps != 0;
			textView.SetAllCaps(allCaps);
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

	public unsafe virtual void SetAllCaps(bool allCaps)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(allCaps ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAllCaps.(Z)V", this, ptr);
	}

	private static Delegate GetSetCompoundDrawablesWithIntrinsicBounds_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPLLLL_V(n_SetCompoundDrawablesWithIntrinsicBounds_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompoundDrawablesWithIntrinsicBounds_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_left, nint native_top, nint native_right, nint native_bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable left = Java.Lang.Object.GetObject<Drawable>(native_left, JniHandleOwnership.DoNotTransfer);
			Drawable top = Java.Lang.Object.GetObject<Drawable>(native_top, JniHandleOwnership.DoNotTransfer);
			Drawable right = Java.Lang.Object.GetObject<Drawable>(native_right, JniHandleOwnership.DoNotTransfer);
			Drawable bottom = Java.Lang.Object.GetObject<Drawable>(native_bottom, JniHandleOwnership.DoNotTransfer);
			textView.SetCompoundDrawablesWithIntrinsicBounds(left, top, right, bottom);
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

	public unsafe virtual void SetCompoundDrawablesWithIntrinsicBounds(Drawable? left, Drawable? top, Drawable? right, Drawable? bottom)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(top?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(right?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(bottom?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCompoundDrawablesWithIntrinsicBounds.(Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(left);
			GC.KeepAlive(top);
			GC.KeepAlive(right);
			GC.KeepAlive(bottom);
		}
	}

	private static Delegate GetSetCompoundDrawablesWithIntrinsicBounds_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_SetCompoundDrawablesWithIntrinsicBounds_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompoundDrawablesWithIntrinsicBounds_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCompoundDrawablesWithIntrinsicBounds(left, top, right, bottom);
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

	public unsafe virtual void SetCompoundDrawablesWithIntrinsicBounds(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCompoundDrawablesWithIntrinsicBounds.(IIII)V", this, ptr);
	}

	private static Delegate GetSetFilters_arrayLandroid_text_InputFilter_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetFilters_arrayLandroid_text_InputFilter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFilters_arrayLandroid_text_InputFilter_(nint jnienv, nint native__this, nint native_filters)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInputFilter[] array = (IInputFilter[])JNIEnv.GetArray(native_filters, JniHandleOwnership.DoNotTransfer, typeof(IInputFilter));
			textView.SetFilters(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_filters);
			}
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

	public unsafe virtual void SetFilters(IInputFilter[]? filters)
	{
		nint num = JNIEnv.NewArray(filters);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFilters.([Landroid/text/InputFilter;)V", this, ptr);
		}
		finally
		{
			if (filters != null)
			{
				JNIEnv.CopyArray(num, filters);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(filters);
		}
	}

	private static Delegate GetSetHeight_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHeight_I(nint jnienv, nint native__this, int pixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHeight(pixels);
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

	public unsafe virtual void SetHeight(int pixels)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pixels);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHeight.(I)V", this, ptr);
	}

	private static Delegate GetSetHighlightColor_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetHighlightColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHighlightColor_I(nint jnienv, nint native__this, int native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Color highlightColor = new Color(native_color);
			textView.SetHighlightColor(highlightColor);
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

	public unsafe virtual void SetHighlightColor(Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHighlightColor.(I)V", this, ptr);
	}

	public unsafe void SetHintTextColor(Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("setHintTextColor.(I)V", this, ptr);
	}

	private static Delegate GetSetIncludeFontPadding_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetIncludeFontPadding_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIncludeFontPadding_Z(nint jnienv, nint native__this, sbyte native_includepad)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool includeFontPadding = native_includepad != 0;
			textView.SetIncludeFontPadding(includeFontPadding);
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

	public unsafe virtual void SetIncludeFontPadding(bool includepad)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(includepad ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setIncludeFontPadding.(Z)V", this, ptr);
	}

	public unsafe void SetLinkTextColor(Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLinkTextColor.(I)V", this, ptr);
	}

	private static Delegate GetSetMaxLines_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetMaxLines_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxLines_I(nint jnienv, nint native__this, int maxLines)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxLines(maxLines);
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

	public unsafe virtual void SetMaxLines(int maxLines)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(maxLines);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxLines.(I)V", this, ptr);
	}

	private static Delegate GetSetOnEditorActionListener_Landroid_widget_TextView_OnEditorActionListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnEditorActionListener_Landroid_widget_TextView_OnEditorActionListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnEditorActionListener_Landroid_widget_TextView_OnEditorActionListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnEditorActionListener onEditorActionListener = Java.Lang.Object.GetObject<IOnEditorActionListener>(native_l, JniHandleOwnership.DoNotTransfer);
			textView.SetOnEditorActionListener(onEditorActionListener);
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

	public unsafe virtual void SetOnEditorActionListener(IOnEditorActionListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnEditorActionListener.(Landroid/widget/TextView$OnEditorActionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	private static Delegate GetSetRawInputType_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetRawInputType_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRawInputType_I(nint jnienv, nint native__this, int native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRawInputType((InputTypes)native_type);
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

	public unsafe virtual void SetRawInputType(InputTypes type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)type);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRawInputType.(I)V", this, ptr);
	}

	private static Delegate GetSetSingleLineHandler()
	{
		return new _JniMarshal_PP_V(n_SetSingleLine);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSingleLine(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSingleLine();
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

	public unsafe virtual void SetSingleLine()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSingleLine.()V", this, null);
	}

	private static Delegate GetSetSingleLine_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetSingleLine_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSingleLine_Z(nint jnienv, nint native__this, sbyte native_singleLine)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool singleLine = native_singleLine != 0;
			textView.SetSingleLine(singleLine);
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

	public unsafe virtual void SetSingleLine(bool singleLine)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(singleLine ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSingleLine.(Z)V", this, ptr);
	}

	public unsafe void SetText(char[] text, int start, int len)
	{
		nint num = JNIEnv.NewArray(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(len);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setText.([CII)V", this, ptr);
		}
		finally
		{
			if (text != null)
			{
				JNIEnv.CopyArray(num, text);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(text);
		}
	}

	private static Delegate GetSetText_Ljava_lang_CharSequence_Landroid_widget_TextView_BufferType_Handler()
	{
		return new _JniMarshal_PPLL_V(n_SetText_Ljava_lang_CharSequence_Landroid_widget_TextView_BufferType_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetText_Ljava_lang_CharSequence_Landroid_widget_TextView_BufferType_(nint jnienv, nint native__this, nint native_text, nint native_type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			BufferType type = Java.Lang.Object.GetObject<BufferType>(native_type, JniHandleOwnership.DoNotTransfer);
			textView.SetText(text, type);
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

	public unsafe virtual void SetText(ICharSequence? text, BufferType? type)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setText.(Ljava/lang/CharSequence;Landroid/widget/TextView$BufferType;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
			GC.KeepAlive(type);
		}
	}

	public void SetText(string? text, BufferType? type)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		SetText(obj, type);
		obj?.Dispose();
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetSetTextAppearance_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetTextAppearance_I);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextAppearance_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTextAppearance(resId);
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

	[SupportedOSPlatform("android23.0")]
	public unsafe virtual void SetTextAppearance(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_colors)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList textColor = Java.Lang.Object.GetObject<ColorStateList>(native_colors, JniHandleOwnership.DoNotTransfer);
			textView.SetTextColor(textColor);
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

	public unsafe virtual void SetTextColor(ColorStateList? colors)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(colors?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(colors);
		}
	}

	private static Delegate GetSetTextColor_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetTextColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextColor_I(nint jnienv, nint native__this, int native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Color textColor = new Color(native_color);
			textView.SetTextColor(textColor);
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

	public unsafe virtual void SetTextColor(Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextColor.(I)V", this, ptr);
	}

	private static Delegate GetSetTextIsSelectable_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetTextIsSelectable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextIsSelectable_Z(nint jnienv, nint native__this, sbyte native_selectable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool textIsSelectable = native_selectable != 0;
			textView.SetTextIsSelectable(textIsSelectable);
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

	public unsafe virtual void SetTextIsSelectable(bool selectable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(selectable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextIsSelectable.(Z)V", this, ptr);
	}

	private static Delegate GetSetTextSize_IFHandler()
	{
		return new _JniMarshal_PPIF_V(n_SetTextSize_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextSize_IF(nint jnienv, nint native__this, int native_unit, float size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTextSize((ComplexUnitType)native_unit, size);
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

	public unsafe virtual void SetTextSize(ComplexUnitType unit, float size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((int)unit);
		ptr[1] = new JniArgumentValue(size);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextSize.(IF)V", this, ptr);
	}

	private static Delegate GetSetTypeface_Landroid_graphics_Typeface_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_SetTypeface_Landroid_graphics_Typeface_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTypeface_Landroid_graphics_Typeface_I(nint jnienv, nint native__this, nint native_tf, int native_style)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextView? textView = Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Typeface tf = Java.Lang.Object.GetObject<Typeface>(native_tf, JniHandleOwnership.DoNotTransfer);
			textView.SetTypeface(tf, (TypefaceStyle)native_style);
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

	public unsafe virtual void SetTypeface(Typeface? tf, TypefaceStyle style)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(tf?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)style);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTypeface.(Landroid/graphics/Typeface;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tf);
		}
	}

	private static Delegate GetSetWidth_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWidth_I(nint jnienv, nint native__this, int pixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TextView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetWidth(pixels);
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

	public unsafe virtual void SetWidth(int pixels)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pixels);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setWidth.(I)V", this, ptr);
	}

	private IOnEditorActionListenerImplementor __CreateIOnEditorActionListenerImplementor()
	{
		return new IOnEditorActionListenerImplementor();
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
