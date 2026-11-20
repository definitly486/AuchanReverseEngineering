using System;

namespace Java.Interop;

internal static class JniFloat
{
	private static JniType? _TypeRef;

	private static JniMethodInfo? init;

	private static JniMethodInfo? floatValue;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Float");

	internal unsafe static JniObjectReference CreateLocalRef(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedConstructor(ref init, "(F)V");
		return TypeRef.NewObject(init, ptr);
	}

	internal static float GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type? targetType)
	{
		TypeRef.GetCachedInstanceMethod(ref floatValue, "floatValue", "()F");
		try
		{
			return JniEnvironment.InstanceMethods.CallFloatMethod(self, floatValue);
		}
		finally
		{
			JniObjectReference.Dispose(ref self, transfer);
		}
	}
}
