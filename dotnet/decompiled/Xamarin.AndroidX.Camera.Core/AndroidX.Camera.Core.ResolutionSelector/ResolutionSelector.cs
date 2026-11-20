using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.ResolutionSelector;

[Register("androidx/camera/core/resolutionselector/ResolutionSelector", DoNotGenerateAcw = true)]
public sealed class ResolutionSelector : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/resolutionselector/ResolutionSelector", typeof(ResolutionSelector));

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

	public unsafe int AllowedResolutionMode
	{
		[Register("getAllowedResolutionMode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getAllowedResolutionMode.()I", this, null);
		}
	}

	public unsafe AspectRatioStrategy AspectRatioStrategy
	{
		[Register("getAspectRatioStrategy", "()Landroidx/camera/core/resolutionselector/AspectRatioStrategy;", "")]
		get
		{
			return Java.Lang.Object.GetObject<AspectRatioStrategy>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAspectRatioStrategy.()Landroidx/camera/core/resolutionselector/AspectRatioStrategy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IResolutionFilter? ResolutionFilter
	{
		[Register("getResolutionFilter", "()Landroidx/camera/core/resolutionselector/ResolutionFilter;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IResolutionFilter>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolutionFilter.()Landroidx/camera/core/resolutionselector/ResolutionFilter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ResolutionStrategy? ResolutionStrategy
	{
		[Register("getResolutionStrategy", "()Landroidx/camera/core/resolutionselector/ResolutionStrategy;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ResolutionStrategy>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolutionStrategy.()Landroidx/camera/core/resolutionselector/ResolutionStrategy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal ResolutionSelector(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
