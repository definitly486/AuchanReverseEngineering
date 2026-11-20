using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Core.Graphics;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/WindowInsetsAnimationControllerCompat", DoNotGenerateAcw = true)]
public sealed class WindowInsetsAnimationControllerCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/WindowInsetsAnimationControllerCompat", typeof(WindowInsetsAnimationControllerCompat));

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

	public unsafe float CurrentAlpha
	{
		[Register("getCurrentAlpha", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getCurrentAlpha.()F", this, null);
		}
	}

	public unsafe float CurrentFraction
	{
		[Register("getCurrentFraction", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getCurrentFraction.()F", this, null);
		}
	}

	public unsafe Insets? CurrentInsets
	{
		[Register("getCurrentInsets", "()Landroidx/core/graphics/Insets;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Insets>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCurrentInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Insets? HiddenStateInsets
	{
		[Register("getHiddenStateInsets", "()Landroidx/core/graphics/Insets;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Insets>(_members.InstanceMethods.InvokeAbstractObjectMethod("getHiddenStateInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsCancelled
	{
		[Register("isCancelled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCancelled.()Z", this, null);
		}
	}

	public unsafe bool IsFinished
	{
		[Register("isFinished", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isFinished.()Z", this, null);
		}
	}

	public unsafe bool IsReady
	{
		[Register("isReady", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isReady.()Z", this, null);
		}
	}

	public unsafe Insets? ShownStateInsets
	{
		[Register("getShownStateInsets", "()Landroidx/core/graphics/Insets;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Insets>(_members.InstanceMethods.InvokeAbstractObjectMethod("getShownStateInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int Types
	{
		[Register("getTypes", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getTypes.()I", this, null);
		}
	}

	internal WindowInsetsAnimationControllerCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("finish", "(Z)V", "")]
	public unsafe void Finish(bool shown)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shown ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("finish.(Z)V", this, ptr);
	}

	[Register("setInsetsAndAlpha", "(Landroidx/core/graphics/Insets;FF)V", "")]
	public unsafe void SetInsetsAndAlpha(Insets? insets, float alpha, float fraction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(alpha);
			ptr[2] = new JniArgumentValue(fraction);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setInsetsAndAlpha.(Landroidx/core/graphics/Insets;FF)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(insets);
		}
	}
}
