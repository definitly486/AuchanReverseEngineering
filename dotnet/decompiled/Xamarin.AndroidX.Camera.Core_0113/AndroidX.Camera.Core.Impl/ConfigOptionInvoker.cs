using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Config$Option", DoNotGenerateAcw = true)]
internal class ConfigOptionInvoker : ConfigOption
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Config$Option", typeof(ConfigOptionInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override string Id
	{
		[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Java.Lang.Object? Token
	{
		[Register("getToken", "()Ljava/lang/Object;", "GetGetTokenHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getToken.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Class ValueClass
	{
		[Register("getValueClass", "()Ljava/lang/Class;", "GetGetValueClassHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeAbstractObjectMethod("getValueClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public ConfigOptionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
