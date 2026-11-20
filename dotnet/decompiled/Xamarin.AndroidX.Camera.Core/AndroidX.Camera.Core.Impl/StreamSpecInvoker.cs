using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/StreamSpec", DoNotGenerateAcw = true)]
internal class StreamSpecInvoker : StreamSpec
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/StreamSpec", typeof(StreamSpecInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override DynamicRange DynamicRange
	{
		[Register("getDynamicRange", "()Landroidx/camera/core/DynamicRange;", "GetGetDynamicRangeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DynamicRange>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDynamicRange.()Landroidx/camera/core/DynamicRange;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Android.Util.Range ExpectedFrameRateRange
	{
		[Register("getExpectedFrameRateRange", "()Landroid/util/Range;", "GetGetExpectedFrameRateRangeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExpectedFrameRateRange.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override IConfig? ImplementationOptions
	{
		[Register("getImplementationOptions", "()Landroidx/camera/core/impl/Config;", "GetGetImplementationOptionsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImplementationOptions.()Landroidx/camera/core/impl/Config;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Size Resolution
	{
		[Register("getResolution", "()Landroid/util/Size;", "GetGetResolutionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolution.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override bool ZslDisabled
	{
		[Register("getZslDisabled", "()Z", "GetGetZslDisabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getZslDisabled.()Z", this, null);
		}
	}

	public StreamSpecInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("toBuilder", "()Landroidx/camera/core/impl/StreamSpec$Builder;", "GetToBuilderHandler")]
	public unsafe override Builder ToBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("toBuilder.()Landroidx/camera/core/impl/StreamSpec$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
