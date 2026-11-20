using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Runtime;
using Android.Util;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Org.XmlPull.V1;

namespace Android.Content.Res;

[Register("android/content/res/XmlResourceParser", DoNotGenerateAcw = true)]
internal class IXmlResourceParserInvoker : Java.Lang.Object, IXmlResourceParser, IAttributeSet, IJavaObject, IDisposable, IJavaPeerable, IXmlPullParser
{
	private static readonly JniPeerMembers _members_android_content_res_XmlResourceParser = new XAPeerMembers("android/content/res/XmlResourceParser", typeof(IXmlResourceParserInvoker));

	private static readonly JniPeerMembers _members_android_util_AttributeSet = new XAPeerMembers("android/util/AttributeSet", typeof(IXmlResourceParserInvoker));

	private static readonly JniPeerMembers _members_org_xmlpull_v1_XmlPullParser = new XAPeerMembers("org/xmlpull/v1/XmlPullParser", typeof(IXmlResourceParserInvoker));

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_getAttributeNamespace_GetAttributeNamespace_I_Ljava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_res_XmlResourceParser;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_res_XmlResourceParser.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_res_XmlResourceParser.ManagedPeerType;

	public unsafe int AttributeCount => _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeCount.()I", this, null);

	public unsafe string? ClassAttribute => JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getClassAttribute.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? IdAttribute => JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getIdAttribute.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? PositionDescription => JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getPositionDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int StyleAttribute => _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getStyleAttribute.()I", this, null);

	public unsafe int ColumnNumber => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getColumnNumber.()I", this, null);

	public unsafe int Depth => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getDepth.()I", this, null);

	public unsafe XmlPullParserNode EventType => (XmlPullParserNode)_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getEventType.()I", this, null);

	public unsafe string? InputEncoding => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getInputEncoding.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsEmptyElementTag => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractBooleanMethod("isEmptyElementTag.()Z", this, null);

	public unsafe bool IsWhitespace => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractBooleanMethod("isWhitespace.()Z", this, null);

	public unsafe int LineNumber => _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getLineNumber.()I", this, null);

	public unsafe string? Name => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Namespace => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getNamespace.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Prefix => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getPrefix.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Text => JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IXmlResourceParserInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IXmlResourceParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	public unsafe void Close()
	{
		_members_android_content_res_XmlResourceParser.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}

	[SupportedOSPlatform("android28.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributeNamespace_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IXmlResourceParser>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeNamespace(index));
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

	[SupportedOSPlatform("android28.0")]
	public unsafe string? GetAttributeNamespace(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_android_content_res_XmlResourceParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributeNamespace.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe bool GetAttributeBooleanValue(int index, bool defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue ? ((sbyte)1) : ((sbyte)0));
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractBooleanMethod("getAttributeBooleanValue.(IZ)Z", this, ptr);
	}

	public unsafe bool GetAttributeBooleanValue(string? @namespace, string? attribute, bool defaultValue)
	{
		nint num = JNIEnv.NewString(@namespace);
		nint num2 = JNIEnv.NewString(attribute);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(defaultValue ? ((sbyte)1) : ((sbyte)0));
			return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractBooleanMethod("getAttributeBooleanValue.(Ljava/lang/String;Ljava/lang/String;Z)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	public unsafe float GetAttributeFloatValue(int index, float defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractSingleMethod("getAttributeFloatValue.(IF)F", this, ptr);
	}

	public unsafe float GetAttributeFloatValue(string? @namespace, string? attribute, float defaultValue)
	{
		nint num = JNIEnv.NewString(@namespace);
		nint num2 = JNIEnv.NewString(attribute);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(defaultValue);
			return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractSingleMethod("getAttributeFloatValue.(Ljava/lang/String;Ljava/lang/String;F)F", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	public unsafe int GetAttributeIntValue(int index, int defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeIntValue.(II)I", this, ptr);
	}

	public unsafe int GetAttributeIntValue(string? @namespace, string? attribute, int defaultValue)
	{
		nint num = JNIEnv.NewString(@namespace);
		nint num2 = JNIEnv.NewString(attribute);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(defaultValue);
			return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeIntValue.(Ljava/lang/String;Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	public unsafe int GetAttributeListValue(int index, string[]? options, int defaultValue)
	{
		nint num = JNIEnv.NewArray(options);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(index);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(defaultValue);
			return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeListValue.(I[Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			if (options != null)
			{
				JNIEnv.CopyArray(num, options);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(options);
		}
	}

	public unsafe int GetAttributeListValue(string? @namespace, string? attribute, string[]? options, int defaultValue)
	{
		nint num = JNIEnv.NewString(@namespace);
		nint num2 = JNIEnv.NewString(attribute);
		nint num3 = JNIEnv.NewArray(options);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(defaultValue);
			return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeListValue.(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			if (options != null)
			{
				JNIEnv.CopyArray(num3, options);
				JNIEnv.DeleteLocalRef(num3);
			}
			GC.KeepAlive(options);
		}
	}

	public unsafe string? GetAttributeName(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getAttributeName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe int GetAttributeNameResource(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeNameResource.(I)I", this, ptr);
	}

	public unsafe int GetAttributeResourceValue(int index, int defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeResourceValue.(II)I", this, ptr);
	}

	public unsafe int GetAttributeResourceValue(string? @namespace, string? attribute, int defaultValue)
	{
		nint num = JNIEnv.NewString(@namespace);
		nint num2 = JNIEnv.NewString(attribute);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(defaultValue);
			return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeResourceValue.(Ljava/lang/String;Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	public unsafe int GetAttributeUnsignedIntValue(int index, int defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeUnsignedIntValue.(II)I", this, ptr);
	}

	public unsafe int GetAttributeUnsignedIntValue(string? @namespace, string? attribute, int defaultValue)
	{
		nint num = JNIEnv.NewString(@namespace);
		nint num2 = JNIEnv.NewString(attribute);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(defaultValue);
			return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeUnsignedIntValue.(Ljava/lang/String;Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	public unsafe string? GetAttributeValue(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getAttributeValue.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getAttributeValue.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	public unsafe int GetIdAttributeResourceValue(int defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getIdAttributeResourceValue.(I)I", this, ptr);
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

	public unsafe string? GetAttributePrefix(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributePrefix.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe string? GetAttributeType(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getAttributeType.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe int GetNamespaceCount(int depth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(depth);
		return _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("getNamespaceCount.(I)I", this, ptr);
	}

	public unsafe string? GetNamespacePrefix(int pos)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pos);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getNamespacePrefix.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe string? GetNamespaceUri(int pos)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pos);
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("getNamespaceUri.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe bool IsAttributeDefault(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractBooleanMethod("isAttributeDefault.(I)Z", this, ptr);
	}

	public unsafe XmlPullParserNode Next()
	{
		return (XmlPullParserNode)_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("next.()I", this, null);
	}

	public unsafe XmlPullParserNode NextTag()
	{
		return (XmlPullParserNode)_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("nextTag.()I", this, null);
	}

	public unsafe string? NextText()
	{
		return JNIEnv.GetString(_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractObjectMethod("nextText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe XmlPullParserNode NextToken()
	{
		return (XmlPullParserNode)_members_org_xmlpull_v1_XmlPullParser.InstanceMethods.InvokeAbstractInt32Method("nextToken.()I", this, null);
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
	private static void n_Close_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Close(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
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
}
