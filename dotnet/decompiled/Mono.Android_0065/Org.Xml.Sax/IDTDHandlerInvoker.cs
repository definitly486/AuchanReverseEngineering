using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/DTDHandler", DoNotGenerateAcw = true)]
internal class IDTDHandlerInvoker : Java.Lang.Object, IDTDHandler, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_org_xml_sax_DTDHandler = new XAPeerMembers("org/xml/sax/DTDHandler", typeof(IDTDHandlerInvoker));

	private static Delegate? cb_notationDecl_NotationDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_unparsedEntityDecl_UnparsedEntityDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_org_xml_sax_DTDHandler;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_org_xml_sax_DTDHandler.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_org_xml_sax_DTDHandler.ManagedPeerType;

	public IDTDHandlerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetNotationDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLL_V(n_NotationDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_NotationDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name, nint native_publicId, nint native_systemId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDTDHandler? iDTDHandler = Java.Lang.Object.GetObject<IDTDHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string publicId = JNIEnv.GetString(native_publicId, JniHandleOwnership.DoNotTransfer);
			string systemId = JNIEnv.GetString(native_systemId, JniHandleOwnership.DoNotTransfer);
			iDTDHandler.NotationDecl(name, publicId, systemId);
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

	public unsafe void NotationDecl(string? name, string? publicId, string? systemId)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(publicId);
		nint num3 = JNIEnv.NewString(systemId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			_members_org_xml_sax_DTDHandler.InstanceMethods.InvokeAbstractVoidMethod("notationDecl.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
		}
	}

	private static Delegate GetUnparsedEntityDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLLL_V(n_UnparsedEntityDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnparsedEntityDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name, nint native_publicId, nint native_systemId, nint native_notationName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDTDHandler? iDTDHandler = Java.Lang.Object.GetObject<IDTDHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string publicId = JNIEnv.GetString(native_publicId, JniHandleOwnership.DoNotTransfer);
			string systemId = JNIEnv.GetString(native_systemId, JniHandleOwnership.DoNotTransfer);
			string notationName = JNIEnv.GetString(native_notationName, JniHandleOwnership.DoNotTransfer);
			iDTDHandler.UnparsedEntityDecl(name, publicId, systemId, notationName);
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

	public unsafe void UnparsedEntityDecl(string? name, string? publicId, string? systemId, string? notationName)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(publicId);
		nint num3 = JNIEnv.NewString(systemId);
		nint num4 = JNIEnv.NewString(notationName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			_members_org_xml_sax_DTDHandler.InstanceMethods.InvokeAbstractVoidMethod("unparsedEntityDecl.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
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
