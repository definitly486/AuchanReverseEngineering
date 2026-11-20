using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Window;
using AndroidX.Core.Util;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity;

[Register("androidx/activity/OnBackPressedDispatcher", DoNotGenerateAcw = true)]
public sealed class OnBackPressedDispatcher : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/OnBackPressedDispatcher", typeof(OnBackPressedDispatcher));

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

	public unsafe bool HasEnabledCallbacks
	{
		[Register("hasEnabledCallbacks", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasEnabledCallbacks.()Z", this, null);
		}
	}

	internal OnBackPressedDispatcher(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe OnBackPressedDispatcher()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Ljava/lang/Runnable;)V", "")]
	public unsafe OnBackPressedDispatcher(IRunnable? fallbackOnBackPressed)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((fallbackOnBackPressed == null) ? IntPtr.Zero : ((Java.Lang.Object)fallbackOnBackPressed).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Runnable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fallbackOnBackPressed);
		}
	}

	[Register(".ctor", "(Ljava/lang/Runnable;Landroidx/core/util/Consumer;)V", "")]
	public unsafe OnBackPressedDispatcher(IRunnable? fallbackOnBackPressed, IConsumer? onHasEnabledCallbacksChanged)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((fallbackOnBackPressed == null) ? IntPtr.Zero : ((Java.Lang.Object)fallbackOnBackPressed).Handle);
			ptr[1] = new JniArgumentValue((onHasEnabledCallbacksChanged == null) ? IntPtr.Zero : ((Java.Lang.Object)onHasEnabledCallbacksChanged).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Runnable;Landroidx/core/util/Consumer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Runnable;Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fallbackOnBackPressed);
			GC.KeepAlive(onHasEnabledCallbacksChanged);
		}
	}

	[Register("addCallback", "(Landroidx/activity/OnBackPressedCallback;)V", "")]
	public unsafe void AddCallback(OnBackPressedCallback onBackPressedCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(onBackPressedCallback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addCallback.(Landroidx/activity/OnBackPressedCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onBackPressedCallback);
		}
	}

	[Register("addCallback", "(Landroidx/lifecycle/LifecycleOwner;Landroidx/activity/OnBackPressedCallback;)V", "")]
	public unsafe void AddCallback(ILifecycleOwner owner, OnBackPressedCallback onBackPressedCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			ptr[1] = new JniArgumentValue(onBackPressedCallback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addCallback.(Landroidx/lifecycle/LifecycleOwner;Landroidx/activity/OnBackPressedCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
			GC.KeepAlive(onBackPressedCallback);
		}
	}

	[Register("dispatchOnBackCancelled", "()V", "")]
	public unsafe void DispatchOnBackCancelled()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchOnBackCancelled.()V", this, null);
	}

	[Register("dispatchOnBackProgressed", "(Landroidx/activity/BackEventCompat;)V", "")]
	public unsafe void DispatchOnBackProgressed(BackEventCompat backEvent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(backEvent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchOnBackProgressed.(Landroidx/activity/BackEventCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(backEvent);
		}
	}

	[Register("dispatchOnBackStarted", "(Landroidx/activity/BackEventCompat;)V", "")]
	public unsafe void DispatchOnBackStarted(BackEventCompat backEvent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(backEvent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchOnBackStarted.(Landroidx/activity/BackEventCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(backEvent);
		}
	}

	[Register("onBackPressed", "()V", "")]
	public unsafe void OnBackPressed()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("onBackPressed.()V", this, null);
	}

	[Register("setOnBackInvokedDispatcher", "(Landroid/window/OnBackInvokedDispatcher;)V", "")]
	public unsafe void SetOnBackInvokedDispatcher(IOnBackInvokedDispatcher invoker)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((invoker == null) ? IntPtr.Zero : ((Java.Lang.Object)invoker).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnBackInvokedDispatcher.(Landroid/window/OnBackInvokedDispatcher;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(invoker);
		}
	}
}
