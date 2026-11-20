using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KType", DoNotGenerateAcw = true)]
internal class IKTypeInvoker : Java.Lang.Object, IKType, IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_reflect_KAnnotatedElement = new XAPeerMembers("kotlin/reflect/KAnnotatedElement", typeof(IKTypeInvoker));

	private static readonly JniPeerMembers _members_kotlin_reflect_KType = new XAPeerMembers("kotlin/reflect/KType", typeof(IKTypeInvoker));

	private static Delegate? cb_getArguments_GetArguments_Ljava_util_List_;

	private static Delegate? cb_getClassifier_GetClassifier_Lkotlin_reflect_KClassifier_;

	private static Delegate? cb_isMarkedNullable_IsMarkedNullable_Z;

	private static Delegate? cb_getAnnotations_GetAnnotations_Ljava_util_List_;

	private static nint java_class_ref => _members_kotlin_reflect_KType.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_reflect_KType;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_reflect_KType.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_reflect_KType.ManagedPeerType;

	public unsafe IList<KTypeProjection> Arguments => JavaList<KTypeProjection>.FromJniHandle(_members_kotlin_reflect_KType.InstanceMethods.InvokeAbstractObjectMethod("getArguments.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IKClassifier? Classifier => Java.Lang.Object.GetObject<IKClassifier>(_members_kotlin_reflect_KType.InstanceMethods.InvokeAbstractObjectMethod("getClassifier.()Lkotlin/reflect/KClassifier;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsMarkedNullable => _members_kotlin_reflect_KType.InstanceMethods.InvokeAbstractBooleanMethod("isMarkedNullable.()Z", this, null);

	public unsafe IList<IAnnotation> Annotations => JavaList<IAnnotation>.FromJniHandle(_members_kotlin_reflect_KAnnotatedElement.InstanceMethods.InvokeAbstractObjectMethod("getAnnotations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IKTypeInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetArgumentsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetArguments);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetArguments(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<KTypeProjection>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Arguments);
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

	private static Delegate GetGetClassifierHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetClassifier);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetClassifier(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IKType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Classifier);
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

	private static Delegate GetIsMarkedNullableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsMarkedNullable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsMarkedNullable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsMarkedNullable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetAnnotationsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAnnotations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnnotations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IAnnotation>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Annotations);
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
