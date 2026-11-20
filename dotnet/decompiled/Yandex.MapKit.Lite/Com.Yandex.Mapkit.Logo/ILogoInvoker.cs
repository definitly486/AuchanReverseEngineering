using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Logo;

[Register("com/yandex/mapkit/logo/Logo", DoNotGenerateAcw = true)]
internal class ILogoInvoker : Java.Lang.Object, ILogo, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_logo_Logo = new XAPeerMembers("com/yandex/mapkit/logo/Logo", typeof(ILogoInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_setAlignment_SetAlignment_Lcom_yandex_mapkit_logo_Alignment__V;

	private static Delegate? cb_setPadding_SetPadding_Lcom_yandex_mapkit_logo_Padding__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_logo_Logo.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_logo_Logo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_logo_Logo.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_logo_Logo.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_logo_Logo.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public ILogoInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<ILogo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetSetAlignment_Lcom_yandex_mapkit_logo_Alignment_Handler()
	{
		if ((object)cb_setAlignment_SetAlignment_Lcom_yandex_mapkit_logo_Alignment__V == null)
		{
			cb_setAlignment_SetAlignment_Lcom_yandex_mapkit_logo_Alignment__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetAlignment_Lcom_yandex_mapkit_logo_Alignment_));
		}
		return cb_setAlignment_SetAlignment_Lcom_yandex_mapkit_logo_Alignment__V;
	}

	private static void n_SetAlignment_Lcom_yandex_mapkit_logo_Alignment_(nint jnienv, nint native__this, nint native_p0)
	{
		ILogo? logo = Java.Lang.Object.GetObject<ILogo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Alignment alignment = Java.Lang.Object.GetObject<Alignment>(native_p0, JniHandleOwnership.DoNotTransfer);
		logo.SetAlignment(alignment);
	}

	public unsafe void SetAlignment(Alignment p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_logo_Logo.InstanceMethods.InvokeAbstractVoidMethod("setAlignment.(Lcom/yandex/mapkit/logo/Alignment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetPadding_Lcom_yandex_mapkit_logo_Padding_Handler()
	{
		if ((object)cb_setPadding_SetPadding_Lcom_yandex_mapkit_logo_Padding__V == null)
		{
			cb_setPadding_SetPadding_Lcom_yandex_mapkit_logo_Padding__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPadding_Lcom_yandex_mapkit_logo_Padding_));
		}
		return cb_setPadding_SetPadding_Lcom_yandex_mapkit_logo_Padding__V;
	}

	private static void n_SetPadding_Lcom_yandex_mapkit_logo_Padding_(nint jnienv, nint native__this, nint native_p0)
	{
		ILogo? logo = Java.Lang.Object.GetObject<ILogo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Padding padding = Java.Lang.Object.GetObject<Padding>(native_p0, JniHandleOwnership.DoNotTransfer);
		logo.SetPadding(padding);
	}

	public unsafe void SetPadding(Padding p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_logo_Logo.InstanceMethods.InvokeAbstractVoidMethod("setPadding.(Lcom/yandex/mapkit/logo/Padding;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
