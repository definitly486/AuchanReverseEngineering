using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.Bindings;

[Register("com/yandex/runtime/bindings/ArchivingHandler", DoNotGenerateAcw = true)]
internal class IArchivingHandlerInvoker : Java.Lang.Object, IArchivingHandler, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_runtime_bindings_ArchivingHandler = new XAPeerMembers("com/yandex/runtime/bindings/ArchivingHandler", typeof(IArchivingHandlerInvoker));

	private static nint java_class_ref => _members_com_yandex_runtime_bindings_ArchivingHandler.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_runtime_bindings_ArchivingHandler;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_runtime_bindings_ArchivingHandler.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_runtime_bindings_ArchivingHandler.ManagedPeerType;

	public IArchivingHandlerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
