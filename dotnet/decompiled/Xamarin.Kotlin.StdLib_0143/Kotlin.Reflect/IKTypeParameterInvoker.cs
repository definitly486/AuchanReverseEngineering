using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KTypeParameter", DoNotGenerateAcw = true)]
internal class IKTypeParameterInvoker : Java.Lang.Object, IKTypeParameter, IKClassifier, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_reflect_KClassifier = new XAPeerMembers("kotlin/reflect/KClassifier", typeof(IKTypeParameterInvoker));

	private static readonly JniPeerMembers _members_kotlin_reflect_KTypeParameter = new XAPeerMembers("kotlin/reflect/KTypeParameter", typeof(IKTypeParameterInvoker));

	private static Delegate? cb_isReified_IsReified_Z;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getUpperBounds_GetUpperBounds_Ljava_util_List_;

	private static Delegate? cb_getVariance_GetVariance_Lkotlin_reflect_KVariance_;

	private static nint java_class_ref => _members_kotlin_reflect_KTypeParameter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_reflect_KTypeParameter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_reflect_KTypeParameter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_reflect_KTypeParameter.ManagedPeerType;

	public unsafe bool IsReified => _members_kotlin_reflect_KTypeParameter.InstanceMethods.InvokeAbstractBooleanMethod("isReified.()Z", this, null);

	public unsafe string Name => JNIEnv.GetString(_members_kotlin_reflect_KTypeParameter.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IKType> UpperBounds => JavaList<IKType>.FromJniHandle(_members_kotlin_reflect_KTypeParameter.InstanceMethods.InvokeAbstractObjectMethod("getUpperBounds.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe KVariance Variance => Java.Lang.Object.GetObject<KVariance>(_members_kotlin_reflect_KTypeParameter.InstanceMethods.InvokeAbstractObjectMethod("getVariance.()Lkotlin/reflect/KVariance;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IKTypeParameterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsReifiedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsReified);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsReified(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKTypeParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsReified ? ((sbyte)1) : ((sbyte)0);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IKTypeParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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

	private static Delegate GetGetUpperBoundsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetUpperBounds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetUpperBounds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IKType>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKTypeParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpperBounds);
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

	private static Delegate GetGetVarianceHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetVariance);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetVariance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IKTypeParameter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Variance);
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
