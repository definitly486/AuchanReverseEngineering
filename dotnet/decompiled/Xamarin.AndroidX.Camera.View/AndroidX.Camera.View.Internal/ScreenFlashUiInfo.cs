using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.View.Internal;

[Register("androidx/camera/view/internal/ScreenFlashUiInfo", DoNotGenerateAcw = true)]
public class ScreenFlashUiInfo : Java.Lang.Object
{
	[Register("androidx/camera/view/internal/ScreenFlashUiInfo$ProviderType", DoNotGenerateAcw = true)]
	public sealed class ProviderType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/internal/ScreenFlashUiInfo$ProviderType", typeof(ProviderType));

		[Register("PREVIEW_VIEW")]
		public static ProviderType? PreviewView => Java.Lang.Object.GetObject<ProviderType>(_members.StaticFields.GetObjectValue("PREVIEW_VIEW.Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SCREEN_FLASH_VIEW")]
		public static ProviderType? ScreenFlashView => Java.Lang.Object.GetObject<ProviderType>(_members.StaticFields.GetObjectValue("SCREEN_FLASH_VIEW.Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ProviderType(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;", "")]
		public unsafe static ProviderType? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<ProviderType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;", "")]
		public unsafe static ProviderType[]? Values()
		{
			return (ProviderType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ProviderType));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/internal/ScreenFlashUiInfo", typeof(ScreenFlashUiInfo));

	private static Delegate? cb_getScreenFlash;

	private static Delegate? cb_getProviderType;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual ImageCapture.IScreenFlash? ScreenFlash
	{
		[Register("getScreenFlash", "()Landroidx/camera/core/ImageCapture$ScreenFlash;", "GetGetScreenFlashHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ImageCapture.IScreenFlash>(_members.InstanceMethods.InvokeVirtualObjectMethod("getScreenFlash.()Landroidx/camera/core/ImageCapture$ScreenFlash;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ScreenFlashUiInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;Landroidx/camera/core/ImageCapture$ScreenFlash;)V", "")]
	public unsafe ScreenFlashUiInfo(ProviderType providerType, ImageCapture.IScreenFlash? screenFlash)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(providerType?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((screenFlash == null) ? IntPtr.Zero : ((Java.Lang.Object)screenFlash).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;Landroidx/camera/core/ImageCapture$ScreenFlash;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;Landroidx/camera/core/ImageCapture$ScreenFlash;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(providerType);
			GC.KeepAlive(screenFlash);
		}
	}

	private static Delegate GetGetScreenFlashHandler()
	{
		if ((object)cb_getScreenFlash == null)
		{
			cb_getScreenFlash = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetScreenFlash));
		}
		return cb_getScreenFlash;
	}

	private static nint n_GetScreenFlash(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScreenFlashUiInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScreenFlash);
	}

	private static Delegate GetGetProviderTypeHandler()
	{
		if ((object)cb_getProviderType == null)
		{
			cb_getProviderType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetProviderType));
		}
		return cb_getProviderType;
	}

	private static nint n_GetProviderType(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScreenFlashUiInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetProviderType());
	}

	[Register("getProviderType", "()Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;", "GetGetProviderTypeHandler")]
	public unsafe virtual ProviderType GetProviderType()
	{
		return Java.Lang.Object.GetObject<ProviderType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getProviderType.()Landroidx/camera/view/internal/ScreenFlashUiInfo$ProviderType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
