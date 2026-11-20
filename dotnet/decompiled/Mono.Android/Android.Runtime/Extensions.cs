using System.Diagnostics.CodeAnalysis;
using Java.Interop;

namespace Android.Runtime;

public static class Extensions
{
	[return: NotNullIfNotNull("instance")]
	public static TResult? JavaCast<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] TResult>(this IJavaObject? instance) where TResult : class, IJavaObject
	{
		return JavaObjectExtensions.JavaCast<TResult>(instance);
	}
}
