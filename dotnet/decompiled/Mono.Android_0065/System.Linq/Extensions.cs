using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Android.Runtime;
using Java.Interop;
using Java.Util;

namespace System.Linq;

public static class Extensions
{
	private static nint id_next;

	static Extensions()
	{
		nint num = JNIEnv.FindClass("java/util/Iterator");
		id_next = JNIEnv.GetMethodID(num, "next", "()Ljava/lang/Object;");
		JNIEnv.DeleteGlobalRef(num);
	}

	internal static IEnumerator ToEnumerator_Dispose(this IIterator source)
	{
		using (source)
		{
			while (source.HasNext)
			{
				yield return JavaConvert.FromJniHandle(JNIEnv.CallObjectMethod(source.Handle, id_next), JniHandleOwnership.TransferLocalRef);
			}
		}
	}

	internal static IEnumerator<T> ToEnumerator_Dispose<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(this IIterator source)
	{
		using (source)
		{
			while (source.HasNext)
			{
				yield return JavaConvert.FromJniHandle<T>(JNIEnv.CallObjectMethod(source.Handle, id_next), JniHandleOwnership.TransferLocalRef);
			}
		}
	}
}
