using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/RequestProcessor$Request", DoNotGenerateAcw = true)]
internal class IRequestProcessorRequestInvoker : Java.Lang.Object, IRequestProcessorRequest, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/RequestProcessor$Request", typeof(IRequestProcessorRequestInvoker));

	private nint class_ref;

	private static Delegate? cb_getParameters;

	private nint id_getParameters;

	private static Delegate? cb_getTargetOutputConfigIds;

	private nint id_getTargetOutputConfigIds;

	private static Delegate? cb_getTemplateId;

	private nint id_getTemplateId;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public IConfig Parameters
	{
		get
		{
			if (id_getParameters == IntPtr.Zero)
			{
				id_getParameters = JNIEnv.GetMethodID(class_ref, "getParameters", "()Landroidx/camera/core/impl/Config;");
			}
			return Java.Lang.Object.GetObject<IConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getParameters), JniHandleOwnership.TransferLocalRef);
		}
	}

	public IList<Integer> TargetOutputConfigIds
	{
		get
		{
			if (id_getTargetOutputConfigIds == IntPtr.Zero)
			{
				id_getTargetOutputConfigIds = JNIEnv.GetMethodID(class_ref, "getTargetOutputConfigIds", "()Ljava/util/List;");
			}
			return JavaList<Integer>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getTargetOutputConfigIds), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int TemplateId
	{
		get
		{
			if (id_getTemplateId == IntPtr.Zero)
			{
				id_getTemplateId = JNIEnv.GetMethodID(class_ref, "getTemplateId", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getTemplateId);
		}
	}

	public static IRequestProcessorRequest? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IRequestProcessorRequest>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.RequestProcessor.Request'.");
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public IRequestProcessorRequestInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetParametersHandler()
	{
		if ((object)cb_getParameters == null)
		{
			cb_getParameters = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetParameters));
		}
		return cb_getParameters;
	}

	private static nint n_GetParameters(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IRequestProcessorRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parameters);
	}

	private static Delegate GetGetTargetOutputConfigIdsHandler()
	{
		if ((object)cb_getTargetOutputConfigIds == null)
		{
			cb_getTargetOutputConfigIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetOutputConfigIds));
		}
		return cb_getTargetOutputConfigIds;
	}

	private static nint n_GetTargetOutputConfigIds(nint jnienv, nint native__this)
	{
		return JavaList<Integer>.ToLocalJniHandle(Java.Lang.Object.GetObject<IRequestProcessorRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetOutputConfigIds);
	}

	private static Delegate GetGetTemplateIdHandler()
	{
		if ((object)cb_getTemplateId == null)
		{
			cb_getTemplateId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTemplateId));
		}
		return cb_getTemplateId;
	}

	private static int n_GetTemplateId(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IRequestProcessorRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TemplateId;
	}
}
