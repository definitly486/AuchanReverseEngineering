using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Bumptech.Glide.Request.Transition;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Resource.Drawable;

[Register("com/bumptech/glide/load/resource/drawable/DrawableTransitionOptions", DoNotGenerateAcw = true)]
public sealed class DrawableTransitionOptions : TransitionOptions
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/resource/drawable/DrawableTransitionOptions", typeof(DrawableTransitionOptions));

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal DrawableTransitionOptions(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe DrawableTransitionOptions()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("crossFade", "()Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe DrawableTransitionOptions CrossFade()
	{
		return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("crossFade.()Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("crossFade", "(Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe DrawableTransitionOptions CrossFade(DrawableCrossFadeFactory drawableCrossFadeFactory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawableCrossFadeFactory?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("crossFade.(Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(drawableCrossFadeFactory);
		}
	}

	[Register("crossFade", "(Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory$Builder;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe DrawableTransitionOptions CrossFade(DrawableCrossFadeFactory.Builder builder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("crossFade.(Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory$Builder;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(builder);
		}
	}

	[Register("crossFade", "(I)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe DrawableTransitionOptions CrossFade(int duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(duration);
		return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("crossFade.(I)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("with", "(Lcom/bumptech/glide/request/transition/TransitionFactory;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe static DrawableTransitionOptions With(ITransitionFactory transitionFactory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((transitionFactory == null) ? IntPtr.Zero : ((Java.Lang.Object)transitionFactory).Handle);
			return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.StaticMethods.InvokeObjectMethod("with.(Lcom/bumptech/glide/request/transition/TransitionFactory;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(transitionFactory);
		}
	}

	[Register("withCrossFade", "()Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe static DrawableTransitionOptions WithCrossFade()
	{
		return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.StaticMethods.InvokeObjectMethod("withCrossFade.()Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("withCrossFade", "(Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe static DrawableTransitionOptions WithCrossFade(DrawableCrossFadeFactory drawableCrossFadeFactory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawableCrossFadeFactory?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.StaticMethods.InvokeObjectMethod("withCrossFade.(Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(drawableCrossFadeFactory);
		}
	}

	[Register("withCrossFade", "(Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory$Builder;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe static DrawableTransitionOptions WithCrossFade(DrawableCrossFadeFactory.Builder builder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.StaticMethods.InvokeObjectMethod("withCrossFade.(Lcom/bumptech/glide/request/transition/DrawableCrossFadeFactory$Builder;)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(builder);
		}
	}

	[Register("withCrossFade", "(I)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", "")]
	public unsafe static DrawableTransitionOptions WithCrossFade(int duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(duration);
		return Java.Lang.Object.GetObject<DrawableTransitionOptions>(_members.StaticMethods.InvokeObjectMethod("withCrossFade.(I)Lcom/bumptech/glide/load/resource/drawable/DrawableTransitionOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
