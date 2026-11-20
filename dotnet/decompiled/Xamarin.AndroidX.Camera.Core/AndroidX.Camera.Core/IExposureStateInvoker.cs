using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ExposureState", DoNotGenerateAcw = true)]
internal class IExposureStateInvoker : Java.Lang.Object, IExposureState, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ExposureState", typeof(IExposureStateInvoker));

	private nint class_ref;

	private static Delegate? cb_getExposureCompensationIndex;

	private nint id_getExposureCompensationIndex;

	private static Delegate? cb_getExposureCompensationRange;

	private nint id_getExposureCompensationRange;

	private static Delegate? cb_getExposureCompensationStep;

	private nint id_getExposureCompensationStep;

	private static Delegate? cb_isExposureCompensationSupported;

	private nint id_isExposureCompensationSupported;

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

	public int ExposureCompensationIndex
	{
		get
		{
			if (id_getExposureCompensationIndex == IntPtr.Zero)
			{
				id_getExposureCompensationIndex = JNIEnv.GetMethodID(class_ref, "getExposureCompensationIndex", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getExposureCompensationIndex);
		}
	}

	public Android.Util.Range ExposureCompensationRange
	{
		get
		{
			if (id_getExposureCompensationRange == IntPtr.Zero)
			{
				id_getExposureCompensationRange = JNIEnv.GetMethodID(class_ref, "getExposureCompensationRange", "()Landroid/util/Range;");
			}
			return Java.Lang.Object.GetObject<Android.Util.Range>(JNIEnv.CallObjectMethod(base.Handle, id_getExposureCompensationRange), JniHandleOwnership.TransferLocalRef);
		}
	}

	public Rational ExposureCompensationStep
	{
		get
		{
			if (id_getExposureCompensationStep == IntPtr.Zero)
			{
				id_getExposureCompensationStep = JNIEnv.GetMethodID(class_ref, "getExposureCompensationStep", "()Landroid/util/Rational;");
			}
			return Java.Lang.Object.GetObject<Rational>(JNIEnv.CallObjectMethod(base.Handle, id_getExposureCompensationStep), JniHandleOwnership.TransferLocalRef);
		}
	}

	public bool IsExposureCompensationSupported
	{
		get
		{
			if (id_isExposureCompensationSupported == IntPtr.Zero)
			{
				id_isExposureCompensationSupported = JNIEnv.GetMethodID(class_ref, "isExposureCompensationSupported", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_isExposureCompensationSupported);
		}
	}

	public static IExposureState? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IExposureState>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ExposureState'.");
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

	public IExposureStateInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetExposureCompensationIndexHandler()
	{
		if ((object)cb_getExposureCompensationIndex == null)
		{
			cb_getExposureCompensationIndex = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetExposureCompensationIndex));
		}
		return cb_getExposureCompensationIndex;
	}

	private static int n_GetExposureCompensationIndex(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IExposureState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExposureCompensationIndex;
	}

	private static Delegate GetGetExposureCompensationRangeHandler()
	{
		if ((object)cb_getExposureCompensationRange == null)
		{
			cb_getExposureCompensationRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExposureCompensationRange));
		}
		return cb_getExposureCompensationRange;
	}

	private static nint n_GetExposureCompensationRange(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExposureState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExposureCompensationRange);
	}

	private static Delegate GetGetExposureCompensationStepHandler()
	{
		if ((object)cb_getExposureCompensationStep == null)
		{
			cb_getExposureCompensationStep = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExposureCompensationStep));
		}
		return cb_getExposureCompensationStep;
	}

	private static nint n_GetExposureCompensationStep(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExposureState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExposureCompensationStep);
	}

	private static Delegate GetIsExposureCompensationSupportedHandler()
	{
		if ((object)cb_isExposureCompensationSupported == null)
		{
			cb_isExposureCompensationSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsExposureCompensationSupported));
		}
		return cb_isExposureCompensationSupported;
	}

	private static bool n_IsExposureCompensationSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IExposureState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsExposureCompensationSupported;
	}
}
