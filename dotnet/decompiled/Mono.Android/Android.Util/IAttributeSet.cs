using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Util;

[Register("android/util/AttributeSet", "", "Android.Util.IAttributeSetInvoker")]
public interface IAttributeSet : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/util/AttributeSet", typeof(IAttributeSet), isInterface: true);

	private static Delegate? cb_getAttributeNamespace_GetAttributeNamespace_I_Ljava_lang_String_;

	int AttributeCount
	{
		[Register("getAttributeCount", "()I", "GetGetAttributeCountHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? ClassAttribute
	{
		[Register("getClassAttribute", "()Ljava/lang/String;", "GetGetClassAttributeHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? IdAttribute
	{
		[Register("getIdAttribute", "()Ljava/lang/String;", "GetGetIdAttributeHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? PositionDescription
	{
		[Register("getPositionDescription", "()Ljava/lang/String;", "GetGetPositionDescriptionHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int StyleAttribute
	{
		[Register("getStyleAttribute", "()I", "GetGetStyleAttributeHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("getAttributeBooleanValue", "(IZ)Z", "GetGetAttributeBooleanValue_IZHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool GetAttributeBooleanValue(int index, bool defaultValue);

	[Register("getAttributeBooleanValue", "(Ljava/lang/String;Ljava/lang/String;Z)Z", "GetGetAttributeBooleanValue_Ljava_lang_String_Ljava_lang_String_ZHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool GetAttributeBooleanValue(string? @namespace, string? attribute, bool defaultValue);

	[Register("getAttributeFloatValue", "(IF)F", "GetGetAttributeFloatValue_IFHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	float GetAttributeFloatValue(int index, float defaultValue);

	[Register("getAttributeFloatValue", "(Ljava/lang/String;Ljava/lang/String;F)F", "GetGetAttributeFloatValue_Ljava_lang_String_Ljava_lang_String_FHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	float GetAttributeFloatValue(string? @namespace, string? attribute, float defaultValue);

	[Register("getAttributeIntValue", "(II)I", "GetGetAttributeIntValue_IIHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeIntValue(int index, int defaultValue);

	[Register("getAttributeIntValue", "(Ljava/lang/String;Ljava/lang/String;I)I", "GetGetAttributeIntValue_Ljava_lang_String_Ljava_lang_String_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeIntValue(string? @namespace, string? attribute, int defaultValue);

	[Register("getAttributeListValue", "(I[Ljava/lang/String;I)I", "GetGetAttributeListValue_IarrayLjava_lang_String_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeListValue(int index, string[]? options, int defaultValue);

	[Register("getAttributeListValue", "(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;I)I", "GetGetAttributeListValue_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeListValue(string? @namespace, string? attribute, string[]? options, int defaultValue);

	[Register("getAttributeName", "(I)Ljava/lang/String;", "GetGetAttributeName_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributeName(int index);

	[Register("getAttributeNameResource", "(I)I", "GetGetAttributeNameResource_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeNameResource(int index);

	[Register("getAttributeResourceValue", "(II)I", "GetGetAttributeResourceValue_IIHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeResourceValue(int index, int defaultValue);

	[Register("getAttributeResourceValue", "(Ljava/lang/String;Ljava/lang/String;I)I", "GetGetAttributeResourceValue_Ljava_lang_String_Ljava_lang_String_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeResourceValue(string? @namespace, string? attribute, int defaultValue);

	[Register("getAttributeUnsignedIntValue", "(II)I", "GetGetAttributeUnsignedIntValue_IIHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeUnsignedIntValue(int index, int defaultValue);

	[Register("getAttributeUnsignedIntValue", "(Ljava/lang/String;Ljava/lang/String;I)I", "GetGetAttributeUnsignedIntValue_Ljava_lang_String_Ljava_lang_String_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetAttributeUnsignedIntValue(string? @namespace, string? attribute, int defaultValue);

	[Register("getAttributeValue", "(I)Ljava/lang/String;", "GetGetAttributeValue_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributeValue(int index);

	[Register("getAttributeValue", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "GetGetAttributeValue_Ljava_lang_String_Ljava_lang_String_Handler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributeValue(string? @namespace, string? name);

	[Register("getIdAttributeResourceValue", "(I)I", "GetGetIdAttributeResourceValue_IHandler:Android.Util.IAttributeSetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetIdAttributeResourceValue(int defaultValue);

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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IAttributeSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAttributeNamespace(index));
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
	[Register("getAttributeNamespace", "(I)Ljava/lang/String;", "GetGetAttributeNamespace_IHandler:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 28)]
	unsafe string? GetAttributeNamespace(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAttributeNamespace.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
