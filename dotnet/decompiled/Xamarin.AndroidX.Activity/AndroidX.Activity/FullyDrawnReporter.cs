using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;
using Kotlin.Jvm.Functions;

namespace AndroidX.Activity;

[Register("androidx/activity/FullyDrawnReporter", DoNotGenerateAcw = true)]
public sealed class FullyDrawnReporter : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/FullyDrawnReporter", typeof(FullyDrawnReporter));

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

	public unsafe bool IsFullyDrawnReported
	{
		[Register("isFullyDrawnReported", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isFullyDrawnReported.()Z", this, null);
		}
	}

	internal FullyDrawnReporter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/util/concurrent/Executor;Lkotlin/jvm/functions/Function0;)V", "")]
	public unsafe FullyDrawnReporter(IExecutor executor, IFunction0 reportFullyDrawn)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((reportFullyDrawn == null) ? IntPtr.Zero : ((Java.Lang.Object)reportFullyDrawn).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/concurrent/Executor;Lkotlin/jvm/functions/Function0;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/util/concurrent/Executor;Lkotlin/jvm/functions/Function0;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(reportFullyDrawn);
		}
	}

	[Register("addOnReportDrawnListener", "(Lkotlin/jvm/functions/Function0;)V", "")]
	public unsafe void AddOnReportDrawnListener(IFunction0 callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnReportDrawnListener.(Lkotlin/jvm/functions/Function0;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("addReporter", "()V", "")]
	public unsafe void AddReporter()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("addReporter.()V", this, null);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("fullyDrawnReported", "()V", "")]
	public unsafe void FullyDrawnReported()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("fullyDrawnReported.()V", this, null);
	}

	[Register("removeOnReportDrawnListener", "(Lkotlin/jvm/functions/Function0;)V", "")]
	public unsafe void RemoveOnReportDrawnListener(IFunction0 callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnReportDrawnListener.(Lkotlin/jvm/functions/Function0;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("removeReporter", "()V", "")]
	public unsafe void RemoveReporter()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeReporter.()V", this, null);
	}
}
