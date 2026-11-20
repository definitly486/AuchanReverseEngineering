using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/VerticalWidgetRun", DoNotGenerateAcw = true)]
public class VerticalWidgetRun : WidgetRun
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/VerticalWidgetRun", typeof(VerticalWidgetRun));

	private static Delegate? cb_applyToWidget_ApplyToWidget_V;

	[Register("baseline")]
	public DependencyNode? Baseline
	{
		get
		{
			return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceFields.GetObjectValue("baseline.Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("baseline.Landroidx/constraintlayout/core/widgets/analyzer/DependencyNode;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

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

	protected VerticalWidgetRun(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", "")]
	public unsafe VerticalWidgetRun(ConstraintWidget? widget)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}

	private static Delegate GetApplyToWidgetHandler()
	{
		return new global::_JniMarshal_PP_V(n_ApplyToWidget);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyToWidget(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<VerticalWidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplyToWidget();
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

	[Register("applyToWidget", "()V", "GetApplyToWidgetHandler")]
	public unsafe virtual void ApplyToWidget()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("applyToWidget.()V", this, null);
	}
}
