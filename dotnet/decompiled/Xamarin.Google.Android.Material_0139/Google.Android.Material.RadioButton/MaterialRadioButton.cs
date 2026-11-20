using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.RadioButton;

[Register("com/google/android/material/radiobutton/MaterialRadioButton", DoNotGenerateAcw = true)]
public class MaterialRadioButton : AppCompatRadioButton
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/radiobutton/MaterialRadioButton", typeof(MaterialRadioButton));

	private static Delegate? cb_isUseMaterialThemeColors_IsUseMaterialThemeColors_Z;

	private static Delegate? cb_setUseMaterialThemeColors_SetUseMaterialThemeColors_Z_V;

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

	protected MaterialRadioButton(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe MaterialRadioButton(Context context)
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
	public unsafe MaterialRadioButton(Context context, IAttributeSet? attrs)
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
	public unsafe MaterialRadioButton(Context context, IAttributeSet? attrs, int defStyleAttr)
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
			return Java.Lang.Object.GetObject<MaterialRadioButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseMaterialThemeColors ? ((sbyte)1) : ((sbyte)0);
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
			MaterialRadioButton? materialRadioButton = Java.Lang.Object.GetObject<MaterialRadioButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool useMaterialThemeColors = native_useMaterialThemeColors != 0;
			materialRadioButton.UseMaterialThemeColors = useMaterialThemeColors;
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
