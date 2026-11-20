using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.ResolutionSelector;

[Register("androidx/camera/core/resolutionselector/ResolutionStrategy", DoNotGenerateAcw = true)]
public sealed class ResolutionStrategy : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/resolutionselector/ResolutionStrategy", typeof(ResolutionStrategy));

	[Register("HIGHEST_AVAILABLE_STRATEGY")]
	public static ResolutionStrategy HighestAvailableStrategy => Java.Lang.Object.GetObject<ResolutionStrategy>(_members.StaticFields.GetObjectValue("HIGHEST_AVAILABLE_STRATEGY.Landroidx/camera/core/resolutionselector/ResolutionStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe Size? BoundSize
	{
		[Register("getBoundSize", "()Landroid/util/Size;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBoundSize.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int FallbackRule
	{
		[Register("getFallbackRule", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getFallbackRule.()I", this, null);
		}
	}

	internal ResolutionStrategy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/util/Size;I)V", "")]
	public unsafe ResolutionStrategy(Size boundSize, int fallbackRule)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(boundSize?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(fallbackRule);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/util/Size;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/util/Size;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(boundSize);
		}
	}
}
