using System;

namespace Java.Interop;

internal static class JniBoolean
{
	private static JniType? _TypeRef;

	private static JniMethodInfo? init;

	private static JniMethodInfo? booleanValue;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Boolean");

	internal unsafe static JniObjectReference CreateLocalRef(bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedConstructor(ref init, "(Z)V");
		return TypeRef.NewObject(init, ptr);
	}

	internal static bool GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type? targetType)
	{
		TypeRef.GetCachedInstanceMethod(ref booleanValue, "booleanValue", "()Z");
		try
		{
			return JniEnvironment.InstanceMethods.CallBooleanMethod(self, booleanValue);
		}
		finally
		{
			JniObjectReference.Dispose(ref self, transfer);
		}
	}
}
