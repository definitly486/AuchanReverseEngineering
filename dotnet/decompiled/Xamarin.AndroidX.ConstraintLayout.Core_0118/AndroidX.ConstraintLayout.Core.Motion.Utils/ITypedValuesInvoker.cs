using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/TypedValues", DoNotGenerateAcw = true)]
internal class ITypedValuesInvoker : Java.Lang.Object, ITypedValues, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_constraintlayout_core_motion_utils_TypedValues = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/TypedValues", typeof(ITypedValuesInvoker));

	private static Delegate? cb_getId_GetId_Ljava_lang_String__I;

	private static Delegate? cb_setValue_SetValue_IZ_Z;

	private static Delegate? cb_setValue_SetValue_IF_Z;

	private static Delegate? cb_setValue_SetValue_II_Z;

	private static Delegate? cb_setValue_SetValue_ILjava_lang_String__Z;

	private static nint java_class_ref => _members_androidx_constraintlayout_core_motion_utils_TypedValues.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_core_motion_utils_TypedValues;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_constraintlayout_core_motion_utils_TypedValues.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_constraintlayout_core_motion_utils_TypedValues.ManagedPeerType;

	public ITypedValuesInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetId_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetId_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITypedValues? typedValues = Java.Lang.Object.GetObject<ITypedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return typedValues.GetId(p);
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

	public unsafe int GetId(string? p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_androidx_constraintlayout_core_motion_utils_TypedValues.InstanceMethods.InvokeAbstractInt32Method("getId.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetValue_IZHandler()
	{
		return new global::_JniMarshal_PPIB_B(n_SetValue_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_IZ(nint jnienv, nint native__this, int p0, sbyte native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITypedValues? typedValues = Java.Lang.Object.GetObject<ITypedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool p1 = native_p1 != 0;
			return typedValues.SetValue(p0, p1) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool SetValue(int p0, bool p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
		return _members_androidx_constraintlayout_core_motion_utils_TypedValues.InstanceMethods.InvokeAbstractBooleanMethod("setValue.(IZ)Z", this, ptr);
	}

	private static Delegate GetSetValue_IFHandler()
	{
		return new _JniMarshal_PPIF_B(n_SetValue_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_IF(nint jnienv, nint native__this, int p0, float p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ITypedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(p0, p1) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool SetValue(int p0, float p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		return _members_androidx_constraintlayout_core_motion_utils_TypedValues.InstanceMethods.InvokeAbstractBooleanMethod("setValue.(IF)Z", this, ptr);
	}

	private static Delegate GetSetValue_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_SetValue_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_II(nint jnienv, nint native__this, int p0, int p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ITypedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(p0, p1) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool SetValue(int p0, int p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		return _members_androidx_constraintlayout_core_motion_utils_TypedValues.InstanceMethods.InvokeAbstractBooleanMethod("setValue.(II)Z", this, ptr);
	}

	private static Delegate GetSetValue_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_SetValue_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_ILjava_lang_String_(nint jnienv, nint native__this, int p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITypedValues? typedValues = Java.Lang.Object.GetObject<ITypedValues>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			return typedValues.SetValue(p0, p1) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool SetValue(int p0, string? p1)
	{
		nint num = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(num);
			return _members_androidx_constraintlayout_core_motion_utils_TypedValues.InstanceMethods.InvokeAbstractBooleanMethod("setValue.(ILjava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
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
