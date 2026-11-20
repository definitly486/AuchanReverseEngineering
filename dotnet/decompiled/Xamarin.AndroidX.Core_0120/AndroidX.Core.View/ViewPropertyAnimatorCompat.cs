using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views.Animations;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ViewPropertyAnimatorCompat", DoNotGenerateAcw = true)]
public sealed class ViewPropertyAnimatorCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/ViewPropertyAnimatorCompat", typeof(ViewPropertyAnimatorCompat));

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

	public unsafe long Duration
	{
		[Register("getDuration", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getDuration.()J", this, null);
		}
	}

	public unsafe IInterpolator? Interpolator
	{
		[Register("getInterpolator", "()Landroid/view/animation/Interpolator;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IInterpolator>(_members.InstanceMethods.InvokeAbstractObjectMethod("getInterpolator.()Landroid/view/animation/Interpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe long StartDelay
	{
		[Register("getStartDelay", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getStartDelay.()J", this, null);
		}
	}

	internal ViewPropertyAnimatorCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("alpha", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? Alpha(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("alpha.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("alphaBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? AlphaBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("alphaBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("cancel", "()V", "")]
	public unsafe void Cancel()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
	}

	[Register("rotation", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? Rotation(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotation.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("rotationBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? RotationBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotationBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("rotationX", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? RotationX(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotationX.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("rotationXBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? RotationXBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotationXBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("rotationY", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? RotationY(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotationY.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("rotationYBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? RotationYBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotationYBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("scaleX", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? ScaleX(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("scaleX.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("scaleXBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? ScaleXBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("scaleXBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("scaleY", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? ScaleY(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("scaleY.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("scaleYBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? ScaleYBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("scaleYBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setDuration", "(J)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? SetDuration(long value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDuration.(J)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setInterpolator", "(Landroid/view/animation/Interpolator;)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? SetInterpolator(IInterpolator? value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
			return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInterpolator.(Landroid/view/animation/Interpolator;)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}

	[Register("setListener", "(Landroidx/core/view/ViewPropertyAnimatorListener;)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? SetListener(IViewPropertyAnimatorListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("setListener.(Landroidx/core/view/ViewPropertyAnimatorListener;)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("setStartDelay", "(J)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? SetStartDelay(long value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("setStartDelay.(J)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setUpdateListener", "(Landroidx/core/view/ViewPropertyAnimatorUpdateListener;)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? SetUpdateListener(IViewPropertyAnimatorUpdateListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUpdateListener.(Landroidx/core/view/ViewPropertyAnimatorUpdateListener;)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("start", "()V", "")]
	public unsafe void Start()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("start.()V", this, null);
	}

	[Register("translationX", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? TranslationX(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("translationX.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("translationXBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? TranslationXBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("translationXBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("translationY", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? TranslationY(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("translationY.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("translationYBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? TranslationYBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("translationYBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("translationZ", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? TranslationZ(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("translationZ.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("translationZBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? TranslationZBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("translationZBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("withEndAction", "(Ljava/lang/Runnable;)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? WithEndAction(IRunnable? runnable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("withEndAction.(Ljava/lang/Runnable;)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(runnable);
		}
	}

	[Register("withLayer", "()Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? WithLayer()
	{
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("withLayer.()Landroidx/core/view/ViewPropertyAnimatorCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("withStartAction", "(Ljava/lang/Runnable;)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? WithStartAction(IRunnable? runnable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("withStartAction.(Ljava/lang/Runnable;)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(runnable);
		}
	}

	[Register("x", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? X(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("x.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("xBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? XBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("xBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("y", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? Y(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("y.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("yBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? YBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("yBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("z", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? Z(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("z.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("zBy", "(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe ViewPropertyAnimatorCompat? ZBy(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("zBy.(F)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
