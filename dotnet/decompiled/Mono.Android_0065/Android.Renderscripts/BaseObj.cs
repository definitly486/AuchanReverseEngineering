using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Renderscripts;

[ObsoletedOSPlatform("android31.0", "This class is obsoleted in this android platform")]
[Register("android/renderscript/BaseObj", DoNotGenerateAcw = true)]
public class BaseObj : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/renderscript/BaseObj", typeof(BaseObj));

	private static Delegate? cb_destroy_Destroy_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	protected BaseObj(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android31.0")]
	private static Delegate GetDestroyHandler()
	{
		return new _JniMarshal_PP_V(n_Destroy);
	}

	[ObsoletedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Destroy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BaseObj>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Destroy();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[ObsoletedOSPlatform("android31.0")]
	public unsafe virtual void Destroy()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("destroy.()V", this, null);
	}
}
