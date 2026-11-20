namespace Java.Interop;

internal static class JniSystem
{
	private static JniType? _typeRef;

	private static JniMethodInfo? _identityHashCode;

	private static JniType TypeRef => JniType.GetCachedJniType(ref _typeRef, "java/lang/System");

	internal unsafe static int IdentityHashCode(JniObjectReference value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		TypeRef.GetCachedStaticMethod(ref _identityHashCode, "identityHashCode", "(Ljava/lang/Object;)I");
		return JniEnvironment.StaticMethods.CallStaticIntMethod(TypeRef.PeerReference, _identityHashCode, ptr);
	}
}
