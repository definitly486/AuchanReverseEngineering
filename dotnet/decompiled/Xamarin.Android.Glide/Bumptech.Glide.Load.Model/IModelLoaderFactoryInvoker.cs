using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/ModelLoaderFactory", DoNotGenerateAcw = true)]
internal class IModelLoaderFactoryInvoker : Java.Lang.Object, IModelLoaderFactory, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_model_ModelLoaderFactory = new XAPeerMembers("com/bumptech/glide/load/model/ModelLoaderFactory", typeof(IModelLoaderFactoryInvoker));

	private static Delegate? cb_build_Build_Lcom_bumptech_glide_load_model_MultiModelLoaderFactory__Lcom_bumptech_glide_load_model_ModelLoader_;

	private static Delegate? cb_teardown_Teardown_V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_model_ModelLoaderFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_model_ModelLoaderFactory;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_model_ModelLoaderFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_model_ModelLoaderFactory.ManagedPeerType;

	public IModelLoaderFactoryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetBuild_Lcom_bumptech_glide_load_model_MultiModelLoaderFactory_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Build_Lcom_bumptech_glide_load_model_MultiModelLoaderFactory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Build_Lcom_bumptech_glide_load_model_MultiModelLoaderFactory_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IModelLoaderFactory? modelLoaderFactory = Java.Lang.Object.GetObject<IModelLoaderFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MultiModelLoaderFactory p = Java.Lang.Object.GetObject<MultiModelLoaderFactory>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(modelLoaderFactory.Build(p));
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

	public unsafe IModelLoader Build(MultiModelLoaderFactory p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IModelLoader>(_members_com_bumptech_glide_load_model_ModelLoaderFactory.InstanceMethods.InvokeAbstractObjectMethod("build.(Lcom/bumptech/glide/load/model/MultiModelLoaderFactory;)Lcom/bumptech/glide/load/model/ModelLoader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetTeardownHandler()
	{
		return new global::_JniMarshal_PP_V(n_Teardown);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Teardown(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IModelLoaderFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Teardown();
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

	public unsafe void Teardown()
	{
		_members_com_bumptech_glide_load_model_ModelLoaderFactory.InstanceMethods.InvokeAbstractVoidMethod("teardown.()V", this, null);
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
