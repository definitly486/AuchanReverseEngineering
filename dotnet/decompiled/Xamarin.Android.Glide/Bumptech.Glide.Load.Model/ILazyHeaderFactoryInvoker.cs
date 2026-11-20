using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/LazyHeaderFactory", DoNotGenerateAcw = true)]
internal class ILazyHeaderFactoryInvoker : Java.Lang.Object, ILazyHeaderFactory, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_model_LazyHeaderFactory = new XAPeerMembers("com/bumptech/glide/load/model/LazyHeaderFactory", typeof(ILazyHeaderFactoryInvoker));

	private static Delegate? cb_buildHeader_BuildHeader_Ljava_lang_String_;

	private static nint java_class_ref => _members_com_bumptech_glide_load_model_LazyHeaderFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_model_LazyHeaderFactory;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_model_LazyHeaderFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_model_LazyHeaderFactory.ManagedPeerType;

	public ILazyHeaderFactoryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetBuildHeaderHandler()
	{
		return new global::_JniMarshal_PP_L(n_BuildHeader);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_BuildHeader(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILazyHeaderFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BuildHeader());
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

	public unsafe string? BuildHeader()
	{
		return JNIEnv.GetString(_members_com_bumptech_glide_load_model_LazyHeaderFactory.InstanceMethods.InvokeAbstractObjectMethod("buildHeader.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
