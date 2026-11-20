using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/Attributes", DoNotGenerateAcw = true)]
internal class IAttributesInvoker : Java.Lang.Object, IAttributes, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_org_xml_sax_Attributes = new XAPeerMembers("org/xml/sax/Attributes", typeof(IAttributesInvoker));

	private static Delegate? cb_getLength_GetLength_I;

	private static Delegate? cb_getIndex_GetIndex_Ljava_lang_String_Ljava_lang_String__I;

	private static Delegate? cb_getIndex_GetIndex_Ljava_lang_String__I;

	private static Delegate? cb_getLocalName_GetLocalName_I_Ljava_lang_String_;

	private static Delegate? cb_getQName_GetQName_I_Ljava_lang_String_;

	private static Delegate? cb_getType_GetType_I_Ljava_lang_String_;

	private static Delegate? cb_getType_GetType_Ljava_lang_String_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getType_GetType_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getURI_GetURI_I_Ljava_lang_String_;

	private static Delegate? cb_getValue_GetValue_I_Ljava_lang_String_;

	private static Delegate? cb_getValue_GetValue_Ljava_lang_String_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getValue_GetValue_Ljava_lang_String__Ljava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_org_xml_sax_Attributes;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_org_xml_sax_Attributes.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_org_xml_sax_Attributes.ManagedPeerType;

	public unsafe int Length => _members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractInt32Method("getLength.()I", this, null);

	public IAttributesInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetLengthHandler()
	{
		return new _JniMarshal_PP_I(n_GetLength);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLength(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length;
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

	private static Delegate GetGetIndex_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_I(n_GetIndex_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIndex_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_uri, nint native_localName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributes? attributes = Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uri = JNIEnv.GetString(native_uri, JniHandleOwnership.DoNotTransfer);
			string localName = JNIEnv.GetString(native_localName, JniHandleOwnership.DoNotTransfer);
			return attributes.GetIndex(uri, localName);
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

	public unsafe int GetIndex(string? uri, string? localName)
	{
		nint num = JNIEnv.NewString(uri);
		nint num2 = JNIEnv.NewString(localName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return _members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractInt32Method("getIndex.(Ljava/lang/String;Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetGetIndex_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetIndex_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIndex_Ljava_lang_String_(nint jnienv, nint native__this, nint native_qName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributes? attributes = Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string qName = JNIEnv.GetString(native_qName, JniHandleOwnership.DoNotTransfer);
			return attributes.GetIndex(qName);
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

	public unsafe int GetIndex(string? qName)
	{
		nint num = JNIEnv.NewString(qName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractInt32Method("getIndex.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetLocalName_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetLocalName_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLocalName_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLocalName(index));
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

	public unsafe string? GetLocalName(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getLocalName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetQName_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetQName_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetQName_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetQName(index));
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

	public unsafe string? GetQName(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getQName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetType_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetType_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetType(index));
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

	public unsafe string? GetType(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getType.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetType_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_L(n_GetType_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_uri, nint native_localName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributes? attributes = Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uri = JNIEnv.GetString(native_uri, JniHandleOwnership.DoNotTransfer);
			string localName = JNIEnv.GetString(native_localName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(attributes.GetType(uri, localName));
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

	public unsafe string? GetType(string? uri, string? localName)
	{
		nint num = JNIEnv.NewString(uri);
		nint num2 = JNIEnv.NewString(localName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getType.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetGetType_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetType_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType_Ljava_lang_String_(nint jnienv, nint native__this, nint native_qName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributes? attributes = Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string qName = JNIEnv.GetString(native_qName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(attributes.GetType(qName));
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

	public unsafe string? GetType(string? qName)
	{
		nint num = JNIEnv.NewString(qName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getType.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetURI_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetURI_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetURI_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetURI(index));
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

	public unsafe string? GetURI(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getURI.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetValue_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetValue_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetValue(index));
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

	public unsafe string? GetValue(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getValue.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetValue_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_L(n_GetValue_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetValue_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_uri, nint native_localName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributes? attributes = Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uri = JNIEnv.GetString(native_uri, JniHandleOwnership.DoNotTransfer);
			string localName = JNIEnv.GetString(native_localName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(attributes.GetValue(uri, localName));
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

	public unsafe string? GetValue(string? uri, string? localName)
	{
		nint num = JNIEnv.NewString(uri);
		nint num2 = JNIEnv.NewString(localName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getValue.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetGetValue_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetValue_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetValue_Ljava_lang_String_(nint jnienv, nint native__this, nint native_qName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributes? attributes = Java.Lang.Object.GetObject<IAttributes>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string qName = JNIEnv.GetString(native_qName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(attributes.GetValue(qName));
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

	public unsafe string? GetValue(string? qName)
	{
		nint num = JNIEnv.NewString(qName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members_org_xml_sax_Attributes.InstanceMethods.InvokeAbstractObjectMethod("getValue.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
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
