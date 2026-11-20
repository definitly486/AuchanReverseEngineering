using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KCallable", DoNotGenerateAcw = true)]
internal class IKCallableInvoker : Java.Lang.Object, IKCallable, IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_reflect_KAnnotatedElement = new XAPeerMembers("kotlin/reflect/KAnnotatedElement", typeof(IKCallableInvoker));

	private static readonly JniPeerMembers _members_kotlin_reflect_KCallable = new XAPeerMembers("kotlin/reflect/KCallable", typeof(IKCallableInvoker));

	private static Delegate? cb_isAbstract_IsAbstract_Z;

	private static Delegate? cb_isFinal_IsFinal_Z;

	private static Delegate? cb_isOpen_IsOpen_Z;

	private static Delegate? cb_isSuspend_IsSuspend_Z;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getParameters_GetParameters_Ljava_util_List_;

	private static Delegate? cb_getReturnType_GetReturnType_Lkotlin_reflect_KType_;

	private static Delegate? cb_getTypeParameters_GetTypeParameters_Ljava_util_List_;

	private static Delegate? cb_getVisibility_GetVisibility_Lkotlin_reflect_KVisibility_;

	private static Delegate? cb_call_Call_arrayLjava_lang_Object__Ljava_lang_Object_;

	private static Delegate? cb_callBy_CallBy_Ljava_util_Map__Ljava_lang_Object_;

	private static Delegate? cb_getAnnotations_GetAnnotations_Ljava_util_List_;

	private static nint java_class_ref => _members_kotlin_reflect_KCallable.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_reflect_KCallable;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_reflect_KCallable.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_reflect_KCallable.ManagedPeerType;

	public unsafe bool IsAbstract => _members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractBooleanMethod("isAbstract.()Z", this, null);

	public unsafe bool IsFinal => _members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractBooleanMethod("isFinal.()Z", this, null);

	public unsafe bool IsOpen => _members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractBooleanMethod("isOpen.()Z", this, null);

	public unsafe bool IsSuspend => _members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractBooleanMethod("isSuspend.()Z", this, null);

	public unsafe string Name => JNIEnv.GetString(_members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IKParameter> Parameters => JavaList<IKParameter>.FromJniHandle(_members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractObjectMethod("getParameters.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IKType ReturnType => Java.Lang.Object.GetObject<IKType>(_members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractObjectMethod("getReturnType.()Lkotlin/reflect/KType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IKTypeParameter> TypeParameters => JavaList<IKTypeParameter>.FromJniHandle(_members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractObjectMethod("getTypeParameters.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe KVisibility? Visibility => Java.Lang.Object.GetObject<KVisibility>(_members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractObjectMethod("getVisibility.()Lkotlin/reflect/KVisibility;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IAnnotation> Annotations => JavaList<IAnnotation>.FromJniHandle(_members_kotlin_reflect_KAnnotatedElement.InstanceMethods.InvokeAbstractObjectMethod("getAnnotations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IKCallableInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsAbstractHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAbstract);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAbstract(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAbstract ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsFinalHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFinal);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFinal(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFinal ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsOpenHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsOpen);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsOpen(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOpen ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsSuspendHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSuspend);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSuspend(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSuspend ? ((sbyte)1) : ((sbyte)0);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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

	private static Delegate GetGetParametersHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetParameters);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParameters(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IKParameter>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parameters);
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

	private static Delegate GetGetReturnTypeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetReturnType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetReturnType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReturnType);
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

	private static Delegate GetGetTypeParametersHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTypeParameters);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTypeParameters(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IKTypeParameter>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TypeParameters);
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

	private static Delegate GetGetVisibilityHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetVisibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility);
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

	private static Delegate GetCall_arrayLjava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Call_arrayLjava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Call_arrayLjava_lang_Object_(nint jnienv, nint native__this, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IKCallable? iKCallable = Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
			nint result = JNIEnv.ToLocalJniHandle(iKCallable.Call(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_args);
			}
			return result;
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

	public unsafe Java.Lang.Object? Call(params Java.Lang.Object[] args)
	{
		nint num = JNIEnv.NewArray(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractObjectMethod("call.([Ljava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (args != null)
			{
				JNIEnv.CopyArray(num, args);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetCallBy_Ljava_util_Map_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_CallBy_Ljava_util_Map_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CallBy_Ljava_util_Map_(nint jnienv, nint native__this, nint native_args)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IKCallable? iKCallable = Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDictionary args = JavaDictionary.FromJniHandle(native_args, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iKCallable.CallBy(args));
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

	public unsafe Java.Lang.Object? CallBy(IDictionary args)
	{
		nint num = JavaDictionary.ToLocalJniHandle(args);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlin_reflect_KCallable.InstanceMethods.InvokeAbstractObjectMethod("callBy.(Ljava/util/Map;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(args);
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
			return JavaList<IAnnotation>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKCallable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Annotations);
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
