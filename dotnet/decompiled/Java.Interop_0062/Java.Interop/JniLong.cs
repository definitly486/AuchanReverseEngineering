using System;

namespace Java.Interop;

internal static class JniLong
{
	private static JniType? _TypeRef;

	private static JniMethodInfo? init;

	private static JniMethodInfo? longValue;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Long");

	internal unsafe static JniObjectReference CreateLocalRef(long value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedConstructor(ref init, "(J)V");
		return TypeRef.NewObject(init, ptr);
	}

	internal static long GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type? targetType)
	{
		TypeRef.GetCachedInstanceMethod(ref longValue, "longValue", "()J");
		try
		{
			return JniEnvironment.InstanceMethods.CallLongMethod(self, longValue);
		}
		finally
		{
			JniObjectReference.Dispose(ref self, transfer);
		}
	}
}
