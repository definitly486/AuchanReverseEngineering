using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/XMLReader", DoNotGenerateAcw = true)]
internal class IXMLReaderInvoker : Java.Lang.Object, IXMLReader, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_org_xml_sax_XMLReader = new XAPeerMembers("org/xml/sax/XMLReader", typeof(IXMLReaderInvoker));

	private static Delegate? cb_getContentHandler_GetContentHandler_Lorg_xml_sax_ContentHandler_;

	private static Delegate? cb_setContentHandler_SetContentHandler_Lorg_xml_sax_ContentHandler__V;

	private static Delegate? cb_getDTDHandler_GetDTDHandler_Lorg_xml_sax_DTDHandler_;

	private static Delegate? cb_setDTDHandler_SetDTDHandler_Lorg_xml_sax_DTDHandler__V;

	private static Delegate? cb_getEntityResolver_GetEntityResolver_Lorg_xml_sax_EntityResolver_;

	private static Delegate? cb_setEntityResolver_SetEntityResolver_Lorg_xml_sax_EntityResolver__V;

	private static Delegate? cb_getErrorHandler_GetErrorHandler_Lorg_xml_sax_ErrorHandler_;

	private static Delegate? cb_setErrorHandler_SetErrorHandler_Lorg_xml_sax_ErrorHandler__V;

	private static Delegate? cb_getFeature_GetFeature_Ljava_lang_String__Z;

	private static Delegate? cb_getProperty_GetProperty_Ljava_lang_String__Ljava_lang_Object_;

	private static Delegate? cb_parse_Parse_Ljava_lang_String__V;

	private static Delegate? cb_parse_Parse_Lorg_xml_sax_InputSource__V;

	private static Delegate? cb_setFeature_SetFeature_Ljava_lang_String_Z_V;

	private static Delegate? cb_setProperty_SetProperty_Ljava_lang_String_Ljava_lang_Object__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_org_xml_sax_XMLReader;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_org_xml_sax_XMLReader.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_org_xml_sax_XMLReader.ManagedPeerType;

	public unsafe IContentHandler? ContentHandler
	{
		get
		{
			return Java.Lang.Object.GetObject<IContentHandler>(_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractObjectMethod("getContentHandler.()Lorg/xml/sax/ContentHandler;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractVoidMethod("setContentHandler.(Lorg/xml/sax/ContentHandler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe IDTDHandler? DTDHandler
	{
		get
		{
			return Java.Lang.Object.GetObject<IDTDHandler>(_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractObjectMethod("getDTDHandler.()Lorg/xml/sax/DTDHandler;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractVoidMethod("setDTDHandler.(Lorg/xml/sax/DTDHandler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe IEntityResolver? EntityResolver
	{
		get
		{
			return Java.Lang.Object.GetObject<IEntityResolver>(_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractObjectMethod("getEntityResolver.()Lorg/xml/sax/EntityResolver;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractVoidMethod("setEntityResolver.(Lorg/xml/sax/EntityResolver;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe IErrorHandler? ErrorHandler
	{
		get
		{
			return Java.Lang.Object.GetObject<IErrorHandler>(_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractObjectMethod("getErrorHandler.()Lorg/xml/sax/ErrorHandler;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractVoidMethod("setErrorHandler.(Lorg/xml/sax/ErrorHandler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public IXMLReaderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetContentHandlerHandler()
	{
		return new _JniMarshal_PP_L(n_GetContentHandler);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentHandler(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentHandler);
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

	private static Delegate GetSetContentHandler_Lorg_xml_sax_ContentHandler_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetContentHandler_Lorg_xml_sax_ContentHandler_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentHandler_Lorg_xml_sax_ContentHandler_(nint jnienv, nint native__this, nint native_handler)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContentHandler contentHandler = Java.Lang.Object.GetObject<IContentHandler>(native_handler, JniHandleOwnership.DoNotTransfer);
			iXMLReader.ContentHandler = contentHandler;
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

	private static Delegate GetGetDTDHandlerHandler()
	{
		return new _JniMarshal_PP_L(n_GetDTDHandler);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDTDHandler(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DTDHandler);
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

	private static Delegate GetSetDTDHandler_Lorg_xml_sax_DTDHandler_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetDTDHandler_Lorg_xml_sax_DTDHandler_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDTDHandler_Lorg_xml_sax_DTDHandler_(nint jnienv, nint native__this, nint native_handler)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDTDHandler dTDHandler = Java.Lang.Object.GetObject<IDTDHandler>(native_handler, JniHandleOwnership.DoNotTransfer);
			iXMLReader.DTDHandler = dTDHandler;
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

	private static Delegate GetGetEntityResolverHandler()
	{
		return new _JniMarshal_PP_L(n_GetEntityResolver);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEntityResolver(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EntityResolver);
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

	private static Delegate GetSetEntityResolver_Lorg_xml_sax_EntityResolver_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetEntityResolver_Lorg_xml_sax_EntityResolver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEntityResolver_Lorg_xml_sax_EntityResolver_(nint jnienv, nint native__this, nint native_resolver)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IEntityResolver entityResolver = Java.Lang.Object.GetObject<IEntityResolver>(native_resolver, JniHandleOwnership.DoNotTransfer);
			iXMLReader.EntityResolver = entityResolver;
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

	private static Delegate GetGetErrorHandlerHandler()
	{
		return new _JniMarshal_PP_L(n_GetErrorHandler);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetErrorHandler(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorHandler);
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

	private static Delegate GetSetErrorHandler_Lorg_xml_sax_ErrorHandler_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetErrorHandler_Lorg_xml_sax_ErrorHandler_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetErrorHandler_Lorg_xml_sax_ErrorHandler_(nint jnienv, nint native__this, nint native_handler)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IErrorHandler errorHandler = Java.Lang.Object.GetObject<IErrorHandler>(native_handler, JniHandleOwnership.DoNotTransfer);
			iXMLReader.ErrorHandler = errorHandler;
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

	private static Delegate GetGetFeature_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_B(n_GetFeature_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetFeature_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return iXMLReader.GetFeature(name) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool GetFeature(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractBooleanMethod("getFeature.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetProperty_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetProperty_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetProperty_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iXMLReader.GetProperty(name));
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

	public unsafe Java.Lang.Object? GetProperty(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractObjectMethod("getProperty.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetParse_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_V(n_Parse_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Parse_Ljava_lang_String_(nint jnienv, nint native__this, nint native_systemId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string systemId = JNIEnv.GetString(native_systemId, JniHandleOwnership.DoNotTransfer);
			iXMLReader.Parse(systemId);
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

	public unsafe void Parse(string? systemId)
	{
		nint num = JNIEnv.NewString(systemId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractVoidMethod("parse.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetParse_Lorg_xml_sax_InputSource_Handler()
	{
		return new _JniMarshal_PPL_V(n_Parse_Lorg_xml_sax_InputSource_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Parse_Lorg_xml_sax_InputSource_(nint jnienv, nint native__this, nint native_input)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InputSource input = Java.Lang.Object.GetObject<InputSource>(native_input, JniHandleOwnership.DoNotTransfer);
			iXMLReader.Parse(input);
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

	public unsafe void Parse(InputSource? input)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(input?.Handle ?? IntPtr.Zero);
			_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractVoidMethod("parse.(Lorg/xml/sax/InputSource;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(input);
		}
	}

	private static Delegate GetSetFeature_Ljava_lang_String_ZHandler()
	{
		return new _JniMarshal_PPLB_V(n_SetFeature_Ljava_lang_String_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFeature_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_name, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			iXMLReader.SetFeature(name, value);
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

	public unsafe void SetFeature(string? name, bool value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractVoidMethod("setFeature.(Ljava/lang/String;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetProperty_Ljava_lang_String_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPLL_V(n_SetProperty_Ljava_lang_String_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProperty_Ljava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXMLReader? iXMLReader = Java.Lang.Object.GetObject<IXMLReader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			iXMLReader.SetProperty(name, value);
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

	public unsafe void SetProperty(string? name, Java.Lang.Object? value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members_org_xml_sax_XMLReader.InstanceMethods.InvokeAbstractVoidMethod("setProperty.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
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
