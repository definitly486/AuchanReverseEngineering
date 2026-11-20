using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/Enumeration", DoNotGenerateAcw = true)]
internal class IEnumerationInvoker : Java.Lang.Object, IEnumeration, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_Enumeration = new XAPeerMembers("java/util/Enumeration", typeof(IEnumerationInvoker));

	private static Delegate? cb_hasMoreElements_HasMoreElements_Z;

	private static Delegate? cb_nextElement_NextElement_Ljava_lang_Object_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_Enumeration;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_Enumeration.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_Enumeration.ManagedPeerType;

	public unsafe bool HasMoreElements => _members_java_util_Enumeration.InstanceMethods.InvokeAbstractBooleanMethod("hasMoreElements.()Z", this, null);

	public IEnumerationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetHasMoreElementsHandler()
	{
		return new _JniMarshal_PP_B(n_HasMoreElements);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasMoreElements(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IEnumeration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasMoreElements ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetNextElementHandler()
	{
		return new _JniMarshal_PP_L(n_NextElement);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NextElement(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumeration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextElement());
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

	public unsafe Java.Lang.Object? NextElement()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_Enumeration.InstanceMethods.InvokeAbstractObjectMethod("nextElement.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
