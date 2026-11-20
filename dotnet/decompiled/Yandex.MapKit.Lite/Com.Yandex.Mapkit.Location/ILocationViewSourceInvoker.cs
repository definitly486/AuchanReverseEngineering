using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationViewSource", DoNotGenerateAcw = true)]
internal class ILocationViewSourceInvoker : Java.Lang.Object, ILocationViewSource, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_location_LocationViewSource = new XAPeerMembers("com/yandex/mapkit/location/LocationViewSource", typeof(ILocationViewSourceInvoker));

	private static nint java_class_ref => _members_com_yandex_mapkit_location_LocationViewSource.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_location_LocationViewSource;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_location_LocationViewSource.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_location_LocationViewSource.ManagedPeerType;

	public ILocationViewSourceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
