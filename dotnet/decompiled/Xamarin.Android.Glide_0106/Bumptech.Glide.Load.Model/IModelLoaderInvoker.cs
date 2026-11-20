using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/ModelLoader", DoNotGenerateAcw = true)]
internal class IModelLoaderInvoker : Java.Lang.Object, IModelLoader, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_model_ModelLoader = new XAPeerMembers("com/bumptech/glide/load/model/ModelLoader", typeof(IModelLoaderInvoker));

	private static Delegate? cb_buildLoadData_BuildLoadData_Ljava_lang_Object_IILcom_bumptech_glide_load_Options__Lcom_bumptech_glide_load_model_ModelLoader_LoadData_;

	private static Delegate? cb_handles_Handles_Ljava_lang_Object__Z;

	private static nint java_class_ref => _members_com_bumptech_glide_load_model_ModelLoader.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_model_ModelLoader;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_model_ModelLoader.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_model_ModelLoader.ManagedPeerType;

	public IModelLoaderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetBuildLoadData_Ljava_lang_Object_IILcom_bumptech_glide_load_Options_Handler()
	{
		return new _JniMarshal_PPLIIL_L(n_BuildLoadData_Ljava_lang_Object_IILcom_bumptech_glide_load_Options_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_BuildLoadData_Ljava_lang_Object_IILcom_bumptech_glide_load_Options_(nint jnienv, nint native__this, nint native_p0, int p1, int p2, nint native_p3)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IModelLoader? modelLoader = Java.Lang.Object.GetObject<IModelLoader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p3 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			Options p4 = Java.Lang.Object.GetObject<Options>(native_p3, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(modelLoader.BuildLoadData(p3, p1, p2, p4));
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

	public unsafe ModelLoaderLoadData? BuildLoadData(Java.Lang.Object p0, int p1, int p2, Options p3)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ModelLoaderLoadData>(_members_com_bumptech_glide_load_model_ModelLoader.InstanceMethods.InvokeAbstractObjectMethod("buildLoadData.(Ljava/lang/Object;IILcom/bumptech/glide/load/Options;)Lcom/bumptech/glide/load/model/ModelLoader$LoadData;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p3);
		}
	}

	private static Delegate GetHandles_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Handles_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Handles_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IModelLoader? modelLoader = Java.Lang.Object.GetObject<IModelLoader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return modelLoader.Handles(p) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Handles(Java.Lang.Object p0)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_com_bumptech_glide_load_model_ModelLoader.InstanceMethods.InvokeAbstractBooleanMethod("handles.(Ljava/lang/Object;)Z", this, ptr);
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
