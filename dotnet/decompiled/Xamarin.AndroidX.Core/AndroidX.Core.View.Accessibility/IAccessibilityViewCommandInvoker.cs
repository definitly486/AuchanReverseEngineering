using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View.Accessibility;

[Register("androidx/core/view/accessibility/AccessibilityViewCommand", DoNotGenerateAcw = true)]
internal class IAccessibilityViewCommandInvoker : Java.Lang.Object, IAccessibilityViewCommand, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_core_view_accessibility_AccessibilityViewCommand = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityViewCommand", typeof(IAccessibilityViewCommandInvoker));

	private static Delegate? cb_perform_Perform_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityViewCommand_CommandArguments__Z;

	private static nint java_class_ref => _members_androidx_core_view_accessibility_AccessibilityViewCommand.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_accessibility_AccessibilityViewCommand;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_view_accessibility_AccessibilityViewCommand.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_view_accessibility_AccessibilityViewCommand.ManagedPeerType;

	public IAccessibilityViewCommandInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetPerform_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityViewCommand_CommandArguments_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_Perform_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityViewCommand_CommandArguments_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Perform_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityViewCommand_CommandArguments_(nint jnienv, nint native__this, nint native_view, nint native_arguments)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAccessibilityViewCommand? accessibilityViewCommand = Java.Lang.Object.GetObject<IAccessibilityViewCommand>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			AccessibilityViewCommandCommandArguments arguments = Java.Lang.Object.GetObject<AccessibilityViewCommandCommandArguments>(native_arguments, JniHandleOwnership.DoNotTransfer);
			return accessibilityViewCommand.Perform(view, arguments) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool Perform(Android.Views.View? view, AccessibilityViewCommandCommandArguments? arguments)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
			return _members_androidx_core_view_accessibility_AccessibilityViewCommand.InstanceMethods.InvokeAbstractBooleanMethod("perform.(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityViewCommand$CommandArguments;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(arguments);
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
