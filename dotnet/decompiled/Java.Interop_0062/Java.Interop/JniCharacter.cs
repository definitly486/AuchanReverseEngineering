using System;

namespace Java.Interop;

internal static class JniCharacter
{
	private static JniType? _TypeRef;

	private static JniMethodInfo? init;

	private static JniMethodInfo? charValue;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Character");

	internal unsafe static JniObjectReference CreateLocalRef(char value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedConstructor(ref init, "(C)V");
		return TypeRef.NewObject(init, ptr);
	}

	internal static char GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type? targetType)
	{
		TypeRef.GetCachedInstanceMethod(ref charValue, "charValue", "()C");
		try
		{
			return JniEnvironment.InstanceMethods.CallCharMethod(self, charValue);
		}
		finally
		{
			JniObjectReference.Dispose(ref self, transfer);
		}
	}
}
