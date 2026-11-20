using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Util;

[Register("android/util/AttributeSet", DoNotGenerateAcw = true)]
internal class IAttributeSetInvoker : Java.Lang.Object, IAttributeSet, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_util_AttributeSet = new XAPeerMembers("android/util/AttributeSet", typeof(IAttributeSetInvoker));

	private static Delegate? cb_getAttributeCount_GetAttributeCount_I;

	private static Delegate? cb_getClassAttribute_GetClassAttribute_Ljava_lang_String_;

	private static Delegate? cb_getIdAttribute_GetIdAttribute_Ljava_lang_String_;

	private static Delegate? cb_getPositionDescription_GetPositionDescription_Ljava_lang_String_;

	private static Delegate? cb_getStyleAttribute_GetStyleAttribute_I;

	private static Delegate? cb_getAttributeBooleanValue_GetAttributeBooleanValue_IZ_Z;

	private static Delegate? cb_getAttributeBooleanValue_GetAttributeBooleanValue_Ljava_lang_String_Ljava_lang_String_Z_Z;

	private static Delegate? cb_getAttributeFloatValue_GetAttributeFloatValue_IF_F;

	private static Delegate? cb_getAttributeFloatValue_GetAttributeFloatValue_Ljava_lang_String_Ljava_lang_String_F_F;

	private static Delegate? cb_getAttributeIntValue_GetAttributeIntValue_II_I;

	private static Delegate? cb_getAttributeIntValue_GetAttributeIntValue_Ljava_lang_String_Ljava_lang_String_I_I;

	private static Delegate? cb_getAttributeListValue_GetAttributeListValue_IarrayLjava_lang_String_I_I;

	private static Delegate? cb_getAttributeListValue_GetAttributeListValue_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_I_I;

	private static Delegate? cb_getAttributeName_GetAttributeName_I_Ljava_lang_String_;

	private static Delegate? cb_getAttributeNameResource_GetAttributeNameResource_I_I;

	private static Delegate? cb_getAttributeResourceValue_GetAttributeResourceValue_II_I;

	private static Delegate? cb_getAttributeResourceValue_GetAttributeResourceValue_Ljava_lang_String_Ljava_lang_String_I_I;

	private static Delegate? cb_getAttributeUnsignedIntValue_GetAttributeUnsignedIntValue_II_I;

	private static Delegate? cb_getAttributeUnsignedIntValue_GetAttributeUnsignedIntValue_Ljava_lang_String_Ljava_lang_String_I_I;

	private static Delegate? cb_getAttributeValue_GetAttributeValue_I_Ljava_lang_String_;

	private static Delegate? cb_getAttributeValue_GetAttributeValue_Ljava_lang_String_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getIdAttributeResourceValue_GetIdAttributeResourceValue_I_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_util_AttributeSet;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_util_AttributeSet.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_util_AttributeSet.ManagedPeerType;

	public unsafe int AttributeCount => _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeCount.()I", this, null);

	public unsafe string? ClassAttribute => JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getClassAttribute.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? IdAttribute => JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getIdAttribute.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? PositionDescription => JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getPositionDescription.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int StyleAttribute => _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getStyleAttribute.()I", this, null);

	public IAttributeSetInvoker(nint handle, JniHandleOwnership transfer)
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
			return Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AttributeCount;
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
	private static nint n_GetClassAttribute(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClassAttribute);
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
	private static nint n_GetIdAttribute(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IdAttribute);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PositionDescription);
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
	private static int n_GetStyleAttribute(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StyleAttribute;
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
	private static sbyte n_GetAttributeBooleanValue_IZ(nint jnienv, nint native__this, int index, sbyte native_defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool defaultValue = native_defaultValue != 0;
			return attributeSet.GetAttributeBooleanValue(index, defaultValue) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool GetAttributeBooleanValue(int index, bool defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue ? ((sbyte)1) : ((sbyte)0));
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractBooleanMethod("getAttributeBooleanValue.(IZ)Z", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetAttributeBooleanValue_Ljava_lang_String_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, sbyte native_defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string attribute = JNIEnv.GetString(native_attribute, JniHandleOwnership.DoNotTransfer);
			bool defaultValue = native_defaultValue != 0;
			return attributeSet.GetAttributeBooleanValue(text, attribute, defaultValue) ? ((sbyte)1) : ((sbyte)0);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetAttributeFloatValue_IF(nint jnienv, nint native__this, int index, float defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeFloatValue(index, defaultValue);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe float GetAttributeFloatValue(int index, float defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractSingleMethod("getAttributeFloatValue.(IF)F", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetAttributeFloatValue_Ljava_lang_String_Ljava_lang_String_F(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, float defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string attribute = JNIEnv.GetString(native_attribute, JniHandleOwnership.DoNotTransfer);
			return attributeSet.GetAttributeFloatValue(text, attribute, defaultValue);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeIntValue_II(nint jnienv, nint native__this, int index, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeIntValue(index, defaultValue);
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

	public unsafe int GetAttributeIntValue(int index, int defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeIntValue.(II)I", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeIntValue_Ljava_lang_String_Ljava_lang_String_I(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string attribute = JNIEnv.GetString(native_attribute, JniHandleOwnership.DoNotTransfer);
			return attributeSet.GetAttributeIntValue(text, attribute, defaultValue);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeListValue_IarrayLjava_lang_String_I(nint jnienv, nint native__this, int index, nint native_options, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_options, JniHandleOwnership.DoNotTransfer, typeof(string));
			int attributeListValue = attributeSet.GetAttributeListValue(index, array, defaultValue);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_options);
			}
			return attributeListValue;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeListValue_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_I(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, nint native_options, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string attribute = JNIEnv.GetString(native_attribute, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_options, JniHandleOwnership.DoNotTransfer, typeof(string));
			int attributeListValue = attributeSet.GetAttributeListValue(text, attribute, array, defaultValue);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_options);
			}
			return attributeListValue;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributeName_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeName(index));
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
		return JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getAttributeName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeNameResource_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeNameResource(index);
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

	public unsafe int GetAttributeNameResource(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeNameResource.(I)I", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeResourceValue_II(nint jnienv, nint native__this, int index, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeResourceValue(index, defaultValue);
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

	public unsafe int GetAttributeResourceValue(int index, int defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeResourceValue.(II)I", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeResourceValue_Ljava_lang_String_Ljava_lang_String_I(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string attribute = JNIEnv.GetString(native_attribute, JniHandleOwnership.DoNotTransfer);
			return attributeSet.GetAttributeResourceValue(text, attribute, defaultValue);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeUnsignedIntValue_II(nint jnienv, nint native__this, int index, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeUnsignedIntValue(index, defaultValue);
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

	public unsafe int GetAttributeUnsignedIntValue(int index, int defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getAttributeUnsignedIntValue.(II)I", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAttributeUnsignedIntValue_Ljava_lang_String_Ljava_lang_String_I(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string attribute = JNIEnv.GetString(native_attribute, JniHandleOwnership.DoNotTransfer);
			return attributeSet.GetAttributeUnsignedIntValue(text, attribute, defaultValue);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAttributeValue_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeValue(index));
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
		return JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getAttributeValue.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			IAttributeSet? attributeSet = Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native__namespace, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(attributeSet.GetAttributeValue(text, name));
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
			return JNIEnv.GetString(_members_android_util_AttributeSet.InstanceMethods.InvokeAbstractObjectMethod("getAttributeValue.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIdAttributeResourceValue_I(nint jnienv, nint native__this, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetIdAttributeResourceValue(defaultValue);
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

	public unsafe int GetIdAttributeResourceValue(int defaultValue)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(defaultValue);
		return _members_android_util_AttributeSet.InstanceMethods.InvokeAbstractInt32Method("getIdAttributeResourceValue.(I)I", this, ptr);
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
	private static nint n_GetClassAttribute_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetClassAttribute(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetIdAttribute_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetIdAttribute(jnienv, native__this);
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
	private static int n_GetStyleAttribute_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetStyleAttribute(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_GetAttributeBooleanValue_IZ_mm_wrapper(nint jnienv, nint native__this, int index, sbyte native_defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeBooleanValue_IZ(jnienv, native__this, index, native_defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_GetAttributeBooleanValue_Ljava_lang_String_Ljava_lang_String_Z_mm_wrapper(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, sbyte native_defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeBooleanValue_Ljava_lang_String_Ljava_lang_String_Z(jnienv, native__this, native__namespace, native_attribute, native_defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static float n_GetAttributeFloatValue_IF_mm_wrapper(nint jnienv, nint native__this, int index, float defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeFloatValue_IF(jnienv, native__this, index, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0f;
		}
	}

	[UnmanagedCallersOnly]
	private static float n_GetAttributeFloatValue_Ljava_lang_String_Ljava_lang_String_F_mm_wrapper(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, float defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeFloatValue_Ljava_lang_String_Ljava_lang_String_F(jnienv, native__this, native__namespace, native_attribute, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0f;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetAttributeIntValue_II_mm_wrapper(nint jnienv, nint native__this, int index, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeIntValue_II(jnienv, native__this, index, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetAttributeIntValue_Ljava_lang_String_Ljava_lang_String_I_mm_wrapper(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeIntValue_Ljava_lang_String_Ljava_lang_String_I(jnienv, native__this, native__namespace, native_attribute, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetAttributeListValue_IarrayLjava_lang_String_I_mm_wrapper(nint jnienv, nint native__this, int index, nint native_options, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeListValue_IarrayLjava_lang_String_I(jnienv, native__this, index, native_options, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetAttributeListValue_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_I_mm_wrapper(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, nint native_options, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeListValue_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_I(jnienv, native__this, native__namespace, native_attribute, native_options, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
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
	private static int n_GetAttributeNameResource_I_mm_wrapper(nint jnienv, nint native__this, int index)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeNameResource_I(jnienv, native__this, index);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetAttributeResourceValue_II_mm_wrapper(nint jnienv, nint native__this, int index, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeResourceValue_II(jnienv, native__this, index, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetAttributeResourceValue_Ljava_lang_String_Ljava_lang_String_I_mm_wrapper(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeResourceValue_Ljava_lang_String_Ljava_lang_String_I(jnienv, native__this, native__namespace, native_attribute, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetAttributeUnsignedIntValue_II_mm_wrapper(nint jnienv, nint native__this, int index, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeUnsignedIntValue_II(jnienv, native__this, index, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetAttributeUnsignedIntValue_Ljava_lang_String_Ljava_lang_String_I_mm_wrapper(nint jnienv, nint native__this, nint native__namespace, nint native_attribute, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAttributeUnsignedIntValue_Ljava_lang_String_Ljava_lang_String_I(jnienv, native__this, native__namespace, native_attribute, defaultValue);
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
	private static int n_GetIdAttributeResourceValue_I_mm_wrapper(nint jnienv, nint native__this, int defaultValue)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetIdAttributeResourceValue_I(jnienv, native__this, defaultValue);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
