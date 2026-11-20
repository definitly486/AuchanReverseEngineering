using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/DataSourceListener", DoNotGenerateAcw = true)]
internal class IDataSourceListenerInvoker : Java.Lang.Object, IDataSourceListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_layers_DataSourceListener = new XAPeerMembers("com/yandex/mapkit/layers/DataSourceListener", typeof(IDataSourceListenerInvoker));

	private static Delegate? cb_onDataSourceUpdated_OnDataSourceUpdated_Lcom_yandex_mapkit_layers_BaseDataSource__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_layers_DataSourceListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_layers_DataSourceListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_layers_DataSourceListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_layers_DataSourceListener.ManagedPeerType;

	public IDataSourceListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnDataSourceUpdated_Lcom_yandex_mapkit_layers_BaseDataSource_Handler()
	{
		if ((object)cb_onDataSourceUpdated_OnDataSourceUpdated_Lcom_yandex_mapkit_layers_BaseDataSource__V == null)
		{
			cb_onDataSourceUpdated_OnDataSourceUpdated_Lcom_yandex_mapkit_layers_BaseDataSource__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDataSourceUpdated_Lcom_yandex_mapkit_layers_BaseDataSource_));
		}
		return cb_onDataSourceUpdated_OnDataSourceUpdated_Lcom_yandex_mapkit_layers_BaseDataSource__V;
	}

	private static void n_OnDataSourceUpdated_Lcom_yandex_mapkit_layers_BaseDataSource_(nint jnienv, nint native__this, nint native_p0)
	{
		IDataSourceListener? dataSourceListener = Java.Lang.Object.GetObject<IDataSourceListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IBaseDataSource p = Java.Lang.Object.GetObject<IBaseDataSource>(native_p0, JniHandleOwnership.DoNotTransfer);
		dataSourceListener.OnDataSourceUpdated(p);
	}

	public unsafe void OnDataSourceUpdated(IBaseDataSource p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_layers_DataSourceListener.InstanceMethods.InvokeAbstractVoidMethod("onDataSourceUpdated.(Lcom/yandex/mapkit/layers/BaseDataSource;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
