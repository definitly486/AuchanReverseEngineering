using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Style;

[Register("android/text/style/MetricAffectingSpan", DoNotGenerateAcw = true)]
public abstract class MetricAffectingSpan : CharacterStyle, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/MetricAffectingSpan", typeof(MetricAffectingSpan));

	private static Delegate? cb_updateMeasureState_UpdateMeasureState_Landroid_text_TextPaint__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected MetricAffectingSpan(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MetricAffectingSpan()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateMeasureState_Landroid_text_TextPaint_(nint jnienv, nint native__this, nint native_textPaint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MetricAffectingSpan? metricAffectingSpan = Java.Lang.Object.GetObject<MetricAffectingSpan>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TextPaint textPaint = Java.Lang.Object.GetObject<TextPaint>(native_textPaint, JniHandleOwnership.DoNotTransfer);
			metricAffectingSpan.UpdateMeasureState(textPaint);
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

	[Register("updateMeasureState", "(Landroid/text/TextPaint;)V", "GetUpdateMeasureState_Landroid_text_TextPaint_Handler")]
	public abstract void UpdateMeasureState(TextPaint textPaint);

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}

	[UnmanagedCallersOnly]
	private static void n_UpdateMeasureState_Landroid_text_TextPaint__mm_wrapper(nint jnienv, nint native__this, nint native_textPaint)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_UpdateMeasureState_Landroid_text_TextPaint_(jnienv, native__this, native_textPaint);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
