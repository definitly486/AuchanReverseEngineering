using System;

namespace Java.Interop;

internal static class JniInteger
{
	private static JniType? _TypeRef;

	private static JniMethodInfo? init;

	private static JniMethodInfo? intValue;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Integer");

	internal unsafe static JniObjectReference CreateLocalRef(int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedConstructor(ref init, "(I)V");
		return TypeRef.NewObject(init, ptr);
	}

	internal static int GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type? targetType)
	{
		TypeRef.GetCachedInstanceMethod(ref intValue, "intValue", "()I");
		try
		{
			return JniEnvironment.InstanceMethods.CallIntMethod(self, intValue);
		}
		finally
		{
			JniObjectReference.Dispose(ref self, transfer);
		}
	}
}
