using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.ResolutionSelector;

[Register("androidx/camera/core/resolutionselector/AspectRatioStrategy", DoNotGenerateAcw = true)]
public sealed class AspectRatioStrategy : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/resolutionselector/AspectRatioStrategy", typeof(AspectRatioStrategy));

	[Register("RATIO_16_9_FALLBACK_AUTO_STRATEGY")]
	public static AspectRatioStrategy Ratio169FallbackAutoStrategy => Java.Lang.Object.GetObject<AspectRatioStrategy>(_members.StaticFields.GetObjectValue("RATIO_16_9_FALLBACK_AUTO_STRATEGY.Landroidx/camera/core/resolutionselector/AspectRatioStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RATIO_4_3_FALLBACK_AUTO_STRATEGY")]
	public static AspectRatioStrategy Ratio43FallbackAutoStrategy => Java.Lang.Object.GetObject<AspectRatioStrategy>(_members.StaticFields.GetObjectValue("RATIO_4_3_FALLBACK_AUTO_STRATEGY.Landroidx/camera/core/resolutionselector/AspectRatioStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe int FallbackRule
	{
		[Register("getFallbackRule", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getFallbackRule.()I", this, null);
		}
	}

	public unsafe int PreferredAspectRatio
	{
		[Register("getPreferredAspectRatio", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getPreferredAspectRatio.()I", this, null);
		}
	}

	internal AspectRatioStrategy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe AspectRatioStrategy(int preferredAspectRatio, int fallbackRule)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(preferredAspectRatio);
			ptr[1] = new JniArgumentValue(fallbackRule);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
		}
	}
}
