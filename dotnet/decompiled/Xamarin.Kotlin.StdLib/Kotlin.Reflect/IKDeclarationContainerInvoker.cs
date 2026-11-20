using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KDeclarationContainer", DoNotGenerateAcw = true)]
internal class IKDeclarationContainerInvoker : Java.Lang.Object, IKDeclarationContainer, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_reflect_KDeclarationContainer = new XAPeerMembers("kotlin/reflect/KDeclarationContainer", typeof(IKDeclarationContainerInvoker));

	private static Delegate? cb_getMembers_GetMembers_Ljava_util_Collection_;

	private static nint java_class_ref => _members_kotlin_reflect_KDeclarationContainer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_reflect_KDeclarationContainer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_reflect_KDeclarationContainer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_reflect_KDeclarationContainer.ManagedPeerType;

	public unsafe ICollection<IKCallable> Members => JavaCollection<IKCallable>.FromJniHandle(_members_kotlin_reflect_KDeclarationContainer.InstanceMethods.InvokeAbstractObjectMethod("getMembers.()Ljava/util/Collection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IKDeclarationContainerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetMembersHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMembers);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMembers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaCollection<IKCallable>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKDeclarationContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Members);
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
