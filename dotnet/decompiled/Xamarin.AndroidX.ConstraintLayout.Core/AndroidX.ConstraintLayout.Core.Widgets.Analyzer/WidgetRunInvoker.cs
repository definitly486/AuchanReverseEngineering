using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/WidgetRun", DoNotGenerateAcw = true)]
internal class WidgetRunInvoker : WidgetRun
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/WidgetRun", typeof(WidgetRunInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public WidgetRunInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
