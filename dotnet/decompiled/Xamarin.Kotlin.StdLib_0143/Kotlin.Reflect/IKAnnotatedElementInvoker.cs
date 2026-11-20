using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KAnnotatedElement", DoNotGenerateAcw = true)]
internal class IKAnnotatedElementInvoker : Java.Lang.Object, IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_reflect_KAnnotatedElement = new XAPeerMembers("kotlin/reflect/KAnnotatedElement", typeof(IKAnnotatedElementInvoker));

	private static Delegate? cb_getAnnotations_GetAnnotations_Ljava_util_List_;

	private static nint java_class_ref => _members_kotlin_reflect_KAnnotatedElement.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_reflect_KAnnotatedElement;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_reflect_KAnnotatedElement.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_reflect_KAnnotatedElement.ManagedPeerType;

	public unsafe IList<IAnnotation> Annotations => JavaList<IAnnotation>.FromJniHandle(_members_kotlin_reflect_KAnnotatedElement.InstanceMethods.InvokeAbstractObjectMethod("getAnnotations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IKAnnotatedElementInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			return JavaList<IAnnotation>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKAnnotatedElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Annotations);
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
