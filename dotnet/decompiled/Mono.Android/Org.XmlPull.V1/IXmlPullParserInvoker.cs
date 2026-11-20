using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Org.XmlPull.V1;

[Register("org/xmlpull/v1/XmlPullParser", DoNotGenerateAcw = true)]
internal class IXmlPullParserInvoker : Java.Lang.Object, IXmlPullParser, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_org_xmlpull_v1_XmlPullParser = new XAPeerMembers("org/xmlpull/v1/XmlPullParser", typeof(IXmlPullParserInvoker));

	private static Delegate? cb_getAttributeCount_GetAttributeCount_I;

	private static Delegate? cb_getColumnNumber_GetColumnNumber_I;

	private static Delegate? cb_getDepth_GetDepth_I;

	private static Delegate? cb_getEventType_GetEventType_I;

	private static Delegate? cb_getInputEncoding_GetInputEncoding_Ljava_lang_String_;

	private static Delegate? cb_isEmptyElementTag_IsEmptyElementTag_Z;

	private static Delegate? cb_isWhitespace_IsWhitespace_Z;

	private static Delegate? cb_getLineNumber_GetLineNumber_I;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getNamespace_GetNamespace_Ljava_lang_String_;

	private static Delegate? cb_getPositionDescription_GetPositionDescription_Ljava_lang_String_;

	private static Delegate? cb_getPrefix_GetPrefix_Ljava_lang_String_;

	private static Delegate? cb_getText_GetText_Ljava_lang_String_;

	private static Delegate? cb_defineEntityReplacementText_DefineEntityReplacementText_Ljava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_getAttributeName_GetAttributeName_I_Ljava_lang_String_;

	private static Delegate? cb_getAttributeNamespace_GetAttributeNamespace_I_Ljava_lang_String_;

	private static Delegate? cb_getAttributePrefix_GetAttributePrefix_I_Ljava_lang_String_;

	private static Delegate? cb_getAttributeType_GetAttributeType_I_Ljava_lang_String_;

	private static Delegate? cb_getAttributeValue_GetAttributeValue_I_Ljava_lang_String_;

	private static Delegate? cb_getAttributeValue_GetAttributeValue_Ljava_lang_String_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getFeature_GetFeature_Ljava_lang_String__Z;

	private static Delegate? cb_getNamespace_GetNamespace_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getNamespaceCount_GetNamespaceCount_I_I;

	private static Delegate? cb_getNamespacePrefix_GetNamespacePrefix_I_Ljava_lang_String_;

	private static Delegate? cb_getNamespaceUri_GetNamespaceUri_I_Ljava_lang_String_;

	private static Delegate? cb_getProperty_GetProperty_Ljava_lang_String__Ljava_lang_Object_;

	private static Delegate? cb_getTextCharacters_GetTextCharacters_arrayI_arrayC;

	private static Delegate? cb_isAttributeDefault_IsAttributeDefault_I_Z;

	private static Delegate? cb_next_Next_I;

	private static Delegate? cb_nextTag_NextTag_I;

	private static Delegate? cb_nextText_NextText_Ljava_lang_String_;

	private static Delegate? cb_nextToken_NextToken_I;

	private static Delegate? cb_require_Require_ILjava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_setFeature_SetFeature_Ljava_lang_String_Z_V;

	private static Delegate? cb_setInput_SetInput_Ljava_io_InputStream_Ljava_lang_String__V;

	private static Delegate? cb_setInput_SetInput_Ljava_io_Reader__V;

	private static Delegate? cb_setProperty_SetProperty_Ljava_lang_String_Ljava_lang_Object__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_org_xmlpull_v1_XmlPullParser;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_org_xmlpull_v1_XmlPullParser.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_org_xmlpull_v1_XmlPullParser.ManagedPeerType;

	public unsafe int AttributeCount => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getAttributeCount.()I", this, null);

	public unsafe int ColumnNumber => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getColumnNumber.()I", this, null);

	public unsafe int Depth => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getDepth.()I", this, null);

	public unsafe XmlPullParserNode EventType => (XmlPullParserNode)_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getEventType.()I", this, null);

	public unsafe string? InputEncoding => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getInputEncoding.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsEmptyElementTag => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractBooleanMethod("isEmptyElementTag.()Z", this, null);

	public unsafe bool IsWhitespace => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractBooleanMethod("isWhitespace.()Z", this, null);

	public unsafe int LineNumber => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getLineNumber.()I", this, null);

	public unsafe string? Name => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Namespace => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getNamespace.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? PositionDescription => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getPositionDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Prefix => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getPrefix.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Text => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IXmlPullParserInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AttributeCount;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColumnNumber(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnNumber;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDepth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Depth;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetEventType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EventType;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInputEncoding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputEncoding);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEmptyElementTag(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmptyElementTag ? ((sbyte)1) : ((sbyte)0);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsWhitespace(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsWhitespace ? ((sbyte)1) : ((sbyte)0);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLineNumber(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LineNumber;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNamespace(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Namespace);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPositionDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PositionDescription);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPrefix(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Prefix);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Text);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DefineEntityReplacementText_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_entityName, nint native_replacementText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string entityName = JNIEnv.GetString(native_entityName, JniHandleOwnership.DoNotTransfer);
			string replacementText = JNIEnv.GetString(native_replacementText, JniHandleOwnership.DoNotTransfer);
			xmlPullParser.DefineEntityReplacementText(entityName, replacementText);
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

	public unsafe void DefineEntityReplacementText(string? entityName, string? replacementText)
	{
		nint num = JNIEnv.NewString(entityName);
		nint num2 = JNIEnv.NewString(replacementText);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractVoidMethod("defineEntityReplacementText.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributeName_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeName(index));
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

	public unsafe string? GetAttributeName(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributeName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributeNamespace_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeNamespace(index));
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

	public unsafe string? GetAttributeNamespace(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributeNamespace.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributePrefix_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributePrefix(index));
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

	public unsafe string? GetAttributePrefix(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributePrefix.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributeType_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeType(index));
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

	public unsafe string? GetAttributeType(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributeType.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributeValue_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeValue(index));
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

	public unsafe string? GetAttributeValue(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributeValue.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributeValue_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native__namespace, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(xmlPullParser.GetAttributeValue(text, name));
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

	public unsafe string? GetAttributeValue(string? @namespace, string? name)
	{
		nint num = JNIEnv.NewString(@namespace);
		nint num2 = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributeValue.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
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
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return xmlPullParser.GetFeature(name) ? ((sbyte)1) : ((sbyte)0);
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
			return _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractBooleanMethod("getFeature.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNamespace_Ljava_lang_String_(nint jnienv, nint native__this, nint native_prefix)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(xmlPullParser.GetNamespace(prefix));
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

	public unsafe string? GetNamespace(string? prefix)
	{
		nint num = JNIEnv.NewString(prefix);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getNamespace.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNamespaceCount_I(nint jnienv, nint native__this, int depth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetNamespaceCount(depth);
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

	public unsafe int GetNamespaceCount(int depth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(depth);
		return _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getNamespaceCount.(I)I", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNamespacePrefix_I(nint jnienv, nint native__this, int pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetNamespacePrefix(pos));
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

	public unsafe string? GetNamespacePrefix(int pos)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pos);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getNamespacePrefix.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNamespaceUri_I(nint jnienv, nint native__this, int pos)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetNamespaceUri(pos));
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

	public unsafe string? GetNamespaceUri(int pos)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pos);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getNamespaceUri.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(xmlPullParser.GetProperty(name));
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
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getProperty.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTextCharacters_arrayI(nint jnienv, nint native__this, nint native_holderForStartAndLength)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_holderForStartAndLength, JniHandleOwnership.DoNotTransfer, typeof(int));
			nint result = JNIEnv.NewArray(xmlPullParser.GetTextCharacters(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_holderForStartAndLength);
			}
			return result;
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

	public unsafe char[]? GetTextCharacters(int[]? holderForStartAndLength)
	{
		nint num = JNIEnv.NewArray(holderForStartAndLength);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return (char[])JNIEnv.GetArray(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getTextCharacters.([I)[C", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(char));
		}
		finally
		{
			if (holderForStartAndLength != null)
			{
				JNIEnv.CopyArray(num, holderForStartAndLength);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(holderForStartAndLength);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAttributeDefault_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAttributeDefault(index) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool IsAttributeDefault(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractBooleanMethod("isAttributeDefault.(I)Z", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Next(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Next();
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

	public unsafe XmlPullParserNode Next()
	{
		return (XmlPullParserNode)_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("next.()I", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_NextTag(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextTag();
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

	public unsafe XmlPullParserNode NextTag()
	{
		return (XmlPullParserNode)_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("nextTag.()I", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NextText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextText());
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

	public unsafe string? NextText()
	{
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("nextText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_NextToken(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextToken();
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

	public unsafe XmlPullParserNode NextToken()
	{
		return (XmlPullParserNode)_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("nextToken.()I", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Require_ILjava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, int native_type, nint native__namespace, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			xmlPullParser.Require((XmlPullParserNode)native_type, text, name);
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

	public unsafe void Require(XmlPullParserNode type, string? @namespace, string? name)
	{
		nint num = JNIEnv.NewString(@namespace);
		nint num2 = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((int)type);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractVoidMethod("require.(ILjava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFeature_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_name, sbyte native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			bool state = native_state != 0;
			xmlPullParser.SetFeature(name, state);
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

	public unsafe void SetFeature(string? name, bool state)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(state ? ((sbyte)1) : ((sbyte)0));
			_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractVoidMethod("setFeature.(Ljava/lang/String;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInput_Ljava_io_InputStream_Ljava_lang_String_(nint jnienv, nint native__this, nint native_inputStream, nint native_inputEncoding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Stream inputStream = Android.Runtime.InputStreamInvoker.FromJniHandle(native_inputStream, JniHandleOwnership.DoNotTransfer);
			string inputEncoding = JNIEnv.GetString(native_inputEncoding, JniHandleOwnership.DoNotTransfer);
			xmlPullParser.SetInput(inputStream, inputEncoding);
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

	public unsafe void SetInput(Stream? inputStream, string? inputEncoding)
	{
		nint num = InputStreamAdapter.ToLocalJniHandle(inputStream);
		nint num2 = JNIEnv.NewString(inputEncoding);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractVoidMethod("setInput.(Ljava/io/InputStream;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(inputStream);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInput_Ljava_io_Reader_(nint jnienv, nint native__this, nint native__in)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Reader input = Java.Lang.Object.GetObject<Reader>(native__in, JniHandleOwnership.DoNotTransfer);
			xmlPullParser.SetInput(input);
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

	public unsafe void SetInput(Reader? @in)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(@in?.Handle ?? IntPtr.Zero);
			_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractVoidMethod("setInput.(Ljava/io/Reader;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@in);
		}
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
			IXmlPullParser? xmlPullParser = Java.Lang.Object.GetObject<IXmlPullParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			xmlPullParser.SetProperty(name, value);
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
			_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractVoidMethod("setProperty.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
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

	[UnmanagedCallersOnly]
	private static int n_GetAttributeCount_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeCount(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetColumnNumber_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetColumnNumber(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetDepth_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetDepth(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetEventType_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetEventType(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetInputEncoding_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetInputEncoding(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_IsEmptyElementTag_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_IsEmptyElementTag(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_IsWhitespace_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_IsWhitespace(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetLineNumber_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetLineNumber(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetName_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetName(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetNamespace_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetNamespace(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetPositionDescription_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetPositionDescription(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetPrefix_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetPrefix(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetText_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetText(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_DefineEntityReplacementText_Ljava_lang_String_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_entityName, nint native_replacementText)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_DefineEntityReplacementText_Ljava_lang_String_Ljava_lang_String_(jnienv, native__this, native_entityName, native_replacementText);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetAttributeName_I_mm_wrapper(nint jnienv, nint native__this, int index)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeName_I(jnienv, native__this, index);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetAttributeNamespace_I_mm_wrapper(nint jnienv, nint native__this, int index)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeNamespace_I(jnienv, native__this, index);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetAttributePrefix_I_mm_wrapper(nint jnienv, nint native__this, int index)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributePrefix_I(jnienv, native__this, index);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetAttributeType_I_mm_wrapper(nint jnienv, nint native__this, int index)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeType_I(jnienv, native__this, index);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetAttributeValue_I_mm_wrapper(nint jnienv, nint native__this, int index)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeValue_I(jnienv, native__this, index);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetAttributeValue_Ljava_lang_String_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native__namespace, nint native_name)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeValue_Ljava_lang_String_Ljava_lang_String_(jnienv, native__this, native__namespace, native_name);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_GetFeature_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_name)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetFeature_Ljava_lang_String_(jnienv, native__this, native_name);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetNamespace_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_prefix)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetNamespace_Ljava_lang_String_(jnienv, native__this, native_prefix);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetNamespaceCount_I_mm_wrapper(nint jnienv, nint native__this, int depth)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetNamespaceCount_I(jnienv, native__this, depth);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetNamespacePrefix_I_mm_wrapper(nint jnienv, nint native__this, int pos)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetNamespacePrefix_I(jnienv, native__this, pos);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetNamespaceUri_I_mm_wrapper(nint jnienv, nint native__this, int pos)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetNamespaceUri_I(jnienv, native__this, pos);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetProperty_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_name)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetProperty_Ljava_lang_String_(jnienv, native__this, native_name);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetTextCharacters_arrayI_mm_wrapper(nint jnienv, nint native__this, nint native_holderForStartAndLength)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetTextCharacters_arrayI(jnienv, native__this, native_holderForStartAndLength);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_IsAttributeDefault_I_mm_wrapper(nint jnienv, nint native__this, int index)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_IsAttributeDefault_I(jnienv, native__this, index);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_Next_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_Next(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_NextTag_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_NextTag(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_NextText_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_NextText(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_NextToken_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_NextToken(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_Require_ILjava_lang_String_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, int native_type, nint native__namespace, nint native_name)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Require_ILjava_lang_String_Ljava_lang_String_(jnienv, native__this, native_type, native__namespace, native_name);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetFeature_Ljava_lang_String_Z_mm_wrapper(nint jnienv, nint native__this, nint native_name, sbyte native_state)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetFeature_Ljava_lang_String_Z(jnienv, native__this, native_name, native_state);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetInput_Ljava_io_InputStream_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_inputStream, nint native_inputEncoding)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetInput_Ljava_io_InputStream_Ljava_lang_String_(jnienv, native__this, native_inputStream, native_inputEncoding);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetInput_Ljava_io_Reader__mm_wrapper(nint jnienv, nint native__this, nint native__in)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetInput_Ljava_io_Reader_(jnienv, native__this, native__in);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetProperty_Ljava_lang_String_Ljava_lang_Object__mm_wrapper(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetProperty_Ljava_lang_String_Ljava_lang_Object_(jnienv, native__this, native_name, native_value);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
