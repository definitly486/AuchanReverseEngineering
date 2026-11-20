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

	int AttributeCount { get; }

	string? ClassAttribute { get; }

	string? IdAttribute { get; }

	string? PositionDescription { get; }

	int StyleAttribute { get; }

	bool GetAttributeBooleanValue(int index, bool defaultValue);

	bool GetAttributeBooleanValue(string? @namespace, string? attribute, bool defaultValue);

	float GetAttributeFloatValue(int index, float defaultValue);

	float GetAttributeFloatValue(string? @namespace, string? attribute, float defaultValue);

	int GetAttributeIntValue(int index, int defaultValue);

	int GetAttributeIntValue(string? @namespace, string? attribute, int defaultValue);

	int GetAttributeListValue(int index, string[]? options, int defaultValue);

	int GetAttributeListValue(string? @namespace, string? attribute, string[]? options, int defaultValue);

	string? GetAttributeName(int index);

	int GetAttributeNameResource(int index);

	int GetAttributeResourceValue(int index, int defaultValue);

	int GetAttributeResourceValue(string? @namespace, string? attribute, int defaultValue);

	int GetAttributeUnsignedIntValue(int index, int defaultValue);

	int GetAttributeUnsignedIntValue(string? @namespace, string? attribute, int defaultValue);

	string? GetAttributeValue(int index);

	string? GetAttributeValue(string? @namespace, string? name);

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
