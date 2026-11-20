using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/RequestManagerTreeNode", DoNotGenerateAcw = true)]
internal class IRequestManagerTreeNodeInvoker : Java.Lang.Object, IRequestManagerTreeNode, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_manager_RequestManagerTreeNode = new XAPeerMembers("com/bumptech/glide/manager/RequestManagerTreeNode", typeof(IRequestManagerTreeNodeInvoker));

	private static Delegate? cb_getDescendants_GetDescendants_Ljava_util_Set_;

	private static nint java_class_ref => _members_com_bumptech_glide_manager_RequestManagerTreeNode.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_manager_RequestManagerTreeNode;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_manager_RequestManagerTreeNode.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_manager_RequestManagerTreeNode.ManagedPeerType;

	public unsafe ICollection<RequestManager> Descendants => JavaSet<RequestManager>.FromJniHandle(_members_com_bumptech_glide_manager_RequestManagerTreeNode.InstanceMethods.InvokeAbstractObjectMethod("getDescendants.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IRequestManagerTreeNodeInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetDescendantsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDescendants);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDescendants(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaSet<RequestManager>.ToLocalJniHandle(Java.Lang.Object.GetObject<IRequestManagerTreeNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Descendants);
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
