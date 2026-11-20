using System;

namespace Java.Interop;

internal static class JniDouble
{
	private static JniType? _TypeRef;

	private static JniMethodInfo? init;

	private static JniMethodInfo? doubleValue;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Double");

	internal unsafe static JniObjectReference CreateLocalRef(double value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedConstructor(ref init, "(D)V");
		return TypeRef.NewObject(init, ptr);
	}

	internal static double GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type? targetType)
	{
		TypeRef.GetCachedInstanceMethod(ref doubleValue, "doubleValue", "()D");
		try
		{
			return JniEnvironment.InstanceMethods.CallDoubleMethod(self, doubleValue);
		}
		finally
		{
			JniObjectReference.Dispose(ref self, transfer);
		}
	}
}
