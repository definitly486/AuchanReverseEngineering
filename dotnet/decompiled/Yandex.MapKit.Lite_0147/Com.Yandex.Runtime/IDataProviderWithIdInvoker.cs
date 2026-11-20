using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime;

[Register("com/yandex/runtime/DataProviderWithId", DoNotGenerateAcw = true)]
internal class IDataProviderWithIdInvoker : Java.Lang.Object, IDataProviderWithId, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_runtime_DataProviderWithId = new XAPeerMembers("com/yandex/runtime/DataProviderWithId", typeof(IDataProviderWithIdInvoker));

	private static Delegate? cb_load_Load_arrayB;

	private static Delegate? cb_providerId_ProviderId_Ljava_lang_String_;

	private static nint java_class_ref => _members_com_yandex_runtime_DataProviderWithId.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_runtime_DataProviderWithId;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_runtime_DataProviderWithId.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_runtime_DataProviderWithId.ManagedPeerType;

	public IDataProviderWithIdInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetLoadHandler()
	{
		if ((object)cb_load_Load_arrayB == null)
		{
			cb_load_Load_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Load));
		}
		return cb_load_Load_arrayB;
	}

	private static nint n_Load(nint jnienv, nint native__this)
	{
		return JNIEnv.NewArray(Java.Lang.Object.GetObject<IDataProviderWithId>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Load());
	}

	public unsafe byte[] Load()
	{
		return (byte[])JNIEnv.GetArray(_members_com_yandex_runtime_DataProviderWithId.InstanceMethods.InvokeAbstractObjectMethod("load.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
	}

	private static Delegate GetProviderIdHandler()
	{
		if ((object)cb_providerId_ProviderId_Ljava_lang_String_ == null)
		{
			cb_providerId_ProviderId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ProviderId));
		}
		return cb_providerId_ProviderId_Ljava_lang_String_;
	}

	private static nint n_ProviderId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IDataProviderWithId>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProviderId());
	}

	public unsafe string ProviderId()
	{
		return JNIEnv.GetString(_members_com_yandex_runtime_DataProviderWithId.InstanceMethods.InvokeAbstractObjectMethod("providerId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
