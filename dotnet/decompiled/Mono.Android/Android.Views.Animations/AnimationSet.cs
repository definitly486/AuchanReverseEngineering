using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Views.Animations;

[Register("android/view/animation/AnimationSet", DoNotGenerateAcw = true)]
public class AnimationSet : Animation
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/animation/AnimationSet", typeof(AnimationSet));

	private static Delegate? cb_addAnimation_AddAnimation_Landroid_view_animation_Animation__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected AnimationSet(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe AnimationSet(Context? context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Z)V", "")]
	public unsafe AnimationSet(bool shareInterpolator)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(shareInterpolator ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Z)V", this, ptr);
		}
	}

	private static Delegate GetAddAnimation_Landroid_view_animation_Animation_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddAnimation_Landroid_view_animation_Animation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddAnimation_Landroid_view_animation_Animation_(nint jnienv, nint native__this, nint native_a)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AnimationSet? animationSet = Java.Lang.Object.GetObject<AnimationSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animation a = Java.Lang.Object.GetObject<Animation>(native_a, JniHandleOwnership.DoNotTransfer);
			animationSet.AddAnimation(a);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addAnimation", "(Landroid/view/animation/Animation;)V", "GetAddAnimation_Landroid_view_animation_Animation_Handler")]
	public unsafe virtual void AddAnimation(Animation? a)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addAnimation.(Landroid/view/animation/Animation;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(a);
		}
	}
}
