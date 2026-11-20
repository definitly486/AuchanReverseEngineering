using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/ContentHandler", DoNotGenerateAcw = true)]
internal class IContentHandlerInvoker : Java.Lang.Object, IContentHandler, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_org_xml_sax_ContentHandler = new XAPeerMembers("org/xml/sax/ContentHandler", typeof(IContentHandlerInvoker));

	private static Delegate? cb_characters_Characters_arrayCII_V;

	private static Delegate? cb_endDocument_EndDocument_V;

	private static Delegate? cb_endElement_EndElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_endPrefixMapping_EndPrefixMapping_Ljava_lang_String__V;

	private static Delegate? cb_ignorableWhitespace_IgnorableWhitespace_arrayCII_V;

	private static Delegate? cb_processingInstruction_ProcessingInstruction_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_setDocumentLocator_SetDocumentLocator_Lorg_xml_sax_Locator__V;

	private static Delegate? cb_skippedEntity_SkippedEntity_Ljava_lang_String__V;

	private static Delegate? cb_startDocument_StartDocument_V;

	private static Delegate? cb_startElement_StartElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lorg_xml_sax_Attributes__V;

	private static Delegate? cb_startPrefixMapping_StartPrefixMapping_Ljava_lang_String_Ljava_lang_String__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_org_xml_sax_ContentHandler;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_org_xml_sax_ContentHandler.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_org_xml_sax_ContentHandler.ManagedPeerType;

	public IContentHandlerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetCharacters_arrayCIIHandler()
	{
		return new _JniMarshal_PPLII_V(n_Characters_arrayCII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Characters_arrayCII(nint jnienv, nint native__this, nint native_ch, int start, int length)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char[] array = (char[])JNIEnv.GetArray(native_ch, JniHandleOwnership.DoNotTransfer, typeof(char));
			contentHandler.Characters(array, start, length);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_ch);
			}
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

	public unsafe void Characters(char[]? ch, int start, int length)
	{
		nint num = JNIEnv.NewArray(ch);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(length);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("characters.([CII)V", this, ptr);
		}
		finally
		{
			if (ch != null)
			{
				JNIEnv.CopyArray(num, ch);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(ch);
		}
	}

	private static Delegate GetEndDocumentHandler()
	{
		return new _JniMarshal_PP_V(n_EndDocument);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EndDocument(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndDocument();
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

	public unsafe void EndDocument()
	{
		_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("endDocument.()V", this, null);
	}

	private static Delegate GetEndElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLL_V(n_EndElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EndElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_uri, nint native_localName, nint native_qName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uri = JNIEnv.GetString(native_uri, JniHandleOwnership.DoNotTransfer);
			string localName = JNIEnv.GetString(native_localName, JniHandleOwnership.DoNotTransfer);
			string qName = JNIEnv.GetString(native_qName, JniHandleOwnership.DoNotTransfer);
			contentHandler.EndElement(uri, localName, qName);
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

	public unsafe void EndElement(string? uri, string? localName, string? qName)
	{
		nint num = JNIEnv.NewString(uri);
		nint num2 = JNIEnv.NewString(localName);
		nint num3 = JNIEnv.NewString(qName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("endElement.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
		}
	}

	private static Delegate GetEndPrefixMapping_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_V(n_EndPrefixMapping_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EndPrefixMapping_Ljava_lang_String_(nint jnienv, nint native__this, nint native_prefix)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			contentHandler.EndPrefixMapping(prefix);
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

	public unsafe void EndPrefixMapping(string? prefix)
	{
		nint num = JNIEnv.NewString(prefix);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("endPrefixMapping.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetIgnorableWhitespace_arrayCIIHandler()
	{
		return new _JniMarshal_PPLII_V(n_IgnorableWhitespace_arrayCII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_IgnorableWhitespace_arrayCII(nint jnienv, nint native__this, nint native_ch, int start, int length)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char[] array = (char[])JNIEnv.GetArray(native_ch, JniHandleOwnership.DoNotTransfer, typeof(char));
			contentHandler.IgnorableWhitespace(array, start, length);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_ch);
			}
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

	public unsafe void IgnorableWhitespace(char[]? ch, int start, int length)
	{
		nint num = JNIEnv.NewArray(ch);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(length);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("ignorableWhitespace.([CII)V", this, ptr);
		}
		finally
		{
			if (ch != null)
			{
				JNIEnv.CopyArray(num, ch);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(ch);
		}
	}

	private static Delegate GetProcessingInstruction_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_ProcessingInstruction_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ProcessingInstruction_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_target, nint native_data)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string target = JNIEnv.GetString(native_target, JniHandleOwnership.DoNotTransfer);
			string data = JNIEnv.GetString(native_data, JniHandleOwnership.DoNotTransfer);
			contentHandler.ProcessingInstruction(target, data);
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

	public unsafe void ProcessingInstruction(string? target, string? data)
	{
		nint num = JNIEnv.NewString(target);
		nint num2 = JNIEnv.NewString(data);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("processingInstruction.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetSetDocumentLocator_Lorg_xml_sax_Locator_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetDocumentLocator_Lorg_xml_sax_Locator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDocumentLocator_Lorg_xml_sax_Locator_(nint jnienv, nint native__this, nint native_locator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILocator documentLocator = Java.Lang.Object.GetObject<ILocator>(native_locator, JniHandleOwnership.DoNotTransfer);
			contentHandler.SetDocumentLocator(documentLocator);
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

	public unsafe void SetDocumentLocator(ILocator? locator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((locator == null) ? IntPtr.Zero : ((Java.Lang.Object)locator).Handle);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("setDocumentLocator.(Lorg/xml/sax/Locator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(locator);
		}
	}

	private static Delegate GetSkippedEntity_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_V(n_SkippedEntity_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SkippedEntity_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			contentHandler.SkippedEntity(name);
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

	public unsafe void SkippedEntity(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("skippedEntity.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetStartDocumentHandler()
	{
		return new _JniMarshal_PP_V(n_StartDocument);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartDocument(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartDocument();
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

	public unsafe void StartDocument()
	{
		_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("startDocument.()V", this, null);
	}

	private static Delegate GetStartElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lorg_xml_sax_Attributes_Handler()
	{
		return new _JniMarshal_PPLLLL_V(n_StartElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lorg_xml_sax_Attributes_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lorg_xml_sax_Attributes_(nint jnienv, nint native__this, nint native_uri, nint native_localName, nint native_qName, nint native_atts)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uri = JNIEnv.GetString(native_uri, JniHandleOwnership.DoNotTransfer);
			string localName = JNIEnv.GetString(native_localName, JniHandleOwnership.DoNotTransfer);
			string qName = JNIEnv.GetString(native_qName, JniHandleOwnership.DoNotTransfer);
			IAttributes atts = Java.Lang.Object.GetObject<IAttributes>(native_atts, JniHandleOwnership.DoNotTransfer);
			contentHandler.StartElement(uri, localName, qName, atts);
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

	public unsafe void StartElement(string? uri, string? localName, string? qName, IAttributes? atts)
	{
		nint num = JNIEnv.NewString(uri);
		nint num2 = JNIEnv.NewString(localName);
		nint num3 = JNIEnv.NewString(qName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue((atts == null) ? IntPtr.Zero : ((Java.Lang.Object)atts).Handle);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("startElement.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lorg/xml/sax/Attributes;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(atts);
		}
	}

	private static Delegate GetStartPrefixMapping_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_StartPrefixMapping_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartPrefixMapping_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_prefix, nint native_uri)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IContentHandler? contentHandler = Java.Lang.Object.GetObject<IContentHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			string uri = JNIEnv.GetString(native_uri, JniHandleOwnership.DoNotTransfer);
			contentHandler.StartPrefixMapping(prefix, uri);
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

	public unsafe void StartPrefixMapping(string? prefix, string? uri)
	{
		nint num = JNIEnv.NewString(prefix);
		nint num2 = JNIEnv.NewString(uri);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_org_xml_sax_ContentHandler.InstanceMethods.InvokeAbstractVoidMethod("startPrefixMapping.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
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
