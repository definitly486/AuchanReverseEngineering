using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Parcelable$Creator", DoNotGenerateAcw = true)]
internal class IParcelableCreatorInvoker : Java.Lang.Object, IParcelableCreator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_os_Parcelable_Creator = new XAPeerMembers("android/os/Parcelable$Creator", typeof(IParcelableCreatorInvoker));

	private static Delegate? cb_createFromParcel_CreateFromParcel_Landroid_os_Parcel__Ljava_lang_Object_;

	private static Delegate? cb_newArray_NewArray_I_arrayLjava_lang_Object_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_os_Parcelable_Creator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_os_Parcelable_Creator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_os_Parcelable_Creator.ManagedPeerType;

	public IParcelableCreatorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetCreateFromParcel_Landroid_os_Parcel_Handler()
	{
		return new _JniMarshal_PPL_L(n_CreateFromParcel_Landroid_os_Parcel_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateFromParcel_Landroid_os_Parcel_(nint jnienv, nint native__this, nint native_source)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IParcelableCreator? parcelableCreator = Java.Lang.Object.GetObject<IParcelableCreator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel source = Java.Lang.Object.GetObject<Parcel>(native_source, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(parcelableCreator.CreateFromParcel(source));
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

	public unsafe Java.Lang.Object? CreateFromParcel(Parcel? source)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_android_os_Parcelable_Creator.InstanceMethods.InvokeAbstractObjectMethod("createFromParcel.(Landroid/os/Parcel;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(source);
		}
	}

	private static Delegate GetNewArray_IHandler()
	{
		return new _JniMarshal_PPI_L(n_NewArray_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NewArray_I(nint jnienv, nint native__this, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IParcelableCreator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewArray(size));
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

	public unsafe Java.Lang.Object[]? NewArray(int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		return (Java.Lang.Object[])JNIEnv.GetArray(_members_android_os_Parcelable_Creator.InstanceMethods.InvokeAbstractObjectMethod("newArray.(I)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
