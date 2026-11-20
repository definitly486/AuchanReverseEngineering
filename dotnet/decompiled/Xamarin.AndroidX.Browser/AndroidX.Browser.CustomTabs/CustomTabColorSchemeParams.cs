using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Browser.CustomTabs;

[Register("androidx/browser/customtabs/CustomTabColorSchemeParams", DoNotGenerateAcw = true)]
public sealed class CustomTabColorSchemeParams : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabColorSchemeParams", typeof(CustomTabColorSchemeParams));

	[Register("navigationBarColor")]
	public Integer? NavigationBarColor
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("navigationBarColor.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("navigationBarColor.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("navigationBarDividerColor")]
	public Integer? NavigationBarDividerColor
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("navigationBarDividerColor.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("navigationBarDividerColor.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("secondaryToolbarColor")]
	public Integer? SecondaryToolbarColor
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("secondaryToolbarColor.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("secondaryToolbarColor.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("toolbarColor")]
	public Integer? ToolbarColor
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("toolbarColor.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("toolbarColor.Ljava/lang/Integer;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
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

	internal CustomTabColorSchemeParams(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
