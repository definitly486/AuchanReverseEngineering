using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/Dependency", DoNotGenerateAcw = true)]
internal class IDependencyInvoker : Java.Lang.Object, IDependency, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_constraintlayout_core_widgets_analyzer_Dependency = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/Dependency", typeof(IDependencyInvoker));

	private static Delegate? cb_update_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency__V;

	private static nint java_class_ref => _members_androidx_constraintlayout_core_widgets_analyzer_Dependency.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_core_widgets_analyzer_Dependency;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_constraintlayout_core_widgets_analyzer_Dependency.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_constraintlayout_core_widgets_analyzer_Dependency.ManagedPeerType;

	public IDependencyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetUpdate_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Update_Landroidx_constraintlayout_core_widgets_analyzer_Dependency_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDependency? dependency = Java.Lang.Object.GetObject<IDependency>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency p = Java.Lang.Object.GetObject<IDependency>(native_p0, JniHandleOwnership.DoNotTransfer);
			dependency.Update(p);
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

	public unsafe void Update(IDependency? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_androidx_constraintlayout_core_widgets_analyzer_Dependency.InstanceMethods.InvokeAbstractVoidMethod("update.(Landroidx/constraintlayout/core/widgets/analyzer/Dependency;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

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
}
