using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/Locator", DoNotGenerateAcw = true)]
internal class ILocatorInvoker : Java.Lang.Object, ILocator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_org_xml_sax_Locator = new XAPeerMembers("org/xml/sax/Locator", typeof(ILocatorInvoker));

	private static Delegate? cb_getColumnNumber_GetColumnNumber_I;

	private static Delegate? cb_getLineNumber_GetLineNumber_I;

	private static Delegate? cb_getPublicId_GetPublicId_Ljava_lang_String_;

	private static Delegate? cb_getSystemId_GetSystemId_Ljava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_org_xml_sax_Locator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_org_xml_sax_Locator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_org_xml_sax_Locator.ManagedPeerType;

	public unsafe int ColumnNumber => _members_org_xml_sax_Locator.InstanceMethods.InvokeAbstractInt32Method("getColumnNumber.()I", this, null);

	public unsafe int LineNumber => _members_org_xml_sax_Locator.InstanceMethods.InvokeAbstractInt32Method("getLineNumber.()I", this, null);

	public unsafe string? PublicId => JNIEnv.GetString(_members_org_xml_sax_Locator.InstanceMethods.InvokeAbstractObjectMethod("getPublicId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? SystemId => JNIEnv.GetString(_members_org_xml_sax_Locator.InstanceMethods.InvokeAbstractObjectMethod("getSystemId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public ILocatorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetColumnNumberHandler()
	{
		return new _JniMarshal_PP_I(n_GetColumnNumber);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColumnNumber(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ILocator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnNumber;
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

	private static Delegate GetGetLineNumberHandler()
	{
		return new _JniMarshal_PP_I(n_GetLineNumber);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLineNumber(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ILocator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineNumber;
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

	private static Delegate GetGetPublicIdHandler()
	{
		return new _JniMarshal_PP_L(n_GetPublicId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPublicId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILocator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PublicId);
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

	private static Delegate GetGetSystemIdHandler()
	{
		return new _JniMarshal_PP_L(n_GetSystemId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSystemId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILocator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemId);
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
