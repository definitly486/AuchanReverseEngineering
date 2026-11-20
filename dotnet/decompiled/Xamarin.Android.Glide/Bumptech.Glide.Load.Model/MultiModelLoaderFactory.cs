using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Core.Util;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/MultiModelLoaderFactory", DoNotGenerateAcw = true)]
public class MultiModelLoaderFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/model/MultiModelLoaderFactory", typeof(MultiModelLoaderFactory));

	private static Delegate? cb_build_Build_Ljava_lang_Class_Ljava_lang_Class__Lcom_bumptech_glide_load_model_ModelLoader_;

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

	protected MultiModelLoaderFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/core/util/Pools$Pool;)V", "")]
	public unsafe MultiModelLoaderFactory(Pools.IPool throwableListPool)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((throwableListPool == null) ? IntPtr.Zero : ((Java.Lang.Object)throwableListPool).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/core/util/Pools$Pool;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/core/util/Pools$Pool;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(throwableListPool);
		}
	}

	private static Delegate GetBuild_Ljava_lang_Class_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Build_Ljava_lang_Class_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Build_Ljava_lang_Class_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_modelClass, nint native_dataClass)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MultiModelLoaderFactory? multiModelLoaderFactory = Java.Lang.Object.GetObject<MultiModelLoaderFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			Class dataClass = Java.Lang.Object.GetObject<Class>(native_dataClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(multiModelLoaderFactory.Build(modelClass, dataClass));
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

	[Register("build", "(Ljava/lang/Class;Ljava/lang/Class;)Lcom/bumptech/glide/load/model/ModelLoader;", "GetBuild_Ljava_lang_Class_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "Model", "Data" })]
	public unsafe virtual IModelLoader Build(Class modelClass, Class dataClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dataClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IModelLoader>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.(Ljava/lang/Class;Ljava/lang/Class;)Lcom/bumptech/glide/load/model/ModelLoader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(modelClass);
			GC.KeepAlive(dataClass);
		}
	}
}
