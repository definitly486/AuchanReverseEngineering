using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Config$OptionPriority", DoNotGenerateAcw = true)]
public sealed class ConfigOptionPriority : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Config$OptionPriority", typeof(ConfigOptionPriority));

	[Register("ALWAYS_OVERRIDE")]
	public static ConfigOptionPriority? AlwaysOverride => Java.Lang.Object.GetObject<ConfigOptionPriority>(_members.StaticFields.GetObjectValue("ALWAYS_OVERRIDE.Landroidx/camera/core/impl/Config$OptionPriority;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("HIGH_PRIORITY_REQUIRED")]
	public static ConfigOptionPriority? HighPriorityRequired => Java.Lang.Object.GetObject<ConfigOptionPriority>(_members.StaticFields.GetObjectValue("HIGH_PRIORITY_REQUIRED.Landroidx/camera/core/impl/Config$OptionPriority;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTIONAL")]
	public static ConfigOptionPriority? Optional => Java.Lang.Object.GetObject<ConfigOptionPriority>(_members.StaticFields.GetObjectValue("OPTIONAL.Landroidx/camera/core/impl/Config$OptionPriority;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("REQUIRED")]
	public static ConfigOptionPriority? Required => Java.Lang.Object.GetObject<ConfigOptionPriority>(_members.StaticFields.GetObjectValue("REQUIRED.Landroidx/camera/core/impl/Config$OptionPriority;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal ConfigOptionPriority(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/Config$OptionPriority;", "")]
	public unsafe static ConfigOptionPriority? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ConfigOptionPriority>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/Config$OptionPriority;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Landroidx/camera/core/impl/Config$OptionPriority;", "")]
	public unsafe static ConfigOptionPriority[]? Values()
	{
		return (ConfigOptionPriority[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/Config$OptionPriority;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ConfigOptionPriority));
	}
}
