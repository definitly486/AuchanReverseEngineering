using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/Layer", DoNotGenerateAcw = true)]
internal class ILayerInvoker : Java.Lang.Object, ILayer, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_layers_Layer = new XAPeerMembers("com/yandex/mapkit/layers/Layer", typeof(ILayerInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_dataSourceLayer_DataSourceLayer_Lcom_yandex_mapkit_layers_DataSourceLayer_;

	private static Delegate? cb_remove_Remove_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_layers_Layer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_layers_Layer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_layers_Layer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_layers_Layer.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_layers_Layer.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public ILayerInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<ILayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetDataSourceLayerHandler()
	{
		if ((object)cb_dataSourceLayer_DataSourceLayer_Lcom_yandex_mapkit_layers_DataSourceLayer_ == null)
		{
			cb_dataSourceLayer_DataSourceLayer_Lcom_yandex_mapkit_layers_DataSourceLayer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DataSourceLayer));
		}
		return cb_dataSourceLayer_DataSourceLayer_Lcom_yandex_mapkit_layers_DataSourceLayer_;
	}

	private static nint n_DataSourceLayer(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ILayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataSourceLayer());
	}

	public unsafe IDataSourceLayer DataSourceLayer()
	{
		return Java.Lang.Object.GetObject<IDataSourceLayer>(_members_com_yandex_mapkit_layers_Layer.InstanceMethods.InvokeAbstractObjectMethod("dataSourceLayer.()Lcom/yandex/mapkit/layers/DataSourceLayer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
		Java.Lang.Object.GetObject<ILayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
	}

	public unsafe void Remove()
	{
		_members_com_yandex_mapkit_layers_Layer.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}
}
