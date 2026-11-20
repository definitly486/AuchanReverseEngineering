using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Model", DoNotGenerateAcw = true)]
internal class IModelInvoker : Java.Lang.Object, IModel, IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_Model = new XAPeerMembers("com/yandex/mapkit/map/Model", typeof(IModelInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkPresentation = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkPresentation", typeof(IModelInvoker));

	private static Delegate? cb_getModelStyle_GetModelStyle_Lcom_yandex_mapkit_map_ModelStyle_;

	private static Delegate? cb_setModelStyle_SetModelStyle_Lcom_yandex_mapkit_map_ModelStyle__V;

	private static Delegate? cb_setData_SetData_Lcom_yandex_runtime_DataProviderWithId_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_remove_Remove_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_Model.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_Model;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_Model.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_Model.ManagedPeerType;

	public unsafe ModelStyle ModelStyle
	{
		get
		{
			return Java.Lang.Object.GetObject<ModelStyle>(_members_com_yandex_mapkit_map_Model.InstanceMethods.InvokeAbstractObjectMethod("getModelStyle.()Lcom/yandex/mapkit/map/ModelStyle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_Model.InstanceMethods.InvokeAbstractVoidMethod("setModelStyle.(Lcom/yandex/mapkit/map/ModelStyle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IModelInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetModelStyleHandler()
	{
		if ((object)cb_getModelStyle_GetModelStyle_Lcom_yandex_mapkit_map_ModelStyle_ == null)
		{
			cb_getModelStyle_GetModelStyle_Lcom_yandex_mapkit_map_ModelStyle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetModelStyle));
		}
		return cb_getModelStyle_GetModelStyle_Lcom_yandex_mapkit_map_ModelStyle_;
	}

	private static nint n_GetModelStyle(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ModelStyle);
	}

	private static Delegate GetSetModelStyle_Lcom_yandex_mapkit_map_ModelStyle_Handler()
	{
		if ((object)cb_setModelStyle_SetModelStyle_Lcom_yandex_mapkit_map_ModelStyle__V == null)
		{
			cb_setModelStyle_SetModelStyle_Lcom_yandex_mapkit_map_ModelStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetModelStyle_Lcom_yandex_mapkit_map_ModelStyle_));
		}
		return cb_setModelStyle_SetModelStyle_Lcom_yandex_mapkit_map_ModelStyle__V;
	}

	private static void n_SetModelStyle_Lcom_yandex_mapkit_map_ModelStyle_(nint jnienv, nint native__this, nint native_p0)
	{
		IModel? model = Java.Lang.Object.GetObject<IModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ModelStyle modelStyle = Java.Lang.Object.GetObject<ModelStyle>(native_p0, JniHandleOwnership.DoNotTransfer);
		model.ModelStyle = modelStyle;
	}

	private static Delegate GetSetData_Lcom_yandex_runtime_DataProviderWithId_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setData_SetData_Lcom_yandex_runtime_DataProviderWithId_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setData_SetData_Lcom_yandex_runtime_DataProviderWithId_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetData_Lcom_yandex_runtime_DataProviderWithId_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setData_SetData_Lcom_yandex_runtime_DataProviderWithId_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetData_Lcom_yandex_runtime_DataProviderWithId_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IModel? model = Java.Lang.Object.GetObject<IModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDataProviderWithId p = Java.Lang.Object.GetObject<IDataProviderWithId>(native_p0, JniHandleOwnership.DoNotTransfer);
		ICallback p2 = Java.Lang.Object.GetObject<ICallback>(native_p1, JniHandleOwnership.DoNotTransfer);
		model.SetData(p, p2);
	}

	public unsafe void SetData(IDataProviderWithId p0, ICallback p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_map_Model.InstanceMethods.InvokeAbstractVoidMethod("setData.(Lcom/yandex/runtime/DataProviderWithId;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
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
		return Java.Lang.Object.GetObject<IModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
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
		Java.Lang.Object.GetObject<IModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
	}

	public unsafe void Remove()
	{
		_members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}
}
