using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Jvm.Internal.Markers;

[Register("kotlin/jvm/internal/markers/KMappedMarker", DoNotGenerateAcw = true)]
internal class IKMappedMarkerInvoker : Java.Lang.Object, IKMappedMarker, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_jvm_internal_markers_KMappedMarker = new XAPeerMembers("kotlin/jvm/internal/markers/KMappedMarker", typeof(IKMappedMarkerInvoker));

	private static nint java_class_ref => _members_kotlin_jvm_internal_markers_KMappedMarker.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_jvm_internal_markers_KMappedMarker;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_jvm_internal_markers_KMappedMarker.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_jvm_internal_markers_KMappedMarker.ManagedPeerType;

	public IKMappedMarkerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
