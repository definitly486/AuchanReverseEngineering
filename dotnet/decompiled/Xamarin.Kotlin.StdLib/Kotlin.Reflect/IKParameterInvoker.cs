using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KParameter", DoNotGenerateAcw = true)]
internal class IKParameterInvoker : Java.Lang.Object, IKParameter, IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_reflect_KAnnotatedElement = new XAPeerMembers("kotlin/reflect/KAnnotatedElement", typeof(IKParameterInvoker));

	private static readonly JniPeerMembers _members_kotlin_reflect_KParameter = new XAPeerMembers("kotlin/reflect/KParameter", typeof(IKParameterInvoker));

	private static Delegate? cb_getIndex_GetIndex_I;

	private static Delegate? cb_isOptional_IsOptional_Z;

	private static Delegate? cb_isVararg_IsVararg_Z;

	private static Delegate? cb_getKind_GetKind_Lkotlin_reflect_KParameter_Kind_;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getType_GetType_Lkotlin_reflect_KType_;

	private static Delegate? cb_getAnnotations_GetAnnotations_Ljava_util_List_;

	private static nint java_class_ref => _members_kotlin_reflect_KParameter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_reflect_KParameter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_reflect_KParameter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_reflect_KParameter.ManagedPeerType;

	public unsafe int Index => _members_kotlin_reflect_KParameter.InstanceMethods.InvokeAbstractInt32Method("getIndex.()I", this, null);

	public unsafe bool IsOptional => _members_kotlin_reflect_KParameter.InstanceMethods.InvokeAbstractBooleanMethod("isOptional.()Z", this, null);

	public unsafe bool IsVararg => _members_kotlin_reflect_KParameter.InstanceMethods.InvokeAbstractBooleanMethod("isVararg.()Z", this, null);

	public unsafe KParameterKind Kind => Java.Lang.Object.GetObject<KParameterKind>(_members_kotlin_reflect_KParameter.InstanceMethods.InvokeAbstractObjectMethod("getKind.()Lkotlin/reflect/KParameter$Kind;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Name => JNIEnv.GetString(_members_kotlin_reflect_KParameter.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IKType Type => Java.Lang.Object.GetObject<IKType>(_members_kotlin_reflect_KParameter.InstanceMethods.InvokeAbstractObjectMethod("getType.()Lkotlin/reflect/KType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IAnnotation> Annotations => JavaList<IAnnotation>.FromJniHandle(_members_kotlin_reflect_KAnnotatedElement.InstanceMethods.InvokeAbstractObjectMethod("getAnnotations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IKParameterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetIndexHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetIndex);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIndex(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Index;
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

	private static Delegate GetIsOptionalHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsOptional);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsOptional(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOptional ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsVarargHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsVararg);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsVararg(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVararg ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetKindHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetKind);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKind(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IKParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Kind);
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

	private static Delegate GetGetNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IKParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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

	private static Delegate GetGetTypeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IKParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
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
			return JavaList<IAnnotation>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Annotations);
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
