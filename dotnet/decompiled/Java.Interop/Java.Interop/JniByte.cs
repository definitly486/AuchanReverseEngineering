using System;

namespace Java.Interop;

internal static class JniByte
{
	private static JniType? _TypeRef;

	private static JniMethodInfo? init;

	private static JniMethodInfo? byteValue;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Byte");

	internal unsafe static JniObjectReference CreateLocalRef(sbyte value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedConstructor(ref init, "(B)V");
		return TypeRef.NewObject(init, ptr);
	}

	internal static sbyte GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type? targetType)
	{
		TypeRef.GetCachedInstanceMethod(ref byteValue, "byteValue", "()B");
		try
		{
			return JniEnvironment.InstanceMethods.CallByteMethod(self, byteValue);
		}
		finally
		{
			JniObjectReference.Dispose(ref self, transfer);
		}
	}
}
