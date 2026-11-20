using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine;

[Register("com/bumptech/glide/load/engine/Resource", DoNotGenerateAcw = true)]
internal class IResourceInvoker : Java.Lang.Object, IResource, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_Resource = new XAPeerMembers("com/bumptech/glide/load/engine/Resource", typeof(IResourceInvoker));

	private static Delegate? cb_getResourceClass_GetResourceClass_Ljava_lang_Class_;

	private static Delegate? cb_getSize_GetSize_I;

	private static Delegate? cb_get_Get_Ljava_lang_Object_;

	private static Delegate? cb_recycle_Recycle_V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_engine_Resource.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_Resource;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_Resource.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_Resource.ManagedPeerType;

	public unsafe Class ResourceClass => Java.Lang.Object.GetObject<Class>(_members_com_bumptech_glide_load_engine_Resource.InstanceMethods.InvokeAbstractObjectMethod("getResourceClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int Size => _members_com_bumptech_glide_load_engine_Resource.InstanceMethods.InvokeAbstractInt32Method("getSize.()I", this, null);

	public IResourceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetResourceClassHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetResourceClass);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResourceClass(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IResource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResourceClass);
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

	private static Delegate GetGetSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IResource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size;
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

	private static Delegate GetGetHandler()
	{
		return new global::_JniMarshal_PP_L(n_Get);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IResource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get());
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

	public unsafe Java.Lang.Object Get()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_bumptech_glide_load_engine_Resource.InstanceMethods.InvokeAbstractObjectMethod("get.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRecycleHandler()
	{
		return new global::_JniMarshal_PP_V(n_Recycle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Recycle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IResource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Recycle();
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

	public unsafe void Recycle()
	{
		_members_com_bumptech_glide_load_engine_Resource.InstanceMethods.InvokeAbstractVoidMethod("recycle.()V", this, null);
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
