using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/LayerLoadedListener", DoNotGenerateAcw = true)]
internal class ILayerLoadedListenerInvoker : Java.Lang.Object, ILayerLoadedListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_layers_LayerLoadedListener = new XAPeerMembers("com/yandex/mapkit/layers/LayerLoadedListener", typeof(ILayerLoadedListenerInvoker));

	private static Delegate? cb_onLayerLoaded_OnLayerLoaded_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_layers_LayerLoadedListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_layers_LayerLoadedListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_layers_LayerLoadedListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_layers_LayerLoadedListener.ManagedPeerType;

	public ILayerLoadedListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnLayerLoadedHandler()
	{
		if ((object)cb_onLayerLoaded_OnLayerLoaded_V == null)
		{
			cb_onLayerLoaded_OnLayerLoaded_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnLayerLoaded));
		}
		return cb_onLayerLoaded_OnLayerLoaded_V;
	}

	private static void n_OnLayerLoaded(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ILayerLoadedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayerLoaded();
	}

	public unsafe void OnLayerLoaded()
	{
		_members_com_yandex_mapkit_layers_LayerLoadedListener.InstanceMethods.InvokeAbstractVoidMethod("onLayerLoaded.()V", this, null);
	}
}
