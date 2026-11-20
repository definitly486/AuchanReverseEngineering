using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.TextField;

[Register("com/google/android/material/textfield/TextInputEditText", DoNotGenerateAcw = true)]
public class TextInputEditText : AppCompatEditText
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/textfield/TextInputEditText", typeof(TextInputEditText));

	private static Delegate? cb_isTextInputLayoutFocusedRectEnabled_IsTextInputLayoutFocusedRectEnabled_Z;

	private static Delegate? cb_setTextInputLayoutFocusedRectEnabled_SetTextInputLayoutFocusedRectEnabled_Z_V;

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

	public unsafe virtual bool TextInputLayoutFocusedRectEnabled
	{
		[Register("isTextInputLayoutFocusedRectEnabled", "()Z", "GetIsTextInputLayoutFocusedRectEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTextInputLayoutFocusedRectEnabled.()Z", this, null);
		}
		[Register("setTextInputLayoutFocusedRectEnabled", "(Z)V", "GetSetTextInputLayoutFocusedRectEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextInputLayoutFocusedRectEnabled.(Z)V", this, ptr);
		}
	}

	protected TextInputEditText(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe TextInputEditText(Context context)
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
	public unsafe TextInputEditText(Context context, IAttributeSet? attrs)
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
	public unsafe TextInputEditText(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetIsTextInputLayoutFocusedRectEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsTextInputLayoutFocusedRectEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTextInputLayoutFocusedRectEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TextInputEditText>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextInputLayoutFocusedRectEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetTextInputLayoutFocusedRectEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetTextInputLayoutFocusedRectEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextInputLayoutFocusedRectEnabled_Z(nint jnienv, nint native__this, sbyte native_textInputLayoutFocusedRectEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextInputEditText? textInputEditText = Java.Lang.Object.GetObject<TextInputEditText>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool textInputLayoutFocusedRectEnabled = native_textInputLayoutFocusedRectEnabled != 0;
			textInputEditText.TextInputLayoutFocusedRectEnabled = textInputLayoutFocusedRectEnabled;
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
