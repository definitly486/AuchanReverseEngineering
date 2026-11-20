using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content.PM;

[Register("android/content/pm/PackageItemInfo", DoNotGenerateAcw = true)]
public class PackageItemInfo : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/PackageItemInfo", typeof(PackageItemInfo));

	private static Delegate? cb_loadLabel_LoadLabel_Landroid_content_pm_PackageManager__Ljava_lang_CharSequence_;

	private static Delegate? cb_writeToParcel_WriteToParcel_Landroid_os_Parcel_I_V;

	[Register("name")]
	public string? Name => JNIEnv.GetString(_members.InstanceFields.GetObjectValue("name.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);

	[Register("packageName")]
	public string? PackageName => JNIEnv.GetString(_members.InstanceFields.GetObjectValue("packageName.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PackageItemInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetLoadLabel_Landroid_content_pm_PackageManager_Handler()
	{
		return new _JniMarshal_PPL_L(n_LoadLabel_Landroid_content_pm_PackageManager_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_LoadLabel_Landroid_content_pm_PackageManager_(nint jnienv, nint native__this, nint native_pm)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PackageItemInfo? packageItemInfo = Java.Lang.Object.GetObject<PackageItemInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PackageManager pm = Java.Lang.Object.GetObject<PackageManager>(native_pm, JniHandleOwnership.DoNotTransfer);
			return CharSequence.ToLocalJniHandle(packageItemInfo.LoadLabelFormatted(pm));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe virtual ICharSequence LoadLabelFormatted(PackageManager pm)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pm?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("loadLabel.(Landroid/content/pm/PackageManager;)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(pm);
		}
	}

	public string LoadLabel(PackageManager pm)
	{
		return LoadLabelFormatted(pm)?.ToString();
	}

	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteToParcel_Landroid_os_Parcel_I(nint jnienv, nint native__this, nint native_dest, int native_parcelableFlags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PackageItemInfo? packageItemInfo = Java.Lang.Object.GetObject<PackageItemInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			packageItemInfo.WriteToParcel(dest, (ParcelableWriteFlags)native_parcelableFlags);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe virtual void WriteToParcel(Parcel? dest, ParcelableWriteFlags parcelableFlags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)parcelableFlags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
		}
	}
}
