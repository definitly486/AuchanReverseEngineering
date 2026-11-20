using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkPresentation", DoNotGenerateAcw = true)]
internal class IPlacemarkPresentationInvoker : Java.Lang.Object, IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkPresentation = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkPresentation", typeof(IPlacemarkPresentationInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_remove_Remove_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_PlacemarkPresentation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_PlacemarkPresentation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_PlacemarkPresentation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_PlacemarkPresentation.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IPlacemarkPresentationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsValidHandler()
	{
		if ((object)cb_isValid_IsValid_Z == null)
		{
			cb_isValid_IsValid_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsValid));
		}
		return cb_isValid_IsValid_Z;
	}

	private static bool n_IsValid(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPlacemarkPresentation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetRemoveHandler()
	{
		if ((object)cb_remove_Remove_V == null)
		{
			cb_remove_Remove_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Remove));
		}
		return cb_remove_Remove_V;
	}

	private static void n_Remove(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlacemarkPresentation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
	}

	public unsafe void Remove()
	{
		_members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}
}
