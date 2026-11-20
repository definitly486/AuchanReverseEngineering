using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/BaseDataSource", DoNotGenerateAcw = true)]
internal class IBaseDataSourceInvoker : Java.Lang.Object, IBaseDataSource, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_layers_BaseDataSource = new XAPeerMembers("com/yandex/mapkit/layers/BaseDataSource", typeof(IBaseDataSourceInvoker));

	private static Delegate? cb_getId_GetId_Ljava_lang_String_;

	private static Delegate? cb_isValid_IsValid_Z;

	private static nint java_class_ref => _members_com_yandex_mapkit_layers_BaseDataSource.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_layers_BaseDataSource;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_layers_BaseDataSource.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_layers_BaseDataSource.ManagedPeerType;

	public unsafe string Id => JNIEnv.GetString(_members_com_yandex_mapkit_layers_BaseDataSource.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsValid => _members_com_yandex_mapkit_layers_BaseDataSource.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IBaseDataSourceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetIdHandler()
	{
		if ((object)cb_getId_GetId_Ljava_lang_String_ == null)
		{
			cb_getId_GetId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetId));
		}
		return cb_getId_GetId_Ljava_lang_String_;
	}

	private static nint n_GetId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IBaseDataSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
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
		return Java.Lang.Object.GetObject<IBaseDataSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}
}
