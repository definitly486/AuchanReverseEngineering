using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/PreviewConfig", DoNotGenerateAcw = true)]
public sealed class PreviewConfig : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/PreviewConfig", typeof(PreviewConfig));

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

	public unsafe IConfig Config
	{
		[Register("getConfig", "()Landroidx/camera/core/impl/Config;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConfig.()Landroidx/camera/core/impl/Config;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int InputFormat
	{
		[Register("getInputFormat", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getInputFormat.()I", this, null);
		}
	}

	internal PreviewConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/camera/core/impl/OptionsBundle;)V", "")]
	public unsafe PreviewConfig(OptionsBundle config)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/camera/core/impl/OptionsBundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/camera/core/impl/OptionsBundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(config);
		}
	}
}
