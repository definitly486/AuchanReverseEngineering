using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/DynamicRange", DoNotGenerateAcw = true)]
public sealed class DynamicRange : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/DynamicRange", typeof(DynamicRange));

	[Register("DOLBY_VISION_10_BIT")]
	public static DynamicRange DolbyVision10Bit => Java.Lang.Object.GetObject<DynamicRange>(_members.StaticFields.GetObjectValue("DOLBY_VISION_10_BIT.Landroidx/camera/core/DynamicRange;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DOLBY_VISION_8_BIT")]
	public static DynamicRange DolbyVision8Bit => Java.Lang.Object.GetObject<DynamicRange>(_members.StaticFields.GetObjectValue("DOLBY_VISION_8_BIT.Landroidx/camera/core/DynamicRange;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("HDR10_10_BIT")]
	public static DynamicRange Hdr1010Bit => Java.Lang.Object.GetObject<DynamicRange>(_members.StaticFields.GetObjectValue("HDR10_10_BIT.Landroidx/camera/core/DynamicRange;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("HDR10_PLUS_10_BIT")]
	public static DynamicRange Hdr10Plus10Bit => Java.Lang.Object.GetObject<DynamicRange>(_members.StaticFields.GetObjectValue("HDR10_PLUS_10_BIT.Landroidx/camera/core/DynamicRange;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("HDR_UNSPECIFIED_10_BIT")]
	public static DynamicRange HdrUnspecified10Bit => Java.Lang.Object.GetObject<DynamicRange>(_members.StaticFields.GetObjectValue("HDR_UNSPECIFIED_10_BIT.Landroidx/camera/core/DynamicRange;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("HLG_10_BIT")]
	public static DynamicRange Hlg10Bit => Java.Lang.Object.GetObject<DynamicRange>(_members.StaticFields.GetObjectValue("HLG_10_BIT.Landroidx/camera/core/DynamicRange;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SDR")]
	public static DynamicRange Sdr => Java.Lang.Object.GetObject<DynamicRange>(_members.StaticFields.GetObjectValue("SDR.Landroidx/camera/core/DynamicRange;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UNSPECIFIED")]
	public static DynamicRange Unspecified => Java.Lang.Object.GetObject<DynamicRange>(_members.StaticFields.GetObjectValue("UNSPECIFIED.Landroidx/camera/core/DynamicRange;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe int BitDepth
	{
		[Register("getBitDepth", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getBitDepth.()I", this, null);
		}
	}

	public unsafe int Encoding
	{
		[Register("getEncoding", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getEncoding.()I", this, null);
		}
	}

	public unsafe bool IsFullySpecified
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isFullySpecified", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isFullySpecified.()Z", this, null);
		}
	}

	internal DynamicRange(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe DynamicRange(int encoding, int bitDepth)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(encoding);
			ptr[1] = new JniArgumentValue(bitDepth);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("is10BitHdr", "()Z", "")]
	public unsafe bool Is10BitHdr()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("is10BitHdr.()Z", this, null);
	}
}
