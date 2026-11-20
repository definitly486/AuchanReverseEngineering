using System;

namespace Java.Interop;

internal static class JniShort
{
	private static JniType? _TypeRef;

	private static JniMethodInfo? init;

	private static JniMethodInfo? shortValue;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Short");

	internal unsafe static JniObjectReference CreateLocalRef(short value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedConstructor(ref init, "(S)V");
		return TypeRef.NewObject(init, ptr);
	}

	internal static short GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type? targetType)
	{
		TypeRef.GetCachedInstanceMethod(ref shortValue, "shortValue", "()S");
		try
		{
			return JniEnvironment.InstanceMethods.CallShortMethod(self, shortValue);
		}
		finally
		{
			JniObjectReference.Dispose(ref self, transfer);
		}
	}
}
