using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/TreeMap", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "K", "V" })]
public class TreeMap : AbstractMap, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/TreeMap", typeof(TreeMap));

	private static Delegate? cb_clone_Clone_Ljava_lang_Object_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected TreeMap(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetCloneHandler()
	{
		return new _JniMarshal_PP_L(n_Clone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TreeMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

	[Register("clone", "()Ljava/lang/Object;", "GetCloneHandler")]
	public new unsafe virtual Java.Lang.Object Clone()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
