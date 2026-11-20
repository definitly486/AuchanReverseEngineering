using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime;

[Register("com/yandex/runtime/Error", DoNotGenerateAcw = true)]
internal class IErrorInvoker : Java.Lang.Object, IError, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_runtime_Error = new XAPeerMembers("com/yandex/runtime/Error", typeof(IErrorInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static nint java_class_ref => _members_com_yandex_runtime_Error.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_runtime_Error;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_runtime_Error.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_runtime_Error.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_runtime_Error.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IErrorInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<IError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}
}
