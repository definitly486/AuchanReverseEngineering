using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Data;

[Register("com/bumptech/glide/load/data/DataRewinder$Factory", DoNotGenerateAcw = true)]
internal class IDataRewinderFactoryInvoker : Java.Lang.Object, IDataRewinderFactory, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_data_DataRewinder_Factory = new XAPeerMembers("com/bumptech/glide/load/data/DataRewinder$Factory", typeof(IDataRewinderFactoryInvoker));

	private static Delegate? cb_getDataClass_GetDataClass_Ljava_lang_Class_;

	private static Delegate? cb_build_Build_Ljava_lang_Object__Lcom_bumptech_glide_load_data_DataRewinder_;

	private static nint java_class_ref => _members_com_bumptech_glide_load_data_DataRewinder_Factory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_data_DataRewinder_Factory;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_data_DataRewinder_Factory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_data_DataRewinder_Factory.ManagedPeerType;

	public unsafe Class DataClass => Java.Lang.Object.GetObject<Class>(_members_com_bumptech_glide_load_data_DataRewinder_Factory.InstanceMethods.InvokeAbstractObjectMethod("getDataClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IDataRewinderFactoryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetDataClassHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDataClass);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDataClass(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDataRewinderFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataClass);
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

	private static Delegate GetBuild_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Build_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Build_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IDataRewinderFactory? dataRewinderFactory = Java.Lang.Object.GetObject<IDataRewinderFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(dataRewinderFactory.Build(p));
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

	public unsafe IDataRewinder Build(Java.Lang.Object p0)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IDataRewinder>(_members_com_bumptech_glide_load_data_DataRewinder_Factory.InstanceMethods.InvokeAbstractObjectMethod("build.(Ljava/lang/Object;)Lcom/bumptech/glide/load/data/DataRewinder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
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
