using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang.Annotation;

[Register("java/lang/annotation/Annotation", DoNotGenerateAcw = true)]
internal class IAnnotationInvoker : Object, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_lang_annotation_Annotation = new XAPeerMembers("java/lang/annotation/Annotation", typeof(IAnnotationInvoker));

	private static Delegate? cb_annotationType_AnnotationType_Ljava_lang_Class_;

	private static Delegate? cb_equals_Equals_Ljava_lang_Object__Z;

	private static Delegate? cb_hashCode_GetHashCode_I;

	private static Delegate? cb_toString_ToString_Ljava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_lang_annotation_Annotation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_lang_annotation_Annotation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_lang_annotation_Annotation.ManagedPeerType;

	public IAnnotationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAnnotationTypeHandler()
	{
		return new _JniMarshal_PP_L(n_AnnotationType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AnnotationType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Object.GetObject<IAnnotation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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

	public unsafe Class? AnnotationType()
	{
		return Object.GetObject<Class>(_members_java_lang_annotation_Annotation.InstanceMethods.InvokeAbstractObjectMethod("annotationType.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetEquals_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_B(n_Equals_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Equals_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_obj)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAnnotation? annotation = Object.GetObject<IAnnotation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Object obj = Object.GetObject<Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return annotation.Equals(obj) ? ((sbyte)1) : ((sbyte)0);
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

	public new unsafe bool Equals(Object? obj)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			return _members_java_lang_annotation_Annotation.InstanceMethods.InvokeAbstractBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
		}
	}

	private static Delegate GetGetHashCodeHandler()
	{
		return new _JniMarshal_PP_I(n_GetHashCode);
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
			return Object.GetObject<IAnnotation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
		return _members_java_lang_annotation_Annotation.InstanceMethods.InvokeAbstractInt32Method("hashCode.()I", this, null);
	}

	private static Delegate GetToStringHandler()
	{
		return new _JniMarshal_PP_L(n_ToString);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToString(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Object.GetObject<IAnnotation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

	public new unsafe string? ToString()
	{
		return JNIEnv.GetString(_members_java_lang_annotation_Annotation.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
