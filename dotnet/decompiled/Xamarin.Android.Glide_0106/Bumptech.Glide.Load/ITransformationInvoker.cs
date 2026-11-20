using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Bumptech.Glide.Load.Engine;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/Transformation", DoNotGenerateAcw = true)]
internal class ITransformationInvoker : Java.Lang.Object, ITransformation, IKey, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_Key = new XAPeerMembers("com/bumptech/glide/load/Key", typeof(ITransformationInvoker));

	private static readonly JniPeerMembers _members_com_bumptech_glide_load_Transformation = new XAPeerMembers("com/bumptech/glide/load/Transformation", typeof(ITransformationInvoker));

	private static Delegate? cb_transform_Transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_Resource_II_Lcom_bumptech_glide_load_engine_Resource_;

	private static Delegate? cb_equals_Equals_Ljava_lang_Object__Z;

	private static Delegate? cb_hashCode_GetHashCode_I;

	private static Delegate? cb_updateDiskCacheKey_UpdateDiskCacheKey_Ljava_security_MessageDigest__V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_Transformation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_Transformation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_Transformation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_Transformation.ManagedPeerType;

	public ITransformationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetTransform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_Resource_IIHandler()
	{
		return new _JniMarshal_PPLLII_L(n_Transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_Resource_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_Resource_II(nint jnienv, nint native__this, nint native_p0, nint native_p1, int p2, int p3)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITransformation? transformation = Java.Lang.Object.GetObject<ITransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p4 = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			IResource p5 = Java.Lang.Object.GetObject<IResource>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transformation.Transform(p4, p5, p2, p3));
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

	public unsafe IResource Transform(Context p0, IResource p1, int p2, int p3)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			ptr[2] = new JniArgumentValue(p2);
			ptr[3] = new JniArgumentValue(p3);
			return Java.Lang.Object.GetObject<IResource>(_members_com_bumptech_glide_load_Transformation.InstanceMethods.InvokeAbstractObjectMethod("transform.(Landroid/content/Context;Lcom/bumptech/glide/load/engine/Resource;II)Lcom/bumptech/glide/load/engine/Resource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetEquals_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Equals_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Equals_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITransformation? transformation = Java.Lang.Object.GetObject<ITransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return transformation.Equals(p) ? ((sbyte)1) : ((sbyte)0);
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

	public new unsafe bool Equals(Java.Lang.Object? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members_com_bumptech_glide_load_Key.InstanceMethods.InvokeAbstractBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetGetHashCodeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHashCode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHashCode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ITransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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

	public new unsafe int GetHashCode()
	{
		return _members_com_bumptech_glide_load_Key.InstanceMethods.InvokeAbstractInt32Method("hashCode.()I", this, null);
	}

	private static Delegate GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateDiskCacheKey_Ljava_security_MessageDigest_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateDiskCacheKey_Ljava_security_MessageDigest_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ITransformation? transformation = Java.Lang.Object.GetObject<ITransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MessageDigest p = Java.Lang.Object.GetObject<MessageDigest>(native_p0, JniHandleOwnership.DoNotTransfer);
			transformation.UpdateDiskCacheKey(p);
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

	public unsafe void UpdateDiskCacheKey(MessageDigest p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_bumptech_glide_load_Key.InstanceMethods.InvokeAbstractVoidMethod("updateDiskCacheKey.(Ljava/security/MessageDigest;)V", this, ptr);
		}
		finally
		{
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
